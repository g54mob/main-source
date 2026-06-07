using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Pathfinding.Sync;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	public class HierarchicalGraph
	{
		public struct HierarhicalNodeData
		{
			[ReadOnly]
			public SlabAllocator<int> connectionAllocator;

			[ReadOnly]
			public NativeList<int> connectionAllocations;

			[ReadOnly]
			public NativeList<Bounds> bounds;
		}

		private struct JobRecalculateComponents : IJob
		{
			private struct Context
			{
				public List<GraphNode> children;

				public int hierarchicalNodeIndex;

				public List<int> connections;

				public uint graphindex;

				public Queue<GraphNode> queue;
			}

			public GCHandle hGraphGC;

			public NativeList<int> connectionAllocations;

			public NativeList<Bounds> bounds;

			public NativeList<int> dirtiedHierarchicalNodes;

			public NativeReference<int> numHierarchicalNodes;

			private void Grow(HierarchicalGraph graph)
			{
			}

			private int GetHierarchicalNodeIndex(HierarchicalGraph graph)
			{
				return 0;
			}

			private void RemoveHierarchicalNode(HierarchicalGraph hGraph, int hierarchicalNode, bool removeAdjacentSmallNodes)
			{
			}

			[Conditional("CHECK_INVARIANTS")]
			private void CheckConnectionInvariants()
			{
			}

			[Conditional("CHECK_INVARIANTS")]
			private void CheckPreUpdateInvariants()
			{
			}

			[Conditional("CHECK_INVARIANTS")]
			private void CheckChildInvariants()
			{
			}

			private void FindHierarchicalNodeChildren(HierarchicalGraph hGraph, int hierarchicalNode, GraphNode startNode)
			{
			}

			private void FloodFill(HierarchicalGraph hGraph)
			{
			}

			public void Execute()
			{
			}
		}

		private const int Tiling = 16;

		private const int MaxChildrenPerNode = 256;

		private const int MinChildrenPerNode = 128;

		private GlobalNodeStorage nodeStorage;

		internal List<GraphNode>[] children;

		internal NativeList<int> connectionAllocations;

		internal SlabAllocator<int> connectionAllocator;

		private NativeList<int> dirtiedHierarchicalNodes;

		private int[] areas;

		private byte[] dirty;

		private int[] versions;

		internal NativeList<Bounds> bounds;

		private NativeReference<int> numHierarchicalNodes;

		internal GCHandle gcHandle;

		public NavmeshEdges navmeshEdges;

		private Queue<GraphNode> temporaryQueue;

		private List<int> currentConnections;

		private Stack<int> temporaryStack;

		private HierarchicalBitset dirtyNodes;

		private CircularBuffer<int> freeNodeIndices;

		private int gizmoVersion;

		private RWLock rwLock;

		public int version { get; private set; }

		public int NumConnectedComponents { get; private set; }

		internal void OnDisable()
		{
		}

		public int GetHierarchicalNodeVersion(int index)
		{
			return 0;
		}

		public HierarhicalNodeData GetHierarhicalNodeData(out RWLock.ReadLockAsync readLock)
		{
			readLock = default(RWLock.ReadLockAsync);
			return default(HierarhicalNodeData);
		}

		internal HierarchicalGraph(GlobalNodeStorage nodeStorage)
		{
		}

		public void OnEnable()
		{
		}

		internal void OnCreatedNode(GraphNode node)
		{
		}

		internal void OnDestroyedNode(GraphNode node)
		{
		}

		public void AddDirtyNode(GraphNode node)
		{
		}

		public void ReserveNodeIndices(uint nodeIndexCount)
		{
		}

		public uint GetConnectedComponent(int hierarchicalNodeIndex)
		{
			return 0u;
		}

		public void RecalculateIfNecessary()
		{
		}

		public JobHandle JobRecalculateIfNecessary(JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public void RecalculateAll()
		{
		}

		public void OnDrawGizmos(DrawingData gizmos, RedrawScope redrawScope)
		{
		}
	}
}
