using Coherence.Log;

namespace Coherence.Brook
{
	public struct OutPacket
	{
		public readonly IOutOctetStream Stream;

		public readonly SequenceId SequenceId;

		public readonly bool IsReliable;

		public readonly bool IsOob;

		public OutPacket(IOutOctetStream stream, SequenceId sequenceId, bool isReliable, bool isOob, Logger logger)
		{
			Stream = null;
			SequenceId = default(SequenceId);
			IsReliable = false;
			IsOob = false;
		}

		public OutPacket WithStream(IOutOctetStream stream, Logger logger)
		{
			return default(OutPacket);
		}
	}
}
