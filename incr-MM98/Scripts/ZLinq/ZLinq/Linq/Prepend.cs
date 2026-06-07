using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Prepend<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private byte state;

		public Prepend(TEnumerator source, TSource element)
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
			bool flag = offset2 == 0;
			int num2 = ((offset2 > 0) ? (offset2 - 1) : 0);
			int val = destination.Length - (flag ? 1 : 0);
			int num3 = Math.Min(count - num2, val);
			if (num3 > 0)
			{
				int start = (flag ? 1 : 0);
				Span<TSource> destination2 = destination.Slice(start, num3);
				if (!source.TryCopyTo(destination2, num2))
				{
					return false;
				}
			}
			if (flag)
			{
				destination[0] = _003Celement_003EP;
			}
			return true;
		}

		public bool TryGetNext(out TSource current)
		{
			if (state == 0)
			{
				current = _003Celement_003EP;
				state = 1;
				return true;
			}
			if (state == 1)
			{
				if (source.TryGetNext(out current))
				{
					return true;
				}
				state = 2;
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
