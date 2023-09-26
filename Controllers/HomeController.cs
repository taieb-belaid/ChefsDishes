#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
namespace ChefsDishes.Controllers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Chef>All_Chefs = _context.Chefs.ToList();
        return View(All_Chefs);
    }
    //___________Add_a_chef__View_____
    [HttpGet("chef/add")]
    public IActionResult AddChef()
    {
        return View();
    }
    //_____________ADD_a_chef_database___
    [HttpPost("/chef/add-db")]
    public IActionResult AddChefDb(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Chefs.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddChef");
    }
    //__________Add_a_Dish_View_______
    [HttpGet("dish/add")]
    public IActionResult AddDish()
    {
        ViewBag.All_Chefs = _context.Chefs.ToList();
        return View();
    }
    //_________Add_a_Dish_database_____
    [HttpPost("/dish/add-db")]
    public IActionResult AddDishDb(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        return View("AddDish");
    }
    //________Dishes_with_Chef___
    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {
        // ViewBag.DishWithChef = _context.Dishes.Include(d => d.Maker).ToList();
        List<Dish> DishWithChef =_context.Dishes.Include(d => d.Maker).ToList();
        return View(DishWithChef);
    }
    //____________________________
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
