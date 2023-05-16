using HW7_8.Models;
using Microsoft.EntityFrameworkCore;

namespace HW7_8.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Expenses> expenses { get; set; }
        public DbSet<Category> categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Transport" },
                new Category { Id = 3, Name = "Mobile connection" },
                new Category { Id = 4, Name = "Internet" },
                new Category { Id = 5, Name = "Entertainment" }
            );
        }
    }
}
