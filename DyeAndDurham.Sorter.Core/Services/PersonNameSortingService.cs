using DyeAndDurham.Sorter.Core.Models;
using DyeAndDurham.Sorter.Core.Sorting;

namespace DyeAndDurham.Sorter.Core.Services;

public interface IPersonNameSortingService
{
    IReadOnlyList<PersonName> SortPersonNames(IEnumerable<PersonName> names);
}

public sealed class PersonNameSortingService : IPersonNameSortingService
{
    private readonly IComparer<PersonName> _comp;

    public PersonNameSortingService(IComparer<PersonName>? comp = null)
    {
        _comp = comp ?? new PersonNameComparer();
    }

    public IReadOnlyList<PersonName> SortPersonNames(IEnumerable<PersonName> names)
        => names.OrderBy(n => n, _comp).ToList();
}
