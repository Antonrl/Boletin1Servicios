using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boletin_4_1
{
    internal class Program
    {
        //public static void view(int grade)
        //{
        //    Console.ForegroundColor = grade >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
        //    Console.WriteLine($"Student grade: {grade,3}.");
        //    Console.ResetColor();
        //}
        //public static bool pass(int num)
        //{
        //    return num >= 5;
        //}
        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
            int[] v2 = { 2, 2,  1, 3 };

            //Array.ForEach(v, view);
            //int res = Array.FindIndex(v, pass);
            
            Array.ForEach(v, grade =>
            {
                Console.ForegroundColor = grade >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Student grade: {grade,3}.");
                Console.ResetColor();
            });
            int res = Array.FindIndex(v, num => num >= 5);
            Console.WriteLine($"The first passing student is number {res + 1} in the list.");

            bool res2 = Array.Exists(v, num => num >= 5);
            Console.WriteLine("Hay algun aprobado? : "+res2);

            res=Array.FindLastIndex(v, num => num >= 5);
            Console.WriteLine($"The last passing student is number {res + 1} in the list.");


            Array.ForEach(v, grade =>
            {
                Console.WriteLine($"Inverso: {1.0/grade:0.00}.");               
            });
            Console.ReadKey();
        }
    }
}
