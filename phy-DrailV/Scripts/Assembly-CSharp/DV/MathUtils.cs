using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DV
{
	public static class MathUtils
	{
		public delegate float WeightGetter<T>(T item);

		public const float ROOT_TWO = 1.4142135f;

		public const float HALF_ROOT_TWO = 0.70710677f;

		public static float InverseLerpUnclamped(float a, float b, float value)
		{
			return (value - a) / (b - a);
		}

		public static T GetRandomElement<T>(this T[] array)
		{
			if (array == null || array.Length == 0)
			{
				throw new IndexOutOfRangeException("Array is null or empty, no elements to choose from.");
			}
			if (array.Length == 1)
			{
				return array[0];
			}
			return array[UnityEngine.Random.Range(0, array.Length)];
		}

		public static T GetRandomElement<T>(this IList<T> list)
		{
			if (list == null || list.Count == 0)
			{
				throw new IndexOutOfRangeException("Array is null or empty, no elements to choose from.");
			}
			if (list.Count == 1)
			{
				return list[0];
			}
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public static void Shuffle<T>(this T[] array)
		{
			if (array != null && array.Length > 1)
			{
				for (int i = 0; i < array.Length; i++)
				{
					int num = UnityEngine.Random.Range(0, array.Length);
					int num2 = i;
					int num3 = num;
					T val = array[num];
					T val2 = array[i];
					array[num2] = val;
					array[num3] = val2;
				}
			}
		}

		public static void Shuffle<T>(this IList<T> list)
		{
			if (list != null && list.Count > 1)
			{
				for (int i = 0; i < list.Count; i++)
				{
					int num = UnityEngine.Random.Range(0, list.Count);
					int index = i;
					int index2 = num;
					T val = list[num];
					T val2 = list[i];
					T val3 = (list[index] = val);
					val3 = (list[index2] = val2);
				}
			}
		}

		public static T[] GetWeightedPicks<T>(this IEnumerable<T> inputData, WeightGetter<T> weightGetter, int count)
		{
			T[] array = inputData.ToArray();
			float[] array2 = new float[array.Length];
			float num = 0f;
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = weightGetter(array[i]);
				num += array2[i];
			}
			T[] array3 = new T[count];
			for (int j = 0; j < count; j++)
			{
				float num2 = UnityEngine.Random.Range(0f, num);
				float num3 = 0f;
				for (int k = 0; k < array.Length; k++)
				{
					num3 += array2[k];
					if (num2 <= num3)
					{
						array3[j] = array[k];
						break;
					}
				}
			}
			return array3;
		}
	}
}
