using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.Utility
{
	[BurstCompile]
	public struct VisibilityChangedFilterManualJob : IJob
	{
		[ReadOnly]
		public NativeList<ItemSelectorInstanceInfo> InstanceList;

		public NativeList<int> VisibilityChangedIndexList;

		public void Execute()
		{
			for (int i = 0; i <= InstanceList.Length - 1; i++)
			{
				ItemSelectorInstanceInfo itemSelectorInstanceInfo = InstanceList[i];
				if (itemSelectorInstanceInfo.Visible != itemSelectorInstanceInfo.LastVisible)
				{
					VisibilityChangedIndexList.Add(i);
				}
			}
		}
	}
}
