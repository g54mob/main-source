using Unity.Burst;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobBuildCompactField : IJob
	{
		public LinkedVoxelField input;

		public CompactVoxelField output;

		public void Execute()
		{
		}
	}
}
