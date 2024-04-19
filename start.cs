    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace BlackJJ
    {
        internal class start
        {
        private int _deelnemers;
        private int _punten;

        public int Deelnemers
        {
            get { return _deelnemers; }
            set { _deelnemers = value; }
        }

        public int Punten
        {
            get { return _punten; }
            set { _punten = value; }
        }
        public void Gamestart()
            {
            
                Console.WriteLine("Welkom in Black Jack spel");
                Console.WriteLine("Met hoeveel deelnemers wil je spelen?");
                Deelnemers = int.Parse(Console.ReadLine());
                Console.WriteLine("Anntal deelnemers zijn bepaald" + " "+ Deelnemers);
                Console.WriteLine("Hoeveel punten wil je in zitten?");
                Punten = int.Parse(Console.ReadLine());
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Je hebt in punten " + Punten + " gezit.");
                Console.ForegroundColor = originalColor;
                Console.WriteLine("Spel is gestart de karten worden nu uitgedeeld");
            }
        
        
        }
    }
