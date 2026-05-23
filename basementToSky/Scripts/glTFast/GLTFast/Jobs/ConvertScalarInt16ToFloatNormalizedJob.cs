using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertScalarInt16ToFloatNormalizedJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<short>.ReadOnly input;

		[WriteOnly]
		public NativeArray<float> result;

		public void Execute(int index)
		{
			result[index] = math.max((float)input[index] / 32767f, -1f);
		}
	}
}
