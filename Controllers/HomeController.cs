using FileUpload.Models;
using FileUpload.services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FileUploadService    _fileUploadService;

        public HomeController(ILogger<HomeController> logger, FileUploadService fileUploadService)
        {
            _logger = logger;
            _fileUploadService = fileUploadService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  async Task<ActionResult> Index(IFormFile file)

        {
            if(await _fileUploadService.uploadfile(file))
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
}