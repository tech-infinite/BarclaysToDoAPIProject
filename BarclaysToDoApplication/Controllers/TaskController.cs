using BarclaysToDoApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BarclaysToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        // To initalize the list to store tasks
        private List<TaskItems> tasks = new List<TaskItems>();
        private int nextTaskID = 1;


        // GET tasks from the list
        [HttpGet]
        public ActionResult GetTasks()
        {
            return Ok(tasks);
        }

        // POST api/task
        [HttpPost]
        public ActionResult AddTask(TaskItems task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.TaskName))
            {
                ModelState.AddModelError("TaskName", "Task Name is required.");
                return BadRequest(ModelState);
            }

            if (tasks.Any(t => t.TaskName.Equals(task.TaskName, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError("TaskName", "Task with the same name already exists.");
                return BadRequest(ModelState);
            }

            task.TaskId = nextTaskID++;
            tasks.Add(task);
            return CreatedAtRoute("DefaultApi", new { id = task.TaskId }, task);
        }

        // PUT request to edit an existing task
        [HttpPut]
        public ActionResult EditTask(int taskID, TaskItems task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.TaskName))
            {
                ModelState.AddModelError("TaskName", "Task Name is required.");
                return BadRequest(ModelState);
            }

            var existingTask = tasks.FirstOrDefault(t => t.TaskId == taskID);
            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.TaskName = task.TaskName;
            existingTask.IsTaskComplete = task.IsTaskComplete;
            return Ok(existingTask);
        }

        // DELETE task by it's ID
        [HttpDelete]
        public ActionResult DeleteTask(int taskID)
        {
            var taskToDelete = tasks.FirstOrDefault(t => t.TaskId == taskID);
            if (taskToDelete == null)
            {
                return NotFound();
            }

            tasks.Remove(taskToDelete);
            return Ok();
        }

        // Deletion of completed tasks
        public ActionResult DeleteCompletedTasks()
        {
            tasks.RemoveAll(t => t.IsTaskComplete);
            return Ok();
        }


    }
}
