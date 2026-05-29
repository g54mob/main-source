using System;
using System.Collections.Generic;
using Pathfinding.ClipperLib;
using Pathfinding.Poly2Tri;
using Pathfinding.Voxels;
using UnityEngine;

namespace Pathfinding.Util
{
	public class TileHandler
	{
		public class TileType
		{
			private Int3[] verts;

			private int[] tris;

			private Int3 offset;

			private int lastYOffset;

			private int lastRotation;

			private int width;

			private int depth;

			private static readonly int[] Rotations;

			public int Width => 0;

			public int Depth => 0;

			public TileType(Int3[] sourceVerts, int[] sourceTris, Int3 tileSize, Int3 centerOffset, int width = 1, int depth = 1)
			{
			}

			public TileType(Mesh source, Int3 tileSize, Int3 centerOffset, int width = 1, int depth = 1)
			{
			}

			public void Load(out Int3[] verts, out int[] tris, int rotation, int yoffset)
			{
				verts = null;
				tris = null;
			}
		}

		[Flags]
		public enum CutMode
		{
			CutAll = 1,
			CutDual = 2,
			CutExtra = 4
		}

		private class Cut
		{
			public IntRect bounds;

			public Int2 boundsY;

			public bool isDual;

			public bool cutsAddedGeom;

			public List<IntPoint> contour;
		}

		private struct CuttingResult
		{
			public Int3[] verts;

			public int[] tris;
		}

		public readonly NavmeshBase graph;

		private readonly int tileXCount;

		private readonly int tileZCount;

		private readonly Clipper clipper;

		private readonly Dictionary<Int2, int> cached_Int2_int_dict;

		private readonly TileType[] activeTileTypes;

		private readonly int[] activeTileRotations;

		private readonly int[] activeTileOffsets;

		private readonly bool[] reloadedInBatch;

		public readonly GridLookup<NavmeshClipper> cuts;

		private int batchDepth;

		private readonly Int3PolygonClipper simpleClipper;

		private bool isBatching => false;

		public bool isValid => false;

		public TileHandler(NavmeshBase graph)
		{
		}

		public void OnRecalculatedTiles(NavmeshTile[] recalculatedTiles)
		{
		}

		public int GetActiveRotation(Int2 p)
		{
			return 0;
		}

		public TileType RegisterTileType(Mesh source, Int3 centerOffset, int width = 1, int depth = 1)
		{
			return null;
		}

		public void CreateTileTypesFromGraph()
		{
		}

		private void UpdateTileType(NavmeshTile tile)
		{
		}

		public void StartBatchLoad()
		{
		}

		public void EndBatchLoad()
		{
		}

		private CuttingResult CutPoly(Int3[] verts, int[] tris, Int3[] extraShape, GraphTransform graphTransform, IntRect tiles, CutMode mode = CutMode.CutAll | CutMode.CutDual, int perturbate = -1)
		{
			return default(CuttingResult);
		}

		private static List<Cut> PrepareNavmeshCutsForCutting(List<NavmeshCut> navmeshCuts, GraphTransform transform, IntRect cutSpaceBounds, int perturbate, bool anyNavmeshAdds)
		{
			return null;
		}

		private static void PoolPolygon(Pathfinding.Poly2Tri.Polygon polygon, Stack<Pathfinding.Poly2Tri.Polygon> pool)
		{
		}

		private void CutAll(List<IntPoint> poly, List<int> intersectingCutIndices, List<Cut> cuts, PolyTree result)
		{
		}

		private void CutDual(List<IntPoint> poly, List<int> tmpIntersectingCuts, List<Cut> cuts, bool hasDual, List<List<IntPoint>> intermediateResult, PolyTree result)
		{
		}

		private void CutExtra(List<IntPoint> poly, List<IntPoint> extraClipShape, PolyTree result)
		{
		}

		private int ClipAgainstRectangle(Int3[] clipIn, Int3[] clipOut, Int2 size)
		{
			return 0;
		}

		private static void CopyMesh(Int3[] vertices, int[] triangles, List<Int3> outVertices, List<int> outTriangles)
		{
		}

		private void DelaunayRefinement(Int3[] verts, int[] tris, ref int tCount, bool delaunay, bool colinear)
		{
		}

		public void ClearTile(int x, int z)
		{
		}

		public void ReloadInBounds(Bounds bounds)
		{
		}

		public void ReloadInBounds(IntRect tiles)
		{
		}

		public void ReloadTile(int x, int z)
		{
		}

		public void LoadTile(TileType tile, int x, int z, int rotation, int yoffset)
		{
		}
	}
}
