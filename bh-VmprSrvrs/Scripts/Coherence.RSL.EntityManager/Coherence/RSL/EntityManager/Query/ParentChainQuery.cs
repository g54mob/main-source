using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Query
{
	public struct ParentChainQuery : IFilter
	{
		private Entity entity;

		public ParentChainQuery(Entity entity)
		{
			this.entity = default(Entity);
		}

		public Entity Entity()
		{
			return default(Entity);
		}

		public bool Contains(Entity entity, EntityMeta _)
		{
			return false;
		}

		public void Update(ICoherenceComponentData comp, IExtendedDefinition root)
		{
		}
	}
}
