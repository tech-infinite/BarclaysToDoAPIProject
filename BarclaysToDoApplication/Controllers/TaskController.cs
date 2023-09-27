using BarclaysToDoApplication.Interfaces;
using BarclaysToDoApplication.Models;
using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly List<TaskItems> _todoItems = new List<TaskItems>();

        [HttpGet]
        public IEnumerable<TaskItems> Get()
        {
            return _todoItems;
        }

        [HttpPost]
        public IActionResult Post(TaskItems item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (_todoItems.Any(x => x.TaskName == item.TaskName))
            {
                return Conflict();
            }

            _todoItems.Add(item);

            return CreatedAtAction(nameof(Get), new { id = item.TaskId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TaskItems item)
        {
            if (item == null || id != item.TaskId)
            {
                return BadRequest();
            }

            var existingItem = _todoItems.FirstOrDefault(x => x.TaskId == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.TaskName = item.TaskName;
            existingItem.Priority = item.Priority;
            existingItem.Status = item.Status;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var itemToRemove = _todoItems.FirstOrDefault(x => x.TaskId == id);

            if (itemToRemove == null)
            {
                return NotFound();
            }

            if (itemToRemove.Status != "completed")
            {
                return BadRequest();
            }

            _todoItems.Remove(itemToRemove);

            return NoContent();
        }
    }



