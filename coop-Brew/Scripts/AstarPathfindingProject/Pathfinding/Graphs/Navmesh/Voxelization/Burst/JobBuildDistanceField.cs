using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobBuildDistanceField : IJob
	{
		public CompactVoxelField field;

		public NativeList<ushort> output;

		public void Execute()
		{
		}
	}
}
