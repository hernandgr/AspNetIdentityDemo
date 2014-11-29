using AuthenticationTest.Entities;
using AuthenticationTest.IdentityProvider.Stores;
using AuthenticationTest.Web.Models;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationTest.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {         
            UserStore userStore = new UserStore();
            UserManager<User> userManager = new UserManager<User>(userStore);
            User user = userManager.FindByName(HttpContext.User.Identity.Name);

            HomeViewModel model = new HomeViewModel()
            {
                Name = user.UserName
            };            

            if (userManager.IsInRole(user.Id, "Administrator"))
            {
                model.Role = "Administrator";
            }

            if (userManager.IsInRole(user.Id, "Operator"))
            {
                model.Role = "Operator";
            }

            return View(model);
        }
    }
}