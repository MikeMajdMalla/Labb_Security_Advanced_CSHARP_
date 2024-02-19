using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LabbSecurity.Models
{
    public class ApplicationUser : IdentityUser 
    {
        [Required, MaxLength(100)]
        public string  FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, MaxLength(7)]
        public string Gender { get; set; }
        [Required, MaxLength(2)]
        public int Age { get; set; }
    }
}
