using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct OrderBySkipTake<TEnumerator, TSource, TKey> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private OrderByComparable<TSource, TKey> comparable;

		private int minIndexInclusive;

		private int maxIndexInclusive;

		private RentedArrayBox<TSource>? buffer;

		private RentedArrayBox<int>? indexMap;

		private int maxIndex;

		private int index;

		public OrderBySkipTake(OrderBy<TEnumerator, TSource, TKey> orderBy, int minIndexInclusive, int maxIndexInclusive)
		{
			buffer = null;
			indexMap = null;
			maxIndex = 0;
			index = 0;
			source = orderBy.source;
			comparable = orderBy.comparable;
			this.minIndexInclusive = minIndexInclusive;
			this.maxIndexInclusive = maxIndexInclusive;
		}

		private OrderBySkipTake(TEnumerator source, OrderByComparable<TSource, TKey> comparable, int minIndexInclusive, int maxIndexInclusive)
		{
			buffer = null;
			indexMap = null;
			maxIndex = 0;
			index = 0;
			this.source = source;
			this.comparable = comparable;
			this.minIndexInclusive = minIndexInclusive;
			this.maxIndexInclusive = maxIndexInclusive;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out count))
			{
				if (count <= minIndexInclusive)
				{
					count = 0;
					return true;
				}
				count = ((count <= maxIndexInclusive) ? count : (maxIndexInclusive + 1)) - minIndexInclusive;
				return true;
			}
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			InitBuffer();
			if (indexMap != null && EnumeratorHelper.TryGetSlice((ReadOnlySpan<int>)indexMap.Span.Slice(minIndexInclusive, (int)Math.Min((uint)maxIndexInclusive - minIndexInclusive + 1, (uint)indexMap.Span.Length - minIndexInclusive)), offset, destination.Length, out ReadOnlySpan<int> slice))
			{
				for (int i = 0; (uint)i < (uint)slice.Length; i++)
				{
					destination[i] = buffer.UnsafeGetAt(slice[i]);
				}
				return true;
			}
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			RentedArrayBox<TSource> rentedArrayBox = buffer;
			if (rentedArrayBox == null)
			{
				InitBuffer();
				rentedArrayBox = buffer;
			}
			int num = index + minIndexInclusive;
			RentedArrayBox<int> rentedArrayBox2 = indexMap;
			if (rentedArrayBox2 != null && num <= maxIndex)
			{
				current = rentedArrayBox.UnsafeGetAt(rentedArrayBox2.UnsafeGetAt(num));
				index++;
				return true;
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			buffer?.Dispose();
			indexMap?.Dispose();
			source.Dispose();
		}

		[MemberNotNull("buffer")]
		private void InitBuffer()
		{
			if (buffer == null)
			{
				new ValueEnumerable<TEnumerator, TSource>(source).ToArrayPool().Deconstruct(out TSource[] array, out int size);
				TSource[] array2 = array;
				int length = size;
				buffer = new RentedArrayBox<TSource>(array2, length);
				Sort(buffer.Span);
			}
		}

		private void Sort(ReadOnlySpan<TSource> span)
		{
			int length = span.Length;
			if (length > minIndexInclusive)
			{
				maxIndex = maxIndexInclusive;
				if (length <= maxIndex)
				{
					maxIndex = length - 1;
				}
				ValueEnumerable.Range(0, span.Length).ToArrayPool().Deconstruct(out int[] array, out int size);
				int[] array2 = array;
				int num = size;
				indexMap = new RentedArrayBox<int>(array2, num);
				using IOrderByComparer comparer = comparable.GetComparer(span, null);
				_003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__OrderByHelper.PartialQuickSort(array2, comparer, 0, num - 1, minIndexInclusive, maxIndex);
			}
		}

		internal OrderBySkipTake<TEnumerator, TSource, TKey> Skip(int count)
		{
			int num = minIndexInclusive + count;
			if ((uint)num > (uint)maxIndexInclusive)
			{
				return new OrderBySkipTake<TEnumerator, TSource, TKey>(source, comparable, 0, -1);
			}
			return new OrderBySkipTake<TEnumerator, TSource, TKey>(source, comparable, num, maxIndexInclusive);
		}

		internal OrderBySkipTake<TEnumerator, TSource, TKey> Take(int count)
		{
			if (count <= 0)
			{
				return new OrderBySkipTake<TEnumerator, TSource, TKey>(source, comparable, 0, -1);
			}
			int num = minIndexInclusive + count - 1;
			if (num < minIndexInclusive || num >= maxIndexInclusive)
			{
				return this;
			}
			return new OrderBySkipTake<TEnumerator, TSource, TKey>(source, comparable, minIndexInclusive, num);
		}
	}
}
