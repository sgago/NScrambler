using System;

namespace NScramble
{
    /// <summary>
    /// Demonstrates use of the Scramble1, Scramble2, and Scramble3
    /// string-extension methods.
    /// </summary>
    public class ScramblerDemo
    {
        public static void Main(string[] args)
        {
            // Scramble "Steven Gago" using our 3 different shuffling algorithms
            string results1 = "Steven Gago".Scramble1();
            string results2 = "Steven Gago".Scramble2();
            string results3 = "Steven Gago".Scramble3();

            // Display the results
            Console.WriteLine("This program demonstrates use of the three different " + 
                "Scramble methods.");

            Console.WriteLine($"Steven Gago => Scramble1 Method => {results1}");
            Console.WriteLine($"Steven Gago => Scramble2 Method => {results2}");
            Console.WriteLine($"Steven Gago => Scramble3 Method => {results3}");

            Console.WriteLine();

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}
