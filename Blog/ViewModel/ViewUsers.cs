using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModel
{
    public class ViewUsers
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Remote("CheckEmail", "Home", ErrorMessage = "Your Given Email is Exist")]
        public string Email { get; set; }

        [Required]
        [MaxLength(11)]
        public string Mobile { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [Url]
        public string Webaddress { get; set; }
        [Url]
        public string SocialLink { get; set; }

        public IFormFile Images { get; set; }
        
        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        public bool Isactive { get; set; }

        public int RolesId { get; set; }

        
    }
}
