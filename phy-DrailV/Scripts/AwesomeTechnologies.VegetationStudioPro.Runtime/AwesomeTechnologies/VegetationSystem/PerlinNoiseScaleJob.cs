using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct PerlinNoiseScaleJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<float3> Position;

		public NativeArray<float3> Scale;

		public float PerlinScale;

		public bool InversePerlinMask;

		public float2 Offset;

		public float MinScale;

		public float MaxScale;

		public void Execute(int index)
		{
			if (Excluded[index] != 1)
			{
				float num = noise.cnoise(new float2((Position[index].x + Offset.x) / PerlinScale, (Position[index].z + Offset.y) / PerlinScale));
				num += 1f;
				num /= 2f;
				num = math.clamp(num, 0f, 1f);
				num = math.select(num, 1f - num, InversePerlinMask);
				float num2 = math.lerp(MinScale, MaxScale, Mathf.Clamp(num, 0f, 1f));
				float3 float5 = new float3(num2, num2, num2);
				Scale[index] *= float5;
			}
		}
	}
}
