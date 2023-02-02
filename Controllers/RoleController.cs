using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paypal.NET.Data;
using Paypal.NET.Repositories;
using Paypal.NET.ViewModels;

namespace Paypal.NET.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        ApplicationDbContext _context;
        RoleRepo _roleRepo;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
            _roleRepo = new RoleRepo(context);
        }

        // GET: Role
        public ActionResult Index()
        {
            RoleRepo roleRepo = new RoleRepo(_context);

            return View(roleRepo.GetAllRoles());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleVM addRole)
        {
            var token = HttpContext.Request.Form["__RequestVerificationToken"];
            _roleRepo.CreateRole(addRole.RoleName);

            return RedirectToAction("Index", "Role");
        }


    }

}
