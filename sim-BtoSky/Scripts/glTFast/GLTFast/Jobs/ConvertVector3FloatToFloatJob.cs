using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertVector3FloatToFloatJob : IJobParallelFor
	{
		[ReadOnly]
		public ReadOnlyNativeStridedArray<float3> input;

		[WriteOnly]
		public NativeArray<float3> result;

		public void Execute(int index)
		{
			float3 value = input[index];
			value.x *= -1f;
			result[index] = value;
		}
	}
}
