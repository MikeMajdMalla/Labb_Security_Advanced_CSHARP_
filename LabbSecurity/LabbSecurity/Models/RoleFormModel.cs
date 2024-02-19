using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace LabbSecurity.Models
{
    public class RoleFormModel
    {
        [Required, StringLength(100)]
        public  string Name { get; set; }
    }
}
