using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class Lotek
    {
        int[] cyfryLotka = new int[6];
        int[] cyfryMoje = new int[6];
       /* public Lotek()
        {
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                cyfryLotka[i] = 0;
            }
        }*/
        public void LosujLiczby()
        {
            int x;
            Random rnd = new Random();
            for(int i=0; i<6;i++)
            {
                x = rnd.Next(1, 50);
                for (int j=0; j<6; j++)
                {
                    if(x==cyfryLotka[j])
                    {
                        i--;
                        break;
                    }
                    if(cyfryLotka[j]==0)
                    {
                        cyfryLotka[j] = x;
                        break;
                    }
                }
            }
            //Console.WriteLine("Losowanie Liczb");
        }
        public void WprowadzanieLiczb()
        {
            int x = 0;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Podaj liczbę: ");
                x = int.Parse(Console.ReadLine());
                cyfryMoje[i] = x;
            }
            
        }
        public int Sprawdzanie()
        {
            int x;
            int licznik = 0;
            for (int i=0; i<6; i++)
            {
                x = cyfryMoje[i];
                for(int j=0; j<6;j++)
                {
                    if (x==cyfryLotka[j])
                    {
                        licznik++;
                    }
                }
            }
            
            Console.WriteLine("Ilość trafień: " + licznik);
            return licznik;
        }
        public void Wyswietl()
        {
            for(int i=0; i<6;i++)
            {
                Console.Write(cyfryLotka[i] + ",");
            }
            Console.WriteLine("");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(cyfryMoje[i] + ",");
            }
        }
    }
}
