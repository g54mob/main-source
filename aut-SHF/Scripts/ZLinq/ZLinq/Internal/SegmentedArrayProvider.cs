using System;

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

		public int Count => 0;

		public bool IsInitialBufferOnly => false;

		public SegmentedArrayProvider(Span<T> initialBuffer)
		{
			currentSegment = default(Span<T>);
			countInCurrentSegment = 0;
			this.initialBuffer = default(Span<T>);
			segments = default(InlineArray27<T[]>);
			segmentsCount = 0;
			countInFinishedSegments = 0;
		}

		public Span<T> GetSpan()
		{
			return default(Span<T>);
		}

		public void Advance(int count)
		{
		}

		private void Expand()
		{
		}

		public void CopyToAndClear(Span<T> destination)
		{
		}
	}
}
