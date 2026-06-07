using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Pathfinding.RVO
{
	[BurstCompile(CompileSynchronously = false, FloatMode = FloatMode.Fast)]
	public struct JobRVOPreprocess : IJob
	{
		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public SimulatorBurst.AgentOutputData previousOutput;

		[WriteOnly]
		public SimulatorBurst.TemporaryAgentData temporaryAgentData;

		public int startIndex;

		public int endIndex;

		public void Execute()
		{
			for (int i = startIndex; i < endIndex; i++)
			{
				if (agentData.version[i].Valid)
				{
					if (agentData.locked[i] & !agentData.manuallyControlled[i])
					{
						temporaryAgentData.desiredTargetPointInVelocitySpace[i] = float2.zero;
						temporaryAgentData.desiredVelocity[i] = float3.zero;
						temporaryAgentData.currentVelocity[i] = float3.zero;
						continue;
					}
					float2 float5 = agentData.movementPlane[i].ToPlane(agentData.targetPoint[i] - agentData.position[i]);
					temporaryAgentData.desiredTargetPointInVelocitySpace[i] = float5;
					float3 float6 = math.normalizesafe(previousOutput.targetPoint[i] - agentData.position[i]) * previousOutput.speed[i];
					temporaryAgentData.desiredVelocity[i] = agentData.movementPlane[i].ToWorld(math.normalizesafe(float5) * agentData.desiredSpeed[i]);
					float3 float7 = math.normalizesafe(agentData.collisionNormal[i]);
					float y = math.dot(float6, float7);
					float6 -= math.min(0f, y) * float7;
					temporaryAgentData.currentVelocity[i] = float6;
				}
			}
		}
	}
}
