using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertIndicesUInt8ToInt32Job : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<byte>.ReadOnly input;

		[WriteOnly]
		public NativeArray<int> result;

		public void Execute(int index)
		{
			result[index] = input[index];
		}
	}
}
