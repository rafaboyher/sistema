using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaFaculdade.Models
{
    public class Curso
    {
        [Key]
        public int IDCurso { get; set; }
        public string Descricao { get; set; }
        
        public virtual ICollection<Aluno> Aluno { get; set; }
    }
}