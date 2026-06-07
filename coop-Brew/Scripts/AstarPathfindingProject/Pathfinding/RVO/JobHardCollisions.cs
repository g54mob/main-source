using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.RVO
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobHardCollisions<MovementPlaneWrapper> : IJobParallelForBatched where MovementPlaneWrapper : struct, IMovementPlaneWrapper
	{
		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public NativeArray<int> neighbours;

		[WriteOnly]
		public NativeArray<float2> collisionVelocityOffsets;

		public float deltaTime;

		public bool enabled;

		private const float CollisionStrength = 0.8f;

		public bool allowBoundsChecks => false;

		public void Execute(int startIndex, int count)
		{
		}
	}
}
