using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Blog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Blog.Controllers
{
    public class BlogsController : Controller
    {
        private readonly BlogContext _context;
        private readonly IHostingEnvironment _he;
        private readonly IHttpContextAccessor _httpContextAccessor;
      
        public BlogsController(BlogContext context, IHostingEnvironment he , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _he = he;
            _httpContextAccessor = httpContextAccessor;
          
            if (String.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString("id")))
            {

                _httpContextAccessor.HttpContext.Response.Redirect("/Home/Login");
            }


        }
    
        public IActionResult Index()
        {
           
                var id = Convert.ToInt32("0" + HttpContext.Session.GetString("id"));
                var userinfo = _context.Users.Where(u => u.Id == id);
                var userposts = _context.Posts.Where(p => p.UsersId == id);
                ViewBag.userinfo = userinfo;
                ViewBag.userposts = userposts;
                return View();
           
            
        }
        public async Task<IActionResult> NewPost()
        {
            var category = await _context.Category.Where(c => c.ParentId == 0).ToListAsync();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewPost([Bind("Title,HangerTitle,Description,Thumbnail,Tags")] ViewPosts  VPosts)
        {
            if (ModelState.IsValid)
            {
                Posts p = new Posts();
                string imgfilename = Path.GetFileName(VPosts.Thumbnail.FileName);
                string webroot = _he.WebRootPath;
                string folder = "PostThumb";
                string filewrite = Path.Combine(webroot, folder, imgfilename);
                //for Save Data To Data Base


                p.Thumbnail = "/" + folder + "/" + imgfilename;  //for image Source Save To Database

                using (var stream = new FileStream(filewrite, FileMode.Create))
                {
                    await VPosts.Thumbnail.CopyToAsync(stream);
                }
                p.CateId = VPosts.CateId;
                p.UsersId = Convert.ToInt32("0" + HttpContext.Session.GetString("id"));
                p.Title = VPosts.Title;
                p.HangerTitle = VPosts.HangerTitle;
                p.Description = VPosts.Description;
                p.Tags = VPosts.Tags;
                p.Posteddate = System.DateTime.Now;
                p.ViewCount = 0;
                p.Featured = false;
                p.IsActive = true;
                _context.Add(p);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                return RedirectToAction(nameof(NewPost));
        }
        public JsonResult GetCategory(string id)
        {
            var category = _context.Category.Where(d => d.ParentId == Convert.ToInt32(id)).OrderBy(d => d.CategoryName);

            return Json(category.ToList());
        }

    }
}