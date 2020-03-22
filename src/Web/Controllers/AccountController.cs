using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            //var user = await this.getUserByEmailAndPassword.Execute(loginViewModel.Email, loginViewModel.Password);

            //if (user is null)
            //{
            //    ModelState.AddModelError("InvalidAttempt", "Usuário ou senha inválidos");
            //    return View(loginViewModel);
            //}

            //await this.CreateClaims(user, loginViewModel.LembrarDeMim);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async ValueTask<IActionResult> Register(RegistroViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            //var user = await this.createUser.Execute(new Usuario(registerViewModel.Nome, registerViewModel.Email, registerViewModel.Senha));

            //await this.CreateClaims(user, registerViewModel.LembrarDeMim);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async ValueTask<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async ValueTask CreateClaims(Usuario usuario, bool lembrarDeMim)
        {
            ClaimsIdentity identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Sid, usuario.Id.ToString())
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(ClaimTypes.IsPersistent, lembrarDeMim ? "true" : TimeSpan.FromMinutes(20).ToString()));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
    }
}