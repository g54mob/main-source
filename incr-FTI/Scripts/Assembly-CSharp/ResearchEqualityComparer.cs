using System.Collections.Generic;

public class ResearchEqualityComparer : IEqualityComparer<ResearchType>
{
	public bool Equals(ResearchType a, ResearchType b)
	{
		return a == b;
	}

	public int GetHashCode(ResearchType obj)
	{
		return (int)obj;
	}
}
