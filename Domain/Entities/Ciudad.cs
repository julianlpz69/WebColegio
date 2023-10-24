using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ciudad : BaseEntity
    {
        public string NombreCiudad {get; set;}
        public int IdDepartamentoFK {get; set;}
        public Departamento Departamento {get; set;}
        public ICollection<Direccion> Direcciones {get; set;}
    }
}