using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Requests
{
	public struct RefsInfo
	{
		private Entity referer;

		private HashSet<Entity> refFields;

		public RefsInfo(Entity referer, HashSet<Entity> refFields)
		{
			this.referer = default(Entity);
			this.refFields = null;
		}

		public Entity GetReferer()
		{
			return default(Entity);
		}

		public List<Entity> GetReferencedEntities()
		{
			return null;
		}

		public bool HasAnyRefs()
		{
			return false;
		}

		public bool IsDirectlyUnresolvable(IEntityMapper mapper, IReadOnlyList<Entity> localKnownEntities)
		{
			return false;
		}

		public void Append(RefsInfo other)
		{
		}
	}
}
