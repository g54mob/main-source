using System;
using System.Collections.Generic;
using Pathfinding.Graphs.Grid.Jobs;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid
{
	public struct GridGraphScanData
	{
		public JobDependencyTracker dependencyTracker;

		public Vector3 up;

		public GraphTransform transform;

		public GridGraphNodeData nodes;

		public NativeArray<RaycastHit> heightHits;

		public IntBounds heightHitsBounds;

		[Obsolete("Use nodes.bounds or heightHitsBounds depending on if you are using the heightHits array or not")]
		public IntBounds bounds => nodes.bounds;

		[Obsolete("Use nodes.layeredDataLayout instead")]
		public bool layeredDataLayout => nodes.layeredDataLayout;

		[Obsolete("Use nodes.positions instead")]
		public NativeArray<Vector3> nodePositions => nodes.positions;

		[Obsolete("Use nodes.connections instead")]
		public NativeArray<ulong> nodeConnections => nodes.connections;

		[Obsolete("Use nodes.penalties instead")]
		public NativeArray<uint> nodePenalties => nodes.penalties;

		[Obsolete("Use nodes.tags instead")]
		public NativeArray<int> nodeTags => nodes.tags;

		[Obsolete("Use nodes.normals instead")]
		public NativeArray<float4> nodeNormals => nodes.normals;

		[Obsolete("Use nodes.walkable instead")]
		public NativeArray<bool> nodeWalkable => nodes.walkable;

		[Obsolete("Use nodes.walkableWithErosion instead")]
		public NativeArray<bool> nodeWalkableWithErosion => nodes.walkableWithErosion;

		public void SetDefaultPenalties(uint initialPenalty)
		{
			nodes.penalties.MemSet(initialPenalty).Schedule(dependencyTracker);
		}

		public void SetDefaultNodePositions(GraphTransform transform)
		{
			new JobNodeGridLayout
			{
				graphToWorld = transform.matrix,
				bounds = nodes.bounds,
				nodePositions = nodes.positions
			}.Schedule(dependencyTracker);
		}

		public JobHandle HeightCheck(GraphCollision collision, int maxHits, IntBounds recalculationBounds, NativeArray<int> outLayerCount, float characterHeight, Allocator allocator)
		{
			int num = recalculationBounds.size.x * recalculationBounds.size.z;
			NativeArray<RaycastCommand> nativeArray = dependencyTracker.NewNativeArray<RaycastCommand>(num, allocator);
			heightHits = dependencyTracker.NewNativeArray<RaycastHit>(num * maxHits, allocator);
			heightHitsBounds = recalculationBounds;
			JobHandle dependency = new JobPrepareGridRaycast
			{
				graphToWorld = transform.matrix,
				bounds = recalculationBounds,
				physicsScene = Physics.defaultPhysicsScene,
				raycastOffset = up * collision.fromHeight,
				raycastDirection = -up * (collision.fromHeight + 0.01f),
				raycastMask = collision.heightMask,
				raycastCommands = nativeArray
			}.Schedule(dependencyTracker);
			if (maxHits > 1)
			{
				float minStep = characterHeight * 0.5f;
				JobHandle dependsOn = new JobRaycastAll(nativeArray, heightHits, Physics.defaultPhysicsScene, maxHits, allocator, dependencyTracker, minStep).Schedule(dependency);
				return Unity.Jobs.IJobExtensions.Schedule(new JobMaxHitCount
				{
					hits = heightHits,
					maxHits = maxHits,
					layerStride = num,
					maxHitCount = outLayerCount
				}, dependsOn);
			}
			dependencyTracker.ScheduleBatch(nativeArray, heightHits, 2048);
			outLayerCount[0] = 1;
			return default(JobHandle);
		}

		public void CopyHits(IntBounds recalculationBounds)
		{
			nodes.normals.MemSet(float4.zero).Schedule(dependencyTracker);
			new JobCopyHits
			{
				hits = heightHits,
				points = nodes.positions,
				normals = nodes.normals,
				slice = new Slice3D(nodes.bounds, recalculationBounds)
			}.Schedule(dependencyTracker);
		}

		public void CalculateWalkabilityFromHeightData(bool useRaycastNormal, bool unwalkableWhenNoGround, float maxSlope, float characterHeight)
		{
			new JobNodeWalkability
			{
				useRaycastNormal = useRaycastNormal,
				unwalkableWhenNoGround = unwalkableWhenNoGround,
				maxSlope = maxSlope,
				up = up,
				nodeNormals = nodes.normals,
				nodeWalkable = nodes.walkable,
				nodePositions = nodes.positions.Reinterpret<float3>(),
				characterHeight = characterHeight,
				layerStride = nodes.bounds.size.x * nodes.bounds.size.z
			}.Schedule(dependencyTracker);
		}

		public IEnumerator<JobHandle> CollisionCheck(GraphCollision collision, IntBounds calculationBounds)
		{
			if (collision.type == ColliderType.Ray && !collision.use2D)
			{
				NativeArray<bool> nativeArray = dependencyTracker.NewNativeArray<bool>(nodes.numNodes, nodes.allocationMethod, NativeArrayOptions.UninitializedMemory);
				collision.JobCollisionRay(nodes.positions, nativeArray, up, nodes.allocationMethod, dependencyTracker);
				nodes.walkable.BitwiseAndWith(nativeArray).WithLength(nodes.numNodes).Schedule(dependencyTracker);
				return null;
			}
			return new JobCheckCollisions
			{
				nodePositions = nodes.positions,
				collisionResult = nodes.walkable,
				collision = collision
			}.ExecuteMainThreadJob(dependencyTracker);
		}

		public void Connections(float maxStepHeight, bool maxStepUsesSlope, IntBounds calculationBounds, NumNeighbours neighbours, bool cutCorners, bool use2D, bool useErodedWalkability, float characterHeight)
		{
			JobCalculateGridConnections jobCalculateGridConnections = new JobCalculateGridConnections
			{
				maxStepHeight = maxStepHeight,
				maxStepUsesSlope = maxStepUsesSlope,
				up = up,
				bounds = calculationBounds.Offset(-nodes.bounds.min),
				arrayBounds = nodes.bounds.size,
				neighbours = neighbours,
				use2D = use2D,
				cutCorners = cutCorners,
				nodeWalkable = (useErodedWalkability ? nodes.walkableWithErosion : nodes.walkable).AsUnsafeSpanNoChecks(),
				nodePositions = nodes.positions.AsUnsafeSpanNoChecks(),
				nodeNormals = nodes.normals.AsUnsafeSpanNoChecks(),
				nodeConnections = nodes.connections.AsUnsafeSpanNoChecks(),
				characterHeight = characterHeight,
				layeredDataLayout = nodes.layeredDataLayout
			};
			if (dependencyTracker != null)
			{
				jobCalculateGridConnections.ScheduleBatch(calculationBounds.size.z, 20, dependencyTracker);
			}
			else
			{
				JobParallelForBatchedExtensions.RunBatch(jobCalculateGridConnections, calculationBounds.size.z);
			}
			if (nodes.layeredDataLayout)
			{
				JobFilterDiagonalConnections jobFilterDiagonalConnections = new JobFilterDiagonalConnections
				{
					slice = new Slice3D(nodes.bounds, calculationBounds),
					neighbours = neighbours,
					cutCorners = cutCorners,
					nodeConnections = nodes.connections.AsUnsafeSpanNoChecks()
				};
				if (dependencyTracker != null)
				{
					jobFilterDiagonalConnections.ScheduleBatch(calculationBounds.size.z, 20, dependencyTracker);
				}
				else
				{
					JobParallelForBatchedExtensions.RunBatch(jobFilterDiagonalConnections, calculationBounds.size.z);
				}
			}
		}

		public void Erosion(NumNeighbours neighbours, int erodeIterations, IntBounds erosionWriteMask, bool erosionUsesTags, int erosionStartTag, int erosionTagsPrecedenceMask)
		{
			if (!nodes.layeredDataLayout)
			{
				new JobErosion<FlatGridAdjacencyMapper>
				{
					bounds = nodes.bounds,
					writeMask = erosionWriteMask,
					neighbours = neighbours,
					nodeConnections = nodes.connections,
					erosion = erodeIterations,
					nodeWalkable = nodes.walkable,
					outNodeWalkable = nodes.walkableWithErosion,
					nodeTags = nodes.tags,
					erosionUsesTags = erosionUsesTags,
					erosionStartTag = erosionStartTag,
					erosionTagsPrecedenceMask = erosionTagsPrecedenceMask
				}.Schedule(dependencyTracker);
			}
			else
			{
				new JobErosion<LayeredGridAdjacencyMapper>
				{
					bounds = nodes.bounds,
					writeMask = erosionWriteMask,
					neighbours = neighbours,
					nodeConnections = nodes.connections,
					erosion = erodeIterations,
					nodeWalkable = nodes.walkable,
					outNodeWalkable = nodes.walkableWithErosion,
					nodeTags = nodes.tags,
					erosionUsesTags = erosionUsesTags,
					erosionStartTag = erosionStartTag,
					erosionTagsPrecedenceMask = erosionTagsPrecedenceMask
				}.Schedule(dependencyTracker);
			}
		}

		public void AssignNodeConnections(GridNodeBase[] nodes, int3 nodeArrayBounds, IntBounds writeBounds)
		{
			IntBounds intBounds = this.nodes.bounds;
			int3 int5 = writeBounds.min - intBounds.min;
			UnsafeSpan<ulong> unsafeSpan = this.nodes.connections.AsUnsafeReadOnlySpan();
			for (int i = 0; i < writeBounds.size.y; i++)
			{
				int num = (i + writeBounds.min.y) * nodeArrayBounds.x * nodeArrayBounds.z;
				for (int j = 0; j < writeBounds.size.z; j++)
				{
					int num2 = num + (j + writeBounds.min.z) * nodeArrayBounds.x + writeBounds.min.x;
					int num3 = (i + int5.y) * intBounds.size.x * intBounds.size.z + (j + int5.z) * intBounds.size.x + int5.x;
					for (int k = 0; k < writeBounds.size.x; k++)
					{
						GridNodeBase gridNodeBase = nodes[num2 + k];
						int index = num3 + k;
						ulong num4 = unsafeSpan[index];
						if (gridNodeBase != null)
						{
							if (gridNodeBase is LevelGridNode levelGridNode)
							{
								levelGridNode.SetAllConnectionInternal(num4);
							}
							else
							{
								(gridNodeBase as GridNode).SetAllConnectionInternal((int)num4);
							}
						}
					}
				}
			}
		}
	}
}
