using Pathfinding.Util;
using Unity.Collections.LowLevel.Unsafe;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileMesh
	{
		public struct TileMeshUnsafe
		{
			public UnsafeAppendBuffer triangles;

			public UnsafeAppendBuffer verticesInTileSpace;

			public UnsafeAppendBuffer tags;

			public void Dispose()
			{
				triangles.Dispose();
				verticesInTileSpace.Dispose();
				tags.Dispose();
			}

			public TileMesh ToManaged()
			{
				return new TileMesh
				{
					triangles = Memory.UnsafeAppendBufferToArray<int>(triangles),
					verticesInTileSpace = Memory.UnsafeAppendBufferToArray<Int3>(verticesInTileSpace),
					tags = Memory.UnsafeAppendBufferToArray<uint>(tags)
				};
			}
		}

		public int[] triangles;

		public Int3[] verticesInTileSpace;

		public uint[] tags;
	}
}
