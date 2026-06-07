using Coherence.Brook;
using Coherence.Tend.Models;

namespace Coherence.Tend
{
	public interface IOutgoingLogic
	{
		int Count { get; }

		bool CanIncrementOutgoingSequence { get; }

		SequenceId LastReceivedByRemoteSequenceId { get; }

		SequenceId OutgoingSequenceId { get; set; }

		bool ReceivedByRemote(SequenceId receivedByRemoteId, ReceiveMask receivedByRemoteMask);

		SequenceId IncreaseOutgoingSequenceId();

		DeliveryInfo Dequeue();
	}
}
