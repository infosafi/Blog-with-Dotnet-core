using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class AdminController : Controller
    {
        private readonly BlogContext _context;
        public AdminController(BlogContext context)
        {
            _context = context;
           
        }
        public IActionResult Index()
        {
            ViewBag.TotalUsers = _context.Users.Count();
            ViewBag.TotalCategory = _context.Category.Count();
            ViewBag.TotalPosts = _context.Posts.Count();
            ViewBag.TotalPublished = _context.Posts.Where(p=>p.IsActive==true).Count();
            return View();
        }
        public async Task<IActionResult> AllUsers(int page, int pagesize)
        {
            IQueryable<Users> app = _context.Users;
            if (page <= 0)
                page = 1;
            pagesize = (pagesize == 0) ? 10 : pagesize;           
            ViewBag.pagesize = pagesize;
            return View(await PaginatedList<Users>.CreateAsync(app, page, pagesize));
        }
        public async Task<IActionResult> AddCategory()
        {
            var category = await _context.Category.Where(c=>c.ParentId==0).ToListAsync();
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory([Bind("ParentId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddCategory");
            }
            return RedirectToAction("AddCategory");
        }
        
        public IActionResult AllPosts()
        {
            ViewBag.userposts = _context.Posts;
            return View();
        }
        public async Task<IActionResult> AllCategory()
        {
            return View(await _context.Category.ToListAsync());
        }
        public async Task<IActionResult> UpdateStatus(int id, bool status, string type)
        {
            var posts = _context.Posts.FirstOrDefault(p => p.Id == id);
            switch (type)
            {
                case "Featured":
                    posts.Featured = status;
                    break;
                case "Publish":
                    posts.IsActive = status;
                    break;                
            }
            _context.Update(posts);
            await _context.SaveChangesAsync();
            return RedirectToAction("AllPosts");
        }
    }
}