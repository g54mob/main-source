using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.Utility
{
	[BurstCompile]
	public struct FlagInstancesForRemovalJob : IJob
	{
		public NativeList<ItemSelectorInstanceInfo> InstanceList;

		[ReadOnly]
		public NativeList<int> RemoveCellIndexList;

		public void Execute()
		{
			for (int i = 0; i <= InstanceList.Length - 1; i++)
			{
				ItemSelectorInstanceInfo value = InstanceList[i];
				for (int j = 0; j <= RemoveCellIndexList.Length - 1; j++)
				{
					if (value.VegetationCellIndex == RemoveCellIndexList[j])
					{
						value.Remove = 1;
						InstanceList[i] = value;
						break;
					}
				}
			}
		}
	}
}
