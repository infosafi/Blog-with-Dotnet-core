using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext (DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Blog.Models.Users> Users { get; set; }

        public DbSet<Blog.Models.Roles> Roles { get; set; }
        public DbSet<Blog.Models.Category> Category { get; set; }

        public DbSet<Blog.Models.Posts> Posts { get; set; }
    }
}
