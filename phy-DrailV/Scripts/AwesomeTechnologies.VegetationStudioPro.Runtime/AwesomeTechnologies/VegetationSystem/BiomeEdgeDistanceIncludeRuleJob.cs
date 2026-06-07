using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct BiomeEdgeDistanceIncludeRuleJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<float> BiomeDistance;

		public float MaxDistance;

		public bool Inverse;

		public void Execute(int index)
		{
			if (Excluded[index] == 1)
			{
				return;
			}
			if (Inverse)
			{
				if (BiomeDistance[index] < MaxDistance)
				{
					Excluded[index] = 1;
				}
			}
			else if (BiomeDistance[index] > MaxDistance)
			{
				Excluded[index] = 1;
			}
		}
	}
}
