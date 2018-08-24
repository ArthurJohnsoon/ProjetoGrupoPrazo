using System.Data.Entity;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Projeto.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("Projeto")
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));


            modelBuilder.Entity<Tarefa>().HasRequired(x => x.Usuario)
                                         .WithMany(x => x.Tarefas)
                                         .HasForeignKey(x=>x.IdUsuario);
        }

    }
}
