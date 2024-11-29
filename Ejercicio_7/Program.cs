using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    internal class Program
    {
        public static readonly object l=new object();
        static void Main(string[] args)
        {
            Random rnd = new Random();
            bool pausa=false;
            bool fin = false;
            int cont = 0;
            
            Thread player1 = new Thread(() =>
            {
                int n=0;
                while (!fin)
                {
                    lock (l)
                    {
                        if (!fin)
                        {
                            n = rnd.Next(1, 11);
                            Console.SetCursorPosition(5,5);

                            Console.WriteLine($"{n,3}");
                            if (n == 5 || n == 7)
                            {
                                pausa = true;
                                cont += 5;
                            }
                            else
                            {
                                cont++;
                            }
                            Console.SetCursorPosition(50, 0);
                            Console.WriteLine($"{cont,4}");
                            if ( cont >=20)
                            {
                                fin = true;
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine("Ha ganado el jugador 1");
                            }
                        }
                    }
                    Thread.Sleep(rnd.Next(100,100*n+1));
                }
            });

            Thread player2 = new Thread(() =>
            {
                int n = 0;
                while (!fin)
                {
                    lock (l)
                    {
                        if (!fin)
                        {
                            n = rnd.Next(1, 11);
                            Console.SetCursorPosition(11,5);

                            Console.WriteLine($"{n,3}");
                            if (n == 5 || n == 7)
                            {
                                cont -= 5;
                                Monitor.Pulse(l);
                                pausa = false;
                            }
                            else {
                                cont--;
                            }
                            Console.SetCursorPosition(50, 0);
                            Console.WriteLine($"{cont,4}");
                            if (cont <= -20 )
                            {
                                fin = true;
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine("Ha ganado el jugador 2");
                            }
                        }
                    }
                    Thread.Sleep(rnd.Next(100, 100 * n + 1));
                }
            });

            Thread display = new Thread(() => {
                string cad = "|/-\\";
                int contCad = 0;
                while (!fin)
                {
                    lock (l)
                    {
                        if (!fin)
                        {
                            if (pausa)
                            {
                                Monitor.Wait(l);
                            }
                            Console.SetCursorPosition(10,5);
                            Console.WriteLine(cad[contCad]);
                            contCad++;
                            if (contCad >=cad.Length) {
                                contCad = 0;
                              }
                        }
                    }
                    Thread.Sleep(200);
                }
            });
            player1.Start();
            player2.Start();
            display.Start();
            display.Join();
            Console.ReadKey();
        }
    }
}
