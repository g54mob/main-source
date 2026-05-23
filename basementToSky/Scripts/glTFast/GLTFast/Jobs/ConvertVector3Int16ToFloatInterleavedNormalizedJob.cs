using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace GLTFast.Jobs
{
	[BurstCompile]
	internal struct ConvertVector3Int16ToFloatInterleavedNormalizedJob : IJobParallelForBatch
	{
		[ReadOnly]
		public ReadOnlyNativeStridedArray<short3> input;

		[ReadOnly]
		public int outputByteStride;

		[ReadOnly]
		[NativeDisableUnsafePtrRestriction]
		public unsafe float3* result;

		public unsafe void Execute(int startIndex, int count)
		{
			float3* ptr = (float3*)((byte*)result + startIndex * outputByteStride);
			int num = startIndex + count;
			for (int i = startIndex; i < num; i++)
			{
				*ptr = input[i].GltfToUnityNormalizedFloat3();
				ptr = (float3*)((byte*)ptr + outputByteStride);
			}
		}
	}
}
