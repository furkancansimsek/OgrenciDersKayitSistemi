using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersKayit
{
    class ogrenci
    {
        public string tc;
        public string okulNo;
        public string adi;
        public string soyadi;
        public string sinif;
        public string sube;
        public string donem;
        public string aldıgıDersler;

        public string ogrenciBirlestir()
        {
            string ogrenciSon = okulNo + "-" + tc + "-" + adi + "-" + soyadi + "-" + sinif + "-" + sube + "-" + donem + "-" + aldıgıDersler;
            return ogrenciSon;
        }
    }
}
