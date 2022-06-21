using System;
using System.Collections.Generic;

namespace CshHFDucks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>() {
                new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 14 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 13 },
                };
            ducks.Sort();
            PrintDucks(ducks);
            Console.WriteLine("Type any key to close!");
            Console.ReadKey();
        }
        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
            {
                Console.WriteLine($"{duck.Size} inch {duck.Kind}");
            }
        }
    }
    class Duck : IComparable<Duck>
    {
        public int Size  {get; set; }
        public KindOfDuck Kind { get; set; }
        public int CompareTo(Duck duckToCompare)  {
            if (this.Size > duckToCompare.Size) return 1;
            else if (this.Size < duckToCompare.Size) return -1;
            else return 0;
        }
    }
    enum KindOfDuck
    {
        Mallard,
        Muscovy,
        Loon,
    }
}
