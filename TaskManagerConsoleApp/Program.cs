using TaskManagerConsoleLibrary.BusinessLogic;
using TaskManagerConsoleLibrary.Models;

namespace TaskManagerConsoleApp;

class Program
{
    static void Main()
    {
        Output.showMessage(Label.Greeting);
        bool exit = false;
        int option;

        List<UserTask>? tasks = Database.LoadFile();

        do 
        {
            Output.showMessage(Label.SelectOption);
            option = Input.GetInputInt();
            switch (option)
            {
                case 1:
                    Database.AddTask(tasks);
                    break;
                case 2:
                    Database.ViewTasks(tasks);
                    break;
                case 3:
                    Database.SearchTasks(tasks);
                    break;
                case 9:
                    exit = true;
                    break;
                default:
                    Output.showMessage(Label.NoneOption);
                    break;

            }
            Output.showSeparator();
        } while (!exit);
        Output.showMessage(Label.Goodbye);
    }
}
