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
			if (!enabled)
			{
				for (int i = startIndex; i < startIndex + count; i++)
				{
					collisionVelocityOffsets[i] = float2.zero;
				}
				return;
			}
			for (int j = startIndex; j < startIndex + count; j++)
			{
				if (!agentData.version[j].Valid || agentData.locked[j])
				{
					collisionVelocityOffsets[j] = float2.zero;
					continue;
				}
				NativeSlice<int> nativeSlice = neighbours.Slice(j * 50, 50);
				float num = agentData.radius[j];
				float2 zero = float2.zero;
				float num2 = 0f;
				float3 float5 = agentData.position[j];
				MovementPlaneWrapper val = new MovementPlaneWrapper();
				val.Set(agentData.movementPlane[j]);
				for (int k = 0; k < nativeSlice.Length && nativeSlice[k] != -1; k++)
				{
					int index = nativeSlice[k];
					float2 float6 = val.ToPlane(float5 - agentData.position[index]);
					float num3 = math.lengthsq(float6);
					float num4 = agentData.radius[index] + num;
					if (num3 < num4 * num4 && num3 > 1E-08f)
					{
						float num5 = math.sqrt(num3);
						float2 obj = float6 * (1f / num5);
						float num6 = num4 - num5;
						float2 float7 = obj * num6 * num6;
						zero += float7;
						num2 += num6;
					}
				}
				float2 value = zero * (1f / (0.0001f + num2));
				value *= 0.4f / deltaTime;
				collisionVelocityOffsets[j] = value;
			}
		}
	}
}
