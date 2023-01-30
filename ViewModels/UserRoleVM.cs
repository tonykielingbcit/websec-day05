using System.ComponentModel.DataAnnotations;

namespace Paypal.NET.ViewModels
{
    public class UserRoleVM
    {
        [Key]
        public int ID { get; set; }


        [Required]
        public string Email { get; set; } = null!;


        [Required]
        public string Role { get; set; } = null!;

    }
}
