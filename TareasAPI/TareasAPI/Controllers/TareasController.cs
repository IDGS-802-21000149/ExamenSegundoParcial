using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasAPI.Models;

namespace TareasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {

        //Crear varariable de contexto de la base de datos
        private readonly BdtareasContext _baseDatos;

        //Constructor
        public TareasController(BdtareasContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        //Get para obtener todas las tareas de la base de datos
        [HttpGet]
        [Route("ListaTareas")]
        public async Task<IActionResult> Lista()
        {
            var listaTareas = await _baseDatos.Tareas.ToListAsync();
            return Ok(listaTareas);
        }

        //Post para agregar una tarea a la base de datos
        [HttpPost]
        [Route("AgregarTarea")]
        public async Task<IActionResult> AgregarTarea(Tarea tarea)
        {
            _baseDatos.Tareas.Add(tarea);
            await _baseDatos.SaveChangesAsync();
            return Ok();
        }

        //put para modificar una tarea de la base de datos
        [HttpPut]
        [Route("ModificarTarea/{id:int}")]
        public async Task<IActionResult> ModificarTarea(int id, [FromBody] Tarea request)
        {
            var tarea = await _baseDatos.Tareas.FindAsync(id);

            if (tarea == null)
            {
              
                return BadRequest("No se encontro la tarea");
            }
            tarea.Nombre = request.Nombre;

           try
            {
                await _baseDatos.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
            
        }

        //Delete para eliminar una tarea de la base de datos
        [HttpDelete]
        [Route("EliminarTarea/{id:int}")]
        public async Task<IActionResult> EliminarTarea(int id)
        {
            var tarea = await _baseDatos.Tareas.FindAsync(id);

            if (tarea == null)
            {

                return BadRequest("No se encontro la tarea");
            }
           _baseDatos.Tareas.Remove(tarea);
            await _baseDatos.SaveChangesAsync();
          
            return Ok();

        }

        //get para obtner tareas por categoria
        [HttpGet]
        [Route("TareasPorCategoria/{categoria}")]
        public async Task<IActionResult> TareasPorCategoria(string categoria)
        {
            var listaTareas = await _baseDatos.Tareas.Where(x => x.categoria == categoria).ToListAsync();
            return Ok(listaTareas);
        }


    }
}
