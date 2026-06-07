using System;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding.Voxels
{
	public class Voxelize
	{
		public List<RasterizationMesh> inputMeshes;

		public readonly int voxelWalkableClimb;

		public readonly uint voxelWalkableHeight;

		public readonly float cellSize;

		public readonly float cellHeight;

		public int minRegionSize;

		public int borderSize;

		public float maxEdgeLength;

		public float maxSlope;

		public RecastGraph.RelevantGraphSurfaceMode relevantGraphSurfaceMode;

		public Bounds forcedBounds;

		public VoxelArea voxelArea;

		public VoxelContourSet countourSet;

		private GraphTransform transform;

		public int width;

		public int depth;

		private Vector3 voxelOffset;

		public const uint NotConnected = 63u;

		private const int MaxLayers = 65535;

		private const int MaxRegions = 500;

		private const int UnwalkableArea = 0;

		private const ushort BorderReg = 32768;

		private const int RC_BORDER_VERTEX = 65536;

		private const int RC_AREA_BORDER = 131072;

		private const int VERTEX_BUCKET_COUNT = 4096;

		public const int RC_CONTOUR_TESS_WALL_EDGES = 1;

		public const int RC_CONTOUR_TESS_AREA_EDGES = 2;

		public const int RC_CONTOUR_TESS_TILE_EDGES = 4;

		private const int ContourRegMask = 65535;

		private readonly Vector3 cellScale;

		public GraphTransform transformVoxel2Graph { get; private set; }

		public void BuildContours(float maxError, int maxEdgeLength, VoxelContourSet cset, int buildFlags)
		{
		}

		private void GetClosestIndices(int[] vertsa, int nvertsa, int[] vertsb, int nvertsb, ref int ia, ref int ib)
		{
		}

		private static void ReleaseContours(VoxelContourSet cset)
		{
		}

		public static bool MergeContours(ref VoxelContour ca, ref VoxelContour cb, int ia, int ib)
		{
			return false;
		}

		public void SimplifyContour(List<int> verts, List<int> simplified, float maxError, int maxEdgeLenght, int buildFlags)
		{
		}

		public void WalkContour(int x, int z, int i, ushort[] flags, List<int> verts)
		{
		}

		public int GetCornerHeight(int x, int z, int i, int dir, ref bool isBorderVertex)
		{
			return 0;
		}

		public void RemoveDegenerateSegments(List<int> simplified)
		{
		}

		public int CalcAreaOfPolygon2D(int[] verts, int nverts)
		{
			return 0;
		}

		public static bool Ileft(int a, int b, int c, int[] va, int[] vb, int[] vc)
		{
			return false;
		}

		public static bool Diagonal(int i, int j, int n, int[] verts, int[] indices)
		{
			return false;
		}

		public static bool InCone(int i, int j, int n, int[] verts, int[] indices)
		{
			return false;
		}

		public static bool Left(int a, int b, int c, int[] verts)
		{
			return false;
		}

		public static bool LeftOn(int a, int b, int c, int[] verts)
		{
			return false;
		}

		public static bool Collinear(int a, int b, int c, int[] verts)
		{
			return false;
		}

		public static int Area2(int a, int b, int c, int[] verts)
		{
			return 0;
		}

		private static bool Diagonalie(int i, int j, int n, int[] verts, int[] indices)
		{
			return false;
		}

		public static bool Xorb(bool x, bool y)
		{
			return false;
		}

		public static bool IntersectProp(int a, int b, int c, int d, int[] verts)
		{
			return false;
		}

		private static bool Between(int a, int b, int c, int[] verts)
		{
			return false;
		}

		private static bool Intersect(int a, int b, int c, int d, int[] verts)
		{
			return false;
		}

		private static bool Vequal(int a, int b, int[] verts)
		{
			return false;
		}

		public static int Prev(int i, int n)
		{
			return 0;
		}

		public static int Next(int i, int n)
		{
			return 0;
		}

		public void BuildPolyMesh(VoxelContourSet cset, int nvp, out VoxelMesh mesh)
		{
			mesh = default(VoxelMesh);
		}

		private int Triangulate(int n, int[] verts, ref int[] indices, ref int[] tris)
		{
			return 0;
		}

		public Vector3 CompactSpanToVector(int x, int z, int i)
		{
			return default(Vector3);
		}

		public void VectorToIndex(Vector3 p, out int x, out int z)
		{
			x = default(int);
			z = default(int);
		}

		public Voxelize(float ch, float cs, float walkableClimb, float walkableHeight, float maxSlope, float maxEdgeLength)
		{
		}

		public void Init()
		{
		}

		public void VoxelizeInput(GraphTransform graphTransform, Bounds graphSpaceBounds)
		{
		}

		public void DebugDrawSpans()
		{
		}

		public void BuildCompactField()
		{
		}

		public void BuildVoxelConnections()
		{
		}

		private void DrawLine(int a, int b, int[] indices, int[] verts, Color color)
		{
		}

		public Vector3 VoxelToWorld(int x, int y, int z)
		{
			return default(Vector3);
		}

		public Int3 VoxelToWorldInt3(Int3 voxelPosition)
		{
			return default(Int3);
		}

		private Vector3 ConvertPosWithoutOffset(int x, int y, int z)
		{
			return default(Vector3);
		}

		private Vector3 ConvertPosition(int x, int z, int i)
		{
			return default(Vector3);
		}

		public void ErodeWalkableArea(int radius)
		{
		}

		public void BuildDistanceField()
		{
		}

		[Obsolete("This function is not complete and should not be used")]
		public void ErodeVoxels(int radius)
		{
		}

		public void FilterLowHeightSpans(uint voxelWalkableHeight, float cs, float ch)
		{
		}

		public void FilterLedges(uint voxelWalkableHeight, int voxelWalkableClimb, float cs, float ch)
		{
		}

		public bool FloodRegion(int x, int z, int i, uint level, ushort r, ushort[] srcReg, ushort[] srcDist, Int3[] stack, int[] flags = null, bool[] closed = null)
		{
			return false;
		}

		public void MarkRectWithRegion(int minx, int maxx, int minz, int maxz, ushort region, ushort[] srcReg)
		{
		}

		public ushort CalculateDistanceField(ushort[] src)
		{
			return 0;
		}

		public ushort[] BoxBlur(ushort[] src, ushort[] dst)
		{
			return null;
		}

		public void BuildRegions()
		{
		}

		private static int union_find_find(int[] arr, int x)
		{
			return 0;
		}

		private static void union_find_union(int[] arr, int a, int b)
		{
		}

		public void FilterSmallRegions(ushort[] reg, int minRegionSize, int maxRegions)
		{
		}
	}
}
