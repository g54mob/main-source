using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Query
{
	public interface IFilter
	{
		bool Contains(Entity entity, EntityMeta meta);

		void Update(ICoherenceComponentData comp, IExtendedDefinition root);
	}
}
