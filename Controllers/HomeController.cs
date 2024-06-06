using ClassTaskOf_June.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ClassTaskOf_June.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClassTaskContext context;

        public HomeController(ILogger<HomeController> logger, ClassTaskContext context)
        {
            _logger = logger;
            this.context = context;
        }
        public IActionResult Signup()
        {
            return View();
        }
        
        public IActionResult Signup(UserReg user)
        {

            return View();
        }
        public IActionResult Index()
        {
            var show = context.Products.Include(options=> options.Category).ToList();
            
            return View(show);
        }
        public IActionResult AddProduct()
        {
            ProductViewModel cat = new ProductViewModel()
            {
                InsertProduct = new Product(),
                Categoryp = context.ProductCategories.ToList()

            };
            return View(cat);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel addPro, IFormFile img)
        {
            if (img != null && img.Length > 1)
            {
                var filetype = System.IO.Path.GetExtension(img.FileName).Substring(1);

                if (filetype == "png" || filetype == "jpeg" || filetype == "jpg")
                {
                    var realname = Path.GetFileName(img.FileName);

                    var name = Guid.NewGuid() + realname;

                    var folder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/images");

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    var path = Path.Combine(folder, name);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        img.CopyTo(stream);
                    }

                    var dbPath = Path.Combine("images", name);

                    Product data = new Product()
                    {
                        ProductName = addPro.InsertProduct.ProductName,
                        ProductPrice = addPro.InsertProduct.ProductPrice,
                        Description = addPro.InsertProduct.Description,
                        CategoryId = addPro.InsertProduct.CategoryId,
                        ProductImage = dbPath
                    };
                    context.Products.Add(data);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.failedfile = "File type is not supported";
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}