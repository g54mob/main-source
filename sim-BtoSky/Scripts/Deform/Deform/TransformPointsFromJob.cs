using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Deform
{
	[BurstCompile(CompileSynchronously = true)]
	public struct TransformPointsFromJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<float3> from;

		[WriteOnly]
		public NativeArray<float3> to;

		public float4x4 matrix;

		public void Execute(int index)
		{
			to[index] = math.mul(matrix, math.float4(from[index], 1f)).xyz;
		}
	}
}
