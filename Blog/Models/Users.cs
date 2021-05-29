using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Remote("CheckEmail","Home",ErrorMessage ="Your Given Email is Exist")]
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

        public string Images { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        public bool Isactive { get; set; }

        public int RolesId { get; set; }

        public List<Posts> Posts { get; set; }
        public Roles Roles { get; set; }
    }
}
