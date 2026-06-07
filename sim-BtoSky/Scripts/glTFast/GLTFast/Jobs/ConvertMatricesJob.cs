using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertMatricesJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<float4x4>.ReadOnly input;

		[WriteOnly]
		public NativeArray<float4x4> result;

		public void Execute(int index)
		{
			float4x4 float4x5 = input[index];
			result[index] = new float4x4(float4x5.c0.x, 0f - float4x5.c1.x, 0f - float4x5.c2.x, 0f - float4x5.c3.x, 0f - float4x5.c0.y, float4x5.c1.y, float4x5.c2.y, float4x5.c3.y, 0f - float4x5.c0.z, float4x5.c1.z, float4x5.c2.z, float4x5.c3.z, float4x5.c0.w, float4x5.c1.w, float4x5.c2.w, float4x5.c3.w);
		}
	}
}
