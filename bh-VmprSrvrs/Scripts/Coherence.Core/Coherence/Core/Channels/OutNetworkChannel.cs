using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.Serializer;
using Coherence.SimulationFrame;
using Coherence.Stats;

namespace Coherence.Core.Channels
{
	internal class OutNetworkChannel : IOutNetworkChannel
	{
		private readonly ChannelSerializationResult lastSerializationResult;

		private readonly ISchemaSpecificComponentSerialize serializer;

		private readonly IComponentInfo definition;

		private SendChangeBuffer changeBuffer;

		private SentCache sentCache;

		private readonly List<uint> removesToApply;

		private readonly List<EntityChange> existenceChangeBuffer;

		private readonly List<EntityChange> updateChangeBuffer;

		private readonly Queue<SerializedEntityMessage> emptyQueue;

		private readonly Coherence.Stats.Stats stats;

		private readonly Logger logger;

		public event Action<Entity> OnEntityAcked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public OutNetworkChannel(ISchemaSpecificComponentSerialize serializer, IComponentInfo definition, Coherence.Stats.Stats stats, Logger logger)
		{
		}

		public void CreateEntity(Entity id, ICoherenceComponentData[] data)
		{
		}

		public void UpdateComponents(Entity id, ICoherenceComponentData[] data)
		{
		}

		public void RemoveComponents(Entity id, uint[] componentTypes, Dictionary<Entity, HashSet<uint>> ackedComponentsPerEntity)
		{
		}

		public void DestroyEntity(Entity id, IReadOnlyCollection<Entity> ackedEntities)
		{
		}

		public void PushCommand(IEntityCommand message, MessageTarget target, Entity id, bool useDebugStreams)
		{
		}

		public void PushInput(IEntityInput message, bool useDebugStreams)
		{
		}

		public bool HasChangesForEntity(Entity entity)
		{
			return false;
		}

		public void ClearAllChangesForEntity(Entity entity)
		{
		}

		public bool HasChanges(IReadOnlyCollection<Entity> ackedEntities)
		{
			return false;
		}

		public bool Serialize(SerializerContext<IOutBitStream> serializerCtx, AbsoluteSimulationFrame referenceSimulationFrame, bool holdOnToCommands, IReadOnlyCollection<Entity> ackedEntities)
		{
			return false;
		}

		public Dictionary<Entity, OutgoingEntityUpdate> MarkAsSent(SequenceId packetSequenceId)
		{
			return null;
		}

		public void OnDeliveryInfo(DeliveryInfo info, ref HashSet<Entity> ackedEntities, ref Dictionary<Entity, HashSet<uint>> ackedComponentsPerEntity)
		{
		}

		public void Reset()
		{
		}

		public void ClearLastSerializationResult()
		{
		}

		private void UpdateAckedComponents(Entity id, OutgoingEntityUpdate update, ref Dictionary<Entity, HashSet<uint>> ackedComponentsPerEntity)
		{
		}
	}
}
