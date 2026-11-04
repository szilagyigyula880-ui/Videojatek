using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videojatek
{
    internal class Jatek
    {
        public string Nev { get; set; }
        public string Tipus { get; set; }
        public string Platform { get; set; }
        public int Kiadas_Ev { get; set; }
        public double Ertekeles { get; set; }

        public Jatek(string sor)
        {
            string[] adatok = sor.Split(';');
            Nev = adatok[0];
            Tipus = adatok[1];
            Platform = adatok[2];
            Kiadas_Ev = int.Parse(adatok[3]);
            Ertekeles = double.Parse(adatok[4]);

        }

    }
}
