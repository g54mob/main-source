using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.Utility
{
	[BurstCompile]
	public struct ResetVisibilityJob : IJob
	{
		public NativeList<ItemSelectorInstanceInfo> InstanceList;

		public void Execute()
		{
			for (int i = 0; i <= InstanceList.Length - 1; i++)
			{
				ItemSelectorInstanceInfo value = InstanceList[i];
				value.LastVisible = value.Visible;
				value.Visible = 0;
				InstanceList[i] = value;
			}
		}
	}
}
