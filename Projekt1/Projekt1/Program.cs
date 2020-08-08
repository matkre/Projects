using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class Program
    {
        static void Main(string[] args)
        {
            Lotek lotek = new Lotek();
            lotek.LosujLiczby();
            lotek.WprowadzanieLiczb();
            lotek.Wyswietl();
            Console.WriteLine("ilosc trafien: "+lotek.Sprawdzanie());
            Gracz g1 = new Gracz("jan", "kowalski");
            g1.ilosc_trafien = lotek.Sprawdzanie();
            //lotek.Sprawdzanie();
                Console.ReadKey();
        }
    }
}
