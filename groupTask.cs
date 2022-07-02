using System;
using System.Collections.Generic;
using System.Text;

namespace sekta
{ 
        public class groupTasks
        {
            static private uint _globalGroupCount = 666;

            public uint idGroup { get; set; }
            public string GroupName { get; set; }
            public List<Task> GroupList { get; set; }

            private groupTasks()
            {

                GroupName = "default";

                _globalGroupCount++;
                idGroup = _globalGroupCount;
                GroupList = new List<Task>();
            }


            public groupTasks(string? name="default")
            {
                
                GroupName = name;

                _globalGroupCount++;
                idGroup = _globalGroupCount;

                GroupList = new List<Task>();
            }

            public void addTask(Task task)
            {
                GroupList.Add(task);
            }

            public void DeleteTask(int id)
            {
                GroupList.RemoveAt(GroupList.FindIndex(miniTask => miniTask.ID == id));
            }

        }
}
