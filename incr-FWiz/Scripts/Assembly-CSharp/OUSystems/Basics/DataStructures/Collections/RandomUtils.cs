using System;
using System.Collections.Generic;

namespace OUSystems.Basics.DataStructures.Collections
{
	public static class RandomUtils
	{
		public static T GetRandomWeightedItem<T>(this List<T> list, Func<T, float> getWeight)
		{
			return default(T);
		}

		public static int GetRandomWeightedIndex<T>(List<T> list, Func<T, float> getWeight)
		{
			return 0;
		}

		public static T GetRandom<T>(this List<T> list)
		{
			return default(T);
		}

		public static List<T> GetRandomWeightedSet<T>(List<T> items, int countToSelect, Func<T, float> getWeight)
		{
			return null;
		}

		public static void Shuffle<T>(this List<T> list)
		{
		}
	}
}
