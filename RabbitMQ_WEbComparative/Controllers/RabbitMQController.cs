using Microsoft.AspNetCore.Mvc;
using RabbitMQ_WEbComparative.Models;

namespace RabbitMQ_WEbComparative.Controllers
{
    public class RabbitMQController : Controller
    {
        private RabbitMQViewModel _rabbitmqViewModel;
        public RabbitMQController()
        {
            _rabbitmqViewModel = new RabbitMQViewModel();
        }
        public IActionResult Index()
        { 
            return View(_rabbitmqViewModel);
        }

        public IActionResult Tester()
        {
            _rabbitmqViewModel.SendMessageQueue();
            return View("Index", _rabbitmqViewModel);
        }
    }
}
