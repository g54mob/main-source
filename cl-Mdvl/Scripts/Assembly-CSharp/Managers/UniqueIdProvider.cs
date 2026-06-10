using NSMedieval.Serialization;

namespace Managers
{
	[FVSerializableKey("UniqueIdProvider", "")]
	public class UniqueIdProvider : IFVSerializable
	{
		private uint nextId;

		public UniqueIdProvider()
		{
			nextId = 1u;
		}

		public uint GetNextId()
		{
			return nextId++;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("nextId", nextId);
		}

		public UniqueIdProvider(FVDeserializer deserializer)
		{
			nextId = deserializer.ReadUInt("nextId");
		}
	}
}
