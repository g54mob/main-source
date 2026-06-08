using System;
using System.Buffers;
using System.Collections.Generic;

namespace MemoryPack.Internal
{
	internal sealed class ReusableReadOnlySequenceBuilder
	{
		private class Segment : ReadOnlySequenceSegment<byte>
		{
			private bool returnToPool;

			public void SetBuffer(ReadOnlyMemory<byte> buffer, bool returnToPool)
			{
			}

			public void Reset()
			{
			}

			public void SetRunningIndexAndNext(long runningIndex, Segment? nextSegment)
			{
			}
		}

		private readonly Stack<Segment> segmentPool;

		private readonly List<Segment> list;

		public void Add(ReadOnlyMemory<byte> buffer, bool returnToPool)
		{
		}

		public bool TryGetSingleMemory(out ReadOnlyMemory<byte> memory)
		{
			memory = default(ReadOnlyMemory<byte>);
			return false;
		}

		public ReadOnlySequence<byte> Build()
		{
			return default(ReadOnlySequence<byte>);
		}

		public void Reset()
		{
		}
	}
}
