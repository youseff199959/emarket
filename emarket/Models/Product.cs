using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace emarket.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public int price { get; set; }
        public string image { get; set; }

        public string description { get; set; }
        [ForeignKey("Category")]
        
        public int category_id { get; set; }
        public virtual Category Category { get; set; }
        public virtual Cart Cart { get; set; }
    }
}