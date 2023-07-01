using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZI_2022___JULY
{
    internal class Program
    {
        public class Products
        {
            public Products(string name, int id, int quantity, decimal price)
            {
                this.Name = name;
                this.Id = id;   
                this.Quantity = quantity;   
                this.Price = price;
            }
            public string Name { get; set; }
            public int Id { get; set; }

            public int Quantity { get; set; }
            public decimal Price { get; set; }

            
        }

        public class Grocery : Products
        {
            public Grocery (string name, int id, int quantity, decimal price, DateTime bestbefore)
                :base(name, id, quantity, price)
            {
                this.BestBefore = bestbefore;
            }
            public DateTime BestBefore { get; set; }

            public override string ToString()
            {
                return $"Name: {this.Name} ID: {this.Id} Quantity: {this.Quantity} Price: {this.Price}lv. Screen size: {this.BestBefore}";
            }
        }


        public class Electronics : Products
        {
            public Electronics(string name, int id, int quantity, decimal price, ScreenSize screenSize) 
                : base(name, id, quantity, price)
            {
                this.screenSize = screenSize;
            }

            public ScreenSize screenSize { get; set; }

            public override string ToString()
            {
                return $"Name: {this.Name} ID: {this.Id} Quantity: {this.Quantity} Price: {this.Price}lv Screen size: {this.screenSize}";
            }


        }

        public enum ScreenSize
        {
            Small,
            Medium,
            Large
        }

        static void Main(string[] args)
        {
            //// List<Products> electronics = new List<Products>();
            // List<Products> products = new List<Products>();
            Magazin magazin = new Magazin();
            Electronics electronics = new Electronics("TV", 1, 10, 2200m, ScreenSize.Large);
            Electronics electronics2 = new Electronics("Laptop", 2, 15, 1900m, ScreenSize.Medium);
            Electronics electronics3 = new Electronics("MacBook", 3, 10, 2200m, ScreenSize.Small);
            Electronics electronics4 = new Electronics("Gaming Laptop", 4, 15, 2100m, ScreenSize.Large);

            magazin.AddElectronics(electronics);
            magazin.AddElectronics(electronics2);
            magazin.AddElectronics(electronics3);
            magazin.AddElectronics(electronics4);


            Grocery grocery = new Grocery("Bread", 11, 100, 1.5m, new DateTime(2023, 12, 12));
            Grocery grocery2 = new Grocery("Peanut Butter", 12, 100, 1.5m, new DateTime(2023, 12, 12));
            Grocery grocery3 = new Grocery("Eggs", 13, 500, 0.5m, new DateTime(2023, 12, 12));
            Grocery grocery4 = new Grocery("Yoghurt", 14, 100, 1.7m, new DateTime(2023, 12, 12));

            magazin.AddGrocery(grocery);
            magazin.AddGrocery(grocery2);
            magazin.AddGrocery(grocery3);
            magazin.AddGrocery(grocery4);

            Console.WriteLine("Electronics:");
            foreach (var p in magazin.Electronics)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Groceries");
            foreach (var g in magazin.Groceries)
            {
                Console.WriteLine(g.ToString());
            }

            magazin.SoldProductE(electronics4);
            magazin.SoldProductG(grocery4);

            Console.WriteLine();

            Console.WriteLine("Electronics UPDATED:");
            foreach (var p in magazin.Electronics)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Groceries UPDATED");
            foreach (var g in magazin.Groceries)
            {
                Console.WriteLine(g.ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Electronics (Sorted by Price):");
            List<Products> sortedElectronics = Magazin.SortByPriceThenByName(magazin.Electronics);
            foreach (var p in sortedElectronics)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Groceries (Sorted by Price):");
            List<Products> sortedGroceries = Magazin.SortByPriceThenByName(magazin.Groceries);
            foreach (var g in sortedGroceries)
            {
                Console.WriteLine(g.ToString());
            }





            Console.ReadLine();


        }

        public class Magazin 
        {
            public List <Products> Electronics { get; set; } = new List<Products>();
            public List<Products> Groceries { get; set; } = new List<Products>();

            public void AddElectronics(Electronics electronics)
            {
                Electronics.Add(electronics);
                
            }

            public void AddGrocery (Grocery grocery)
            {
                Groceries.Add(grocery);
                
            }

            public void SoldProductE(Electronics electronics)
            {
                Electronics.Remove(electronics);
                Console.WriteLine("Successfully Removed");
            }

            public void SoldProductG(Grocery grocery)
            {
                Groceries.Remove(grocery);
                Console.WriteLine("Successfully Removed");
            }

            public static List <Products> SortByPriceThenByName(List <Products> products)
            {
                return products.OrderBy(p => p.Price).ThenBy(p => p.Name).ToList();
            }

        }

      
    }
}
