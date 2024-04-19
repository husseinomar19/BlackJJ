using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJJ
{
    internal class score
    {
        
        public void Score(int scorepunten)
        {
            Console.WriteLine("Hoeveel punten wil je in zitten?");
            scorepunten = int.Parse(Console.ReadLine());
            Console.WriteLine("Je hebt in gezit : " + scorepunten);
            Console.WriteLine("Spel is gestart de karten worden nu uitgedeeld");
            
        }

        public void ScoreBijhouden(int punten , int deelnemers)

        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Speler nummer " + deelnemers + " hebt " + punten + " gewonen");
            Console.ForegroundColor = originalColor;

        }
    }
}
