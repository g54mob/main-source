using Unity.Burst;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobErodeWalkableArea : IJob
	{
		public CompactVoxelField field;

		public int radius;

		public void Execute()
		{
		}
	}
}
