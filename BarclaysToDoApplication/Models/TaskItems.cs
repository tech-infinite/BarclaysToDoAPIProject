using System.ComponentModel.DataAnnotations;

namespace BarclaysToDoApplication.Models
{
    public class TaskItems
    {

        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task Name is required.")]
        [StringLength(100, ErrorMessage = "Task Name cannot exceed 100 characters.")]
        public string TaskName { get; set; }
        
        [Range(1, 5, ErrorMessage = "Priority must be between 1 and 5.")]
        public int Priority { get; set; }
        public string Status { get; set; }
    }
}
