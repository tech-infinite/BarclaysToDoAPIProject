using BarclaysToDoApplication.Interfaces;
using BarclaysToDoApplication.Models;
using Microsoft.AspNetCore.Mvc;


public class TaskController : Controller
{
    private readonly ITaskServices _taskServices;

    public TaskController(ITaskServices taskService)
    {
        _taskServices = taskService;
    }

    // Other action methods...

    [HttpPost]
    public IActionResult AddTask(TaskItems task)
    {
        if (ModelState.IsValid)
        {
            _taskServices.AddTask(task); // Calls the AddTask method 
            return RedirectToAction("Index");
        }
        return View(task);
    }

    [HttpPost]
    public IActionResult EditTask(int id, TaskItems task)
    {
        if (ModelState.IsValid)
        {
            _taskServices.EditTask(id, task); // Calls the EditTask method of your service
            return RedirectToAction("Index");
        }
        return View(task);
    }

    [HttpDelete]
    public IActionResult DeleteCompletedTasks()
    {
        _taskServices.DeleteCompletedTasks(); // Call the DeleteCompletedTasks method of your service
        return RedirectToAction("Index");
    }
}


