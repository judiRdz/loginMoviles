
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

    }
}
