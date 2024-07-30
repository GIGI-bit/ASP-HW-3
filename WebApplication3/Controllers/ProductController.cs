using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public async Task<ActionResult> Index(string key="")
        {
            var items=await _productService.GetAllByKey(key);
            var vm =new ProductListViewModel { Products=items};
            return View(vm);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var product = new ProductCreateViewModel
            {
                Product = new Product()
            };

            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(vm.Product);
                return RedirectToAction("Index");
            }
            else { return View(vm); }
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetById(id);
            if (product != null)
            {
                var vm = new ProductUpdateViewModel
                {
                    Product = product
                };
                return View(vm);

            }
            return RedirectToAction("Index");
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductCreateViewModel vm)
        {
            var item = await _productService.GetById(id);
            if (ModelState.IsValid)
            {
                if (item != null)
                {
                    item.Name = vm.Product.Name;
                    item.Price = vm.Product.Price;
                    item.Description = vm.Product.Description;
                    item.ImageLink = vm.Product.ImageLink;
                    item.Discount = vm.Product.Discount;

                    await _productService.UpdateAsync(item,id);

                    return RedirectToAction("Index");

                }


            }
            return View(vm);
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var item = await _productService.GetById(id);
        
            await _productService.DeleteAsync(item);

            return RedirectToAction("Index");
        }

  
    }
}
