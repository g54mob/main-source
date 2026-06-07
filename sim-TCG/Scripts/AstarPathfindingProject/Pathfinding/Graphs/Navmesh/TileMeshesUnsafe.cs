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
			this.tileMeshes = tileMeshes;
			this.tileRect = tileRect;
			this.tileWorldSize = tileWorldSize;
		}

		public TileMeshes ToManaged()
		{
			TileMesh[] array = new TileMesh[tileMeshes.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = tileMeshes[i].ToManaged();
			}
			return new TileMeshes
			{
				tileMeshes = array,
				tileRect = tileRect,
				tileWorldSize = tileWorldSize
			};
		}

		public void Dispose()
		{
			if (tileMeshes.IsCreated)
			{
				for (int i = 0; i < tileMeshes.Length; i++)
				{
					tileMeshes[i].Dispose();
				}
				tileMeshes.Dispose();
			}
		}
	}
}
