using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

public class QuickSelect
{
	private static void swap<T>(List<T> arr, int i, int j)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
	[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
	private static void swap<T>(T[] arr, int i, int j)
	{
	}

	private static int defaultCompare<T>(T a, T b)
	{
		return 0;
	}

	public static void DoQuickSelect<T>(ref ListAccessor<T> list, int k, int left = 0, int right = -1, Comparison<T> compare = null)
	{
	}
}
