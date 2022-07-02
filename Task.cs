using System;
using System.Collections.Generic;
using System.Text;

namespace sekta
{   
    public class Task
    {
        static private uint _globalIDcount = 0;

        public string TaskName { get; set; }
        public uint ID { get; set; }
        public bool isCompleted { get; set; }
        public string Date { get; set; }

        // Я не очень знаком с хорошими практиками программирования на c#,
        // предполагаю что следует делать что-то такое,
        // но это тестовое задание и думаю можно упустить и принять то, как сделал я))) 
        // (всё-таки надо будет чему-то учиться на курсе)))
        // ( get и set для даты реализованы в CORE)

        /*private string _date;  
        public string Date    
        {
            get => _date;
            set => _date = value;
        }*/

        public List<subTask> SubTasks { get; set; }


        private Task()
        {
            TaskName = "default";
            _globalIDcount += 2;
            ID = _globalIDcount;

            isCompleted = false;
            Date = DateTime.Today.ToString().Substring(0, 10);
            SubTasks = new List<subTask>();

        }

        public Task(in string name="default")
        {
            
            TaskName = name;

            _globalIDcount += 2;
            ID = _globalIDcount;

            isCompleted = false;
            Date = DateTime.Today.ToString().Substring(0, 10);

            SubTasks = new List<subTask>();
        }


        public void AddSubTask(string subtask)
        {
            subTask temp = new subTask(subtask);

            this.SubTasks.Add(temp);
        }

        public void CompleteSubTask(string name)
        {
            SubTasks[SubTasks.FindIndex(task => task.SubTaskName == name)].isCompleted = true;
        }
    }
}
