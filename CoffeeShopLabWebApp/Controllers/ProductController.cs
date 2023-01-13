using CoffeeShopLabDomain;
using CoffeeShopLabWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeShopLabDTO;
using CoffeeShopLabDomain;
using CoffeeShopLabRepository;

namespace CoffeeShopLabWebApp.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository repo;
        private ProductInteractor _interactor;
        public ProductController()
        {
            _interactor = new ProductInteractor();
            repo = new ProductRepository();
        }
        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            _interactor.GetAllItems().ForEach(product => products.Add(ProductViewModel.ViewModelMapper(product)));

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (_interactor.GetProductIfExists(id, out Product dbProduct))
            {
                return View(ProductViewModel.ViewModelMapper(dbProduct));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
               }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Product productToAdd = ProductViewModel.ProductDtoMapperForCreate(collection);
                _interactor.AddNewProduct(productToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
