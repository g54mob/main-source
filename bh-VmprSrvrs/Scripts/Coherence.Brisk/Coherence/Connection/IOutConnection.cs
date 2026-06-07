using Coherence.Brook;

namespace Coherence.Connection
{
	internal interface IOutConnection
	{
		bool CanSend { get; }

		bool UseDebugStreams { get; }

		OutPacket CreatePacket(bool reliable);

		void Send(OutPacket packet);
	}
}
