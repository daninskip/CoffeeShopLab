using CoffeeShopLabRepository;
using CoffeeShopLabDTO;

namespace CoffeeShopLabDomain
{
    public class ProductInteractor
    {
        private ProductRepository _repository;

        public ProductInteractor()
        {
            _repository = new ProductRepository();
        }
        public bool AddNewProduct(Product productToAdd)
        {
            if (string.IsNullOrEmpty(productToAdd.Name) || string.IsNullOrEmpty(productToAdd.Description))
            {
                throw new ArgumentException("Name and Description must contain valid text.");
            }
            return _repository.AddProduct(productToAdd);
        }
        public List<Product> GetAllItems()
        {
            return _repository.GetAllItems();
        }
        public bool GetProductIfExists(int productId, out Product productToReturn)
        {
            Product product = _repository.GetProductById(productId);
            productToReturn = product;
            return productToReturn != null;
        }
    }
}