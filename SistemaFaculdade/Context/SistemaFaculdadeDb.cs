using SistemaFaculdade.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaFaculdade.Context
{
    public class SistemaFaculdadeDb : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }

        public System.Data.Entity.DbSet<SistemaFaculdade.Models.Curso> Cursoes { get; set; }

        public System.Data.Entity.DbSet<SistemaFaculdade.Models.Disciplina> Disciplinas { get; set; }

        public System.Data.Entity.DbSet<SistemaFaculdade.Models.Professor> Professors { get; set; }

    }
}