using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public struct PathTracer
	{
		public enum PartGraphType : byte
		{
			Navmesh = 0,
			Grid = 1,
			OffMeshLink = 2
		}

		public enum RepairQuality
		{
			Low = 0,
			High = 1
		}

		private struct QueueItem
		{
			public GraphNode node;

			public int parent;

			public float distance;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate bool ContainsAndProject_00000AEB_0024PostfixBurstDelegate(ref Int3 a, ref Int3 b, ref Int3 c, ref Vector3 p, float height, ref NativeMovementPlane movementPlane, out Vector3 projected);

		internal static class ContainsAndProject_00000AEB_0024BurstDirectCall
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

			public static bool Invoke(ref Int3 a, ref Int3 b, ref Int3 c, ref Vector3 p, float height, ref NativeMovementPlane movementPlane, out Vector3 projected)
			{
				projected = default(Vector3);
				return false;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float EstimateRemainingPath_00000AFE_0024PostfixBurstDelegate(ref Funnel.FunnelState funnelState, ref Funnel.PathPart part, int maxCorners, ref NativeMovementPlane movementPlane);

		internal static class EstimateRemainingPath_00000AFE_0024BurstDirectCall
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

			public static float Invoke(ref Funnel.FunnelState funnelState, ref Funnel.PathPart part, int maxCorners, ref NativeMovementPlane movementPlane)
			{
				return 0f;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float RemainingDistanceLowerBound_00000B02_0024PostfixBurstDelegate(in UnsafeSpan<float3> nextCorners, in float3 endOfPart, in NativeMovementPlane movementPlane);

		internal static class RemainingDistanceLowerBound_00000B02_0024BurstDirectCall
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

			public static float Invoke(in UnsafeSpan<float3> nextCorners, in float3 endOfPart, in NativeMovementPlane movementPlane)
			{
				return 0f;
			}
		}

		private Funnel.PathPart[] parts;

		private CircularBuffer<GraphNode> nodes;

		private CircularBuffer<int> nodeHashes;

		private CircularBuffer<byte> portalIsNotInnerCorner;

		private Funnel.FunnelState funnelState;

		private Vector3 unclampedEndPoint;

		private Vector3 unclampedStartPoint;

		private GraphNode startNodeInternal;

		private TraversalConstraint traversalConstraint;

		private TraversalCosts traversalCosts;

		private int firstPartIndex;

		private bool startIsUpToDate;

		private bool endIsUpToDate;

		private bool pathEmptyAndUnrepairableBacking;

		private bool firstPartContainsDestroyedNodes;

		public PartGraphType partGraphType;

		private static readonly ProfilerMarker MarkerContains;

		private static readonly ProfilerMarker MarkerClosest;

		private static readonly ProfilerMarker MarkerGetNearest;

		private static readonly ProfilerMarker MarkerSetFunnelState;

		private static readonly ProfilerMarker MarkerCalculatePortals;

		private const int NODES_TO_CHECK_FOR_DESTRUCTION = 5;

		private static readonly QueueItem[][] TempQueues;

		private static readonly List<GraphNode>[] TempConnectionLists;

		[ThreadStatic]
		private static List<float3> tmpLeftPortals;

		[ThreadStatic]
		private static List<float3> tmpRightPortals;

		[ThreadStatic]
		private static List<GraphNode> scratchList;

		private static int[] SplittingCoefficients;

		private static readonly ProfilerMarker MarkerSimplify;

		private bool pathEmptyAndUnrepairable
		{
			readonly get
			{
				return false;
			}
			set
			{
			}
		}

		public ushort version
		{
			[IgnoredByDeepProfiler]
			get;
			[IgnoredByDeepProfiler]
			private set;
		}

		public readonly bool isCreated => false;

		public GraphNode startNode
		{
			[IgnoredByDeepProfiler]
			readonly get
			{
				return null;
			}
			[IgnoredByDeepProfiler]
			private set
			{
			}
		}

		public readonly bool isStale
		{
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
		}

		public readonly int partCount => 0;

		public readonly bool hasPath => false;

		public readonly bool hasValidEndPoint => false;

		public readonly Vector3 startPoint => default(Vector3);

		public readonly Vector3 endPoint => default(Vector3);

		public readonly Vector3 endPointOfFirstPart => default(Vector3);

		public int desiredCornersForGoodSimplification => 0;

		public readonly bool isNextPartValidLink => false;

		public PathTracer(Allocator allocator)
		{
			parts = null;
			nodes = default(CircularBuffer<GraphNode>);
			nodeHashes = default(CircularBuffer<int>);
			portalIsNotInnerCorner = default(CircularBuffer<byte>);
			funnelState = default(Funnel.FunnelState);
			unclampedEndPoint = default(Vector3);
			unclampedStartPoint = default(Vector3);
			startNodeInternal = null;
			traversalConstraint = default(TraversalConstraint);
			traversalCosts = default(TraversalCosts);
			firstPartIndex = 0;
			startIsUpToDate = false;
			endIsUpToDate = false;
			pathEmptyAndUnrepairableBacking = false;
			firstPartContainsDestroyedNodes = false;
			partGraphType = default(PartGraphType);
			version = 0;
		}

		public void Dispose()
		{
		}

		public void SetEmptyAndUnrepairable()
		{
		}

		public Vector3 UpdateStart(Vector3 position, RepairQuality quality, NativeMovementPlane movementPlane)
		{
			return default(Vector3);
		}

		public Vector3 UpdateEnd(Vector3 position, RepairQuality quality, NativeMovementPlane movementPlane)
		{
			return default(Vector3);
		}

		private void AppendNode(bool toStart, GraphNode node)
		{
		}

		private void AppendPath(bool toStart, CircularBuffer<GraphNode> path)
		{
		}

		[Conditional("UNITY_EDITOR")]
		private void CheckInvariants()
		{
		}

		private bool SplicePath(int startIndex, int toRemove, List<GraphNode> toInsert)
		{
			return false;
		}

		private static bool ContainsPoint(GraphNode node, Vector3 point, NativeMovementPlane plane)
		{
			return false;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(ContainsAndProject_00000AEB_0024PostfixBurstDelegate))]
		private static bool ContainsAndProject(ref Int3 a, ref Int3 b, ref Int3 c, ref Vector3 p, float height, ref NativeMovementPlane movementPlane, out Vector3 projected)
		{
			projected = default(Vector3);
			return false;
		}

		private static float3 ProjectOnSurface(float3 a, float3 b, float3 c, float3 p, float3 up)
		{
			return default(float3);
		}

		private void Repair(Vector3 point, bool isStart, RepairQuality quality, NativeMovementPlane movementPlane, bool allowCache = true)
		{
		}

		private void HeuristicallyPopPortals(bool isStartOfPart, Vector3 point)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		private void AssertValidInPath(int absoluteNodeIndex)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		private readonly bool ValidInPath(int absoluteNodeIndex)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		private static bool Valid(GraphNode node)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		private static int HashNode(GraphNode node)
		{
			return 0;
		}

		private void RepairFull(Vector3 point, bool isStart, RepairQuality quality, NativeMovementPlane movementPlane)
		{
		}

		private static float SquaredDistanceToNode(GraphNode node, Vector3 point, ref BBTree.ProjectionParams projectionParams)
		{
			return 0f;
		}

		private static bool QueueHasNode(QueueItem[] queue, int count, GraphNode node)
		{
			return false;
		}

		private void GetTempQueue(out QueueItem[] queue, out List<GraphNode> connections)
		{
			queue = null;
			connections = null;
		}

		private CircularBuffer<GraphNode> LocalSearch(GraphNode currentNode, Vector3 point, int maxNodesToSearch, NativeMovementPlane movementPlane, bool reverse)
		{
			return default(CircularBuffer<GraphNode>);
		}

		public void DrawFunnel(CommandBuilder draw, NativeMovementPlane movementPlane)
		{
		}

		private static Int3 MaybeSetYZero(Int3 p, bool setYToZero)
		{
			return default(Int3);
		}

		private static bool IsInnerVertex(CircularBuffer<GraphNode> nodes, Funnel.PathPart part, int portalIndex, bool rightSide, List<GraphNode> alternativeNodes, ref TraversalConstraint traversalConstraint, ref TraversalCosts traversalCosts, out int startIndex, out int endIndex)
		{
			startIndex = default(int);
			endIndex = default(int);
			return false;
		}

		private static bool IsInnerVertexTriangleMesh(CircularBuffer<GraphNode> nodes, Funnel.PathPart part, int portalIndex, bool rightSide, List<GraphNode> alternativeNodes, ref TraversalConstraint traversalConstraint, ref TraversalCosts traversalCosts, out int startIndex, out int endIndex)
		{
			startIndex = default(int);
			endIndex = default(int);
			return false;
		}

		private bool FirstInnerVertex(NativeArray<int> indices, int numCorners, List<GraphNode> alternativePath, out int alternativeStartIndex, out int alternativeEndIndex)
		{
			alternativeStartIndex = default(int);
			alternativeEndIndex = default(int);
			return false;
		}

		public float EstimateRemainingPath(int maxCorners, ref NativeMovementPlane movementPlane)
		{
			return 0f;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(EstimateRemainingPath_00000AFE_0024PostfixBurstDelegate))]
		private static float EstimateRemainingPath(ref Funnel.FunnelState funnelState, ref Funnel.PathPart part, int maxCorners, ref NativeMovementPlane movementPlane)
		{
			return 0f;
		}

		public void GetNextCorners(NativeList<float3> buffer, int maxCorners, ref NativeArray<int> scratchArray, Allocator allocator, bool allowSimplify = true)
		{
		}

		public int GetNextCornerIndices(ref NativeArray<int> buffer, int maxCorners, Allocator allocator, bool allowSimplify, out bool lastCorner)
		{
			lastCorner = default(bool);
			return 0;
		}

		public void ConvertCornerIndicesToPathProjected(NativeArray<int> cornerIndices, int numCorners, bool lastCorner, NativeList<float3> buffer, float3 up)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RemainingDistanceLowerBound_00000B02_0024PostfixBurstDelegate))]
		public static float RemainingDistanceLowerBound(in UnsafeSpan<float3> nextCorners, in float3 endOfPart, in NativeMovementPlane movementPlane)
		{
			return 0f;
		}

		public void PopParts(int count)
		{
		}

		public void RemoveAllButFirstNode()
		{
		}

		private void RemoveAllPartsExceptFirst()
		{
		}

		public readonly Funnel.PartType GetPartType(int partIndex = 0)
		{
			return default(Funnel.PartType);
		}

		public readonly bool PartContainsDestroyedNodes(int partIndex = 0)
		{
			return false;
		}

		public OffMeshLinks.OffMeshLinkTracer GetLinkInfo(int partIndex = 0)
		{
			return default(OffMeshLinks.OffMeshLinkTracer);
		}

		private static void GetTemporaryPortalLists(out List<float3> left, out List<float3> right)
		{
			left = null;
			right = null;
		}

		private void SetFunnelState(Funnel.PathPart part)
		{
		}

		private void CalculateFunnelPortals(int startNodeIndex, int endNodeIndex, List<float3> outLeftPortals, List<float3> outRightPortals)
		{
		}

		public void SetFromSingleNode(GraphNode node, Vector3 position, NativeMovementPlane movementPlane, TraversalConstraint traversalConstraint, TraversalCosts traversalCosts)
		{
		}

		public void Clear()
		{
		}

		private static int2 ResolveNormalizedGridPoint(GridGraph grid, ref CircularBuffer<GraphNode> nodes, UnsafeSpan<int> cornerIndices, Funnel.PathPart part, int index, out int nodeIndex)
		{
			nodeIndex = default(int);
			return default(int2);
		}

		private static bool SimplifyGridInnerVertex(ref CircularBuffer<GraphNode> nodes, UnsafeSpan<int> cornerIndices, Funnel.PathPart part, ref CircularBuffer<byte> portalIsNotInnerCorner, List<GraphNode> alternativePath, out int alternativeStartIndex, out int alternativeEndIndex, ref TraversalConstraint traversalConstraint, ref TraversalCosts traversalCosts, bool lastCorner)
		{
			alternativeStartIndex = default(int);
			alternativeEndIndex = default(int);
			return false;
		}

		private static void RemoveGridPathDiagonals(Funnel.PathPart[] parts, int partIndex, ref CircularBuffer<GraphNode> path, ref CircularBuffer<int> pathNodeHashes, ref TraversalConstraint traversalConstraint)
		{
		}

		private static PartGraphType PartGraphTypeFromNode(GraphNode node)
		{
			return default(PartGraphType);
		}

		public void SetPath(ABPath path, NativeMovementPlane movementPlane)
		{
		}

		public void SetPath(List<Funnel.PathPart> parts, List<GraphNode> nodes, Vector3 unclampedStartPoint, Vector3 unclampedEndPoint, NativeMovementPlane movementPlane, TraversalConstraint traversalConstraint, TraversalCosts traversalCosts)
		{
		}

		public PathTracer Clone()
		{
			return default(PathTracer);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool ContainsAndProject_0024BurstManaged(ref Int3 a, ref Int3 b, ref Int3 c, ref Vector3 p, float height, ref NativeMovementPlane movementPlane, out Vector3 projected)
		{
			projected = default(Vector3);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static float EstimateRemainingPath_0024BurstManaged(ref Funnel.FunnelState funnelState, ref Funnel.PathPart part, int maxCorners, ref NativeMovementPlane movementPlane)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static float RemainingDistanceLowerBound_0024BurstManaged(in UnsafeSpan<float3> nextCorners, in float3 endOfPart, in NativeMovementPlane movementPlane)
		{
			return 0f;
		}
	}
}
