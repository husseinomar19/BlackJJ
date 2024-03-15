using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJJ
{
    internal class score
    {
        public void Score()
        {
            Console.WriteLine("Hoeveel punten wil je in zitten?");
            int score = int.Parse(Console.ReadLine());
            Console.WriteLine("Je hebt : " + score);
            Console.WriteLine("Spel is gestart de karten worden nu uitgedeeld");
            
        }
    }
}
