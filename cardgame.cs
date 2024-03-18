using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJJ
{
    internal class CardGame
    {
        private List<string> deck;
        private List<List<string>> drawnCardsPerPlayer;
        private Dictionary<string, int> cardValues;

        public CardGame()
        {
            deck = GetDeck();
            drawnCardsPerPlayer = new List<List<string>>();
            cardValues = new Dictionary<string, int>
            {
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "10", 10 },
                { "Jack", 10 },
                { "Queen", 10 },
                { "King", 10 },
                { "Ace", 10 }
            };
        }

        private List<string> GetDeck()
        {
            List<string> deck = new List<string>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    string card = $"{value} of {suit}";
                    deck.Add(card);
                }
            }

            return deck;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to BlackJJ!");
            Console.Write("Enter number of players: ");
            int numberOfPlayers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPlayers; i++)
            {
                drawnCardsPerPlayer.Add(new List<string>());
            }

            DrawInitialCards();
            PlayRound();
        }

        private void DrawInitialCards()
        {
            Random random = new Random();

            foreach (var playerCards in drawnCardsPerPlayer)
            {
                for (int j = 0; j < 2; j++)
                {
                    int randomIndex = random.Next(deck.Count);
                    playerCards.Add(deck[randomIndex]);
                    deck.RemoveAt(randomIndex);
                }
            }
        }

        private void PlayRound()
        {
            foreach (var playerCards in drawnCardsPerPlayer)
            {
                Console.WriteLine("Player's Cards:");
                foreach (var card in playerCards)
                {
                    Console.WriteLine(card);
                }

                while (true)
                {
                    Console.WriteLine("Choose your action: (1: Hit, 2: Stand)");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1) // Hit
                    {
                        Hit(playerCards);
                        Console.WriteLine("Player's Cards:");
                        foreach (var card in playerCards)
                        {
                            Console.WriteLine(card);
                        }

                        if (CalculateTotalValue(playerCards) > 21)
                        {
                            Console.WriteLine("Bust!");
                            break;
                        }
                    }
                    else if (choice == 2) // Stand
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
            }

            Console.WriteLine("Final Results:");
            for (int i = 0; i < drawnCardsPerPlayer.Count; i++)
            {
                int totalValue = CalculateTotalValue(drawnCardsPerPlayer[i]);
                Console.WriteLine($"Player {i + 1}: Total value = {totalValue}");
            }
        }

        private void Hit(List<string> playerCards)
        {
            Random random = new Random();
            int randomIndex = random.Next(deck.Count);
            playerCards.Add(deck[randomIndex]);
            deck.RemoveAt(randomIndex);
        }

        private int CalculateTotalValue(List<string> cards)
        {
            int totalValue = 0;
            foreach (string card in cards)
            {
                string[] parts = card.Split(' ');
                string value = parts[0];
                totalValue += cardValues[value];
            }
            return totalValue;
        }
    }
}

