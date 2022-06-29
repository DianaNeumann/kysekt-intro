using System;
using System.Collections.Generic;
using System.Text;

namespace sekta
{
    public class subTask
    {

        static uint _globalSubTaskCount = 228;

        public uint id { get; set; }
        public string subTaskName { get; set; }
        public bool isCompleted { get; set; }

        public subTask(string name)
        {
            subTaskName = name;
            _globalSubTaskCount++;
            id = _globalSubTaskCount;
            isCompleted = false;
        }

        /// Подобные пустые конструкторы нужны для сериаизации (дальше они тоже будут у всех классов)
        public subTask()
        {
            subTaskName = "default";
            _globalSubTaskCount++;
            id = _globalSubTaskCount;
            isCompleted = false;
        }




    }

    public class groupTasks
    {
        static uint _globalGroupCount = 666;


        public uint _idGroup { get; set; }
        public string _groupName { get; set; }
        public List<Task> _groupList { get; set; }


        public groupTasks()
        {
            
            _groupName = "default";

            _globalGroupCount++;
            _idGroup = _globalGroupCount;
            _groupList = new List<Task>();
        }


        public groupTasks(string? name)
        {
            if (name == null)
            {
                _groupName = "default";
            }
            _groupName = name;

            _globalGroupCount++;
            _idGroup = _globalGroupCount;

            _groupList = new List<Task>();
        }

        

        public void addTask(Task task)
        {
            _groupList.Add(task);
        }

        public void DeleteTask(int id)
        {
            _groupList.RemoveAt(_groupList.FindIndex(miniTask => miniTask._id == id));
        }



    }

    public class Task
    {
        static uint _globalIDcount = 0;

        public string _taskName { get; set; }
        public uint _id { get; set; }
        public bool _isCompleted { get; set; }
        public string _date { get; set; }
        
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

        public List<subTask> _subTasks { get; set; }

        
        public Task(){
            _taskName = "default";
            _globalIDcount += 2;
            _id = _globalIDcount;

            _isCompleted = false;
            _date = DateTime.Today.ToString().Substring(0, 10);
            _subTasks = new List<subTask>();

        }

        public Task(in string? name)
        {
            if(name == null)
            {
                _taskName = "default";
            }
            _taskName = name;

            _globalIDcount += 2;
            _id = _globalIDcount;
            
            _isCompleted = false;
            _date = DateTime.Today.ToString().Substring(0, 10);

            _subTasks = new List<subTask>();
        }


        public void AddSubTask(string subtask)
        {
            subTask temp = new subTask(subtask);

            this._subTasks.Add(temp);
        }

        public void CompleteSubTask(string name)
        {
            _subTasks[_subTasks.FindIndex(task => task.subTaskName == name)].isCompleted = true;
        }

        
        

        
    }
}
