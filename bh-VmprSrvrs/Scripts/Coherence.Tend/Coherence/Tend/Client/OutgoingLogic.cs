using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Log;
using Coherence.Tend.Models;

namespace Coherence.Tend.Client
{
	public class OutgoingLogic : IOutgoingLogic
	{
		private SequenceId lastReceivedByRemoteSequenceId;

		private readonly Queue<DeliveryInfo> receivedQueue;

		private Logger logger;

		public int Count => 0;

		public bool CanIncrementOutgoingSequence => false;

		public SequenceId LastReceivedByRemoteSequenceId => default(SequenceId);

		public SequenceId OutgoingSequenceId { get; set; }

		public OutgoingLogic(Logger logger)
		{
		}

		public bool ReceivedByRemote(SequenceId receivedByRemoteId, ReceiveMask receivedByRemoteMask)
		{
			return false;
		}

		public SequenceId IncreaseOutgoingSequenceId()
		{
			return default(SequenceId);
		}

		public DeliveryInfo Dequeue()
		{
			return default(DeliveryInfo);
		}

		private void Append(SequenceId receivedId, bool bit)
		{
		}
	}
}
