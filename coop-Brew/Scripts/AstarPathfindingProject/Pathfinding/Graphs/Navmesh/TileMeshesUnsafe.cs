using Unity.Collections;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileMeshesUnsafe
	{
		public NativeArray<TileMesh.TileMeshUnsafe> tileMeshes;

		public IntRect tileRect;

		public Vector2 tileWorldSize;

		public TileMeshesUnsafe(NativeArray<TileMesh.TileMeshUnsafe> tileMeshes, IntRect tileRect, Vector2 tileWorldSize)
		{
			this.tileMeshes = default(NativeArray<TileMesh.TileMeshUnsafe>);
			this.tileRect = default(IntRect);
			this.tileWorldSize = default(Vector2);
		}

		public TileMeshes ToManaged()
		{
			return default(TileMeshes);
		}

		public void Dispose(Allocator allocator)
		{
		}
	}
}
