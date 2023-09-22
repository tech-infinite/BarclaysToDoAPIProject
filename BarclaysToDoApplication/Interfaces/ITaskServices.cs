using BarclaysToDoApplication.Models;

namespace BarclaysToDoApplication.Interfaces
{
    public interface ITaskServices
    {
        List<TaskItems> GetTasks();
        void AddTask(TaskItems task);
        void EditTask(int taskId, TaskItems task);
        void DeleteCompletedTasks();
    }
}
