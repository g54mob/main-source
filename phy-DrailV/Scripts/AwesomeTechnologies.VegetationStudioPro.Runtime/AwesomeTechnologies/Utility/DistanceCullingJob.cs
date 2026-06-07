using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace AwesomeTechnologies.Utility
{
	[BurstCompile]
	public struct DistanceCullingJob : IJob
	{
		public NativeList<ItemSelectorInstanceInfo> InstanceList;

		public float3 CameraPosition;

		public float CullingDistance;

		public void Execute()
		{
			for (int i = 0; i <= InstanceList.Length - 1; i++)
			{
				ItemSelectorInstanceInfo value = InstanceList[i];
				if (math.distance(value.Position, CameraPosition) <= CullingDistance)
				{
					value.Visible = 1;
				}
				else
				{
					value.Visible = -1;
				}
				InstanceList[i] = value;
			}
		}
	}
}
