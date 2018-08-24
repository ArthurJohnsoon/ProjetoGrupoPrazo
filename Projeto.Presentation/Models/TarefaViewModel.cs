using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class TarefaViewModel
    {
        public int TarefaId { get; set; }
        [Required(ErrorMessage = "Informe o título.")]
        public string Titulo { get; set; }
        public bool IsConcluido { get; set; }
    }
}