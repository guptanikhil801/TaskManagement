
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
        public async Task<Models.Task> AddTaskAsync(Models.Task task)
        {
            await context.Tasks.AddAsync(task);
            if (context.SaveChanges() == 1)
            {
                return context.Tasks.LastOrDefault();
            }
            return new Models.Task { };
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

        public Models.Task GetSingleTask(Guid id)
        {
            return context.Tasks.SingleOrDefault(task => task.ID == id);
        }

        public Models.Task UpdateTask(Models.Task task)
        {
            var isTaskExist = context.Tasks.Any(option => option.ID == task.ID);
            if (isTaskExist)
            {
                context.Update(task);
                context.SaveChanges();
                return context.Tasks.SingleOrDefault(option => option.ID == task.ID);
            }
            return new Models.Task { };
        }
    }
}
