using System;
using System.Collections.Generic;

namespace Version2
{
    public sealed class OrderItem
    {
        public readonly string Nm;
        public readonly double Pr;

        public OrderItem(string nm, double pr)
        {
            Nm = nm;
            Pr = pr;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var r = 10;

            var f = F();
            var fb = C(f);

            var d = O();
            var db = C(d);

            var wt = T(fb, r);
            print(wt);

            // Expected £15.40
            // Actual £8.80
        }

        public static List<OrderItem> F()
        {
            return new List<OrderItem>
            {
                new OrderItem("Vegetable Pakora", 3.0),
                new OrderItem("Chicken Tikka Masala", 5.0)
            };
        }

        public static List<OrderItem> O()
        {
            return new List<OrderItem>
            {
                new OrderItem("Coke", 1.5),
                new OrderItem("Beer", 4.5)
            };
        }

        public static double C(List<OrderItem> ol)
        {
            var c = 0.0;
            foreach (var o in ol)
                c = c + o.Pr;
            return c;
        }

        public static double Ad(float c)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                return c*0.9;
            return c;
        }

        public static double T(double t, int r)
        {
            return t * (1.0 + r / 100.0);
        }

        public static void print(double t)
        {
            Console.WriteLine("Total food cost: {0:C}", t);
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
