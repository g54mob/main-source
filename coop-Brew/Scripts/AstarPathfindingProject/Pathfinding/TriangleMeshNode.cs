using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public sealed class TriangleMeshNode : MeshNode
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void InterpolateEdge_0000075F_0024PostfixBurstDelegate(ref Int3 p1, ref Int3 p2, uint fractionAlongEdge, out Int3 pos);

		internal static class InterpolateEdge_0000075F_0024BurstDirectCall
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

			public static void Invoke(ref Int3 p1, ref Int3 p2, uint fractionAlongEdge, out Int3 pos)
			{
				pos = default(Int3);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OpenSingleEdgeBurst_00000764_0024PostfixBurstDelegate(ref Int3 s1, ref Int3 s2, ref Int3 pos, ushort pathID, uint pathNodeIndex, uint candidatePathNodeIndex, uint candidateNodeIndex, uint candidateG, ref UnsafeSpan<PathNode> pathNodes, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective);

		internal static class OpenSingleEdgeBurst_00000764_0024BurstDirectCall
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

			public static void Invoke(ref Int3 s1, ref Int3 s2, ref Int3 pos, ushort pathID, uint pathNodeIndex, uint candidatePathNodeIndex, uint candidateNodeIndex, uint candidateG, ref UnsafeSpan<PathNode> pathNodes, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void CalculateBestEdgePosition_00000765_0024PostfixBurstDelegate(ref Int3 s1, ref Int3 s2, ref Int3 pos, out int3 closestPointAlongEdge, out uint quantizedFractionAlongEdge, out uint cost);

		internal static class CalculateBestEdgePosition_00000765_0024BurstDirectCall
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

			public static void Invoke(ref Int3 s1, ref Int3 s2, ref Int3 pos, out int3 closestPointAlongEdge, out uint quantizedFractionAlongEdge, out uint cost)
			{
				closestPointAlongEdge = default(int3);
				quantizedFractionAlongEdge = default(uint);
				cost = default(uint);
			}
		}

		public const bool InaccuratePathSearch = false;

		public int v0;

		public int v1;

		public int v2;

		private static INavmeshHolder[] _navmeshHolders;

		private static readonly object lockObject;

		public static readonly ProfilerMarker MarkerDecode;

		public static readonly ProfilerMarker MarkerGetVertices;

		public static readonly ProfilerMarker MarkerClosest;

		internal override int PathNodeVariants => 0;

		public int TileIndex => 0;

		public TriangleMeshNode()
		{
		}

		public TriangleMeshNode(AstarPath astar)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static INavmeshHolder GetNavmeshHolder(uint graphIndex)
		{
			return null;
		}

		public static void SetNavmeshHolder(int graphIndex, INavmeshHolder graph)
		{
		}

		public static void ClearNavmeshHolder(int graphIndex, INavmeshHolder graph)
		{
		}

		public void UpdatePositionFromVertices()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public int GetVertexIndex(int i)
		{
			return 0;
		}

		public int GetVertexArrayIndex(int i)
		{
			return 0;
		}

		public void GetVertices(out Int3 v0, out Int3 v1, out Int3 v2)
		{
			v0 = default(Int3);
			v1 = default(Int3);
			v2 = default(Int3);
		}

		public void GetVerticesInGraphSpace(out Int3 v0, out Int3 v1, out Int3 v2)
		{
			v0 = default(Int3);
			v1 = default(Int3);
			v2 = default(Int3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[IgnoredByDeepProfiler]
		public override Int3 GetVertex(int i)
		{
			return default(Int3);
		}

		public Int3 GetVertexInGraphSpace(int i)
		{
			return default(Int3);
		}

		public override int GetVertexCount()
		{
			return 0;
		}

		public Vector3 ProjectOnSurface(Vector3 point)
		{
			return default(Vector3);
		}

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			return default(Vector3);
		}

		internal Int3 ClosestPointOnNodeXZInGraphSpace(Vector3 p)
		{
			return default(Int3);
		}

		public override Vector3 ClosestPointOnNodeXZ(Vector3 p)
		{
			return default(Vector3);
		}

		public override bool ContainsPoint(Vector3 p)
		{
			return false;
		}

		public bool ContainsPoint(Vector3 p, NativeMovementPlane movementPlane)
		{
			return false;
		}

		public override bool ContainsPointInGraphSpace(Int3 p)
		{
			return false;
		}

		public override Int3 DecodeVariantPosition(uint pathNodeIndex, uint fractionAlongEdge)
		{
			return default(Int3);
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		[MonoPInvokeCallback(typeof(InterpolateEdge_0000075F_0024PostfixBurstDelegate))]
		private static void InterpolateEdge(ref Int3 p1, ref Int3 p2, uint fractionAlongEdge, out Int3 pos)
		{
			pos = default(Int3);
		}

		public override void OpenAtPoint(Path path, uint pathNodeIndex, Int3 point, uint gScore)
		{
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
		}

		private void OpenAtPoint(Path path, uint pathNodeIndex, Int3 pos, int edge, uint gScore)
		{
		}

		private void OpenSingleEdge(Path path, uint pathNodeIndex, TriangleMeshNode other, int sharedEdgeOnOtherNode, Int3 pos, uint gScore)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(OpenSingleEdgeBurst_00000764_0024PostfixBurstDelegate))]
		private static void OpenSingleEdgeBurst(ref Int3 s1, ref Int3 s2, ref Int3 pos, ushort pathID, uint pathNodeIndex, uint candidatePathNodeIndex, uint candidateNodeIndex, uint candidateG, ref UnsafeSpan<PathNode> pathNodes, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(CalculateBestEdgePosition_00000765_0024PostfixBurstDelegate))]
		private static void CalculateBestEdgePosition(ref Int3 s1, ref Int3 s2, ref Int3 pos, out int3 closestPointAlongEdge, out uint quantizedFractionAlongEdge, out uint cost)
		{
			closestPointAlongEdge = default(int3);
			quantizedFractionAlongEdge = default(uint);
			cost = default(uint);
		}

		public int SharedEdge(GraphNode other)
		{
			return 0;
		}

		public override bool GetPortal(GraphNode toNode, out Vector3 left, out Vector3 right)
		{
			left = default(Vector3);
			right = default(Vector3);
			return false;
		}

		public bool GetPortalInGraphSpace(TriangleMeshNode toNode, out Int3 a, out Int3 b, out int aIndex, out int bIndex)
		{
			a = default(Int3);
			b = default(Int3);
			aIndex = default(int);
			bIndex = default(int);
			return false;
		}

		public bool GetPortal(GraphNode toNode, out Vector3 left, out Vector3 right, out int aIndex, out int bIndex)
		{
			left = default(Vector3);
			right = default(Vector3);
			aIndex = default(int);
			bIndex = default(int);
			return false;
		}

		public override float SurfaceArea()
		{
			return 0f;
		}

		public override Vector3 RandomPointOnSurface()
		{
			return default(Vector3);
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(FloatMode = FloatMode.Fast)]
		internal static void InterpolateEdge_0024BurstManaged(ref Int3 p1, ref Int3 p2, uint fractionAlongEdge, out Int3 pos)
		{
			pos = default(Int3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void OpenSingleEdgeBurst_0024BurstManaged(ref Int3 s1, ref Int3 s2, ref Int3 pos, ushort pathID, uint pathNodeIndex, uint candidatePathNodeIndex, uint candidateNodeIndex, uint candidateG, ref UnsafeSpan<PathNode> pathNodes, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void CalculateBestEdgePosition_0024BurstManaged(ref Int3 s1, ref Int3 s2, ref Int3 pos, out int3 closestPointAlongEdge, out uint quantizedFractionAlongEdge, out uint cost)
		{
			closestPointAlongEdge = default(int3);
			quantizedFractionAlongEdge = default(uint);
			cost = default(uint);
		}
	}
}
