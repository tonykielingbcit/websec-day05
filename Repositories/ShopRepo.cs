using Paypal.NET.Data;
using Paypal.NET.Models;
using Paypal.NET.ViewModels;

namespace Paypal.NET.Repositories
{
    public class ShopRepo
    {
        ApplicationDbContext _context;

        public ShopRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            // it grabs all records from AspNetUsers table
            var allProducts = _context.Products.ToList();

            return allProducts;
        }
    }
}
