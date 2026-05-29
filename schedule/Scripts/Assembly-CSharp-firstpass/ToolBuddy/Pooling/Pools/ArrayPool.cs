using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;

namespace ToolBuddy.Pooling.Pools
{
	public class ArrayPool<T>
	{
		private readonly SubArray<T> emptySubArray;

		private readonly Random random;

		private const int keysInitialCapacity = 200;

		private int[] poolKeys;

		private T[][] poolValues;

		private int arraysCount;

		private long elementsCount;

		private long elementsCapacity;

		public long ElementsCapacity
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public bool LogAllocations { get; set; }

		public ArrayPoolUsageData UsageData => default(ArrayPoolUsageData);

		public ArrayPool(long elementsCapacity)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SubArray<T> Allocate(int minimalSize, bool clearArray = true)
		{
			return default(SubArray<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SubArray<T> AllocateExactSize(int exactSize, bool clearArray = true)
		{
			return default(SubArray<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Free(SubArray<T> subArray)
		{
		}

		public void Free([NotNull] T[] array)
		{
		}

		public void Resize(ref SubArray<T> subArray, int newMinimalSize, bool clearNewSpace = true)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ResizeAndClear(ref SubArray<T> subArray, int newMinimalSize)
		{
		}

		public void ResizeCopyless(ref SubArray<T> subArray, int newMinimalSize)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SubArray<T> Clone(T[] source)
		{
			return default(SubArray<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SubArray<T> Clone(SubArray<T> source)
		{
			return default(SubArray<T>);
		}

		private SubArray<T> Allocate(int size, bool exactSize, bool clearArray, out bool isArrayCleared)
		{
			isArrayCleared = default(bool);
			return default(SubArray<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ApplyCapacity(long capacity)
		{
		}

		private T[] RemoveElementAt(int elementIndex)
		{
			return null;
		}

		private static int BinarySearch(int[] array, int length, int value)
		{
			return 0;
		}
	}
}
