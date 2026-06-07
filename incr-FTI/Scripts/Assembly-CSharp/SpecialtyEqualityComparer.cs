using System.Collections.Generic;

public class SpecialtyEqualityComparer : IEqualityComparer<Specialty>
{
	public bool Equals(Specialty a, Specialty b)
	{
		return a == b;
	}

	public int GetHashCode(Specialty obj)
	{
		return (int)obj;
	}
}
