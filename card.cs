using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackJJ
{
    internal class Card
    {
        public void DisplayCard()
        {
            List<string> cards = GetDeck();

            
            //foreach (string card in cards)
           // {
              //  Console.WriteLine(card);
          //  }
        }

        // hier maak ik method om 52 genereren 
        private List<string> GetDeck()
        {
            //hier maak ik lijst om kaarten op te slaan 
            List<string> deck = new List<string>();

            //hier maak ik 2 aar. 
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

           //deze foreach zorgt voor dat 4 deck worden gemaakt hearts en Diamons en Clubs en Spades.
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
        
        public List<List<string>> drawnCardsPerPlayer = new List<List<string>>();
        public Random random = new Random();

        public int scorepunten;
        public void DrawAndCalculate()
        {
            start start = new start();
            start.Gamestart();
            scorepunten = start.punten;
            




            int aantalDeelnemers = start.deelnemers;
            List<string> deck = GetDeck();

          
            Random random = new Random();

           
           

            // Maak lijsten voor elke deelnemer
            for (int i = 0; i < aantalDeelnemers; i++)
            {
                drawnCardsPerPlayer.Add(new List<string>());
            }

            // Teken kaarten voor elke deelnemer
            for (int i = 0; i < aantalDeelnemers; i++)
            {
                List<string> drawnCards = drawnCardsPerPlayer[i];
                for (int j = 0; j < 2; j++) 
                {
                    int randomIndex = random.Next(deck.Count);
                    drawnCards.Add(deck[randomIndex]);
                    deck.RemoveAt(randomIndex);
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

            Console.WriteLine("Choose an action: (H)it or (S)tand");
            string choice = Console.ReadLine().Trim().ToUpper();
            bool dealerbeurt = true;
            int dealer = drawnCardsPerPlayer.Count - 1; 

            while (dealerbeurt)
            {
                if (choice == "H")
                {
                    List<string> drawnCards = drawnCardsPerPlayer[dealer];
                    int randomIndex = random.Next(deck.Count);
                    drawnCards.Add(deck[randomIndex]);
                    deck.RemoveAt(randomIndex);

                    
                    Console.WriteLine($"Nieuwe card drawn: {drawnCards[drawnCards.Count - 1]}");

                   
                    int totalValue = CalculateTotalValue(drawnCards);
                    Console.WriteLine($"Total value nu: {totalValue}");

                    
                    if (totalValue > 21)
                    {
                        Console.WriteLine("Bust! jouw totale is over 21.");
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

            // totale per deelnemers berekend

            for (int i = 0; i < aantalDeelnemers; i++)
            {
                int totalValue = CalculateTotalValue(drawnCardsPerPlayer[i]);
                Console.WriteLine($"Totale waarde van getrokken kaarten voor deelnemer {i + 1}: {totalValue}");
                
            }
            DetermineWinner();
            
           

        }
        public void DetermineWinner()
        {
            int aantalDeelnemers = drawnCardsPerPlayer.Count;

            int winnendeTotaleWaarde = 0;
            int winnaarIndex = -1;
            bool gelijkspel = false;

            for (int i = 0; i < aantalDeelnemers; i++)
            {
                int totaleWaarde = CalculateTotalValue(drawnCardsPerPlayer[i]);

                if (totaleWaarde > 21)
                    continue;

                if (totaleWaarde == winnendeTotaleWaarde)
                {
                    gelijkspel = true;
                    break;
                }

                if (totaleWaarde > winnendeTotaleWaarde && totaleWaarde <= 21)
                {
                    winnendeTotaleWaarde = totaleWaarde;
                    winnaarIndex = i;
                }
            }

            if (gelijkspel)
            {
                Console.WriteLine("Gelijkspel! Niemand wint.");
                return;
            }

            if (winnaarIndex != -1)
            {
                Console.WriteLine($"Deelnemer {winnaarIndex + 1} wint met een totale waarde van {winnendeTotaleWaarde}!");
            }
            else
            {
                Console.WriteLine("Alle deelnemers zijn gediskwalificeerd!");
            }
            score score = new score();
            
            score.ScoreBijhouden(scorepunten, winnaarIndex + 1);
        }



        private int CalculateTotalValue(List<string> cards)
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
