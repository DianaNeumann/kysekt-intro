using System;
using System.Collections.Generic;
using System.Text;

namespace sekta
{
    public class ConsoleIO
    {
        public static  void ShowTaskCMD(Task task)
        {
            
            Console.WriteLine($"Task: {task.TaskName} " +
                $"\nID: {task.ID} " +
                $"\nDate: {task.Date}" +
                $"\nCompleted: {task.isCompleted}" +
                $"\nSubtasks: ");

            foreach (subTask miniTask in task.SubTasks)
            {
                Console.Write($"\t- {miniTask.SubTaskName} Completed: {miniTask.isCompleted} ID={miniTask.ID} \n");
            }
           
        }

        public static void ShowGroupCMD(groupTasks group)
        {
            Console.WriteLine($"ID: {group.idGroup} " + 
                $"\nGroup: {group.GroupName} " +
                $"\nTasks in group: ");

            foreach (var task in group.GroupList)
            {
                Console.Write("\t- " + task.TaskName + " ID: " + task.ID+ "\n");
            }
        }



        public static void StrangeCommand(string command)
        {
            Console.ForegroundColor = ConsoleColor.Blue; ;
            Console.WriteLine($"[-] W7F 7h3 c0mm4nd \"{command}\" m34n5?");
            Console.ResetColor();
        }

        public static void SuccessAdd(Task task)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Task added. ID={task.ID}");
            Console.ResetColor();
        }

        public static void SuccessDelete(int id)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Task ID={id} deleted!");
            Console.ResetColor();
        }

        public static void SuccessDateSet()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] New date is set!");
            Console.ResetColor();
        }

        public static void AddSubTaskSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Subtask added!");
            Console.ResetColor();
        }

        public static void CompleteTask(int id)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Task №{id} completed!");
            Console.ResetColor();
        }

        public static void CompleteSubTaskSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Subtask completed!");
            Console.ResetColor();
        }

        public static void CreateGroupSucces(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Group \"{name}\" create!");
            Console.ResetColor();
        }

        public static void DeleteGroupSucces(int id)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Group №{id} delete!");
            Console.ResetColor();
        }

        public static void SuccessAddToGroup(int id)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Task №{id} was added to this group!");
            Console.ResetColor();
        }

        public static void SuccessDeleteFromGroup(int id)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] Task №{id} deleted from this group!");
            Console.ResetColor();
        }


        public static void JSONSaved()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] Json data was succesefuly saved!");
            Console.ResetColor();
        }

        public static void JSONLoaded()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] Json data was succesefuly loaded!");
            Console.ResetColor();
        }


        public static void ShowSaveFileError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[-] Enter correct file to save data");
            Console.WriteLine(ex);
            Console.ResetColor();
        }

        public static void ShowLoadFileError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[-] Enter correct file to load datafrom");
            Console.WriteLine(ex);
            Console.ResetColor();
        }

        public static void IndexError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[-] Index probably out of range");
            Console.WriteLine(ex);
            Console.ResetColor();
        }

        public static void SetDateError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[-] Incorrect date");
            Console.WriteLine(ex);
            Console.ResetColor();
        }

        public static void AddToGroupError(int id, string name, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[-] Enter the correct task ID and group name." +
                $" \"{id}\" and \"{name}\" doesn't correct");
            Console.WriteLine(ex);
            Console.ResetColor();
        }

        public static void DeleteFromGroupError(int id, string name, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[-] Enter the correct task ID and group name to delete." +
                $"\"{id}\" and \"{name}\" doesn't correct");
            Console.WriteLine(ex);
            Console.ResetColor();
        }


    }
}
