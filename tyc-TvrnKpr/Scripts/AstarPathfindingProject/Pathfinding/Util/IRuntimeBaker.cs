using Unity.Entities;

namespace Pathfinding.Util
{
	internal interface IRuntimeBaker
	{
		void OnCreatedEntity(World world, Entity entity);
	}
}
