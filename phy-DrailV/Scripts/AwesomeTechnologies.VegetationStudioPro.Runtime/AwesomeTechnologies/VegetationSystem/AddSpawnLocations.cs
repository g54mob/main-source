using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct AddSpawnLocations : IJob
	{
		[WriteOnly]
		public NativeList<VegetationSpawnLocationInstance> SpawnLocations;

		public int SampleCount;

		public void Execute()
		{
			for (int i = 0; i <= SampleCount - 1; i++)
			{
				SpawnLocations.Add(default(VegetationSpawnLocationInstance));
			}
		}
	}
}
