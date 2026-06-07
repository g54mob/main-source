using System.Collections.Generic;

public class BuildingEqualityComparer : IEqualityComparer<BuildingType>
{
	public bool Equals(BuildingType a, BuildingType b)
	{
		return a == b;
	}

	public int GetHashCode(BuildingType obj)
	{
		return (int)obj;
	}
}
