using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Shuffle<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		internal TEnumerator source;

		private RentedArrayBox<TSource>? buffer;

		private int index;

		public Shuffle(TEnumerator source)
		{
			buffer = null;
			this.source = source;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			return source.TryGetNonEnumeratedCount(out count);
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			InitBuffer();
			span = buffer.Span;
			return true;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			if (source.TryGetNonEnumeratedCount(out var count) && offset.GetOffset(count) == 0 && destination.Length >= count && source.TryCopyTo(destination, 0))
			{
				RandomShared.Shuffle(destination.Slice(0, count));
				return true;
			}
			InitBuffer();
			if (EnumeratorHelper.TryGetSlice((ReadOnlySpan<TSource>)buffer.Span, offset, destination.Length, out ReadOnlySpan<TSource> slice))
			{
				slice.CopyTo(destination);
				return true;
			}
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			InitBuffer();
			if ((uint)index < (uint)buffer.Length)
			{
				current = buffer.UnsafeGetAt(index);
				index++;
				return true;
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			buffer?.Dispose();
			if (buffer == null)
			{
				source.Dispose();
			}
		}

		[MemberNotNull("buffer")]
		private void InitBuffer()
		{
			if (buffer == null)
			{
				new ValueEnumerable<TEnumerator, TSource>(source).ToArrayPool().Deconstruct(out TSource[] array, out int size);
				TSource[] array2 = array;
				int length = size;
				buffer = new RentedArrayBox<TSource>(array2, length);
				RandomShared.Shuffle(buffer.Span);
			}
		}
	}
}
