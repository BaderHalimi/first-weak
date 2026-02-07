using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Learning.Models;

namespace Learning.Controllers;

public class ProductsController : Controller
{
    public ProductsController()
    {
    }

    public IActionResult ProductsAjax()
    {
        return View();
    }

    public async Task<IActionResult> Index()
    {
        using var client = new HttpClient();
        var response = await client.GetStringAsync("https://dummyjson.com/products");
        
        ViewData["Products"] = response;
        return View();
    }
}
