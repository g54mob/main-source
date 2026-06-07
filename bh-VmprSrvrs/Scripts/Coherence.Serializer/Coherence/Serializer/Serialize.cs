using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;

namespace Coherence.Serializer
{
	public static class Serialize
	{
		private static readonly uint NUM_BITS_FOR_END_OF_ENTITIES;

		private static readonly uint DEBUG_NUM_BITS_FOR_END_OF_ENTITIES;

		public const uint NUM_BITS_FOR_MESSAGE_TYPE = 8u;

		public const int NUM_BITS_FOR_DESTROY_REASON = 3;

		public const int NUM_BITS_FOR_SIMFRAME_DELTA_FLAG = 1;

		public const int MAX_SERIALIZED_MESSAGE_BYTES = 1024;

		public const int NUM_BITS_FOR_AUTHORITY = 1;

		public const int NUM_BITS_FOR_ORPHAN = 1;

		public const int NUM_BITS_FOR_OPERATION = 2;

		public const int NUM_BITS_FOR_LOD = 4;

		public const int NUM_BITS_FOR_COMPONENT_COUNT = 5;

		public const int NUM_BITS_FOR_COMPONENT_STATE = 2;

		public const int NUM_BITS_FOR_MESSAGE_TARGET = 2;

		public const int NUM_BITS_FOR_CHANNEL_ID = 4;

		private static uint ChannelIDBits(SerializerContext<IOutBitStream> ctx)
		{
			return 0u;
		}

		private static uint MessageTypeBits(SerializerContext<IOutBitStream> ctx)
		{
			return 0u;
		}

		private static uint EndOfPacketBits(SerializerContext<IOutBitStream> ctx)
		{
			return 0u;
		}

		private static bool HasEnoughBits(SerializerContext<IOutBitStream> ctx, uint count)
		{
			return false;
		}

		private static uint RemainingBitBudget(SerializerContext<IOutBitStream> ctx)
		{
			return 0u;
		}

		public static void WriteEntityUpdates(List<Entity> writtenEntitiesBuffer, IReadOnlyList<EntityChange> changes, AbsoluteSimulationFrame referenceSimulationFrame, ISchemaSpecificComponentSerialize componentSerializer, SerializerContext<IOutBitStream> ctx)
		{
		}

		private static bool SerializeSimulationFrame(AbsoluteSimulationFrame referenceSimulationFrame, IOutBitStream bitStream, Logger logger, AbsoluteSimulationFrame simulationFrame)
		{
			return false;
		}

		public static void SerializeUpdated(EntityChange change, AbsoluteSimulationFrame referenceSimulationFrame, ISchemaSpecificComponentSerialize componentSerializer, SerializerContext<IOutBitStream> ctx, ref ushort lastIndex, out uint bitsTaken)
		{
			bitsTaken = default(uint);
		}

		private static void SerializeDestroyed(EntityChange change, SerializerContext<IOutBitStream> ctx, ref ushort lastIndex)
		{
		}

		private static void SerializeCommand(MessageType messageType, IOutBitStream outBitStream)
		{
		}

		private static void WriteMessageIDDelta(ushort id, ushort lastId, IOutBitStream stream)
		{
		}

		private static ushort WriteEntityIndex(Entity entityId, IOutBitStream stream, ushort lastIndex)
		{
			return 0;
		}

		private static void WriteEntityIndexDelta(int delta, IOutBitStream stream)
		{
		}

		private static void WriteEntityMeta(SerializedMeta entityMeta, IOutBitStream stream)
		{
		}

		private static void WriteEntityDestroyReason(DestroyReason reason, IOutBitStream stream)
		{
		}

		private static void WriteEntityAuthority(bool hasAuthority, IOutBitStream stream)
		{
		}

		private static void WriteEntityOrphan(bool isOrphan, IOutBitStream stream)
		{
		}

		private static void WriteEntityLOD(uint lod, IOutBitStream stream)
		{
		}

		private static void WriteEntityOperation(EntityOperation operation, IOutBitStream stream)
		{
		}

		private static void WriteEntityVersion(uint version, IOutBitStream stream)
		{
		}

		private static void WriteEndOfEntities(IOutBitStream stream)
		{
		}

		private static void WriteComponentCount(int count, IOutBitStream stream)
		{
		}

		private static void WriteComponentState(ComponentState state, IOutBitStream stream)
		{
		}

		private static void WriteComponentId(uint componentSerializeId, IOutBitStream stream)
		{
		}

		private static void WriteMessageEntityId(Entity entityID, IOutBitStream outBitStream)
		{
		}

		private static void WriteMessageTarget(MessageTarget target, IOutBitStream outBitStream)
		{
		}

		public static void WriteMessages(List<SerializedEntityMessage> serializedMessagesBuffer, MessageType messageType, Queue<SerializedEntityMessage> messages, SerializerContext<IOutBitStream> ctx)
		{
		}

		public static List<MessageID> WriteOrderedCommands(List<(MessageID, SerializedEntityMessage)> messages, SerializerContext<IOutBitStream> ctx)
		{
			return null;
		}

		public static SerializedEntityMessage SerializeMessage(MessageType messageType, MessageTarget target, IEntityMessage message, Entity id, ISchemaSpecificComponentSerialize serializer, bool useDebugStream, Logger logger)
		{
			return null;
		}

		public static void WriteFloatingOrigin(Vector3d floatingOrigin, SerializerContext<IOutBitStream> ctx)
		{
		}

		private static AbsoluteSimulationFrame? GetMinSimFrame(EntityChange change, Logger logger)
		{
			return null;
		}

		public static void WriteChannelID(ChannelID channelID, SerializerContext<IOutBitStream> ctx)
		{
		}

		public static void WriteEndOfMessages(SerializerContext<IOutBitStream> ctx)
		{
		}

		public static void WriteEndOfChannels(SerializerContext<IOutBitStream> ctx)
		{
		}
	}
}
