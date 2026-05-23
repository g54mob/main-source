using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

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
			NativeArray<float> neighbourDistances = new NativeArray<float>(50, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = startIndex; i < startIndex + count; i++)
			{
				if (agentData.version[i].Valid)
				{
					CalculateNeighbours(i, outNeighbours, neighbourDistances);
				}
			}
		}

		private void CalculateNeighbours(int agentIndex, NativeArray<int> neighbours, NativeArray<float> neighbourDistances)
		{
			int num = math.min(50, agentData.maxNeighbours[agentIndex]);
			int num2 = agentIndex * 50;
			quadtree.QueryKNearest(new RVOQuadtreeBurst.QuadtreeQuery
			{
				position = agentData.position[agentIndex],
				speed = agentData.maxSpeed[agentIndex],
				agentRadius = agentData.radius[agentIndex],
				timeHorizon = agentData.agentTimeHorizon[agentIndex],
				outputStartIndex = num2,
				maxCount = num,
				result = neighbours,
				resultDistances = neighbourDistances
			});
			int i;
			for (i = 0; i < num && math.isfinite(neighbourDistances[i]); i++)
			{
			}
			output.numNeighbours[agentIndex] = i;
			MovementPlaneWrapper val = default(MovementPlaneWrapper);
			val.Set(agentData.movementPlane[agentIndex]);
			val.ToPlane(agentData.position[agentIndex], out var elevation);
			for (int j = 0; j < i; j++)
			{
				int num3 = neighbours[num2 + j];
				val.ToPlane(agentData.position[num3], out var elevation2);
				float num4 = math.min(elevation + agentData.height[agentIndex], elevation2 + agentData.height[num3]);
				float num5 = math.max(elevation, elevation2);
				if ((num4 < num5 || num3 == agentIndex) | ((agentData.collidesWith[agentIndex] & agentData.layer[num3]) == 0))
				{
					i--;
					neighbours[num2 + j] = neighbours[num2 + i];
					j--;
				}
			}
			if (i < 50)
			{
				neighbours[num2 + i] = -1;
			}
		}
	}
}
