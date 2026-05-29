using System;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public class GridNode : GridNodeBase
	{
		private static GridGraph[] _gridGraphs = new GridGraph[0];

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
				return gridFlags;
			}
			set
			{
				gridFlags = value;
			}
		}

		public override bool HasConnectionsToAllEightNeighbours => (InternalGridFlags & 0xFF) == 255;

		public override bool HasConnectionsToAllAxisAlignedNeighbours => (InternalGridFlags & 0xF) == 15;

		public override bool HasAnyGridConnections => GetAllConnectionInternal() != 0;

		public bool EdgeNode
		{
			get
			{
				return (gridFlags & 0x400) != 0;
			}
			set
			{
				gridFlags = (ushort)((gridFlags & -1025) | (value ? 1024 : 0));
			}
		}

		public GridNode()
		{
		}

		public GridNode(AstarPath astar)
		{
			astar.InitializeNode(this);
		}

		public static GridGraph GetGridGraph(uint graphIndex)
		{
			return _gridGraphs[graphIndex];
		}

		public static void SetGridGraph(int graphIndex, GridGraph graph)
		{
			if (_gridGraphs.Length <= graphIndex)
			{
				GridGraph[] array = new GridGraph[graphIndex + 1];
				for (int i = 0; i < _gridGraphs.Length; i++)
				{
					array[i] = _gridGraphs[i];
				}
				_gridGraphs = array;
			}
			_gridGraphs[graphIndex] = graph;
		}

		public static void ClearGridGraph(int graphIndex, GridGraph graph)
		{
			if (graphIndex < _gridGraphs.Length && _gridGraphs[graphIndex] == graph)
			{
				_gridGraphs[graphIndex] = null;
			}
		}

		public override bool HasConnectionInDirection(int dir)
		{
			return ((gridFlags >> dir) & 1) != 0;
		}

		[Obsolete("Use HasConnectionInDirection")]
		public bool GetConnectionInternal(int dir)
		{
			return HasConnectionInDirection(dir);
		}

		public void SetConnection(int dir, bool value)
		{
			SetConnectionInternal(dir, value);
			GetGridGraph(base.GraphIndex).nodeDataRef.connections[base.NodeInGridIndex] = (ulong)GetAllConnectionInternal();
		}

		public void SetConnectionInternal(int dir, bool value)
		{
			gridFlags = (ushort)((gridFlags & ~(1 << dir)) | ((value ? 1 : 0) << dir));
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
		}

		public void SetAllConnectionInternal(int connections)
		{
			gridFlags = (ushort)((gridFlags & -256) | connections);
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
		}

		public int GetAllConnectionInternal()
		{
			return gridFlags & 0xFF;
		}

		public override void ResetConnectionsInternal()
		{
			gridFlags = (ushort)(gridFlags & -256);
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
		}

		public override GridNodeBase GetNeighbourAlongDirection(int direction)
		{
			if (HasConnectionInDirection(direction))
			{
				GridGraph gridGraph = GetGridGraph(base.GraphIndex);
				return gridGraph.nodes[base.NodeInGridIndex + gridGraph.neighbourOffsets[direction]];
			}
			return null;
		}

		public override void ClearConnections(bool alsoReverse)
		{
			if (alsoReverse)
			{
				for (int i = 0; i < 8; i++)
				{
					if (GetNeighbourAlongDirection(i) is GridNode gridNode)
					{
						gridNode.SetConnectionInternal(GridNodeBase.OppositeConnectionDirection(i), value: false);
					}
				}
			}
			ResetConnectionsInternal();
			base.ClearConnections(alsoReverse);
		}

		public override void GetConnections<T>(GetConnectionsWithData<T> action, ref T data, int connectionFilter)
		{
			if ((connectionFilter & 0x30) == 0)
			{
				return;
			}
			GridGraph gridGraph = GetGridGraph(base.GraphIndex);
			int[] neighbourOffsets = gridGraph.neighbourOffsets;
			GridNodeBase[] nodes = gridGraph.nodes;
			for (int i = 0; i < 8; i++)
			{
				if (((gridFlags >> i) & 1) != 0)
				{
					GridNodeBase gridNodeBase = nodes[base.NodeInGridIndex + neighbourOffsets[i]];
					if (gridNodeBase != null)
					{
						action(gridNodeBase, ref data);
					}
				}
			}
			base.GetConnections(action, ref data, connectionFilter);
		}

		public override bool GetPortal(GraphNode other, out Vector3 left, out Vector3 right)
		{
			if (other.GraphIndex != base.GraphIndex)
			{
				left = (right = Vector3.zero);
				return false;
			}
			GridGraph gridGraph = GetGridGraph(base.GraphIndex);
			Int2 @int = (other as GridNode).CoordinatesInGrid - base.CoordinatesInGrid;
			int num = GridNodeBase.OffsetToConnectionDirection(@int.x, @int.y);
			if (num == -1 || !HasConnectionInDirection(num))
			{
				left = (right = Vector3.zero);
				return false;
			}
			if (num < 4)
			{
				Vector3 vector = (Vector3)(position + other.position) * 0.5f;
				Vector3 vector2 = Vector3.Cross(gridGraph.collision.up, (Vector3)(other.position - position));
				vector2.Normalize();
				vector2 *= gridGraph.nodeSize * 0.5f;
				left = vector - vector2;
				right = vector + vector2;
			}
			else
			{
				bool flag = false;
				bool flag2 = false;
				if (HasConnectionInDirection(num - 4))
				{
					GridNodeBase gridNodeBase = gridGraph.nodes[base.NodeInGridIndex + gridGraph.neighbourOffsets[num - 4]];
					if (gridNodeBase.Walkable && gridNodeBase.HasConnectionInDirection((num - 4 + 1) % 4))
					{
						flag = true;
					}
				}
				if (HasConnectionInDirection((num - 4 + 1) % 4))
				{
					GridNodeBase gridNodeBase2 = gridGraph.nodes[base.NodeInGridIndex + gridGraph.neighbourOffsets[(num - 4 + 1) % 4]];
					if (gridNodeBase2.Walkable && gridNodeBase2.HasConnectionInDirection(num - 4))
					{
						flag2 = true;
					}
				}
				Vector3 vector3 = (Vector3)(position + other.position) * 0.5f;
				Vector3 vector4 = Vector3.Cross(gridGraph.collision.up, (Vector3)(other.position - position));
				vector4.Normalize();
				vector4 *= gridGraph.nodeSize * 1.4142f;
				left = vector3 - (flag2 ? vector4 : Vector3.zero);
				right = vector3 + (flag ? vector4 : Vector3.zero);
			}
			return true;
		}

		public static int FilterDiagonalConnections(int conns, NumNeighbours neighbours, bool cutCorners)
		{
			switch (neighbours)
			{
			case NumNeighbours.Four:
				return conns & 0xF;
			default:
			{
				if (cutCorners)
				{
					int num = conns & 0xF;
					int num2 = (num | ((num >> 1) | (num << 3))) << 4;
					num2 &= conns;
					return num | num2;
				}
				int num3 = conns & 0xF;
				int num4 = (num3 & ((num3 >> 1) | (num3 << 3))) << 4;
				num4 &= conns;
				return num3 | num4;
			}
			case NumNeighbours.Six:
				return conns & 0xAF;
			}
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
			GridGraph gridGraph = GetGridGraph(base.GraphIndex);
			int[] neighbourOffsets = gridGraph.neighbourOffsets;
			uint[] neighbourCosts = gridGraph.neighbourCosts;
			GridNodeBase[] nodes = gridGraph.nodes;
			int num = base.NodeInGridIndex;
			int num2 = gridFlags & 0xFF;
			for (int i = 0; i < 8; i++)
			{
				if (i == 4 && (path.traversalProvider == null || path.traversalProvider.filterDiagonalGridConnections))
				{
					num2 = FilterDiagonalConnections(num2, gridGraph.neighbours, gridGraph.cutCorners);
				}
				if (((num2 >> i) & 1) != 0)
				{
					GridNodeBase gridNodeBase = nodes[num + neighbourOffsets[i]];
					if (path.CanTraverse(this, gridNodeBase))
					{
						path.OpenCandidateConnection(pathNodeIndex, gridNodeBase.NodeIndex, gScore, neighbourCosts[i], 0u, gridNodeBase.position);
					}
					else
					{
						num2 &= ~(1 << i);
					}
				}
			}
			base.Open(path, pathNodeIndex, gScore);
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
			base.SerializeNode(ctx);
			ctx.SerializeInt3(position);
			ctx.writer.Write(gridFlags);
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
			base.DeserializeNode(ctx);
			position = ctx.DeserializeInt3();
			gridFlags = ctx.reader.ReadUInt16();
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
			if (node is GridNode gridNode && gridNode.GraphIndex == base.GraphIndex)
			{
				RemoveGridConnection(gridNode);
			}
			base.AddPartialConnection(node, cost, isOutgoing, isIncoming);
		}

		public override void RemovePartialConnection(GraphNode node)
		{
			base.RemovePartialConnection(node);
			if (node is GridNode gridNode && gridNode.GraphIndex == base.GraphIndex)
			{
				RemoveGridConnection(gridNode);
			}
		}

		protected void RemoveGridConnection(GridNode node)
		{
			int num = base.NodeInGridIndex;
			GridGraph gridGraph = GetGridGraph(base.GraphIndex);
			for (int i = 0; i < 8; i++)
			{
				if (num + gridGraph.neighbourOffsets[i] == node.NodeInGridIndex && GetNeighbourAlongDirection(i) == node)
				{
					SetConnectionInternal(i, value: false);
					break;
				}
			}
		}
	}
}
