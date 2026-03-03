using System;

namespace Agent5
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write("Enter a positive integer to count to: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out maxNumber) && maxNumber > 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            }

            Console.WriteLine($"Counting to {maxNumber}:");
            for (int i = 1; i <= maxNumber; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}