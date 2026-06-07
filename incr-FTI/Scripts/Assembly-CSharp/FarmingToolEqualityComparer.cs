using System.Collections.Generic;

public class FarmingToolEqualityComparer : IEqualityComparer<FarmingToolType>
{
	public bool Equals(FarmingToolType a, FarmingToolType b)
	{
		return a == b;
	}

	public int GetHashCode(FarmingToolType obj)
	{
		return (int)obj;
	}
}
