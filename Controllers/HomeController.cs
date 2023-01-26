using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paypal.NET.Data;
using Paypal.NET.Models;
using System.Diagnostics;

namespace Paypal.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(
            ILogger<HomeController> logger, 
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Index()
        {
            return View("Index", "3.55|CAD");
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        [Authorize]
        public IActionResult Transactions()
        {
            DbSet<IPN> items = _context.IPNs;

            //this is temporary with hardcoded data
            //List<IPN> items = new List<IPN>();
            //var temp = new IPN
            //{
            //    paymentID = "123",
            //    create_time = DateTime.Now.ToString("dd'/'MM'/'yyyy , HH:mm"),
            //    payerFirstName = "Bob",
            //    payerEmail = "bob@email.ca",
            //    amount = "123",
            //    paymentMethod = "paypal"
            //};
            //items.Add(temp);

            return View(items);
        }

        // This method receives and stores
        // the Paypal transaction details.
        [HttpPost]
        public JsonResult PaySuccess([FromBody] IPN ipn)
        {
            try
            {
                _context.IPNs.Add(ipn);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(ipn);
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        [Authorize]
        public IActionResult Confirmation(string confirmationId)
        {
            // check whether there is real data coming,
            // if not, it displays fake data below
            if (confirmationId != null)
            {
                IPN transaction = _context.IPNs
                                    .FirstOrDefault(t => t.paymentID == confirmationId);

                return View("Confirmation", transaction);
            }

            //this is temporary with hardcoded data
            var temp = new IPN
            {
                paymentID = "PAYID-MPIH5HA4J269406WS7648845",
                create_time = DateTime.Now.ToString("dd'/'MM'/'yyyy , HH:mm"),
                payerFirstName = "Tony Kieling",
                amount = "123.46",
                paymentMethod = "paypal"
            };
            ViewBag.temp = "flag is ON";
            return View("Confirmation", temp);
        }

    }
}