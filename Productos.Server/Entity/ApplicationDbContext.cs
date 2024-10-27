using Microsoft.EntityFrameworkCore;
using Productos.Server.Models;

namespace Productos.Server.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable(nameof(Category));
                e.HasKey(c => c.Id);
                e.HasMany(c => c.Products);
                e.Property(c => c.Name).IsRequired();
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable(nameof(Product));
                e.HasKey(c => c.Id);
                e.Property(c => c.Name).IsRequired().HasMaxLength(128);
                e.Property(c => c.Description);
                e.HasOne(e => e.Category)
                .WithMany(c => c.Products);
            });

            modelBuilder.Entity<Wishlist>(e =>
            {
                e.ToTable(nameof(Wishlist));
                e.HasKey(c => c.Id);
                e.HasMany(c => c.Products);
            });
        }


    }
}
