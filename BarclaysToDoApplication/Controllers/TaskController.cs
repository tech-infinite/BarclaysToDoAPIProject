using BarclaysToDoApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace BarclaysToDoApplication.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        // To initalize the list to store tasks
        private List<TaskItems> tasks = new List<TaskItems>();
        private int nextTaskID = 1;


        // GET tasks from the list
        [System.Web.Http.HttpGet]
        public ActionResult GetTasks()
        {
            return Ok(tasks);
        }

        // POST api/task
        [System.Web.Http.HttpPost]
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
        [System.Web.Http.HttpPut]
        public ActionResult EditTask(int id, TaskItems task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.TaskName))
            {
                ModelState.AddModelError("TaskName", "Task Name is required.");
                return BadRequest(ModelState);
            }

            var existingTask = tasks.FirstOrDefault(t => t.TaskId == id);
            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.TaskName = task.TaskName;
            existingTask.IsTaskComplete = task.IsTaskComplete;
            return Ok(existingTask);
        }

        // DELETE 
        [System.Web.Http.HttpDelete]
        public ActionResult DeleteTask(int id)
        {
            var taskToDelete = tasks.FirstOrDefault(t => t.TaskId == id);
            if (taskToDelete == null)
            {
                return NotFound();
            }

            tasks.Remove(taskToDelete);
            return Ok();
        }

        // Verify deletion of completed tasks
        public ActionResult DeleteCompletedTasks()
        {
            tasks.RemoveAll(t => t.IsTaskComplete);
            return Ok();
        }


    }
}
