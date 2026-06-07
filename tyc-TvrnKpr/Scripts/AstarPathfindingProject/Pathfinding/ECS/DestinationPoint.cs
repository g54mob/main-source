using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	public struct DestinationPoint : IComponentData, IQueryTypeParameter
	{
		public float3 destination;

		public float3 facingDirection;
	}
}
