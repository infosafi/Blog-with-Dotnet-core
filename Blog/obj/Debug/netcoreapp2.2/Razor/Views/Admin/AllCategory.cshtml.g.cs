#pragma checksum "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\Admin\AllCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14060980588681e5ed7e18abb913bf520ad50275"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AllCategory), @"mvc.1.0.view", @"/Views/Admin/AllCategory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/AllCategory.cshtml", typeof(AspNetCore.Views_Admin_AllCategory))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using Blog;

#line default
#line hidden
#line 2 "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using Blog.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14060980588681e5ed7e18abb913bf520ad50275", @"/Views/Admin/AllCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60de8826b8954e9153bb5ddebbd8520bddd0a921", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AllCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Blog.Models.Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\Admin\AllCategory.cshtml"
  
    ViewData["Title"] = "All Category";

#line default
#line hidden
            BeginContext(92, 84, true);
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(177, 44, false);
#line 10 "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\Admin\AllCategory.cshtml"
           Write(Html.DisplayNameFor(model => model.ParentId));

#line default
#line hidden
            EndContext();
            BeginContext(221, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(277, 48, false);
#line 13 "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\Admin\AllCategory.cshtml"
           Write(Html.DisplayNameFor(model => model.CategoryName));

#line default
#line hidden
            EndContext();
            BeginContext(325, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 19 "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\Admin\AllCategory.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(460, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(521, 43, false);
#line 23 "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\Admin\AllCategory.cshtml"
               Write(Html.DisplayFor(modelItem => item.ParentId));

#line default
#line hidden
            EndContext();
            BeginContext(564, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(632, 47, false);
#line 26 "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\Admin\AllCategory.cshtml"
               Write(Html.DisplayFor(modelItem => item.CategoryName));

#line default
#line hidden
            EndContext();
            BeginContext(679, 61, true);
            WriteLiteral("\r\n                </td>\r\n               \r\n            </tr>\r\n");
            EndContext();
#line 30 "H:\Safi-backup\BACKUP\Blog\Blog\Blog\Views\Admin\AllCategory.cshtml"
        }

#line default
#line hidden
            BeginContext(751, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Blog.Models.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
