using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paypal.NET.Models;
using System.ComponentModel.DataAnnotations;

namespace Paypal.NET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<IPN> IPNs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
               base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}