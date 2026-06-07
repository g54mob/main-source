using System.Net;

namespace Coherence.Brook
{
	public struct InPacket
	{
		public readonly IInOctetStream Stream;

		public readonly SequenceId SequenceId;

		public readonly bool IsReliable;

		public readonly bool IsOob;

		public readonly IPEndPoint From;

		public InPacket(IInOctetStream stream, SequenceId sequenceId, bool isReliable, bool isOob, IPEndPoint from)
		{
			Stream = null;
			SequenceId = default(SequenceId);
			IsReliable = false;
			IsOob = false;
			From = null;
		}
	}
}
