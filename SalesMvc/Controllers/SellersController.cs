using Microsoft.AspNetCore.Mvc;

namespace SalesMvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
