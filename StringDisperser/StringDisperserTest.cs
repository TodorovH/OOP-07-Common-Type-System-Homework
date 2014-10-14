using System;

namespace StringDisperser
{
    class StringDisperserTest
    {
        static void Main(string[] args)
        {
            var stringDispersers = new StringDisperser[]
            {
                new StringDisperser("pesho", "gosho", "maria", "silvia"),
                new StringDisperser("sharo", "mecho"),
                new StringDisperser("sofia", "varna", "bourgas"),
            };

            Array.Sort(stringDispersers);

            foreach (var stringDisperser in stringDispersers)
            {
                Console.WriteLine(stringDisperser);
            }

            Console.WriteLine();

            Console.WriteLine(stringDispersers[0].Equals(stringDispersers[1]));
            Console.WriteLine(stringDispersers[0].Equals(stringDispersers[0]));
            Console.WriteLine();

            foreach (var stringDisperser in stringDispersers)
            {
                foreach (var ch in stringDisperser)
                {
                    Console.Write(ch + " ");
                }

                Console.WriteLine();
            }          
        }
    }
}
