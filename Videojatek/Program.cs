
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Videojatek
{
    internal class Program
    {
        static void Main()
        {
            List<Jatek> jatekok = File.ReadAllLines("jatekok.csv")
                .Skip(1)
                .Select(sor => new Jatek(sor))
                .ToList();

            // 1. 
            var f1 = jatekok.Where(x => x.Ertekeles >= 9);

            foreach (var x in f1)
                Console.WriteLine(x.Nev);

            // 2. 
            var f2 = jatekok.Where(x =>
                x.Platform == "Nintendo Switch" &&
                x.Kiadas_Ev > 2015 &&
                x.Ertekeles >= 8);

            foreach (var x in f2)
                Console.WriteLine(x.Nev);

            // 3. 
            var f3 = jatekok.OrderByDescending(x => x.Kiadas_Ev);

            foreach (var x in f3)
                Console.WriteLine(x.Nev + " - " + x.Kiadas_Ev);

            // 4. 
            var f4 = jatekok
                .OrderByDescending(x => x.Ertekeles)
                .Take(10)
                .Select(x => new { x.Nev, x.Ertekeles });

            foreach (var x in f4)
                Console.WriteLine(x.Nev + " - " + x.Ertekeles);

            // 5. 
            var f5 = jatekok
                .GroupBy(x => x.Platform)
                .Select(x => new
                {
                    Platform = x.Key,
                    Count = x.Count()
                });

            foreach (var x in f5)
                Console.WriteLine(x.Platform + " - " + x.Count);

            // 6. 
            var f6 = jatekok
                .GroupBy(x => x.Tipus)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .FirstOrDefault();

            Console.WriteLine(f6);

            // 7. 
            var f7 = jatekok.Average(x => x.Ertekeles);

            Console.WriteLine(f7);

            // 8.
            var f8 = jatekok
                .GroupBy(x => x.Platform)
                .OrderByDescending(x => x.Average(y => y.Ertekeles))
                .Select(x => x.Key)
                .FirstOrDefault();

            Console.WriteLine(f8);

            // 9.
            var maxErtekeles = jatekok.Max(x => x.Ertekeles);
            var minErtekeles = jatekok.Min(x => x.Ertekeles);

            Console.WriteLine("Maximum: " + maxErtekeles);
            Console.WriteLine("Minimum: " + minErtekeles);

            // 10. 
            var f10 = jatekok
                .Select(x => x.Tipus)
                .Distinct();

            foreach (var x in f10)
                Console.WriteLine(x);

            // 11. 
            var f11 = jatekok.Select(x => new
            {
                x.Nev,
                x.Kiadas_Ev
            });

            foreach (var x in f11)
                Console.WriteLine(x.Nev + " - " + x.Kiadas_Ev);

            // 12. 
            var f12 = jatekok
                .Where(x => x.Tipus == "Action")
                .OrderByDescending(x => x.Ertekeles)
                .Select(x => new
                {
                    x.Nev,
                    x.Kiadas_Ev,
                    x.Ertekeles
                });

            foreach (var x in f12)
                Console.WriteLine(x.Nev + " - " + x.Kiadas_Ev + " - " + x.Ertekeles);

            // 14. 
            var f14 = from x in jatekok
                      where x.Kiadas_Ev < 2005
                      select new { x.Nev, x.Platform };

            foreach (var x in f14)
                Console.WriteLine(x.Nev + " - " + x.Platform);

            // 15. 
            var f15 = jatekok
                .GroupBy(x => x.Platform)
                .Select(x => x.OrderByDescending(y => y.Ertekeles).First());

            foreach (var x in f15)
                Console.WriteLine(x.Platform + " - " + x.Nev + " - " + x.Ertekeles);

            Console.ReadKey();
        }
    }
}
