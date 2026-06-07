using Coherence.Entities;
using Coherence.Log;

namespace Coherence.Serializer
{
	public class SerializerContext<TStream>
	{
		public TStream BitStream { get; private set; }

		public bool UseDebugStreams { get; private set; }

		public Logger Logger { get; private set; }

		public uint ProtocolVersion { get; private set; }

		public string Section { get; private set; }

		public Entity EntityId { get; private set; }

		public uint ComponentId { get; private set; }

		public uint BitsRemainingInEmptyPacket { get; private set; }

		public SerializerContext(TStream stream, bool useDebugStreams, Logger logger, uint protocolVersion = 4u)
		{
		}

		public void StartSection(string section)
		{
		}

		public void EndSection()
		{
		}

		public void SetEntity(Entity id)
		{
		}

		public void SetComponent(uint id)
		{
		}

		public void SetBitsRemainingInEmptyPacket(uint bitsRemainingInEmptyPacket)
		{
		}
	}
}
