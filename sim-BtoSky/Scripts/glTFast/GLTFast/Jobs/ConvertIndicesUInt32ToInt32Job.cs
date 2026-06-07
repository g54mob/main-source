using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertIndicesUInt32ToInt32Job : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<uint>.ReadOnly input;

		[WriteOnly]
		public NativeArray<int> result;

		public void Execute(int index)
		{
			result[index] = (int)input[index];
		}
	}
}
