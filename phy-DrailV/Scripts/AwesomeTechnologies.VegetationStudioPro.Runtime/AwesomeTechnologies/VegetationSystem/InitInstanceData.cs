using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile]
	public struct InitInstanceData : IJobParallelFor
	{
		public NativeArray<byte> HeightmapSampled;

		public NativeArray<byte> Excluded;

		public void Execute(int index)
		{
			HeightmapSampled[index] = 0;
			Excluded[index] = 1;
		}
	}
}
