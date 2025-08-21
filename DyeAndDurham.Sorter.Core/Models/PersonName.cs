namespace DyeAndDurham.Sorter.Core.Models;

public sealed record PersonName (IReadOnlyList<string> GivenNames, string LastName)
{
    public override string ToString() => string.Join(' ', GivenNames.Append(LastName));
}
