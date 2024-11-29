using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ejercicio4
{
    internal class Program
    {
        static int cont = 0;
        static bool fin = false;

        static readonly private object l = new object();


        //public static void suma()
        //{
        //    while (!fin)
        //    {
        //        lock (l)
        //        {
        //            if (!fin)
        //            {
        //                cont++;
        //                Console.WriteLine($"Thread 1, el contador vale: {cont}");
        //                if (cont == 500)
        //                {
        //                    fin = true;
        //                    Monitor.Pulse(l);

        //                }
        //            }
        //        }
        //    }
        //}
        //public static void resta()
        //{
        //    while (!fin)
        //    {
        //        lock (l)
        //        {
        //            if (!fin)
        //            {
        //                cont--;
        //                Console.WriteLine($"Thread 2, el contador vale: {cont}");
        //                if (cont == -500) { 
        //                    fin = true;
        //                    Monitor.Pulse(l);
        //                }
        //            }
        //        }
        //    }
        //}

        static void Main(string[] args)
        {

            Thread Sumar = new Thread(() =>
            {
                while (!fin)
                {
                    lock (l)
                    {
                      if (!fin)
                        {
                            cont++;
                            Console.WriteLine($"Thread 1, el contador vale: {cont}");
                            if (cont == 500)
                            {
                                fin = true;
                                Monitor.Pulse(l);

                            }
                        }
                    }
                }
            });
            Thread Restar = new Thread(() =>
            {
                while (!fin)
                {
                    lock (l)
                    {
                        if (!fin)
                        {
                            cont--;
                            Console.WriteLine($"Thread 2, el contador vale: {cont}");
                            if (cont == -500)
                            {
                                fin = true;
                                Monitor.Pulse(l);
                            }
                        }
                    }
                }
            });
            Sumar.Start();
            Restar.Start();

            lock (l)
            {
                Monitor.Wait(l);
            }
            //Sumar.Join(); Se queda esperando a que el hilo al que esta referenciado termine y luego ejecuta el resto del codigo
            //Restar.Join();

            Console.WriteLine(cont == 500 ? "El hilo incrementador ha ganado" : "El hilo decrementador ha ganado");

            //if (cont == 500)
            //{
            //    Console.WriteLine("El hilo incrementador ha ganado");
            //}
            //else
            //{
            //    Console.WriteLine("El hilo decrementador ha ganado");
            //}

            Console.ReadKey();
        }
    }
}

