using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GrupoController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public GrupoController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<Grupo>> Get(int id)
         {
            var clientes = await unitofwork.Grupos.GetByIdAsync(id);
            return Ok(clientes);
         }


         [HttpPost]
         [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public async Task<ActionResult<Grupo>> Post([FromBody] AddGrupoDto AddGrupoDto)
         {
            var Grupo = mapper.Map<Grupo>(AddGrupoDto);
             unitofwork.Grupos.Add(Grupo);
             
            await unitofwork.SaveAsync();
        
            if (Grupo == null){
                return BadRequest();
            }
            AddGrupoDto.Id = Grupo.Id;
            return CreatedAtAction(nameof(Post), new {id = AddGrupoDto.Id}, AddGrupoDto); 
         }

 


        

        

    }
}