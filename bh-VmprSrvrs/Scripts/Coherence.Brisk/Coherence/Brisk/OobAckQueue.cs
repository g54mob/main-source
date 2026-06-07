using System.Collections.Generic;
using Coherence.Brisk.Models;
using Coherence.Brook;

namespace Coherence.Brisk
{
	internal class OobAckQueue
	{
		private struct Packet
		{
			public readonly IOobMessage Message;

			public readonly SequenceId SequenceId;

			public Packet(IOobMessage message, SequenceId sequenceId)
			{
				Message = null;
				SequenceId = default(SequenceId);
			}
		}

		private readonly Queue<Packet> queue;

		public void Clear()
		{
		}

		public void Enqueue(IOobMessage oobMessage, SequenceId packetSequenceId)
		{
		}

		public PacketStatus Ack(DeliveryInfo info, out IOobMessage message)
		{
			message = null;
			return default(PacketStatus);
		}
	}
}
