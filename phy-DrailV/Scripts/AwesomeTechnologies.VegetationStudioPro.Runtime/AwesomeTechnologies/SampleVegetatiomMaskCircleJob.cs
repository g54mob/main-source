using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace AwesomeTechnologies
{
	[BurstCompile(CompileSynchronously = true)]
	public struct SampleVegetatiomMaskCircleJob : IJobParallelForDefer
	{
		public NativeArray<float3> Position;

		public NativeArray<byte> Excluded;

		public float Radius;

		public float3 MaskPosition;

		public void Execute(int index)
		{
			if (Excluded[index] != 1 && math.distance(new float2(Position[index].x, Position[index].z), new float2(MaskPosition.x, MaskPosition.z)) < Radius)
			{
				Excluded[index] = 1;
			}
		}
	}
}
