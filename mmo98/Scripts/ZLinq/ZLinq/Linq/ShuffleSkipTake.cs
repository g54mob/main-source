using System;
using System.Buffers;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ShuffleSkipTake<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private readonly int skipCount;

		private readonly int takeCount;

		private RentedArrayBox<TSource>? buffer;

		private int index;

		public ShuffleSkipTake(TEnumerator source, int skipCount, int takeCount)
		{
			buffer = null;
			this.source = source;
			this.skipCount = skipCount;
			this.takeCount = takeCount;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out count))
			{
				count = GetLength(count);
				return true;
			}
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			InitBuffer();
			span = buffer.Span;
			return true;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
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
			if (buffer == null)
			{
				InitBuffer();
			}
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

		private int GetLength(int count)
		{
			return Math.Min(Math.Max(0, count - skipCount), takeCount);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[MemberNotNull("buffer")]
		private void InitBuffer()
		{
			if (buffer == null)
			{
				new ValueEnumerable<TEnumerator, TSource>(source).ToArrayPool().Deconstruct(out TSource[] array, out int size);
				TSource[] array2 = array;
				int num = size;
				int length = GetLength(num);
				if (length == 0)
				{
					ArrayPool<TSource>.Shared.Return(array2, RuntimeHelpers.IsReferenceOrContainsReferences<TSource>());
					buffer = RentedArrayBox<TSource>.Empty;
				}
				else
				{
					RandomShared.PartialShuffle(array2.AsSpan(0, num), length);
					buffer = new RentedArrayBox<TSource>(array2, length);
				}
			}
		}
	}
}
