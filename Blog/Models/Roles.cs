using Blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Roles
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public List<Users> Users { get; set; }
    }
}
