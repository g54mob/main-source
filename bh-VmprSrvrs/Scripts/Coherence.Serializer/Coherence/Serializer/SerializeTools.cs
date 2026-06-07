using Coherence.Brook;
using Coherence.Entities;
using Coherence.ProtocolDef;

namespace Coherence.Serializer
{
	public static class SerializeTools
	{
		public static void WriteRleSigned(IOutBitStream stream, short v)
		{
		}

		public static void WriteRle(IOutBitStream stream, uint v)
		{
		}

		public static void SerializeEntity(Entity entity, IOutBitStream outBitStream)
		{
		}

		public static void SerializeComponentTypeID(uint componentTypeId, IOutBitStream outBitStream)
		{
		}

		public static void WriteFieldSimFrameDelta(IOutProtocolBitStream stream, byte delta)
		{
		}
	}
}
