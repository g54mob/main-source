using System.Collections.Generic;

public static class ShuffleListExtensions
{
	public static void Shuffle<T>(this IList<T> list)
	{
	}

	public static void Shuffle<T>(this IList<T> list, int seed)
	{
	}

	public static T RandomItem<T>(this IList<T> list)
	{
		return default(T);
	}

	public static T RemoveRandom<T>(this IList<T> list)
	{
		return default(T);
	}
}
