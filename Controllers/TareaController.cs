using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/tarea")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITarea _servicesTarea;
        public TareaController(ITarea servicesTarea) { _servicesTarea = servicesTarea; }

        [HttpGet("TAREA")]
        public async Task<ActionResult<ServiceResponse<List<Tarea>>>> GetAllTarea()
        {
            return await _servicesTarea.GetAllTarea();
        }

        [HttpGet("TAREA/{id_tarea}")]
        public async Task<ActionResult<ServiceResponse<Tarea>>> GetTarea(int id_tarea)
        {
            return await _servicesTarea.GetTarea(id_tarea);
        }

        [HttpPost("TAREA")]
        public async Task<ActionResult<ServiceResponse<Tarea>>> SaveTarea([FromBody]Tarea tarea)
        {
            return await _servicesTarea.SaveTarea(tarea);
        }

         [HttpDelete("TAREA/{id_tarea}")]
        public async Task<ActionResult<ServiceResponse<Tarea>>> DeleteTarea(int id_tarea)
        {
            return await _servicesTarea.DeleteTarea(id_tarea);
        }
    }
}
