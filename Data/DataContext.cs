using Microsoft.EntityFrameworkCore;
using CRUD.Models;



namespace CRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<Tarea> Tareas => Set<Tarea>();
    }
}
