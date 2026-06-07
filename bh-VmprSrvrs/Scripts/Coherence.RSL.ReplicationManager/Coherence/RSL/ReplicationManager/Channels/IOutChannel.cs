using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Entities;
using Coherence.RSL.ReplicationManager.ClientWorld;
using Coherence.RSL.ReplicationManager.OutBuffer;
using Coherence.Serializer;
using Coherence.SimulationFrame;

namespace Coherence.RSL.ReplicationManager.Channels
{
	public interface IOutChannel
	{
		void DestroyInternalEntity(Entity entity, DestroyReason reason);

		void PushEntityChanges(List<Coherence.RSL.ReplicationManager.ClientWorld.EntityChange> changes);

		void PushCommand(SerializedEntityMessage message);

		void PushInput(SerializedEntityMessage message);

		bool ContainsInFlightCreateFor(Entity entity);

		List<uint> GetInFlightRemovesFor(Entity entity);

		bool HasInputChanges();

		bool HasChanges();

		SentCache.Error HandleReceived(List<Entity> ackedEntities);

		void HandleLost();

		bool Serialize(SerializerContext<IOutBitStream> serializerCtx, AbsoluteSimulationFrame simFrame);

		bool SerializeOnlyInputs(SerializerContext<IOutBitStream> serializerCtx);

		void MarkAsSent();

		void MarkAsSentOnlyInputs();

		void ShiftOutgoingPositionComponents(Vector3d floatingOriginShift);

		void ClearLastSerializationResult();
	}
}
