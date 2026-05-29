using System;
using Pathfinding.Drawing;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobHorizonAvoidancePhase1 : IJobParallelForBatched
	{
		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public NativeArray<float2> desiredTargetPointInVelocitySpace;

		[ReadOnly]
		public NativeArray<int> neighbours;

		public SimulatorBurst.HorizonAgentData horizonAgentData;

		public CommandBuilder draw;

		public bool allowBoundsChecks => true;

		private static void Sort<T>(NativeSlice<T> arr, NativeSlice<float> keys) where T : struct
		{
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int i = 0; i < arr.Length - 1; i++)
				{
					if (keys[i] > keys[i + 1])
					{
						float value = keys[i];
						T value2 = arr[i];
						keys[i] = keys[i + 1];
						keys[i + 1] = value;
						arr[i] = arr[i + 1];
						arr[i + 1] = value2;
						flag = true;
					}
				}
			}
		}

		public static float DeltaAngle(float current, float target)
		{
			float num = Mathf.Repeat(target - current, MathF.PI * 2f);
			if (num > MathF.PI)
			{
				num -= MathF.PI * 2f;
			}
			return num;
		}

		public void Execute(int startIndex, int count)
		{
			NativeArray<float> thisArray = new NativeArray<float>(100, Allocator.Temp);
			NativeArray<int> thisArray2 = new NativeArray<int>(100, Allocator.Temp);
			for (int i = startIndex; i < startIndex + count; i++)
			{
				if (!agentData.version[i].Valid)
				{
					continue;
				}
				if (agentData.locked[i] || agentData.manuallyControlled[i])
				{
					horizonAgentData.horizonSide[i] = 0;
					horizonAgentData.horizonMinAngle[i] = 0f;
					horizonAgentData.horizonMaxAngle[i] = 0f;
					continue;
				}
				float num = 0f;
				float num2 = 0f;
				float num3 = math.atan2(desiredTargetPointInVelocitySpace[i].y, desiredTargetPointInVelocitySpace[i].x);
				int num4 = 0;
				int num5 = 0;
				float num6 = agentData.radius[i];
				float3 float5 = agentData.position[i];
				NativeMovementPlane nativeMovementPlane = agentData.movementPlane[i];
				NativeSlice<int> nativeSlice = neighbours.Slice(i * 50, 50);
				for (int j = 0; j < nativeSlice.Length && nativeSlice[j] != -1; j++)
				{
					int index = nativeSlice[j];
					if (agentData.locked[index] || agentData.manuallyControlled[index])
					{
						float2 x = nativeMovementPlane.ToPlane(agentData.position[index] - float5);
						float num7 = math.length(x);
						float num8 = math.atan2(x.y, x.x) - num3;
						float num9 = agentData.radius[index];
						float num10 = ((!(num7 < num6 + num9)) ? (math.asin((num6 + num9) / num7) + MathF.PI / 180f) : 1.5393804f);
						float num11 = DeltaAngle(0f, num8 - num10);
						float num12 = num11 + DeltaAngle(num11, num8 + num10);
						if (num11 < 0f && num12 > 0f)
						{
							num5++;
						}
						thisArray[num4] = num11;
						thisArray2[num4] = 1;
						num4++;
						thisArray[num4] = num12;
						thisArray2[num4] = -1;
						num4++;
					}
				}
				if (num5 == 0)
				{
					horizonAgentData.horizonSide[i] = 0;
					horizonAgentData.horizonMinAngle[i] = 0f;
					horizonAgentData.horizonMaxAngle[i] = 0f;
					continue;
				}
				Sort(thisArray2.Slice(0, num4), thisArray.Slice(0, num4));
				int k;
				for (k = 0; k < num4 && !(thisArray[k] > 0f); k++)
				{
				}
				int num13 = num5;
				int l;
				for (l = k; l < num4; l++)
				{
					num13 += thisArray2[l];
					if (num13 == 0)
					{
						break;
					}
				}
				num2 = ((l == num4) ? MathF.PI : thisArray[l]);
				num13 = num5;
				for (l = k - 1; l >= 0; l--)
				{
					num13 -= thisArray2[l];
					if (num13 == 0)
					{
						break;
					}
				}
				num = ((l == -1) ? (-MathF.PI) : thisArray[l]);
				if (horizonAgentData.horizonSide[i] == 0)
				{
					horizonAgentData.horizonSide[i] = 2;
				}
				horizonAgentData.horizonMinAngle[i] = num + num3;
				horizonAgentData.horizonMaxAngle[i] = num2 + num3;
			}
		}
	}
}
