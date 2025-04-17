using System;
using System.Globalization;
using TaskManagerConsoleLibrary.Models;

namespace TaskManagerConsoleLibrary.BusinessLogic;

public static class Input
{
    public static int GetInputInt()
    {
        var input = Console.ReadLine();
        if(!String.IsNullOrEmpty(input))
        {
            try
            {
                return Int32.Parse(input);
            }
            catch (FormatException)
            {
                Output.showMessage($"Unable to Parse '{input}'.");
                return 0;
            }
        } else {
            Output.showMessage(Label.UnableGetInput);
            return 0;
        }
    }

    public static string GetInputWithLabel(Label label) 
    {
        Output.showMessage(label);
        string? description;
        do
        {
            description = Console.ReadLine();
            if(String.IsNullOrEmpty(description)) { Output.showMessage(Label.UnableGetInput); }
        } while (String.IsNullOrEmpty(description));
        return description;
    }

    public static DateTime ParseDateInput(string input) 
    {
        try 
        {
            return DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        }
        catch (FormatException) 
        {
            Output.showMessage($"Unable to parse '{input}', please try again.");
            string newInput = GetInputWithLabel(Label.InputDeadline);
            return ParseDateInput(newInput);
        }
    }

    public static bool ConfirmPendingTask() 
    {
        Output.showMessage(Label.ConfirmPending);
        var confirm = Console.ReadLine();
        try
        {
            if (!String.IsNullOrEmpty(confirm) && string.Equals(confirm,"Y", StringComparison.OrdinalIgnoreCase)) 
            {
                return true;
            } else {
                return false;
            }
        }
        catch (FormatException)
        {
            Output.showMessage($"Unable to Parse '{confirm}', please try again.");
            return ConfirmPendingTask();
        }
    }

    public static bool ConfirmNewTask() 
    {
        Output.showMessage(Label.ConfirmNewTask);
        var confirm = Console.ReadLine();
        try
        {
            if (!String.IsNullOrEmpty(confirm) && !string.Equals(confirm,"Y", StringComparison.OrdinalIgnoreCase)) 
            {
                return true;
            } else {
                return false;
            }
        }
        catch (FormatException)
        {
            Output.showMessage($"Unable to Parse '{confirm}', back to the menu.");
            return true;
        }
    }

    public static int GetSelectedStatus() 
    {
        Output.showMessage(Label.StatusOption);
        var statuses = Enum.GetValues(typeof(Status));
        foreach(Status status in statuses)
        {
            Output.showMessage($"{(int) status} - {status}");
        }
        return GetInputInt();
    }
}
