using System.Collections.Generic;

public class BiomeEqualityComparer : IEqualityComparer<BiomeType>
{
	public bool Equals(BiomeType a, BiomeType b)
	{
		return a == b;
	}

	public int GetHashCode(BiomeType obj)
	{
		return (int)obj;
	}
}
