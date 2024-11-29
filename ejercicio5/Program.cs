using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ejercicio5
{
    internal class Program
    {
        static readonly private object l = new object();
        static bool fin;
        static Caballo[] caballos = new Caballo[5];
        static int ganador;
        Random generador = new Random();

        public static void hilo(object n)
        {
            int aux = (int)n;
            
            Caballo c = new Caballo();
            caballos[aux] = c;
            int aleat;

            lock (l)
            {
                Console.SetCursorPosition(0, aux);
                Console.Write("Caballo " + (aux + 1) + ": ");
                Console.SetCursorPosition(65, aux);
                Console.Write("|");


            }
            while (!fin)
            {
                aleat = 50;// generador.Next(50,150);
                Thread.Sleep(aleat);
                lock (l)
                {
                    if (!fin)
                    {
                        Caballo.correr(c);
                       // c.Posicion += 1;//
                        Console.SetCursorPosition(c.Posicion + 15, aux);

                        Console.Write("*");

                        if (c.Posicion >= 50)
                        {
                            fin = true;
                            ganador = aux + 1;
                            Console.Write("He ganado");
                            Monitor.Pulse(l);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {           
            int result,acierto;
            do
            {   
                result = 0;
                acierto = 0;
                do
                {
                    Console.WriteLine("Que caballo crees que va a ganar, el 1, 2, 3, 4 o 5?: ");
                    bool flag = int.TryParse(Console.ReadLine(), out acierto);
                    if (!flag|| acierto < 1 || acierto > 5)
                    {
                        Console.WriteLine("Respuesta no valida");
                    }                    
                }
                while (acierto < 1|| acierto > 5);
                Console.Clear();
                Console.SetCursorPosition(64, 5);
                Console.Write("META");
                Console.SetCursorPosition(0, 0);
                Thread[] hilos = new Thread[5];
                for (int i = 0; i < hilos.Length; i++)
                {
                    hilos[i] = new Thread(hilo);
                    hilos[i].Start(i);
                }
                lock (l)
                {
                    Monitor.Wait(l);
                }
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("Ha ganado el caballo numero " + ganador);
                Console.WriteLine(acierto == ganador?"Has acertado":"Has fallado");
                result=0;
                do
                {
                    Console.WriteLine("Pulsa 1 para volver a jugar, 2 para salir: ");
                    bool flag = int.TryParse(Console.ReadLine(), out result);
                    if (!flag || result < 1 || result > 2)
                    {
                        Console.WriteLine("Respuesta no valida");
                    }
                   
                }
                while (result!=1 && result !=2);
                Console.Clear();
                fin = false;
            }
            while (result != 2);

        }
    }
}
