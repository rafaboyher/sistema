using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaFaculdade.Models
{
    public class Disciplina
    {
        [Key]
        public int IDDisciplina { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Professor> Professor { get; set; }
    }
}