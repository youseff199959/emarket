using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using emarket.Models;

namespace emarket.ViewModels
{
    public class ProductCategoryModel
    {
        public IEnumerable<Category> category { get; set; }
        public Product product { get; set; }
    }
}