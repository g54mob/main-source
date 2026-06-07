using System;
using System.Collections.Generic;

public static class Sorting
{
	public static void SlowSort<T>(List<T> listToSort) where T : IComparable<T>
	{
		int count = listToSort.Count;
		if (count == 0)
		{
			return;
		}
		List<T> list = ListPool<T>.Get(count);
		list.Add(listToSort[0]);
		for (int i = 1; i < count; i++)
		{
			T val = listToSort[i];
			int j;
			for (j = 0; j < list.Count; j++)
			{
				if (list[j].CompareTo(val) > 0)
				{
					list.Insert(j, val);
					break;
				}
			}
			if (j == list.Count)
			{
				list.Add(val);
			}
		}
		for (int k = 0; k < count; k++)
		{
			listToSort[k] = list[k];
		}
		ListPool<T>.Add(list);
	}

	public static void SlowSort<T>(List<T> listToSort, IComparer<T> comparer)
	{
		int count = listToSort.Count;
		if (count == 0)
		{
			return;
		}
		List<T> list = ListPool<T>.Get(count);
		list.Add(listToSort[0]);
		for (int i = 1; i < count; i++)
		{
			T val = listToSort[i];
			int j;
			for (j = 0; j < list.Count; j++)
			{
				if (comparer.Compare(list[j], val) > 0)
				{
					list.Insert(j, val);
					break;
				}
			}
			if (j == list.Count)
			{
				list.Add(val);
			}
		}
		for (int k = 0; k < count; k++)
		{
			listToSort[k] = list[k];
		}
		ListPool<T>.Add(list);
	}

	public static void SlowSort<T>(List<T> listToSort, Comparison<T> comparison)
	{
		int count = listToSort.Count;
		if (count == 0)
		{
			return;
		}
		List<T> list = ListPool<T>.Get(count);
		list.Add(listToSort[0]);
		for (int i = 1; i < count; i++)
		{
			T val = listToSort[i];
			int j;
			for (j = 0; j < list.Count; j++)
			{
				if (comparison(list[j], val) > 0)
				{
					list.Insert(j, val);
					break;
				}
			}
			if (j == list.Count)
			{
				list.Add(val);
			}
		}
		for (int k = 0; k < count; k++)
		{
			listToSort[k] = list[k];
		}
		ListPool<T>.Add(list);
	}
}
