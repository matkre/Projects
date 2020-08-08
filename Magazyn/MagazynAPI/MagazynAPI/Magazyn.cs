using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynAPI
{
        public partial class Magazyn
        {
            public int ID { get; set; }
            public string Nazwa { get; set; }
            public string Kategoria { get; set; }
            public string Producent { get; set; }
            public int Ilość { get; set; }
            public string Samochód { get; set; }
            public string Silnik { get; set; }
            public decimal Cena { get; set; }
        }
}
