using System;
using System.Text.Json;
using TaskManagerConsoleLibrary.Models;

namespace TaskManagerConsoleLibrary.BusinessLogic;

public class Database
{
    const string fileName = "../TaskManagerConsoleApp/Tasks.json";
    public static List<UserTask>? LoadFile() 
    {
        if (File.Exists(fileName)) 
        {
            string fileContent = File.ReadAllText(fileName);
            if (String.IsNullOrEmpty(fileContent)) 
            {
                return [];
            } else 
            {
                return JsonSerializer.Deserialize<List<UserTask>>(fileContent);
            }
        } else 
        {
            File.CreateText(fileName);
            return [];
        }
    }

    public static void AddTask(List<UserTask>? tasks)
    {
        bool exit;
        do
        {
            UserTask task = new UserTask(Input.GetInputWithLabel(Label.InputDescription),Input.ParseDateInput(Input.GetInputWithLabel(Label.InputDeadline)));
            task.Status = Input.ConfirmPendingTask() ? Status.Pending : Status.Completed;
            WriteToJson(task, tasks);
            exit = Input.ConfirmNewTask();
        } while (!exit);
    }

    static void WriteToJson(UserTask task, List<UserTask>? tasks) 
    {
        if (tasks is not null) 
        {
            tasks.Add(task);
        } else {
            tasks = [];
            tasks.Add(task);
        }
        string jsonString = JsonSerializer.Serialize<List<UserTask>>(tasks);
        File.WriteAllText(fileName, jsonString);
    }

    public static void ViewTasks(List<UserTask>? tasks)
    {
        if(tasks is not null) 
        {
            if(!tasks.Any()) {Output.showMessage(Label.NoTasksAvailable);return;}
            foreach(var task in tasks)
            {
                Output.showMessage($"Description: {task.Description}");
                Output.showMessage($"Deadline: {task.Deadline}");
                Output.showMessage($"Status: {task.Status}");
            }
        } else {
            Output.showMessage(Label.NoTasksAvailable);
        }
    }

    public static void SearchTasks(List<UserTask>? tasks) 
    {
        Output.showMessage(Label.SearchOption);

        int option = Input.GetInputInt();
        switch (option)
        {
            case 1: 
                RunQuery((Status)Input.GetSelectedStatus(), tasks);
                break;
            case 9:
                break;
            default:
                Output.showMessage(Label.NoneOptionMenu);
                break;
        }
    }

    static void RunQuery(Status status, List<UserTask>? tasks) 
    {
        IEnumerable<UserTask> query =
            from task in tasks
            where task.Status == status
            orderby task.Deadline ascending
            select task;

        if(!query.Any()) {Output.showMessage(Label.NoTasksAvailableFilter);return;}
        foreach(var task in query)
        {
            Output.showMessage($"Description: {task.Description}");
            Output.showMessage($"Deadline: {task.Deadline}");
            Output.showMessage($"Status: {task.Status}");
        }
    }
}
