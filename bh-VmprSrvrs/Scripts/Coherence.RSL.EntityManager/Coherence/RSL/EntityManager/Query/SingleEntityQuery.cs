using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Query
{
	public struct SingleEntityQuery : IFilter
	{
		private Entity entity;

		public SingleEntityQuery(Entity entity)
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
