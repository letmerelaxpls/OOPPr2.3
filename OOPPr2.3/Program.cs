using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string productData)
    {
        string[] data = productData.Split(';');
        Name = data[0];
        Price = decimal.Parse(data[1]);
    }
}


class Program
{
    static void Main(string[] args)
    {

        List<string> productsList = File.ReadAllLines("products.txt").ToList();


        List<Product> products = productsList.Select(p => new Product(p)).ToList();


        var groupedProducts = products.GroupBy(p => p.Price);

        Console.WriteLine("Result of grouping by price: \n");


        foreach (var group in groupedProducts)
        {
            Console.WriteLine($"Товари, що коштують {group.Key}:");

            foreach (var product in group)
            {
                Console.WriteLine($"\t{product.Name}");
            }

            Console.WriteLine();
        }
    }
}


