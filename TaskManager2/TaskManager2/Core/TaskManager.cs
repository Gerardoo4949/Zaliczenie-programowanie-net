using System; // To jest potrzebne dla DateTime
using System.Collections.Generic; // To jest potrzebne dla List<>
namespace TaskManagerApp.Core // Zmiana na TaskManagerApp.Core
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int id, string title, string description, DateTime dueDate)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }
    }

    public class TaskManager // Klasa pozostaje bez zmian
    {
        private List<Task> tasks = new List<Task>();
        private int nextId = 1;

        public void AddTask(string title, string description, DateTime dueDate)
        {
            tasks.Add(new Task(nextId++, title, description, dueDate));
        }

        public List<Task> GetTasks()
        {
            return tasks;
        }

        public void CompleteTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

        public void RemoveTask(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
        }
    }
}
