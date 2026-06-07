using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.RVO
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobHorizonAvoidancePhase1<MovementPlaneWrapper> : IJobParallelForBatched where MovementPlaneWrapper : struct, IMovementPlaneWrapper
	{
		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public NativeArray<float2> desiredTargetPointInVelocitySpace;

		[ReadOnly]
		public NativeArray<int> neighbours;

		public SimulatorBurst.HorizonAgentData horizonAgentData;

		public bool allowBoundsChecks => false;

		private static void Sort<T>(NativeSlice<T> arr, NativeSlice<float> keys) where T : struct
		{
		}

		public static float DeltaAngle(float current, float target)
		{
			return 0f;
		}

		public void Execute(int startIndex, int count)
		{
		}
	}
}
