using DyeAndDurham.Sorter.Core.Parsing;

namespace DyeAndDurham.Sorter.Tests;

public class PersonNameParserTests
{
    [Theory]
    [InlineData("Janet Parsons", 1, "Parsons")]
    [InlineData("Beau Tristan Bentley", 2, "Bentley")]
    [InlineData("Hunter Uriah Mathew Clarke", 3, "Clarke")]
    public void Parses_Valid_Lines(string line, int givenCount, string last)
    {
        var p = PersonNameParser.ParseLine(line, 1);
        Assert.Equal(givenCount, p.GivenNames.Count);
        Assert.Equal(last, p.LastName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Empty_Line_Throws(string line)
        => Assert.Throws<ArgumentException>(() => PersonNameParser.ParseLine(line, 1));

    [Theory]
    [InlineData("Parsons")]
    [InlineData("A B C D E")]
    public void Invalid_Format_Throws(string line)
        => Assert.Throws<FormatException>(() => PersonNameParser.ParseLine(line, 1));

    [Fact]
    public void Ignores_Extra_Spaces()
    {
        var p = PersonNameParser.ParseLine("  Janet   Parsons   ", 1);
        Assert.Equal("Janet", p.GivenNames[0]);
        Assert.Equal("Parsons", p.LastName);
    }
}
