﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Art.Models;
using Art.Models.Entities;
using MimeKit;
using System.Text;

namespace Art.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    PmitLn2oqDb0001Context db = new PmitLn2oqDb0001Context()!;



    public string? Email { get; private set; }

    [Route("/{currentPage?}")]
    public IActionResult Index(int currentPage)
    {
        if (currentPage == 0)
        {
            currentPage = 1;
        }

        HttpContext.Session.SetInt32("currentPage", currentPage);

        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            Slides = db.Slides!.OrderBy(x => x.Order).Where(x => x.Isview == true).ToList(),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),

        };
        return View(model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/contactform")]
    public IActionResult ContactForm(Contactform postedData)
    {
        postedData.Isview = false;
        postedData.Date = DateTime.Now;
        db.Contactforms.Add(postedData);
        db.SaveChanges();

        

        Site site=db.Sites.First();
        Smtp smtp=db.Smtps.First();

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(site.Title, smtp.Email));
        message.To.Add(new MailboxAddress("Admin", site.Email));
        message.Subject = site.Title + " | Iletisim Formu";

        var body = new StringBuilder();
        body.AppendLine(site.Title + " | Iletisim Formu");
        body.AppendLine("");
        body.AppendLine("------------------------------------------");
        body.AppendLine("");
        body.AppendLine("Gonderen : " + postedData.Name +" " +postedData.Lastname);
        body.AppendLine("Email : " + postedData.Email);
        body.AppendLine("Konu : " + postedData.Subject);
        body.AppendLine("Mesaji : " + postedData.Message);

        message.Body = new TextPart("plain")
        {
            Text = body.ToString(),
        };

        Methods.sendEmail(message);
        TempData["Success"] = " Mesajiniz Basariyla iletildi en kisa surede size geri donus yapilacakdi! ";
        return Redirect(TempData["Url"]!.ToString()!);


    }

    [Route("/about")]
    public IActionResult About()
    {
        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            About = db.Abouts!.First(),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
        };
        return View(model);
    }

    [Route("/blog/{currentPage?}")]
    public IActionResult Blog(int currentPage)
    {
        if (currentPage == 0)
        {
            currentPage = 1;
        }

        HttpContext.Session.SetInt32("currentPage", currentPage);

        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
        };
        return View(model);
    }

    [Route("/blog/{title?}/{id?}")]
    public IActionResult BlogDetail(String title, int id)
    {
        Blog toUpdate = db.Blogs.Find(id)!;
        toUpdate.Read = toUpdate.Read + 1;
        db.Entry(toUpdate).CurrentValues.SetValues(toUpdate);
        db.SaveChanges();


        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            Blog = db.Blogs!.FirstOrDefault(x => x.Isview == true && x.Id == id),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Comments = db.Comments!.OrderByDescending(x => x.Id).Where(x => x.Isview == true && x.Type == "blog" && x.Typeid == id).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
        };
        return View(model);
    }

    [Route("/event/{currentPage?}")]
    public IActionResult Event(int currentPage)
    {
        if (currentPage == 0)
        {
            currentPage = 1;
        }

        HttpContext.Session.SetInt32("currentPage", currentPage);

        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
        };
        return View(model);
    }

    [Route("/event/{title?}/{id?}")]
    public IActionResult EventDetail(String title, int id)
    {
        Event toUpdate = db.Events.Find(id)!;
        toUpdate.Read = toUpdate.Read + 1;
        db.Entry(toUpdate).CurrentValues.SetValues(toUpdate);
        db.SaveChanges();

        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            Event = db.Events!.FirstOrDefault(x => x.Isview == true && x.Id == id),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Comments = db.Comments!.OrderByDescending(x => x.Id).Where(x => x.Isview == true && x.Type == "event" && x.Typeid == id).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
        };
        return View(model);
    }

    [Route("/contact/{currentPage?}")]
    public IActionResult Contact(int currentPage)
    {
        if (currentPage == 0)
        {
            currentPage = 1;
        }

        HttpContext.Session.SetInt32("currentPage", currentPage);

        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            /* Contacts = db.Contacts!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(), */
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
        };
        return View(model);
    }


    [Route("/workcat")]
    public IActionResult WorkCat()
    {

        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),

        };
        return View(model);
    }

    [Route("/workcat/{catTitle}/{catId}/{currentPage?}")]
    public IActionResult Work(string catTitle, int catId, int currentPage)
    {
        if (currentPage == 0)
        {
            currentPage = 1;
        }

        HttpContext.Session.SetInt32("currentPage", currentPage);

        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Works = db.Works!.OrderByDescending(x => x.Id).Where(x => x.Isview == true && x.Catid == catId).ToList(),
            AllWorks = db.Works!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Workcat = db.Workcats!.FirstOrDefault(x => x.Isview == true && x.Id == catId),
        };
        return View(model);
    }

    [Route("/work/{title?}/{id?}")]
    public IActionResult WorkDetail(String title, int id)
    {

        Work toUpdate = db.Works.Find(id)!;
        toUpdate.Read = toUpdate.Read + 1;
        db.Entry(toUpdate).CurrentValues.SetValues(toUpdate);
        db.SaveChanges();


        var model = new IndexViewModel()
        {
            Site = db.Sites!.First(),
            Work = db.Works!.FirstOrDefault(x => x.Isview == true && x.Id == id),
            Blogs = db.Blogs!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Events = db.Events!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Likes = db.Likes!.OrderByDescending(x => x.Id).ToList(),
            Workcats = db.Workcats!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            AllWorks = db.Works!.OrderByDescending(x => x.Id).Where(x => x.Isview == true).ToList(),
            Comments = db.Comments!.OrderByDescending(x => x.Id).Where(x => x.Isview == true && x.Type == "work" && x.Typeid == id).ToList(),
        };
        return View(model);
    }


    [Route("/like/{type?}/{id?}")]
    public IActionResult Like(string type, int id)
    {
        String ip = Request.HttpContext.Connection.RemoteIpAddress!.ToString();

        if (db.Likes.Where(x => x.Ip == ip && x.Typeid == id && x.Type == type).Count() == 0)
        {
            Like toAdd = new Like();
            toAdd.Type = type;
            toAdd.Typeid = id;
            toAdd.Ip = ip;
            db.Add(toAdd);
            db.SaveChanges();
        }
        else
        {
            Like toDelete = db.Likes.FirstOrDefault(x => x.Ip == ip && x.Typeid == id && x.Type == type)!;
            db.Remove(toDelete);
            db.SaveChanges();
        }
        int likeCount = db.Likes.Where(x => x.Typeid == id && x.Type == type).Count();

        return Content(likeCount.ToString());

        /*  return Redirect(TempData["Url"]!.ToString()!); */
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/comment")]
    public IActionResult comment(Comment postedData)
    {
        postedData.Isview = false;
        postedData.Date = DateTime.Now;
        db.Comments.Add(postedData);
        db.SaveChanges();
        TempData["Success"] = " Yurumunuz basariyla kaydedildi! ";
        return Redirect(TempData["Url"]!.ToString()!);

        /*  return Content(postedData.Email!); */
        /*  return Content(postedData.Typeid.ToString()!);  */
        /* return Content(DateTime.Now.ToString()!); */
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/subscribe")]
    public IActionResult Subscribe(Subscribe postedData)
    {
        if (db.Subscribes.FirstOrDefault(x => x.Email == postedData.Email) == null)
        {
            db.Subscribes.Add(postedData);
            db.SaveChanges();
            TempData["SuccessSubscribe"] = " E-Bulten kaydiniz Basariyla gerceklestirilmistir! ";
        }
        else
        {
            TempData["DangerSubscribe"] = "  Girmis oldugunuz e-mail adresi sistemde kayitli! ";
        }

        return Redirect(TempData["Url"]!.ToString()!);


    }
    /* string Title="";
    if (postedData.Type=="blog")
    {
       Title=db.Blogs.Find(postedData.Typeid)!.Title!;	
    }
    postedData.Isview= false;
    postedData.Date=DateTime.Now;
    db.Comments.Add(postedData);
    db.SaveChanges();
    TempData["Success"]=" Yorumunuz Basariyla Kaydedildi! incelendiginden Sonra Yayinlanacak! ";
    return Redirect("/" + postedData.Type + "/"+ Methods.GenerateUrl(Title) +"/"+ 
    postedData.Typeid);*/

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

