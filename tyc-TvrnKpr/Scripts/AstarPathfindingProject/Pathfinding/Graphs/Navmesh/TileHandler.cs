using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Clipper2Lib;
using Pathfinding.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using andywiecko.BurstTriangulator.LowLevel.Unsafe;

namespace Pathfinding.Graphs.Navmesh
{
	[BurstCompile]
	public static class TileHandler
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate bool CutFunction(ref UnsafeSpan<Point64Wrapper> subject, ref UnsafeSpan<UnsafeSpan<Point64Wrapper>> contours, ref UnsafeSpan<UnsafeSpan<Point64Wrapper>> contoursDual, ref UnsafeList<Vector2Int> outputVertices, ref UnsafeList<int> outputVertexCountPerPolygon, int dual);

		[StructLayout((LayoutKind)0, Size = 1)]
		private struct CutFunctionKey
		{
		}

		internal struct TileCuts
		{
			public int contourStartIndex;

			public int contourEndIndex;
		}

		internal struct ContourMeta
		{
			public bool isDual;

			public bool cutsAddedGeom;
		}

		internal struct CutCollection : IDisposable
		{
			public UnsafeList<Point64Wrapper> contourVertices;

			public UnsafeList<NavmeshCut.ContourBurst> contours;

			public UnsafeList<ContourMeta> contoursExtra;

			public UnsafeList<TileCuts> tileCuts;

			public bool cuttingRequired;

			public void Dispose()
			{
			}
		}

		public struct Point64Wrapper
		{
			public long x;

			public long y;

			public Point64Wrapper(long x, long y)
			{
				this.x = 0L;
				this.y = 0L;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ConvertVerticesAndSnapToTileBoundaries_00000C36_0024PostfixBurstDelegate(ref UnsafeSpan<float2> contourVertices, out UnsafeList<Point64Wrapper> outputVertices, ref Vector2 tileSize);

		internal static class ConvertVerticesAndSnapToTileBoundaries_00000C36_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(ref UnsafeSpan<float2> contourVertices, out UnsafeList<Point64Wrapper> outputVertices, ref Vector2 tileSize)
			{
				outputVertices = default(UnsafeList<Point64Wrapper>);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void CutTiles_00000C37_0024PostfixBurstDelegate(ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, ref Vector2Int tileSize, ref CutCollection cutCollection, ref UnsafeSpan<TileMesh.TileMeshUnsafe> output, Allocator allocator);

		internal static class CutTiles_00000C37_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, ref Vector2Int tileSize, ref CutCollection cutCollection, ref UnsafeSpan<TileMesh.TileMeshUnsafe> output, Allocator allocator)
			{
			}
		}

		private static readonly ProfilerMarker MarkerTriangulate;

		private static readonly ProfilerMarker MarkerClipping;

		private static readonly ProfilerMarker MarkerPrepare;

		private static readonly ProfilerMarker MarkerAllocate;

		private static readonly ProfilerMarker MarkerCore;

		private static readonly ProfilerMarker MarkerCompress;

		private static readonly ProfilerMarker MarkerRemoveDegenerateTriangles;

		private static readonly ProfilerMarker MarkerRefine;

		private static readonly ProfilerMarker MarkerEdgeSnapping;

		private static readonly ProfilerMarker MarkerRemoveDegenerateLines;

		private static readonly ProfilerMarker MarkerClipHorizontal;

		private static readonly ProfilerMarker MarkerCopyClippingResult;

		private static readonly ProfilerMarker CopyTriangulationToOutputMarker;

		private static readonly SharedStatic<IntPtr> CutFunctionPtr;

		private static CutFunction DelegateGCRoot;

		private const int EdgeSnappingMaxDistance = 1;

		private const int Scale = 16;

		public const int TileSnappingMaxDistance = 20;

		internal static CutCollection CollectCuts(GridLookup<NavmeshClipper> cuts, List<Vector2Int> tileCoordinates, float characterRadius, TileLayout tileLayout, ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags)
		{
			return default(CutCollection);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(ConvertVerticesAndSnapToTileBoundaries_00000C36_0024PostfixBurstDelegate))]
		private static void ConvertVerticesAndSnapToTileBoundaries(ref UnsafeSpan<float2> contourVertices, out UnsafeList<Point64Wrapper> outputVertices, ref Vector2 tileSize)
		{
			outputVertices = default(UnsafeList<Point64Wrapper>);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(CutTiles_00000C37_0024PostfixBurstDelegate))]
		internal static void CutTiles(ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, ref Vector2Int tileSize, ref CutCollection cutCollection, ref UnsafeSpan<TileMesh.TileMeshUnsafe> output, Allocator allocator)
		{
		}

		private static void ScaleUpCoordinates(UnsafeSpan<long> coords)
		{
		}

		private static void ScaleDownCoordinates(UnsafeSpan<int> coords)
		{
		}

		private static void RemoveDegenerateSegments(ref UnsafeSpan<int2> polygon)
		{
		}

		private static void CollectCutsTouchingBounds(UnsafeSpan<IntBounds> cutBounds, NativeList<int> outputCutIndices, IntBounds bounds)
		{
		}

		private static IntBounds TriangleBounds(Int3 a, Int3 b, Int3 c)
		{
			return default(IntBounds);
		}

		private static TileMesh.TileMeshUnsafe CompressAndRefineTile(NativeList<Int3> tileOutputVertices, NativeList<int> tileOutputTriangles, NativeList<int> tileOutputTags, Allocator allocator)
		{
			return default(TileMesh.TileMeshUnsafe);
		}

		private static void CopyTriangulationToOutput(ref OutputData<int2> triangulatorOutput, NativeList<Int3> tileOutputVertices, NativeList<int> tileOutputTriangles, NativeList<int> tileOutputTags, int tag, Int3 a, Int3 b, Int3 c)
		{
		}

		private static void SnapEdges(ref NativeArray<Point64Wrapper> triBuffer, ref int vertexCount, UnsafeSpan<UnsafeSpan<Point64Wrapper>> contours, Vector2Int tileSize)
		{
		}

		private static NativeArray<IntBounds> CalculateCutBounds(ref CutCollection cutCollection, ref UnsafeList<Point64Wrapper> contourVerticesP64)
		{
			return default(NativeArray<IntBounds>);
		}

		private static void AddContours(Clipper64 clipper, ref UnsafeSpan<UnsafeSpan<Point64Wrapper>> contours)
		{
		}

		private static void CopyClipperOutput(List<List<Point64>> closedSolutions, ref UnsafeList<Vector2Int> outputVertices, ref UnsafeList<int> outputVertexCountPerPolygon)
		{
		}

		[MonoPInvokeCallback(typeof(CutFunction))]
		private static bool CutPolygon(ref UnsafeSpan<Point64Wrapper> subject, ref UnsafeSpan<UnsafeSpan<Point64Wrapper>> contours, ref UnsafeSpan<UnsafeSpan<Point64Wrapper>> contoursDual, ref UnsafeList<Vector2Int> outputVertices, ref UnsafeList<int> outputVertexCountPerPolygon, int mode)
		{
			return false;
		}

		internal static void InitDelegates()
		{
		}

		private static int ClipAgainstRectangle(UnsafeSpan<Int3> clipIn, UnsafeSpan<Int3> clipTmp, Vector2Int size)
		{
			return 0;
		}

		private static bool ClipAgainstHalfPlane(UnsafeSpan<Point64Wrapper> clipIn, NativeList<Point64Wrapper> clipOut, Point64Wrapper a, Point64Wrapper b)
		{
			return false;
		}

		private static void ClipAgainstHorizontalHalfPlane(ref UnsafeSpan<Point64Wrapper> contourVertices, NativeList<Point64Wrapper> scratchVertices, int h, Int3 a, Int3 b, Int3 c, bool preserveBelow)
		{
		}

		private static int DelaunayRefinement(UnsafeSpan<Int3> verts, UnsafeSpan<int> tris, UnsafeSpan<int> tags, bool delaunay, bool colinear)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void ConvertVerticesAndSnapToTileBoundaries_0024BurstManaged(ref UnsafeSpan<float2> contourVertices, out UnsafeList<Point64Wrapper> outputVertices, ref Vector2 tileSize)
		{
			outputVertices = default(UnsafeList<Point64Wrapper>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void CutTiles_0024BurstManaged(ref UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, ref UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, ref Vector2Int tileSize, ref CutCollection cutCollection, ref UnsafeSpan<TileMesh.TileMeshUnsafe> output, Allocator allocator)
		{
		}
	}
}
