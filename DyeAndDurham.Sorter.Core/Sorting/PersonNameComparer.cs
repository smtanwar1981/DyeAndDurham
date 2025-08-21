using DyeAndDurham.Sorter.Core.Models;

namespace DyeAndDurham.Sorter.Core.Sorting;

public sealed class PersonNameComparer : IComparer<PersonName>
{
    private readonly StringComparer _comp;

    public PersonNameComparer(StringComparer? comp = null)
    {
        _comp = comp ?? StringComparer.OrdinalIgnoreCase;   
    }
    public int Compare(PersonName? x, PersonName? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return -1;
        if (y is null) return 1;
        
        var c = _comp.Compare(x.LastName, y.LastName);
        if(c != 0) return c;

        var max = Math.Max(x.GivenNames.Count, y.GivenNames.Count);
        for (int i = 0; i < max; i++)
        { 
            var gx = i < x.GivenNames.Count ? x.GivenNames[i] : string.Empty;
            var gy = i < y.GivenNames.Count ? y.GivenNames[i] : string.Empty;   

            c = _comp.Compare(gx, gy);
            if (c != 0) return c;
        }
        return 0;
    }
}
