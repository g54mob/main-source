using System;
using DV.Utils;
using UnityEngine;

public static class RaycastUtils
{
	private const int EXPAND_LIMIT = 64;

	private static readonly Comparison<RaycastHit> comparison = (RaycastHit a, RaycastHit b) => a.distance.CompareTo(b.distance);

	public static void SortByDistance(this RaycastHit[] array, int hitCount)
	{
		QuickSort.Sort(array, 0, hitCount, comparison);
	}

	public static bool ExtendOnCacheFull<T>(ref T[] array, int hitCount, int expandLimit = 64)
	{
		if (array.Length > Mathf.Min(hitCount, expandLimit - 1))
		{
			return false;
		}
		Array.Resize(ref array, Mathf.Min(array.Length * 2, expandLimit));
		return true;
	}

	public static bool SortDistanceAndExpandCache(ref RaycastHit[] array, int hitCount, int expandLimit = 64)
	{
		if (hitCount == 0)
		{
			return false;
		}
		array.SortByDistance(hitCount);
		return ExtendOnCacheFull(ref array, hitCount, expandLimit);
	}
}
