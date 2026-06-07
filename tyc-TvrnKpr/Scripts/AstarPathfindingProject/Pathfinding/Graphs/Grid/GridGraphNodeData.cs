using System.Runtime.CompilerServices;
using Pathfinding.Collections;
using Pathfinding.Jobs;
using Unity.Collections;
using Unity.Jobs;
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

		public int layers => 0;

		public void AllocateBuffers(JobDependencyTracker dependencyTracker)
		{
		}

		public void TrackBuffers(JobDependencyTracker dependencyTracker)
		{
		}

		public void PersistBuffers(JobDependencyTracker dependencyTracker)
		{
		}

		public void Dispose()
		{
		}

		public JobHandle Rotate2D(int dx, int dz, JobHandle dependency)
		{
			return default(JobHandle);
		}

		public void ResizeLayerCount(int layerCount, JobDependencyTracker dependencyTracker)
		{
		}

		public void ReadFromNodesForConnectionCalculations(GridNodeBase[] nodes, Slice3D slice, JobHandle nodesDependsOn, NativeArray<float4> graphNodeNormals, JobDependencyTracker dependencyTracker)
		{
		}

		private void ReadNodeNormals(Slice3D slice, NativeArray<float4> graphNodeNormals, JobDependencyTracker dependencyTracker)
		{
		}

		public static GridGraphNodeData ReadFromNodes(GridNodeBase[] nodes, Slice3D slice, JobHandle nodesDependsOn, NativeArray<float4> graphNodeNormals, Allocator allocator, bool layeredDataLayout, JobDependencyTracker dependencyTracker)
		{
			return default(GridGraphNodeData);
		}

		public GridGraphNodeData ReadFromNodesAndCopy(GridNodeBase[] nodes, Slice3D slice, JobHandle nodesDependsOn, NativeArray<float4> graphNodeNormals, bool copyPenaltyAndTags, JobDependencyTracker dependencyTracker)
		{
			return default(GridGraphNodeData);
		}

		public void CopyFrom(GridGraphNodeData other, bool copyPenaltyAndTags, JobDependencyTracker dependencyTracker)
		{
		}

		public void CopyFrom(GridGraphNodeData other, IntBounds bounds, bool copyPenaltyAndTags, JobDependencyTracker dependencyTracker)
		{
		}

		public JobHandle AssignToNodes(GridNodeBase[] nodes, int3 nodeArrayBounds, IntBounds writeMask, uint graphIndex, JobHandle nodesDependsOn, JobDependencyTracker dependencyTracker)
		{
			return default(JobHandle);
		}
	}
}
