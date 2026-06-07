using System;
using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Common.Pooling;

namespace Coherence.RSL.Brisk.Connection
{
	public class OOBAckQueue
	{
		public enum Status
		{
			Unknown = 0,
			Acked = 1,
			Lost = 2
		}

		private struct OOBPacket
		{
			public Buffer<byte> Data;

			public SequenceId SequenceId;
		}

		private readonly Queue<OOBPacket> queue;

		private readonly Pool<Buffer<byte>> packetBufferPool;

		public void Enqueue(ReadOnlySpan<byte> packetData, SequenceId sequenceId)
		{
		}

		public Status Ack(DeliveryInfo ack, out ReadOnlySpan<byte> data)
		{
			data = default(ReadOnlySpan<byte>);
			return default(Status);
		}
	}
}
