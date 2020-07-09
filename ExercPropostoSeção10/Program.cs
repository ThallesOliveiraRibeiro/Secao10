using System;
using System.Globalization;
using ExercPropostoSeção10.Entitites;
using System.Collections.Generic;
namespace ExercPropostoSeção10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> listProducts = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data: ");
                Console.Write("Common, used or imported: (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                switch (type)
                {
                    case 'c':
                        listProducts.Add(new Product(name, price));
                        break;
                    case 'u':
                        Console.Write("Manufactured date (DD/MM/YYYY): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        listProducts.Add(new UsedProduct(name, price, date));
                        break;
                    case 'i':
                        Console.Write("Custom fee: ");
                        double customfee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        listProducts.Add(new ImportedProduct(name, price, customfee));

                        break;
                    default:
                        Console.WriteLine("Entrada não válida!");
                        break;

                }


            }
            Console.WriteLine("PRICE TAGS: ");
            foreach (Product prod in listProducts)
                Console.WriteLine(prod.PriceTag());
        }
    }
}
