using System;
using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Entities;
using Coherence.ProtocolDef;
using Coherence.Serializer;
using Coherence.SimulationFrame;

namespace Coherence.Core.Channels
{
	internal interface IOutNetworkChannel
	{
		event Action<Entity> OnEntityAcked;

		void CreateEntity(Entity id, ICoherenceComponentData[] data);

		void UpdateComponents(Entity id, ICoherenceComponentData[] data);

		void RemoveComponents(Entity id, uint[] componentTypes, Dictionary<Entity, HashSet<uint>> ackedComponentsPerEntity);

		void DestroyEntity(Entity id, IReadOnlyCollection<Entity> ackedEntities);

		void PushCommand(IEntityCommand message, MessageTarget target, Entity id, bool useDebugStreams);

		void PushInput(IEntityInput message, bool useDebugStreams);

		bool HasChangesForEntity(Entity entity);

		void ClearAllChangesForEntity(Entity entity);

		bool HasChanges(IReadOnlyCollection<Entity> ackedEntities);

		bool Serialize(SerializerContext<IOutBitStream> serializerCtx, AbsoluteSimulationFrame referenceSimulationFrame, bool holdOnToCommands, IReadOnlyCollection<Entity> ackedEntities);

		Dictionary<Entity, OutgoingEntityUpdate> MarkAsSent(SequenceId packetSequenceId);

		void OnDeliveryInfo(DeliveryInfo info, ref HashSet<Entity> ackedEntities, ref Dictionary<Entity, HashSet<uint>> ackedComponentsPerEntity);

		void Reset();

		void ClearLastSerializationResult();
	}
}
