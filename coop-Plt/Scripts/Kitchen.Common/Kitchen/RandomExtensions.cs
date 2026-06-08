using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public static class RandomExtensions
	{
		public static T Random<T>(this List<T> list)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public static T Random<T>(this List<T> list, out int index)
		{
			index = UnityEngine.Random.Range(0, list.Count);
			return list[index];
		}

		public static T Random<T>(this T[] array)
		{
			return array[UnityEngine.Random.Range(0, array.Length)];
		}

		public static T Random<T>(this NativeArray<T> list) where T : struct
		{
			return list[UnityEngine.Random.Range(0, list.Length)];
		}

		public static T Random<T>(this EntityQuery query) where T : struct, IComponentData
		{
			NativeArray<T> list = query.ToComponentDataArray<T>(Allocator.Temp);
			T result = list.Random();
			list.Dispose();
			return result;
		}

		public static List<T> Shuffle<T>(this List<T> list)
		{
			return list.OrderBy((T r) => UnityEngine.Random.value).ToList();
		}

		public static void ShuffleInPlace<T>(this IList<T> list)
		{
			int num = list.Count;
			while (num > 1)
			{
				num--;
				int num2 = UnityEngine.Random.Range(0, num + 1);
				int index = num2;
				int index2 = num;
				T val = list[num];
				T val2 = list[num2];
				T val3 = (list[index] = val);
				val3 = (list[index2] = val2);
			}
		}

		public static void ShuffleInPlace<T>(this NativeArray<T> list) where T : struct
		{
			int num = list.Length;
			while (num > 1)
			{
				num--;
				int num2 = UnityEngine.Random.Range(0, num + 1);
				int index = num2;
				int index2 = num;
				T val = list[num];
				T val2 = list[num2];
				T val3 = (list[index] = val);
				val3 = (list[index2] = val2);
			}
		}
	}
}
