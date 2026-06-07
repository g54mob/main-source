using Unity.Entities;

namespace Pathfinding.ECS
{
	public struct GravityState : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
		public float verticalVelocity;
	}
}
