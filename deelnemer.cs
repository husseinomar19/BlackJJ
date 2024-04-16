using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BlackJJ
{
    internal class deelnemer
    {
       
        public int winnendeTotaleWaarde = 0;
        public int winnaarIndex = -1;
        public bool gelijkspel = false;
        public int aantalDeelnemers;
        public int scorepunten;
        
        public void DetermineWinner(Card card, start start, score score)
        {
            
            aantalDeelnemers = card.drawnCardsPerPlayer.Count;
            winnendeTotaleWaarde = 0;
            winnaarIndex = -1;
            gelijkspel = false;

            for (int i = 0; i < aantalDeelnemers; i++)
            {
                int totaleWaarde = card.CalculateTotalValue(card.drawnCardsPerPlayer[i]);

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

            // scorepunten = start.punten;
            // Console.WriteLine(scorepunten);

            scorepunten = card.ScoreDeelnemerpunten;


            score.ScoreBijhouden(scorepunten, winnaarIndex + 1);
        }
    }
}

