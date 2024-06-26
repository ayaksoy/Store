using EKStore.Areas.Customer.Services.Interfaces;
using EKStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EKStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        public HomeController(ILogger<HomeController> logger,ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Category()
        {
            var list=await _categoryService.GetAllAsync();
            return View(list);
        }
        public async Task<IActionResult> CategoryDetail(int id) 
        { 
            var category=await _categoryService.GetByIdAsync(id);

            return View(category);
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult User()
        {
            return View();
        }
        public IActionResult Role()
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
