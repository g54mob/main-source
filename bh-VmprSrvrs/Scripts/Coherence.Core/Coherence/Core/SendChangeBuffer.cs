using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.Core
{
	internal class SendChangeBuffer : ChangeBuffer
	{
		public const int CREATE_PRIORITY = 100;

		public const int DESTROY_PRIORITY = 1000;

		public const int HELDBACK_PRIORITY = 1000;

		private HashSet<Entity> sentEntities;

		private readonly CacheList<(Entity, DeltaComponents)> entitiesWithOrderedComps;

		private IComponentInfo definition;

		public SendChangeBuffer(IComponentInfo definition, Logger logger)
			: base(null, null, null, default(SequenceId), null)
		{
		}

		public bool HasChanges(IReadOnlyCollection<Entity> ackedEntities)
		{
			return false;
		}

		public int GetPrioritizedChanges(List<EntityChange> existenceChanges, List<EntityChange> updateChanges, IReadOnlyCollection<Entity> ackedEntities)
		{
			return 0;
		}

		public void AppendSentUpdates(ref Dictionary<Entity, OutgoingEntityUpdate> updateMap, IReadOnlyList<Entity> ids)
		{
		}

		public void CreateEntity(EntityCreateChange create)
		{
		}

		public void DestroyEntity(Entity id, IReadOnlyCollection<Entity> ackedEntities, long priority = 1000L)
		{
		}

		public void UpdateEntity(EntityUpdateChange change)
		{
		}

		public void RemoveComponent(EntityRemoveChange change)
		{
		}

		public void ResetWithLostChanges(ChangeBuffer droppedChanges, LinkedList<ChangeBuffer> unackedChanges, IReadOnlyCollection<Entity> ackedEntities)
		{
		}

		public void Acknowledge(ChangeBuffer ackedChanges, LinkedList<ChangeBuffer> unackedChanges)
		{
		}

		public void ApplyOrderedComponentsFromSent(SentCache sentCache, IComponentInfo componentInfo)
		{
		}

		public Dictionary<Entity, OutgoingEntityUpdate> GetEntityMeta()
		{
			return null;
		}

		public OutgoingEntityUpdate? CopyEntityUpdate(Entity entity)
		{
			return null;
		}

		private OutgoingEntityUpdate CreateEntityUpdate(Entity id)
		{
			return default(OutgoingEntityUpdate);
		}

		private OutgoingEntityUpdate FindOrCreateEntityUpdate(Entity id)
		{
			return default(OutgoingEntityUpdate);
		}
	}
}
