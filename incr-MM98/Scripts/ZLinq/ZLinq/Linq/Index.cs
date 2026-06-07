using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Index<TEnumerator, TSource> : IValueEnumerator<(int Index, TSource Item)>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private int index;

		public Index(TEnumerator source)
		{
			this.source = source;
			index = -1;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			return source.TryGetNonEnumeratedCount(out count);
		}

		public bool TryGetSpan(out ReadOnlySpan<(int Index, TSource Item)> span)
		{
			span = default(ReadOnlySpan<(int, TSource)>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<(int Index, TSource Item)> destination, Index offset)
		{
			if (source.TryGetSpan(out ReadOnlySpan<TSource> span) && EnumeratorHelper.TryGetSlice(span, offset, destination.Length, out var slice))
			{
				int num = offset.GetOffset(span.Length);
				for (int i = 0; (uint)i < (uint)slice.Length; i++)
				{
					destination[i] = (Index: num, Item: slice[i]);
					num = checked(num + 1);
				}
				return true;
			}
			return false;
		}

		public bool TryGetNext(out (int Index, TSource Item) current)
		{
			checked
			{
				if (source.TryGetNext(out TSource current2))
				{
					index++;
					current = (Index: index, Item: current2);
					return true;
				}
				Unsafe.SkipInit<(int, TSource)>(out current);
				return false;
			}
		}

		public void Dispose()
		{
			source.Dispose();
		}
	}
}
