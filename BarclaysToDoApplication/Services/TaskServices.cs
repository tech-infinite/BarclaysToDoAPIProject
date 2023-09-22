using BarclaysToDoApplication.Interfaces;
using BarclaysToDoApplication.Models;

namespace BarclaysToDoApplication.Services
{
    public class TaskServices : ITaskServices
    {

        private readonly List<TaskItems> _tasks = new List<TaskItems>();
        private int _nextTaskId = 1;

        // returns a copy of the tasks list
        public List<TaskItems> GetTasks()
        {
            return _tasks.ToList();
        }

        // assigns a unique ID to the task and adds it to the list
        public void AddTask(TaskItems task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            // Assign a unique ID to the task
            task.TaskId = _nextTaskId++;
            _tasks.Add(task);
        }

        // edits an existing task.
        public void EditTask(int taskId, TaskItems task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            var existingTask = _tasks.FirstOrDefault(t => t.TaskId == taskId);
            
            if (existingTask == null)
            {
                throw new InvalidOperationException("Task not found.");
            }

            // Update task properties
            existingTask.TaskName = task.TaskName;
            existingTask.IsTaskComplete = task.IsTaskComplete;
        }

       
        // deletes completed tasks from the list
        public void DeleteCompletedTasks()
        {
            _tasks.RemoveAll(task => task.IsTaskComplete);
        }

    }   
}
