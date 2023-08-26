using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Art.Models;
using Art.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MimeKit;
using System.Text;

namespace Art.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly IWebHostEnvironment webHostEnvironment;
    public AdminController(IWebHostEnvironment hostEnvironment, ILogger<AdminController> logger)
    {
        webHostEnvironment = hostEnvironment;
        _logger = logger;
    }

    PmitLn2oqDb0001Context db = new PmitLn2oqDb0001Context()!;
    private object postedData;

    [Route("/admin/slide")]
    public IActionResult Slide()
    {
        int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "id")!.Value);

        var model = new IndexViewModel()
        {
            User = db.Users!.FirstOrDefault(x => x.Id == id && x.Role == "admin"),
            Site = db.Sites!.First(),
            Slides = db.Slides!.OrderBy(x => x.Order).ToList(),
        };

        return View(model);
    }

    [Route("/admin/slide/isview/{id}")]
    public IActionResult SlideIsview(int id)
    {
        Slide toUpdate = db.Slides.FirstOrDefault(x => x.Id == id)!;
        toUpdate.Isview = !toUpdate.Isview;
        db.Entry(toUpdate).CurrentValues.SetValues(toUpdate);
        db.SaveChanges();

        return Content(toUpdate.Isview.ToString()!);

        /*  return Redirect(TempData["Url"]!.ToString()!); */
    }
    [Route("/admin/slide/add")]
    public IActionResult SlideAdd()
    {
        int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "id")!.Value);

        var model = new IndexViewModel()
        {
            User = db.Users!.FirstOrDefault(x => x.Id == id && x.Role == "admin"),
            Site = db.Sites!.First(),
        };

        return View(model);
    }

    [Route("/admin/slide/delete/{id?}")]
    public IActionResult SlideDelete(int id)
    {
        Slide toDelete = db.Slides.Find(id)!;
        db.Remove(toDelete);
        db.SaveChanges();
        TempData["Success"] = "Kayıt silindi!";
        return Redirect("/admin/slide");
    }
 [HttpPost]
    [IgnoreAntiforgeryToken]
    [Route("/admin/slide/save")]
    public IActionResult SlideSave(Slide postedData, IFormFile File)
    {
        string fileExtension = System.IO.Path.GetExtension(File.FileName);
        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads/images/");
        /* string fileName = Guid.NewGuid().ToString() + fileExtension; */
        string fileName = Methods.GenerateUrl(postedData.Title!)+ "-slid" + fileExtension;
        string filePath = Path.Combine(uploadsFolder, fileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            File.CopyTo(fileStream);
        }
        postedData.Image = fileName;
        postedData.Isview = true;
        db.Slides.Add(postedData);
        db.SaveChanges();

        TempData["Success"] = "Kayıt eklendi!";
        return Redirect("/admin/slide");
    }

        [AllowAnonymous]
        [Route("/admin/forgot-password")]
        public IActionResult ForgotPassword()
        {

            var model = new IndexViewModel()
            {
                Site = db.Sites!.First(),
            };


            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [IgnoreAntiforgeryToken]
        [Route("/admin/recover-password")]
        public IActionResult RecowerPassword(User postedData)
        {

            User user = db.Users!.FirstOrDefault(x => x.Email == postedData.Email && x.Role == "admin")!;
            Site site = db.Sites!.First();
            Smtp smtp = db.Smtps!.First();

            if (user != null)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(site.Title, smtp.Email));
                message.To.Add(new MailboxAddress("Admin", user.Email));
                message.Subject = site.Title + " | Admin Şifre Hatırlatma";

                var body = new StringBuilder();
                body.AppendLine(site.Title + " | Admin Şifre Hatırlatma");
                body.AppendLine("");
                body.AppendLine("------------------------------------------");
                body.AppendLine("");

                body.AppendLine("Email : " + user.Email);
                body.AppendLine("Şifre : " + user.Password);

                message.Body = new TextPart("plain")
                {
                    Text = body.ToString(),
                };

                Methods.sendEmail(message);

                TempData["Success"] = "Şifreniz e-mail adresine gönderilmiştir!";
                return Redirect("/admin/forgot-password");

            }
            else
            {
                TempData["Danger"] = "Bu e-mail adresi sisteme kayıtlı değil!";
                return Redirect("/admin/forgot-password");
            }
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
