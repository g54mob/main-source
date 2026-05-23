using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Deform
{
	[BurstCompile(CompileSynchronously = true)]
	public struct NormalizeNormalsJob : IJobParallelFor
	{
		public NativeArray<float3> normals;

		public void Execute(int index)
		{
			normals[index] = math.normalize(normals[index]);
		}
	}
}
