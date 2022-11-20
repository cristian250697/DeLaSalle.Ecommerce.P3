using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers;

public class Brand : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}