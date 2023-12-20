namespace TaskManagement.Services
{
    public interface ITaskServices
    {
        List<Models.Task> GetAllTasks();
        Models.Task GetTask(Guid id);
        Task<bool> AddTaskAsync(Models.Task task);
        bool DeleteTask(Guid id);
        bool UpdateTask(Models.Task task);
    }
}
