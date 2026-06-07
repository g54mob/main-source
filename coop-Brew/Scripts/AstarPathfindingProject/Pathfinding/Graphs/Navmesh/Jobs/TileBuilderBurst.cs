using Pathfinding.Graphs.Navmesh.Voxelization.Burst;
using Pathfinding.Jobs;
using Unity.Collections;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct TileBuilderBurst : IArenaDisposable
	{
		public LinkedVoxelField linkedVoxelField;

		public CompactVoxelField compactVoxelField;

		public NativeList<ushort> distanceField;

		public NativeQueue<Int3> tmpQueue1;

		public NativeQueue<Int3> tmpQueue2;

		public NativeList<VoxelContour> contours;

		public NativeList<int> contourVertices;

		public VoxelMesh voxelMesh;

		public TileBuilderBurst(int width, int depth, int voxelWalkableHeight, int maximumVoxelYCoord)
		{
			linkedVoxelField = default(LinkedVoxelField);
			compactVoxelField = default(CompactVoxelField);
			distanceField = default(NativeList<ushort>);
			tmpQueue1 = default(NativeQueue<Int3>);
			tmpQueue2 = default(NativeQueue<Int3>);
			contours = default(NativeList<VoxelContour>);
			contourVertices = default(NativeList<int>);
			voxelMesh = default(VoxelMesh);
		}

		void IArenaDisposable.DisposeWith(DisposeArena arena)
		{
		}
	}
}
