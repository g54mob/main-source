using Unity.Entities;
using Unity.Mathematics;

namespace ContainedMiniSim.Components
{
	public struct AquariumFishMovementCD : IComponentData, IQueryTypeParameter
	{
		public float3 targetPosition;

		public float2 swimSpeedMinMax;

		public float2 idleTimeMinMax;

		public float idleTimer;

		public bool isMoving;

		public float smoothingFactor;

		public float speed;
	}
}
