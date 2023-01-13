using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CoffeeShopLabDTO;

namespace CoffeeShopLabRepository
{
    public class ProductRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDBContext> _optionsBuilder;


        public ProductRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CoffeeShop"));
        }
        public bool AddProduct(Product productToAdd)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                //determine if item exists
                Product existingProduct = db.Products.FirstOrDefault(x => x.Name.ToLower() == productToAdd.Name.ToLower());

                if (existingProduct == null)
                {
                    // doesn't exist, add it
                    db.Products.Add(productToAdd);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
        public List<Product> GetAllItems()
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Products.ToList();
            }
        }
        public Product GetProductById(int productId)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Products.FirstOrDefault(x => x.Id == productId);
            }
        }

    }
}


