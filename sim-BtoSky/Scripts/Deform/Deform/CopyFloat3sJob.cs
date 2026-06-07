using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Deform
{
	[BurstCompile(CompileSynchronously = true)]
	public struct CopyFloat3sJob : IJobParallelFor
	{
		public NativeArray<float3> from;

		public NativeArray<float3> to;

		public void Execute(int index)
		{
			to[index] = from[index];
		}
	}
}
