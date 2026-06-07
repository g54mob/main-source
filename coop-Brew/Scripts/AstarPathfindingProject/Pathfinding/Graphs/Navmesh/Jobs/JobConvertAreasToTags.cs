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
		}
	}
}
