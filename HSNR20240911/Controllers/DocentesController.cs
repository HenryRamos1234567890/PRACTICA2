using HSNR20240911.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HSNR20240911.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {
        //Declaracio de una lista estatica de objetos
        //"Docente" para almacenar docentes.
        static List<Docente> docentes = new List<Docente>();

        // Definicio de un metodo HTTP GET
        // Que devuelve una colocacion de docentes.
        [HttpGet]
        public IEnumerable<Docente> Get()
        {
            return docentes;
        }

        // Definicion de un metodo HTTP GET
        // Que recibe un ID como parametro y devuelve un docente especifico.
        [HttpGet("{id}")]
        public Docente Get(int id)
        {
            var docente = docentes.FirstOrDefault(x => x.Id == id);
            return docente;
        }

        // Definicion para metodo HTTP POST
        // Para agregar un nuevo docente a la lista.
        [HttpPost]
        public IActionResult Post([FromBody] Docente docente)
        {
            docentes.Add(docente);
            return Ok();
        }

        // Para actualizar un docente existente en la lista por su ID.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Docente docente)
        {
            var existingDocente = docentes.FirstOrDefault(x => x.Id == id); 
            if (existingDocente != null)
            {
                existingDocente.Nombre = docente.Nombre;
                existingDocente.Identificacion = docente.Identificacion;
                existingDocente.Especialidad = docente.Especialidad;
                existingDocente.Email = docente.Email;
                existingDocente.Telefono = docente.Telefono;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // Definicion de un  metedo HTTP DELETE
        // Para eliminar un docente por su ID.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingDocente = docentes.FirstOrDefault(x => x.Id == id);
            if (existingDocente != null)
            {
                docentes.Remove(existingDocente);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
