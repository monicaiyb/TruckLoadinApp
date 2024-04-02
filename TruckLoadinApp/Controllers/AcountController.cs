using Microsoft.AspNetCore.Mvc;

namespace TruckLoadinApp.Controllers
{
    public class AcountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
