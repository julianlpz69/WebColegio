using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        private readonly ColegioDBContext _context;

        public PaisRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Pais>> PaisesDepCiudades()
        {
            var Paises =await _context.Paises
                .Include(pais => pais.Departamentos)
                    .ThenInclude(Departamento => Departamento.Ciudades)
                .ToListAsync();

            return Paises;
        }

    }
}