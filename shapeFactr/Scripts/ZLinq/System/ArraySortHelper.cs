using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
	internal sealed class ArraySortHelper<T> where T : notnull
	{
		private const int IntrosortSizeThreshold = 16;

		public static void Sort(Span<T> keys, IComparer<T>? comparer)
		{
		}

		private static void SwapIfGreater(Span<T> keys, Comparison<T> comparer, int i, int j)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Swap(Span<T> a, int i, int j)
		{
		}

		internal static void IntrospectiveSort(Span<T> keys, Comparison<T> comparer)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void IntroSort(Span<T> keys, int depthLimit, Comparison<T> comparer)
		{
		}

		private static int PickPivotAndPartition(Span<T> keys, Comparison<T> comparer)
		{
			return 0;
		}

		private static void HeapSort(Span<T> keys, Comparison<T> comparer)
		{
		}

		private static void DownHeap(Span<T> keys, int i, int n, Comparison<T> comparer)
		{
		}

		private static void InsertionSort(Span<T> keys, Comparison<T> comparer)
		{
		}
	}
	internal static class ArraySortHelper<TKey, TValue> where TKey : notnull where TValue : notnull
	{
		private const int IntrosortSizeThreshold = 16;

		public static void Sort(Span<TKey> keys, Span<TValue> values, IComparer<TKey>? comparer)
		{
		}

		private static void SwapIfGreaterWithValues(Span<TKey> keys, Span<TValue> values, IComparer<TKey> comparer, int i, int j)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Swap(Span<TKey> keys, Span<TValue> values, int i, int j)
		{
		}

		internal static void IntrospectiveSort(Span<TKey> keys, Span<TValue> values, IComparer<TKey> comparer)
		{
		}

		private static void IntroSort(Span<TKey> keys, Span<TValue> values, int depthLimit, IComparer<TKey> comparer)
		{
		}

		private static int PickPivotAndPartition(Span<TKey> keys, Span<TValue> values, IComparer<TKey> comparer)
		{
			return 0;
		}

		private static void HeapSort(Span<TKey> keys, Span<TValue> values, IComparer<TKey> comparer)
		{
		}

		private static void DownHeap(Span<TKey> keys, Span<TValue> values, int i, int n, IComparer<TKey> comparer)
		{
		}

		private static void InsertionSort(Span<TKey> keys, Span<TValue> values, IComparer<TKey> comparer)
		{
		}
	}
}
