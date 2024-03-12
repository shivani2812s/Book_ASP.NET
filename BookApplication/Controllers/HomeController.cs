using Microsoft.AspNetCore.Mvc;

namespace BookApplication.NewFolder
{
    public class HomeController : Controller
    {
        public ViewResult Index() {
            ViewBag.Title="BookWaale";
             return View(); }


        public ViewResult AboutUs() { 

            return View(); 
        }
    }
}
