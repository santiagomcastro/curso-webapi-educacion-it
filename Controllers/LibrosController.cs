using BibliotecaApi.Contexto;
using BibliotecaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        readonly ApplicationDBContext _context;

        public LibrosController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> Get() => await _context.Libros.Include(libro => libro.Autor).ToListAsync();

        [HttpGet]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            Libro libroSearch = await _context.Libros.Include(libro => libro.Autor).FirstOrDefaultAsync(libro => libro.Id == id);

            if (libroSearch == null) return await Task.FromResult(NotFound());

            return await Task.FromResult(Ok(libroSearch));
        }

        [HttpPost]
        public async Task<ActionResult<Libro>> Post([FromBody] Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();

            return await Task.FromResult(Ok(libro));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Libro libro)
        {
            _context.Entry(libro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await Task.FromResult(Ok());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Libro>> Delete(int id)
        {
            Libro libroToDelete = await _context.Libros.FirstOrDefaultAsync(libro => libro.Id == id);

            if (libroToDelete == null) return await Task.FromResult(NotFound(libroToDelete));

            _context.Libros.Remove(libroToDelete);
            await _context.SaveChangesAsync();


            return await Task.FromResult(Ok(libroToDelete));
        }
    }
}
