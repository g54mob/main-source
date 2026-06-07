using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	public struct JobBuildContours : IJob
	{
		public CompactVoxelField field;

		public float maxError;

		public float maxEdgeLength;

		public int buildFlags;

		public float cellSize;

		public NativeList<VoxelContour> outputContours;

		public NativeList<int> outputVerts;

		public void Execute()
		{
		}

		private void GetClosestIndices(NativeArray<int> verts, int vertexStartIndexA, int nvertsa, int vertexStartIndexB, int nvertsb, out int ia, out int ib)
		{
			ia = default(int);
			ib = default(int);
		}

		public static bool MergeContours(NativeList<int> verts, ref VoxelContour ca, ref VoxelContour cb, int ia, int ib)
		{
			return false;
		}

		public void SimplifyContour(NativeList<int> verts, NativeList<int> simplified, float maxError, int buildFlags)
		{
		}

		public void WalkContour(int x, int z, int i, NativeArray<ushort> flags, NativeList<int> verts)
		{
		}

		public int GetCornerHeight(int x, int z, int i, int dir, ref bool isBorderVertex)
		{
			return 0;
		}

		private static void RemoveRange(NativeList<int> arr, int index, int count)
		{
		}

		private static void RemoveDegenerateSegments(NativeList<int> simplified)
		{
		}

		private int CalcAreaOfPolygon2D(NativeArray<int> verts, int vertexStartIndex, int nverts)
		{
			return 0;
		}

		private static bool Ileft(NativeArray<int> verts, int a, int b, int c)
		{
			return false;
		}
	}
}
