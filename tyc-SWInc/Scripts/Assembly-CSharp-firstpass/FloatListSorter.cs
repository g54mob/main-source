using System;
using System.Collections.Generic;

public static class FloatListSorter
{
	public static void SortByFloatKeys<T>(List<T> items, List<float> keys)
	{
		if (items.Count != keys.Count)
		{
			throw new ArgumentException("Items and keys must be the same length.");
		}
		QuickSort(items, keys, 0, items.Count - 1);
	}

	private static void QuickSort<T>(List<T> items, List<float> keys, int left, int right)
	{
		if (left < right)
		{
			int num = Partition(items, keys, left, right);
			QuickSort(items, keys, left, num - 1);
			QuickSort(items, keys, num + 1, right);
		}
	}

	private static int Partition<T>(List<T> items, List<float> keys, int left, int right)
	{
		float num = keys[right];
		int num2 = left - 1;
		for (int i = left; i < right; i++)
		{
			if (keys[i] <= num)
			{
				num2++;
				Swap(items, keys, num2, i);
			}
		}
		Swap(items, keys, num2 + 1, right);
		return num2 + 1;
	}

	private static void Swap<T>(List<T> items, List<float> keys, int i, int j)
	{
		T value = items[i];
		items[i] = items[j];
		items[j] = value;
		float value2 = keys[i];
		keys[i] = keys[j];
		keys[j] = value2;
	}
}
