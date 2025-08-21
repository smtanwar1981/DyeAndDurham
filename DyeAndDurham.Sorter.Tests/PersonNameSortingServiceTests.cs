using DyeAndDurham.Sorter.Core.Services;

namespace DyeAndDurham.Sorter.Tests;

public class PersonNameSortingServiceTests
{
    [Fact]
    public void Sorts_Sample_As_Required()
    {
        var input = new[]
            {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer",
            "Shelby Nathan Yoder",
            "Marin Alvarez",
            "London Lindsey",
            "Beau Tristan Bentley",
            "Leo Gardner",
            "Hunter Uriah Mathew Clarke",
            "Mikayla Lopez",
            "Frankie Conner Ritter"
        };

        var expected = new[]
        {
            "Marin Alvarez",
            "Adonis Julius Archer",
            "Beau Tristan Bentley",
            "Hunter Uriah Mathew Clarke",
            "Leo Gardner",
            "Vaughn Lewis",
            "London Lindsey",
            "Mikayla Lopez",
            "Janet Parsons",
            "Frankie Conner Ritter",
            "Shelby Nathan Yoder"
        };

        var names = Core.Parsing.PersonNameParser.ValidateAndParseLines(input).ToArray();
        var service = new PersonNameSortingService();
        var sorted = service.SortPersonNames(names).Select(x => x.ToString()).ToArray();

        Assert.Equal(expected, sorted);
    }
}
