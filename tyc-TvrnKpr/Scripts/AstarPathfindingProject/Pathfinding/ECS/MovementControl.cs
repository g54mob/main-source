using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	public struct MovementControl : IComponentData, IQueryTypeParameter
	{
		public float3 targetPoint;

		public float3 endOfPath;

		public float speed;

		public float maxSpeed;

		public int hierarchicalNodeIndex;

		public float targetRotation;

		public float targetRotationHint;

		public float targetRotationOffset;

		public float rotationSpeed;

		public bool overrideLocalAvoidance;
	}
}
