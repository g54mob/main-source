using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Common.Pooling;
using Coherence.Core.Channels;
using Coherence.Entities;
using Coherence.Log;
using Coherence.RSL.ReplicationManager.ClientWorld;
using Coherence.RSL.ReplicationManager.InBuffer;
using Coherence.RSL.ReplicationManager.OutBuffer;
using Coherence.Serializer;
using Coherence.SimulationFrame;

namespace Coherence.RSL.ReplicationManager.Channels
{
	internal class OutChannel : IOutChannel
	{
		private readonly uint participant;

		private readonly IExtendedDefinition root;

		private readonly SentCache sentCache;

		private readonly ChangeBuffer changeBuffer;

		private readonly MessageBuffer commandBuffer;

		private readonly MessageBuffer inputBuffer;

		private readonly ChannelSerializationResult lastSerializationResult;

		private readonly CacheList<Entity> sentChangesList;

		private readonly CacheList<Entity> filteredEntities;

		private readonly CacheList<Coherence.Entities.EntityChange> filteredChanges;

		private readonly Pool<ChangeBuffer> changeBufferPool;

		private readonly Logger logger;

		public OutChannel(uint participant, IExtendedDefinition root, bool disableArchetypeLOD, Logger logger)
		{
		}

		public void DestroyInternalEntity(Entity entity, DestroyReason reason)
		{
		}

		public void PushEntityChanges(List<Coherence.RSL.ReplicationManager.ClientWorld.EntityChange> changes)
		{
		}

		public void PushCommand(SerializedEntityMessage message)
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

		public SentCache.Error HandleReceived(List<Entity> ackedEntitiesBuffer)
		{
			return default(SentCache.Error);
		}

		public void HandleLost()
		{
		}

		public bool Serialize(SerializerContext<IOutBitStream> serializerCtx, AbsoluteSimulationFrame simFrame)
		{
			return false;
		}

		public bool SerializeOnlyInputs(SerializerContext<IOutBitStream> serializerCtx)
		{
			return false;
		}

		public void MarkAsSent()
		{
		}

		private ChangeBuffer PrepareSentBuffer(IReadOnlyList<Entity> sent, IReadOnlyList<Entity> sentIDs)
		{
			return null;
		}

		public void MarkAsSentOnlyInputs()
		{
		}

		private void WriteWorldUpdate(List<Entity> changesSentBuffer, List<Entity> internalEntitiesSentBuffer, SerializerContext<IOutBitStream> ctx, ChangeList changeList, ChangeBuffer changes, SerializeEx.SerializeChanges changeType, AbsoluteSimulationFrame simFrame, bool shouldFilterOwn)
		{
		}

		private void FilterEntities(ChangeList changeList, bool shouldFilterOwn, SerializeEx.SerializeChanges changeType, Logger logger)
		{
		}

		private void LogFiltering(string reason, EntityPriority change)
		{
		}

		private Coherence.Entities.EntityChange CreateCoherenceEntityChange(Entity id, EntityState state, AbsoluteSimulationFrame _)
		{
			return default(Coherence.Entities.EntityChange);
		}

		public void ShiftOutgoingPositionComponents(Vector3d floatingOriginShift)
		{
		}

		public void ClearLastSerializationResult()
		{
		}
	}
}
