using DyeAndDurham.Sorter.Core.Models;

namespace DyeAndDurham.Sorter.Core.Sorting;

public sealed class PersonNameComparer : IComparer<PersonName>
{
    private readonly StringComparer _comp;

    public PersonNameComparer(StringComparer? comp = null)
    {
        _comp = comp ?? StringComparer.OrdinalIgnoreCase;   
    }
    public int Compare(PersonName? person1, PersonName? person2)
    {
        if( ReferenceEquals(person1, person2)) return 0;    
        if (person1 is null) return -1;
        if (person2 is null) return 1;  

        var result = _comp.Compare(person1.LastName, person2.LastName);

        if(result != 0) return result;

        var maxCount = Math.Max(person1.GivenNames.Count, person2.GivenNames.Count);

        for (int i = 0; i < maxCount; i++)
        {
            var givenName1 = i < person1.GivenNames.Count ? person1.GivenNames[i] : string.Empty;
            var givenName2 = i < person2.GivenNames.Count ? person2.GivenNames[i] : string.Empty;
            result = _comp.Compare(givenName1, givenName2);
            if (result != 0) return result;
        }

        return 0;
    }
}
