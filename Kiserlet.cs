using System;
using System.IO;
namespace Alkimistak
{
    public class Kiserlet
    {
        Elemek[] elemek;
        int elemSzam;
        StreamReader sr;

        public int Elemszam { get{ return elemSzam; } }

        public Elemek[] Elemek { get{ return elemek; } }

        public Kiserlet()
        {
            sr = new StreamReader("ARANY.BE.txt");
            this.ElemszamKiolvas();
            this.TombFeltolt();
            this.sr.Close();
        }


        private void ElemszamKiolvas() //elemek tömb méret megad
        {
            this.elemSzam = int.Parse(this.sr.ReadLine());

            elemek = new Elemek[this.elemSzam];
        }


        private void TombFeltolt() 
        {
            for (int i = 0; i < this.elemSzam; i++)
            {
                string[] str = this.sr.ReadLine().Split(' ');
                elemek[i] = new Elemek(int.Parse(str[0]), char.Parse(str[1]), int.Parse(str[2]));
            }
        }

    }
}
