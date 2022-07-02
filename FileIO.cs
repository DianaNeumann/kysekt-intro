using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace sekta
{
    class FileIO
    {
        public static void saveFile(in string filePath, in List<Task> taskSave, in List<groupTasks> groupSave)
        {
            string jsonTask = JsonSerializer.Serialize(taskSave);
            string jsonGroup = JsonSerializer.Serialize(groupSave);

                
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

                  
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(jsonTask);
                sw.WriteLine(jsonGroup);

            }

            ConsoleIO.JSONSaved();
      
        }

        public static void loadFile(in string inputFile, out List<Task> outTaskList, out List<groupTasks> outGroupList)
        {
          
            string jsonInput = File.ReadAllText(inputFile);

            string taskJson = jsonInput.Split("\n")[0];
            string groupJson = jsonInput.Split("\n")[1];

            outTaskList = JsonSerializer.Deserialize< List<Task>>(taskJson);
            outGroupList = JsonSerializer.Deserialize<List<groupTasks>>(groupJson);


            ConsoleIO.JSONLoaded();
            
        }
    }
}
