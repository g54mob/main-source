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
			linkedVoxelField = new LinkedVoxelField(width, depth, maximumVoxelYCoord);
			compactVoxelField = new CompactVoxelField(width, depth, voxelWalkableHeight, Allocator.Persistent);
			tmpQueue1 = new NativeQueue<Int3>(Allocator.Persistent);
			tmpQueue2 = new NativeQueue<Int3>(Allocator.Persistent);
			distanceField = new NativeList<ushort>(0, Allocator.Persistent);
			contours = new NativeList<VoxelContour>(Allocator.Persistent);
			contourVertices = new NativeList<int>(Allocator.Persistent);
			voxelMesh = new VoxelMesh
			{
				verts = new NativeList<Int3>(Allocator.Persistent),
				tris = new NativeList<int>(Allocator.Persistent),
				areas = new NativeList<int>(Allocator.Persistent)
			};
		}

		void IArenaDisposable.DisposeWith(DisposeArena arena)
		{
			arena.Add(linkedVoxelField);
			arena.Add(compactVoxelField);
			arena.Add(distanceField);
			arena.Add(tmpQueue1);
			arena.Add(tmpQueue2);
			arena.Add(contours);
			arena.Add(contourVertices);
			arena.Add(voxelMesh);
		}
	}
}
