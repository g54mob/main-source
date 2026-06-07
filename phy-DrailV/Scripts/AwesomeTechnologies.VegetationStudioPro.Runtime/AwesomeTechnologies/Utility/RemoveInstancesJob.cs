using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.Utility
{
	[BurstCompile]
	public struct RemoveInstancesJob : IJob
	{
		public NativeList<ItemSelectorInstanceInfo> InstanceList;

		public void Execute()
		{
			for (int num = InstanceList.Length - 1; num >= 0; num--)
			{
				if (InstanceList[num].Remove == 1)
				{
					InstanceList.RemoveAtSwapBack(num);
				}
			}
		}
	}
}
