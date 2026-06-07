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

		private const int GridFlagsAxisAlignedConnectionMask = 15;

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

		public override bool HasConnectionsToAllAxisAlignedNeighbours => false;

		public override bool HasAnyGridConnections => false;

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

		public GridNode()
		{
		}

		public GridNode(AstarPath astar)
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

		public void SetConnection(int dir, bool value)
		{
		}

		public void SetConnectionInternal(int dir, bool value)
		{
		}

		public void SetAllConnectionInternal(int connections)
		{
		}

		public int GetAllConnectionInternal()
		{
			return 0;
		}

		public override void ResetConnectionsInternal()
		{
		}

		public override GridNodeBase GetNeighbourAlongDirection(int direction)
		{
			return null;
		}

		public override void ClearConnections(bool alsoReverse)
		{
		}

		public override void GetConnections<T>(GetConnectionsWithData<T> action, ref T data, int connectionFilter)
		{
		}

		public override bool GetPortal(GraphNode other, out Vector3 left, out Vector3 right)
		{
			left = default(Vector3);
			right = default(Vector3);
			return false;
		}

		public static int FilterDiagonalConnections(int conns, NumNeighbours neighbours, bool cutCorners)
		{
			return 0;
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
		}

		public override void RemovePartialConnection(GraphNode node)
		{
		}

		protected void RemoveGridConnection(GridNode node)
		{
		}
	}
}
