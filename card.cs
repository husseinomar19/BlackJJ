using System;
using System.Collections;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace BlackJJ
{
    internal class Card
    {
        public List<List<string>> drawnCardsPerPlayer = new List<List<string>>();
        public Random random = new Random();
        public int ScoreDeelnemerpunten;
        public List<string> drawnCards;
        public int aantalDeelnemers;
        public List<string> deck;
        public void DisplayCard()
        {
            List<string> cards = GetDeck();
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
        
        
        public void DrawAndCalculate()
        {
            start start = new start();
            start.Gamestart();
            ScoreDeelnemerpunten = start.Punten;





            aantalDeelnemers = start.Deelnemers;
            deck = GetDeck();

          
            Random random = new Random();

            // Maak lijsten voor elke deelnemer
            for (int i = 0; i < aantalDeelnemers; i++)
            {
                drawnCardsPerPlayer.Add(new List<string>());
            }

            // Teken kaarten voor elke deelnemer
            // Eerst krijgt elke speler twee kaarten
            for (int i = 0; i < aantalDeelnemers; i++)
            {
                drawnCards = drawnCardsPerPlayer[i];

                // Twee kaarten voor elke speler
                for (int j = 0; j < 2; j++)
                {
                    int randomIndex = random.Next(deck.Count);
                    drawnCards.Add(deck[randomIndex]);
                    deck.RemoveAt(randomIndex);
                }
            }

            // Controleren of de totale kaartwaarde van elke speler (behalve de dealer) minder is dan 12
            for (int i = 0; i < aantalDeelnemers - 1; i++)
            {
                drawnCards = drawnCardsPerPlayer[i];
                int totalewaarde = CalculateTotalValue(drawnCards);

                // Extra kaarten trekken als de totale kaartwaarde minder is dan 12
                if (totalewaarde < 13)
                {
                    int extraKaarten = 13 - totalewaarde;

                    for (int k = 0; k < extraKaarten; k++)
                    {
                        int randomIndex = random.Next(deck.Count);
                        drawnCards.Add(deck[randomIndex]);
                        deck.RemoveAt(randomIndex);
                    }

                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Extra kaarten getrokken voor Speler {i + 1}");
                    Console.ForegroundColor = originalColor;
                }
            }


            Console.WriteLine("Getrokken kaarten per deelnemer:");
            for (int i = 0; i < aantalDeelnemers; i++)
            {
                Console.WriteLine($"Deelnemer {i + 1}:");
                foreach (string card in drawnCardsPerPlayer[i])
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Dealer beurt :: (H)it or (S)tand");
            string choice = Console.ReadLine().Trim().ToUpper();
            bool dealerbeurt = true;
            int dealer = drawnCardsPerPlayer.Count - 1;

            while (dealerbeurt)
            {
                if (choice == "H")
                {
                    drawnCards = drawnCardsPerPlayer[dealer];
                    int randomIndex = random.Next(deck.Count);
                    drawnCards.Add(deck[randomIndex]);
                    deck.RemoveAt(randomIndex);


                    Console.WriteLine($"Nieuwe card drawn voor Dealer: {drawnCards[drawnCards.Count - 1]}");


                    int totalValue = CalculateTotalValue(drawnCards);
                    Console.WriteLine($"Total value nu: {totalValue}");


                    if (totalValue > 21)
                    {
                        ConsoleColor originalColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bust! jouw totale is over 21.");
                        Console.ForegroundColor = originalColor;
                        dealerbeurt = false;
                    }
                    else
                    {

                        Console.WriteLine("H voor Hit S voor Stand:");
                        choice = Console.ReadLine().Trim().ToUpper();
                    }
                }
                else if (choice == "S")
                {
                    dealerbeurt = false;
                }
                else
                {
                    Console.WriteLine("opnieuw. H voor Hit en S voor Stand");
                    choice = Console.ReadLine().Trim().ToUpper();
                }
            }

            for (int i = 0; i < aantalDeelnemers; i++)
            {
                int totalValue = CalculateTotalValue(drawnCardsPerPlayer[i]);
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Totale waarde van getrokken kaarten voor deelnemer {i + 1}: {totalValue}");
                Console.ForegroundColor = originalColor;

            }

            deelnemer deel = new deelnemer();
            score scoreObject = new score();
            start startObject = new start();
            deel.DetermineWinner(this, startObject, scoreObject);
        }
        
        
        
        public int CalculateTotalValue(List<string> cards)
        {
            
            Dictionary<string, int> cardValues = new Dictionary<string, int>
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
