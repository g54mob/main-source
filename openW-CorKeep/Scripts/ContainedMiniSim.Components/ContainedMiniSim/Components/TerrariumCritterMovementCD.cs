using Unity.Entities;
using Unity.Mathematics;

namespace ContainedMiniSim.Components
{
	public struct TerrariumCritterMovementCD : IComponentData, IQueryTypeParameter
	{
		public float3 targetPosition;

		public float idleTimer;

		public bool isMoving;

		public float moveSpeed;

		public float2 minMaxIdleTime;
	}
}
