using BarclaysToDoApplication.Interfaces;
using BarclaysToDoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BarclaysToDoApplication.Tests
{
    public class TaskControllerTests
    {
        [Fact]
        public void AddTask_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var taskServiceMock = new Mock<ITaskServices>();
            var controller = new TaskController(taskServiceMock.Object);
            var taskToAdd = new TaskItems { TaskName = "New Task" };

            // Act
            var result = controller.AddTask(taskToAdd) as RedirectToActionResult;

            // Assert
            taskServiceMock.Verify(service => service.AddTask(It.IsAny<TaskItems>()), Times.Once);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void EditTask_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var taskServiceMock = new Mock<ITaskServices>();
            var controller = new TaskController(taskServiceMock.Object);
            var taskToEdit = new TaskItems { TaskId = 1, TaskName = "Updated Task" };

            // Act
            var result = controller.EditTask(1, taskToEdit) as RedirectToActionResult;

            // Assert
            taskServiceMock.Verify(service => service.EditTask(It.IsAny<int>(), It.IsAny<TaskItems>()), Times.Once);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void DeleteCompletedTasks_ReturnsRedirectToActionResult()
        {
            // Arrange
            var taskServiceMock = new Mock<ITaskServices>();
            var controller = new TaskController(taskServiceMock.Object);

            // Act
            var result = controller.DeleteCompletedTasks() as RedirectToActionResult;

            // Assert
            taskServiceMock.Verify(service => service.DeleteCompletedTasks(), Times.Once);
            Assert.Equal("Index", result.ActionName);
        }
    }
}
