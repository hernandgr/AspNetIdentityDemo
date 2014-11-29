using AuthenticationTest.Entities;
using AuthenticationTest.IdentityProvider.Stores;
using AuthenticationTest.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationTest.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<Role> roleManager;

        public AccountController()
        {
            UserStore userStore = new UserStore();
            userManager = new UserManager<User>(userStore);

            RoleStore roleStore = new RoleStore();
            roleManager = new RoleManager<Role>(roleStore);

        }

        #region Register

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                
                IdentityResult result = userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("UserName", "Error while creating the user!");
                }
            }
            return View(model);
        }

        #endregion Register

        #region Login

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                User user = userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                    ClaimsIdentity identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationProperties props = new AuthenticationProperties();
                    props.IsPersistent = model.RememberMe;
                    authenticationManager.SignIn(props, identity);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }

        #endregion Login

        #region ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                User user = userManager.FindByName(HttpContext.User.Identity.Name);
                IdentityResult result = userManager.ChangePassword(user.Id, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Error while changing the password.");
                }
            }
            return View(model);
        }

        #endregion

        #region Logout

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        #endregion
    }
}