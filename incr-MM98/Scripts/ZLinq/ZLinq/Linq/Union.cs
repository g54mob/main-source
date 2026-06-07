using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Union<TEnumerator, TEnumerator2, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private TEnumerator2 second;

		private HashSetSlim<TSource>? set;

		private byte state;

		public Union(TEnumerator source, TEnumerator2 second, IEqualityComparer<TSource>? comparer)
		{
			_003Ccomparer_003EP = comparer;
			set = null;
			this.source = source;
			this.second = second;
			state = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
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
			if (destination.Length == 1 && offset.Value == 0)
			{
				return source.TryCopyTo(destination, offset);
			}
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			if (state == 0)
			{
				set = new HashSetSlim<TSource>(_003Ccomparer_003EP ?? EqualityComparer<TSource>.Default);
				state = 1;
			}
			if (state == 1)
			{
				TSource current2;
				while (source.TryGetNext(out current2))
				{
					if (set.Add(current2))
					{
						current = current2;
						return true;
					}
				}
				state = 2;
			}
			if (state == 2)
			{
				TSource current3;
				while (second.TryGetNext(out current3))
				{
					if (set.Add(current3))
					{
						current = current3;
						return true;
					}
				}
				state = 3;
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			state = 3;
			set?.Dispose();
			source.Dispose();
			second.Dispose();
		}
	}
}
