using Microsoft.EntityFrameworkCore;

namespace TaskMenager.Models
{
    public class DbTaskContext : DbContext
    {
        public DbTaskContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
