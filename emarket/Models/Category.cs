using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emarket.Models
{
    public class Category
    {
       [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int number_of_products { get; set; }
    }
}