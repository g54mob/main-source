using System;
using System.Collections.Generic;
using Pathfinding.Util;

namespace Pathfinding
{
	public class HierarchicalGraph
	{
		private const int Tiling = 16;

		private const int MaxChildrenPerNode = 256;

		private const int MinChildrenPerNode = 128;

		private List<GraphNode>[] children;

		private List<int>[] connections;

		private int[] areas;

		private byte[] dirty;

		public Action onConnectedComponentsChanged;

		private Action<GraphNode> connectionCallback;

		private Queue<GraphNode> temporaryQueue;

		private List<GraphNode> currentChildren;

		private List<int> currentConnections;

		private int currentHierarchicalNodeIndex;

		private Stack<int> temporaryStack;

		private int numDirtyNodes;

		private GraphNode[] dirtyNodes;

		private Stack<int> freeNodeIndices;

		private int gizmoVersion;

		public int version { get; private set; }

		public int NumConnectedComponents { get; private set; }

		private void Grow()
		{
		}

		private int GetHierarchicalNodeIndex()
		{
			return 0;
		}

		internal void OnCreatedNode(GraphNode node)
		{
		}

		public void AddDirtyNode(GraphNode node)
		{
		}

		public uint GetConnectedComponent(int hierarchicalNodeIndex)
		{
			return 0u;
		}

		private void RemoveHierarchicalNode(int hierarchicalNode, bool removeAdjacentSmallNodes)
		{
		}

		public void RecalculateIfNecessary()
		{
		}

		public void RecalculateAll()
		{
		}

		private void FloodFill()
		{
		}

		private void FindHierarchicalNodeChildren(int hierarchicalNode, GraphNode startNode)
		{
		}

		public void OnDrawGizmos(RetainedGizmos gizmos)
		{
		}
	}
}
