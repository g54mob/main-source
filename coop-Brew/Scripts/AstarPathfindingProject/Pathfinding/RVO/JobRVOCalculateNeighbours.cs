using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;

namespace Pathfinding.RVO
{
	[BurstCompile(CompileSynchronously = false, FloatMode = FloatMode.Fast)]
	public struct JobRVOCalculateNeighbours<MovementPlaneWrapper> : IJobParallelForBatched where MovementPlaneWrapper : struct, IMovementPlaneWrapper
	{
		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public RVOQuadtreeBurst quadtree;

		public NativeArray<int> outNeighbours;

		[WriteOnly]
		public SimulatorBurst.AgentOutputData output;

		public bool allowBoundsChecks => false;

		public void Execute(int startIndex, int count)
		{
		}

		private void CalculateNeighbours(int agentIndex, NativeArray<int> neighbours, NativeArray<float> neighbourDistances)
		{
		}
	}
}
