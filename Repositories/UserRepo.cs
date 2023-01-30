using Paypal.NET.Data;
using Paypal.NET.ViewModels;

namespace Paypal.NET.Repositories
{
    public class UserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserVM> GetAllUsers()
        {
            // it grabs all records from AspNetUsers table
            var allUsers = _context.Users
                            .Select(u => new UserVM() { Email = u.Email });

            return allUsers.ToList();
        }
    }
}
