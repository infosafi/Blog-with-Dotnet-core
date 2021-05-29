using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Blog.ViewModel;
using System.Text;
using System.Security.Cryptography;
using System;
using Blog.Services;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogContext _context;
        private readonly IHostingEnvironment _he;
        private readonly IEmailService _emailService;
        public HomeController(BlogContext context, IHostingEnvironment he, IEmailService emailService)
        {
            _context = context;
            _he = he;
            _emailService = emailService;
        }
        public async Task<IActionResult> Index(int page)
        {
            IQueryable<Posts> Feature = _context.Posts.Where(p => p.IsActive == true && p.Featured==true).OrderByDescending(p=>p.Posteddate).Take(3);
            IQueryable<Posts> Posts = _context.Posts.Where(p => p.IsActive == true).OrderByDescending(p=>p.Posteddate);
            IQueryable<Posts> Mostread = _context.Posts.Where(p => p.IsActive == true).OrderByDescending(p => p.ViewCount).Take(3);
            if (page <= 0)
                page = 1;
            int pagesize =5;
            ViewBag.page = page;
            ViewBag.Feature = Feature;
            ViewBag.Mostread = Mostread;
            return View(await PaginatedList<Posts>.CreateAsync(Posts, page, pagesize));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Name,Email,Mobile,Address,Webaddress,SocialLink,Images,Password")] ViewUsers users)
        {
            var msg = "";
            if (ModelState.IsValid)
            {
               

                Users u = new Users();
               
                string imgfilename = Path.GetFileName(users.Images.FileName);
                string webroot = _he.WebRootPath;
                string folder = "Thumbnail";
                string filewrite = Path.Combine(webroot, folder, imgfilename);
                //for Save Data To Data Base
               
                  
                u.Images = "/" + folder + "/" + imgfilename;  //for image Source Save To Database
               
                using (var stream = new FileStream(filewrite, FileMode.Create))
                {
                    await users.Images.CopyToAsync(stream);
                }
                u.Name = users.Name;
                u.Email = users.Email;
                u.Mobile = users.Mobile;
                u.Address = users.Address;
                u.Webaddress = users.Webaddress;
                u.SocialLink = users.SocialLink;              
                u.Password = PasswordEnc(users.Password);               
                u.Isactive = true;
                u.RolesId = 2;
                _context.Add(u);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetString("Name", users.Name);
                HttpContext.Session.SetString("id", users.Id.ToString());
                HttpContext.Session.SetString("Email", users.Email.ToString());
             //   await _emailService.SendEmail(users.Email, "Registration Successfully", "Hello { users.Name} Your Registration Successfully Complete!");
                return RedirectToAction("Index", "Blogs");

            }
            msg = "Given Data is Invalid";
            TempData["msg"] = msg;
            return RedirectToAction("Register");
        }
        [AcceptVerbs("Get","Post")]
        public IActionResult CheckEmail(string Email)
        {
            if (ModelState.IsValid)
            {
                var email = _context.Users.Where(u => u.Email == Email).ToList();
                if (email.Count > 0)
                {
                    return Json(data: $"Given {Email} already Exist");
                }
              
            }
            return Json(true);
        }

        private string PasswordEnc(string password)
        {
            var enc = Encoding.GetEncoding(0);

            byte[] buffer = enc.GetBytes(password);
            var sha1 = SHA1.Create();
            var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
            return hash;
        }
        public IActionResult Login()
        {
            ViewBag.msg = TempData["msg"];
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Email, string Password)
        {
            string msg = "";
            bool loggedin = false;
            if (!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password))
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == PasswordEnc(Password));
                if (user != null)
                {
                    if (user.Isactive == true)
                    {
                        HttpContext.Session.SetString("Name", user.Name);
                        HttpContext.Session.SetString("id", user.Id.ToString());
                        HttpContext.Session.SetString("Email", user.Email.ToString());
                        loggedin = true;

                    }
                    else
                    {
                        msg = "User is not active";

                    }
                }
                else
                {
                    msg = "Email or Password is Invalid";

                }

                if (loggedin)
                {
                    if (user.RolesId == 1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Blogs");
                    }
                   
                }
                TempData["msg"] = msg;
                return RedirectToAction(nameof(Login));
            }
            else
            {
                msg = "UserName or Password is Invalid";
            }

            TempData["msg"] = msg;
            return RedirectToAction(nameof(Login));
        }
        public async Task<IActionResult> SinglePosts(int id)
        {
            var posts = _context.Posts.FirstOrDefault(p=>p.Id==id && p.IsActive==true);
            posts.ViewCount = posts.ViewCount + 1;
            _context.Update(posts);
            await _context.SaveChangesAsync();
            IQueryable<Posts> Mostread = _context.Posts.Where(p => p.IsActive == true).OrderByDescending(p => p.ViewCount).Take(3);
            ViewBag.Mostread = Mostread;
            return View(posts);
        }
      
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Name");
            HttpContext.Session.Remove("id");
            HttpContext.Session.Remove("Email");
            return RedirectToAction(nameof(Login));


        }
    }
}
