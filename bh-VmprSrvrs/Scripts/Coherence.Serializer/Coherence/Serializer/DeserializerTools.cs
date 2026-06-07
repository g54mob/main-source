using Coherence.Brook;
using Coherence.Entities;
using Coherence.ProtocolDef;

namespace Coherence.Serializer
{
	public static class DeserializerTools
	{
		public static short ReadRleSigned(IInBitStream stream)
		{
			return 0;
		}

		public static uint ReadRle(IInBitStream stream)
		{
			return 0u;
		}

		public static Entity DeserializeEntity(IInBitStream outBitStream)
		{
			return default(Entity);
		}

		public static uint DeserializeComponentTypeID(IInBitStream inBitStream)
		{
			return 0u;
		}

		public static MessageTarget DeserializeMessageTarget(IInBitStream inBitStream)
		{
			return default(MessageTarget);
		}

		public static byte ReadFieldSimFrameDelta(IInProtocolBitStream stream)
		{
			return 0;
		}
	}
}
