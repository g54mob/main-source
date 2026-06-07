using System;
using System.Runtime.CompilerServices;
using System.Text;
using Pathfinding.Util;
using Unity.Collections;

namespace Pathfinding
{
	public class PathHandler
	{
		private ushort pathID;

		public readonly int threadID;

		public readonly int totalThreadCount;

		public readonly NNConstraintWithTraversalProvider constraintWrapper = new NNConstraintWithTraversalProvider();

		internal readonly GlobalNodeStorage nodeStorage;

		private UnsafeSpan<TemporaryNode> temporaryNodes;

		public UnsafeSpan<PathNode> pathNodes;

		public BinaryHeap heap = new BinaryHeap(128);

		public readonly StringBuilder DebugStringBuilder = new StringBuilder();

		public int numTemporaryNodes { get; private set; }

		public uint temporaryNodeStartIndex { get; private set; }

		public ushort PathID => pathID;

		internal PathHandler(GlobalNodeStorage nodeStorage, int threadID, int totalThreadCount)
		{
			this.threadID = threadID;
			this.totalThreadCount = totalThreadCount;
			this.nodeStorage = nodeStorage;
			temporaryNodes = default(UnsafeSpan<TemporaryNode>);
		}

		public void InitializeForPath(Path p)
		{
			ushort num = pathID;
			pathID = p.pathID;
			numTemporaryNodes = 0;
			pathNodes = nodeStorage.pathfindingThreadData[threadID].pathNodes;
			temporaryNodeStartIndex = nodeStorage.reservedPathNodeData;
			int num2 = pathNodes.Length - (int)temporaryNodeStartIndex;
			if (num2 > temporaryNodes.Length)
			{
				temporaryNodes = temporaryNodes.Reallocate(Allocator.Persistent, num2);
			}
			if (pathID < num)
			{
				ClearPathIDs();
			}
		}

		public PathNode GetPathNode(GraphNode node, uint variant = 0u)
		{
			return pathNodes[node.NodeIndex + variant];
		}

		public bool IsTemporaryNode(uint pathNodeIndex)
		{
			return pathNodeIndex >= temporaryNodeStartIndex;
		}

		public uint AddTemporaryNode(TemporaryNode node)
		{
			if (numTemporaryNodes >= temporaryNodes.Length)
			{
				nodeStorage.GrowTemporaryNodeStorage(threadID);
				pathNodes = nodeStorage.pathfindingThreadData[threadID].pathNodes;
				temporaryNodes = temporaryNodes.Reallocate(Allocator.Persistent, pathNodes.Length - (int)temporaryNodeStartIndex);
			}
			uint num = temporaryNodeStartIndex + (uint)numTemporaryNodes;
			temporaryNodes[numTemporaryNodes] = node;
			pathNodes[num] = PathNode.Default;
			numTemporaryNodes++;
			return num;
		}

		public GraphNode GetNode(uint nodeIndex)
		{
			return nodeStorage.GetNode(nodeIndex);
		}

		public ref TemporaryNode GetTemporaryNode(uint nodeIndex)
		{
			if (nodeIndex < temporaryNodeStartIndex || nodeIndex >= temporaryNodeStartIndex + numTemporaryNodes)
			{
				throw new ArgumentOutOfRangeException();
			}
			return ref temporaryNodes[(int)(nodeIndex - temporaryNodeStartIndex)];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void LogVisitedNode(uint pathNodeIndex, uint h, uint g)
		{
		}

		public void ClearPathIDs()
		{
			for (int i = 0; i < pathNodes.Length; i++)
			{
				pathNodes[i].pathID = 0;
			}
		}

		public void Dispose()
		{
			heap.Dispose();
			temporaryNodes.Free(Allocator.Persistent);
			pathNodes = default(UnsafeSpan<PathNode>);
		}
	}
}
