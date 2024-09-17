
using loginMoviles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace loginMoviles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : Controller
    {
        private readonly ApplicationDbContext context;

        public DepartamentoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Departamento departamento)
        {
            var deptoExiste = await context.Departamentos.AnyAsync(x => x.Nombre == departamento.Nombre);
            if (deptoExiste)
                return BadRequest($"Departamento{departamento.Nombre} duplicado");
            context.Add(departamento);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id:int}", Name = "ObtenerDepartamento")]
        public async Task<ActionResult<Departamento>> GetObtenerDepartamento(int id)
        {
            var depto = await context.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (depto == null)
                return NotFound();

            return Ok(depto);
        }

        [HttpGet("ListarDepartamentos")]
        public async Task<ActionResult<List<Departamento>>> ListarDepartamentos()
        {
            var departamento = await context.Departamentos.ToListAsync();
            if (departamento == null)
                return NotFound();

            return Ok(departamento);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutModificarDepto(int id, Departamento departamento)
        {
            var deptoExiste = await context.Departamentos.FirstOrDefaultAsync(x=>x.Id == id);

            if (deptoExiste == null)
                return NotFound();


            deptoExiste.Nombre = departamento.Nombre;
            deptoExiste.Descripcion = departamento.Descripcion;

            //Automapper se utiliza para cuando son muchos atributos
            

            context.Update(departamento);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var eliminarDpto = context.Departamentos.FirstOrDefaultAsync(x => x.Id == id);

            if (eliminarDpto == null)
                return NotFound();

            context.Remove(eliminarDpto);
            await context.SaveChangesAsync();
            return NoContent();
            
        }
    }
}
