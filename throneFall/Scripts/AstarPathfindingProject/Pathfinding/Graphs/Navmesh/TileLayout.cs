using System;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileLayout
	{
		public Int2 tileCount;

		public GraphTransform transform;

		public Int2 tileSizeInVoxels;

		public Vector3 graphSpaceSize;

		public float cellSize;

		public float CellHeight => Mathf.Max(graphSpaceSize.y / 64000f, 0.001f);

		public float TileWorldSizeX => (float)tileSizeInVoxels.x * cellSize;

		public float TileWorldSizeZ => (float)tileSizeInVoxels.y * cellSize;

		public Bounds GetTileBoundsInGraphSpace(int x, int z, int width = 1, int depth = 1)
		{
			Bounds result = default(Bounds);
			result.SetMinMax(new Vector3((float)x * TileWorldSizeX, 0f, (float)z * TileWorldSizeZ), new Vector3((float)(x + width) * TileWorldSizeX, graphSpaceSize.y, (float)(z + depth) * TileWorldSizeZ));
			return result;
		}

		public IntRect GetTouchingTiles(Bounds bounds, float margin = 0f)
		{
			bounds = transform.InverseTransform(bounds);
			return new IntRect(Mathf.FloorToInt((bounds.min.x - margin) / TileWorldSizeX), Mathf.FloorToInt((bounds.min.z - margin) / TileWorldSizeZ), Mathf.FloorToInt((bounds.max.x + margin) / TileWorldSizeX), Mathf.FloorToInt((bounds.max.z + margin) / TileWorldSizeZ));
		}

		public TileLayout(RecastGraph graph)
			: this(new Bounds(graph.forcedBoundsCenter, graph.forcedBoundsSize), Quaternion.Euler(graph.rotation), graph.cellSize, graph.editorTileSize, graph.useTiles)
		{
		}

		public TileLayout(Bounds bounds, Quaternion rotation, float cellSize, int tileSizeInVoxels, bool useTiles)
		{
			transform = RecastGraph.CalculateTransform(bounds, rotation);
			this.cellSize = cellSize;
			Vector3 vector = (graphSpaceSize = bounds.size);
			int num = (int)(vector.x / cellSize + 0.5f);
			int num2 = (int)(vector.z / cellSize + 0.5f);
			if (!useTiles)
			{
				this.tileSizeInVoxels = new Int2(num, num2);
			}
			else
			{
				this.tileSizeInVoxels = new Int2(tileSizeInVoxels, tileSizeInVoxels);
			}
			tileCount = new Int2(Mathf.Max(0, (num + this.tileSizeInVoxels.x - 1) / this.tileSizeInVoxels.x), Mathf.Max(0, (num2 + this.tileSizeInVoxels.y - 1) / this.tileSizeInVoxels.y));
			if (tileCount.x * tileCount.y > 2048)
			{
				throw new Exception("Too many tiles (" + tileCount.x * tileCount.y + ") maximum is " + 2048 + "\nTry disabling ASTAR_RECAST_LARGER_TILES under the 'Optimizations' tab in the A* inspector.");
			}
		}
	}
}
