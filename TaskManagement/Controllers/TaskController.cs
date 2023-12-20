using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices taskService;
        public TaskController(ITaskServices taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("getAllTasks")]
        public IActionResult GetAllTasks()
        {
            var allTasks = taskService.GetAllTasks();
            return (allTasks.Count == 0) ? NoContent() : Ok(allTasks);
        }

        [HttpPost("addTask")]
        public async Task<IActionResult> AddTask(Models.Task task)
        {
            var newlyAddedTask = await taskService.AddTaskAsync(task);
            if (!ModelState.IsValid || newlyAddedTask == null)
            {
                return BadRequest(false);
            }

            return Ok(newlyAddedTask);
        }

        [HttpDelete("deleteTask")]
        public IActionResult DeleteTask(Guid id)
        {
            if (!taskService.DeleteTask(id))
            {
                return NotFound();
            }

            return Ok("Task deleted successfully.");
        }

        [HttpGet("getSingleTask/{id}")]
        public IActionResult GetSingleTask(Guid id)
        {
            var task = taskService.GetSingleTask(id);
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        [HttpPut("updateTask")]
        public IActionResult UpdateTask(Models.Task task)
        {
            var updatedTask = taskService.UpdateTask(task);
            if (updatedTask == null)
            {
                return NotFound(); ;
            }
            return Ok(updatedTask);
        }
    }
}
