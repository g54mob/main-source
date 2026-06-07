using System.Collections.Generic;
using Coherence.Common;
using Coherence.Common.Pooling;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.RSL.EntityManager;
using Coherence.RSL.ReplicationManager.ClientWorld;
using Coherence.RSL.ReplicationManager.InBuffer;

namespace Coherence.RSL.ReplicationManager.OutBuffer
{
	public class ChangeBuffer : IReusable
	{
		private readonly bool disableArchetypeLOD;

		private readonly Logger log;

		private readonly IExtendedDefinition root;

		private readonly Dictionary<Entity, EntityState> data;

		private readonly Dictionary<Entity, EntityState> internalData;

		private readonly ChangeList priorityList;

		private readonly List<Entity> entityCache;

		private readonly CacheList<(Entity, DeltaComponents)> entitiesWithOrderedComps;

		public Dictionary<Entity, EntityState> Data => null;

		public Dictionary<Entity, EntityState> InternalData => null;

		public bool DisableArchetypeLOD => false;

		public ChangeBuffer(IExtendedDefinition root, bool disableArchetypeLOD, Logger log)
		{
		}

		internal ChangeBuffer(IExtendedDefinition root, bool disableArchetypeLOD, Logger log, int capacity)
		{
		}

		internal ChangeBuffer Clone()
		{
			return null;
		}

		public void ResetState()
		{
		}

		public void GetEntities(List<Entity> buffer)
		{
		}

		public Dictionary<Entity, EntityMeta> GetEntityMeta()
		{
			return null;
		}

		public bool ViewEntityState(Entity entity, out EntityState state)
		{
			state = default(EntityState);
			return false;
		}

		public EntityState GetEntityState(Entity entity)
		{
			return default(EntityState);
		}

		public void UpdateWithChanges(IReadOnlyList<Coherence.RSL.ReplicationManager.ClientWorld.EntityChange> changes)
		{
		}

		public void UpdateWithChange(Coherence.RSL.ReplicationManager.ClientWorld.EntityChange change)
		{
		}

		public void DestroyInternalEntity(Entity entity, DestroyReason reason)
		{
		}

		public ChangeList GetPrioritizedList()
		{
			return null;
		}

		public void UpdateWithSent(IReadOnlyList<Entity> sent, IReadOnlyList<Entity> sentIDs)
		{
		}

		public void ReprioritizeHeldBackChanges()
		{
		}

		public void MergeIfOrderedComponents(Entity entity, ref DeltaComponents components)
		{
		}

		public void ApplyOrderedComponentsFromSent(SentCache sentCache)
		{
		}

		public void UpdateFromCache(ChangeBuffer dropped, Queue<ChangeBuffer> inFlightChanges)
		{
		}

		public void Acknowledge(ChangeBuffer ackedChanges, Queue<ChangeBuffer> inFlightChanges)
		{
		}

		public int GetLength()
		{
			return 0;
		}

		private void AcknowledgeOrderedComponents(Queue<ChangeBuffer> inFlightChanges, Entity ackedEntity, EntityState ackedChange)
		{
		}

		private void ApplyDelta(ChangeBuffer delta)
		{
		}

		private EntityState GetInternalState(Entity entity)
		{
			return default(EntityState);
		}

		private EntityArchetypeLOD GetArchetypeLOD(IExtendedDefinition root, EntityMeta meta)
		{
			return null;
		}

		private void UpdateEntity(Coherence.RSL.ReplicationManager.ClientWorld.EntityChange change)
		{
		}

		private void DestroyEntity(Coherence.RSL.ReplicationManager.ClientWorld.EntityChange change)
		{
		}

		private void CreateEntity(Coherence.RSL.ReplicationManager.ClientWorld.EntityChange change)
		{
		}

		private void RemoveComponent(Coherence.RSL.ReplicationManager.ClientWorld.EntityChange change)
		{
		}

		public bool HasPendingCreate(Entity entity)
		{
			return false;
		}

		public uint[] GetPendingRemoves(Entity entity)
		{
			return null;
		}

		public string PrintData()
		{
			return null;
		}

		public void ShiftPositionComponents(Vector3d floatingOriginShift)
		{
		}

		public bool HasChanges()
		{
			return false;
		}
	}
}
