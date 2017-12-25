using System;
namespace Alkimistak
{
    public class Elemek
    {
        int kiindulasianyag;
        char katalizator;
        int vegtermek;

        public int Kiindulasianyag { get { return kiindulasianyag; } }

        public char Katalizator { get { return katalizator; } }

        public int Vegtermek { get { return vegtermek; } }

        public Elemek(int kiindulasianyag, char katalizator, int vegtermek)
        {
            this.kiindulasianyag = kiindulasianyag;
            this.katalizator = katalizator;
            this.vegtermek = vegtermek;
        }

    }
}
