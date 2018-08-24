using Projeto.Entities;
using Projeto.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Repositories
{
    public class TarefaRepository
    {
        protected readonly DataContext db;

        public TarefaRepository()
        {
            db = new DataContext();
        }

        public void Insert(Tarefa tarefa)
        {
            db.Tarefas.Add(tarefa);
            db.SaveChanges();
        }
        public void Delete(Tarefa tarefa)
        {
            db.Tarefas.Remove(tarefa);
            db.SaveChanges();
        }
        public void Update(Tarefa tarefa)
        {
            db.Entry(tarefa).State = EntityState.Modified;
            db.SaveChanges();
        }
        public List<Tarefa> GetAll()
        {
            return db.Tarefas.ToList();
        }

        public List<Tarefa> GetByUsuario(int usuarioId)
        {
            return db.Tarefas.Where(x => x.Usuario.UsuarioId == usuarioId).ToList();
        }

        public Tarefa GetById(int TarefaId)
        {
            return db.Tarefas.Find(TarefaId);
        }
    }
}
