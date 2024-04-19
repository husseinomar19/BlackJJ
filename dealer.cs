using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJJ
{
    
    internal class dealer
    {
       public string choice;
       public bool dealerbeurt = true;
       public int dealerIndex;


        public void StandAndHit()
        {

            Card card = new Card();
            Random random = new Random();  
            Console.WriteLine("Choose an action: (H)it or (S)tand");
            choice = Console.ReadLine().Trim().ToUpper();
            dealerbeurt = true;
            Console
            .WriteLine(" aantal deeldeamer" + dealerIndex);

            while (dealerbeurt)
            {
                if (choice == "H")
                {
                    Console.WriteLine("aantal lijsst " + card.drawnCardsPerPlayer.Count);
                    /*card.drawnCards = card.drawnCardsPerPlayer[1];
                    int randomIndex = random.Next(card.deck.Count);
                    card.drawnCards.Add(card.deck[randomIndex]);
                    card.deck.RemoveAt(randomIndex);*/


                    Console.WriteLine($"Nieuwe card drawn: {card.drawnCards[card.drawnCards.Count - 1]}");


                    int totalValue = card.CalculateTotalValue(card.drawnCards);
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

            for (int i = 0; i < card.aantalDeelnemers; i++)
            {
                int totalValue = card.CalculateTotalValue(card.drawnCardsPerPlayer[i]);
                Console.WriteLine($"Totale waarde van getrokken kaarten voor deelnemer {i + 1}: {totalValue}");

            }
        }


    }
}
