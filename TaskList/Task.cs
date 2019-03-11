using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }

        public void MarkComplete()
        {
            IsComplete = true;
        }

        public string Print()
        {
            string formatTask = $"{IsComplete} \t {DueDate} \t {Name} \t\t {Description}";
            return formatTask;
        }
        public string Print(int index)
        {
            string formatTask = $"{index}. \t {IsComplete} \t {DueDate} \t {Name} \t\t {Description}";
            return formatTask;
        }
        public string PrintToFile()
        {
            string formatTask = $"{Name};{Description};{IsComplete};{DueDate}";
            return formatTask;
        }

        public Task(string name, string description, DateTime dueDate)
        {
            Name = name;
            Description = description;
            DueDate = dueDate;
            IsComplete = false;
        }
        public Task(string name, string description, DateTime dueDate, bool isComplete)
        {
            Name = name;
            Description = description;
            DueDate = dueDate;
            IsComplete = isComplete;
        }
    }
}
