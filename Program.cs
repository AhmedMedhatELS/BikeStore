using BikeStore.Data;
using BikeStore.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BikeStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext Context = new ApplicationDbContext();

            //Retrieve all categories from the production.categories table.

            Console.WriteLine("All categories:");
            var categ = Context.Categories;
            foreach (var category in categ)
            {
                Console.WriteLine(category.CategoryId + " " +category.CategoryName);
            }

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");

            //Retrieve the first product from the production.products table.

            Console.WriteLine($@"first product is {Context.Products.FirstOrDefault()?.ProductName}");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");

            //Retrieve a specific product from the production.products table by ID.

            Console.WriteLine($"Product ID 5 Name " +
                $"{Context.Products.Select(e => new { e.ProductName,e.ProductId}).
                Where(e => e.ProductId == 5).
                FirstOrDefault()?.
                ProductName}");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");

            //Retrieve all products from the production.products table with a certain model year.

            var prod = Context.Products.Select(e => new { e.ProductName, e.ModelYear }).
                Where(e => e.ModelYear == 2018);
            Console.WriteLine($@"Products of the Model Year 2018 :");
            foreach(var product in prod)
                Console.WriteLine(product.ProductName);

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");

            //Retrieve a specific customer from the sales.customers table by ID.

            Console.WriteLine($"Customer ID 16 Name {
                Context.Customers.Select(e => new {e.FirstName, e.LastName, e.CustomerId}).
                Where(e => e.CustomerId == 16).First().FirstName}");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");

            //Retrieve a list of product names and their corresponding brand names.

            var prod_brand = Context.Products.Include(product => product.Brand).Select(product => new { product.Brand.BrandName, product.ProductName });
            Console.WriteLine("List of Products and Their Brand name : \n\n");
            foreach(var pb in prod_brand) Console.WriteLine(pb.ProductName + " Brand " + pb.BrandName);

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");

            //Count the number of products in a specific category.

            Console.WriteLine($"Number of Products in Category 6 equal " +
                $"{Context.Products.Count(c => c.CategoryId == 6)}");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");

            //Calculate the total list price of all products in a specific category.

            Console.WriteLine($"Tthe Sum of Products in Category 6 equal " +
                $"{Context.Products.Where(e => e.CategoryId == 6).Sum(e => e.ListPrice):c}");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");

            //Calculate the average list price of products.

            Console.WriteLine($"Tthe Avg of Products equal " +
                $"{Context.Products.Average(e => e.ListPrice):c}");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");

            //Retrieve orders that are completed.
            //Assume completed orders is 4

            var comp_orders = Context.Orders.Select(e => new {e.OrderId,e.OrderStatus})
                .Where(e => e.OrderStatus == 4);
            Console.WriteLine("The List of Completed orders :\n\n");
            foreach (var comp_order in comp_orders) Console.WriteLine("Oreder ID : " + comp_order.OrderId);

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\n\n");
        }
    }
}
