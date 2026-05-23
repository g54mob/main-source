using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertRotationsFloatToFloatJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<float4>.ReadOnly input;

		[WriteOnly]
		public NativeArray<quaternion> result;

		public void Execute(int index)
		{
			float4 float5 = input[index];
			float5.y *= -1f;
			float5.z *= -1f;
			result[index] = float5;
		}
	}
}
