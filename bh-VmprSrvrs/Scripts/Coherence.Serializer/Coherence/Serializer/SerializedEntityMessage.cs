using Coherence.Entities;

namespace Coherence.Serializer
{
	public class SerializedEntityMessage
	{
		public Entity TargetEntity { get; }

		public byte[] Octets { get; }

		public uint BitCount { get; }

		public SerializedEntityMessage(Entity targetEntity, byte[] octets, uint bitCount)
		{
		}
	}
}
