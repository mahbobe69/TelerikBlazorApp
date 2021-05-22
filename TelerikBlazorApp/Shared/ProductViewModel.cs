using System;
using System.Collections.Generic;
using System.Text;

namespace TelerikBlazorApp.Shared
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public int BuyCount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public static List<Product> Getproducts()
        {
        return new List<Product>() {
        new Product(name:"گوشی سامسونگ A 31",price:6000000,category:"سامسونگ"),
        new Product(name: "گوشی سامسونگ A 51", price: 8000000, category: "سامسونگ"),
        new Product(name: "گوشی سامسونگ A 71", price: 10000000, category: "سامسونگ"),
        new Product(name: "گوشی سامسونگ S 21", price: 6000000, category: "سامسونگ"),
        new Product(name: "گوشی اپل 12", price: 360000000, category: "آیفون"),
        new Product(name: "گوشی اپل 11", price: 2400000, category: "آیفون"),
        new Product(name: "شیاوومی note 9", price: 600000, category: "شیاوومی"),
        new Product(name: "شیاوومی redmi", price: 400000, category: "شیاوومی")
        };
        }
    }
    public class Product
    {
        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

}
