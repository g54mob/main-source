using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile]
	public struct AddToInstanceListJob : IJob
	{
		[DeallocateOnJobCompletion]
		public NativeArray<VegetationInstance> SourceInstanceArray;

		public NativeList<VegetationInstance> TargetInstanceList;

		public void Execute()
		{
			for (int i = 0; i <= SourceInstanceArray.Length - 1; i++)
			{
				VegetationInstance value = SourceInstanceArray[i];
				if (value.Excluded != 1)
				{
					TargetInstanceList.Add(value);
				}
			}
		}
	}
}
