using BarclaysToDoApplication.Interfaces;
using BarclaysToDoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarclaysToDoApplication.Views.Tasks
{
    public class CreateTaskModel : PageModel
    {
        private readonly ITaskServices _taskService;

        public CreateTaskModel(ITaskServices taskService)
        {
            _taskService = taskService;
        }

        [BindProperty]
        public TaskItems Task { get; set; }

        // return the page when initally requested
        public IActionResult OnGet()
        {
            return Page();
        }

        // executed when the form is submitted, checks if the model state is valid
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _taskService.AddTask(Task);
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it) and return an error page or message
                ModelState.AddModelError(string.Empty, "An error occurred while adding the task.");
                return Page();
            }
        }
    }
}
