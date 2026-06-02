using System;
using System.Collections.Generic;

namespace Version1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tipRate = 10;

            var foodOrder = GetFoodOrder();
            var foodBill = CalculateTotalCost(foodOrder);

            var drinksOrder = GetDrinksOrder();
            var drinksBill = CalculateTotalCost(drinksOrder);

            var foodBillWithTip = CalculateBillWithTip(foodBill, tipRate);
            PrintBill(foodBillWithTip);

            // Expected £15.40
            // Actual £8.80
        }

        public static List<OrderItem> GetFoodOrder()
        {
            return new List<OrderItem>
            {
                new OrderItem("Vegetable Pakora", 3.0),
                new OrderItem("Chicken Tikka Masala", 5.0)
            };
        }
        
        public static List<OrderItem> GetDrinksOrder()
        {
            return new List<OrderItem>
            {
                new OrderItem("Coke", 1.5),
                new OrderItem("Beer", 4.5)
            };
        }

        public static double CalculateTotalCost(List<OrderItem> orderItemList)
        {
            var cost = 0.0;
            foreach (var orderItem in orderItemList)
                cost = cost + orderItem.Price;
            return cost;
        }

        public static double CalculateBillWithTip(double totalBill, int tipRate)
        {
            return totalBill * (1.0 + tipRate / 100.0);
        }

        public static void PrintBill(double totalBill)
        {
            Console.WriteLine("Total food cost: {0:C}", totalBill);
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
    
    public sealed class OrderItem
    {
        public readonly string Name;
        public readonly double Price;

        public OrderItem(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}