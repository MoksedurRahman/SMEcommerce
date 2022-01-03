using Microsoft.EntityFrameworkCore;
using SMECommerce.Models.EntityModels;

namespace SMECommerce.Databases.DbContexts
{
    public class SMECommerceDbContext : DbContext
    {
        public SMECommerceDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = @"Server=(local);Database=SMECommerceDB; Integrated Security=true";
            //optionsBuilder
            //    //.UseLazyLoadingProxies()
            //    .UseSqlServer(connectionString);

        }
    }
}
