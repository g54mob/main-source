using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Core;
using Coherence.Entities;
using Coherence.RSL.ReplicationManager.ClientWorld;
using Coherence.RSL.ReplicationManager.OutBuffer;
using Coherence.Serializer;
using Coherence.SimulationFrame;

namespace Coherence.RSL.ReplicationManager.Channels
{
	internal class OutOrderedChannel : IOutChannel
	{
		internal class OrderedChannelSerializationResult
		{
			public List<MessageID> MessagesSent;

			public void Clear()
			{
			}
		}

		private readonly Queue<SerializedEntityMessage> commandQueue;

		private readonly SendSequenceBuffer sequenceBuffer;

		private readonly SentSequenceCache sentCache;

		private readonly CacheList<MessageID> messageIdBuffer;

		public readonly OrderedChannelSerializationResult LastSerializationResult;

		private readonly List<(MessageID, SerializedEntityMessage)> sendMessages;

		public void PushCommand(SerializedEntityMessage message)
		{
		}

		public bool Serialize(SerializerContext<IOutBitStream> serializerCtx, AbsoluteSimulationFrame simFrame)
		{
			return false;
		}

		private List<(MessageID, SerializedEntityMessage)> PreSerialize()
		{
			return null;
		}

		public void MarkAsSent()
		{
		}

		public void HandleLost()
		{
		}

		public Coherence.RSL.ReplicationManager.OutBuffer.SentCache.Error HandleReceived(List<Entity> ackedEntities)
		{
			return default(Coherence.RSL.ReplicationManager.OutBuffer.SentCache.Error);
		}

		public void DestroyInternalEntity(Entity entity, DestroyReason reason)
		{
		}

		public void PushEntityChanges(List<Coherence.RSL.ReplicationManager.ClientWorld.EntityChange> changes)
		{
		}

		public void PushInput(SerializedEntityMessage message)
		{
		}

		public bool ContainsInFlightCreateFor(Entity entity)
		{
			return false;
		}

		public List<uint> GetInFlightRemovesFor(Entity entity)
		{
			return null;
		}

		public bool HasInputChanges()
		{
			return false;
		}

		public bool HasChanges()
		{
			return false;
		}

		public bool SerializeOnlyInputs(SerializerContext<IOutBitStream> serializerCtx)
		{
			return false;
		}

		public void MarkAsSentOnlyInputs()
		{
		}

		public void ShiftOutgoingPositionComponents(Vector3d floatingOriginShift)
		{
		}

		public void ClearLastSerializationResult()
		{
		}
	}
}
