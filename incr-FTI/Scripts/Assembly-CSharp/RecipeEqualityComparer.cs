using System.Collections.Generic;

public class RecipeEqualityComparer : IEqualityComparer<RecipeType>
{
	public bool Equals(RecipeType a, RecipeType b)
	{
		return a == b;
	}

	public int GetHashCode(RecipeType obj)
	{
		return (int)obj;
	}
}
