using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaFaculdade.Models
{
    public class Professor
    {
        [Key]
        public int IDProfessor { get; set; }
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public int IDDisciplina { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Salario { get; set; }

        public virtual Disciplina Disciplina { get; set; }
    }
}