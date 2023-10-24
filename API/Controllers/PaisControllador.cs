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
    public class PaisController : BaseApiController
    {
        private IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitofwork = unitOfWork;
            this.mapper = Mapper;
        }
        
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PaisDto>>> Get([FromQuery]Params PaisParams)
        {
        var Pais = await unitofwork.Paises.GetAllAsync(PaisParams.PageIndex,PaisParams.PageSize, PaisParams.Search,"NombrePais");
        var listaPaiss= mapper.Map<List<PaisDto>>(Pais.registros);
        return new Pager<PaisDto>(listaPaiss, Pais.totalRegistros,PaisParams.PageIndex,PaisParams.PageSize,PaisParams.Search);
        }


         [HttpPost]
         [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public async Task<ActionResult<Pais>> Post([FromBody] Pais AddPaisDto)
         {
            var Pais = mapper.Map<Pais>(AddPaisDto);
             unitofwork.Paises.Add(Pais);
             
            await unitofwork.SaveAsync();
        
            if (Pais == null){
                return BadRequest();
            }
            AddPaisDto.Id = Pais.Id;
            return CreatedAtAction(nameof(Post), new {id = AddPaisDto.Id}, AddPaisDto); 
         }

 


        

        

    }
}