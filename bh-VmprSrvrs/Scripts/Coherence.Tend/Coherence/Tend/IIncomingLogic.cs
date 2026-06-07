using Coherence.Brook;
using Coherence.Tend.Models;

namespace Coherence.Tend
{
	public interface IIncomingLogic
	{
		SequenceId LastReceivedToUs { get; }

		ReceiveMask ReceiveMask { get; }

		bool ReceivedToUs(SequenceId nextId);
	}
}
