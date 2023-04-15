using Microsoft.AspNetCore.Mvc;
using NewsApplication2.Models;
using System.Diagnostics;


using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using NewsApplication2.Services;
using NewsApplication2.Business;

namespace NewsApplication2.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private NewsManager _newsManager = new NewsManager();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int page = 1, string saerchNews = "software")
        {
            var news = _newsManager.GetNewsOnAPI(DateTime.Today.Date, page, saerchNews);
            var pageCount = _newsManager.GetPageCount();

            ViewData["PageCount"] = pageCount;
            ViewData["ActivePage"] = page;

            if (news == null)
            {
                return NotFound();
            }
            return View(news);

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