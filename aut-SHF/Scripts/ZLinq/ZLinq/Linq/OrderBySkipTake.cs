using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
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
			source = default(TEnumerator);
			comparable = null;
			this.minIndexInclusive = 0;
			this.maxIndexInclusive = 0;
			buffer = null;
			indexMap = null;
			maxIndex = 0;
			index = 0;
		}

		private OrderBySkipTake(TEnumerator source, OrderByComparable<TSource, TKey> comparable, int minIndexInclusive, int maxIndexInclusive)
		{
			this.source = default(TEnumerator);
			this.comparable = null;
			this.minIndexInclusive = 0;
			this.maxIndexInclusive = 0;
			buffer = null;
			indexMap = null;
			maxIndex = 0;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo(Span<TSource> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			current = default(TSource);
			return false;
		}

		public void Dispose()
		{
		}

		[MemberNotNull("buffer")]
		private void InitBuffer()
		{
		}

		private void Sort(ReadOnlySpan<TSource> span)
		{
		}

		internal OrderBySkipTake<TEnumerator, TSource, TKey> Skip(int count)
		{
			return default(OrderBySkipTake<TEnumerator, TSource, TKey>);
		}

		internal OrderBySkipTake<TEnumerator, TSource, TKey> Take(int count)
		{
			return default(OrderBySkipTake<TEnumerator, TSource, TKey>);
		}
	}
}
