using System;
using TaskManagerApp.Core; // Użyj tej samej przestrzeni nazw

namespace TaskManagerApp // Zmień na inną nazwę, aby uniknąć konfliktu
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager(); // Ta linia powinna teraz działać
            bool running = true;

            while (running)
            {
                Console.WriteLine("Task Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Complete Task");
                Console.WriteLine("4. Remove Task");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter due date (yyyy-mm-dd): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());
                        taskManager.AddTask(title, description, dueDate);
                        break;
                    case "2":
                        var tasks = taskManager.GetTasks();
                        foreach (var task in tasks)
                        {
                            Console.WriteLine($"[{(task.IsCompleted ? "X" : " ")}] {task.Id}: {task.Title} - {task.Description} (Due: {task.DueDate.ToShortDateString()})");
                        }
                        break;
                    case "3":
                        Console.Write("Enter task ID to complete: ");
                        int completeId = int.Parse(Console.ReadLine());
                        taskManager.CompleteTask(completeId);
                        break;
                    case "4":
                        Console.Write("Enter task ID to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        taskManager.RemoveTask(removeId);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
