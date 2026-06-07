using System.Collections.Generic;
using Coherence.Entities;
using Coherence.RSL.EntityManager.Requests;

namespace Coherence.RSL.ReplicationManager.InBuffer
{
	public struct RefsResolver
	{
		private Dictionary<Entity, List<Entity>> referencedEntities;

		private HashSet<Entity> unresolvableEntities;

		public static void GetResolvableEntities(List<Entity> resolvableEntitiesBuffer, IReadOnlyList<RefsInfo> info, IEntityMapper mapper)
		{
		}

		private RefsResolver(IReadOnlyList<RefsInfo> info, IEntityMapper mapper)
		{
			referencedEntities = null;
			unresolvableEntities = null;
		}

		private bool IsUnresolvable(Entity entity)
		{
			return false;
		}

		private void MarkUnresolvable(Entity entity, IEntityMapper mapper)
		{
		}
	}
}
