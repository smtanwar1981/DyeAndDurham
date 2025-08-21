

using DyeAndDurham.Sorter.Core.Parsing;
using DyeAndDurham.Sorter.Core.Services;
using System.Text;

const string outputFileName = "sorted-names.txt";

if (args.Length != 1)
{ 
    Console.Error.WriteLine($"Please supply a file path.");
    // Exit code 1 indicates no file path was provided. A user error.
    Environment.Exit(1);
    return;
}

var filePath = args[0];
if (!File.Exists(filePath))
{ 
    Console.Error.WriteLine($"The path: {filePath} does not exist.");
    // Exit code 2 indicates the file path does not exist.
    Environment.Exit(2);
    return;
}

try
{
    // Read all lines from the file, assuming UTF-8 encoding.
    var lines = File.ReadAllLines(filePath, Encoding.UTF8);

    // Validating names and converting them to Given Names and Last Name.
    var names = PersonNameParser.ValidateAndParseLines(lines);

    // Sort the names using the NameSortingService.
    var _personNameSortingService = new PersonNameSortingService();

    // Sort the names and convert them to a list.
    var sortedPersonNames = _personNameSortingService.SortPersonNames(names);

    foreach (var personName in sortedPersonNames)
    {
        Console.WriteLine(personName.ToString());
    }

    File.WriteAllLines(outputFileName, sortedPersonNames.Select(s => s.ToString()), Encoding.UTF8);
}
catch (FormatException fe)
{
    Console.Error.WriteLine($"Data error: {fe.Message}");
    // Exit code 3 indicates a format error in the data, such as an invalid name format.
    Environment.Exit(3);
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Unexpected error: {ex.Message}");
    // Exit code 99 indicates an unexpected error.
    Environment.Exit(99);
}