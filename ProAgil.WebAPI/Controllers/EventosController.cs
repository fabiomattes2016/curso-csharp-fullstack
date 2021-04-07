﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;
using System;
using System.Threading.Tasks;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        public ProAgilContext _context { get; }

        public EventosController(ProAgilContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) // .ToList().FirstOrDefault(x => x.EventoId == id);
        {
            var result = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}