using System;
using System.Collections.Generic;

public static class RandomizeExtensionsForLists
{
	public static void ETShuffle<T>(this IList<T> list, Random generator)
	{
		int num = list.Count;
		while (num > 1)
		{
			num--;
			int index = generator.Next(num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}
}
