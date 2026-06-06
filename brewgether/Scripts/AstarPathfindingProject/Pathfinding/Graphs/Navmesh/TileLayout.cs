using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileLayout
	{
		public Vector2Int tileCount;

		public GraphTransform transform;

		public Vector2Int tileSizeInVoxels;

		public Vector3 graphSpaceSize;

		public float cellSize;

		public float CellHeight => 0f;

		public Vector2 TileWorldSize => default(Vector2);

		public float TileWorldSizeX => 0f;

		public float TileWorldSizeZ => 0f;

		public Bounds GetTileBoundsInGraphSpace(int x, int z, int width = 1, int depth = 1)
		{
			return default(Bounds);
		}

		public IntRect GetTouchingTiles(Bounds bounds, float margin = 0f)
		{
			return default(IntRect);
		}

		public IntRect GetTouchingTilesInGraphSpace(Rect rect)
		{
			return default(IntRect);
		}

		public TileLayout(RecastGraph graph)
		{
			tileCount = default(Vector2Int);
			transform = null;
			tileSizeInVoxels = default(Vector2Int);
			graphSpaceSize = default(Vector3);
			cellSize = 0f;
		}

		public TileLayout(NavMeshGraph graph)
		{
			tileCount = default(Vector2Int);
			transform = null;
			tileSizeInVoxels = default(Vector2Int);
			graphSpaceSize = default(Vector3);
			cellSize = 0f;
		}

		public TileLayout(Bounds bounds, Quaternion rotation, float cellSize, int tileSizeInVoxels, bool useTiles)
		{
			tileCount = default(Vector2Int);
			transform = null;
			this.tileSizeInVoxels = default(Vector2Int);
			graphSpaceSize = default(Vector3);
			this.cellSize = 0f;
		}
	}
}
