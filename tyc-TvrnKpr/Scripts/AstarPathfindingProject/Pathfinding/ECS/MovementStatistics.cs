using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	public struct MovementStatistics : IComponentData, IQueryTypeParameter
	{
		public float3 estimatedVelocity;

		public float3 lastPosition;
	}
}
