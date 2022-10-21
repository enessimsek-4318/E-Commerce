using Entity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccesLayer
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Data Source=DESKTOP-UVMSNSF;Initial Catalog=E-Ticaret;Integrated Security=True")
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
