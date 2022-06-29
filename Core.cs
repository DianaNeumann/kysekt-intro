using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;


namespace sekta
{
    class Core
    {
        static private List<Task> taskList = new List<Task>();

        static private List<groupTasks> groupList = new List<groupTasks>();



        /* TASK METHODS */

        public static void AddToTaskList(string name)
        {
            Task tempTask = new Task(name);
            taskList.Add(tempTask);

            ConsoleIO.SuccessAdd(tempTask);
        }

        private static void RemoveFromTaskList(int id)
        {
            int indexToDelete = taskList.FindIndex(task => task._id == id);
            taskList.RemoveAt(indexToDelete);

            ConsoleIO.SuccessDelete(id);
        }

        private static void CompleteTask(int id)
        {
            try
            {
                int indexToComplete = taskList.FindIndex(task => task._id == id);
                taskList[indexToComplete]._isCompleted = true;
            }
            catch(Exception ex)
            {
                ConsoleIO.IndexError(ex);
            }
            

            ConsoleIO.CompleteTask(id);
        }

        private static bool isCompeled(Task task)
        {
            return task._isCompleted;
        }

        private static void SetDate(int idDate, DateTime oDate)
        {
            taskList[taskList.FindIndex(task => task._id == idDate)]._date = oDate.ToString().Substring(0, 10);

        }

        private static string GetDate(Task task)
        {
            return task._date;
        }

        private static void AddSubTask(int TaskId, string SubTaskName)
        {
            taskList[taskList.FindIndex(task => task._id == TaskId)].AddSubTask(SubTaskName);
            ConsoleIO.AddSubTaskSuccess();
        }

        private static void CompleteSubTask(int MainTaskID, string SubTaskName)
        {
            taskList[taskList.FindIndex(task => task._id == MainTaskID)].CompleteSubTask(SubTaskName);
            ConsoleIO.CompleteSubTaskSuccess();
        }
        /* END TASK METHODS */



        /* GROUP METHOS */

        private static void AddGroup(string groupName)
        {
            groupTasks tempGroup = new groupTasks(groupName);
            groupList.Add(tempGroup);

            ConsoleIO.CreateGroupSucces(groupName);
        }

        private static void DeleteGroup(int ID)
        {
            groupList.RemoveAt(groupList.FindIndex(group => group._idGroup == ID));
            ConsoleIO.DeleteGroupSucces(ID);
        }

        private static void AddToGroup(int id, string name)
        {
            
            try
            {
                groupList[groupList.FindIndex(group => group._groupName == name)].addTask(taskList[taskList.FindIndex(task => task._id == id)]);
                ConsoleIO.SuccessAddToGroup(id);
            }
            catch (Exception ex)
            {
                ConsoleIO.AddToGroupError(id, name, ex);
            }
        }

        private static void DeleteFromGroup(int idDelete, string name)
        {
            try
            {
                groupList[groupList.FindIndex(group => group._groupName == name)].DeleteTask(idDelete);
                ConsoleIO.SuccessDeleteFromGroup(idDelete);
            }
            catch(Exception ex)
            {
                ConsoleIO.DeleteFromGroupError(idDelete, name, ex);

            }
        }

        /* END GROUP METHOS *////


        public static void Execute(string? json)
        {
            string[] split_comm = json.Split(' ');
            
            string? command = split_comm[0];        

            switch (command)
            {
                case "add":
                    string? taskName = split_comm[1];
                    Core.AddToTaskList(taskName);
                    break;

                case "delete":
                    int idToDelete = Int32.Parse(split_comm[1]);
                    Core.RemoveFromTaskList(idToDelete);
                    break;

                case "all":
                    foreach(Task task in taskList)
                    {
                        ConsoleIO.ShowTaskCMD(task);
                    }
                    break;

                case "save":
                    try
                    {
                        string localPath = AppDomain.CurrentDomain.BaseDirectory;
                        string filePath = localPath + "\\" + split_comm[1] + ".json";

                        FileIO.saveFile(filePath, taskList, groupList);
                    }
                    catch(Exception ex)
                    {
                        ConsoleIO.ShowSaveFileError(ex);
                    }
                    break;

                case "load":
                    try
                    {
                        string filename = split_comm[1] + ".json";
                        FileIO.loadFile(filename, out taskList, out groupList);
                    }
                    catch (Exception ex)
                    {
                        ConsoleIO.ShowLoadFileError(ex);

                    }
                    break;

                case "complete":
                    int idToComplete = Int32.Parse(split_comm[1]);
                    Core.CompleteTask(idToComplete);
                    break;

                case "completed":
                    foreach(var task in taskList)
                    {
                        if (Core.isCompeled(task))
                        {
                            ConsoleIO.ShowTaskCMD(task);
                        }
                    }
                    break;

                case "set-date":
                    int idDate = Int32.Parse(split_comm[1]);

                    try
                    {
                        DateTime oDate = DateTime.Parse(split_comm[2]);
                        Core.SetDate(idDate, oDate);

                        ConsoleIO.SuccessDateSet();
                    }
                    catch (Exception ex)
                    {
                        ConsoleIO.SetDateError(ex);
                     }
                    
                    break;

                case "today":
                    string currentDate = DateTime.Today.ToString().Substring(0, 10);
                    
                    foreach (var task in taskList)
                    {
                        if (Core.GetDate(task) == currentDate)
                        {
                            ConsoleIO.ShowTaskCMD(task);
                        }
                    }
                    break;
                case "add-subtask":
                    int TaskId = Int32.Parse(split_comm[1]);
                    string SubTaskName = split_comm[2];

                    Core.AddSubTask(TaskId, SubTaskName);
                    break;

                case "complete-subtask":
                    int MainTaskID = Int32.Parse(split_comm[1]);
                    string SubTaskNameComplete = split_comm[2];

                    Core.CompleteSubTask(MainTaskID, SubTaskNameComplete);
                    break;


                // GROUP CASES
                case "create-group":
                    
                    string? createGroupName = split_comm[1];
                    Core.AddGroup(createGroupName);
                    break;

                case "delete-group":
                    int DeleteGroupID = Int32.Parse(split_comm[1]);
                    Core.DeleteGroup(DeleteGroupID);
                    break;

                case "add-to-group":
                    int taskID = Int32.Parse(split_comm[1]);
                    string? groupName = split_comm[2];

                    Core.AddToGroup(taskID, groupName);
                    break;

                case "all-groups":
                    foreach(var group in groupList)
                    {
                        ConsoleIO.ShowGroupCMD(group);
                    }

                    break;

                case "delete-from-group":
                    int idToDeleteGroup = Int32.Parse(split_comm[1]);
                    string? deleteGroupName = split_comm[2];

                    Core.DeleteFromGroup(idToDeleteGroup, deleteGroupName); 
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    ConsoleIO.StrangeCommand(command);
                    break;

            }

        }
    }
}

