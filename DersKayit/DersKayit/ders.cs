using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersKayit
{
    class ders
    {
        public string dersKodu;
        public string dersAdi;
        public int dersAkts;
        public string yazdir;
        public string dersAdiBirlestir()
        {
            yazdir = dersKodu + " ∽ " + dersAdi + " ∽ AKTS " + dersAkts;
            return yazdir;
        }
    }
}
