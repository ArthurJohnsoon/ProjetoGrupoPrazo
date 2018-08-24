using Projeto.Entities;
using Projeto.Repository.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projeto.Repository.Repositories
{
    public class UsuarioRepository
    {
        protected readonly DataContext db;

        public UsuarioRepository()
        {
            db = new DataContext();
        }

        public void Insert(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
        public void Delete(Usuario usuario)
        {
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
        }
        public void Update(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }
        public List<Usuario> GetAll()
        {
            return db.Usuarios.ToList();
        }
        public Usuario GetById(int IdUsuario)
        {
            return db.Usuarios.Find(IdUsuario);
        }
        public Usuario GetLogin(string login, string senha)
        {
            return db.Usuarios.Where(p => p.Login == login && 
                                          p.Senha == senha)
                                          .FirstOrDefault();
        }
        public Usuario GetLogin(string login)
        {
            return db.Usuarios.Where(p => p.Login == login)
                                          .FirstOrDefault();
        }

    }
}
