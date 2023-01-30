using System.ComponentModel.DataAnnotations;

namespace Paypal.NET.ViewModels
{
    public class UserVM
    {
        [Key] public string Email { get; set; }

    }
}
