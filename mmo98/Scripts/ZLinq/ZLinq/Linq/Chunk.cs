using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Chunk<TEnumerator, TSource> : IValueEnumerator<TSource[]>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private int index;

		private bool isInitialized;

		private bool isCompleted;

		private bool isCanGetSpan;

		public Chunk(TEnumerator source, int size)
		{
			_003Csize_003EP = size;
			index = 0;
			isInitialized = false;
			isCompleted = false;
			isCanGetSpan = false;
			this.source = source;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out var count2))
			{
				count = (count2 + _003Csize_003EP - 1) / _003Csize_003EP;
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource[]> span)
		{
			span = default(ReadOnlySpan<TSource[]>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource[]> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TSource[] current)
		{
			if (isCompleted)
			{
				current = null;
				return false;
			}
			if (!isInitialized)
			{
				isInitialized = true;
				if (source.TryGetNonEnumeratedCount(out var count))
				{
					_003Csize_003EP = Math.Min(_003Csize_003EP, count);
				}
				if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
				{
					isCanGetSpan = true;
					if (span.Length == 0)
					{
						isCompleted = true;
						current = null;
						return false;
					}
				}
			}
			if (isCanGetSpan)
			{
				source.TryGetSpan(out ReadOnlySpan<TSource> span2);
				ReadOnlySpan<TSource> readOnlySpan = span2.Slice(index, Math.Min(_003Csize_003EP, span2.Length - index));
				index += readOnlySpan.Length;
				current = readOnlySpan.ToArray();
				if (index == span2.Length)
				{
					isCompleted = true;
				}
				return true;
			}
			index = 0;
			current = null;
			TSource current2;
			while (source.TryGetNext(out current2))
			{
				if (current == null)
				{
					current = new TSource[_003Csize_003EP];
				}
				current[index++] = current2;
				if (index == _003Csize_003EP)
				{
					index = 0;
					return true;
				}
			}
			isCompleted = true;
			if (current == null)
			{
				return false;
			}
			if (current.Length != index)
			{
				Array.Resize(ref current, index);
			}
			return true;
		}

		public void Dispose()
		{
			source.Dispose();
		}
	}
}
