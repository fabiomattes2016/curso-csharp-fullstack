using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        public DataContext _context { get; }

        public EventosController(DataContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            return _context.Eventos.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            return _context.Eventos.ToList().FirstOrDefault(x => x.EventoId == id);
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
