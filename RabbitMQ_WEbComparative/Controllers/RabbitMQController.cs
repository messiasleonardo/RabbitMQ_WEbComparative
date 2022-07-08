using Microsoft.AspNetCore.Mvc;
using RabbitMQ_WEbComparative.Models;

namespace RabbitMQ_WEbComparative.Controllers
{
    public class RabbitMQController : Controller
    {
        public IActionResult Index()
        {
            RabbitMQViewModel rabbitMQViewModel = new RabbitMQViewModel();
            return View(rabbitMQViewModel);
        }

        public IActionResult Tester()
        {
            RabbitMQViewModel rabbitMQViewModel = new RabbitMQViewModel();
            rabbitMQViewModel.Valid = true;
            return View("Index",rabbitMQViewModel);
        }
    }
}
