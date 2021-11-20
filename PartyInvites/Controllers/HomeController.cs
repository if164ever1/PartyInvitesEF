using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Entity;
using PartyInvites.Model;
using System.Linq;

namespace PartyInvites.Controllers
{
    public class HomeController: Controller
    {
        private DataContext context;

        public HomeController(DataContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Responde()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Responde(GuestResponse guestResponde)
        {
            context.Add(guestResponde);
            context.SaveChanges();
            return RedirectToAction(nameof(Thanks), 
                new { Name = guestResponde.Name, WillAttend = guestResponde.WillAttend});
        }

        public IActionResult Thanks(GuestResponse response) => View(response);

        public IActionResult ListResponse() =>
            View(context.Response.OrderByDescending(r => r.WillAttend));

    }
}
