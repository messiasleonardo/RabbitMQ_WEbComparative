using Microsoft.AspNetCore.Mvc;
using RabbitMQ_WEbComparative.Models;

namespace RabbitMQ_WEbComparative.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index(List<string> names)
        {
            RabbitMQViewModel model = new RabbitMQViewModel();
            model.CustomerName = names;
            return View(model);
        }
    }
}
