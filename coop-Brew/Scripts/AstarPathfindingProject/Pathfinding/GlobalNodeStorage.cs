using System;
using Pathfinding.Collections;
using Unity.Jobs;

namespace Pathfinding
{
	internal class GlobalNodeStorage
	{
		public struct PathfindingThreadData
		{
			public UnsafeSpan<PathNode> pathNodes;
		}

		private class IndexedStack<T>
		{
			private T[] buffer;

			public int Count { get; private set; }

			public void Push(T v)
			{
			}

			public void Clear()
			{
			}

			public T Pop()
			{
				return default(T);
			}

			public void PopMany(T[] resultBuffer, int popCount)
			{
			}
		}

		private struct JobAllocateNodes<T> : IJob where T : GraphNode
		{
			public T[] result;

			public int count;

			public GlobalNodeStorage nodeStorage;

			public uint variantsPerNode;

			public Func<T> createNode;

			public bool allowBoundsChecks => false;

			public void Execute()
			{
			}
		}

		private readonly AstarPath astar;

		private JobHandle lastAllocationJob;

		public uint nextNodeIndex;

		public uint reservedPathNodeData;

		private const int InitialTemporaryNodes = 256;

		private int temporaryNodeCount;

		private readonly IndexedStack<uint>[] nodeIndexPools;

		public PathfindingThreadData[] pathfindingThreadData;

		private GraphNode[] nodes;

		public uint destroyedNodesVersion { get; private set; }

		public GlobalNodeStorage(AstarPath astar)
		{
		}

		public GraphNode GetNode(uint nodeIndex)
		{
			return null;
		}

		private void DisposeThreadData()
		{
		}

		public void SetThreadCount(int threadCount)
		{
		}

		public void GrowTemporaryNodeStorage(int threadID)
		{
		}

		public void InitializeNode(GraphNode node)
		{
		}

		private void ReserveNodeIndices(uint nextNodeIndex)
		{
		}

		public void DestroyNode(GraphNode node)
		{
		}

		public void OnDisable()
		{
		}

		public JobHandle AllocateNodesJob<T>(T[] result, int count, Func<T> createNode, uint variantsPerNode) where T : GraphNode
		{
			return default(JobHandle);
		}
	}
}
