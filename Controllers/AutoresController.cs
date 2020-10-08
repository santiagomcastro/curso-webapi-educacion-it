using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Contexto;
using BibliotecaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        readonly ApplicationDBContext _context;

        public AutoresController(ApplicationDBContext dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Devuelve todos los Autores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> Get() => await _context.Autores.ToListAsync();

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public async Task<ActionResult<Autor>> Get(int id)
        {

            Autor autorSearch = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == id);
            
            if (autorSearch == null) return NotFound();

            return autorSearch;
        }

        [HttpPost]
        public async Task<ActionResult<Autor>> Post([FromBody] Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return await Task.FromResult(Ok(autor));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Autor value)
        {
            if(id != value.Id)
            {
                return await Task.FromResult(BadRequest());
            }
            _context.Entry(value).State = EntityState.Modified;
            _context.SaveChanges();

            return await Task.FromResult(Ok());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Autor>> Delete(int id)
        {
            Autor autorDelete = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == id);

            if (autorDelete == null) return await Task.FromResult(NotFound());

            _context.Autores.Remove(autorDelete);
            _context.SaveChanges();

            return await Task.FromResult(autorDelete);
        }
    }
}