using Unity.Burst;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobFilterLedges : IJob
	{
		public LinkedVoxelField field;

		public uint voxelWalkableHeight;

		public int voxelWalkableClimb;

		public float cellSize;

		public float cellHeight;

		public void Execute()
		{
		}
	}
}
