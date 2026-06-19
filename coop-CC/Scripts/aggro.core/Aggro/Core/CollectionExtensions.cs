using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;

namespace Aggro.Core
{
	public static class CollectionExtensions
	{
		public static void AddRangeNoGarbage<T>(this IList<T> list, IList<T> other)
		{
			int count = other.Count;
			for (int i = 0; i < count; i++)
			{
				list.Add(other[i]);
			}
		}

		public static void AddRangeNoGarbage<T>(this IList<T> list, NativeArray<T> other) where T : struct
		{
			int length = other.Length;
			for (int i = 0; i < length; i++)
			{
				list.Add(other[i]);
			}
		}

		public static void Randomize<T>(this IList<T> list, int seed)
		{
			Random random = MathUtil.GetRandom(seed);
			int count = list.Count;
			while (count > 1)
			{
				int index = random.NextInt(0, count--);
				T value = list[count];
				list[count] = list[index];
				list[index] = value;
			}
		}

		public static void Swap<T>(this IList<T> list, int index1, int index2)
		{
			T value = list[index1];
			list[index1] = list[index2];
			list[index2] = value;
		}

		public static ReadOnlyCollection<T> AsReadOnlyNoGarbage<T>(this IList<T> list)
		{
			return new ReadOnlyCollection<T>(list);
		}

		public static void AddRange<T>(this NativeList<T> list, IList<T> other) where T : unmanaged
		{
			int count = other.Count;
			for (int i = 0; i < count; i++)
			{
				list.Add(other[i]);
			}
		}
	}
}
