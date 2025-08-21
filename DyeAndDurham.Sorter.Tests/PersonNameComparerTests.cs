using DyeAndDurham.Sorter.Core.Models;
using DyeAndDurham.Sorter.Core.Sorting;

namespace DyeAndDurham.Sorter.Tests;

public class PersonNameComparerTests
{
    [Fact]
    public void Sorts_By_Last_Then_Given()
    {
        var comparer = new PersonNameComparer();
        var list = new[]
            {
            new PersonName(new[] { "B" }, "Apple"),
            new PersonName(new[] { "A" }, "Apple"),
            new PersonName(new[] { "Z" }, "Ball")
        };

        var sorted = list.OrderBy(x => x, comparer).ToArray();
        Assert.Equal("Apple", sorted[0].LastName);
        Assert.Equal("A", sorted[0].GivenNames[0]);
        Assert.Equal("Apple", sorted[1].LastName);
        Assert.Equal("B", sorted[1].GivenNames[0]);
        Assert.Equal("Ball", sorted[2].LastName);
    }
}
