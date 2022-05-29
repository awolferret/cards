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
        private List<Card> hand = new List<Card>();
        Deck deck = new Deck();
        private bool _isPlaying = true;
        public void Playing()
        {
            deck.BuildDeck();

            while (_isPlaying)
            {
                Console.WriteLine("\n1. Брать карты");
                Console.WriteLine("2. Посмотреть карты в руке");
                Console.WriteLine("3. Выход");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DrawCard();
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

        public void DrawCard()
        {
            if (deck._deck.Count > 0)
            {
                Console.WriteLine("Как много вы хотите взять?");
                string input = Console.ReadLine();
                int wantToDraw;
                Random random = new Random();
                int selectedNumber;

                if (int.TryParse(input, out wantToDraw) && wantToDraw <= deck._deck.Count)
                {
                    for (int i = 0; i < wantToDraw; i++)
                    {
                        selectedNumber = random.Next(1, deck._deck.Count);
                        hand.Add(deck._deck[selectedNumber-1]);
                        deck._deck.RemoveAt(selectedNumber-1);
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

        public void Exit()
        {
            _isPlaying = false;
        }
    }   

    class Deck
    {
        public List<Card> _deck = new List<Card>();
        private int cardValueNumber = 9;
        private int cardSuitNumber = 4;
        public void BuildDeck()
        {
            for (int i = 0; i < cardSuitNumber; i++)
            {
                for (int j = 0; j < cardValueNumber; j++)
                {
                    _deck.Add(new Card((Card.CardValue)j,(Card.CardSuit)i));
                }
            }
        }
    }

    class Card
    {
        private CardSuit _cardSuit;
        private CardValue _cardValue;

        public Card(CardValue cardValue,CardSuit cardSuit)
        {
            _cardSuit = cardSuit;
            _cardValue = cardValue;
        }

        public void CardInfo()
        {
            Console.WriteLine($"{_cardSuit} {_cardValue}");
        }

        public enum CardValue
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

        public enum CardSuit
        { 
            Червы,
            Пики,
            Крести,
            Бубны
        }
    }
}