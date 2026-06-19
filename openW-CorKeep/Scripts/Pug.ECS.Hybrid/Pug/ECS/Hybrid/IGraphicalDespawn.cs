using Unity.Entities;

namespace Pug.ECS.Hybrid
{
	public interface IGraphicalDespawn
	{
		void Despawn(Entity entity, EntityManager entityManager);
	}
}
