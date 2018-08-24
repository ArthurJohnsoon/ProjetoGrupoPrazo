using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Titulo { get; set; }
        public bool IsConcluido { get; set; }
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
        public Tarefa()
        {

        }

        public Tarefa(int idTarefa, string titulo, bool isConcluido)
        {
            TarefaId = idTarefa;
            Titulo = titulo;
            IsConcluido = isConcluido;
        }

        public override string ToString()
        {
            return $"Id: {TarefaId}, Título: {Titulo}, Está concluída: {(IsConcluido ? "Sim" : "Não")}";
        }
    }
}
