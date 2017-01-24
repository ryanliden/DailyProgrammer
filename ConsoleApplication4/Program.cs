using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RyansLibrary;
using RyansLibrary.GameUtils;

namespace TestBed
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = "y";
            
            while (response != "n")
            {
                Console.Write("Enter the letters: ");

                Scrabble scrabble = new Scrabble(Console.ReadLine());



                Console.WriteLine("The longest word is: {0}", scrabble.LongestWord());


                Console.Write("Try again? ");
                response = Console.ReadLine();

                Console.WriteLine();
            }

            //Console.ReadKey();
        }
    }
}
