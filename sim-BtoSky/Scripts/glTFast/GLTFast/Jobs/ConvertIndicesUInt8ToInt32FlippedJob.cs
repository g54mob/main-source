using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertIndicesUInt8ToInt32FlippedJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<byte3>.ReadOnly input;

		[WriteOnly]
		public NativeArray<int3> result;

		public void Execute(int index)
		{
			result[index] = input[index].GltfToUnityTriangleIndies();
		}
	}
}
