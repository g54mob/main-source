using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SelectMany4<TEnumerator, TEnumerator2, TSource, TCollection, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TCollection>
	{
		private TEnumerator source;

		private TEnumerator2 innerEnumerator;

		private TSource currentSource;

		private int index;

		private bool hasInner;

		public SelectMany4(TEnumerator source, Func<TSource, int, ValueEnumerable<TEnumerator2, TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			_003CcollectionSelector_003EP = null;
			_003CresultSelector_003EP = null;
			this.source = default(TEnumerator);
			innerEnumerator = default(TEnumerator2);
			currentSource = default(TSource);
			index = 0;
			hasInner = false;
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
	public struct SelectMany4<TEnumerator, TSource, TCollection, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TCollection : notnull where TResult : notnull
	{
		private TEnumerator source;

		private FromEnumerable<TCollection> innerEnumerator;

		private TSource currentSource;

		private int index;

		private bool hasInner;

		public SelectMany4(TEnumerator source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			_003CcollectionSelector_003EP = null;
			_003CresultSelector_003EP = null;
			this.source = default(TEnumerator);
			innerEnumerator = default(FromEnumerable<TCollection>);
			currentSource = default(TSource);
			index = 0;
			hasInner = false;
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
