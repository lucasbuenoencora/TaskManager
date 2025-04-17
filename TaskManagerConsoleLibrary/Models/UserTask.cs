using System;

namespace TaskManagerConsoleLibrary.Models;

public enum Status
{
    Completed = 1,
    Pending = 0
}

public class UserTask (string description, DateTime deadline)
{
    private string _description = description;
    private DateTime _deadline = deadline;
    private Status _status = 0;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public DateTime Deadline 
    {
        get { return _deadline; }
        set { _deadline = value; }
    }

    public Status Status 
    {
        get { return _status; }
        set { _status = value; }
    }
}
