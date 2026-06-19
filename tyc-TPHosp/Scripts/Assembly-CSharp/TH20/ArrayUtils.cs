using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public static class ArrayUtils
	{
		public static void Populate<T>(T[,] arr, T value)
		{
			for (int i = 0; i < arr.GetLength(1); i++)
			{
				for (int j = 0; j < arr.GetLength(0); j++)
				{
					arr[j, i] = value;
				}
			}
		}

		public static void Populate<T>(T[] arr, T value)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = value;
			}
		}

		public static T Get<T>(T[,] arr, int x, int y, T nullVal)
		{
			if (x >= 0 && x < arr.GetLength(0) && y >= 0 && y < arr.GetLength(1))
			{
				return arr[x, y];
			}
			return nullVal;
		}

		public static void Set<T>(T[,] arr, int x, int y, T value)
		{
			if (x >= 0 && x < arr.GetLength(0) && y >= 0 && y < arr.GetLength(1))
			{
				arr[x, y] = value;
			}
		}

		public static void CopyTo<T>(this T[,] arr, T[,] other)
		{
			for (int i = 0; i < arr.GetLength(1); i++)
			{
				for (int j = 0; j < arr.GetLength(0); j++)
				{
					other[j, i] = arr[j, i];
				}
			}
		}

		public static bool AddUnique<T>(this List<T> list, T item)
		{
			if (list.Contains(item))
			{
				return false;
			}
			list.Add(item);
			return true;
		}

		public static void ClearAndDestroy<T>(this List<T> list) where T : UnityEngine.Object
		{
			if (list == null)
			{
				return;
			}
			foreach (T item in list)
			{
				UnityEngine.Object.Destroy(item);
			}
			list.Clear();
		}

		public static void ClearAndDestroyImmediate<T>(this List<T> list) where T : UnityEngine.Object
		{
			if (list == null)
			{
				return;
			}
			foreach (T item in list)
			{
				UnityEngine.Object.DestroyImmediate(item);
			}
			list.Clear();
		}

		public static void DestroyAll<T>(this T[] array) where T : UnityEngine.Object
		{
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					UnityEngine.Object.Destroy(array[i]);
				}
			}
		}

		public static void ClearAndDestroy(this List<Transform> list)
		{
			if (list == null)
			{
				return;
			}
			foreach (Transform item in list)
			{
				if ((bool)item && (bool)item.gameObject)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			list.Clear();
		}

		public static void ClearAndCallDestroy<T>(this List<T> list) where T : MustCallDestroy
		{
			if (list != null)
			{
				while (list.Count != 0)
				{
					list.Pop().Destroy();
				}
			}
		}

		public static void CallDestroy<T>(this T[] array) where T : MustCallDestroy
		{
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Destroy();
				}
			}
		}

		public static T Pop<T>(this List<T> list)
		{
			if (list == null || list.Count == 0)
			{
				throw new Debug.AssertException("Empty list");
			}
			T result = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
			return result;
		}

		public static T RandomItem<T>(this List<T> list)
		{
			if (list == null || list.Count == 0)
			{
				throw new Debug.AssertException("Empty list");
			}
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public static T RandomItem<T>(this List<T> list, System.Random random)
		{
			if (list == null || list.Count == 0)
			{
				throw new Debug.AssertException("Empty list");
			}
			return list[random.Next(0, list.Count)];
		}

		public static T RandomItem<T>(this T[] list)
		{
			if (list == null || list.Length == 0)
			{
				throw new Debug.AssertException("Empty list");
			}
			return list[UnityEngine.Random.Range(0, list.Length)];
		}

		public static T WeightedRandomItemSelectImpl<T>(List<T> list, Func<T, float> weight, float totalWeight, float weightedDieRoll) where T : class
		{
			if (Mathf.Approximately(totalWeight, 0f))
			{
				return null;
			}
			float num = 0f;
			for (int i = 0; i < list.Count; i++)
			{
				num += weight(list[i]);
				if (weightedDieRoll <= num)
				{
					return list[i];
				}
			}
			return null;
		}

		public static T WeightedRandomItem<T>(this List<T> list, Func<T, float> weight) where T : class
		{
			float num = 0f;
			for (int i = 0; i < list.Count; i++)
			{
				num += weight(list[i]);
			}
			float weightedDieRoll = UnityEngine.Random.Range(0f, num);
			return WeightedRandomItemSelectImpl(list, weight, num, weightedDieRoll);
		}

		public static T FindLowest<T>(this T[] array, Func<T, float> getValue)
		{
			return array.FindLowest(0, array.Length, getValue);
		}

		public static T FindLowest<T>(this T[] array, int index, int count, Func<T, float> getValue)
		{
			T result = default(T);
			float num = float.PositiveInfinity;
			for (int i = index; i < index + count; i++)
			{
				float num2 = getValue(array[i]);
				if (num2 < num)
				{
					num = num2;
					result = array[i];
				}
			}
			return result;
		}

		public static bool TrueForAll<T>(this T[] array, Func<T, bool> getValue)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (!getValue(array[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static void Shuffle<T>(this IList<T> list, System.Random rng)
		{
			int num = list.Count;
			while (num > 1)
			{
				num--;
				int index = rng.Next(num + 1);
				T value = list[index];
				list[index] = list[num];
				list[num] = value;
			}
		}

		public static bool AreEqual<T>(this List<T> list, List<T> otherList) where T : class
		{
			if (list.Count != otherList.Count)
			{
				return false;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != otherList[i])
				{
					return false;
				}
			}
			return true;
		}

		public static void FlipVertically<T>(this T[] array, int width, int height)
		{
			for (int i = 0; i < height / 2; i++)
			{
				int num = i * width;
				int num2 = (height - 1 - i) * width;
				for (int j = 0; j < width; j++)
				{
					MathUtils.Swap(ref array[j + num], ref array[j + num2]);
				}
			}
		}

		public static int IndexOf<T>(this T[] array, T obj) where T : class
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == obj)
				{
					return i;
				}
			}
			return -1;
		}

		public static bool ValidIndex<T>(this T[] array, int index)
		{
			if (array != null)
			{
				return MathUtils.IsInRange(index, 0, array.Length - 1);
			}
			return false;
		}

		public static bool ValidIndex<T>(this T[,] array, int x, int y)
		{
			if (array != null && MathUtils.IsInRange(x, 0, array.GetLength(0) - 1))
			{
				return MathUtils.IsInRange(y, 0, array.GetLength(1) - 1);
			}
			return false;
		}

		public static bool IsEmpty<T>(this T[] array)
		{
			if (array != null)
			{
				return array.Length == 0;
			}
			return true;
		}

		public static void RemoveAll<K, V>(this Dictionary<K, V> dict, Func<KeyValuePair<K, V>, bool> predicate)
		{
			List<KeyValuePair<K, V>> list = new List<KeyValuePair<K, V>>();
			foreach (KeyValuePair<K, V> item in dict)
			{
				if (predicate(item))
				{
					list.Add(item);
				}
			}
			foreach (KeyValuePair<K, V> item2 in list)
			{
				dict.Remove(item2.Key);
			}
		}

		public static void AddRangeUnique<T>(this List<T> list, List<T> range)
		{
			foreach (T item in range)
			{
				list.AddUnique(item);
			}
		}

		public static void RemoveDuplicates<T>(this List<T> list)
		{
			List<T> list2 = new List<T>();
			foreach (T item in list)
			{
				list2.AddUnique(item);
			}
			list.Clear();
			list.AddRange(list2);
		}
	}
}
