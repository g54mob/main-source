using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Query
{
	public struct QueryResponse
	{
		public List<Entity> Entities;

		public Dictionary<Entity, ICoherenceComponentData[]> Components;

		public Dictionary<Entity, EntityMeta> Metas;

		public Dictionary<Entity, DestroyReason> Destroyed;

		public static QueryResponse New()
		{
			return default(QueryResponse);
		}
	}
}
