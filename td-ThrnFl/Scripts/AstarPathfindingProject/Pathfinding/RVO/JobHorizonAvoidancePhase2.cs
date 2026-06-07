using Pathfinding.ECS.RVO;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.RVO
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobHorizonAvoidancePhase2 : IJobParallelForBatched
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
			float2 float5 = default(float2);
			for (int i = startIndex; i < startIndex + count; i++)
			{
				if (!versions[i].Valid || horizonAgentData.horizonSide[i] == 0)
				{
					continue;
				}
				if (horizonAgentData.horizonSide[i] == 2)
				{
					float num = 0f;
					NativeSlice<int> nativeSlice = neighbours.Slice(i * 50, 50);
					for (int j = 0; j < nativeSlice.Length && nativeSlice[j] != -1; j++)
					{
						int index = nativeSlice[j];
						float num2 = 0f - (horizonAgentData.horizonMinAngle[index] + horizonAgentData.horizonMaxAngle[index]);
						num += num2;
					}
					float num3 = 0f - (horizonAgentData.horizonMinAngle[i] + horizonAgentData.horizonMaxAngle[i]);
					num += num3;
					horizonAgentData.horizonSide[i] = ((!(num < 0f)) ? 1 : (-1));
				}
				math.sincos((horizonAgentData.horizonSide[i] < 0) ? horizonAgentData.horizonMinAngle[i] : horizonAgentData.horizonMaxAngle[i], out float5.y, out float5.x);
				desiredVelocity[i] = movementPlane[i].ToWorld(math.length(desiredVelocity[i]) * float5);
				desiredTargetPointInVelocitySpace[i] = math.length(desiredTargetPointInVelocitySpace[i]) * float5;
			}
		}
	}
}
