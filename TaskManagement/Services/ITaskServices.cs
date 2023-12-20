namespace TaskManagement.Services
{
    public interface ITaskServices
    {
        List<Models.Task> GetAllTasks();
        Models.Task GetSingleTask(Guid id);
        Task<Models.Task> AddTaskAsync(Models.Task task);
        bool DeleteTask(Guid id);
        Models.Task UpdateTask(Models.Task task);
    }
}
