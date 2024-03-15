using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackJJ
{
    internal class Card
    {
        // Methode om de kaarten weer te geven
        public void DisplayCard()
        {
            // Haal de lijst met kaarten op vanuit de GetDeck-methode
            List<string> cards = GetDeck();

            // Ga door elke kaart in de lijst en geef deze weer op de console
            //foreach (string card in cards)
           // {
              //  Console.WriteLine(card);
          //  }
        }

        // Methode om een deck van 52 kaarten te genereren
        private List<string> GetDeck()
        {
            // Initialiseer een lege lijst om kaarten op te slaan
            List<string> deck = new List<string>();

            // Definieer de mogelijke kleuren en waarden van de kaarten
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            // Genereer kaarten voor elk mogelijke paar van kleur en waarde
            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    // Maak een kaartstring met de waarde en de kleur en voeg deze toe aan het deck
                    string card = $"{value} of {suit}";
                    deck.Add(card);
                }
            }

            // Geef het volledige deck van kaarten terug
            return deck;
        }

        // Methode om willekeurig vier kaarten te trekken, ze weer te geven en de totale waarde te berekenen
        public void DrawAndCalculate()
        {
            start start = new start();
            start.Gamestart(); // Haal aantal deelnemers op van de Start-klasse

            int aantalDeelnemers = start.deelnemers;
            List<string> deck = GetDeck();

            // Initialisatie van de willekeurige getallen generator
            Random random = new Random();

            // Lijst om de getrokken kaarten per deelnemer op te slaan
            List<List<string>> drawnCardsPerPlayer = new List<List<string>>();

            // Maak lijsten voor elke deelnemer
            for (int i = 0; i < aantalDeelnemers; i++)
            {
                drawnCardsPerPlayer.Add(new List<string>());
            }

            // Teken kaarten voor elke deelnemer
            for (int i = 0; i < aantalDeelnemers; i++)
            {
                List<string> drawnCards = drawnCardsPerPlayer[i];
                for (int j = 0; j < 2; j++) // Hier kun je 4 vervangen door het gewenste aantal kaarten per deelnemer
                {
                    int randomIndex = random.Next(deck.Count);
                    drawnCards.Add(deck[randomIndex]);
                    deck.RemoveAt(randomIndex);
                }
            }

            // Toon de getrokken kaarten per deelnemer
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

            // Bereken en toon de totale waarde van de kaarten per deelnemer
            for (int i = 0; i < aantalDeelnemers; i++)
            {
                int totalValue = CalculateTotalValue(drawnCardsPerPlayer[i]);
                Console.WriteLine($"Totale waarde van getrokken kaarten voor deelnemer {i + 1}: {totalValue}");
            }
        }


        // Methode om de totale waarde van een lijst met kaarten te berekenen
        private int CalculateTotalValue(List<string> cards)
        {
            // Dictionary om de waarden van de kaarten op te slaan
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

            // Bereken de totale waarde door de waarden van de getrokken kaarten op te tellen
            int totalValue = 0;
            foreach (string card in cards)
            {
                // Split de kaartstring om de waarde te verkrijgen
                string[] parts = card.Split(' ');
                string value = parts[0];

                // Voeg de waarde toe aan de totale waarde
                totalValue += cardValues[value];
            }

            return totalValue;
        }
    }
}
