using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using emarket.Models;


namespace emarket.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Cart { get; set; }

    }
}