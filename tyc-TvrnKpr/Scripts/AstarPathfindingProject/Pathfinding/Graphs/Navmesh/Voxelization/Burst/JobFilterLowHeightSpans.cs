using Unity.Burst;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobFilterLowHeightSpans : IJob
	{
		public LinkedVoxelField field;

		public uint voxelWalkableHeight;

		public void Execute()
		{
		}
	}
}
