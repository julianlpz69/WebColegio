using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class AddGrupoDto : BaseEntity
    {
        
        public string NombreGrupo {get; set;}
        public int IdGradoFK {get; set;}
        public Grado Grado {get; set;}
    }
}