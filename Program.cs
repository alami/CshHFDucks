using System;
using System.Collections.Generic;
using System.Linq;

namespace CshHFDucks
{
    internal class Program
    {
        static void Main(string[] args)
        {
goto next;
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

            Console.WriteLine("\n-- Kovariantnost via IEnumerable<> -- ");
            //Bird.FlyAway(ducks, "Minnesota");
            IEnumerable<Bird> upcastDucks = ducks;
            Bird.FlyAway(upcastDucks.ToList(), "Minnesota");

//next:
            Console.WriteLine("\n-- Dictionary -- ");
            Dictionary<string, Duck> duckIds = new Dictionary<string, Duck>();
            duckIds.Add("first", new Duck() { Kind = KindOfDuck.Mallard, Size = 15 });
            foreach (string key in duckIds.Keys)
            {
                Console.WriteLine($"{key}'s  is {duckIds[key].Kind}/{duckIds[key].Size}");
            }

            Dictionary<string, string> favoriteFoods = new Dictionary<string, string>();
            favoriteFoods["Alex"] = "hot dogs";
            favoriteFoods["A'ja"] = "pizza";
            favoriteFoods["Jules"] = "falafel";
            favoriteFoods["Naima"] = "spaghetti";
            string name;
            while ((name = Console.ReadLine()) != "")
            {
                if (favoriteFoods.ContainsKey(name))
                    Console.WriteLine($"{name}'s favorite food is {favoriteFoods[name]}");
                else
                    Console.WriteLine($"I don't know {name}'s favorite food");
            }
next:
            Console.WriteLine("\n-- Dictionary of NY Yankees baseball liders -- ");
            Dictionary<int, RetiredPlayer> retiredYankees = new Dictionary<int, RetiredPlayer>() {
                {3, new RetiredPlayer("Babe Ruth", 1948)},
                {4, new RetiredPlayer("Lou Gehrig", 1939)},
                {5, new RetiredPlayer("Joe DiMaggio", 1952)},
                {7, new RetiredPlayer("Mickey Mantle", 1969)},
                {8, new RetiredPlayer("Yogi Berra", 1972)},
                {10, new RetiredPlayer("Phil Rizzuto", 1985)},
                {23, new RetiredPlayer("Don Mattingly", 1997)},
                {42, new RetiredPlayer("Jackie Robinson", 1993)},
                {44, new RetiredPlayer("Reggie Jackson", 1993)},
                };
            foreach (int jerseyNumber in retiredYankees.Keys)
            {
                RetiredPlayer player = retiredYankees[jerseyNumber];
                Console.WriteLine($"{player.Name} #{jerseyNumber} retired in {player.YearRetired}");
            }

            Console.WriteLine("Type any key to close!");
            Console.ReadKey();
        }
        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
            {
                Console.WriteLine($"{duck.Size} inch {duck.Kind}");
            }
            
            Console.WriteLine("\n-- IEnumerator<> -- ");
            IEnumerator<Duck> enumerator = ducks.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Duck duck = enumerator.Current;
                Console.WriteLine(duck);
            }
            if (enumerator is IDisposable disposable) disposable.Dispose();

        }
    }
    class Duck : Bird, IComparable<Duck>
    {
        public int Size  {get; set; }
        public KindOfDuck Kind { get; set; }
        public int CompareTo(Duck duckToCompare)  {
            if (this.Size > duckToCompare.Size) return 1;
            else if (this.Size < duckToCompare.Size) return -1;
            else return 0;
        }
        public override string ToString()
        {
            return $"A {Size} inch {Kind}";
        }
    }
    enum KindOfDuck
    {
        Mallard,
        Muscovy,
        Loon,
    }
    class Bird
    {
        public string Name { get; set; }
        public virtual void Fly(string destination)
        {
            Console.WriteLine($"{this} is flying to {destination}");
        }
        public override string ToString()
        {
            return $"A bird named {Name}";
        }
        public static void FlyAway(List<Bird> flock, string destination)
        {
            foreach (Bird bird in flock)
            {
                bird.Fly(destination);
            }
        }
    }

    class RetiredPlayer
    {
        public string Name { get; private set; }
        public int YearRetired { get; private set; }
        public RetiredPlayer(string player, int yearRetired)
        {
            Name = player;
            YearRetired = yearRetired;
        }
    }
}
