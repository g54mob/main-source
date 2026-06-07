using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile]
	public struct FilterIncludeMaskJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<byte> TextureMaskData;

		public void Execute(int index)
		{
			if (Excluded[index] != 1 && TextureMaskData[index] == 0)
			{
				Excluded[index] = 1;
			}
		}
	}
}
