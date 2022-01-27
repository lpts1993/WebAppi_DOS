using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1_DOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DOSController : ControllerBase
    {
      
        private readonly DataContext _context;

        //conectar con la base de datos
        public DOSController(DataContext context) {
            _context = context;
        }



        //mostrar los datos
        [HttpGet]
        public async Task<ActionResult<List<paginados>>> Get() {
           
            return Ok(await _context.datapaginados.ToListAsync());
        }

        //buscar datos POR EL ID
        [HttpGet("{id}")]
        public async Task<ActionResult<paginados>> Get(int id)
        {
            var dosdato2 = await _context.datapaginados.FindAsync(id);
            if (dosdato2 == null)
                return BadRequest("dato no EXISTE");
                return Ok(dosdato2);
        }



        //agregar nuevo dato
        [HttpPost]
        public async Task<ActionResult<List<paginados>>> Adddoso(paginados dosdato2)
        {
            _context.datapaginados.Add(dosdato2);
            await _context.SaveChangesAsync(); 
            return Ok(await _context.datapaginados.ToListAsync());
        }

        //editar
        [HttpPut]
        public async Task<ActionResult<List<paginados>>> Updatedoso(paginados request)
        {
            var db = await _context.datapaginados.FindAsync(request.id);
            if (db == null)
                return BadRequest("dato no EXISTE");
            db.PrimerNombre = request.PrimerNombre;
            db.SegundoNombre = request.SegundoNombre;
            db.Apellido = request.Apellido;
            db.Lugar = request.Lugar;
            await _context.SaveChangesAsync();
            return Ok(await _context.datapaginados.ToListAsync());
        }

        //eliminar dato
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<paginados>>> Delete(int id)
        {
            var db2 = await _context.datapaginados.FindAsync(id);
            if (db2 == null)
                return BadRequest("dato no EXISTE");
            

            _context.datapaginados.Remove(db2);
            await _context.SaveChangesAsync();
            return Ok(await _context.datapaginados.ToListAsync());
        }




    }
}
