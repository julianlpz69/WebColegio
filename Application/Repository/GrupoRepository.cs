using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class GrupoRepository : GenericRepository<Grupo>, IGrupo
    {
        private readonly ColegioDBContext _context;

        public GrupoRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }
    }
}