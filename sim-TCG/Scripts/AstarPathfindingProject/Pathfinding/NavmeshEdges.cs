using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Pathfinding.Drawing;
using Pathfinding.Jobs;
using Pathfinding.RVO;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public class NavmeshEdges
	{
		[BurstCompile]
		private struct JobResizeObstacles : IJob
		{
			public NativeList<UnmanagedObstacle> obstacles;

			public NativeReference<int> numHierarchicalNodes;

			public void Execute()
			{
				int length = obstacles.Length;
				int value = numHierarchicalNodes.Value;
				obstacles.Resize(value, NativeArrayOptions.UninitializedMemory);
				for (int i = length; i < obstacles.Length; i++)
				{
					obstacles[i] = new UnmanagedObstacle
					{
						verticesAllocation = -1,
						groupsAllocation = -1
					};
				}
				if (obstacles.Length > 0)
				{
					obstacles[0] = new UnmanagedObstacle
					{
						verticesAllocation = -2,
						groupsAllocation = -2
					};
				}
			}
		}

		private struct JobCalculateObstacles : IJobParallelForBatch
		{
			public GCHandle hGraphGC;

			public SlabAllocator<float3> obstacleVertices;

			public SlabAllocator<ObstacleVertexGroup> obstacleVertexGroups;

			[NativeDisableParallelForRestriction]
			public NativeArray<UnmanagedObstacle> obstacles;

			[NativeDisableParallelForRestriction]
			public NativeArray<Bounds> bounds;

			[ReadOnly]
			public NativeList<int> dirtyHierarchicalNodes;

			[NativeDisableUnsafePtrRestriction]
			public unsafe SpinLock* allocationLock;

			private static readonly ProfilerMarker MarkerBBox = new ProfilerMarker("HierarchicalBBox");

			private static readonly ProfilerMarker MarkerObstacles = new ProfilerMarker("CalculateObstacles");

			private static readonly ProfilerMarker MarkerCollect = new ProfilerMarker("Collect");

			private static readonly ProfilerMarker MarkerTrace = new ProfilerMarker("Trace");

			public void Execute(int startIndex, int count)
			{
				HierarchicalGraph hGraph = hGraphGC.Target as HierarchicalGraph;
				int num = (dirtyHierarchicalNodes.Length + 32 - 1) / 32;
				startIndex *= num;
				count *= num;
				int num2 = math.min(startIndex + count, dirtyHierarchicalNodes.Length);
				NativeList<RVOObstacleCache.ObstacleSegment> edgesScratch = new NativeList<RVOObstacleCache.ObstacleSegment>(Allocator.Temp);
				for (int i = startIndex; i < num2; i++)
				{
					edgesScratch.Clear();
					int hierarchicalNode = dirtyHierarchicalNodes[i];
					CalculateBoundingBox(hGraph, hierarchicalNode);
					CalculateObstacles(hGraph, hierarchicalNode, obstacleVertexGroups, obstacleVertices, obstacles, edgesScratch);
				}
			}

			private void CalculateBoundingBox(HierarchicalGraph hGraph, int hierarchicalNode)
			{
				List<GraphNode> list = hGraph.children[hierarchicalNode];
				Bounds value = default(Bounds);
				if (list.Count != 0)
				{
					if (list[0] is TriangleMeshNode)
					{
						Int3 int5 = new Int3(int.MaxValue, int.MaxValue, int.MaxValue);
						Int3 int6 = new Int3(int.MinValue, int.MinValue, int.MinValue);
						for (int i = 0; i < list.Count; i++)
						{
							(list[i] as TriangleMeshNode).GetVertices(out var v, out var v2, out var v3);
							int5 = Int3.Min(Int3.Min(Int3.Min(int5, v), v2), v3);
							int6 = Int3.Max(Int3.Max(Int3.Max(int6, v), v2), v3);
						}
						value.SetMinMax((Vector3)int5, (Vector3)int6);
					}
					else
					{
						Int3 int7 = new Int3(int.MaxValue, int.MaxValue, int.MaxValue);
						Int3 int8 = new Int3(int.MinValue, int.MinValue, int.MinValue);
						for (int j = 0; j < list.Count; j++)
						{
							GraphNode graphNode = list[j];
							int7 = Int3.Min(int7, graphNode.position);
							int8 = Int3.Max(int8, graphNode.position);
						}
						if (list[0] is GridNodeBase)
						{
							float num = ((!(list[0] is LevelGridNode)) ? GridNode.GetGridGraph(list[0].GraphIndex).nodeSize : LevelGridNode.GetGridGraph(list[0].GraphIndex).nodeSize);
							Vector3 vector = num * 0.70710677f * Vector3.one;
							value.SetMinMax((Vector3)int7 - vector, (Vector3)int8 + vector);
						}
						else
						{
							value.SetMinMax((Vector3)int7, (Vector3)int8);
						}
					}
				}
				bounds[hierarchicalNode] = value;
			}

			private unsafe void CalculateObstacles(HierarchicalGraph hGraph, int hierarchicalNode, SlabAllocator<ObstacleVertexGroup> obstacleVertexGroups, SlabAllocator<float3> obstacleVertices, NativeArray<UnmanagedObstacle> obstacles, NativeList<RVOObstacleCache.ObstacleSegment> edgesScratch)
			{
				RVOObstacleCache.CollectContours(hGraph.children[hierarchicalNode], edgesScratch);
				UnmanagedObstacle unmanagedObstacle = obstacles[hierarchicalNode];
				if (unmanagedObstacle.groupsAllocation != -1)
				{
					allocationLock->Lock();
					obstacleVertices.Free(unmanagedObstacle.verticesAllocation);
					obstacleVertexGroups.Free(unmanagedObstacle.groupsAllocation);
					allocationLock->Unlock();
				}
				List<GraphNode> list = hGraph.children[hierarchicalNode];
				bool simplifyObstacles = true;
				NativeMovementPlane movementPlane;
				if (list.Count > 0)
				{
					if (list[0] is GridNodeBase)
					{
						movementPlane = new NativeMovementPlane((list[0].Graph as GridGraph).transform.rotation);
					}
					else if (list[0] is TriangleMeshNode)
					{
						NavmeshBase navmeshBase = list[0].Graph as NavmeshBase;
						movementPlane = new NativeMovementPlane(navmeshBase.transform.rotation);
						simplifyObstacles = navmeshBase.RecalculateNormals;
					}
					else
					{
						movementPlane = new NativeMovementPlane(quaternion.identity);
						simplifyObstacles = false;
					}
				}
				else
				{
					movementPlane = default(NativeMovementPlane);
				}
				UnsafeSpan<RVOObstacleCache.ObstacleSegment> obstaclesSpan = edgesScratch.AsUnsafeSpan();
				RVOObstacleCache.TraceContours(ref obstaclesSpan, ref movementPlane, hierarchicalNode, (UnmanagedObstacle*)obstacles.GetUnsafePtr(), ref obstacleVertices, ref obstacleVertexGroups, ref UnsafeUtility.AsRef<SpinLock>(allocationLock), simplifyObstacles);
			}
		}

		public struct NavmeshBorderData
		{
			public HierarchicalGraph.HierarhicalNodeData hierarhicalNodeData;

			public SimulatorBurst.ObstacleData obstacleData;

			public static NavmeshBorderData CreateEmpty(Allocator allocator)
			{
				return new NavmeshBorderData
				{
					hierarhicalNodeData = new HierarchicalGraph.HierarhicalNodeData
					{
						connectionAllocator = default(SlabAllocator<int>),
						connectionAllocations = new NativeList<int>(0, allocator),
						bounds = new NativeList<Bounds>(0, allocator)
					},
					obstacleData = new SimulatorBurst.ObstacleData
					{
						obstacleVertexGroups = default(SlabAllocator<ObstacleVertexGroup>),
						obstacleVertices = default(SlabAllocator<float3>),
						obstacles = new NativeList<UnmanagedObstacle>(0, allocator)
					}
				};
			}

			public void DisposeEmpty(JobHandle dependsOn)
			{
				if (hierarhicalNodeData.connectionAllocator.IsCreated)
				{
					throw new InvalidOperationException("NavmeshEdgeData was not empty");
				}
				hierarhicalNodeData.connectionAllocations.Dispose(dependsOn);
				hierarhicalNodeData.bounds.Dispose(dependsOn);
				obstacleData.obstacles.Dispose(dependsOn);
			}

			private static void GetHierarchicalNodesInRangeRec(int hierarchicalNode, Bounds bounds, SlabAllocator<int> connectionAllocator, [NoAlias] NativeList<int> connectionAllocations, NativeList<Bounds> nodeBounds, [NoAlias] NativeList<int> indices)
			{
				indices.Add(in hierarchicalNode);
				UnsafeSpan<int> span = connectionAllocator.GetSpan(connectionAllocations[hierarchicalNode]);
				for (int i = 0; i < span.Length; i++)
				{
					int num = span[i];
					if (nodeBounds[num].Intersects(bounds) && !indices.Contains(num))
					{
						GetHierarchicalNodesInRangeRec(num, bounds, connectionAllocator, connectionAllocations, nodeBounds, indices);
					}
				}
			}

			private static void ConvertObstaclesToEdges(ref SimulatorBurst.ObstacleData obstacleData, NativeList<int> obstacleIndices, Bounds localBounds, NativeList<float2> edgeBuffer, NativeMovementPlane movementPlane)
			{
				Bounds bounds = movementPlane.ToWorld(localBounds);
				ToPlaneMatrix toPlaneMatrix = movementPlane.AsWorldToPlaneMatrix();
				float3 float5 = bounds.min;
				float3 float6 = bounds.max;
				float3 float7 = localBounds.min;
				float3 float8 = localBounds.max;
				int num = 0;
				for (int i = 0; i < obstacleIndices.Length; i++)
				{
					UnmanagedObstacle unmanagedObstacle = obstacleData.obstacles[obstacleIndices[i]];
					num += obstacleData.obstacleVertices.GetSpan(unmanagedObstacle.verticesAllocation).Length;
				}
				edgeBuffer.ResizeUninitialized(num * 3);
				int length = 0;
				for (int j = 0; j < obstacleIndices.Length; j++)
				{
					UnmanagedObstacle unmanagedObstacle2 = obstacleData.obstacles[obstacleIndices[j]];
					if (unmanagedObstacle2.verticesAllocation == -1)
					{
						continue;
					}
					UnsafeSpan<float3> span = obstacleData.obstacleVertices.GetSpan(unmanagedObstacle2.verticesAllocation);
					UnsafeSpan<ObstacleVertexGroup> span2 = obstacleData.obstacleVertexGroups.GetSpan(unmanagedObstacle2.groupsAllocation);
					int num2 = 0;
					for (int k = 0; k < span2.Length; k++)
					{
						ObstacleVertexGroup obstacleVertexGroup = span2[k];
						if (!math.all((obstacleVertexGroup.boundsMx >= float5) & (obstacleVertexGroup.boundsMn <= float6)))
						{
							num2 += obstacleVertexGroup.vertexCount;
							continue;
						}
						for (int l = 0; l < obstacleVertexGroup.vertexCount - 1; l++)
						{
							float3 float9 = span[num2 + l];
							float3 float10 = span[num2 + l + 1];
							float3 float11 = math.min(float9, float10);
							if (math.all((math.max(float9, float10) >= float5) & (float11 <= float6)))
							{
								float3 x = toPlaneMatrix.ToXZPlane(float9);
								float3 y = toPlaneMatrix.ToXZPlane(float10);
								float11 = math.min(x, y);
								if (math.all((math.max(x, y) >= float7) & (float11 <= float8)))
								{
									edgeBuffer[length++] = x.xz;
									edgeBuffer[length++] = y.xz;
								}
							}
						}
						if (obstacleVertexGroup.type == ObstacleType.Loop)
						{
							float3 float12 = span[num2 + obstacleVertexGroup.vertexCount - 1];
							float3 float13 = span[num2];
							float3 float14 = math.min(float12, float13);
							if (math.all((math.max(float12, float13) >= float5) & (float14 <= float6)))
							{
								float3 x2 = toPlaneMatrix.ToXZPlane(float12);
								float3 y2 = toPlaneMatrix.ToXZPlane(float13);
								float14 = math.min(x2, y2);
								if (math.all((math.max(x2, y2) >= float7) & (float14 <= float8)))
								{
									edgeBuffer[length++] = x2.xz;
									edgeBuffer[length++] = y2.xz;
								}
							}
						}
						num2 += obstacleVertexGroup.vertexCount;
					}
				}
				edgeBuffer.Length = length;
			}

			public void GetObstaclesInRange(int hierarchicalNode, Bounds bounds, NativeList<int> obstacleIndexBuffer)
			{
				if (obstacleData.obstacleVertices.IsCreated)
				{
					GetHierarchicalNodesInRangeRec(hierarchicalNode, bounds, hierarhicalNodeData.connectionAllocator, hierarhicalNodeData.connectionAllocations, hierarhicalNodeData.bounds, obstacleIndexBuffer);
				}
			}

			public void GetEdgesInRange(int hierarchicalNode, Bounds localBounds, NativeList<float2> edgeBuffer, NativeMovementPlane movementPlane)
			{
				if (obstacleData.obstacleVertices.IsCreated)
				{
					NativeList<int> nativeList = new NativeList<int>(8, Allocator.Temp);
					GetObstaclesInRange(hierarchicalNode, movementPlane.ToWorld(localBounds), nativeList);
					ConvertObstaclesToEdges(ref obstacleData, nativeList, localBounds, edgeBuffer, movementPlane);
				}
			}
		}

		public SimulatorBurst.ObstacleData obstacleData;

		private SpinLock allocationLock;

		private const int JobRecalculateObstaclesBatchCount = 32;

		private RWLock rwLock = new RWLock();

		public HierarchicalGraph hierarchicalGraph;

		private int gizmoVersion;

		public void Dispose()
		{
			rwLock.WriteSync().Unlock();
			obstacleData.Dispose();
		}

		private void Init()
		{
			obstacleData.Init(Allocator.Persistent);
		}

		public unsafe JobHandle RecalculateObstacles(NativeList<int> dirtyHierarchicalNodes, NativeReference<int> numHierarchicalNodes, JobHandle dependency)
		{
			Init();
			RWLock.WriteLockAsync writeLockAsync = rwLock.Write();
			JobHandle dependsOn = Unity.Jobs.IJobExtensions.Schedule(new JobResizeObstacles
			{
				numHierarchicalNodes = numHierarchicalNodes,
				obstacles = obstacleData.obstacles
			}, JobHandle.CombineDependencies(dependency, writeLockAsync.dependency));
			dependsOn = IJobParallelForBatchExtensions.ScheduleBatch(new JobCalculateObstacles
			{
				hGraphGC = hierarchicalGraph.gcHandle,
				obstacleVertices = obstacleData.obstacleVertices,
				obstacleVertexGroups = obstacleData.obstacleVertexGroups,
				obstacles = obstacleData.obstacles.AsDeferredJobArray(),
				bounds = hierarchicalGraph.bounds.AsDeferredJobArray(),
				dirtyHierarchicalNodes = dirtyHierarchicalNodes,
				allocationLock = (SpinLock*)UnsafeUtility.AddressOf(ref allocationLock)
			}, 32, 1, dependsOn);
			writeLockAsync.UnlockAfter(dependsOn);
			gizmoVersion++;
			return dependsOn;
		}

		public void OnDrawGizmos(DrawingData gizmos, RedrawScope redrawScope)
		{
			if (!obstacleData.obstacleVertices.IsCreated)
			{
				return;
			}
			NodeHasher nodeHasher = new NodeHasher(AstarPath.active);
			nodeHasher.Add(12314127);
			nodeHasher.Add(gizmoVersion);
			if (gizmos.Draw(nodeHasher, redrawScope))
			{
				return;
			}
			RWLock.LockSync lockSync = rwLock.ReadSync();
			try
			{
				using CommandBuilder commandBuilder = gizmos.GetBuilder(nodeHasher, redrawScope);
				for (int i = 1; i < obstacleData.obstacles.Length; i++)
				{
					UnmanagedObstacle unmanagedObstacle = obstacleData.obstacles[i];
					UnsafeSpan<float3> span = obstacleData.obstacleVertices.GetSpan(unmanagedObstacle.verticesAllocation);
					UnsafeSpan<ObstacleVertexGroup> span2 = obstacleData.obstacleVertexGroups.GetSpan(unmanagedObstacle.groupsAllocation);
					int num = 0;
					for (int j = 0; j < span2.Length; j++)
					{
						ObstacleVertexGroup obstacleVertexGroup = span2[j];
						commandBuilder.PushLineWidth(2f);
						for (int k = 0; k < obstacleVertexGroup.vertexCount - 1; k++)
						{
							commandBuilder.ArrowRelativeSizeHead(span[num + k], span[num + k + 1], new float3(0f, 1f, 0f), 0.05f, Color.black);
						}
						if (obstacleVertexGroup.type == ObstacleType.Loop)
						{
							commandBuilder.Arrow(span[num + obstacleVertexGroup.vertexCount - 1], span[num], new float3(0f, 1f, 0f), 0.05f, Color.black);
						}
						commandBuilder.PopLineWidth();
						num += obstacleVertexGroup.vertexCount;
						commandBuilder.WireBox(0.5f * (obstacleVertexGroup.boundsMn + obstacleVertexGroup.boundsMx), obstacleVertexGroup.boundsMx - obstacleVertexGroup.boundsMn, Color.white);
					}
				}
			}
			finally
			{
				lockSync.Unlock();
			}
		}

		public NavmeshBorderData GetNavmeshEdgeData(out RWLock.CombinedReadLockAsync readLock)
		{
			Init();
			RWLock.ReadLockAsync @lock = rwLock.Read();
			RWLock.ReadLockAsync readLock2;
			HierarchicalGraph.HierarhicalNodeData hierarhicalNodeData = hierarchicalGraph.GetHierarhicalNodeData(out readLock2);
			readLock = new RWLock.CombinedReadLockAsync(@lock, readLock2);
			return new NavmeshBorderData
			{
				hierarhicalNodeData = hierarhicalNodeData,
				obstacleData = obstacleData
			};
		}
	}
}
