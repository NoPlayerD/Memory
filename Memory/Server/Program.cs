using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.AutoML;
using Microsoft.ML.TorchSharp;
using TorchSharp;


using System.IO;
using System.Data;
using Tensorflow.Contexts;
using Spectre.Console;

Welcome();

#region Welcome

void Welcome()
{
    Console.Title= "(Server) Memory";
    Console.WindowHeight = 40;
    Console.WindowWidth = 130;
    Console.Clear();
    var welcome = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("WELCOME").PageSize(5).HighlightStyle("gray").AddChoices(new[] { "Create Model", "Help", "[red]Exit[/]" }));
    if (welcome == "[red]Exit[/]") { Environment.Exit(0); } else if (welcome == "Help") { Help(); } else { Continue(); }
}
#endregion

#region Continue

void Continue()
{
    AAM CModel = new AAM();

    string path;
    Console.WriteLine("Enter the Path of your DataSet: ");
    path = Console.ReadLine();
    CModel.Experiment(path);
}
#endregion

#region Help

void Help()
{
    Console.WriteLine("Help Menu: \n");
    Console.WriteLine("- Your DataSet must be .csv file" +
        "\n- Your DataSet must has headers" +
        "\n- Your DataSet must be categorizable" +
        "\n- Your Data files must be named with the names of 'Category'\n" +
        "\n- EXAMPLE DataSet & Data:");


    #region table1

    // Create a table
    var table = new Table();

    // Add some columns
    table.AddColumn(new TableColumn("Prompt").Centered());
    table.AddColumn(new TableColumn("Category").Centered());

    // Add some rows
    table.AddRow("Delete file", "[red]Delete[/]");
    table.AddRow("Delete folder", "[red]Delete[/]");
    table.AddRow("Delete data", "[red]Delete[/]");
    table.AddRow("Delete some files", "[red]Delete[/]");
    table.AddRow("--------------------","----------");
    table.AddRow("Add file", "[green]Add[/]");
    table.AddRow("Add folders", "[green]Add[/]");
    table.AddRow("Add new data", "[green]Add[/]");
    table.AddRow("Add some files", "[green]Add[/]");
    table.AddRow("--------------------", "----------");
    table.AddRow("Rename files", "[yellow]Edit[/]");
    table.AddRow("Rename folders", "[yellow]Edit[/]");
    table.AddRow("Change some files", "[yellow]Edit[/]");
    table.AddRow("Edit first file", "[yellow]Edit[/]");
    table.AddRow("Change data", "[yellow]Edit[/]");

        // Render the table to the console
    AnsiConsole.Write(table);
    #endregion

    #region table2

    // Create a table
    var tableD = new Table();

    // Add some columns
    tableD.AddColumn(new TableColumn("Path").Centered());
    tableD.AddColumn(new TableColumn("File Name").Centered());

    // Add some rows
    tableD.AddRow(@"..\MyData\", "[red]Delete.txt[/]");
    tableD.AddRow(@"..\MyData\", "[green]Add.txt[/]");
    tableD.AddRow(@"..\MyData\", "[yellow]Edit.txt[/]");

    // Render the table to the console
    AnsiConsole.Write(tableD);
    #endregion

    Console.WriteLine("\nPress any key to Go Back..");

    Console.ReadKey();
    Welcome();
}
#endregion

