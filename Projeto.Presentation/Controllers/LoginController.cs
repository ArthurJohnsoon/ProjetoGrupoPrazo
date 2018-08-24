using Projeto.Presentation.Models;
using Projeto.Repository.Repositories;
using System.Web.Mvc;
using System.Web.Security;


namespace Projeto.Presentation.Controllers
{
    public class LoginController : Controller
    {
        protected readonly UsuarioRepository _loginRepository;

        public LoginController()
        {
            _loginRepository = new UsuarioRepository();
        }

        // GET: Usuario/Login
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var vLogin = _loginRepository.GetLogin(model.Login, model.Senha);

                if (vLogin != null)
                {
                    if (Equals(vLogin.Senha, model.Senha))
                    {
                        FormsAuthentication.SetAuthCookie(vLogin.Login, false);
                        Session["Nome"] = vLogin.Nome;
                        Session["IdUsuario"] = vLogin.UsuarioId;

                        return RedirectToAction("Home", "Home");
                    }

                    else
                    {

                        ModelState.AddModelError("", "Senha informada Inválida!!!");

                        return View(new LoginViewModel());
                    }

                }

            }

            return View(model);

        }
    }
}