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
			temporaryNodes = new UnsafeSpan<TemporaryNode>(Allocator.Persistent, 4096);
		}

		public void InitializeForPath(Path p)
		{
			ushort num = pathID;
			pathID = p.pathID;
			numTemporaryNodes = 0;
			temporaryNodeStartIndex = nodeStorage.nextNodeIndex;
			pathNodes = nodeStorage.pathfindingThreadData[threadID].pathNodes;
			if (pathID < num)
			{
				ClearPathIDs();
			}
		}

		public ref PathNode GetPathNode(GraphNode node, uint variant = 0u)
		{
			return ref pathNodes[node.NodeIndex + variant];
		}

		public bool IsTemporaryNode(uint pathNodeIndex)
		{
			return pathNodeIndex >= temporaryNodeStartIndex;
		}

		public uint AddTemporaryNode(TemporaryNode node)
		{
			if (numTemporaryNodes >= 4096)
			{
				throw new InvalidOperationException("Cannot create more than " + 4096 + " temporary nodes. You can enable ASTAR_MORE_MULTI_TARGET_PATH_TARGETS in the A* Inspector optimizations tab to increase this limit.");
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
