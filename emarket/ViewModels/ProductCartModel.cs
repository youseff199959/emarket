using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using emarket.Models;

namespace emarket.ViewModels
{
    public class ProductCartModel
    {
        public IEnumerable<Cart> Cart { get; set; }
        public IEnumerable<Product> Product { get; set; }
    }
}