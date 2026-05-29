using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.RVO
{
	[BurstCompile]
	public static class RVOObstacleCache
	{
		public struct ObstacleSegment
		{
			public float3 vertex1;

			public float3 vertex2;

			public int vertex1LinkId;

			public int vertex2LinkId;
		}

		public unsafe delegate void TraceContours_00000F0E_0024PostfixBurstDelegate(ref UnsafeSpan<ObstacleSegment> obstaclesSpan, ref NativeMovementPlane movementPlane, int obstacleId, UnmanagedObstacle* outputObstacles, ref SlabAllocator<float3> verticesAllocator, ref SlabAllocator<ObstacleVertexGroup> obstaclesAllocator, ref SpinLock spinLock, bool simplifyObstacles);

		internal static class TraceContours_00000F0E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(TraceContours_00000F0E_0024PostfixBurstDelegate).TypeHandle);
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

			static TraceContours_00000F0E_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref UnsafeSpan<ObstacleSegment> obstaclesSpan, ref NativeMovementPlane movementPlane, int obstacleId, UnmanagedObstacle* outputObstacles, ref SlabAllocator<float3> verticesAllocator, ref SlabAllocator<ObstacleVertexGroup> obstaclesAllocator, ref SpinLock spinLock, bool simplifyObstacles)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref UnsafeSpan<ObstacleSegment>, ref NativeMovementPlane, int, UnmanagedObstacle*, ref SlabAllocator<float3>, ref SlabAllocator<ObstacleVertexGroup>, ref SpinLock, bool, void>)functionPointer)(ref obstaclesSpan, ref movementPlane, obstacleId, outputObstacles, ref verticesAllocator, ref obstaclesAllocator, ref spinLock, simplifyObstacles);
						return;
					}
				}
				TraceContours_0024BurstManaged(ref obstaclesSpan, ref movementPlane, obstacleId, outputObstacles, ref verticesAllocator, ref obstaclesAllocator, ref spinLock, simplifyObstacles);
			}
		}

		private static readonly ProfilerMarker MarkerAllocate = new ProfilerMarker("Allocate");

		private static ulong HashKey(GraphNode sourceNode, int traversableTags, SimpleMovementPlane movementPlane)
		{
			return (((((((ulong)((((long)sourceNode.NodeIndex * 786433L) ^ traversableTags) * 786433) ^ (ulong)(movementPlane.rotation.x * 4f)) * 786433) ^ (ulong)(movementPlane.rotation.y * 4f)) * 786433) ^ (ulong)(movementPlane.rotation.z * 4f)) * 786433) ^ (ulong)(movementPlane.rotation.w * 4f);
		}

		public unsafe static void CollectContours(List<GraphNode> nodes, NativeList<ObstacleSegment> obstacles)
		{
			if (nodes.Count == 0)
			{
				return;
			}
			if (nodes[0] is TriangleMeshNode)
			{
				for (int i = 0; i < nodes.Count; i++)
				{
					TriangleMeshNode triangleMeshNode = nodes[i] as TriangleMeshNode;
					int num = 0;
					if (triangleMeshNode.connections != null)
					{
						for (int j = 0; j < triangleMeshNode.connections.Length; j++)
						{
							Connection connection = triangleMeshNode.connections[j];
							if (connection.isEdgeShared)
							{
								num |= 1 << connection.shapeEdge;
							}
						}
					}
					triangleMeshNode.GetVertices(out var v, out var v2, out var v3);
					for (int k = 0; k < 3; k++)
					{
						if ((num & (1 << k)) == 0)
						{
							Int3 int5;
							Int3 int6;
							switch (k)
							{
							case 0:
								int5 = v;
								int6 = v2;
								break;
							case 1:
								int5 = v2;
								int6 = v3;
								break;
							default:
								int5 = v3;
								int6 = v;
								break;
							}
							int hashCode = int5.GetHashCode();
							int hashCode2 = int6.GetHashCode();
							ObstacleSegment value = new ObstacleSegment
							{
								vertex1 = (Vector3)int5,
								vertex2 = (Vector3)int6,
								vertex1LinkId = hashCode,
								vertex2LinkId = hashCode2
							};
							obstacles.Add(in value);
						}
					}
				}
			}
			else
			{
				if (!(nodes[0] is GridNodeBase))
				{
					return;
				}
				GridGraph gridGraph = ((!(nodes[0] is LevelGridNode)) ? GridNode.GetGridGraph(nodes[0].GraphIndex) : LevelGridNode.GetGridGraph(nodes[0].GraphIndex));
				Vector3* ptr = stackalloc Vector3[4];
				for (int l = 0; l < 4; l++)
				{
					int num2 = (l + 1) % 4;
					ptr[l] = gridGraph.transform.TransformVector(0.5f * new Vector3(GridGraph.neighbourXOffsets[l] + GridGraph.neighbourXOffsets[num2], 0f, GridGraph.neighbourZOffsets[l] + GridGraph.neighbourZOffsets[num2]));
				}
				for (int m = 0; m < nodes.Count; m++)
				{
					GridNodeBase gridNodeBase = nodes[m] as GridNodeBase;
					if (gridNodeBase.HasConnectionsToAllAxisAlignedNeighbours)
					{
						continue;
					}
					for (int n = 0; n < 4; n++)
					{
						if (gridNodeBase.HasConnectionInDirection(n))
						{
							continue;
						}
						int direction = (n + 1) % 4;
						int num3 = (n - 1 + 4) % 4;
						GridNodeBase neighbourAlongDirection = gridNodeBase.GetNeighbourAlongDirection(direction);
						GridNodeBase neighbourAlongDirection2 = gridNodeBase.GetNeighbourAlongDirection(num3);
						uint vertex1LinkId;
						if (neighbourAlongDirection != null)
						{
							GridNodeBase neighbourAlongDirection3 = neighbourAlongDirection.GetNeighbourAlongDirection(n);
							if (neighbourAlongDirection3 != null)
							{
								uint a = gridNodeBase.NodeIndex;
								uint b = neighbourAlongDirection.NodeIndex;
								uint b2 = neighbourAlongDirection3.NodeIndex;
								if (a > b)
								{
									Memory.Swap(ref a, ref b);
								}
								if (b > b2)
								{
									Memory.Swap(ref b, ref b2);
								}
								if (a > b)
								{
									Memory.Swap(ref a, ref b);
								}
								vertex1LinkId = math.hash(new uint3(a, b, b2));
							}
							else
							{
								uint a2 = gridNodeBase.NodeIndex;
								uint b3 = neighbourAlongDirection.NodeIndex;
								if (a2 > b3)
								{
									Memory.Swap(ref a2, ref b3);
								}
								vertex1LinkId = math.hash(new uint3(a2, b3, (uint)n));
							}
						}
						else
						{
							int y = n + 4;
							vertex1LinkId = math.hash(new uint2(gridNodeBase.NodeIndex, (uint)y));
						}
						uint vertex2LinkId;
						if (neighbourAlongDirection2 != null)
						{
							GridNodeBase neighbourAlongDirection4 = neighbourAlongDirection2.GetNeighbourAlongDirection(n);
							if (neighbourAlongDirection4 != null)
							{
								uint a3 = gridNodeBase.NodeIndex;
								uint b4 = neighbourAlongDirection2.NodeIndex;
								uint b5 = neighbourAlongDirection4.NodeIndex;
								if (a3 > b4)
								{
									Memory.Swap(ref a3, ref b4);
								}
								if (b4 > b5)
								{
									Memory.Swap(ref b4, ref b5);
								}
								if (a3 > b4)
								{
									Memory.Swap(ref a3, ref b4);
								}
								vertex2LinkId = math.hash(new uint3(a3, b4, b5));
							}
							else
							{
								uint a4 = gridNodeBase.NodeIndex;
								uint b6 = neighbourAlongDirection2.NodeIndex;
								if (a4 > b6)
								{
									Memory.Swap(ref a4, ref b6);
								}
								vertex2LinkId = math.hash(new uint3(a4, b6, (uint)n));
							}
						}
						else
						{
							int y2 = num3 + 4;
							vertex2LinkId = math.hash(new uint2(gridNodeBase.NodeIndex, (uint)y2));
						}
						Vector3 vector = (Vector3)gridNodeBase.position;
						obstacles.Add(new ObstacleSegment
						{
							vertex1 = vector + ptr[n],
							vertex2 = vector + ptr[num3],
							vertex1LinkId = (int)vertex1LinkId,
							vertex2LinkId = (int)vertex2LinkId
						});
					}
				}
			}
		}

		[BurstCompile]
		public unsafe static void TraceContours(ref UnsafeSpan<ObstacleSegment> obstaclesSpan, ref NativeMovementPlane movementPlane, int obstacleId, UnmanagedObstacle* outputObstacles, ref SlabAllocator<float3> verticesAllocator, ref SlabAllocator<ObstacleVertexGroup> obstaclesAllocator, ref SpinLock spinLock, bool simplifyObstacles)
		{
			TraceContours_00000F0E_0024BurstDirectCall.Invoke(ref obstaclesSpan, ref movementPlane, obstacleId, outputObstacles, ref verticesAllocator, ref obstaclesAllocator, ref spinLock, simplifyObstacles);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public unsafe static void TraceContours_0024BurstManaged(ref UnsafeSpan<ObstacleSegment> obstaclesSpan, ref NativeMovementPlane movementPlane, int obstacleId, UnmanagedObstacle* outputObstacles, ref SlabAllocator<float3> verticesAllocator, ref SlabAllocator<ObstacleVertexGroup> obstaclesAllocator, ref SpinLock spinLock, bool simplifyObstacles)
		{
			UnsafeSpan<ObstacleSegment> unsafeSpan = obstaclesSpan;
			if (unsafeSpan.Length == 0)
			{
				outputObstacles[obstacleId] = new UnmanagedObstacle
				{
					verticesAllocation = -1,
					groupsAllocation = -1
				};
				return;
			}
			NativeParallelHashMap<int, int> nativeParallelHashMap = new NativeParallelHashMap<int, int>(unsafeSpan.Length, Allocator.Temp);
			NativeArray<byte> nativeArray = new NativeArray<byte>(unsafeSpan.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < unsafeSpan.Length; i++)
			{
				if (nativeParallelHashMap.TryAdd(unsafeSpan[i].vertex1LinkId, i))
				{
					nativeArray[i] = 2;
				}
				else
				{
					nativeArray[i] = 0;
				}
			}
			for (int j = 0; j < unsafeSpan.Length; j++)
			{
				if (nativeParallelHashMap.TryGetValue(unsafeSpan[j].vertex2LinkId, out var item) && nativeArray[item] > 0)
				{
					nativeArray[item] = 1;
				}
			}
			NativeList<ObstacleVertexGroup> values = new NativeList<ObstacleVertexGroup>(16, Allocator.Temp);
			NativeList<float3> values2 = new NativeList<float3>(16, Allocator.Temp);
			ToPlaneMatrix toPlaneMatrix = movementPlane.AsWorldToPlaneMatrix();
			for (int k = 0; k <= 1; k++)
			{
				int num = ((k == 1) ? 1 : 2);
				for (int l = 0; l < unsafeSpan.Length; l++)
				{
					if (nativeArray[l] < num)
					{
						continue;
					}
					int length = values2.Length;
					values2.Add(in unsafeSpan[l].vertex1);
					float3 float5 = unsafeSpan[l].vertex1;
					float3 value = unsafeSpan[l].vertex2;
					int index = l;
					ObstacleType type = ObstacleType.Chain;
					float3 float6 = float5;
					float3 float7 = float5;
					while (nativeArray[index] != 0)
					{
						nativeArray[index] = 0;
						float3 value2;
						if (nativeParallelHashMap.TryGetValue(unsafeSpan[index].vertex2LinkId, out var item2))
						{
							value2 = 0.5f * (unsafeSpan[index].vertex2 + unsafeSpan[item2].vertex1);
						}
						else
						{
							value2 = unsafeSpan[index].vertex2;
							item2 = -1;
						}
						float3 float8 = float5;
						float3 float9 = value2;
						float3 float10 = value;
						float2 c = toPlaneMatrix.ToPlane(float9 - float8);
						float2 c2 = toPlaneMatrix.ToPlane(float10 - float8);
						if (!(math.abs(VectorMath.Determinant(c, c2)) < 0.01f && simplifyObstacles))
						{
							values2.Add(in value);
							float6 = math.min(float6, value);
							float7 = math.max(float7, value);
							float5 = float10;
						}
						if (item2 == l)
						{
							values2[length] = value2;
							type = ObstacleType.Loop;
							break;
						}
						if (item2 == -1)
						{
							values2.Add(in value2);
							float6 = math.min(float6, value2);
							float7 = math.max(float7, value2);
							break;
						}
						index = item2;
						value = value2;
					}
					ObstacleVertexGroup value3 = new ObstacleVertexGroup
					{
						type = type,
						vertexCount = values2.Length - length,
						boundsMn = float6,
						boundsMx = float7
					};
					values.Add(in value3);
				}
			}
			int groupsAllocation;
			int verticesAllocation;
			if (values.Length > 0)
			{
				spinLock.Lock();
				groupsAllocation = obstaclesAllocator.Allocate(values);
				verticesAllocation = verticesAllocator.Allocate(values2);
				spinLock.Unlock();
			}
			else
			{
				groupsAllocation = -1;
				verticesAllocation = -1;
			}
			outputObstacles[obstacleId] = new UnmanagedObstacle
			{
				verticesAllocation = verticesAllocation,
				groupsAllocation = groupsAllocation
			};
		}
	}
}
