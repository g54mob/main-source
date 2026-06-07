using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
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

		public delegate bool ContainsAndProject_0000095F_0024PostfixBurstDelegate(ref Int3 a, ref Int3 b, ref Int3 c, ref Vector3 p, float height, ref NativeMovementPlane movementPlane, out Vector3 projected);

		internal static class ContainsAndProject_0000095F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(ContainsAndProject_0000095F_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static ContainsAndProject_0000095F_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static bool Invoke(ref Int3 a, ref Int3 b, ref Int3 c, ref Vector3 p, float height, ref NativeMovementPlane movementPlane, out Vector3 projected)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref Int3, ref Int3, ref Int3, ref Vector3, float, ref NativeMovementPlane, ref Vector3, bool>)functionPointer)(ref a, ref b, ref c, ref p, height, ref movementPlane, ref projected);
					}
				}
				return ContainsAndProject_0024BurstManaged(ref a, ref b, ref c, ref p, height, ref movementPlane, out projected);
			}
		}

		public delegate float EstimateRemainingPath_00000973_0024PostfixBurstDelegate(ref Funnel.FunnelState funnelState, ref Funnel.PathPart part, int maxCorners, ref NativeMovementPlane movementPlane);

		internal static class EstimateRemainingPath_00000973_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(EstimateRemainingPath_00000973_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static EstimateRemainingPath_00000973_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static float Invoke(ref Funnel.FunnelState funnelState, ref Funnel.PathPart part, int maxCorners, ref NativeMovementPlane movementPlane)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref Funnel.FunnelState, ref Funnel.PathPart, int, ref NativeMovementPlane, float>)functionPointer)(ref funnelState, ref part, maxCorners, ref movementPlane);
					}
				}
				return EstimateRemainingPath_0024BurstManaged(ref funnelState, ref part, maxCorners, ref movementPlane);
			}
		}

		public delegate float RemainingDistanceLowerBound_00000977_0024PostfixBurstDelegate(in UnsafeSpan<float3> nextCorners, in float3 endOfPart, in NativeMovementPlane movementPlane);

		internal static class RemainingDistanceLowerBound_00000977_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RemainingDistanceLowerBound_00000977_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static RemainingDistanceLowerBound_00000977_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static float Invoke(in UnsafeSpan<float3> nextCorners, in float3 endOfPart, in NativeMovementPlane movementPlane)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref UnsafeSpan<float3>, ref float3, ref NativeMovementPlane, float>)functionPointer)(ref nextCorners, ref endOfPart, ref movementPlane);
					}
				}
				return RemainingDistanceLowerBound_0024BurstManaged(in nextCorners, in endOfPart, in movementPlane);
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

		private NNConstraint nnConstraint;

		private int firstPartIndex;

		private bool startIsUpToDate;

		private bool endIsUpToDate;

		private bool firstPartContainsDestroyedNodes;

		public PartGraphType partGraphType;

		private static readonly ProfilerMarker MarkerContains = new ProfilerMarker("ContainsNode");

		private static readonly ProfilerMarker MarkerClosest = new ProfilerMarker("ClosestPointOnNode");

		private static readonly ProfilerMarker MarkerGetNearest = new ProfilerMarker("GetNearest");

		private const int NODES_TO_CHECK_FOR_DESTRUCTION = 5;

		[ThreadStatic]
		private static List<GraphNode> scratchList;

		private static int[] SplittingCoefficients = new int[16]
		{
			0, 1, 1, 2, 1, 4, 3, 4, 1, 8,
			3, 8, 5, 8, 7, 8
		};

		private static readonly ProfilerMarker MarkerSimplify = new ProfilerMarker("Simplify");

		public ushort version { get; private set; }

		public readonly bool isCreated => funnelState.unwrappedPortals.IsCreated;

		public GraphNode startNode
		{
			readonly get
			{
				if (startNodeInternal == null || startNodeInternal.Destroyed)
				{
					return null;
				}
				return startNodeInternal;
			}
			private set
			{
				startNodeInternal = value;
			}
		}

		public readonly bool isStale
		{
			get
			{
				if (endIsUpToDate && startIsUpToDate)
				{
					return firstPartContainsDestroyedNodes;
				}
				return true;
			}
		}

		public readonly int partCount
		{
			get
			{
				if (parts == null)
				{
					return 0;
				}
				return parts.Length - firstPartIndex;
			}
		}

		public readonly bool hasPath => partCount > 0;

		public readonly Vector3 startPoint => parts[firstPartIndex].startPoint;

		public readonly Vector3 endPoint => parts[parts.Length - 1].endPoint;

		public readonly Vector3 endPointOfFirstPart => parts[firstPartIndex].endPoint;

		public int desiredCornersForGoodSimplification
		{
			get
			{
				if (partGraphType != PartGraphType.Grid)
				{
					return 2;
				}
				return 3;
			}
		}

		public readonly bool isNextPartValidLink
		{
			get
			{
				if (partCount > 1 && GetPartType(1) == Funnel.PartType.OffMeshLink)
				{
					return !PartContainsDestroyedNodes(1);
				}
				return false;
			}
		}

		public PathTracer(Allocator allocator)
		{
			funnelState = new Funnel.FunnelState(16, allocator);
			parts = null;
			nodes = new CircularBuffer<GraphNode>(16);
			portalIsNotInnerCorner = new CircularBuffer<byte>(16);
			nodeHashes = new CircularBuffer<int>(16);
			unclampedEndPoint = (unclampedStartPoint = Vector3.zero);
			firstPartIndex = 0;
			startIsUpToDate = false;
			endIsUpToDate = false;
			firstPartContainsDestroyedNodes = false;
			startNodeInternal = null;
			version = 1;
			nnConstraint = NNConstraint.Walkable;
			partGraphType = PartGraphType.Navmesh;
			Clear();
		}

		public void Dispose()
		{
			Clear();
			funnelState.Dispose();
		}

		public Vector3 UpdateStart(Vector3 position, RepairQuality quality, NativeMovementPlane movementPlane, ITraversalProvider traversalProvider, Path path)
		{
			Repair(position, isStart: true, quality, movementPlane, traversalProvider, path);
			return parts[firstPartIndex].startPoint;
		}

		public Vector3 UpdateEnd(Vector3 position, RepairQuality quality, NativeMovementPlane movementPlane, ITraversalProvider traversalProvider, Path path)
		{
			Repair(position, isStart: false, quality, movementPlane, traversalProvider, path);
			return parts[parts.Length - 1].endPoint;
		}

		private void AppendNode(bool toStart, GraphNode node)
		{
			int num = (toStart ? firstPartIndex : (parts.Length - 1));
			ref Funnel.PathPart reference = ref parts[num];
			GraphNode graphNode = ((reference.endIndex >= reference.startIndex) ? nodes.GetBoundaryValue(toStart) : null);
			if (node == graphNode)
			{
				return;
			}
			if (node == null)
			{
				throw new ArgumentNullException();
			}
			if (reference.endIndex >= reference.startIndex + 1 && nodes.GetAbsolute(toStart ? (reference.startIndex + 1) : (reference.endIndex - 1)) == node)
			{
				if (toStart)
				{
					reference.startIndex++;
				}
				else
				{
					reference.endIndex--;
				}
				nodes.Pop(toStart);
				nodeHashes.Pop(toStart);
				if (num == firstPartIndex && funnelState.leftFunnel.Length > 0)
				{
					funnelState.Pop(toStart);
					portalIsNotInnerCorner.Pop(toStart);
				}
				return;
			}
			if (num == firstPartIndex && graphNode != null)
			{
				Vector3 left;
				Vector3 right;
				if (toStart)
				{
					if (!node.GetPortal(graphNode, out left, out right))
					{
						throw new NotImplementedException();
					}
				}
				else if (!graphNode.GetPortal(node, out left, out right))
				{
					throw new NotImplementedException();
				}
				funnelState.Push(toStart, left, right);
				portalIsNotInnerCorner.Push(toStart, 0);
			}
			nodes.Push(toStart, node);
			nodeHashes.Push(toStart, HashNode(node));
			if (toStart)
			{
				reference.startIndex--;
			}
			else
			{
				reference.endIndex++;
			}
		}

		private void AppendPath(bool toStart, CircularBuffer<GraphNode> path)
		{
			if (path.Length == 0)
			{
				return;
			}
			while (path.Length > 0)
			{
				AppendNode(toStart, path.PopStart());
			}
			if (toStart)
			{
				startNode = nodes.First;
				int num = Mathf.Min(parts[firstPartIndex].startIndex + 5, parts[firstPartIndex].endIndex);
				bool flag = false;
				for (int i = parts[firstPartIndex].startIndex; i <= num; i++)
				{
					flag |= !ValidInPath(i);
				}
				firstPartContainsDestroyedNodes = flag;
			}
		}

		[Conditional("UNITY_EDITOR")]
		private void CheckInvariants()
		{
		}

		private bool SplicePath(int startIndex, int toRemove, List<GraphNode> toInsert)
		{
			ref Funnel.PathPart reference = ref parts[firstPartIndex];
			if (startIndex < reference.startIndex || startIndex + toRemove - 1 > reference.endIndex)
			{
				throw new ArgumentException("This method can only handle splicing the first part of the path");
			}
			if (toInsert != null)
			{
				int i = 0;
				int j = 0;
				for (; i < toInsert.Count && i < toRemove && toInsert[i] == nodes.GetAbsolute(startIndex + i); i++)
				{
				}
				if (i == toInsert.Count && i == toRemove)
				{
					return true;
				}
				for (; j < toInsert.Count - i && j < toRemove - i && toInsert[toInsert.Count - j - 1] == nodes.GetAbsolute(startIndex + toRemove - j - 1); j++)
				{
				}
				toInsert.RemoveRange(toInsert.Count - j, j);
				toInsert.RemoveRange(0, i);
				startIndex += i;
				toRemove -= i + j;
			}
			int num = toInsert?.Count ?? 0;
			if (startIndex - 1 >= reference.startIndex && !ValidInPath(startIndex - 1))
			{
				return false;
			}
			if (startIndex + toRemove <= reference.endIndex && !ValidInPath(startIndex + toRemove))
			{
				return false;
			}
			nodes.SpliceAbsolute(startIndex, toRemove, toInsert);
			nodeHashes.SpliceUninitializedAbsolute(startIndex, toRemove, num);
			if (toInsert != null)
			{
				for (int k = 0; k < toInsert.Count; k++)
				{
					nodeHashes.SetAbsolute(startIndex + k, HashNode(toInsert[k]));
				}
			}
			int num2 = num - toRemove;
			int num3 = math.max(startIndex - 1, reference.startIndex);
			int toRemove2 = math.min(startIndex + toRemove, reference.endIndex) - num3;
			reference.endIndex += num2;
			for (int l = firstPartIndex + 1; l < parts.Length; l++)
			{
				parts[l].startIndex += num2;
				parts[l].endIndex += num2;
			}
			List<float3> list = ListPool<float3>.Claim();
			List<float3> list2 = ListPool<float3>.Claim();
			int num4 = startIndex + num - 1;
			int num5 = math.max(startIndex - 1, reference.startIndex);
			int endNodeIndex = math.min(num4 + 1, reference.endIndex);
			CalculateFunnelPortals(num5, endNodeIndex, list, list2);
			funnelState.Splice(num5 - reference.startIndex, toRemove2, list, list2);
			portalIsNotInnerCorner.SpliceUninitialized(num5 - reference.startIndex, toRemove2, list.Count);
			for (int m = 0; m < list.Count; m++)
			{
				portalIsNotInnerCorner[num5 - reference.startIndex + m] = 0;
			}
			ListPool<float3>.Release(ref list);
			ListPool<float3>.Release(ref list2);
			return true;
		}

		private static bool ContainsPoint(GraphNode node, Vector3 point, NativeMovementPlane plane)
		{
			if (node is TriangleMeshNode triangleMeshNode)
			{
				return triangleMeshNode.ContainsPoint(point, plane);
			}
			return node.ContainsPoint(point);
		}

		[BurstCompile]
		private static bool ContainsAndProject(ref Int3 a, ref Int3 b, ref Int3 c, ref Vector3 p, float height, ref NativeMovementPlane movementPlane, out Vector3 projected)
		{
			return ContainsAndProject_0000095F_0024BurstDirectCall.Invoke(ref a, ref b, ref c, ref p, height, ref movementPlane, out projected);
		}

		private static float3 ProjectOnSurface(float3 a, float3 b, float3 c, float3 p, float3 up)
		{
			float3 x = math.cross(c - a, b - a);
			float num = math.dot(x, up);
			if (math.abs(num) > 1.1754944E-38f)
			{
				float3 y = p - a;
				float num2 = (0f - math.dot(x, y)) / num;
				return p + num2 * up;
			}
			return p;
		}

		private void Repair(Vector3 point, bool isStart, RepairQuality quality, NativeMovementPlane movementPlane, ITraversalProvider traversalProvider, Path path, bool allowCache = true)
		{
			int num;
			int num2;
			GraphNode absolute;
			bool flag;
			if (isStart)
			{
				num = firstPartIndex;
				num2 = parts[num].startIndex;
				absolute = nodes.GetAbsolute(num2);
				flag = unclampedStartPoint == point;
			}
			else
			{
				num = parts.Length - 1;
				num2 = parts[num].endIndex;
				absolute = nodes.GetAbsolute(num2);
				flag = unclampedEndPoint == point;
			}
			bool flag2 = ValidInPath(num2);
			if (allowCache && flag && flag2)
			{
				return;
			}
			if (partGraphType == PartGraphType.OffMeshLink)
			{
				throw new InvalidOperationException("Cannot repair path while on an off-mesh link");
			}
			ref Funnel.PathPart reference = ref parts[num];
			if (!float.IsFinite(point.x))
			{
				if (isStart)
				{
					throw new ArgumentException("Position must be a finite vector");
				}
				unclampedEndPoint = point;
				endIsUpToDate = false;
				RemoveAllPartsExceptFirst();
				ref Funnel.PathPart reference2 = ref parts[firstPartIndex];
				if (reference2.endIndex > reference2.startIndex)
				{
					SplicePath(reference2.startIndex + 1, reference2.endIndex - reference2.startIndex, null);
				}
				reference2.endPoint = reference2.startPoint;
				version++;
				return;
			}
			if (flag2)
			{
				bool flag3 = false;
				Vector3 projected = Vector3.zero;
				if (absolute is TriangleMeshNode triangleMeshNode)
				{
					triangleMeshNode.GetVertices(out var v, out var v2, out var v3);
					flag3 = ContainsAndProject(ref v, ref v2, ref v3, ref point, 1f, ref movementPlane, out projected);
				}
				else if (absolute is GridNodeBase gridNodeBase && gridNodeBase.ContainsPoint(point))
				{
					flag3 = true;
					projected = gridNodeBase.ClosestPointOnNode(point);
				}
				if (flag3)
				{
					if (isStart)
					{
						reference.startPoint = projected;
						unclampedStartPoint = point;
						startIsUpToDate = true;
						startNode = absolute;
					}
					else
					{
						reference.endPoint = projected;
						unclampedEndPoint = point;
						endIsUpToDate = true;
					}
					version++;
					return;
				}
			}
			RepairFull(point, isStart, quality, movementPlane, traversalProvider, path);
			version++;
		}

		private void HeuristicallyPopPortals(bool isStartOfPart, Vector3 point)
		{
			ref Funnel.PathPart reference = ref parts[firstPartIndex];
			if (isStartOfPart)
			{
				while (funnelState.IsReasonableToPopStart(point, reference.endPoint))
				{
					reference.startIndex++;
					nodes.PopStart();
					nodeHashes.PopStart();
					funnelState.PopStart();
					portalIsNotInnerCorner.PopStart();
				}
				if (ValidInPath(nodes.AbsoluteStartIndex))
				{
					startNode = nodes.First;
				}
			}
			else
			{
				int num = 0;
				while (funnelState.IsReasonableToPopEnd(reference.startPoint, point))
				{
					reference.endIndex--;
					num++;
					funnelState.PopEnd();
					portalIsNotInnerCorner.PopEnd();
				}
				if (num > 0)
				{
					nodes.SpliceAbsolute(reference.endIndex + 1, num, null);
					nodeHashes.SpliceAbsolute(reference.endIndex + 1, num, null);
					for (int i = firstPartIndex + 1; i < parts.Length; i++)
					{
						parts[i].startIndex -= num;
						parts[i].endIndex -= num;
					}
				}
			}
			int num2 = Mathf.Min(reference.startIndex + 5, reference.endIndex);
			bool flag = false;
			for (int j = reference.startIndex; j <= num2; j++)
			{
				flag |= !ValidInPath(j);
			}
			firstPartContainsDestroyedNodes = flag;
		}

		[Conditional("UNITY_ASSERTIONS")]
		private void AssertValidInPath(int absoluteNodeIndex)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private readonly bool ValidInPath(int absoluteNodeIndex)
		{
			return HashNode(nodes.GetAbsolute(absoluteNodeIndex)) == nodeHashes.GetAbsolute(absoluteNodeIndex);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool Valid(GraphNode node)
		{
			if (!node.Destroyed)
			{
				return node.Walkable;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int HashNode(GraphNode node)
		{
			int nodeIndex = (int)node.NodeIndex;
			nodeIndex ^= (node.Walkable ? 100663319 : 0);
			if (node is GridNodeBase gridNodeBase)
			{
				nodeIndex ^= gridNodeBase.NodeInGridIndex * 25165843;
			}
			return nodeIndex;
		}

		private void RepairFull(Vector3 point, bool isStart, RepairQuality quality, NativeMovementPlane movementPlane, ITraversalProvider traversalProvider, Path path)
		{
			int maxNodesToSearch = ((quality == RepairQuality.High) ? 16 : 9);
			int num = (isStart ? firstPartIndex : (parts.Length - 1));
			ref Funnel.PathPart reference = ref parts[num];
			int num2 = (isStart ? reference.startIndex : reference.endIndex);
			if ((!ValidInPath(num2) || (reference.endIndex != reference.startIndex && !ValidInPath(isStart ? (reference.startIndex + 1) : (reference.endIndex - 1)))) && num == firstPartIndex)
			{
				HeuristicallyPopPortals(isStart, point);
				num2 = (isStart ? reference.startIndex : reference.endIndex);
			}
			if (!ValidInPath(num2))
			{
				if (isStart)
				{
					firstPartContainsDestroyedNodes = true;
					unclampedStartPoint = point;
					startIsUpToDate = false;
					NNConstraint nNConstraint = nnConstraint;
					nNConstraint.distanceMetric = DistanceMetric.ClosestAsSeenFromAboveSoft(movementPlane.ToWorld(float2.zero, 1f));
					GraphNode graphNode = ((AstarPath.active != null) ? AstarPath.active.GetNearest(point, nNConstraint).node : null);
					if (traversalProvider != null && !traversalProvider.CanTraverse(path, graphNode))
					{
						graphNode = null;
					}
					startNode = graphNode;
					if (startNode != null)
					{
						reference.startPoint = startNode.ClosestPointOnNode(point);
						if (reference.endIndex - reference.startIndex < 10 && partCount <= 1)
						{
							Vector3 vector = reference.startPoint;
							Clear();
							startNode = graphNode;
							partGraphType = PartGraphTypeFromNode(startNode);
							unclampedStartPoint = point;
							unclampedEndPoint = vector;
							nodes.PushEnd(graphNode);
							nodeHashes.PushEnd(HashNode(graphNode));
							parts = new Funnel.PathPart[1];
							parts[0] = new Funnel.PathPart
							{
								startIndex = nodes.AbsoluteStartIndex,
								endIndex = nodes.AbsoluteEndIndex,
								startPoint = vector,
								endPoint = vector
							};
						}
					}
					else
					{
						reference.startPoint = point;
					}
				}
				else
				{
					unclampedEndPoint = point;
					reference.endPoint = point;
					endIsUpToDate = false;
				}
			}
			else
			{
				CircularBuffer<GraphNode> path2 = LocalSearch(nodes.GetAbsolute(num2), point, maxNodesToSearch, movementPlane, isStart, traversalProvider, path);
				GraphNode last = path2.Last;
				NNConstraint nNConstraint2 = nnConstraint;
				nNConstraint2.constrainArea = true;
				nNConstraint2.area = (int)last.Area;
				NNInfo nearest = AstarPath.active.GetNearest(point, nNConstraint2);
				nNConstraint2.constrainArea = false;
				Vector3 vector2 = (isStart ? reference.startPoint : reference.endPoint);
				bool flag;
				Vector3 vector3;
				if (nearest.node == last)
				{
					flag = true;
					vector3 = nearest.position;
				}
				else
				{
					float sqrMagnitude = ((isStart ? unclampedStartPoint : unclampedEndPoint) - vector2).sqrMagnitude;
					bool num3 = (isStart ? startIsUpToDate : endIsUpToDate);
					vector3 = last.ClosestPointOnNode(point);
					float sqrMagnitude2 = (point - vector3).sqrMagnitude;
					flag = num3 && sqrMagnitude2 <= sqrMagnitude + 0.010000001f;
				}
				if (!flag && !isStart)
				{
					path2.Clear();
					vector3 = vector2;
				}
				AppendPath(isStart, path2);
				path2.Pool();
				if (isStart)
				{
					startNode = nodes.First;
				}
				if (isStart)
				{
					unclampedStartPoint = point;
					reference.startPoint = vector3;
					startIsUpToDate = true;
				}
				else
				{
					unclampedEndPoint = point;
					reference.endPoint = vector3;
					endIsUpToDate = flag;
				}
			}
		}

		private static float SquaredDistanceToNode(GraphNode node, Vector3 point, ref BBTree.ProjectionParams projectionParams)
		{
			if (node is TriangleMeshNode triangleMeshNode)
			{
				triangleMeshNode.GetVerticesInGraphSpace(out var v, out var v2, out var v3);
				Polygon.ClosestPointOnTriangleProjected(ref v, ref v2, ref v3, ref projectionParams, ref UnsafeUtility.As<Vector3, float3>(ref point), out var _, out var sqrDist, out var _);
				return sqrDist;
			}
			if (node is GridNodeBase { CoordinatesInGrid: var coordinatesInGrid })
			{
				float x = math.clamp(point.x, coordinatesInGrid.x, coordinatesInGrid.x + 1);
				float z = math.clamp(point.z, coordinatesInGrid.y, coordinatesInGrid.y + 1);
				return math.lengthsq(new float3(x, 0f, z) - (float3)point);
			}
			Vector3 vector = node.ClosestPointOnNode(point);
			return (point - vector).sqrMagnitude;
		}

		private static bool QueueHasNode(QueueItem[] queue, int count, GraphNode node)
		{
			for (int i = 0; i < count; i++)
			{
				if (queue[i].node == node)
				{
					return true;
				}
			}
			return false;
		}

		private void GetTempQueue(out QueueItem[] queue, out List<GraphNode> connections)
		{
			queue = new QueueItem[16];
			connections = new List<GraphNode>();
		}

		private CircularBuffer<GraphNode> LocalSearch(GraphNode currentNode, Vector3 point, int maxNodesToSearch, NativeMovementPlane movementPlane, bool reverse, ITraversalProvider traversalProvider, Path path)
		{
			NNConstraint nNConstraint = nnConstraint;
			nNConstraint.distanceMetric = DistanceMetric.ClosestAsSeenFromAboveSoft(movementPlane.up);
			GetTempQueue(out var queue, out var connections);
			int num = 0;
			int num2 = 0;
			NavGraph graph = currentNode.Graph;
			BBTree.ProjectionParams projectionParams;
			Vector3 point2;
			if (partGraphType == PartGraphType.Navmesh)
			{
				NavmeshBase navmeshBase = graph as NavmeshBase;
				projectionParams = new BBTree.ProjectionParams(nNConstraint, navmeshBase.transform);
				point2 = navmeshBase.transform.InverseTransform(point);
			}
			else if (partGraphType == PartGraphType.Grid)
			{
				projectionParams = default(BBTree.ProjectionParams);
				point2 = (graph as GridGraph).transform.InverseTransform(point);
			}
			else
			{
				projectionParams = default(BBTree.ProjectionParams);
				point2 = point;
			}
			float num3 = SquaredDistanceToNode(currentNode, point2, ref projectionParams);
			queue[0] = new QueueItem
			{
				node = currentNode,
				parent = -1,
				distance = num3
			};
			num2++;
			int num4 = 0;
			while (num < num2)
			{
				int num5 = num;
				GraphNode node = queue[num5].node;
				num++;
				if (ContainsPoint(node, point, movementPlane))
				{
					num3 = 0f;
					num4 = num5;
					break;
				}
				float distance = queue[num5].distance;
				if (distance < num3)
				{
					num3 = distance;
					num4 = num5;
				}
				float num6 = distance * 1.1024998f + 0.05f;
				node.GetConnections(delegate(GraphNode item, ref List<GraphNode> ls)
				{
					ls.Add(item);
				}, ref connections);
				for (int num7 = 0; num7 < connections.Count; num7++)
				{
					GraphNode graphNode = connections[num7];
					if (num2 >= maxNodesToSearch || graphNode.GraphIndex != node.GraphIndex || !nNConstraint.Suitable(graphNode))
					{
						continue;
					}
					if (traversalProvider != null)
					{
						bool num8;
						if (!reverse)
						{
							num8 = traversalProvider.CanTraverse(path, node, graphNode);
						}
						else
						{
							if (!traversalProvider.CanTraverse(path, graphNode))
							{
								continue;
							}
							num8 = traversalProvider.CanTraverse(path, graphNode, node);
						}
						if (!num8)
						{
							continue;
						}
					}
					float num9 = SquaredDistanceToNode(graphNode, point2, ref projectionParams);
					if (num9 < num6 && !QueueHasNode(queue, num2, graphNode))
					{
						queue[num2] = new QueueItem
						{
							node = graphNode,
							parent = num5,
							distance = num9
						};
						num2++;
					}
				}
				connections.Clear();
			}
			CircularBuffer<GraphNode> path2 = new CircularBuffer<GraphNode>(8);
			while (num4 != -1)
			{
				path2.PushStart(queue[num4].node);
				num4 = queue[num4].parent;
			}
			connections.Clear();
			for (int num10 = 0; num10 < num2; num10++)
			{
				queue[num10].node = null;
			}
			if (partGraphType == PartGraphType.Grid)
			{
				CircularBuffer<int> pathNodeHashes = default(CircularBuffer<int>);
				RemoveGridPathDiagonals(null, 0, ref path2, ref pathNodeHashes, nnConstraint, traversalProvider, path);
			}
			return path2;
		}

		public void DrawFunnel(CommandBuilder draw, NativeMovementPlane movementPlane)
		{
			if (parts == null)
			{
				return;
			}
			Funnel.PathPart pathPart = parts[firstPartIndex];
			funnelState.PushStart(pathPart.startPoint, pathPart.startPoint);
			funnelState.PushEnd(pathPart.endPoint, pathPart.endPoint);
			using (draw.WithLineWidth(2f))
			{
				draw.Polyline(funnelState.leftFunnel);
				draw.Polyline(funnelState.rightFunnel);
			}
			if (funnelState.unwrappedPortals.Length > 1)
			{
				using (draw.WithLineWidth(1f))
				{
					float3 up = movementPlane.up;
					float4x3 float4x5 = funnelState.UnwrappedPortalsToWorldMatrix(up);
					float4x4 float4x6 = new float4x4(float4x5.c0, float4x5.c1, new float4(0f, 0f, 1f, 0f), float4x5.c2);
					using (draw.WithMatrix(float4x6))
					{
						float2 a = funnelState.unwrappedPortals[0].xy;
						float2 a2 = funnelState.unwrappedPortals[1].xy;
						for (int i = 0; i < funnelState.unwrappedPortals.Length; i++)
						{
							float2 xy = funnelState.unwrappedPortals[i].xy;
							float2 zw = funnelState.unwrappedPortals[i].zw;
							draw.xy.Line(xy, zw, Palette.Colorbrewer.Set1.Brown);
							draw.xy.Line(a, xy, Palette.Colorbrewer.Set1.Brown);
							draw.xy.Line(a2, zw, Palette.Colorbrewer.Set1.Brown);
							a = xy;
							a2 = zw;
						}
					}
				}
			}
			using (draw.WithColor(new Color(0f, 0f, 0f, 0.2f)))
			{
				for (int j = 0; j < funnelState.leftFunnel.Length - 1; j++)
				{
					draw.SolidTriangle(funnelState.leftFunnel[j], funnelState.rightFunnel[j], funnelState.rightFunnel[j + 1]);
					draw.SolidTriangle(funnelState.leftFunnel[j], funnelState.leftFunnel[j + 1], funnelState.rightFunnel[j + 1]);
				}
			}
			using (draw.WithColor(new Color(0f, 0f, 1f, 0.5f)))
			{
				for (int k = 0; k < funnelState.leftFunnel.Length; k++)
				{
					draw.Line(funnelState.leftFunnel[k], funnelState.rightFunnel[k]);
				}
			}
			funnelState.PopStart();
			funnelState.PopEnd();
		}

		private static Int3 MaybeSetYZero(Int3 p, bool setYToZero)
		{
			if (setYToZero)
			{
				p.y = 0;
			}
			return p;
		}

		private static bool IsInnerVertex(CircularBuffer<GraphNode> nodes, Funnel.PathPart part, int portalIndex, bool rightSide, List<GraphNode> alternativeNodes, NNConstraint nnConstraint, out int startIndex, out int endIndex, ITraversalProvider traversalProvider, Path path)
		{
			GraphNode absolute = nodes.GetAbsolute(portalIndex);
			if (absolute is TriangleMeshNode)
			{
				return IsInnerVertexTriangleMesh(nodes, part, portalIndex, rightSide, alternativeNodes, nnConstraint, out startIndex, out endIndex, traversalProvider, path);
			}
			if (absolute is GridNodeBase)
			{
				return IsInnerVertexGrid(nodes, part, portalIndex, rightSide, alternativeNodes, nnConstraint, out startIndex, out endIndex, traversalProvider, path);
			}
			startIndex = portalIndex;
			endIndex = portalIndex + 1;
			return false;
		}

		private static bool IsInnerVertexGrid(CircularBuffer<GraphNode> nodes, Funnel.PathPart part, int portalIndex, bool rightSide, List<GraphNode> alternativeNodes, NNConstraint nnConstraint, out int startIndex, out int endIndex, ITraversalProvider traversalProvider, Path path)
		{
			startIndex = portalIndex;
			endIndex = portalIndex + 1;
			return false;
		}

		private static bool IsInnerVertexTriangleMesh(CircularBuffer<GraphNode> nodes, Funnel.PathPart part, int portalIndex, bool rightSide, List<GraphNode> alternativeNodes, NNConstraint nnConstraint, out int startIndex, out int endIndex, ITraversalProvider traversalProvider, Path path)
		{
			startIndex = portalIndex;
			endIndex = portalIndex + 1;
			TriangleMeshNode triangleMeshNode = nodes.GetAbsolute(startIndex) as TriangleMeshNode;
			TriangleMeshNode triangleMeshNode2 = nodes.GetAbsolute(endIndex) as TriangleMeshNode;
			if (triangleMeshNode == null || triangleMeshNode2 == null || !Valid(triangleMeshNode) || !Valid(triangleMeshNode2))
			{
				return false;
			}
			if (!triangleMeshNode.GetPortalInGraphSpace(triangleMeshNode2, out var a, out var b, out var aIndex, out var bIndex))
			{
				return false;
			}
			bool recalculateNormals = (triangleMeshNode.Graph as NavmeshBase).RecalculateNormals;
			Int3 int5 = MaybeSetYZero(rightSide ? b : a, recalculateNormals);
			Int3 a2;
			Int3 b2;
			while (startIndex > part.startIndex && nodes.GetAbsolute(startIndex - 1) is TriangleMeshNode triangleMeshNode3 && Valid(triangleMeshNode3) && triangleMeshNode3.GetPortalInGraphSpace(triangleMeshNode, out a2, out b2, out bIndex, out aIndex) && MaybeSetYZero(rightSide ? b2 : a2, recalculateNormals) == int5)
			{
				triangleMeshNode = triangleMeshNode3;
				startIndex--;
			}
			Int3 a3;
			Int3 b3;
			while (endIndex < part.endIndex && nodes.GetAbsolute(endIndex + 1) is TriangleMeshNode triangleMeshNode4 && Valid(triangleMeshNode4) && triangleMeshNode2.GetPortalInGraphSpace(triangleMeshNode4, out a3, out b3, out aIndex, out bIndex) && MaybeSetYZero(rightSide ? b3 : a3, recalculateNormals) == int5)
			{
				triangleMeshNode2 = triangleMeshNode4;
				endIndex++;
				if (triangleMeshNode2 == triangleMeshNode)
				{
					break;
				}
			}
			TriangleMeshNode triangleMeshNode5 = triangleMeshNode;
			int num = 0;
			alternativeNodes.Add(triangleMeshNode);
			if (triangleMeshNode == triangleMeshNode2)
			{
				return true;
			}
			bool flag;
			do
			{
				flag = false;
				for (int i = 0; i < triangleMeshNode5.connections.Length; i++)
				{
					if (triangleMeshNode5.connections[i].node is TriangleMeshNode triangleMeshNode6 && (traversalProvider?.CanTraverse(path, triangleMeshNode5, triangleMeshNode6) ?? nnConstraint.Suitable(triangleMeshNode6)) && triangleMeshNode5.connections[i].isOutgoing && triangleMeshNode5.GetPortalInGraphSpace(triangleMeshNode6, out var a4, out var b4, out bIndex, out aIndex) && MaybeSetYZero(rightSide ? a4 : b4, recalculateNormals) == int5)
					{
						triangleMeshNode5 = triangleMeshNode6;
						alternativeNodes.Add(triangleMeshNode5);
						if (triangleMeshNode5 == triangleMeshNode2)
						{
							return true;
						}
						if (num++ > 100)
						{
							throw new Exception("Caught in a potentially infinite loop. The navmesh probably contains degenerate geometry.");
						}
						flag = true;
						break;
					}
				}
			}
			while (flag);
			return false;
		}

		private bool FirstInnerVertex(NativeArray<int> indices, int numCorners, List<GraphNode> alternativePath, out int alternativeStartIndex, out int alternativeEndIndex, ITraversalProvider traversalProvider, Path path)
		{
			Funnel.PathPart part = parts[firstPartIndex];
			for (int i = 0; i < numCorners; i++)
			{
				int num = indices[i];
				bool flag = (num & 0x40000000) != 0;
				int num2 = num & 0x3FFFFFFF;
				if ((portalIsNotInnerCorner[num2] & (flag ? 1 : 2)) == 0)
				{
					alternativePath.Clear();
					if (IsInnerVertex(nodes, part, part.startIndex + num2, flag, alternativePath, nnConstraint, out alternativeStartIndex, out alternativeEndIndex, traversalProvider, path))
					{
						return true;
					}
					portalIsNotInnerCorner[num2] = (byte)(portalIsNotInnerCorner[num2] | (flag ? 1 : 2));
				}
			}
			alternativeStartIndex = -1;
			alternativeEndIndex = -1;
			return false;
		}

		public float EstimateRemainingPath(int maxCorners, ref NativeMovementPlane movementPlane)
		{
			return EstimateRemainingPath(ref funnelState, ref parts[firstPartIndex], maxCorners, ref movementPlane);
		}

		[BurstCompile]
		private static float EstimateRemainingPath(ref Funnel.FunnelState funnelState, ref Funnel.PathPart part, int maxCorners, ref NativeMovementPlane movementPlane)
		{
			return EstimateRemainingPath_00000973_0024BurstDirectCall.Invoke(ref funnelState, ref part, maxCorners, ref movementPlane);
		}

		public void GetNextCorners(NativeList<float3> buffer, int maxCorners, ref NativeArray<int> scratchArray, Allocator allocator, ITraversalProvider traversalProvider, Path path)
		{
			bool lastCorner;
			int nextCornerIndices = GetNextCornerIndices(ref scratchArray, maxCorners, allocator, out lastCorner, traversalProvider, path);
			Funnel.PathPart pathPart = parts[firstPartIndex];
			funnelState.ConvertCornerIndicesToPath(scratchArray, nextCornerIndices, splitAtEveryPortal: false, pathPart.startPoint, pathPart.endPoint, lastCorner, buffer);
		}

		public int GetNextCornerIndices(ref NativeArray<int> buffer, int maxCorners, Allocator allocator, out bool lastCorner, ITraversalProvider traversalProvider, Path path)
		{
			int num = 3;
			maxCorners--;
			if (scratchList == null)
			{
				scratchList = new List<GraphNode>(8);
			}
			List<GraphNode> list = scratchList;
			int num3;
			while (true)
			{
				int num2 = math.max(0, math.min(maxCorners, funnelState.leftFunnel.Length));
				if (!buffer.IsCreated || buffer.Length < num2)
				{
					if (buffer.IsCreated)
					{
						buffer.Dispose();
					}
					buffer = new NativeArray<int>(math.ceilpow2(num2), allocator, NativeArrayOptions.UninitializedMemory);
				}
				NativeArray<int> nativeArray = buffer;
				Funnel.PathPart part = parts[firstPartIndex];
				num3 = funnelState.CalculateNextCornerIndices(num2, nativeArray, part.startPoint, part.endPoint, out lastCorner);
				if (num <= 0)
				{
					break;
				}
				if (partGraphType == PartGraphType.Grid)
				{
					if (!SimplifyGridInnerVertex(ref nodes, nativeArray.AsUnsafeSpan().Slice(0, num3), part, ref portalIsNotInnerCorner, list, out var alternativeStartIndex, out var alternativeEndIndex, nnConstraint, traversalProvider, path, lastCorner))
					{
						break;
					}
					if (!SplicePath(alternativeStartIndex, alternativeEndIndex - alternativeStartIndex + 1, list))
					{
						firstPartContainsDestroyedNodes = true;
						break;
					}
					num--;
					version++;
				}
				else
				{
					if (!FirstInnerVertex(nativeArray, num3, list, out var alternativeStartIndex2, out var alternativeEndIndex2, traversalProvider, path))
					{
						break;
					}
					if (!SplicePath(alternativeStartIndex2, alternativeEndIndex2 - alternativeStartIndex2 + 1, list))
					{
						firstPartContainsDestroyedNodes = true;
						break;
					}
					num--;
					version++;
				}
			}
			return num3;
		}

		public void ConvertCornerIndicesToPathProjected(NativeArray<int> cornerIndices, int numCorners, bool lastCorner, NativeList<float3> buffer, float3 up)
		{
			Funnel.PathPart pathPart = parts[firstPartIndex];
			funnelState.ConvertCornerIndicesToPathProjected(cornerIndices.AsUnsafeReadOnlySpan().Slice(0, numCorners), splitAtEveryPortal: false, pathPart.startPoint, pathPart.endPoint, lastCorner, buffer, up);
		}

		[BurstCompile]
		public static float RemainingDistanceLowerBound(in UnsafeSpan<float3> nextCorners, in float3 endOfPart, in NativeMovementPlane movementPlane)
		{
			return RemainingDistanceLowerBound_00000977_0024BurstDirectCall.Invoke(in nextCorners, in endOfPart, in movementPlane);
		}

		public void PopParts(int count, ITraversalProvider traversalProvider, Path path)
		{
			if (firstPartIndex + count >= parts.Length)
			{
				throw new InvalidOperationException("Cannot pop the last part of a path");
			}
			firstPartIndex += count;
			version++;
			Funnel.PathPart pathPart = parts[firstPartIndex];
			while (nodes.AbsoluteStartIndex < pathPart.startIndex)
			{
				nodes.PopStart();
				nodeHashes.PopStart();
			}
			startNode = ((nodes.Length > 0) ? nodes.First : null);
			firstPartContainsDestroyedNodes = false;
			if (GetPartType() == Funnel.PartType.OffMeshLink)
			{
				partGraphType = PartGraphType.OffMeshLink;
				SetFunnelState(pathPart);
				return;
			}
			partGraphType = PartGraphTypeFromNode(startNode);
			for (int i = pathPart.startIndex; i <= pathPart.endIndex; i++)
			{
				if (!ValidInPath(i))
				{
					RemoveAllPartsExceptFirst();
					while (nodes.AbsoluteEndIndex > i)
					{
						nodes.PopEnd();
						nodeHashes.PopEnd();
					}
					pathPart.endIndex = i;
					parts[firstPartIndex] = pathPart;
					if (i == pathPart.startIndex)
					{
						firstPartContainsDestroyedNodes = true;
						funnelState.Clear();
						portalIsNotInnerCorner.Clear();
						startNode = null;
						return;
					}
					endIsUpToDate = false;
					nodes.PopEnd();
					nodeHashes.PopEnd();
					pathPart.endIndex = i - 1;
					parts[firstPartIndex] = pathPart;
					break;
				}
			}
			if (partGraphType == PartGraphType.Grid)
			{
				RemoveGridPathDiagonals(parts, firstPartIndex, ref nodes, ref nodeHashes, nnConstraint, traversalProvider, path);
				pathPart = parts[firstPartIndex];
			}
			SetFunnelState(pathPart);
		}

		private void RemoveAllPartsExceptFirst()
		{
			if (partCount > 1)
			{
				parts = new Funnel.PathPart[1] { parts[firstPartIndex] };
				firstPartIndex = 0;
				while (nodes.AbsoluteEndIndex > parts[0].endIndex)
				{
					nodes.PopEnd();
					nodeHashes.PopEnd();
				}
				version++;
			}
		}

		public readonly Funnel.PartType GetPartType(int partIndex = 0)
		{
			return parts[firstPartIndex + partIndex].type;
		}

		public readonly bool PartContainsDestroyedNodes(int partIndex = 0)
		{
			if (partIndex < 0 || partIndex >= partCount)
			{
				throw new ArgumentOutOfRangeException("partIndex");
			}
			Funnel.PathPart pathPart = parts[firstPartIndex + partIndex];
			for (int i = pathPart.startIndex; i <= pathPart.endIndex; i++)
			{
				if (!ValidInPath(i))
				{
					return true;
				}
			}
			return false;
		}

		public OffMeshLinks.OffMeshLinkTracer GetLinkInfo(int partIndex = 0)
		{
			if (partIndex < 0 || partIndex >= partCount)
			{
				throw new ArgumentOutOfRangeException("partIndex");
			}
			if (GetPartType(partIndex) != Funnel.PartType.OffMeshLink)
			{
				throw new ArgumentException("Part is not an off-mesh link");
			}
			Funnel.PathPart pathPart = parts[firstPartIndex + partIndex];
			LinkNode linkNode = nodes.GetAbsolute(pathPart.startIndex) as LinkNode;
			LinkNode linkNode2 = nodes.GetAbsolute(pathPart.endIndex) as LinkNode;
			if (linkNode == null)
			{
				throw new Exception("Expected a link node");
			}
			if (linkNode2 == null)
			{
				throw new Exception("Expected a link node");
			}
			if (linkNode.Destroyed)
			{
				throw new Exception("Start node is destroyed");
			}
			if (linkNode2.Destroyed)
			{
				throw new Exception("End node is destroyed");
			}
			bool reversed;
			if (linkNode.linkConcrete.startLinkNode == linkNode)
			{
				reversed = false;
			}
			else
			{
				if (linkNode.linkConcrete.startLinkNode != linkNode2)
				{
					throw new Exception("Link node is not part of the link");
				}
				reversed = true;
			}
			return new OffMeshLinks.OffMeshLinkTracer(linkNode.linkConcrete, reversed);
		}

		private void SetFunnelState(Funnel.PathPart part)
		{
			funnelState.Clear();
			portalIsNotInnerCorner.Clear();
			if (part.type == Funnel.PartType.NodeSequence)
			{
				if (nodes.GetAbsolute(part.startIndex).Graph is GridGraph gridGraph)
				{
					funnelState.projectionAxis = gridGraph.transform.WorldUpAtGraphPosition(Vector3.zero);
				}
				List<float3> list = ListPool<float3>.Claim(part.endIndex - part.startIndex);
				List<float3> list2 = ListPool<float3>.Claim(part.endIndex - part.startIndex);
				CalculateFunnelPortals(part.startIndex, part.endIndex, list, list2);
				funnelState.Splice(0, 0, list, list2);
				for (int i = 0; i < list.Count; i++)
				{
					portalIsNotInnerCorner.PushEnd(0);
				}
				ListPool<float3>.Release(ref list);
				ListPool<float3>.Release(ref list2);
			}
			version++;
		}

		private void CalculateFunnelPortals(int startNodeIndex, int endNodeIndex, List<float3> outLeftPortals, List<float3> outRightPortals)
		{
			GraphNode graphNode = nodes.GetAbsolute(startNodeIndex);
			for (int i = startNodeIndex + 1; i <= endNodeIndex; i++)
			{
				GraphNode absolute = nodes.GetAbsolute(i);
				if (graphNode.GetPortal(absolute, out var left, out var right))
				{
					outLeftPortals.Add(left);
					outRightPortals.Add(right);
					graphNode = absolute;
					continue;
				}
				throw new InvalidOperationException("Couldn't find a portal from " + graphNode?.ToString() + " " + absolute?.ToString() + " " + graphNode.ContainsOutgoingConnection(absolute));
			}
		}

		public void SetFromSingleNode(GraphNode node, Vector3 position, NativeMovementPlane movementPlane)
		{
			SetPath(new List<Funnel.PathPart>
			{
				new Funnel.PathPart
				{
					startIndex = 0,
					endIndex = 0,
					startPoint = position,
					endPoint = position
				}
			}, new List<GraphNode> { node }, position, position, movementPlane, null, null);
		}

		public void Clear()
		{
			funnelState.Clear();
			parts = null;
			nodes.Clear();
			nodeHashes.Clear();
			portalIsNotInnerCorner.Clear();
			unclampedEndPoint = (unclampedStartPoint = Vector3.zero);
			firstPartIndex = 0;
			startIsUpToDate = false;
			endIsUpToDate = false;
			firstPartContainsDestroyedNodes = false;
			startNodeInternal = null;
			partGraphType = PartGraphType.Navmesh;
		}

		private static int2 ResolveNormalizedGridPoint(GridGraph grid, ref CircularBuffer<GraphNode> nodes, UnsafeSpan<int> cornerIndices, Funnel.PathPart part, int index, out int nodeIndex)
		{
			if (index < 0 || index >= cornerIndices.Length)
			{
				Vector3 point = ((index < 0) ? part.startPoint : part.endPoint);
				nodeIndex = ((index < 0) ? part.startIndex : part.endIndex);
				Vector3 vector = grid.transform.InverseTransform(point);
				Int2 coordinatesInGrid = (nodes.GetAbsolute(nodeIndex) as GridNodeBase).CoordinatesInGrid;
				return new int2(math.clamp((int)(1024f * (vector.x - (float)coordinatesInGrid.x)), 0, 1024), math.clamp((int)(1024f * (vector.z - (float)coordinatesInGrid.y)), 0, 1024));
			}
			bool flag = (cornerIndices[index] & 0x40000000) != 0;
			nodeIndex = part.startIndex + (cornerIndices[index] & 0x3FFFFFFF);
			GridNodeBase gridNodeBase = nodes.GetAbsolute(nodeIndex) as GridNodeBase;
			GridNodeBase obj = nodes.GetAbsolute(nodeIndex + 1) as GridNodeBase;
			Int2 coordinatesInGrid2 = gridNodeBase.CoordinatesInGrid;
			Int2 coordinatesInGrid3 = obj.CoordinatesInGrid;
			int dx = coordinatesInGrid3.x - coordinatesInGrid2.x;
			int dz = coordinatesInGrid3.y - coordinatesInGrid2.y;
			int num = GridNodeBase.OffsetToConnectionDirection(dx, dz);
			if (num > 4)
			{
				throw new Exception("Diagonal connections are not supported");
			}
			int num2 = GridGraph.neighbourXOffsets[num] + GridGraph.neighbourXOffsets[(num + ((!flag) ? 1 : (-1)) + 4) % 4];
			int num3 = GridGraph.neighbourZOffsets[num] + GridGraph.neighbourZOffsets[(num + ((!flag) ? 1 : (-1)) + 4) % 4];
			return new int2(512 + 512 * num2, 512 + 512 * num3);
		}

		private static bool SimplifyGridInnerVertex(ref CircularBuffer<GraphNode> nodes, UnsafeSpan<int> cornerIndices, Funnel.PathPart part, ref CircularBuffer<byte> portalIsNotInnerCorner, List<GraphNode> alternativePath, out int alternativeStartIndex, out int alternativeEndIndex, NNConstraint nnConstraint, ITraversalProvider traversalProvider, Path path, bool lastCorner)
		{
			int num = (lastCorner ? cornerIndices.Length : (cornerIndices.Length - 1));
			alternativeStartIndex = -1;
			alternativeEndIndex = -1;
			if (num == 0)
			{
				return false;
			}
			int num2 = 0;
			int index = cornerIndices[num2] & 0x3FFFFFFF;
			int num3 = portalIsNotInnerCorner[index] % 32;
			portalIsNotInnerCorner[index] = (byte)(num3 + 1);
			if ((num3 & 3) != 0)
			{
				return false;
			}
			num3 /= 4;
			int num4 = ((cornerIndices.length < 2) ? part.endIndex : math.min(part.endIndex, part.startIndex + (cornerIndices[1] & 0x3FFFFFFF) + 1));
			for (int i = part.startIndex; i < num4; i++)
			{
				GraphNode absolute = nodes.GetAbsolute(i);
				GraphNode absolute2 = nodes.GetAbsolute(i + 1);
				if (!Valid(absolute2) || !absolute.ContainsOutgoingConnection(absolute2))
				{
					return false;
				}
			}
			GridGraph gridGraph = GridNode.GetGridGraph(nodes.GetAbsolute(part.startIndex).GraphIndex);
			int nodeIndex;
			int2 fixedNormalizedFromPoint = ResolveNormalizedGridPoint(gridGraph, ref nodes, cornerIndices, part, num2 - 1, out nodeIndex);
			int nodeIndex2;
			int2 int5 = ResolveNormalizedGridPoint(gridGraph, ref nodes, cornerIndices, part, num2 + 1, out nodeIndex2);
			int nodeIndex3;
			int2 int6 = ResolveNormalizedGridPoint(gridGraph, ref nodes, cornerIndices, part, num2, out nodeIndex3);
			GridNodeBase fromNode = nodes.GetAbsolute(nodeIndex) as GridNodeBase;
			GridNodeBase gridNodeBase = nodes.GetAbsolute(nodeIndex3) as GridNodeBase;
			GridNodeBase gridNodeBase2 = nodes.GetAbsolute(nodeIndex2) as GridNodeBase;
			if (num3 > 0)
			{
				int num5 = SplittingCoefficients[num3 * 2];
				int num6 = SplittingCoefficients[num3 * 2 + 1];
				nodeIndex2 += (nodeIndex3 - nodeIndex2) * num5 / num6;
				if (nodeIndex2 == nodeIndex3)
				{
					return false;
				}
				Int2 coordinatesInGrid = gridNodeBase2.CoordinatesInGrid;
				Int2 coordinatesInGrid2 = gridNodeBase.CoordinatesInGrid;
				int2 int7 = new int2(coordinatesInGrid2.x * 1024, coordinatesInGrid2.y * 1024) + int6;
				int2 int8 = new int2(coordinatesInGrid.x * 1024, coordinatesInGrid.y * 1024) + int5;
				gridNodeBase2 = nodes.GetAbsolute(nodeIndex2) as GridNodeBase;
				coordinatesInGrid = gridNodeBase2.CoordinatesInGrid;
				float s = VectorMath.ClosestPointOnLineFactor(new Int2(int7.x, int7.y), new Int2(int8.x, int8.y), new Int2(coordinatesInGrid.x * 1024 + 512, coordinatesInGrid.y * 1024 + 512));
				int2 int9 = new int2((int)math.lerp(int7.x, int8.x, s), (int)math.lerp(int7.y, int8.y, s)) - new int2(coordinatesInGrid.x * 1024, coordinatesInGrid.y * 1024);
				int5 = new int2(math.clamp(int9.x, 0, 1024), math.clamp(int9.y, 0, 1024));
			}
			alternativePath.Clear();
			if (!gridGraph.Linecast(fromNode, fixedNormalizedFromPoint, gridNodeBase2, int5, out var _, alternativePath))
			{
				for (int j = 1; j < alternativePath.Count; j++)
				{
					if ((traversalProvider != null) ? (!traversalProvider.CanTraverse(path, alternativePath[j - 1], alternativePath[j])) : (!nnConstraint.Suitable(alternativePath[j])))
					{
						return false;
					}
				}
				uint num7 = 0u;
				for (int k = 0; k < alternativePath.Count; k++)
				{
					num7 += traversalProvider?.GetTraversalCost(path, alternativePath[k]) ?? DefaultITraversalProvider.GetTraversalCost(path, alternativePath[k]);
				}
				if (num7 != 0)
				{
					uint num8 = 0u;
					for (int l = nodeIndex; l <= nodeIndex2; l++)
					{
						num8 += traversalProvider?.GetTraversalCost(path, nodes.GetAbsolute(l)) ?? DefaultITraversalProvider.GetTraversalCost(path, nodes.GetAbsolute(l));
					}
					if (num7 > num8)
					{
						return false;
					}
				}
				alternativeStartIndex = nodeIndex;
				alternativeEndIndex = nodeIndex2;
				return true;
			}
			return false;
		}

		private static void RemoveGridPathDiagonals(Funnel.PathPart[] parts, int partIndex, ref CircularBuffer<GraphNode> path, ref CircularBuffer<int> pathNodeHashes, NNConstraint nnConstraint, ITraversalProvider traversalProvider, Path pathObject)
		{
			int num = 0;
			Funnel.PathPart pathPart = ((parts != null) ? parts[partIndex] : new Funnel.PathPart
			{
				startIndex = path.AbsoluteStartIndex,
				endIndex = path.AbsoluteEndIndex
			});
			for (int num2 = pathPart.endIndex - 1; num2 >= pathPart.startIndex; num2--)
			{
				GridNodeBase gridNodeBase = path.GetAbsolute(num2) as GridNodeBase;
				GridNodeBase gridNodeBase2 = path.GetAbsolute(num2 + 1) as GridNodeBase;
				int dx = gridNodeBase2.XCoordinateInGrid - gridNodeBase.XCoordinateInGrid;
				int dz = gridNodeBase2.ZCoordinateInGrid - gridNodeBase.ZCoordinateInGrid;
				int num3 = GridNodeBase.OffsetToConnectionDirection(dx, dz);
				if (num3 >= 4)
				{
					int direction = num3 - 4;
					int direction2 = (num3 - 4 + 1) % 4;
					GridNodeBase gridNodeBase3 = gridNodeBase.GetNeighbourAlongDirection(direction);
					if (gridNodeBase3 != null && ((traversalProvider != null) ? (!traversalProvider.CanTraverse(pathObject, gridNodeBase, gridNodeBase3)) : (!nnConstraint.Suitable(gridNodeBase3))))
					{
						gridNodeBase3 = null;
					}
					if (gridNodeBase3 != null && gridNodeBase3.GetNeighbourAlongDirection(direction2) == gridNodeBase2 && (traversalProvider == null || traversalProvider.CanTraverse(pathObject, gridNodeBase3, gridNodeBase2)))
					{
						path.InsertAbsolute(num2 + 1, gridNodeBase3);
						if (pathNodeHashes.Length > 0)
						{
							pathNodeHashes.InsertAbsolute(num2 + 1, HashNode(gridNodeBase3));
						}
						num++;
					}
					else
					{
						GridNodeBase gridNodeBase4 = gridNodeBase.GetNeighbourAlongDirection(direction2);
						if (gridNodeBase4 != null && ((traversalProvider != null) ? (!traversalProvider.CanTraverse(pathObject, gridNodeBase, gridNodeBase4)) : (!nnConstraint.Suitable(gridNodeBase4))))
						{
							gridNodeBase4 = null;
						}
						if (gridNodeBase4 == null || gridNodeBase4.GetNeighbourAlongDirection(direction) != gridNodeBase2 || (traversalProvider != null && !traversalProvider.CanTraverse(pathObject, gridNodeBase4, gridNodeBase2)))
						{
							throw new Exception("Axis-aligned connection not found");
						}
						path.InsertAbsolute(num2 + 1, gridNodeBase4);
						if (pathNodeHashes.Length > 0)
						{
							pathNodeHashes.InsertAbsolute(num2 + 1, HashNode(gridNodeBase4));
						}
						num++;
					}
				}
			}
			if (parts != null)
			{
				parts[partIndex].endIndex += num;
				for (int i = partIndex + 1; i < parts.Length; i++)
				{
					parts[i].startIndex += num;
					parts[i].endIndex += num;
				}
			}
		}

		private static PartGraphType PartGraphTypeFromNode(GraphNode node)
		{
			if (node == null)
			{
				return PartGraphType.Navmesh;
			}
			if (node is GridNodeBase)
			{
				return PartGraphType.Grid;
			}
			if (node is TriangleMeshNode)
			{
				return PartGraphType.Navmesh;
			}
			throw new Exception("The PathTracer (and by extension FollowerEntity component) cannot be used on graphs of type " + node.Graph.GetType().Name);
		}

		public void SetPath(ABPath path, NativeMovementPlane movementPlane)
		{
			List<Funnel.PathPart> list = Funnel.SplitIntoParts(path);
			nnConstraint.constrainTags = path.nnConstraint.constrainTags;
			nnConstraint.tags = path.nnConstraint.tags;
			nnConstraint.graphMask = path.nnConstraint.graphMask;
			nnConstraint.constrainWalkability = path.nnConstraint.constrainWalkability;
			nnConstraint.walkable = path.nnConstraint.walkable;
			SetPath(list, path.path, path.originalStartPoint, path.originalEndPoint, movementPlane, path.traversalProvider, path);
			ListPool<Funnel.PathPart>.Release(ref list);
		}

		public void SetPath(List<Funnel.PathPart> parts, List<GraphNode> nodes, Vector3 unclampedStartPoint, Vector3 unclampedEndPoint, NativeMovementPlane movementPlane, ITraversalProvider traversalProvider, Path path)
		{
			startNode = ((nodes.Count > 0) ? nodes[0] : null);
			partGraphType = PartGraphTypeFromNode(startNode);
			this.unclampedEndPoint = unclampedEndPoint;
			this.unclampedStartPoint = unclampedStartPoint;
			firstPartContainsDestroyedNodes = false;
			startIsUpToDate = true;
			endIsUpToDate = true;
			this.parts = parts.ToArray();
			this.nodes.Clear();
			this.nodes.AddRange(nodes);
			nodeHashes.Clear();
			for (int i = 0; i < nodes.Count; i++)
			{
				nodeHashes.PushEnd(HashNode(nodes[i]));
			}
			firstPartIndex = 0;
			if (partGraphType == PartGraphType.Grid)
			{
				RemoveGridPathDiagonals(this.parts, 0, ref this.nodes, ref nodeHashes, nnConstraint, traversalProvider, path);
			}
			SetFunnelState(this.parts[firstPartIndex]);
			version++;
			Repair(unclampedStartPoint, isStart: true, RepairQuality.Low, movementPlane, traversalProvider, path, allowCache: false);
			Repair(unclampedEndPoint, isStart: false, RepairQuality.Low, movementPlane, traversalProvider, path, allowCache: false);
		}

		public PathTracer Clone()
		{
			return new PathTracer
			{
				parts = ((parts != null) ? (parts.Clone() as Funnel.PathPart[]) : null),
				nodes = nodes.Clone(),
				portalIsNotInnerCorner = portalIsNotInnerCorner.Clone(),
				funnelState = funnelState.Clone(),
				unclampedEndPoint = unclampedEndPoint,
				unclampedStartPoint = unclampedStartPoint,
				startNodeInternal = startNodeInternal,
				firstPartIndex = firstPartIndex,
				startIsUpToDate = startIsUpToDate,
				endIsUpToDate = endIsUpToDate,
				firstPartContainsDestroyedNodes = firstPartContainsDestroyedNodes,
				version = version,
				nnConstraint = NNConstraint.Walkable,
				partGraphType = partGraphType
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool ContainsAndProject_0024BurstManaged(ref Int3 a, ref Int3 b, ref Int3 c, ref Vector3 p, float height, ref NativeMovementPlane movementPlane, out Vector3 projected)
		{
			int3 aWorld = (int3)a;
			int3 bWorld = (int3)b;
			int3 cWorld = (int3)c;
			int3 pWorld = (int3)(Int3)p;
			if (!Polygon.ContainsPoint(ref aWorld, ref bWorld, ref cWorld, ref pWorld, ref movementPlane))
			{
				projected = Vector3.zero;
				return false;
			}
			float3 a2 = (Vector3)a;
			float3 b2 = (Vector3)b;
			float3 c2 = (Vector3)c;
			float3 float5 = p;
			float num = math.lengthsq(Polygon.ClosestPointOnTriangle(a2, b2, c2, float5) - float5);
			float num2 = height * 0.5f;
			if (num >= num2 * num2)
			{
				projected = Vector3.zero;
				return false;
			}
			float3 up = movementPlane.ToWorld(float2.zero, 1f);
			projected = ProjectOnSurface(a2, b2, c2, float5, up);
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static float EstimateRemainingPath_0024BurstManaged(ref Funnel.FunnelState funnelState, ref Funnel.PathPart part, int maxCorners, ref NativeMovementPlane movementPlane)
		{
			NativeList<float3> nativeList = new NativeList<float3>(maxCorners, Allocator.Temp);
			NativeArray<int> nativeArray = new NativeArray<int>(maxCorners, Allocator.Temp);
			maxCorners--;
			maxCorners = math.max(0, math.min(maxCorners, funnelState.leftFunnel.Length));
			bool lastCorner;
			int numCorners = funnelState.CalculateNextCornerIndices(maxCorners, nativeArray, part.startPoint, part.endPoint, out lastCorner);
			funnelState.ConvertCornerIndicesToPath(nativeArray, numCorners, splitAtEveryPortal: false, part.startPoint, part.endPoint, lastCorner, nativeList);
			return RemainingDistanceLowerBound(nativeList.AsUnsafeSpan(), (float3)part.endPoint, in movementPlane);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static float RemainingDistanceLowerBound_0024BurstManaged(in UnsafeSpan<float3> nextCorners, in float3 endOfPart, in NativeMovementPlane movementPlane)
		{
			if (nextCorners.Length == 0)
			{
				return 0f;
			}
			float3 float5 = nextCorners[0];
			float num = 0f;
			for (int i = 1; i < nextCorners.Length; i++)
			{
				float3 float6 = nextCorners[i];
				num += math.length(movementPlane.ToPlane(float6 - float5));
				float5 = float6;
			}
			return num + math.length(movementPlane.ToPlane(float5 - endOfPart));
		}
	}
}
