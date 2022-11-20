using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DefectList
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders => Set<Order>();
        public OrdersContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=OrderForBuyer.db");
        }
    }
}
