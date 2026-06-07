using System;
using System.Collections.Generic;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public class GridNode : GridNodeBase
	{
		private static GridGraph[] _gridGraphs;

		private const int GridFlagsConnectionOffset = 0;

		private const int GridFlagsConnectionBit0 = 1;

		private const int GridFlagsConnectionMask = 255;

		private const int GridFlagsEdgeNodeOffset = 10;

		private const int GridFlagsEdgeNodeMask = 1024;

		internal ushort InternalGridFlags
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override bool HasConnectionsToAllEightNeighbours => false;

		public bool EdgeNode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public GridNode(AstarPath astar)
			: base(null)
		{
		}

		public static GridGraph GetGridGraph(uint graphIndex)
		{
			return null;
		}

		public static void SetGridGraph(int graphIndex, GridGraph graph)
		{
		}

		public static void ClearGridGraph(int graphIndex, GridGraph graph)
		{
		}

		public override bool HasConnectionInDirection(int dir)
		{
			return false;
		}

		[Obsolete("Use HasConnectionInDirection")]
		public bool GetConnectionInternal(int dir)
		{
			return false;
		}

		public void SetConnectionInternal(int dir, bool value)
		{
		}

		public void SetAllConnectionInternal(int connections)
		{
		}

		public void ResetConnectionsInternal()
		{
		}

		public override GridNodeBase GetNeighbourAlongDirection(int direction)
		{
			return null;
		}

		public override void ClearConnections(bool alsoReverse)
		{
		}

		public override void GetConnections(Action<GraphNode> action)
		{
		}

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			return default(Vector3);
		}

		public override bool GetPortal(GraphNode other, List<Vector3> left, List<Vector3> right, bool backwards)
		{
			return false;
		}

		public override void UpdateRecursiveG(Path path, PathNode pathNode, PathHandler handler)
		{
		}

		public override void Open(Path path, PathNode pathNode, PathHandler handler)
		{
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
		}

		public override void AddConnection(GraphNode node, uint cost)
		{
		}

		public override void RemoveConnection(GraphNode node)
		{
		}

		protected void RemoveGridConnection(GridNode node)
		{
		}
	}
}
