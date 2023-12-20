using Microsoft.EntityFrameworkCore;

namespace PracticeWebApi.Contexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<TaskManagement.Models.Task> Tasks { get; set; }
    }
}
