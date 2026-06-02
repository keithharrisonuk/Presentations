using System;
using System.Collections.Generic;
using System.Linq;

namespace Version3
{
    public sealed class Item
    {
        public readonly string Name;
        public readonly double Tag;

        public Item(string name, double tag)
        {
            Name = name;
            Tag = tag;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var c = new Item("Coke", 1.5);
            var ctm = new Item("Chicken Tikka Masala", 5.0);

            var b = new Item("Beer", 4.5);
            var x = 0.0;

            var r = 10;
            var vp = new Item("Vegetable Pakora", 3.0);
            var main = new List<Item> {vp, ctm};
            foreach (var i in main)
            {
                var r1 = i.Tag + x;
                x = r1;
            }

            if (D()() == 0)
                x = x*0.9;
            else
                x = x;

            var m = x;
            var other = new List<Item> {c, b};
            var seq1 = Enumerable.Range(1, other.ToArray().Length).Select(i => i);// Add linq statment
            foreach (var i in seq1)
            {
                if (i - 1 == 0)
                {
                    x = 0.0;
                    x = x + other.ToArray()[i - 1].Tag;
                }
            }

            foreach (var i in seq1)
            {
                if (i - 1 == 0)
                    x = 0.0;
                x = x + other.ToArray()[i - 1].Tag;
            }
            var o = x;

            if (D()() == 0)
                o = o*0.9;
            else
                o = o;
            x = o;

            var total = m *(1.0 + ((float) r/100.0));
            Out(total);

            // Expected £15.40
            // Actual £8.80
        }

        private static void Out(double totalBill)
        {
            Console.WriteLine("Total food cost: {0:C}", totalBill);
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        private static Func<int> D()
        {
            return () => (int) DateTime.Now.DayOfWeek;
        }
    }
}
