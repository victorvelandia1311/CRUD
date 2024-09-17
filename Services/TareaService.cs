using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services
{
    public interface ITarea
    {
        Task<ServiceResponse<List<Tarea>>> GetAllTarea();
        Task<ServiceResponse<Tarea>> GetTarea(int id_tarea);
        Task<ServiceResponse<Tarea>> SaveTarea(Tarea tarea);
        Task<ServiceResponse<Tarea>> DeleteTarea(int id_tarea);
    }

    public class TareaService : ITarea
    {
        private readonly DataContext _context;
        public TareaService(DataContext context) { _context = context; }

        public async Task<ServiceResponse<List<Tarea>>> GetAllTarea()
        {
            ServiceResponse<List<Tarea>> response = new();
            try
            {
                var db_tarea = await _context.Tareas.ToListAsync();
                {
                    if (db_tarea == null)
                    {
                        response.Success = false;
                        response.Message = $"No hay tareas";
                        return response;
                    }
                    response.Success = true;
                    response.Message = "Datos recuperados correctamente";
                    response.Data = db_tarea;

                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ocurrió un error al consultar datos.";
                response.Error = $"Exception -> {ex}";
            }
            return response;
        }

        public async Task<ServiceResponse<Tarea>> GetTarea(int id_tarea)
        {
            ServiceResponse<Tarea> response = new();
            try
            {
                var db_tarea = await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id_tarea);
                {
                    if (db_tarea == null)
                    {
                        response.Success = false;
                        response.Message = $"No existe una tarea con ese id {db_tarea.Id}";
                        return response;
                    }
                    response.Success = true;
                    response.Message = "Dato recuperado correctamente";
                    response.Data = db_tarea;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ocurrió un error al consultar datos.";
                response.Error = $"Exception -> {ex}";
            }
            return response;
        }

        public async Task<ServiceResponse<Tarea>> SaveTarea(Tarea tarea)
        {
            ServiceResponse<Tarea> response = new();
            try
            {
                var db_tarea = await _context.Tareas.FirstOrDefaultAsync(t => t.Id == tarea.Id);
                {
                    if (db_tarea != null)
                    {
                        response.Success = false;
                        response.Message = $"Ya existe una tarea con ese id {tarea.Id}";
                        return response;
                    }
                }

                _context.Tareas.Add(tarea);
                await _context.SaveChangesAsync();

                response.Message = $"Tarea guardada correctamente.";
                response.Success = true;
                response.Data = db_tarea;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ocurrio un error al guardar la tarea";
                response.Error = $"Exception -> {ex}";
            }
            return response;

        }
        
        public async Task<ServiceResponse<Tarea>> DeleteTarea(int id_tarea)
        {
            ServiceResponse<Tarea> response = new();

            try
            {
                // Busca la tarea por su ID
                var db_tarea = await _context.Tareas.FirstOrDefaultAsync(x => x.Id == id_tarea);

                // Verifica si la tarea existe
                if (db_tarea == null)
                {
                    response.Success = false;
                    response.Message = $"No existe una tarea con el ID {id_tarea}";
                    return response;
                }

                // Elimina la tarea
                _context.Tareas.Remove(db_tarea);
                await _context.SaveChangesAsync();

                // Configura la respuesta
                response.Message = $"La tarea con ID {db_tarea.Id} ha sido eliminada.";
                response.Data = db_tarea;
                response.Success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception -> {ex}");
                response.Success = false;
                response.Message = "Ocurrió un error al eliminar la tarea.";
                response.Error = $"Exception -> {ex}";
            }

            return response;
        }

    }
}
