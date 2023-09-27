using BarclaysToDoApplication.Models;

namespace BarclaysToDoApplication
{
    public class ToDoActions
    {
        private readonly List<TaskItems> _items = new List<TaskItems>();

        private IEnumerable<TaskItems> GetTasks() 
        {
            return _items;
        }

        public void AddTask(TaskItems item) 
        {
            _items.Add(item);
        }

        public void UpdateTask(TaskItems item) 
        {
            var existingTask = _items.FirstOrDefault(x => x.TaskId == item.TaskId);

            if (existingTask != null) 
            {
                existingTask.TaskName = item.TaskName;
                existingTask.Priority = item.Priority;
                existingTask.Status = item.Status;
            }
        }

        public void DeleteTask(int Id) 
        {
            var taskToRemove = _items.FirstOrDefault(x => x.TaskId == Id);
            if (taskToRemove != null) 
            {
                _items.Remove(taskToRemove);
            }
        }
    }
}
