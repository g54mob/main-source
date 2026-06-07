using System.Collections.Generic;

public class PerkEqualityComparer : IEqualityComparer<PerkType>
{
	public bool Equals(PerkType a, PerkType b)
	{
		return a == b;
	}

	public int GetHashCode(PerkType obj)
	{
		return (int)obj;
	}
}
