using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Player player = new Player();
            player.Playing();
        }
    }
    class Player
    {
        public List<Card> hand = new List<Card>();
        Deck deck = new Deck();
        private bool _isPlaying = true;
        string input;
        public void Playing()
        {
            deck.BuildDeck();

            while (_isPlaying)
            {
                Console.WriteLine("1. Брать карты");
                Console.WriteLine("2. Посмотреть карты в руке");
                Console.WriteLine("3. Выход");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DrawCard(deck._deck);
                        break;
                    case "2":
                        ShowHand();
                        break;
                    case "3":
                        Exit();
                        break;
                }
            }
        }

        public void DrawCard(List<Card> _deck)
        {
            if (_deck.Count > 0)
            {
                Console.WriteLine("Как много вы хотите взять?");
                string input = Console.ReadLine();
                int wantToDraw;
                Random random = new Random();
                int selectedNumber;

                if (ChekInput(input, out wantToDraw) && wantToDraw <= _deck.Count)
                {
                    for (int i = 0; i < wantToDraw; i++)
                    {
                        selectedNumber = random.Next(1, _deck.Count);
                        hand.Add(_deck[selectedNumber-1]);
                        _deck.RemoveAt(selectedNumber-1);
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод,нажмите любую кнопку");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Карт больше нет,нажмите любую кнопку");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void ShowHand()
        {
            if (hand.Count != 0)
            {
                for (int i = 0; i < hand.Count; i++)
                {
                    Console.WriteLine();
                    hand[i].CardInfo();
                }
            }
            else 
            {
                Console.WriteLine("В руке пусто,нажмите любую кнопку");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private bool ChekInput(string input, out int number)
        {
            bool isCorrect;
            isCorrect = int.TryParse(input, out number);
            return isCorrect;
        }

        public void Exit()
        {
            _isPlaying = false;
        }
    }   

    class Deck
    {
        public List<Card> _deck = new List<Card>();
        int cardValueNumber = 9;
        int cardSuitNumber = 4;
        public void BuildDeck()
        {
            for (int i = 0; i < cardSuitNumber; i++)
            {
                for (int j = 0; j < cardValueNumber; j++)
                {
                    _deck.Add(new Card((Card.cardValue)j,(Card.cardSuit)i));
                }
            }
        }
    }

    class Card
    {
        private cardSuit _cardSuit;
        private cardValue _cardValue;

        public Card(cardValue cardValue,cardSuit cardSuit)
        {
            _cardSuit = cardSuit;
            _cardValue = cardValue;
        }

        public void CardInfo()
        {
            Console.WriteLine($"{_cardSuit} {_cardValue}");
        }

        public enum cardValue
        {
            Шесть,
            Семь,
            Восемь,
            Девять,
            Десять,
            Валет,
            Дама,
            Король,
            Туз
        }

        public enum cardSuit
        { 
            Червы,
            Пики,
            Крести,
            Бубны
        }
    }
}