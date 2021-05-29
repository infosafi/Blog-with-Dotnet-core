using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
       
        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
           
            _httpContextAccessor = httpContextAccessor;
            var id = _session.GetString("id");
            if (String.IsNullOrEmpty(id))
            {
                
            }
        }

        public bool CheckLOgin()
        {
     
            var id = _session.GetString("id");
            if (String.IsNullOrEmpty(id))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
    }
}
