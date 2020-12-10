﻿using System;
using System.Collections;
using System.Collections.Generic;
using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Data.Seeding.Contracts;

namespace P03_SalesDatabase.Data.Seeding
{
    public class ProductSeeder : ISeeder
    {
        private readonly Random random;
        private readonly SalesContext dbContext;
        public ProductSeeder(SalesContext context, Random random)
        {
            this.dbContext = context;
            this.random = random;
        }
        public void Seed()
        {
            string[] names = new string[]
            {
                "CPU",
                "Motherboard",
                "RAM",
                "SSD",
                "HDD",
                "CD-RW",
                "Water Cooler"
            };

            ICollection<Product> products = new List<Product>();
            for (int i = 0; i < 50; i++)
            {
                int nameIndex = this.random.Next(names.Length);

                string currentProduct = names[nameIndex];

                double quantity = this.random.Next(1000);

                decimal price = this.random.Next(5000) * 1.133m;

                Product product = new Product()
                { 
                    Name = currentProduct,
                Price = price,
                Quantity = quantity
                };

                products.Add(product);
            }

            this.dbContext.Products.AddRange(products);

            this.dbContext.SaveChanges();
        }
    }
}
