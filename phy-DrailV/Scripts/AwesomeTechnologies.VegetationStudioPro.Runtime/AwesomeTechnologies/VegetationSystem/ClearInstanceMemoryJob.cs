using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile]
	public struct ClearInstanceMemoryJob : IJobParallelFor
	{
		public NativeArray<VegetationInstance> VegetationInstanceList;

		public void Execute(int index)
		{
			VegetationInstanceList[index] = default(VegetationInstance);
		}
	}
}
