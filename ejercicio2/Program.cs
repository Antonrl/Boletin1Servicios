using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    internal class Program
    {
        public delegate void MyDelegate();

        public static bool MenuGenerator(String[] opciones, MyDelegate[] funciones)  //Comprobaciones de parámetros. Numeracion de opciones. Indice de salir. La,bdas
        {
            if (opciones == null || funciones == null || opciones.Contains(null) || funciones.Contains(null) || opciones.Length != funciones.Length)
            {
                return false;
            }
            else
            {
                int opcion;
                do
                {
                    Console.WriteLine("Selecciona una opcion: ");
                    for (int i = 0; i < opciones.Length; i++)
                    {
                        Console.WriteLine((i + 1) + " - " + opciones[i]);
                    }
                    Console.WriteLine((opciones.Length + 1) + " - Salir");
                    bool flag = int.TryParse(Console.ReadLine(), out opcion);
                    if (!flag || opcion > opciones.Length + 1 || opcion < 1)
                    {
                        Console.WriteLine("Opcion no valida");
                    }
                    else
                    {
                        if (opciones.Length + 1 != opcion)
                        {
                            funciones[opcion - 1].Invoke();
                        }
                    }
                } while (opciones.Length + 1 != opcion);

                Console.WriteLine("Fin de programa");
                return true;
            }



        }

        static void f1()
        {
            Console.WriteLine("A");
        }
        static void f2()
        {
            Console.WriteLine("B");
        }
        static void f3()
        {
            Console.WriteLine("C");
        }
        static void Main(string[] args)
        {

            //MenuGenerator(null,
            //new MyDelegate[] { f1, f2, f3 });

            //MenuGenerator(new string[] { "Suma", "Res", "Op3", "otro", "Suma", "Res", "Op3", "otro" },
            //new MyDelegate[] { f1, f2, f3, f1, f2, f3, f1, f2 });

            Console.WriteLine(MenuGenerator(new string[] { "Suma", "Res", "Op3", "otro" },
            new MyDelegate[] { () => Console.WriteLine("A"), () => Console.WriteLine("B"), () => Console.WriteLine("C"), () => Console.WriteLine("B") }) ? "Menu creado correctamente" : "Error al crear el menu");

            //Console.WriteLine(MenuGenerator(new string[] { "Suma", "Res", "Op3", "otro" },
            //new MyDelegate[] { f1, f2, f3, f2 }) ? "Menu creado correctamente" : "Error al crear el menu");

            Console.ReadKey();
        }
    }
}
