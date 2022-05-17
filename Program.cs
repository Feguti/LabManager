using LabManager.Database;
using LabManager.Repositories;
using Microsoft.Data.Sqlite;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);

// Routing
var modelName = args[0];
var modelAction = args[1];

if (modelName == "Computer")
{
    if (modelAction == "List")
    {
        Console.WriteLine("\nComputer List\n");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
        }

    }

    if (modelAction == "New")
    {
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);
        command.ExecuteNonQuery();

        connection.Close();
    }

}

if (modelName == "Laboratory")
{

    if (modelAction == "List")
    {
        var connection = new SqliteConnection("Data Source = database.db");
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT id, number, name, sector FROM Laboratories";

        var reader = command.ExecuteReader();

        Console.WriteLine("\nLaboratory List\n");
        while (reader.Read())
        {
            Console.WriteLine(
                "{0}, {1}, {2}, {3}", reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetChar(3)
            );
        }

        reader.Close();
        connection.Close();
    }

    if (modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var number = Convert.ToInt32(args[3]);
        var name = args[4];
        var sector = args[5];

        var connection = new SqliteConnection("Data Source = database.db");

        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = @"
            INSERT INTO Laboratories VALUES($id, $number, $name, $sector);
            
            ";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$number", number);
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$sector", sector);

        command.ExecuteNonQuery();

        connection.Close();
    }
}

