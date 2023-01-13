using Microsoft.EntityFrameworkCore;
using CoffeeShopLabDTO;
using Microsoft.Extensions.Configuration;
using System.IO;  
namespace CoffeeShopLabRepository
{
    public class ApplicationDBContext :DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        private static IConfigurationRoot _configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                string cnstr = _configuration.GetConnectionString("CoffeeShop");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

    }
}