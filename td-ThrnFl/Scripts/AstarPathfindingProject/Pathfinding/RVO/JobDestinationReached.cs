using Pathfinding.Drawing;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;

namespace Pathfinding.RVO
{
	[BurstCompile(CompileSynchronously = false, FloatMode = FloatMode.Fast)]
	public struct JobDestinationReached<MovementPlaneWrapper> : IJob where MovementPlaneWrapper : struct, IMovementPlaneWrapper
	{
		private struct TempAgentData
		{
			public bool blockedAndSlow;

			public float distToEndSq;
		}

		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public SimulatorBurst.TemporaryAgentData temporaryAgentData;

		[ReadOnly]
		public SimulatorBurst.ObstacleData obstacleData;

		public SimulatorBurst.AgentOutputData output;

		public int numAgents;

		public CommandBuilder draw;

		private static readonly ProfilerMarker MarkerInvert = new ProfilerMarker("InvertArrows");

		private static readonly ProfilerMarker MarkerAlloc = new ProfilerMarker("Alloc");

		private static readonly ProfilerMarker MarkerFirstPass = new ProfilerMarker("FirstPass");

		public void Execute()
		{
			for (int i = 0; i < numAgents; i++)
			{
				output.effectivelyReachedDestination[i] = ReachedEndOfPath.NotReached;
			}
			NativeArray<int> nativeArray = new NativeArray<int>(agentData.position.Length * 7, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<int> nativeArray2 = new NativeArray<int>(agentData.position.Length, Allocator.Temp);
			NativeCircularBuffer<int> nativeCircularBuffer = new NativeCircularBuffer<int>(16, Allocator.Temp);
			NativeArray<bool> nativeArray3 = new NativeArray<bool>(numAgents, Allocator.Temp);
			NativeArray<TempAgentData> nativeArray4 = new NativeArray<TempAgentData>(numAgents, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int j = 0; j < numAgents; j++)
			{
				if (!agentData.version[j].Valid)
				{
					continue;
				}
				for (int k = 0; k < 7; k++)
				{
					int num = output.blockedByAgents[j * 7 + k];
					if (num == -1)
					{
						break;
					}
					int num2 = nativeArray2[num];
					if (num2 < 7)
					{
						nativeArray[num * 7 + num2] = j;
						nativeArray2[num] = num2 + 1;
					}
				}
			}
			for (int l = 0; l < numAgents; l++)
			{
				if (!agentData.version[l].Valid)
				{
					continue;
				}
				float3 float5 = agentData.position[l];
				NativeMovementPlane nativeMovementPlane = agentData.movementPlane[l];
				float num3 = output.speed[l];
				float3 float6 = agentData.endOfPath[l];
				if (!math.isfinite(float6.x))
				{
					continue;
				}
				float elevation;
				float num4 = math.lengthsq(nativeMovementPlane.ToPlane(float6 - float5, out elevation));
				float num5 = agentData.height[l];
				bool flag = false;
				bool flag2 = false;
				float num6 = agentData.radius[l];
				float num7 = output.forwardClearance[l];
				if (num4 < num6 * num6 * 0.25f && elevation < num5 && elevation > (0f - num5) * 0.5f)
				{
					flag = true;
				}
				bool num8 = num7 < num6 * 0.5f;
				bool flag3 = num3 * num3 < math.max(0.0001f, math.lengthsq(temporaryAgentData.desiredVelocity[l]) * 0.25f);
				bool flag4 = num8 && flag3;
				nativeArray4[l] = new TempAgentData
				{
					blockedAndSlow = flag4,
					distToEndSq = num4
				};
				for (int m = 0; m < 7; m++)
				{
					int num9 = output.blockedByAgents[l * 7 + m];
					if (num9 == -1)
					{
						break;
					}
					float3 float7 = agentData.position[num9];
					float num10 = (math.sqrt(math.lengthsq(nativeMovementPlane.ToPlane(float5 - float7))) + num6 + agentData.radius[num9]) * 0.5f;
					if (!(math.lengthsq(nativeMovementPlane.ToPlane(float6 - 0.5f * (float5 + float7))) < num10 * num10))
					{
						continue;
					}
					bool flag5 = false;
					for (int n = 0; n < 7; n++)
					{
						int num11 = nativeArray[l * 7 + n];
						if (num11 == -1)
						{
							break;
						}
						if (num11 == num9)
						{
							flag5 = true;
							break;
						}
					}
					if (flag5)
					{
						flag2 = true;
						if (flag4)
						{
							flag = true;
						}
					}
				}
				ReachedEndOfPath reachedEndOfPath = (flag ? ReachedEndOfPath.Reached : (flag2 ? ReachedEndOfPath.ReachedSoon : ReachedEndOfPath.NotReached));
				if (reachedEndOfPath == output.effectivelyReachedDestination[l])
				{
					continue;
				}
				output.effectivelyReachedDestination[l] = reachedEndOfPath;
				if (reachedEndOfPath != ReachedEndOfPath.Reached)
				{
					continue;
				}
				nativeArray3[l] = true;
				int num12 = nativeArray2[l];
				for (int num13 = 0; num13 < num12; num13++)
				{
					int num14 = nativeArray[l * 7 + num13];
					if (!nativeArray3[num14])
					{
						nativeCircularBuffer.PushEnd(num14);
					}
				}
			}
			int num15 = 0;
			while (nativeCircularBuffer.Length > 0)
			{
				int num16 = nativeCircularBuffer.PopStart();
				num15++;
				if (output.effectivelyReachedDestination[num16] == ReachedEndOfPath.Reached)
				{
					continue;
				}
				nativeArray3[num16] = false;
				float x = output.speed[num16];
				float3 float8 = agentData.endOfPath[num16];
				if (!math.isfinite(float8.x))
				{
					continue;
				}
				_ = agentData.position[num16];
				bool blockedAndSlow = nativeArray4[num16].blockedAndSlow;
				float distToEndSq = nativeArray4[num16].distToEndSq;
				float num17 = agentData.radius[num16];
				bool flag6 = false;
				bool flag7 = false;
				for (int num18 = 0; num18 < 7; num18++)
				{
					int num19 = output.blockedByAgents[num16 * 7 + num18];
					if (num19 == -1)
					{
						break;
					}
					float3 obj = agentData.endOfPath[num19];
					float num20 = agentData.radius[num19];
					bool flag8 = math.lengthsq(obj - float8) <= distToEndSq * 0.25f;
					if (output.effectivelyReachedDestination[num19] == ReachedEndOfPath.Reached && (flag8 || math.lengthsq(float8 - agentData.position[num19]) < math.lengthsq(num17 + num20)))
					{
						float y = output.speed[num19];
						flag7 |= math.min(x, y) < 0.01f;
						flag6 = flag6 || blockedAndSlow;
					}
				}
				ReachedEndOfPath x2 = (flag6 ? ReachedEndOfPath.Reached : (flag7 ? ReachedEndOfPath.ReachedSoon : ReachedEndOfPath.NotReached));
				x2 = (ReachedEndOfPath)math.max((int)x2, (int)output.effectivelyReachedDestination[num16]);
				if (x2 == output.effectivelyReachedDestination[num16])
				{
					continue;
				}
				output.effectivelyReachedDestination[num16] = x2;
				if (x2 != ReachedEndOfPath.Reached)
				{
					continue;
				}
				nativeArray3[num16] = true;
				int num21 = nativeArray2[num16];
				for (int num22 = 0; num22 < num21; num22++)
				{
					int num23 = nativeArray[num16 * 7 + num22];
					if (!nativeArray3[num23])
					{
						nativeCircularBuffer.PushEnd(num23);
					}
				}
			}
		}
	}
}
