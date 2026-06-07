using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace DV.VFX
{
	[BurstCompile]
	public struct LightsLODJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<float4> dataNativeArray;

		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> resultNativeArray;

		public float3 cameraPos;

		public float range;

		public void Execute(int index)
		{
			float4 float5 = dataNativeArray[index];
			float t = math.clamp(math.length(cameraPos - float5.xyz) / range, 0f, 1f);
			resultNativeArray[index] = math.lerp(float5.w, 0f, t) * 2f;
		}
	}
}
