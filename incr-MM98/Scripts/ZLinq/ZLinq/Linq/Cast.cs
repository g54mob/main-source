using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Cast<TEnumerator, TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		public Cast(TEnumerator source)
		{
			this.source = source;
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
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			if (source.TryGetNext(out TSource current2))
			{
				current = (TResult)(object)current2;
				return true;
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
		}
	}
}
