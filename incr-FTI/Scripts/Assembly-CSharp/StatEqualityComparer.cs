using System.Collections.Generic;

public class StatEqualityComparer : IEqualityComparer<StatType>
{
	public bool Equals(StatType a, StatType b)
	{
		return a == b;
	}

	public int GetHashCode(StatType obj)
	{
		return (int)obj;
	}
}
