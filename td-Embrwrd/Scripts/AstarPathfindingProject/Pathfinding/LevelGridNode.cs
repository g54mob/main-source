using System;
using System.Collections.Generic;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public class LevelGridNode : GridNodeBase
	{
		private static LayerGridGraph[] _gridGraphs;

		public ulong gridConnections;

		protected static LayerGridGraph[] gridGraphs;

		public const int NoConnection = 255;

		public const int ConnectionMask = 255;

		private const int ConnectionStride = 8;

		public const int MaxLayerCount = 255;

		public override bool HasConnectionsToAllEightNeighbours => false;

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

		public LevelGridNode(AstarPath astar)
			: base(null)
		{
		}

		public static LayerGridGraph GetGridGraph(uint graphIndex)
		{
			return null;
		}

		public static void SetGridGraph(int graphIndex, LayerGridGraph graph)
		{
		}

		public void ResetAllGridConnections()
		{
		}

		public bool HasAnyGridConnections()
		{
			return false;
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

		public override void GetConnections(Action<GraphNode> action)
		{
		}

		[Obsolete("Use HasConnectionInDirection instead")]
		public bool GetConnection(int i)
		{
			return false;
		}

		public override bool HasConnectionInDirection(int direction)
		{
			return false;
		}

		public void SetConnectionValue(int dir, int value)
		{
		}

		public int GetConnectionValue(int dir)
		{
			return 0;
		}

		public override void AddConnection(GraphNode node, uint cost)
		{
		}

		public override void RemoveConnection(GraphNode node)
		{
		}

		protected void RemoveGridConnection(LevelGridNode node)
		{
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

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			return default(Vector3);
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
		}
	}
}
