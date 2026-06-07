using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct TerrainSourceIncludeRuleJob : IJobParallelForDefer
	{
		public NativeArray<byte> TerrainSourceID;

		public NativeArray<byte> Excluded;

		public TerrainSourceRule TerrainSourceRule;

		public void Execute(int index)
		{
			if (Excluded[index] != 1 && !TerrainSourceRule[TerrainSourceID[index]])
			{
				Excluded[index] = 1;
			}
		}
	}
}
