using System.Collections.Generic;
using System.Numerics;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;

namespace Coherence.Serializer
{
	public static class Deserialize
	{
		public static void ReadWorldUpdate(List<IncomingEntityUpdate> updatesBuffer, AbsoluteSimulationFrame referenceSimulationFrame, Vector3 floatingOriginDelta, ISchemaSpecificComponentDeserialize componentDeserializer, IInBitStream bitStream, IComponentInfo definition, Logger logger)
		{
		}

		public static IncomingEntityUpdate UpdateComponents(ISchemaSpecificComponentDeserialize componentDeserializer, IncomingEntityUpdate entityUpdate, AbsoluteSimulationFrame entityRefSimulationFrame, IInBitStream bitStream, IComponentInfo definition, Logger logger)
		{
			return default(IncomingEntityUpdate);
		}

		public static bool ReadEntity(IInBitStream bitStream, AbsoluteSimulationFrame referenceSimulationFrame, ref ushort lastIndex, out EntityWithMeta meta, out AbsoluteSimulationFrame entityRefSimulationFrame, Logger logger)
		{
			meta = default(EntityWithMeta);
			entityRefSimulationFrame = default(AbsoluteSimulationFrame);
			return false;
		}

		private static AbsoluteSimulationFrame ReadSimulationFrame(IInBitStream bitStream, AbsoluteSimulationFrame referenceSimulationFrame)
		{
			return default(AbsoluteSimulationFrame);
		}

		private static MessageID ReadNextMessageID(IInBitStream bitstream, ushort lastID)
		{
			return default(MessageID);
		}

		private static uint ReadEntityIndex(IInBitStream bitstream, ushort lastIndex)
		{
			return 0u;
		}

		private static EntityWithMeta ReadEntityPotentialMeta(ushort entityIndex, IInBitStream bitStream, Logger logger)
		{
			return default(EntityWithMeta);
		}

		private static SerializedMeta ReadEntityMeta(IInBitStream bitstream)
		{
			return default(SerializedMeta);
		}

		private static byte ReadEntityVersion(IInBitStream bitstream)
		{
			return 0;
		}

		private static bool ReadEntityAuthority(IInBitStream bitstream)
		{
			return false;
		}

		private static bool ReadEntityOrphan(IInBitStream bitstream)
		{
			return false;
		}

		private static uint ReadEntityLOD(IInBitStream bitstream)
		{
			return 0u;
		}

		private static EntityOperation ReadEntityOperation(IInBitStream bitstream)
		{
			return default(EntityOperation);
		}

		private static DestroyReason ReadDestroyReason(IInBitStream bitstream)
		{
			return default(DestroyReason);
		}

		private static uint ReadComponentCount(IInBitStream bitstream)
		{
			return 0u;
		}

		private static ComponentState ReadComponentState(IInBitStream bitstream)
		{
			return default(ComponentState);
		}

		private static uint ReadComponentId(IInBitStream bitstream)
		{
			return 0u;
		}

		private static uint ReadComponentTypeId(IInBitStream bitstream)
		{
			return 0u;
		}

		public static Vector3d ReadFloatingOrigin(IInBitStream bitstream, Logger logger)
		{
			return default(Vector3d);
		}

		public static bool ReadChannelID(IInBitStream bitstream, out ChannelID channelID)
		{
			channelID = default(ChannelID);
			return false;
		}

		public static List<(MessageID, IEntityMessage)> ReadOrderedCommands(IInBitStream bitStream, ISchemaSpecificComponentDeserialize componentDeserializer, Logger logger)
		{
			return null;
		}
	}
}
