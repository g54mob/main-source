using System.Collections.Generic;

public class NaturalResourceEqualityComparer : IEqualityComparer<NaturalResource>
{
	public bool Equals(NaturalResource a, NaturalResource b)
	{
		return a == b;
	}

	public int GetHashCode(NaturalResource obj)
	{
		return (int)obj;
	}
}
