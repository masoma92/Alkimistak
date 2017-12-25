using System;
using System.IO;
namespace Alkimistak
{
    public class Vizsgalat
    {
        Kiserlet beVizs = new Kiserlet();

        string osszesEredmeny = "";
        string vegEredmeny = "";
        StreamWriter sw = new StreamWriter("ARANY.KI.txt");


        public Vizsgalat()
        {
            Console.WriteLine("Van-e arany alapból: " + this.VaneAranyKiindulo());
            Console.WriteLine("Van-e arany a vegtermekek között: " + this.VaneAranyVegtermek());
            Console.WriteLine("Van-e vas alapból: " + this.VanEVasAlapbol());


            osszesEredmeny = this.BejarasiUtvonalak(1, 0, "");
            vegEredmeny = EredmenyKiad();

            Console.WriteLine("\nBejárási útvonalak: " + osszesEredmeny.Replace('_', ' '));

            if (VaneAranyKiindulo())
            {
                Console.WriteLine("\nEgyik sem kell!");
                this.sw.WriteLine("Egyik sem kell!");
            }
            else if (!VaneAranyVegtermek())
            {
                Console.WriteLine("\nNem lehet!");
                this.sw.WriteLine("Nem lehet!");
            }

            else if (vegEredmeny.Length>0)
            {
                Console.WriteLine("\nNélkülözhetetlen katalizátorok: {0}", vegEredmeny);
                this.sw.WriteLine(vegEredmeny);
            }
            else
            {
                Console.WriteLine("\nNem lehet!");
                this.sw.WriteLine("Nem lehet!");
            }
            sw.Close();
        }

        private string BejarasiUtvonalak(int kezdoElem, int arany, string utvonal)
        {
            for (int i = 0; i < this.beVizs.Elemszam; i++)
            {
                if (this.beVizs.Elemek[i].Kiindulasianyag == kezdoElem)
                {
                    string katHozzaAd = this.beVizs.Elemek[i].Katalizator + " ";
                    if (this.beVizs.Elemek[i].Vegtermek != arany)
                    {
                        this.BejarasiUtvonalak(this.beVizs.Elemek[i].Vegtermek, arany, (utvonal + katHozzaAd));
                    }
                    else
                    {
                        string eredmeny = utvonal + katHozzaAd;
                        this.osszesEredmeny += this.EredmenyIsmetlodesNelkul(eredmeny) + "_";
                    }
                }
            }
            return osszesEredmeny;
        }

        private bool VaneAranyKiindulo()
        {
            bool x = false;
            for (int i = 0; i < this.beVizs.Elemszam; i++)
            {
                if (this.beVizs.Elemek[i].Kiindulasianyag == 0)
                {
                    x = true;
                }

            }
            return x;
        }

        private bool VaneAranyVegtermek()
        {
            int i = 0;
            while (this.beVizs.Elemek[i].Vegtermek==0 && i<this.beVizs.Elemek.Length)
            {
                i++;
            }
            return i < this.beVizs.Elemek.Length;

        }

        private bool VanEVasAlapbol()
        {
            int i = 0;
            while (this.beVizs.Elemek[i].Kiindulasianyag == 1 && i < this.beVizs.Elemek.Length)
            {
                i++;
            }
            return i < this.beVizs.Elemek.Length;
        }

        private string EredmenyIsmetlodesNelkul(string bemenet)
              
        {

            string[] seged = bemenet.Split(' ');
            string kimenet = seged[0] + " ";

            int db = 0;
            for (int i = 1; i < seged.Length; i++)
            {
                int j = 0;
                while (j <= db && seged[i] != seged[j])
                {
                    j++;
                }
                if (j > db)
                {
                    db++;
                    kimenet += seged[i] + " ";
                }

            }

            return kimenet;

        }  //BejarasiUtvonalakHivjaMeg

        private string Metszet(string a, string b) 
        {
            string c = "";
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < b.Length - 1; j++)
                {
                    if (a[i]==(b[j]) && a[i] != ' ')
                    {
                        c += a[i] + " ";
                    }
                }
            }
            if (c.Length<1)
            {
                return a + ", " + b + ", ";
            }
            else
            {
                return c;
            }
            


        }  //eredmenykiadhoz

        private string EredmenyKiad()
        {
            string[] seged = osszesEredmeny.Split('_');
            string osszeHas = seged[0];
            for (int i = 1; i < seged.Length-1; i++)
            {
                osszeHas = this.Metszet(osszeHas, seged[i]);
            }
            return osszeHas;

        }


    }
}
