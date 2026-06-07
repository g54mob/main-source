using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.Core
{
	internal struct RefsInfo
	{
		private static readonly List<Entity> EmptyRefs;

		public Entity Referer;

		private readonly List<Entity> referencedEntities;

		public IReadOnlyList<Entity> ReferencedEntities => null;

		public bool HasAnyRefs => false;

		public RefsInfo(in IncomingEntityUpdate update)
		{
			Referer = default(Entity);
			referencedEntities = null;
		}

		public RefsInfo(in Entity referer, List<Entity> referencedEntities)
		{
			Referer = default(Entity);
			this.referencedEntities = null;
		}
	}
}
