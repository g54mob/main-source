using Unity.Core;
using Unity.Entities;

namespace Pug.ECS.Hybrid
{
	public interface IGraphicalObject : IGraphicalSpawn, IGraphicalDespawn
	{
		void GraphicalUpdate(Entity entity, EntityManager entityManager, TimeData timeData);
	}
}
