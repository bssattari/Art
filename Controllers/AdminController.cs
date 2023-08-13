using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Art.Models;
using Art.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Art.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    PmitLn2oqDb0001Context db = new PmitLn2oqDb0001Context()!;

    [Route("/admin")]
    public IActionResult Index()
    {
        int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "id")!.Value);

        var model = new IndexViewModel()
        {
            User = db.Users!.FirstOrDefault(x => x.Id == id && x.Role == "admin"),
            Site = db.Sites!.First(),
        };


        return View(model);
    }

    [AllowAnonymous]
    [Route("/admin/signin")]
    public async Task<IActionResult> SignIn()
    {

        /* bugün yapılan değişiklik*/

        if (Request.Cookies["email"] != null && Request.Cookies["password"] != null && Request.Cookies["role"] != null)
        {
            User user = db.Users!.FirstOrDefault(x => x.Email == Request.Cookies["email"] && x.Password == Request.Cookies["password"] && x.Role == Request.Cookies["role"])!;

            if (user != null)
            {
                var claims = new List<Claim>{
                new Claim("id",user.Id.ToString()),
                };

                var claimsIdendity = new ClaimsIdentity(claims, "Cookies", user.Role, "role");
                var claimsPrinciple = new ClaimsPrincipal(claimsIdendity);
                await HttpContext.SignInAsync(claimsPrinciple);
                return Redirect("/admin");
            }

        }

        /* bugün yapılan değişiklik sonu*/


        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
        };

        return View(model);



    }

    [AllowAnonymous]
    [HttpPost]
    [IgnoreAntiforgeryToken]
    [Route("/admin/signin")]
    public async Task<IActionResult> SignIn(User postedData)
    {

        User user = db.Users!.FirstOrDefault(x => x.Email == postedData.Email && x.Password == postedData.Password && x.Role == "admin")!;

        if (user != null)
        {
            /* bugün yapılan değişiklik*/
            if (postedData.Isremember != null && postedData.Isremember == "true")
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Append("email", user.Email, options);
                Response.Cookies.Append("password", user.Password, options);
                Response.Cookies.Append("role", user.Role, options);
            }

            /* bugün yapılan değişiklik sonu*/


            var claims = new List<Claim>{
                new Claim("id",user.Id.ToString()),
            };

            var claimsIdendity = new ClaimsIdentity(claims, "Cookies", user.Role, "role");
            var claimsPrinciple = new ClaimsPrincipal(claimsIdendity);
            await HttpContext.SignInAsync(claimsPrinciple);
            return Redirect("/admin");
        }
        else
        {
            TempData["Danger"] = "Hatalı Email / Şifre!";
            return Redirect("/admin/signin");
        }
    }

    [Route("/admin/signout")]
    public async Task<IActionResult> Signout()
    {
        await HttpContext.SignOutAsync();
        /* bugün yapılan değişiklik*/
        Response.Cookies.Delete("email");
        Response.Cookies.Delete("password");
        Response.Cookies.Delete("role");
        /* bugün yapılan değişiklik sonu*/


        TempData["Success"] = "Güvenli Çıkış Yapıldı...";

        return Redirect("/admin/signin");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
