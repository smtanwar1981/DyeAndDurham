using DyeAndDurham.Sorter.Core.Models;

namespace DyeAndDurham.Sorter.Core.Parsing;

public static class PersonNameParser
{
    private const int minPartsOfName = 2;
    private const int maxPartsOfName = 4;

    public static PersonName ParseLine(string line, int lineIndex)
    { 
        if (string.IsNullOrWhiteSpace(line))
            throw new ArgumentException($"Name line is null or empty.", nameof(line));

        // Split the line into parts, removing empty entries and trimming whitespace
        var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        // Validate the number of parts
        if (parts.Length < minPartsOfName)
            throw new FormatException($"Invalid name on line number '{lineIndex}'. A name must have at least one given name and a last name");

        // Check if the number of parts exceeds the maximum allowed
        if (parts.Length > maxPartsOfName)
            throw new FormatException($"Invalid name on line number '{lineIndex}'. A name may have up to 3 give names and one last name (max 4 parts).");

        // The last part is the last name, and the rest are given names
        var lastName = parts[^1];

        var givenNames = parts.Take(parts.Length - 1).ToArray();

        return new PersonName(givenNames, lastName);
    }

    public static IEnumerable<PersonName> ValidateAndParseLines(IEnumerable<string> lines) =>
        lines.Where(l => !string.IsNullOrWhiteSpace(l)).Select(ParseLine);
}
