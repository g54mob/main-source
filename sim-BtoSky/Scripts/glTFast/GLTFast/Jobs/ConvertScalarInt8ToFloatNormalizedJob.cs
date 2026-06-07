using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertScalarInt8ToFloatNormalizedJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<sbyte>.ReadOnly input;

		[WriteOnly]
		public NativeArray<float> result;

		public void Execute(int index)
		{
			result[index] = math.max((float)input[index] / 127f, -1f);
		}
	}
}
