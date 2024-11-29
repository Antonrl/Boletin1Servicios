using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio5
{
    internal class Caballo
    {

        public int Posicion { set; get; }

        
        public Caballo()
        {
            this.Posicion = 0;
        }

        public static void correr(Caballo c)
        {
            Random generador = new Random();
            c.Posicion += 1;// generador.Next(5);
        }
    }
}
