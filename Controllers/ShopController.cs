using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paypal.NET.Data;
using Paypal.NET.Repositories;

namespace Paypal.NET.Controllers
{
    public class ShopController : Controller
    {
        ApplicationDbContext _context;
        ShopRepo _shopRepo;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
            _shopRepo = new ShopRepo(context);
        }
        public IActionResult Index()
        {
            var products = _shopRepo.GetAllProducts();

            return View(products);
        }
    }
}
