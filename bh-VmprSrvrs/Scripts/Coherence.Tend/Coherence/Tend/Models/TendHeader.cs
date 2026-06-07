using Coherence.Brook;

namespace Coherence.Tend.Models
{
	public struct TendHeader
	{
		public bool isReliable;

		public SequenceId packetId;

		public SequenceId receivedId;

		public ReceiveMask receiveMask;

		public override string ToString()
		{
			return null;
		}
	}
}
