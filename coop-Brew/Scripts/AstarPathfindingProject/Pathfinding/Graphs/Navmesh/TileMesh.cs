using Pathfinding.Collections;
using Unity.Collections;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileMesh
	{
		public struct TileMeshUnsafe
		{
			public UnsafeSpan<int> triangles;

			public UnsafeSpan<Int3> verticesInTileSpace;

			public UnsafeSpan<uint> tags;

			public void Dispose(Allocator allocator)
			{
			}

			public TileMesh ToManaged()
			{
				return default(TileMesh);
			}
		}

		public int[] triangles;

		public Int3[] verticesInTileSpace;

		public uint[] tags;
	}
}
