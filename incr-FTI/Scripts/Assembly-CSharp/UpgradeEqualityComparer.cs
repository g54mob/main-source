using System.Collections.Generic;

public class UpgradeEqualityComparer : IEqualityComparer<UpgradeType>
{
	public bool Equals(UpgradeType a, UpgradeType b)
	{
		return a == b;
	}

	public int GetHashCode(UpgradeType obj)
	{
		return (int)obj;
	}
}
