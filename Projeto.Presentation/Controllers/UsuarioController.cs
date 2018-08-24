using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models;
using Projeto.Repository.Repositories;
using Projeto.Entities;
using System.Net;

namespace Projeto.Presentation.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        public ActionResult Index()
        {
            var usuario = _usuarioRepository.GetAll();

            List<UsuarioViewModel> viewModel = new List<UsuarioViewModel>();
            foreach (var item in usuario)
            {
                var model = new UsuarioViewModel();
                model.UsuarioId = item.UsuarioId;
                model.Nome = item.Nome;
                model.Email = item.Email;
                model.Senha = item.Senha;
                model.Login = item.Login;
                model.Permissao = item.Permissao;

                viewModel.Add(model);
            }

            return View(viewModel);
        }

        // GET: Usuario/Cadastro
        public ActionResult Cadastro()
        {
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        public ActionResult Cadastro(UsuarioViewModel model)
        {
            if (ModelState.IsValid)

            {
                try
                {
                    var usuario = new Usuario();
                    usuario.Nome = model.Nome;
                    usuario.Senha = model.Senha;
                    usuario.Login = model.Login;
                    usuario.Email = model.Email;
                    usuario.Permissao = model.Permissao;

                    _usuarioRepository.Insert(usuario);
                }
                catch (Exception e)
                {

                    ViewBag.Mensagem = e.Message;
                    return View();
                }

                ViewBag.Mensagem = "Usuario cadastrado com sucesso.";
                ModelState.Clear();
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Alterar(int usuarioId)
        {

            var usuario = _usuarioRepository.GetById(usuarioId);

            var viewModel = new UsuarioViewModel();
            viewModel.UsuarioId = usuario.UsuarioId;
            viewModel.Nome = usuario.Nome;
            viewModel.Email = usuario.Email;
            viewModel.Login = usuario.Login;
            viewModel.Senha = usuario.Senha;
            viewModel.Permissao = usuario.Permissao;
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Alterar(UsuarioViewModel model)
        {

            ModelState.Remove("Senha");
            ModelState.Remove("SenhaConfirm");
            if (ModelState.IsValid)

            {
                try
                {
                    var usuario = _usuarioRepository.GetById(model.UsuarioId);

                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Login = model.Login;
                    usuario.Permissao = model.Permissao;

                    _usuarioRepository.Update(usuario);
                    ViewBag.Mensagem = "Usuario Alterado com sucesso.";
                    ModelState.Clear();
                    return RedirectToAction("Index");

                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                    return View();
                }

            }
            return View();
        }


        public ActionResult Excluir(int usuarioId)
        {
            var usuario = _usuarioRepository.GetById(usuarioId);

            _usuarioRepository.Delete(usuario);

            ViewBag.Mensagem = "Usuario excluido com sucesso.";

            return RedirectToAction("Index");
        }

    }
}