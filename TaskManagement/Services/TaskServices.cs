
using PracticeWebApi.Contexts;

namespace TaskManagement.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ApplicationDBContext context;
        public TaskServices(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddTaskAsync(Models.Task task)
        {
            await context.Tasks.AddAsync(task);
            return context.SaveChanges() == 1;
        }

        public bool DeleteTask(Guid id)
        {
            var task = context.Tasks.SingleOrDefault(option => option.ID == id);
            if (task != null)
            {
                context.Tasks.Remove(task);
                return context.SaveChanges() == 1;
            }
            return false;
        }

        public List<Models.Task> GetAllTasks()
        {
            return context.Tasks.ToList();
        }

        public Models.Task GetTask(Guid id)
        {
            return context.Tasks.SingleOrDefault(task => task.ID == id);
        }

        public bool UpdateTask(Models.Task task)
        {
            var isTaskExist = context.Tasks.Any(option => option.ID == task.ID);
            if (isTaskExist)
            {
                context.Update(task);
                return context.SaveChanges() == 1;
            }
            return false;
        }
    }
}
