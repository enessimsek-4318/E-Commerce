using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public int productId { get; set; }
        public int categoryId { get; set; }
        public Category Category { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productBrand { get; set; }
        public decimal price { get; set; }
        public int stockNumber { get; set; }
        public string productPhoto { get; set; }
    }
}
