using Pathfinding.ECS.RVO;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.RVO
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobHorizonAvoidancePhase2<MovementPlaneWrapper> : IJobParallelForBatched where MovementPlaneWrapper : struct, IMovementPlaneWrapper
	{
		[ReadOnly]
		public NativeArray<int> neighbours;

		[ReadOnly]
		public NativeArray<AgentIndex> versions;

		public NativeArray<float3> desiredVelocity;

		public NativeArray<float2> desiredTargetPointInVelocitySpace;

		[ReadOnly]
		public NativeArray<NativeMovementPlane> movementPlane;

		public SimulatorBurst.HorizonAgentData horizonAgentData;

		public bool allowBoundsChecks => false;

		public void Execute(int startIndex, int count)
		{
		}
	}
}
