using System;
using TaskManagerConsoleLibrary.BusinessLogic;

namespace TaskManagerConsoleApp.Tests;

public class OutputTests
{

    [Fact]
    public void ShowMessage_ValidLabel_LabelShown()
    {
        // Arrange
        Label label = Label.Greeting;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Output.showMessage(label);

        //Assert
        var output = stringWriter.ToString();
        Assert.Equal("Welcome to Task Manager 4.1\n", output);
    }

    [Fact]
    public void ShowMessage_NoLabel_ReturnMessage()
    {
        // Arrange
        Label error = (Label)20;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Output.showMessage(error);

        //Assert
        var output = stringWriter.ToString();
        Assert.Equal("Couldn't find label\n", output);
    }

}
