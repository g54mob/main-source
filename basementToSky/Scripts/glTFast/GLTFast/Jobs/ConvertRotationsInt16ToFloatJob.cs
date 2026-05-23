using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertRotationsInt16ToFloatJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<short4>.ReadOnly input;

		[WriteOnly]
		public NativeArray<quaternion> result;

		public void Execute(int index)
		{
			result[index] = input[index].GltfToUnityRotation();
		}
	}
}
