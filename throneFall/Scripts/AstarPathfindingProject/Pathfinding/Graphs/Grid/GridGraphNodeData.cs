using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.Graphs.Grid.Jobs;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid
{
	public struct GridGraphNodeData
	{
		private struct LightReader : GridIterationUtilities.ISliceAction
		{
			public GridNodeBase[] nodes;

			public UnsafeSpan<Vector3> nodePositions;

			public UnsafeSpan<bool> nodeWalkable;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Execute(uint outerIdx, uint innerIdx)
			{
				if (outerIdx < nodes.Length)
				{
					GridNodeBase gridNodeBase = nodes[outerIdx];
					if (gridNodeBase != null)
					{
						nodePositions[innerIdx] = (Vector3)gridNodeBase.position;
						nodeWalkable[innerIdx] = gridNodeBase.Walkable;
						return;
					}
				}
				nodePositions[innerIdx] = Vector3.zero;
				nodeWalkable[innerIdx] = false;
			}
		}

		public Allocator allocationMethod;

		public int numNodes;

		public IntBounds bounds;

		public NativeArray<Vector3> positions;

		public NativeArray<ulong> connections;

		public NativeArray<uint> penalties;

		public NativeArray<int> tags;

		public NativeArray<float4> normals;

		public NativeArray<bool> walkable;

		public NativeArray<bool> walkableWithErosion;

		public bool layeredDataLayout;

		public int layers => bounds.size.y;

		public void AllocateBuffers(JobDependencyTracker dependencyTracker)
		{
			if (dependencyTracker != null)
			{
				positions = dependencyTracker.NewNativeArray<Vector3>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				normals = dependencyTracker.NewNativeArray<float4>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				connections = dependencyTracker.NewNativeArray<ulong>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				penalties = dependencyTracker.NewNativeArray<uint>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				walkable = dependencyTracker.NewNativeArray<bool>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				walkableWithErosion = dependencyTracker.NewNativeArray<bool>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				tags = dependencyTracker.NewNativeArray<int>(numNodes, allocationMethod);
			}
			else
			{
				positions = new NativeArray<Vector3>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				normals = new NativeArray<float4>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				connections = new NativeArray<ulong>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				penalties = new NativeArray<uint>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				walkable = new NativeArray<bool>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				walkableWithErosion = new NativeArray<bool>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
				tags = new NativeArray<int>(numNodes, allocationMethod);
			}
		}

		public void TrackBuffers(JobDependencyTracker dependencyTracker)
		{
			if (positions.IsCreated)
			{
				dependencyTracker.Track(positions);
			}
			if (normals.IsCreated)
			{
				dependencyTracker.Track(normals);
			}
			if (connections.IsCreated)
			{
				dependencyTracker.Track(connections);
			}
			if (penalties.IsCreated)
			{
				dependencyTracker.Track(penalties);
			}
			if (walkable.IsCreated)
			{
				dependencyTracker.Track(walkable);
			}
			if (walkableWithErosion.IsCreated)
			{
				dependencyTracker.Track(walkableWithErosion);
			}
			if (tags.IsCreated)
			{
				dependencyTracker.Track(tags);
			}
		}

		public void PersistBuffers(JobDependencyTracker dependencyTracker)
		{
			dependencyTracker.Persist(positions);
			dependencyTracker.Persist(normals);
			dependencyTracker.Persist(connections);
			dependencyTracker.Persist(penalties);
			dependencyTracker.Persist(walkable);
			dependencyTracker.Persist(walkableWithErosion);
			dependencyTracker.Persist(tags);
		}

		public void Dispose()
		{
			bounds = default(IntBounds);
			numNodes = 0;
			if (positions.IsCreated)
			{
				positions.Dispose();
			}
			if (normals.IsCreated)
			{
				normals.Dispose();
			}
			if (connections.IsCreated)
			{
				connections.Dispose();
			}
			if (penalties.IsCreated)
			{
				penalties.Dispose();
			}
			if (walkable.IsCreated)
			{
				walkable.Dispose();
			}
			if (walkableWithErosion.IsCreated)
			{
				walkableWithErosion.Dispose();
			}
			if (tags.IsCreated)
			{
				tags.Dispose();
			}
		}

		public unsafe JobHandle Rotate2D(int dx, int dz, JobHandle dependency)
		{
			int3 size = bounds.size;
			return JobHandleUnsafeUtility.CombineDependencies(stackalloc JobHandle[7]
			{
				positions.Rotate3D(size, dx, dz).Schedule(dependency),
				normals.Rotate3D(size, dx, dz).Schedule(dependency),
				connections.Rotate3D(size, dx, dz).Schedule(dependency),
				penalties.Rotate3D(size, dx, dz).Schedule(dependency),
				walkable.Rotate3D(size, dx, dz).Schedule(dependency),
				walkableWithErosion.Rotate3D(size, dx, dz).Schedule(dependency),
				tags.Rotate3D(size, dx, dz).Schedule(dependency)
			}, 7);
		}

		public void ResizeLayerCount(int layerCount, JobDependencyTracker dependencyTracker)
		{
			if (layerCount > layers)
			{
				GridGraphNodeData input = this;
				bounds.max.y = layerCount;
				numNodes = bounds.volume;
				AllocateBuffers(dependencyTracker);
				normals.MemSet(float4.zero).Schedule(dependencyTracker);
				walkable.MemSet(value: false).Schedule(dependencyTracker);
				walkableWithErosion.MemSet(value: false).Schedule(dependencyTracker);
				new JobCopyBuffers
				{
					input = input,
					output = this,
					copyPenaltyAndTags = true,
					bounds = input.bounds
				}.Schedule(dependencyTracker);
			}
			if (layerCount < layers)
			{
				throw new ArgumentException("Cannot reduce the number of layers");
			}
		}

		public void ReadFromNodesForConnectionCalculations(GridNodeBase[] nodes, Slice3D slice, JobHandle nodesDependsOn, NativeArray<float4> graphNodeNormals, JobDependencyTracker dependencyTracker)
		{
			bounds = slice.slice;
			numNodes = slice.slice.volume;
			positions = new NativeArray<Vector3>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
			normals = new NativeArray<float4>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
			connections = new NativeArray<ulong>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
			walkableWithErosion = new NativeArray<bool>(numNodes, allocationMethod, NativeArrayOptions.UninitializedMemory);
			LightReader action = new LightReader
			{
				nodes = nodes,
				nodePositions = positions.AsUnsafeSpan(),
				nodeWalkable = walkableWithErosion.AsUnsafeSpan()
			};
			GridIterationUtilities.ForEachCellIn3DSlice(slice, ref action);
			ReadNodeNormals(slice, graphNodeNormals, dependencyTracker);
		}

		private void ReadNodeNormals(Slice3D slice, NativeArray<float4> graphNodeNormals, JobDependencyTracker dependencyTracker)
		{
			if (dependencyTracker != null)
			{
				normals.MemSet(float4.zero).Schedule(dependencyTracker);
				new JobCopyRectangle<float4>
				{
					input = graphNodeNormals,
					output = normals,
					inputSlice = slice,
					outputSlice = new Slice3D(bounds, slice.slice)
				}.Schedule(dependencyTracker);
			}
			else
			{
				normals.AsUnsafeSpan().FillZeros();
				JobCopyRectangle<float4>.Copy(graphNodeNormals, normals, slice, new Slice3D(bounds, slice.slice));
			}
		}

		public static GridGraphNodeData ReadFromNodes(GridNodeBase[] nodes, Slice3D slice, JobHandle nodesDependsOn, NativeArray<float4> graphNodeNormals, Allocator allocator, bool layeredDataLayout, JobDependencyTracker dependencyTracker)
		{
			GridGraphNodeData result = new GridGraphNodeData
			{
				allocationMethod = allocator,
				numNodes = slice.slice.volume,
				bounds = slice.slice,
				layeredDataLayout = layeredDataLayout
			};
			result.AllocateBuffers(dependencyTracker);
			GCHandle gCHandle = GCHandle.Alloc(nodes);
			JobHandle dependsOn = new JobReadNodeData
			{
				nodesHandle = gCHandle,
				nodePositions = result.positions,
				nodePenalties = result.penalties,
				nodeTags = result.tags,
				nodeConnections = result.connections,
				nodeWalkableWithErosion = result.walkableWithErosion,
				nodeWalkable = result.walkable,
				slice = slice
			}.ScheduleBatch(result.numNodes, math.max(2000, result.numNodes / 16), dependencyTracker, nodesDependsOn);
			dependencyTracker.DeferFree(gCHandle, dependsOn);
			if (graphNodeNormals.IsCreated)
			{
				result.ReadNodeNormals(slice, graphNodeNormals, dependencyTracker);
			}
			return result;
		}

		public GridGraphNodeData ReadFromNodesAndCopy(GridNodeBase[] nodes, Slice3D slice, JobHandle nodesDependsOn, NativeArray<float4> graphNodeNormals, bool copyPenaltyAndTags, JobDependencyTracker dependencyTracker)
		{
			GridGraphNodeData result = ReadFromNodes(nodes, slice, nodesDependsOn, graphNodeNormals, allocationMethod, layeredDataLayout, dependencyTracker);
			result.CopyFrom(this, copyPenaltyAndTags, dependencyTracker);
			return result;
		}

		public void CopyFrom(GridGraphNodeData other, bool copyPenaltyAndTags, JobDependencyTracker dependencyTracker)
		{
			CopyFrom(other, IntBounds.Intersection(bounds, other.bounds), copyPenaltyAndTags, dependencyTracker);
		}

		public void CopyFrom(GridGraphNodeData other, IntBounds bounds, bool copyPenaltyAndTags, JobDependencyTracker dependencyTracker)
		{
			JobCopyBuffers jobData = new JobCopyBuffers
			{
				input = other,
				output = this,
				copyPenaltyAndTags = copyPenaltyAndTags,
				bounds = bounds
			};
			if (dependencyTracker != null)
			{
				jobData.Schedule(dependencyTracker);
			}
			else
			{
				Unity.Jobs.IJobExtensions.RunByRef(ref jobData);
			}
		}

		public JobHandle AssignToNodes(GridNodeBase[] nodes, int3 nodeArrayBounds, IntBounds writeMask, uint graphIndex, JobHandle nodesDependsOn, JobDependencyTracker dependencyTracker)
		{
			GCHandle gCHandle = GCHandle.Alloc(nodes);
			JobHandle jobHandle = new JobWriteNodeData
			{
				nodesHandle = gCHandle,
				graphIndex = graphIndex,
				nodePositions = positions,
				nodePenalties = penalties,
				nodeTags = tags,
				nodeConnections = connections,
				nodeWalkableWithErosion = walkableWithErosion,
				nodeWalkable = walkable,
				nodeArrayBounds = nodeArrayBounds,
				dataBounds = bounds,
				writeMask = writeMask
			}.ScheduleBatch(writeMask.volume, math.max(1000, writeMask.volume / 16), dependencyTracker, nodesDependsOn);
			dependencyTracker.DeferFree(gCHandle, jobHandle);
			return jobHandle;
		}
	}
}
