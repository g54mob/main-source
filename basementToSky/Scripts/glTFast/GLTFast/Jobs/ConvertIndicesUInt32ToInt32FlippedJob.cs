using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertIndicesUInt32ToInt32FlippedJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<uint3>.ReadOnly input;

		[WriteOnly]
		public NativeArray<int3> result;

		public void Execute(int index)
		{
			uint3 uint5 = input[index];
			result[index] = new int3((int)uint5.x, (int)uint5.z, (int)uint5.y);
		}
	}
}
