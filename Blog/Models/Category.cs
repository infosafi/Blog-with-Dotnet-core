using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public int ParentId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public List<Posts> Posts { get; set; }

    }
}
