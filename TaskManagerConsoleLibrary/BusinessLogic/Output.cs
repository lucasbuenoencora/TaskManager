using System;
using System.ComponentModel;
using System.Reflection;

namespace TaskManagerConsoleLibrary.BusinessLogic;

public enum Label
{
    [Description("Welcome to Task Manager 4.1")]
    Greeting = 1,
    [Description("Type the number of the desired option:\n1 - Add Tasks\n2 - View Tasks\n3 - Search Tasks\n9 - Exit")]
    SelectOption = 2,
    [Description("None of the options select. Please, try again.")]
    NoneOption = 3,
    [Description("Please, insert new task description:")]
    InputDescription = 4,
    [Description("Please, insert deadline (dd/mm/yyyy):")]
    InputDeadline = 5,
    [Description("Is this task pending? Press Y for yes, N for no.")]
    ConfirmPending = 6,
    [Description("Task saved, do you want to keep adding tasks? Press Y.")]
    ConfirmNewTask = 7,
    [Description("You don't have any tasks saved.")]
    NoTasksAvailable = 8,
    [Description("Which option do you want to search by?\n1 - Status\n9 - Exit")]
    SearchOption = 9,
    [Description("None of the options select, back to the menu.")]
    NoneOptionMenu = 10,
    [Description("Which status do you choose?")]
    StatusOption = 11,
    [Description("You don't have any tasks with this filter.")]
    NoTasksAvailableFilter = 12,
    [Description("Unable to get input.")]
    UnableGetInput = 13,
    [Description("Good bye!")]
    Goodbye = 14
}

public class Output
{
    public static void showMessage(Label label) 
    {
        Console.WriteLine(GetEnumDescription(label));
    }

    public static void showMessage(string text)
    {
        Console.WriteLine(text);
    }


    private static string GetEnumDescription(Enum enumVal)
    {
        System.Reflection.MemberInfo[] memInfo = enumVal.GetType().GetMember(enumVal.ToString());
        if(memInfo.Length == 0) { return "Couldn't find label"; }
        DescriptionAttribute? attribute = CustomAttributeExtensions.GetCustomAttribute<DescriptionAttribute>(memInfo[0]);
        if (String.IsNullOrEmpty(attribute?.Description)) 
        {
            return "Label description is blank";
        }
        else 
        {
            return attribute.Description;
        }
    }

    public static void showSeparator()
    {
        Console.WriteLine("##################################################");
    }

}
