using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMVVM.Model;

namespace WpfAppMVVM.EF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=ConfigurationModel") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
