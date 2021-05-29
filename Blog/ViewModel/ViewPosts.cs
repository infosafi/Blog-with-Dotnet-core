using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModel
{
    public class ViewPosts
    {
        
            public int Id { get; set; }
            [Required]
            public int UsersId { get; set; }
            [Required]
            public int PCateId { get; set; }
            [Required]
             public int CateId { get; set; }
            [Required]
            [MaxLength(250)]
            public string Title { get; set; }

            [Required]
            [MaxLength(250)]
            public string HangerTitle { get; set; }

            [Required]
            public string Description { get; set; }

            public IFormFile Thumbnail { get; set; }
            [MaxLength(150)]
            public string Tags { get; set; }

            public DateTime Posteddate { get; set; }
            public int ViewCount { get; set; }
            public bool IsActive { get; set; }
            public bool Featured { get; set; }
           
        
    }
}
