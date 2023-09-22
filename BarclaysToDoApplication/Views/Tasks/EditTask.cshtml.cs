using BarclaysToDoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarclaysToDoApplication.Views.Tasks
{
    public class EditTaskModel : PageModel
    {
        [BindProperty]
        public TaskItems Task { get; set; }

        public IActionResult OnGet()
        {
            // Load task data from a database or another source based on TaskId
            Task = new TaskItems { TaskId = 1, TaskName = "Task test", IsTaskComplete = false };

            if (Task == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the task in your data source here

            return RedirectToPage("./Index");
        }
    }
    
}
