using Coherence.Serializer;

namespace Coherence.Core
{
	internal class SendSequenceBufferEntry
	{
		public bool Sent;

		public bool Acked;

		public SerializedEntityMessage Message;
	}
}
