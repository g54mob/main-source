using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class ListExtensions
	{
		public static T GetRandom<T>(this IList<T> list)
		{
			if (list == null || list.Count <= 0)
			{
				return default(T);
			}
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public static T GetRandom<T>(this ReadOnlyList<T> list)
		{
			if (list.Count <= 0)
			{
				return default(T);
			}
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public static T GetRandom<T>(this ReadOnlyArray<T> list)
		{
			if (list.Count <= 0)
			{
				return default(T);
			}
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public static T GetRandom<T>(this T[] array)
		{
			if (array == null || array.Length == 0)
			{
				return default(T);
			}
			return array[UnityEngine.Random.Range(0, array.Length)];
		}

		public static int GetRandomIndex(this IList list)
		{
			if (list == null || list.Count <= 0)
			{
				return -1;
			}
			return UnityEngine.Random.Range(0, list.Count);
		}

		public static int IndexOf<T>(this IList<T> list, T predicate)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Equals(predicate))
				{
					return i;
				}
			}
			return -1;
		}

		public static TObject GetFirst<TObject, TArg>(this IList<TObject> array, Func<TObject, TArg, bool> filter, TArg arg)
		{
			if (array == null || array.Count <= 0)
			{
				return default(TObject);
			}
			foreach (TObject item in array)
			{
				if (filter(item, arg))
				{
					return item;
				}
			}
			return default(TObject);
		}

		public static TObject GetFirst<TObject, TArg1, TArg2>(this IList<TObject> array, Func<TObject, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2)
		{
			if (array == null || array.Count <= 0)
			{
				return default(TObject);
			}
			foreach (TObject item in array)
			{
				if (filter(item, arg1, arg2))
				{
					return item;
				}
			}
			return default(TObject);
		}

		public static TObject GetFirst<TObject, TArg1, TArg2, TArg3>(this IList<TObject> array, Func<TObject, TArg1, TArg2, TArg3, bool> filter, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			if (array == null || array.Count <= 0)
			{
				return default(TObject);
			}
			foreach (TObject item in array)
			{
				if (filter(item, arg1, arg2, arg3))
				{
					return item;
				}
			}
			return default(TObject);
		}

		public static TObject GetFirst<TObject, TArg>(this TObject[] array, Func<TObject, TArg, bool> filter, TArg arg)
		{
			if (array == null || array.Length == 0)
			{
				return default(TObject);
			}
			foreach (TObject val in array)
			{
				if (filter(val, arg))
				{
					return val;
				}
			}
			return default(TObject);
		}

		public static void Shuffle<T>(this IList<T> list)
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

		public static T GetNearest<T>(this IEnumerable<T> p_list, Vector2 p_position) where T : Component
		{
			float num = float.MaxValue;
			T result = null;
			foreach (T item in p_list)
			{
				float sqrMagnitude = (item.transform.position.ToHorizontal2D() - p_position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = item;
				}
			}
			return result;
		}

		public static T GetNearest<T>(this IEnumerable<T> p_list, Vector2 p_position, Func<T, bool> filter) where T : Component
		{
			float num = float.MaxValue;
			T result = null;
			foreach (T item in p_list)
			{
				if (filter(item))
				{
					float sqrMagnitude = (item.transform.position.ToHorizontal2D() - p_position).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						result = item;
					}
				}
			}
			return result;
		}

		public static T GetNearest<T, TArg>(this IEnumerable<T> p_list, Vector2 p_position, Func<T, TArg, bool> filter, TArg filterArg) where T : Component
		{
			float num = float.MaxValue;
			T result = null;
			foreach (T item in p_list)
			{
				if (filter(item, filterArg))
				{
					float sqrMagnitude = (item.transform.position.ToHorizontal2D() - p_position).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						result = item;
					}
				}
			}
			return result;
		}

		public static T GetNearest<T, TArg1, TArg2>(this IEnumerable<T> p_list, Vector2 p_position, Func<T, TArg1, TArg2, bool> filter, TArg1 filterArg1, TArg2 filterArg2) where T : Component
		{
			float num = float.MaxValue;
			T result = null;
			foreach (T item in p_list)
			{
				if (filter(item, filterArg1, filterArg2))
				{
					float sqrMagnitude = (item.transform.position.ToHorizontal2D() - p_position).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						result = item;
					}
				}
			}
			return result;
		}
	}
}
