using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Client.Models;
using NetCoreWebApi.DataAccess.Entities;
using NetCoreWebApi.Models.Concrete;
using Newtonsoft.Json;
using System.Diagnostics;

namespace NetCoreWebApi.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var cat = new List<CategoryDTO>();
            using(HttpClient cl = new HttpClient())
            {
                using (var response = await cl.GetAsync("https://localhost:7175/api/Category/GetAllCategories"))
                {
                    string apRes = await response.Content.ReadAsStringAsync();
                    cat = JsonConvert.DeserializeObject<List<CategoryDTO>>(apRes);
                }
            }
            return View(cat);
        }

        public async Task<IActionResult> Privacy()
        {
            var prod = new List<ProductDTO>();
            using(HttpClient cl = new HttpClient())
            {
                using(var respoen = await cl.GetAsync("https://localhost:7175/api/Product/GettAllProducts"))
                {
                    string apres= await respoen.Content.ReadAsStringAsync();
                    prod = JsonConvert.DeserializeObject<List<ProductDTO>>(apres);
                }
            }
            return View(prod);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}