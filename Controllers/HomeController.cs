using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Art.Models;
using Art.Models.Entities;

namespace Art.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    PmitLn2oqDb0001Context db = new PmitLn2oqDb0001Context();

    public IActionResult Index()
    {
        var model = new IndexVeiewModel() 
        { Site = db.Sites!.First() };
        return View(model);
    }

    [Route("/contact")]
    public IActionResult Contact()
    {
        return View();
    }

    [Route("/about")]
    public IActionResult About()
    {
        return View();
    }
    [Route("/blog")]
    public IActionResult Blog()
    {
        return View();
    }
    [Route("/bloge/{title}/{id}")]
    public IActionResult blogDetail(string title, int id)
    {
        return View();
    }

    [Route("/event")]
    public IActionResult Event()
    {
        return View();
    }

    [Route("/work")]
    public IActionResult Work()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public override bool Equals(object? obj)
    {
        return obj is HomeController controller &&
               EqualityComparer<PmitLn2oqDb0001Context>.Default.Equals(db, controller.db);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(db);
    }
}

