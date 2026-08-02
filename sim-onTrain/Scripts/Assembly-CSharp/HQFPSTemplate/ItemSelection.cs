using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate
{
	public static class ItemSelection
	{
		public enum Method
		{
			Random = 0,
			RandomExcludeLast = 1,
			Sequence = 2
		}

		public static T Select<T>(this T[] array, ref int last, Method selectionMethod = Method.Random)
		{
			if (array == null || array.Length == 0)
			{
				return default(T);
			}
			int num = 0;
			if (selectionMethod == Method.Random)
			{
				num = Random.Range(0, array.Length);
			}
			else if (selectionMethod == Method.RandomExcludeLast && array.Length > 1)
			{
				last = Mathf.Clamp(last, 0, array.Length - 1);
				T val = array[0];
				array[0] = array[last];
				array[last] = val;
				num = Random.Range(1, array.Length);
			}
			else if (selectionMethod == Method.Sequence)
			{
				num = (int)Mathf.Repeat(last + 1, array.Length);
			}
			last = num;
			return array[num];
		}

		public static T Select<T>(this List<T> list, ref int last, Method selectionMethod = Method.Random)
		{
			if (list == null || list.Count == 0)
			{
				return default(T);
			}
			int num = 0;
			if (selectionMethod == Method.Random)
			{
				num = Random.Range(0, list.Count);
			}
			else if (selectionMethod == Method.RandomExcludeLast && list.Count > 1)
			{
				last = Mathf.Clamp(last, 0, list.Count - 1);
				T value = list[0];
				list[0] = list[last];
				list[last] = value;
				num = Random.Range(1, list.Count);
			}
			else if (selectionMethod == Method.Sequence)
			{
				num = (int)Mathf.Repeat(last + 1, list.Count);
			}
			last = num;
			return list[num];
		}
	}
}
