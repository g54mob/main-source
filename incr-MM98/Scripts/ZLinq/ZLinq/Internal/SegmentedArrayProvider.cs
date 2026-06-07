using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal ref struct SegmentedArrayProvider<T>
	{
		private const int ArrayMaxLength = 2147483591;

		private Span<T> currentSegment;

		private int countInCurrentSegment;

		private Span<T> initialBuffer;

		private InlineArray27<T[]> segments;

		private int segmentsCount;

		private int countInFinishedSegments;

		public int Count => checked(countInFinishedSegments + countInCurrentSegment);

		public bool IsInitialBufferOnly => segmentsCount == 0;

		public SegmentedArrayProvider(Span<T> initialBuffer)
		{
			countInCurrentSegment = 0;
			segments = default(InlineArray27<T[]>);
			segmentsCount = 0;
			countInFinishedSegments = 0;
			this.initialBuffer = (currentSegment = initialBuffer);
		}

		public Span<T> GetSpan()
		{
			Span<T> span = currentSegment;
			int num = countInCurrentSegment;
			if ((uint)num < (uint)span.Length)
			{
				return span.Slice(num);
			}
			Expand();
			return currentSegment;
		}

		public void Advance(int count)
		{
			countInCurrentSegment += count;
		}

		private void Expand()
		{
			int length = currentSegment.Length;
			checked
			{
				countInFinishedSegments += length;
				if (countInFinishedSegments > 2147483591)
				{
					throw new OutOfMemoryException();
				}
			}
			int minimumLength = (int)Math.Min((long)Math.Max(16, length) * 2L, 2147483591L);
			currentSegment = (InlineArrayMarshal.ElementRef<InlineArray27<T[]>, T[]>(ref segments, segmentsCount) = ArrayPool<T>.Shared.Rent(minimumLength));
			countInCurrentSegment = 0;
			segmentsCount++;
		}

		public void CopyToAndClear(Span<T> destination)
		{
			int num = segmentsCount;
			if (num != 0)
			{
				Span<T> span = initialBuffer;
				span.CopyTo(destination);
				destination = destination.Slice(span.Length);
				num--;
				if (num != 0)
				{
					ReadOnlySpan<T[]> readOnlySpan = segments.AsSpan().Slice(0, num);
					for (int i = 0; i < readOnlySpan.Length; i++)
					{
						T[] array = readOnlySpan[i];
						Span<T> span2 = array.AsSpan();
						span2.CopyTo(destination);
						destination = destination.Slice(span2.Length);
						ArrayPool<T>.Shared.Return(array, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
					}
				}
				T[] array2 = segments[num];
				array2.AsSpan(0, countInCurrentSegment).CopyTo(destination);
				ArrayPool<T>.Shared.Return(array2, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
			}
			else
			{
				currentSegment.Slice(0, countInCurrentSegment).CopyTo(destination);
			}
		}
	}
}
