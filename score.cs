using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJJ
{
    internal class score
    {
        public int punten;
        public void Score()
        {
            Console.WriteLine("Hoeveel punten wil je in zitten?");
            punten = int.Parse(Console.ReadLine());
            Console.WriteLine("Je hebt in gezit : " + punten);
            Console.WriteLine("Spel is gestart de karten worden nu uitgedeeld");
            
        }

        public void ScoreBijhouden(int punten , int deelnemers)

        {
            Console.WriteLine("Speler nummer " + deelnemers + " hebt " + punten + " gewonen");

        }
    }
}
