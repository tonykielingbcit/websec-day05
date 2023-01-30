using System.ComponentModel.DataAnnotations;

namespace Paypal.NET.ViewModels
{
    public class RoleVM
    {
        public string Id { get; set; } = null!;

        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; } = string.Empty;

    }
}
