using System;
using System.Collections.Generic;

public static class ListUtl
{
	public static void Shuffle<T>(this List<T> ts, Random rnd)
	{
	}

	public static void Shuffle<T>(this T[] ts, Random rnd)
	{
	}

	public static List<T> PickRandomElements<T>(T[] list, int nElements, Random rnd = null)
	{
		return null;
	}

	public static List<T> PickRandomElements<T>(this List<T> list, int nElements, Random rnd = null)
	{
		return null;
	}

	public static T PickItemClamped<T>(this T[] list, int idx)
	{
		return default(T);
	}

	public static List<T> PickRandomItems<T>(this List<T> list, int nElements, Random rnd)
	{
		return null;
	}

	public static List<T> PickRandomItems<T>(this List<T> list, List<T> list2, int nElements, Random rnd)
	{
		return null;
	}

	public static int PickRandomIdx<T>(this List<T> l1, Random rnd = null)
	{
		return 0;
	}

	public static T PickRandomItem<T>(this T[] l1, Random rnd = null)
	{
		return default(T);
	}

	public static T PickRandomItem<T>(this List<T> l1, Random rnd = null)
	{
		return default(T);
	}

	public static T PickRandomItem<T>(List<T> l1, List<T> l2, Random rnd)
	{
		return default(T);
	}

	public static T PickRandomItem<T>(T[] l1, T[] l2, Random rnd)
	{
		return default(T);
	}

	public static T GetLastItem<T>(this List<T> list)
	{
		return default(T);
	}

	public static T GetLastItem<T>(this T[] list)
	{
		return default(T);
	}

	public static T[] GrowArrayIfNeeded<T>(this T[] list, int minSize)
	{
		return null;
	}

	public static T[] ResizeArray<T>(this T[] list, int newSize)
	{
		return null;
	}

	public static void SwapIdxes<T>(this T[] list, int idx1, int idx2)
	{
	}

	public static void MoveIdxToEnd<T>(this T[] list, int idx)
	{
	}

	public static void ShiftIdxToEnd<T>(this T[] list, int idx)
	{
	}

	public static void ShiftIdxToIdx<T>(this T[] list, int fromIdx, int toIdx)
	{
	}

	public static void PickRandomSetInRange(int numItems, int numToPick, Random rnd, List<int> outList)
	{
	}

	public static int IndexOf<T>(this T[] list, T toFind)
	{
		return 0;
	}
}
