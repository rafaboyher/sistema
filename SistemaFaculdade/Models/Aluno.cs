using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaFaculdade.Models
{
    public class Aluno
    {
        [Key]
        public int IDAluno { get; set; }
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public int IDCurso { get; set; }
        public decimal MediaNota { get; set; }

        public virtual Curso Curso { get; set; }
    }
}