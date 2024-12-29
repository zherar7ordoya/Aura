using System.Diagnostics;

using Aura.Data;
using Aura.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aura.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LiteDbService _liteDbService;

        // Un solo constructor que recibe ambas dependencias
        public HomeController(ILogger<HomeController> logger, LiteDbService liteDbService)
        {
            _logger = logger;
            _liteDbService = liteDbService;
            _liteDbService.Initialize(); // Aseguramos que la base de datos y las colecciones estén inicializadas
        }

        //......................................................................

        public IActionResult Index()
        {
            var data = _liteDbService.GetAllUsers(); // Método que obtiene los datos desde LiteDB
            return View(data);
        }

        //......................................................................

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
