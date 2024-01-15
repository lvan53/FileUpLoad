using FileUpload.Interfaces;
using FileUpload.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileUpload.Controllers;

public class HomeController : Controller
{
    private readonly IFileUpload _fileUploadService;

    public HomeController(IFileUpload fileUploadService)
    {
        _fileUploadService = fileUploadService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public  async Task<ActionResult> Index(IFormFile file)
    {
        if(await _fileUploadService.UploadFile(file))
        {
            ViewBag.Message = "file upload success";
        }
        else { 
            ViewBag.Message="failed";
        }

        return View();
    }

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
