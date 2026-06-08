using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace KitchenData
{
	public static class RandomExtensions
	{
		public static T Random<T>(this List<T> list)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
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
	}
}
