using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJJ
{
    internal class start
    {
        public int deelnemers;
        public int punten;
        public void Gamestart()
        {
            score score = new score();
            Console.WriteLine("Welkom in Black Jack spel");
            Console.WriteLine("Met hoeveel deelnemers wil je spelen?");
            deelnemers = int.Parse(Console.ReadLine());
            Console.WriteLine("Anntal deelnemers zijn bepaald" + " "+ deelnemers);
            //score.Score();
            Console.WriteLine("Hoeveel punten wil je in zitten?");
            punten = int.Parse(Console.ReadLine());
            Console.WriteLine("Je hebt in gezit : " + punten);
            Console.WriteLine("Spel is gestart de karten worden nu uitgedeeld");
        }
        
        
    }
}
