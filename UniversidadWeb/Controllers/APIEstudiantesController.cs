using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadWeb.Data;
using UniversidadWeb.Models;

namespace UniversidadWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIEstudiantesController : ControllerBase
    {
        private readonly UniversidadDbContext _context;

        public APIEstudiantesController(UniversidadDbContext context)
        {
            _context = context;
        }

        // GET: api/APIEstudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Universidad>>> GetEstudiante()
        {
            return await _context.Estudiante.ToListAsync();
        }

        // GET: api/APIEstudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Universidad>> GetUniversidad(int id)
        {
            var universidad = await _context.Estudiante.FindAsync(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/APIEstudiantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversidad(int id, Universidad universidad)
        {
            if (id != universidad.EstudianteId)
            {
                return BadRequest();
            }

            _context.Entry(universidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversidadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/APIEstudiantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Universidad>> PostUniversidad(Universidad universidad)
        {
            _context.Estudiante.Add(universidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversidad", new { id = universidad.EstudianteId }, universidad);
        }

        // DELETE: api/APIEstudiantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversidad(int id)
        {
            var universidad = await _context.Estudiante.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();
            }

            _context.Estudiante.Remove(universidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversidadExists(int id)
        {
            return _context.Estudiante.Any(e => e.EstudianteId == id);
        }

        public class Parametros
        {
            public int Inicial { get; set; }
            public int Final { get; set; }
        }
        public class Respuesta
        {
            public int aleatorio { get; set; }
        }

        public class RespuestaLetra
        {
            public char letraAleatoria { get; set; }
        }


        [HttpGet]
        [Route("Random")]
        public Respuesta Aleatorio()
        {
            Respuesta respuesta = new Respuesta();
            Random numeroAleatorio = new Random();
            respuesta.aleatorio = numeroAleatorio.Next(0, 101);
            return respuesta;
        }

        [HttpPost]
        [Route("Randomconparametros")]
        public Respuesta AleatoriotConRago([FromBody] Parametros numeros)
        {

            Respuesta respuesta = new Respuesta();
            Random r = new Random();
            respuesta.aleatorio = (r.Next(numeros.Inicial, (numeros.Final + 1)));

            return respuesta;
        }

        [HttpGet]
        [Route("Randomletras")]
        public RespuestaLetra letra()
        {
            RespuestaLetra respuesta = new RespuestaLetra();
            Random r = new Random();
            int numero = r.Next(26);
            char letraGenerada = (char)(((int)'A') + numero);
            respuesta.letraAleatoria = letraGenerada;
            return respuesta;
        }




    }
}
