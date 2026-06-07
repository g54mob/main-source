using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct OrderBy<TEnumerator, TSource, TKey> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
	{
		internal TEnumerator source;

		internal OrderByComparable<TSource, TKey> comparable;

		private RentedArrayBox<TSource>? buffer;

		private int index;

		public OrderBy(TEnumerator source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer, IOrderByComparable<TSource>? parent, bool descending)
		{
			_003CkeySelector_003EP = null;
			_003Ccomparer_003EP = null;
			_003Cparent_003EP = null;
			_003Cdescending_003EP = false;
			this.source = default(TEnumerator);
			comparable = null;
			buffer = null;
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

		private void Sort(Span<TSource> span)
		{
		}

		public OrderBy<TEnumerator, TSource, TSecondKey> ThenBy<TSecondKey>(Func<TSource, TSecondKey> keySelector, IComparer<TSecondKey>? comparer = null) where TSecondKey : notnull
		{
			return default(OrderBy<TEnumerator, TSource, TSecondKey>);
		}

		public OrderBy<TEnumerator, TSource, TSecondKey> ThenByDescending<TSecondKey>(Func<TSource, TSecondKey> keySelector, IComparer<TSecondKey>? comparer = null) where TSecondKey : notnull
		{
			return default(OrderBy<TEnumerator, TSource, TSecondKey>);
		}

		private bool IsAllowDirectSort()
		{
			return false;
		}
	}
}
