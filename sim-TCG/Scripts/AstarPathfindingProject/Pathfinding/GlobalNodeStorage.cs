using System;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

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
			private T[] buffer = new T[4];

			public int Count { get; private set; }

			public void Push(T v)
			{
				if (Count == buffer.Length)
				{
					Memory.Realloc(ref buffer, buffer.Length * 2);
				}
				buffer[Count] = v;
				Count++;
			}

			public void Clear()
			{
				Count = 0;
			}

			public T Pop()
			{
				Count--;
				return buffer[Count];
			}

			public void PopMany(T[] resultBuffer, int popCount)
			{
				if (popCount > Count)
				{
					throw new IndexOutOfRangeException();
				}
				Array.Copy(buffer, Count - popCount, resultBuffer, 0, popCount);
				Count -= popCount;
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
				HierarchicalGraph hierarchicalGraph = nodeStorage.astar.hierarchicalGraph;
				lock (nodeStorage)
				{
					IndexedStack<uint> indexedStack = nodeStorage.nodeIndexPools[variantsPerNode - 1];
					uint num = nodeStorage.nextNodeIndex;
					for (uint num2 = 0u; num2 < count; num2++)
					{
						T val = (result[num2] = createNode());
						if (indexedStack.Count > 0)
						{
							val.NodeIndex = indexedStack.Pop();
							continue;
						}
						val.NodeIndex = num;
						num += variantsPerNode;
					}
					nodeStorage.ReserveNodeIndices(num);
					nodeStorage.nextNodeIndex = num;
					for (int i = 0; i < count; i++)
					{
						T val2 = result[i];
						hierarchicalGraph.AddDirtyNode(val2);
						nodeStorage.nodes[val2.NodeIndex] = val2;
					}
				}
			}
		}

		private readonly AstarPath astar;

		private JobHandle lastAllocationJob;

		public uint nextNodeIndex = 1u;

		private uint reservedPathNodeData;

		public const int MaxTemporaryNodes = 4096;

		private readonly IndexedStack<uint>[] nodeIndexPools = new IndexedStack<uint>[3]
		{
			new IndexedStack<uint>(),
			new IndexedStack<uint>(),
			new IndexedStack<uint>()
		};

		public PathfindingThreadData[] pathfindingThreadData = new PathfindingThreadData[0];

		private GraphNode[] nodes = new GraphNode[0];

		public uint destroyedNodesVersion { get; private set; }

		public GlobalNodeStorage(AstarPath astar)
		{
			this.astar = astar;
		}

		public GraphNode GetNode(uint nodeIndex)
		{
			return nodes[nodeIndex];
		}

		private void DisposeThreadData()
		{
			if (pathfindingThreadData.Length != 0)
			{
				for (int i = 0; i < pathfindingThreadData.Length; i++)
				{
					pathfindingThreadData[i].pathNodes.Free(Allocator.Persistent);
				}
				pathfindingThreadData = new PathfindingThreadData[0];
			}
		}

		public void SetThreadCount(int threadCount)
		{
			if (pathfindingThreadData.Length != threadCount)
			{
				DisposeThreadData();
				pathfindingThreadData = new PathfindingThreadData[threadCount];
				for (int i = 0; i < pathfindingThreadData.Length; i++)
				{
					pathfindingThreadData[i].pathNodes = new UnsafeSpan<PathNode>(Allocator.Persistent, (int)(reservedPathNodeData + 4096));
					pathfindingThreadData[i].pathNodes.Fill(PathNode.Default);
				}
			}
		}

		public void InitializeNode(GraphNode node)
		{
			int pathNodeVariants = node.PathNodeVariants;
			lock (this)
			{
				if (nodeIndexPools[pathNodeVariants - 1].Count > 0)
				{
					node.NodeIndex = nodeIndexPools[pathNodeVariants - 1].Pop();
				}
				else
				{
					node.NodeIndex = nextNodeIndex;
					nextNodeIndex += (uint)pathNodeVariants;
					ReserveNodeIndices(nextNodeIndex);
				}
				for (int i = 0; i < pathNodeVariants; i++)
				{
					nodes[node.NodeIndex + i] = node;
				}
				astar.hierarchicalGraph.OnCreatedNode(node);
			}
		}

		private void ReserveNodeIndices(uint nextNodeIndex)
		{
			if (nextNodeIndex > reservedPathNodeData)
			{
				reservedPathNodeData = math.ceilpow2(nextNodeIndex);
				astar.hierarchicalGraph.ReserveNodeIndices(reservedPathNodeData);
				int threadCount = pathfindingThreadData.Length;
				DisposeThreadData();
				SetThreadCount(threadCount);
				Memory.Realloc(ref nodes, (int)reservedPathNodeData);
			}
		}

		public void DestroyNode(GraphNode node)
		{
			uint nodeIndex = node.NodeIndex;
			if (nodeIndex == 268435454)
			{
				return;
			}
			destroyedNodesVersion++;
			int pathNodeVariants = node.PathNodeVariants;
			nodeIndexPools[pathNodeVariants - 1].Push(nodeIndex);
			for (int i = 0; i < pathNodeVariants; i++)
			{
				nodes[nodeIndex + i] = null;
			}
			for (int j = 0; j < this.pathfindingThreadData.Length; j++)
			{
				PathfindingThreadData pathfindingThreadData = this.pathfindingThreadData[j];
				for (uint num = 0u; num < pathNodeVariants; num++)
				{
					pathfindingThreadData.pathNodes[nodeIndex + num].pathID = 0;
				}
			}
			astar.hierarchicalGraph.OnDestroyedNode(node);
		}

		public void OnDisable()
		{
			lastAllocationJob.Complete();
			nextNodeIndex = 1u;
			reservedPathNodeData = 0u;
			for (int i = 0; i < nodeIndexPools.Length; i++)
			{
				nodeIndexPools[i].Clear();
			}
			nodes = new GraphNode[0];
			DisposeThreadData();
		}

		public JobHandle AllocateNodesJob<T>(T[] result, int count, Func<T> createNode, uint variantsPerNode) where T : GraphNode
		{
			lastAllocationJob = new JobAllocateNodes<T>
			{
				result = result,
				count = count,
				nodeStorage = this,
				variantsPerNode = variantsPerNode,
				createNode = createNode
			}.ScheduleManaged(lastAllocationJob);
			return lastAllocationJob;
		}
	}
}
