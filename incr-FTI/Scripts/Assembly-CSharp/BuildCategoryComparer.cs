using System.Collections.Generic;

public class BuildCategoryComparer : IEqualityComparer<BuildCategoryType>
{
	public bool Equals(BuildCategoryType a, BuildCategoryType b)
	{
		return a == b;
	}

	public int GetHashCode(BuildCategoryType obj)
	{
		return (int)obj;
	}
}
