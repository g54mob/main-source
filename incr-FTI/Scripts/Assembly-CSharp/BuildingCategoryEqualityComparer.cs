using System.Collections.Generic;

public class BuildingCategoryEqualityComparer : IEqualityComparer<BuildingCategory>
{
	public bool Equals(BuildingCategory a, BuildingCategory b)
	{
		return a == b;
	}

	public int GetHashCode(BuildingCategory obj)
	{
		return (int)obj;
	}
}
