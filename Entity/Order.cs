using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {
        public int orderId { get; set; }
        public int productId { get; set; }
        public Product product { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public DateTime orderDate { get; set; }
        public string orderAdress { get; set; }
        public string orderCity { get; set; }
        public decimal freight { get; set; }
        public decimal unitPrice { get; set; }
        public int quantity { get; set; }
    }
}
