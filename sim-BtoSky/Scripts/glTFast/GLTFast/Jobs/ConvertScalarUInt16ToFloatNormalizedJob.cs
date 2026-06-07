using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertScalarUInt16ToFloatNormalizedJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<ushort>.ReadOnly input;

		[WriteOnly]
		public NativeArray<float> result;

		public void Execute(int index)
		{
			result[index] = (float)(int)input[index] / 65535f;
		}
	}
}
