using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;
using System.Linq;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISimpleRepository repository;

        public HomeController(ISimpleRepository repo)
        {
            repository = repo;
        }

        // Right-click on line below and select "Add View..." to build Views\Home\index.cshtml
        public IActionResult Index() => View(repository.Products.Where(p => p?.Price < 50));
    }
}