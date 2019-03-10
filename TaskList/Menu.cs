using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    class Menu
    {
        static bool ReturnToMenu = true;
        public static List<Task> TaskList;

        static Task GetTask()
        {
            // prompt user
            Console.Write("Enter Task Number: ");
            int index = Input.ValidInt(1, TaskList.Count);

            // display task
            Task task = TaskList[index - 1];
            task.Print(index);

            return task;
        }

        public static void MainMenu()
        {
            TaskList = new List<Task>();
            Console.WriteLine("Welcome to the Task Manager!");

            while (ReturnToMenu)
            {

                Console.WriteLine("\n1. List Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Mark Task Complete");
                Console.WriteLine("5. Save + Quit");

                Console.Write("Enter an integer between 1 and 5: ");
                switch (Input.ValidInt(1, 5))
                {
                    case 1:
                        ListTasks();
                        break;
                    case 2:
                        AddTask();
                        break;
                    case 3:
                        DeleteTask();
                        break;
                    case 4:
                        MarkTaskComplete();
                        break;
                    case 5:
                        SaveQuit();
                        break;
                }
            }
        }

        public static void ListTasks()
        {
            if(TaskList.Count == 0)
            {
                Console.WriteLine("Your task list is empty.");
            }
            else
            {
                int index = 1;
                Console.WriteLine("\nLIST TASKS");

                // list all tasks
                Console.WriteLine("# \t Done? \t Due Date \t Team Member \t Description \n");
                foreach (Task task in TaskList)
                {
                    Console.WriteLine(task.Print(index));
                    index++;
                }
            }
        }
        public static void AddTask()
        {
            Console.WriteLine("\nADD TASK");
            string name, description;
            DateTime dueDate;

            // prompt user
            Console.Write("Enter Team Member Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Task Description: ");
            description = Console.ReadLine();
            Console.Write("Enter Due Date (mm/dd/yyyy): ");
            dueDate = Input.ValidDate();

            // add task
            Task task = new Task(name, description, dueDate);
            TaskList.Add(task);

            Console.WriteLine("Task entered successfully!");
        }
        public static void DeleteTask()
        {
            Console.WriteLine("\nDELETE TASK");

            Task task = GetTask();

            // delete y/n
            Console.Write("Are you sure you want to delete? (y/n): ");
            if (Input.YesOrNo())
            {
                TaskList.Remove(task);
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Operation aborted.");
            }

        }
        public static void MarkTaskComplete()
        {
            Console.WriteLine("\nMARK TASK COMPLETE");

            Task task = GetTask();

            // complete y/n
            Console.Write("Are you sure you want to mark this task complete? (y/n): ");
            if (Input.YesOrNo())
            {
                task.MarkComplete();
                Console.WriteLine("Task Completed Successfully!");
            }
            else
            {
                Console.WriteLine("Operation aborted.");
            }
        }
        public static void SaveQuit()
        {
            Console.Write("Are you sure you want to quit? (y/n): ");
            if (Input.YesOrNo())
            {
                ReturnToMenu = false;
            }
        }
    }
}
