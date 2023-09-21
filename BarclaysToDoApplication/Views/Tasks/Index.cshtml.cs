using BarclaysToDoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarclaysToDoApplication.Views.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly List<TaskItems> _tasks = new List<TaskItems>
        {
            new TaskItems {TaskId = 1, TaskName = "Test 1", IsTaskComplete = false },
            new TaskItems {TaskId = 2, TaskName = "Test 2", IsTaskComplete = true },
        };

        public List<TaskItems> Tasks { get; set; }

        public void OnGet()
        {
            Tasks = _tasks;
        }
    }
}
