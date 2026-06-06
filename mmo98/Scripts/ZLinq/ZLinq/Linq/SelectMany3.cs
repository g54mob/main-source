using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SelectMany3<TEnumerator, TEnumerator2, TSource, TCollection, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TCollection>
	{
		private TEnumerator source;

		private TEnumerator2 innerEnumerator;

		private TSource currentSource;

		private bool hasInner;

		public SelectMany3(TEnumerator source, Func<TSource, ValueEnumerable<TEnumerator2, TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			_003CcollectionSelector_003EP = collectionSelector;
			_003CresultSelector_003EP = resultSelector;
			innerEnumerator = default(TEnumerator2);
			this.source = source;
			currentSource = default(TSource);
			hasInner = false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			while (true)
			{
				if (hasInner)
				{
					if (innerEnumerator.TryGetNext(out TCollection current2))
					{
						current = _003CresultSelector_003EP(currentSource, current2);
						return true;
					}
					innerEnumerator.Dispose();
					hasInner = false;
				}
				if (!source.TryGetNext(out TSource current3))
				{
					break;
				}
				currentSource = current3;
				innerEnumerator = _003CcollectionSelector_003EP(current3).Enumerator;
				hasInner = true;
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
			if (hasInner)
			{
				innerEnumerator.Dispose();
			}
			source.Dispose();
		}
	}
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SelectMany3<TEnumerator, TSource, TCollection, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private FromEnumerable<TCollection> innerEnumerator;

		private TSource currentSource;

		private bool hasInner;

		public SelectMany3(TEnumerator source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			_003CcollectionSelector_003EP = collectionSelector;
			_003CresultSelector_003EP = resultSelector;
			innerEnumerator = default(FromEnumerable<TCollection>);
			this.source = source;
			currentSource = default(TSource);
			hasInner = false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			while (true)
			{
				if (hasInner)
				{
					if (innerEnumerator.TryGetNext(out var current2))
					{
						current = _003CresultSelector_003EP(currentSource, current2);
						return true;
					}
					innerEnumerator.Dispose();
					hasInner = false;
				}
				if (!source.TryGetNext(out TSource current3))
				{
					break;
				}
				currentSource = current3;
				innerEnumerator = _003CcollectionSelector_003EP(current3).AsValueEnumerable().Enumerator;
				hasInner = true;
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
			if (hasInner)
			{
				innerEnumerator.Dispose();
			}
			source.Dispose();
		}
	}
}
