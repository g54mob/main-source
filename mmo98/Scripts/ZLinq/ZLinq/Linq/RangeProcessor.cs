using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	internal struct RangeProcessor
	{
		public readonly Range Range;

		public int SkipIndex;

		public int Remains;

		public int Index;

		public int FromEndQueueSize;

		public RangeProcessor(Range range)
		{
			Range = range;
			SkipIndex = 0;
			Remains = -2;
			Index = 0;
			FromEndQueueSize = 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Initialize(int? knownCount = null)
		{
			if (Remains == -2)
			{
				if (knownCount.HasValue)
				{
					InitializeWithKnownCount(knownCount.Value);
				}
				else if (!Range.Start.IsFromEnd && !Range.End.IsFromEnd)
				{
					InitializeBothFromStart();
				}
				else
				{
					InitializeWithUnknownCount();
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void InitializeBothFromStart()
		{
			SkipIndex = Range.Start.Value;
			int val = Range.End.Value - Range.Start.Value;
			Remains = Math.Max(0, val);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void InitializeWithKnownCount(int count)
		{
			int val = (Range.Start.IsFromEnd ? Math.Max(0, count - Range.Start.Value) : Range.Start.Value);
			int val2 = (Range.End.IsFromEnd ? Math.Max(0, count - Range.End.Value) : Range.End.Value);
			SkipIndex = Math.Min(val, count);
			Remains = Math.Max(0, Math.Min(val2, count) - SkipIndex);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void InitializeWithUnknownCount()
		{
			if (!Range.Start.IsFromEnd && Range.End.IsFromEnd)
			{
				SkipIndex = Range.Start.Value;
				Remains = ((Range.End.Value == 0) ? int.MaxValue : (-1));
				if (Range.End.Value > 0)
				{
					FromEndQueueSize = Range.End.Value;
				}
				return;
			}
			if (Range.Start.IsFromEnd && !Range.End.IsFromEnd)
			{
				SkipIndex = 0;
				Remains = -1;
				FromEndQueueSize = Math.Max(1, Range.Start.Value);
				return;
			}
			SkipIndex = 0;
			int num = Range.Start.Value - Range.End.Value;
			Remains = ((num > 0) ? (-1) : 0);
			if (num > 0)
			{
				FromEndQueueSize = Math.Max(1, Range.Start.Value);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CalculateRemainsFromQueue(int totalCount, int queueCount)
		{
			int num = (Range.Start.IsFromEnd ? Math.Max(0, totalCount - Range.Start.Value) : Range.Start.Value);
			int num2 = (Range.End.IsFromEnd ? Math.Max(0, totalCount - Range.End.Value) : Range.End.Value);
			Remains = Math.Max(0, num2 - num);
			int num3 = totalCount - queueCount;
			int num4 = Math.Max(0, num - num3);
			Remains = Math.Min(Remains - num4, queueCount - num4);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int GetQueueSkipCount(int totalCount, int queueCount)
		{
			int num = (Range.Start.IsFromEnd ? Math.Max(0, totalCount - Range.Start.Value) : Range.Start.Value);
			int num2 = totalCount - queueCount;
			return Math.Max(0, num - num2);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public (int offsetInRange, int elementsToCopy) CalculateCopyParameters(int totalCount, int destinationLength, Index offset)
		{
			int num = Math.Min(Remains, Math.Max(0, totalCount - SkipIndex));
			if (num <= 0)
			{
				return (offsetInRange: -1, elementsToCopy: 0);
			}
			int offset2 = offset.GetOffset(num);
			if (offset2 < 0 || offset2 >= num)
			{
				return (offsetInRange: -1, elementsToCopy: 0);
			}
			int item = Math.Min(num - offset2, destinationLength);
			return (offsetInRange: offset2, elementsToCopy: item);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SkipQueue<TSource>(ref ValueQueue<TSource> queue)
		{
			CalculateRemainsFromQueue(Index, queue.Count);
			int num = GetQueueSkipCount(Index, queue.Count);
			while (num > 0 && queue.Count > 0)
			{
				queue.Dequeue();
				num--;
			}
		}
	}
}
