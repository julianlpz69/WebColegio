using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;

    public class UnitOfWork : IUnitOfWork
    {

        private readonly ColegioDBContext _context; 
        
        private IRol _roles;
        private IUsuario _usuario;
        private IEstudiante _estudiante;
        private IGrupo _Grupo;
        private IPais _Pais;
        


        public UnitOfWork(ColegioDBContext context){
            _context = context;
        }

    
        
        public IRol Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }


        public IUsuario Usuarios
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new UsuarioRepository(_context);
                }
                return _usuario;
            }
        }

        public IGrupo Grupos
        {
            get
            {
                if (_Grupo == null)
                {
                    _Grupo = new GrupoRepository(_context);
                }
                return _Grupo;
            }
        }

        public IEstudiante Estudiantes
        {
            get
            {
                if (_estudiante == null)
                {
                    _estudiante = new EstudianteRepository(_context);
                }
                return _estudiante;
            }
        }


        public IPais Paises
        {
            get
            {
                if (_Pais == null)
                {
                    _Pais = new PaisRepository(_context);
                }
                return _Pais;
            }
        }



        

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }