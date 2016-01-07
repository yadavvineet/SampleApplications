using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMars.Models
{
    public class ContactPerson
    {
        [Required]
        [StringLength(234, MinimumLength = 4)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(234, MinimumLength = 23)]
        public string Message { get; set; }
    }
}
