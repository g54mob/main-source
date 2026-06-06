using Pathfinding.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile]
	public struct JobBuildMesh : IJob
	{
		public NativeList<int> contourVertices;

		public NativeList<VoxelContour> contours;

		public VoxelMesh mesh;

		public CompactVoxelField field;

		private static bool Diagonal(int i, int j, int n, NativeArray<int> verts, NativeArray<int> indices)
		{
			return false;
		}

		private static bool InCone(int i, int j, int n, NativeArray<int> verts, NativeArray<int> indices)
		{
			return false;
		}

		private static bool Left(int a, int b, int c, NativeArray<int> verts)
		{
			return false;
		}

		private static bool LeftOn(int a, int b, int c, NativeArray<int> verts)
		{
			return false;
		}

		private static bool Collinear(int a, int b, int c, NativeArray<int> verts)
		{
			return false;
		}

		public static int Area2(int a, int b, int c, NativeArray<int> verts)
		{
			return 0;
		}

		private static bool Diagonalie(int i, int j, int n, NativeArray<int> verts, NativeArray<int> indices)
		{
			return false;
		}

		private static bool Xorb(bool x, bool y)
		{
			return false;
		}

		private static bool IntersectProp(int a, int b, int c, int d, NativeArray<int> verts)
		{
			return false;
		}

		private static bool Between(int a, int b, int c, NativeArray<int> verts)
		{
			return false;
		}

		private static bool Intersect(int a, int b, int c, int d, NativeArray<int> verts)
		{
			return false;
		}

		private static bool Vequal(int a, int b, NativeArray<int> verts)
		{
			return false;
		}

		private static int Prev(int i, int n)
		{
			return 0;
		}

		private static int Next(int i, int n)
		{
			return 0;
		}

		private static int AddVertex(NativeList<Int3> vertices, NativeHashMap<Int3, int> vertexMap, Int3 vertex)
		{
			return 0;
		}

		public void Execute()
		{
		}

		private void RemoveTileBorderVertices(ref VoxelMesh mesh, NativeArray<bool> verticesToRemove)
		{
		}

		private bool CanRemoveVertex(ref VoxelMesh mesh, int vertexToRemove, UnsafeSpan<byte> vertexScratch)
		{
			return false;
		}

		private void RemoveVertex(ref VoxelMesh mesh, int vertexToRemove)
		{
		}

		private static int Triangulate(int n, NativeArray<int> verts, NativeArray<int> indices, NativeArray<int> tris)
		{
			return 0;
		}
	}
}
