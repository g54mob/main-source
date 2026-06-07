using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	public struct ResolvedMovement : IComponentData, IQueryTypeParameter
	{
		public float3 targetPoint;

		public float speed;

		public float turningRadiusMultiplier;

		public float targetRotation;

		public float targetRotationHint;

		public float targetRotationOffset;

		public float rotationSpeed;
	}
}
