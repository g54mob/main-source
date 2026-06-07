using System.Collections.Generic;

public class StructureEqualityComparer : IEqualityComparer<StructureType>
{
	public bool Equals(StructureType a, StructureType b)
	{
		return a == b;
	}

	public int GetHashCode(StructureType obj)
	{
		return (int)obj;
	}
}
