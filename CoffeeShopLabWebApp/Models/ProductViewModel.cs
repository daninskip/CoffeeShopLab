using CoffeeShopLabDTO;
namespace CoffeeShopLabWebApp.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }



        public static ProductViewModel ViewModelMapper(Product productDTO)
        {
            return new ProductViewModel
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Category = productDTO.Category

            };
        }

        public static Product ProductDtoMapperForCreate(IFormCollection collection)
        {
            return new Product
            {
                Name = collection["Name"],
                Description = collection["Description"],
                Price = decimal.Parse(collection["Price"]),
                Category = collection["Category"]

            };
        }
    }
}
