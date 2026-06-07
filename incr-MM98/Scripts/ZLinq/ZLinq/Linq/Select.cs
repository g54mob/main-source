using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Select<TEnumerator, TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		internal TEnumerator source;

		internal readonly Func<TSource, TResult> selector;

		public Select(TEnumerator source, Func<TSource, TResult> selector)
		{
			this.source = source;
			this.selector = selector;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			return source.TryGetNonEnumeratedCount(out count);
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TResult> destination, Index offset)
		{
			if (source.TryGetSpan(out ReadOnlySpan<TSource> span) && EnumeratorHelper.TryGetSlice(span, offset, destination.Length, out var slice))
			{
				for (int i = 0; (uint)i < (uint)slice.Length; i++)
				{
					destination[i] = selector(slice[i]);
				}
				return true;
			}
			if (destination.Length == 1)
			{
				TSource reference = default(TSource);
				if (source.TryCopyTo(SingleSpan.Create(ref reference), offset))
				{
					destination[0] = selector(reference);
					return true;
				}
				if (EnumeratorHelper.TryConsumeGetAt<TEnumerator, TSource>(ref source, offset, out var value))
				{
					destination[0] = selector(value);
					return true;
				}
			}
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			if (source.TryGetNext(out TSource current2))
			{
				current = selector(current2);
				return true;
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
		}

		internal SelectWhere<TEnumerator, TSource, TResult> Where(Func<TResult, bool> predicate)
		{
			return new SelectWhere<TEnumerator, TSource, TResult>(source, selector, predicate);
		}
	}
}
