using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Append<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private byte state;

		public Append(TEnumerator source, TSource element)
		{
			_003Celement_003EP = element;
			state = 0;
			this.source = source;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out count) && count < int.MaxValue)
			{
				count++;
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			if (destination.Length == 0)
			{
				return false;
			}
			if (!source.TryGetNonEnumeratedCount(out var count))
			{
				return false;
			}
			int num = count + 1;
			int offset2 = offset.GetOffset(num);
			if (offset2 >= num)
			{
				return false;
			}
			int num2 = 0;
			if (offset2 < count)
			{
				if (!source.TryCopyTo(destination, offset2))
				{
					return false;
				}
				num2 = Math.Min(count - offset2, destination.Length);
			}
			if (num2 < destination.Length && offset2 <= count)
			{
				destination[num2] = _003Celement_003EP;
			}
			return true;
		}

		public bool TryGetNext(out TSource current)
		{
			if (state == 0)
			{
				if (source.TryGetNext(out current))
				{
					return true;
				}
				state = 1;
			}
			if (state == 1)
			{
				current = _003Celement_003EP;
				state = 2;
				return true;
			}
			current = default(TSource);
			return false;
		}

		public void Dispose()
		{
			state = 2;
			source.Dispose();
		}
	}
}
