using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SelectMany<TEnumerator, TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private FromEnumerable<TResult> innerEnumerator;

		private bool hasInner;

		public SelectMany(TEnumerator source, Func<TSource, IEnumerable<TResult>> selector)
		{
			_003Cselector_003EP = selector;
			innerEnumerator = default(FromEnumerable<TResult>);
			this.source = source;
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
					if (innerEnumerator.TryGetNext(out current))
					{
						return true;
					}
					innerEnumerator.Dispose();
					hasInner = false;
				}
				if (!source.TryGetNext(out TSource current2))
				{
					break;
				}
				innerEnumerator = _003Cselector_003EP(current2).AsValueEnumerable().Enumerator;
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
	public struct SelectMany<TEnumerator, TEnumerator2, TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TResult>
	{
		private TEnumerator source;

		private TEnumerator2 innerEnumerator;

		private bool hasInner;

		public SelectMany(TEnumerator source, Func<TSource, ValueEnumerable<TEnumerator2, TResult>> selector)
		{
			_003Cselector_003EP = selector;
			innerEnumerator = default(TEnumerator2);
			this.source = source;
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
					if (innerEnumerator.TryGetNext(out current))
					{
						return true;
					}
					innerEnumerator.Dispose();
					hasInner = false;
				}
				if (!source.TryGetNext(out TSource current2))
				{
					break;
				}
				innerEnumerator = _003Cselector_003EP(current2).Enumerator;
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
