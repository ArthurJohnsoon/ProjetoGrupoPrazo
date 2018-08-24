using Projeto.Entities;
using Projeto.Presentation.Models;
using Projeto.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Controllers
{
    [Authorize]
    public class TarefaController : Controller
    {
        private readonly TarefaRepository _tarefaRepository;
        private readonly UsuarioRepository _usuarioRepository;


        public TarefaController()
        {
            _tarefaRepository = new TarefaRepository();
            _usuarioRepository = new UsuarioRepository();
        }


        public ActionResult Index()
        {
            var usuario = _usuarioRepository.GetById(int.Parse(Session["IdUsuario"].ToString()));

            List<Tarefa> tarefa;

            if (usuario.Permissao == "ADMINISTRADOR")
                tarefa = _tarefaRepository.GetAll();
            else
                tarefa = _tarefaRepository.GetByUsuario(usuario.UsuarioId);

            List<TarefaViewModel> viewModel = new List<TarefaViewModel>();
            foreach (var item in tarefa)
            {
                var model = new TarefaViewModel();
                model.Titulo = item.Titulo;
                model.TarefaId = item.TarefaId;
                model.IsConcluido = item.IsConcluido;

                viewModel.Add(model);
            }

            return View("Tarefas", viewModel);
        }

        // GET: Tarefa
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(TarefaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tarefa = new Tarefa();
                    tarefa.Titulo = model.Titulo;
                    tarefa.Usuario = _usuarioRepository.GetById(int.Parse(Session["IdUsuario"].ToString()));
                    _tarefaRepository.Insert(tarefa);
                }
                catch (Exception e)
                {

                    ViewBag.Mensagem = e.Message;
                    return View();
                }

                ViewBag.Mensagem = "Tarefa cadastrada com sucesso.";
                ModelState.Clear();
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Alterar(int tarefaId)
        {

            var tarefa = _tarefaRepository.GetById(tarefaId);

            var viewModel = new TarefaViewModel();
            viewModel.TarefaId = tarefa.TarefaId;
            viewModel.Titulo = tarefa.Titulo;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Alterar(TarefaViewModel model)
        {
            if (ModelState.IsValid)

            {
                try
                {
                    var tarefa = _tarefaRepository.GetById(model.TarefaId);

                    tarefa.Titulo = model.Titulo;

                    _tarefaRepository.Update(tarefa);

                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }


       
        public ActionResult Feito(int tarefaId)
        {
            if (ModelState.IsValid)

            {
                try
                {
                    var tarefa = _tarefaRepository.GetById(tarefaId);

                    tarefa.IsConcluido = true;

                    _tarefaRepository.Update(tarefa);

                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                    return View();
                }
                return RedirectToAction("Index");

            }
            return View();
        }

        
        public ActionResult Excluir(int tarefaId)
        {
            if (ModelState.IsValid)

            {
                var tarefa = _tarefaRepository.GetById(tarefaId);
                

                _tarefaRepository.Delete(tarefa);

                ViewBag.Mensagem = "Tarefa excluída com sucesso.";

                return RedirectToAction("Index");
            }
            return View();
        }
    }


}