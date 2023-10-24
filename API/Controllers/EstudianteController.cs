using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EstudianteController : BaseApiController
    {
        private IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public EstudianteController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitofwork = unitOfWork;
            this.mapper = Mapper;
        }




        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<AddEstudianteDto>>> Get([FromQuery]Params EstudianteParams)
        {
        var Estudiante = await unitofwork.Estudiantes.GetAllAsync(EstudianteParams.PageIndex,EstudianteParams.PageSize, EstudianteParams.Search,"NombreEstudiante");
        var listaEstudiantes= mapper.Map<List<AddEstudianteDto>>(Estudiante.registros);
        return new Pager<AddEstudianteDto>(listaEstudiantes, Estudiante.totalRegistros,EstudianteParams.PageIndex,EstudianteParams.PageSize,EstudianteParams.Search);
        }



         [HttpPost]
         [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public async Task<ActionResult<Estudiante>> Post([FromBody] AddEstudianteDto AddEstudianteDto)
         {
            var Estudiante = mapper.Map<Estudiante>(AddEstudianteDto);
        
             unitofwork.Estudiantes.Add(Estudiante);
             
            await unitofwork.SaveAsync();
        
            if (Estudiante == null){
                return BadRequest();
            }
            AddEstudianteDto.Id = Estudiante.Id;
            return CreatedAtAction(nameof(Post), new {id = AddEstudianteDto.Id}, AddEstudianteDto); 
         }

 


        

        

    }
}