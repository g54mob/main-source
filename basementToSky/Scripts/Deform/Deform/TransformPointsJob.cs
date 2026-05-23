using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Deform
{
	[BurstCompile(CompileSynchronously = true)]
	public struct TransformPointsJob : IJobParallelFor
	{
		public NativeArray<float3> points;

		public float4x4 matrix;

		public void Execute(int index)
		{
			points[index] = math.mul(matrix, math.float4(points[index], 1f)).xyz;
		}
	}
}
