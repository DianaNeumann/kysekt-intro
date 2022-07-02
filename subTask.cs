using System;
using System.Collections.Generic;
using System.Text;

namespace sekta
{
    public class subTask
    {
        static private uint _globalSubTaskCount = 228;

        public uint ID { get; set; }
        public string SubTaskName { get; set; }
        public bool isCompleted { get; set; }

        public subTask(string name)
        {
            SubTaskName = name;
            _globalSubTaskCount++;
            ID = _globalSubTaskCount;
            isCompleted = false;
        }

        /// Подобные пустые конструкторы нужны для сериаизации (дальше они тоже будут у всех классов)
        private subTask()
        {
            SubTaskName = "default";
            _globalSubTaskCount++;
            ID = _globalSubTaskCount;
            isCompleted = false;
        }
    }
}
