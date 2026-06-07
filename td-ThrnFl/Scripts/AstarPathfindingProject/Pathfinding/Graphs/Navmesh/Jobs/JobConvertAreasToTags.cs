using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	[BurstCompile]
	public struct JobConvertAreasToTags : IJob
	{
		public NativeList<int> areas;

		public void Execute()
		{
			for (int i = 0; i < areas.Length; i++)
			{
				int num = areas[i];
				areas[i] = (((num & 0x4000) != 0) ? ((num & 0x3FFF) - 1) : 0);
			}
		}
	}
}
