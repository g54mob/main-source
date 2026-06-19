using Unity.Entities;

namespace Pug.ECS.Hybrid
{
	public interface IGraphicalSpawn
	{
		void Spawn(Entity entity, EntityManager entityManager);
	}
}
