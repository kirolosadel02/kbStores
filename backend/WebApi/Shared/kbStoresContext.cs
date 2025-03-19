using Microsoft.EntityFrameworkCore;

namespace WebApi.Shared
{
    public class kbStoresContext : DbContext
    {
        public kbStoresContext(DbContextOptions<kbStoresContext> options)
            : base(options)
        {
        }

        // Add your DbSet properties here
        // Example:
        // public DbSet<Store> Stores { get; set; }
        // public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships and constraints here
            // Example:
            // modelBuilder.Entity<Store>().HasKey(s => s.Id);
            // modelBuilder.Entity<Product>().HasOne(p => p.Store).WithMany(s => s.Products);
        }
    }
}