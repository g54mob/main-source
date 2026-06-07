using System;
using System.Runtime.CompilerServices;
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
		public delegate void InterpolateEdge_0000075A_0024PostfixBurstDelegate(ref Int3 p1, ref Int3 p2, uint fractionAlongEdge, out Int3 pos);

		internal static class InterpolateEdge_0000075A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(InterpolateEdge_0000075A_0024PostfixBurstDelegate).TypeHandle);
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

			static InterpolateEdge_0000075A_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref Int3 p1, ref Int3 p2, uint fractionAlongEdge, out Int3 pos)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref Int3, ref Int3, uint, ref Int3, void>)functionPointer)(ref p1, ref p2, fractionAlongEdge, ref pos);
						return;
					}
				}
				InterpolateEdge_0024BurstManaged(ref p1, ref p2, fractionAlongEdge, out pos);
			}
		}

		public delegate void OpenSingleEdgeBurst_0000075F_0024PostfixBurstDelegate(ref Int3 s1, ref Int3 s2, ref Int3 pos, ushort pathID, uint pathNodeIndex, uint candidatePathNodeIndex, uint candidateNodeIndex, uint candidateG, ref UnsafeSpan<PathNode> pathNodes, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective);

		internal static class OpenSingleEdgeBurst_0000075F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(OpenSingleEdgeBurst_0000075F_0024PostfixBurstDelegate).TypeHandle);
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

			static OpenSingleEdgeBurst_0000075F_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref Int3 s1, ref Int3 s2, ref Int3 pos, ushort pathID, uint pathNodeIndex, uint candidatePathNodeIndex, uint candidateNodeIndex, uint candidateG, ref UnsafeSpan<PathNode> pathNodes, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref Int3, ref Int3, ref Int3, ushort, uint, uint, uint, uint, ref UnsafeSpan<PathNode>, ref BinaryHeap, ref HeuristicObjective, void>)functionPointer)(ref s1, ref s2, ref pos, pathID, pathNodeIndex, candidatePathNodeIndex, candidateNodeIndex, candidateG, ref pathNodes, ref heap, ref heuristicObjective);
						return;
					}
				}
				OpenSingleEdgeBurst_0024BurstManaged(ref s1, ref s2, ref pos, pathID, pathNodeIndex, candidatePathNodeIndex, candidateNodeIndex, candidateG, ref pathNodes, ref heap, ref heuristicObjective);
			}
		}

		public delegate void CalculateBestEdgePosition_00000760_0024PostfixBurstDelegate(ref Int3 s1, ref Int3 s2, ref Int3 pos, out int3 closestPointAlongEdge, out uint quantizedFractionAlongEdge, out uint cost);

		internal static class CalculateBestEdgePosition_00000760_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(CalculateBestEdgePosition_00000760_0024PostfixBurstDelegate).TypeHandle);
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

			static CalculateBestEdgePosition_00000760_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref Int3 s1, ref Int3 s2, ref Int3 pos, out int3 closestPointAlongEdge, out uint quantizedFractionAlongEdge, out uint cost)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref Int3, ref Int3, ref Int3, ref int3, ref uint, ref uint, void>)functionPointer)(ref s1, ref s2, ref pos, ref closestPointAlongEdge, ref quantizedFractionAlongEdge, ref cost);
						return;
					}
				}
				CalculateBestEdgePosition_0024BurstManaged(ref s1, ref s2, ref pos, out closestPointAlongEdge, out quantizedFractionAlongEdge, out cost);
			}
		}

		public const bool InaccuratePathSearch = false;

		public int v0;

		public int v1;

		public int v2;

		private static INavmeshHolder[] _navmeshHolders = new INavmeshHolder[0];

		private static readonly object lockObject = new object();

		public static readonly ProfilerMarker MarkerDecode = new ProfilerMarker("Decode");

		public static readonly ProfilerMarker MarkerGetVertices = new ProfilerMarker("GetVertex");

		public static readonly ProfilerMarker MarkerClosest = new ProfilerMarker("MarkerClosest");

		internal override int PathNodeVariants => 3;

		public int TileIndex => (v0 >> 12) & 0x7FFFF;

		public TriangleMeshNode()
		{
			base.HierarchicalNodeIndex = 0;
			base.NodeIndex = 268435454u;
		}

		public TriangleMeshNode(AstarPath astar)
		{
			astar.InitializeNode(this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static INavmeshHolder GetNavmeshHolder(uint graphIndex)
		{
			return _navmeshHolders[graphIndex];
		}

		public static void SetNavmeshHolder(int graphIndex, INavmeshHolder graph)
		{
			lock (lockObject)
			{
				if (graphIndex >= _navmeshHolders.Length)
				{
					INavmeshHolder[] array = new INavmeshHolder[graphIndex + 1];
					_navmeshHolders.CopyTo(array, 0);
					_navmeshHolders = array;
				}
				_navmeshHolders[graphIndex] = graph;
			}
		}

		public static void ClearNavmeshHolder(int graphIndex, INavmeshHolder graph)
		{
			lock (lockObject)
			{
				if (graphIndex < _navmeshHolders.Length && _navmeshHolders[graphIndex] == graph)
				{
					_navmeshHolders[graphIndex] = null;
				}
			}
		}

		public void UpdatePositionFromVertices()
		{
			GetVertices(out var int5, out var int6, out var int7);
			position = (int5 + int6 + int7) * 0.333333f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetVertexIndex(int i)
		{
			return i switch
			{
				1 => v1, 
				0 => v0, 
				_ => v2, 
			};
		}

		public int GetVertexArrayIndex(int i)
		{
			return GetNavmeshHolder(base.GraphIndex).GetVertexArrayIndex(i switch
			{
				1 => v1, 
				0 => v0, 
				_ => v2, 
			});
		}

		public void GetVertices(out Int3 v0, out Int3 v1, out Int3 v2)
		{
			INavmeshHolder navmeshHolder = GetNavmeshHolder(base.GraphIndex);
			v0 = navmeshHolder.GetVertex(this.v0);
			v1 = navmeshHolder.GetVertex(this.v1);
			v2 = navmeshHolder.GetVertex(this.v2);
		}

		public void GetVerticesInGraphSpace(out Int3 v0, out Int3 v1, out Int3 v2)
		{
			INavmeshHolder navmeshHolder = GetNavmeshHolder(base.GraphIndex);
			v0 = navmeshHolder.GetVertexInGraphSpace(this.v0);
			v1 = navmeshHolder.GetVertexInGraphSpace(this.v1);
			v2 = navmeshHolder.GetVertexInGraphSpace(this.v2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override Int3 GetVertex(int i)
		{
			return GetNavmeshHolder(base.GraphIndex).GetVertex(GetVertexIndex(i));
		}

		public Int3 GetVertexInGraphSpace(int i)
		{
			return GetNavmeshHolder(base.GraphIndex).GetVertexInGraphSpace(GetVertexIndex(i));
		}

		public override int GetVertexCount()
		{
			return 3;
		}

		public Vector3 ProjectOnSurface(Vector3 point)
		{
			GetVertices(out var int5, out var int6, out var int7);
			Vector3 vector = (Vector3)int5;
			Vector3 vector2 = (Vector3)int6;
			Vector3 normalized = Vector3.Cross(rhs: (Vector3)int7 - vector, lhs: vector2 - vector).normalized;
			return point - normalized * Vector3.Dot(normalized, point - vector);
		}

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			GetVertices(out var int5, out var int6, out var int7);
			return Polygon.ClosestPointOnTriangle((float3)(Vector3)int5, (float3)(Vector3)int6, (float3)(Vector3)int7, (float3)p);
		}

		internal Int3 ClosestPointOnNodeXZInGraphSpace(Vector3 p)
		{
			GetVerticesInGraphSpace(out var int5, out var int6, out var int7);
			p = GetNavmeshHolder(base.GraphIndex).transform.InverseTransform(p);
			Int3 int8 = (Int3)Polygon.ClosestPointOnTriangleXZ((Vector3)int5, (Vector3)int6, (Vector3)int7, p);
			if (ContainsPointInGraphSpace(int8))
			{
				return int8;
			}
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if (i != 0 || j != 0)
					{
						Int3 int9 = new Int3(int8.x + i, int8.y, int8.z + j);
						if (ContainsPointInGraphSpace(int9))
						{
							return int9;
						}
					}
				}
			}
			long sqrMagnitudeLong = (int5 - int8).sqrMagnitudeLong;
			long sqrMagnitudeLong2 = (int6 - int8).sqrMagnitudeLong;
			long sqrMagnitudeLong3 = (int7 - int8).sqrMagnitudeLong;
			if (sqrMagnitudeLong >= sqrMagnitudeLong2)
			{
				if (sqrMagnitudeLong2 >= sqrMagnitudeLong3)
				{
					return int7;
				}
				return int6;
			}
			if (sqrMagnitudeLong >= sqrMagnitudeLong3)
			{
				return int7;
			}
			return int5;
		}

		public override Vector3 ClosestPointOnNodeXZ(Vector3 p)
		{
			GetVertices(out var int5, out var int6, out var int7);
			return Polygon.ClosestPointOnTriangleXZ((Vector3)int5, (Vector3)int6, (Vector3)int7, p);
		}

		public override bool ContainsPoint(Vector3 p)
		{
			return ContainsPointInGraphSpace((Int3)GetNavmeshHolder(base.GraphIndex).transform.InverseTransform(p));
		}

		public bool ContainsPoint(Vector3 p, NativeMovementPlane movementPlane)
		{
			GetVertices(out var int5, out var int6, out var int7);
			int3 aWorld = (int3)int5;
			int3 bWorld = (int3)int6;
			int3 cWorld = (int3)int7;
			int3 pWorld = (int3)(Int3)p;
			return Polygon.ContainsPoint(ref aWorld, ref bWorld, ref cWorld, ref pWorld, ref movementPlane);
		}

		public override bool ContainsPointInGraphSpace(Int3 p)
		{
			GetVerticesInGraphSpace(out var int5, out var int6, out var int7);
			if ((long)(int6.x - int5.x) * (long)(p.z - int5.z) - (long)(p.x - int5.x) * (long)(int6.z - int5.z) > 0)
			{
				return false;
			}
			if ((long)(int7.x - int6.x) * (long)(p.z - int6.z) - (long)(p.x - int6.x) * (long)(int7.z - int6.z) > 0)
			{
				return false;
			}
			if ((long)(int5.x - int7.x) * (long)(p.z - int7.z) - (long)(p.x - int7.x) * (long)(int5.z - int7.z) > 0)
			{
				return false;
			}
			return true;
		}

		public override Int3 DecodeVariantPosition(uint pathNodeIndex, uint fractionAlongEdge)
		{
			int num = (int)(pathNodeIndex - base.NodeIndex);
			Int3 p = GetVertex(num);
			Int3 p2 = GetVertex((num + 1) % 3);
			InterpolateEdge(ref p, ref p2, fractionAlongEdge, out var pos);
			return pos;
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		private static void InterpolateEdge(ref Int3 p1, ref Int3 p2, uint fractionAlongEdge, out Int3 pos)
		{
			InterpolateEdge_0000075A_0024BurstDirectCall.Invoke(ref p1, ref p2, fractionAlongEdge, out pos);
		}

		public override void OpenAtPoint(Path path, uint pathNodeIndex, Int3 point, uint gScore)
		{
			OpenAtPoint(path, pathNodeIndex, point, -1, gScore);
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
			PathHandler pathHandler = ((IPathInternals)path).PathHandler;
			int edge = (int)(pathNodeIndex - base.NodeIndex);
			OpenAtPoint(path, pathNodeIndex, DecodeVariantPosition(pathNodeIndex, pathHandler.pathNodes[pathNodeIndex].fractionAlongEdge), edge, gScore);
		}

		private void OpenAtPoint(Path path, uint pathNodeIndex, Int3 pos, int edge, uint gScore)
		{
			PathHandler pathHandler = ((IPathInternals)path).PathHandler;
			PathNode pathNode = pathHandler.pathNodes[pathNodeIndex];
			if (pathNode.flag1)
			{
				path.OpenCandidateConnectionsToEndNode(pos, pathNodeIndex, base.NodeIndex, gScore);
			}
			int num = 0;
			bool flag = pathNode.parentIndex >= base.NodeIndex && pathNode.parentIndex < base.NodeIndex + 3;
			if (connections == null)
			{
				return;
			}
			for (int num2 = connections.Length - 1; num2 >= 0; num2--)
			{
				Connection connection = connections[num2];
				if (connection.isOutgoing)
				{
					GraphNode node = connection.node;
					if (connection.isEdgeShared)
					{
						int adjacentShapeEdge = connection.adjacentShapeEdge;
						uint num3 = node.NodeIndex + (uint)adjacentShapeEdge;
						if (num3 != pathNode.parentIndex)
						{
							if (connection.shapeEdge == edge)
							{
								if (path.CanTraverse(this, node))
								{
									TriangleMeshNode triangleMeshNode = node as TriangleMeshNode;
									if (path.ShouldConsiderPathNode(num3))
									{
										if (connection.edgesAreIdentical)
										{
											uint traversalCost = path.GetTraversalCost(node);
											ref PathNode reference = ref pathHandler.pathNodes[num3];
											reference.pathID = path.pathID;
											reference.heapIndex = ushort.MaxValue;
											reference.parentIndex = pathNodeIndex;
											reference.fractionAlongEdge = PathNode.ReverseFractionAlongEdge(pathNode.fractionAlongEdge);
											path.OnVisitNode(num3, uint.MaxValue, gScore + traversalCost);
											pathHandler.LogVisitedNode(num3, uint.MaxValue, gScore + traversalCost);
											triangleMeshNode.OpenAtPoint(path, num3, pos, adjacentShapeEdge, gScore + traversalCost);
										}
										else
										{
											OpenSingleEdge(path, pathNodeIndex, triangleMeshNode, adjacentShapeEdge, pos, gScore);
										}
									}
								}
							}
							else if (!flag && (num & (1 << connection.shapeEdge)) == 0)
							{
								num |= 1 << connection.shapeEdge;
								OpenSingleEdge(path, pathNodeIndex, this, connection.shapeEdge, pos, gScore);
							}
						}
					}
					else if (!flag && path.CanTraverse(this, node) && path.ShouldConsiderPathNode(node.NodeIndex))
					{
						uint costMagnitude = (uint)(node.position - pos).costMagnitude;
						if (edge != -1)
						{
							path.OpenCandidateConnection(pathNodeIndex, node.NodeIndex, gScore, costMagnitude, 0u, node.position);
						}
						else
						{
							uint num4 = pathHandler.AddTemporaryNode(new TemporaryNode
							{
								associatedNode = base.NodeIndex,
								position = pos,
								targetIndex = 0,
								type = TemporaryNodeType.Ignore
							});
							ref PathNode reference2 = ref pathHandler.pathNodes[num4];
							reference2.pathID = path.pathID;
							reference2.parentIndex = pathNodeIndex;
							path.OpenCandidateConnection(num4, node.NodeIndex, gScore, costMagnitude, 0u, node.position);
						}
					}
				}
			}
		}

		private void OpenSingleEdge(Path path, uint pathNodeIndex, TriangleMeshNode other, int sharedEdgeOnOtherNode, Int3 pos, uint gScore)
		{
			uint num = other.NodeIndex + (uint)sharedEdgeOnOtherNode;
			if (path.ShouldConsiderPathNode(num))
			{
				Int3 s = other.GetVertex(sharedEdgeOnOtherNode);
				Int3 s2 = other.GetVertex((sharedEdgeOnOtherNode + 1) % 3);
				PathHandler pathHandler = ((IPathInternals)path).PathHandler;
				uint traversalCost = path.GetTraversalCost(other);
				uint candidateG = gScore + traversalCost;
				OpenSingleEdgeBurst(ref s, ref s2, ref pos, path.pathID, pathNodeIndex, num, other.NodeIndex, candidateG, ref pathHandler.pathNodes, ref pathHandler.heap, ref path.heuristicObjectiveInternal);
			}
		}

		[BurstCompile]
		private static void OpenSingleEdgeBurst(ref Int3 s1, ref Int3 s2, ref Int3 pos, ushort pathID, uint pathNodeIndex, uint candidatePathNodeIndex, uint candidateNodeIndex, uint candidateG, ref UnsafeSpan<PathNode> pathNodes, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
		{
			OpenSingleEdgeBurst_0000075F_0024BurstDirectCall.Invoke(ref s1, ref s2, ref pos, pathID, pathNodeIndex, candidatePathNodeIndex, candidateNodeIndex, candidateG, ref pathNodes, ref heap, ref heuristicObjective);
		}

		[BurstCompile]
		private static void CalculateBestEdgePosition(ref Int3 s1, ref Int3 s2, ref Int3 pos, out int3 closestPointAlongEdge, out uint quantizedFractionAlongEdge, out uint cost)
		{
			CalculateBestEdgePosition_00000760_0024BurstDirectCall.Invoke(ref s1, ref s2, ref pos, out closestPointAlongEdge, out quantizedFractionAlongEdge, out cost);
		}

		public int SharedEdge(GraphNode other)
		{
			int result = -1;
			if (connections != null)
			{
				for (int i = 0; i < connections.Length; i++)
				{
					if (connections[i].node == other && connections[i].isEdgeShared)
					{
						result = connections[i].shapeEdge;
					}
				}
			}
			return result;
		}

		public override bool GetPortal(GraphNode toNode, out Vector3 left, out Vector3 right)
		{
			int aIndex;
			int bIndex;
			return GetPortal(toNode, out left, out right, out aIndex, out bIndex);
		}

		public bool GetPortalInGraphSpace(TriangleMeshNode toNode, out Int3 a, out Int3 b, out int aIndex, out int bIndex)
		{
			aIndex = -1;
			bIndex = -1;
			a = Int3.zero;
			b = Int3.zero;
			if (toNode.GraphIndex != base.GraphIndex)
			{
				return false;
			}
			int num = -1;
			int num2 = -1;
			if (connections != null)
			{
				for (int i = 0; i < connections.Length; i++)
				{
					if (connections[i].node == toNode && connections[i].isEdgeShared)
					{
						num = connections[i].shapeEdge;
						num2 = connections[i].adjacentShapeEdge;
					}
				}
			}
			if (num == -1)
			{
				return false;
			}
			aIndex = num;
			bIndex = (num + 1) % 3;
			INavmeshHolder navmeshHolder = GetNavmeshHolder(base.GraphIndex);
			a = navmeshHolder.GetVertexInGraphSpace(GetVertexIndex(aIndex));
			b = navmeshHolder.GetVertexInGraphSpace(GetVertexIndex(bIndex));
			int tileIndex = TileIndex;
			int tileIndex2 = toNode.TileIndex;
			if (tileIndex != tileIndex2)
			{
				Int3 vertexInGraphSpace = toNode.GetVertexInGraphSpace(num2);
				Int3 vertexInGraphSpace2 = toNode.GetVertexInGraphSpace((num2 + 1) % 3);
				navmeshHolder.GetTileCoordinates(tileIndex, out var x, out var _);
				navmeshHolder.GetTileCoordinates(tileIndex2, out var x2, out var _);
				int i2 = ((x != x2) ? 2 : 0);
				int min = Mathf.Min(vertexInGraphSpace[i2], vertexInGraphSpace2[i2]);
				int max = Mathf.Max(vertexInGraphSpace[i2], vertexInGraphSpace2[i2]);
				a[i2] = Mathf.Clamp(a[i2], min, max);
				b[i2] = Mathf.Clamp(b[i2], min, max);
			}
			return true;
		}

		public bool GetPortal(GraphNode toNode, out Vector3 left, out Vector3 right, out int aIndex, out int bIndex)
		{
			if (toNode is TriangleMeshNode toNode2 && GetPortalInGraphSpace(toNode2, out var a, out var b, out aIndex, out bIndex))
			{
				INavmeshHolder navmeshHolder = GetNavmeshHolder(base.GraphIndex);
				left = navmeshHolder.transform.Transform((Vector3)a);
				right = navmeshHolder.transform.Transform((Vector3)b);
				return true;
			}
			aIndex = -1;
			bIndex = -1;
			left = Vector3.zero;
			right = Vector3.zero;
			return false;
		}

		public override float SurfaceArea()
		{
			INavmeshHolder navmeshHolder = GetNavmeshHolder(base.GraphIndex);
			return (float)Math.Abs(VectorMath.SignedTriangleAreaTimes2XZ(navmeshHolder.GetVertex(v0), navmeshHolder.GetVertex(v1), navmeshHolder.GetVertex(v2))) * 0.5f;
		}

		public override Vector3 RandomPointOnSurface()
		{
			float2 float5;
			do
			{
				float5 = AstarMath.ThreadSafeRandomFloat2();
			}
			while (float5.x + float5.y > 1f);
			GetVertices(out var int5, out var int6, out var int7);
			return (Vector3)(int6 - int5) * float5.x + (Vector3)(int7 - int5) * float5.y + (Vector3)int5;
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
			base.SerializeNode(ctx);
			ctx.writer.Write(v0);
			ctx.writer.Write(v1);
			ctx.writer.Write(v2);
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
			base.DeserializeNode(ctx);
			v0 = ctx.reader.ReadInt32();
			v1 = ctx.reader.ReadInt32();
			v2 = ctx.reader.ReadInt32();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public static void InterpolateEdge_0024BurstManaged(ref Int3 p1, ref Int3 p2, uint fractionAlongEdge, out Int3 pos)
		{
			int3 int5 = (int3)math.lerp((int3)p1, (int3)p2, PathNode.UnQuantizeFractionAlongEdge(fractionAlongEdge));
			pos = new Int3(int5.x, int5.y, int5.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void OpenSingleEdgeBurst_0024BurstManaged(ref Int3 s1, ref Int3 s2, ref Int3 pos, ushort pathID, uint pathNodeIndex, uint candidatePathNodeIndex, uint candidateNodeIndex, uint candidateG, ref UnsafeSpan<PathNode> pathNodes, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
		{
			CalculateBestEdgePosition(ref s1, ref s2, ref pos, out var closestPointAlongEdge, out var quantizedFractionAlongEdge, out var cost);
			candidateG += cost;
			Path.OpenCandidateParams pars = new Path.OpenCandidateParams
			{
				pathID = pathID,
				parentPathNode = pathNodeIndex,
				targetPathNode = candidatePathNodeIndex,
				targetNodeIndex = candidateNodeIndex,
				candidateG = candidateG,
				fractionAlongEdge = quantizedFractionAlongEdge,
				targetNodePosition = closestPointAlongEdge,
				pathNodes = pathNodes
			};
			Path.OpenCandidateConnectionBurst(ref pars, ref heap, ref heuristicObjective);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void CalculateBestEdgePosition_0024BurstManaged(ref Int3 s1, ref Int3 s2, ref Int3 pos, out int3 closestPointAlongEdge, out uint quantizedFractionAlongEdge, out uint cost)
		{
			float3 obj = (int3)s1;
			float3 float5 = (int3)s2;
			int3 int5 = (int3)pos;
			float v = math.clamp(VectorMath.ClosestPointOnLineFactor(obj, float5, int5), 0f, 1f);
			quantizedFractionAlongEdge = PathNode.QuantizeFractionAlongEdge(v);
			v = PathNode.UnQuantizeFractionAlongEdge(quantizedFractionAlongEdge);
			float3 float6 = math.lerp(obj, float5, v);
			closestPointAlongEdge = (int3)float6;
			int3 int6 = int5 - closestPointAlongEdge;
			cost = (uint)new Int3(int6.x, int6.y, int6.z).costMagnitude;
		}
	}
}
