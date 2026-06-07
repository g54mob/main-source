using Unity.Burst;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobBuildConnections : IJob
	{
		public CompactVoxelField field;

		public int voxelWalkableHeight;

		public int voxelWalkableClimb;

		public void Execute()
		{
		}
	}
}
