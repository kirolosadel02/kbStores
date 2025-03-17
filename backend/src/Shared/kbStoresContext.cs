using Microsoft.EntityFrameworkCore;
//using src.Modules.Users.Models;
//using src.Modules.Products.Models;
//using src.Modules.Orders.Models;

namespace src.Shared
{
    public class kbStoresContext : DbContext
    {
        public kbStoresContext(DbContextOptions<kbStoresContext> options) : base(options) { }

        // Define DbSet properties for each module
        //public DbSet<User> Users { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints here
            base.OnModelCreating(modelBuilder);
        }
    }
}