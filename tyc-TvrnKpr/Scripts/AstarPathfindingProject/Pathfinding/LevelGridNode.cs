using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public class LevelGridNode : GridNodeBase
	{
		private static LayerGridGraph[] _gridGraphs;

		public uint gridConnections;

		protected static LayerGridGraph[] gridGraphs;

		private const int MaxNeighbours = 8;

		public const int ConnectionMask = 15;

		public const int ConnectionStride = 4;

		public const int AxisAlignedConnectionsMask = 65535;

		public const uint AllConnectionsMask = 4294967295u;

		public const int NoConnection = 15;

		internal const ulong DiagonalConnectionsMask = 4294901760uL;

		public const int MaxLayerCount = 15;

		public override bool HasAnyGridConnections => false;

		public override bool HasConnectionsToAllEightNeighbours => false;

		public override bool HasConnectionsToAllAxisAlignedNeighbours => false;

		public int LayerCoordinateInGrid
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public LevelGridNode()
		{
		}

		public LevelGridNode(AstarPath astar)
		{
		}

		public static LayerGridGraph GetGridGraph(uint graphIndex)
		{
			return null;
		}

		public static void SetGridGraph(int graphIndex, LayerGridGraph graph)
		{
		}

		public static void ClearGridGraph(int graphIndex, LayerGridGraph graph)
		{
		}

		public override void ResetConnectionsInternal()
		{
		}

		public void SetPosition(Int3 position)
		{
		}

		public override int GetGizmoHashCode()
		{
			return 0;
		}

		public override GridNodeBase GetNeighbourAlongDirection(int direction)
		{
			return null;
		}

		public override void ClearConnections(bool alsoReverse)
		{
		}

		public override void GetConnections<T>(NodeActionWithData<T> action, ref T data, int connectionFilter)
		{
		}

		public override bool HasConnectionInDirection(int direction)
		{
			return false;
		}

		public void SetConnectionValue(int dir, int value)
		{
		}

		public void SetAllConnectionInternal(ulong value)
		{
		}

		public int GetConnectionValue(int dir)
		{
			return 0;
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
		}

		public override void RemovePartialConnection(GraphNode node)
		{
		}

		protected void RemoveGridConnection(LevelGridNode node)
		{
		}

		public override bool GetPortal(GraphNode other, out Vector3 left, out Vector3 right)
		{
			left = default(Vector3);
			right = default(Vector3);
			return false;
		}

		public override void Open(ref Path.SearchContext ctx, uint pathNodeIndex, uint gScore)
		{
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
		}
	}
}
