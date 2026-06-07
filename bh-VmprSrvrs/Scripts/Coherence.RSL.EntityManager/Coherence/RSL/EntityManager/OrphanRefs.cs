using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;
using Coherence.RSL.EntityManager.Requests;

namespace Coherence.RSL.EntityManager
{
	public class OrphanRefs
	{
		private readonly Logger logger;

		private readonly Dictionary<Entity, List<Entity>> referencesByOrphan;

		private readonly Dictionary<Entity, Dictionary<Entity, OrphanRefData>> orphansByReferencedEntity;

		public OrphanRefs(Logger logger)
		{
		}

		public bool AddOrphan(Entity orphan, ComponentData componentData, in EntityMeta meta)
		{
			return false;
		}

		public bool RemoveOrphan(Entity orphan)
		{
			return false;
		}

		public List<OrphanRefData> GetOrphansReferencingEntity(Entity referencedEntity)
		{
			return null;
		}

		public List<OrphanRefData> RemoveEntity(Entity referencedEntity)
		{
			return null;
		}

		public void GetOrphanUpdatesForDestroyedEntity(Entity referencedEntity, List<UpdateComponentsRequest> orphanUpdatesBuffer)
		{
		}

		private void AddRefsFromOrphanComponents(Entity orphan, ComponentData componentData, ICoherenceComponentData component, in EntityMeta meta, List<Entity> referencedEntities)
		{
		}

		private (string, List<Entity>) ValidateEntry(Entity orphan, bool expectFound)
		{
			return default((string, List<Entity>));
		}
	}
}
