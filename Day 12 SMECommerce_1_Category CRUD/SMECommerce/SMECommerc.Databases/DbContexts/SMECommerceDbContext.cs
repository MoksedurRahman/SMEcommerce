using Microsoft.EntityFrameworkCore;
using SMECommerce.Models.EntityModels;

namespace SMECommerce.Databases.DbContexts
{
    public class SMECommerceDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=(local);Database=SMECommerceDB; Integrated Security=true";
            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer(connectionString);

        }
    }
}
