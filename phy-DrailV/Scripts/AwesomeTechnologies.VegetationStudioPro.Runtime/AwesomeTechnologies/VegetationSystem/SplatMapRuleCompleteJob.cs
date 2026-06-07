using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile]
	public struct SplatMapRuleCompleteJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<byte> TerrainTextureData;

		public bool Include;

		public void Execute(int index)
		{
			if (Excluded[index] == 1)
			{
				return;
			}
			if (Include)
			{
				if (TerrainTextureData[index] != 1)
				{
					Excluded[index] = 1;
				}
				else
				{
					TerrainTextureData[index] = 0;
				}
			}
			else if (TerrainTextureData[index] == 1)
			{
				Excluded[index] = 1;
			}
			else
			{
				TerrainTextureData[index] = 0;
			}
		}
	}
}
