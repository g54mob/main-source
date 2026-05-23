using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SelectMany2<TEnumerator, TEnumerator2, TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TResult>
	{
		private TEnumerator source;

		private TEnumerator2 innerEnumerator;

		private bool hasInner;

		private int index;

		public SelectMany2(TEnumerator source, Func<TSource, int, ValueEnumerable<TEnumerator2, TResult>> selector)
		{
			_003Cselector_003EP = null;
			this.source = default(TEnumerator);
			innerEnumerator = default(TEnumerator2);
			hasInner = false;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo(Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			current = default(TResult);
			return false;
		}

		public void Dispose()
		{
		}
	}
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SelectMany2<TEnumerator, TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private FromEnumerable<TResult> innerEnumerator;

		private bool hasInner;

		private int index;

		public SelectMany2(TEnumerator source, Func<TSource, int, IEnumerable<TResult>> selector)
		{
			_003Cselector_003EP = null;
			this.source = default(TEnumerator);
			innerEnumerator = default(FromEnumerable<TResult>);
			hasInner = false;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo(Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			current = default(TResult);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
