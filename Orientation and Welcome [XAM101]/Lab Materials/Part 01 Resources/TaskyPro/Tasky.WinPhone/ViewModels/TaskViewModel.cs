﻿using Tasky.Core;

namespace TaskyPro
{
    public class TaskViewModel : ViewModelBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    
        public TaskViewModel ()
        {
        }
        public TaskViewModel (TodoTask item)
        {
            Update (item);
        }

        public void Update (TodoTask item)
        {
            ID = item.ID;
            Name = item.Name;
            Notes = item.Notes;
            Done = item.Done;
        }

        public TodoTask GetTask()
        {
            return new TodoTask {
                ID = this.ID,
                Name = this.Name,
                Notes = this.Notes,
                Done = this.Done
            };
        }
    }
}
