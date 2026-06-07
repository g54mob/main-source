using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct DefaultIfEmpty<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private bool iterateDefault;

		public DefaultIfEmpty(TEnumerator source, TSource defaultValue)
		{
			_003CdefaultValue_003EP = defaultValue;
			this.source = source;
			iterateDefault = true;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out count))
			{
				if (count == 0)
				{
					count = 1;
				}
				return true;
			}
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			if (source.TryGetSpan(out span))
			{
				if (span.Length == 0)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			if (destination.Length == 0)
			{
				return true;
			}
			if (source.TryGetNonEnumeratedCount(out var count) && count == 0 && destination.Length >= 1)
			{
				if (offset.GetOffset(count) == 0)
				{
					destination[0] = _003CdefaultValue_003EP;
					return true;
				}
				return false;
			}
			return source.TryCopyTo(destination, offset);
		}

		public bool TryGetNext(out TSource current)
		{
			if (source.TryGetNext(out current))
			{
				iterateDefault = false;
				return true;
			}
			if (iterateDefault)
			{
				iterateDefault = false;
				current = _003CdefaultValue_003EP;
				return true;
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
		}
	}
}
