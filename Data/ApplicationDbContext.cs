using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MiniProject01.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        // ===== THÊM 2 DÒNG NÀY =====
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ===== THÊM SEED DATA =====
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Italian" },
                new Category { Id = 2, Name = "Mexican" },
                new Category { Id = 3, Name = "Chinese" }
            );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Pizza", Description = "Cheese pizza", Price = 9.99, CategoryId = 1 },
                new Product { Id = 2, Name = "Taco", Description = "Beef taco", Price = 4.99, CategoryId = 2 },
                new Product { Id = 3, Name = "Fried Rice", Description = "Egg fried rice", Price = 7.99, CategoryId = 3 }
            );
        }
    }
}