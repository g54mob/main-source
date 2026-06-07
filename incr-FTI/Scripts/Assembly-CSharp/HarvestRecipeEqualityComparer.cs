using System.Collections.Generic;

public class HarvestRecipeEqualityComparer : IEqualityComparer<HarvestRecipeType>
{
	public bool Equals(HarvestRecipeType a, HarvestRecipeType b)
	{
		return a == b;
	}

	public int GetHashCode(HarvestRecipeType obj)
	{
		return (int)obj;
	}
}
