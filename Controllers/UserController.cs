using Aura.Data;
using Aura.Models;

using Microsoft.AspNetCore.Mvc;

namespace Aura.Controllers
{
    public class UserController : Controller
    {
        private readonly LiteDbService _dbService;

        public UserController()
        {
            _dbService = new LiteDbService();
        }

        // Acción para mostrar todos los usuarios
        public IActionResult Index()
        {
            var users = _dbService.GetAllUsers().ToList();
            return View(users);
        }

        // Acción para crear un nuevo usuario
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _dbService.Insert(user, "Users");
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Acción para eliminar un usuario
        public IActionResult Delete(int id)
        {
            _dbService.Delete<User>(id, "Users");
            return RedirectToAction("Index");
        }
    }
}
