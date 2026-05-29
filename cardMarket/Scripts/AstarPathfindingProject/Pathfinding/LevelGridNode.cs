using System;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public class LevelGridNode : GridNodeBase
	{
		private static LayerGridGraph[] _gridGraphs = new LayerGridGraph[0];

		public uint gridConnections;

		protected static LayerGridGraph[] gridGraphs;

		private const int MaxNeighbours = 8;

		public const int ConnectionMask = 15;

		public const int ConnectionStride = 4;

		public const int AxisAlignedConnectionsMask = 65535;

		public const uint AllConnectionsMask = uint.MaxValue;

		public const int NoConnection = 15;

		internal const ulong DiagonalConnectionsMask = 4294901760uL;

		public const int MaxLayerCount = 15;

		public override bool HasAnyGridConnections => gridConnections != uint.MaxValue;

		public override bool HasConnectionsToAllEightNeighbours
		{
			get
			{
				for (int i = 0; i < 8; i++)
				{
					if (!HasConnectionInDirection(i))
					{
						return false;
					}
				}
				return true;
			}
		}

		public override bool HasConnectionsToAllAxisAlignedNeighbours => (gridConnections & 0xFFFF) == 65535;

		public int LayerCoordinateInGrid
		{
			get
			{
				return nodeInGridIndex >> 24;
			}
			set
			{
				nodeInGridIndex = (nodeInGridIndex & 0xFFFFFF) | (value << 24);
			}
		}

		public LevelGridNode()
		{
		}

		public LevelGridNode(AstarPath astar)
		{
			astar.InitializeNode(this);
		}

		public static LayerGridGraph GetGridGraph(uint graphIndex)
		{
			return _gridGraphs[graphIndex];
		}

		public static void SetGridGraph(int graphIndex, LayerGridGraph graph)
		{
			GridNode.SetGridGraph(graphIndex, graph);
			if (_gridGraphs.Length <= graphIndex)
			{
				LayerGridGraph[] array = new LayerGridGraph[graphIndex + 1];
				for (int i = 0; i < _gridGraphs.Length; i++)
				{
					array[i] = _gridGraphs[i];
				}
				_gridGraphs = array;
			}
			_gridGraphs[graphIndex] = graph;
		}

		public static void ClearGridGraph(int graphIndex, LayerGridGraph graph)
		{
			if (graphIndex < _gridGraphs.Length && _gridGraphs[graphIndex] == graph)
			{
				_gridGraphs[graphIndex] = null;
			}
		}

		public override void ResetConnectionsInternal()
		{
			gridConnections = uint.MaxValue;
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
		}

		public void SetPosition(Int3 position)
		{
			base.position = position;
		}

		public override int GetGizmoHashCode()
		{
			return base.GetGizmoHashCode() ^ (int)((805306457L * (long)gridConnections) ^ (402653189L * (long)gridConnections));
		}

		public override GridNodeBase GetNeighbourAlongDirection(int direction)
		{
			int connectionValue = GetConnectionValue(direction);
			if (connectionValue != 15)
			{
				LayerGridGraph gridGraph = GetGridGraph(base.GraphIndex);
				return gridGraph.nodes[base.NodeInGridIndex + gridGraph.neighbourOffsets[direction] + gridGraph.lastScannedWidth * gridGraph.lastScannedDepth * connectionValue];
			}
			return null;
		}

		public override void ClearConnections(bool alsoReverse)
		{
			if (alsoReverse)
			{
				LayerGridGraph gridGraph = GetGridGraph(base.GraphIndex);
				int[] neighbourOffsets = gridGraph.neighbourOffsets;
				GridNodeBase[] nodes = gridGraph.nodes;
				for (int i = 0; i < 8; i++)
				{
					int connectionValue = GetConnectionValue(i);
					if (connectionValue != 15 && nodes[base.NodeInGridIndex + neighbourOffsets[i] + gridGraph.lastScannedWidth * gridGraph.lastScannedDepth * connectionValue] is LevelGridNode levelGridNode)
					{
						levelGridNode.SetConnectionValue((i + 2) % 4, 15);
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
			LayerGridGraph gridGraph = GetGridGraph(base.GraphIndex);
			int[] neighbourOffsets = gridGraph.neighbourOffsets;
			GridNodeBase[] nodes = gridGraph.nodes;
			int num = base.NodeInGridIndex;
			for (int i = 0; i < 8; i++)
			{
				int connectionValue = GetConnectionValue(i);
				if (connectionValue != 15)
				{
					GridNodeBase gridNodeBase = nodes[num + neighbourOffsets[i] + gridGraph.lastScannedWidth * gridGraph.lastScannedDepth * connectionValue];
					if (gridNodeBase != null)
					{
						action(gridNodeBase, ref data);
					}
				}
			}
			base.GetConnections(action, ref data, connectionFilter);
		}

		[Obsolete("Use HasConnectionInDirection instead")]
		public bool GetConnection(int i)
		{
			return ((gridConnections >> i * 4) & 0xF) != 15;
		}

		public override bool HasConnectionInDirection(int direction)
		{
			return ((gridConnections >> direction * 4) & 0xF) != 15;
		}

		public void SetConnectionValue(int dir, int value)
		{
			gridConnections = (gridConnections & (uint)(~(15 << dir * 4))) | (uint)(value << dir * 4);
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
		}

		public void SetAllConnectionInternal(ulong value)
		{
			gridConnections = (uint)value;
		}

		public int GetConnectionValue(int dir)
		{
			return (int)((gridConnections >> dir * 4) & 0xF);
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
			if (node is LevelGridNode levelGridNode && levelGridNode.GraphIndex == base.GraphIndex)
			{
				RemoveGridConnection(levelGridNode);
			}
			base.AddPartialConnection(node, cost, isOutgoing, isIncoming);
		}

		public override void RemovePartialConnection(GraphNode node)
		{
			base.RemovePartialConnection(node);
			if (node is LevelGridNode levelGridNode && levelGridNode.GraphIndex == base.GraphIndex)
			{
				RemoveGridConnection(levelGridNode);
			}
		}

		protected void RemoveGridConnection(LevelGridNode node)
		{
			int num = base.NodeInGridIndex;
			LayerGridGraph gridGraph = GetGridGraph(base.GraphIndex);
			for (int i = 0; i < 8; i++)
			{
				if (num + gridGraph.neighbourOffsets[i] == node.NodeInGridIndex && GetNeighbourAlongDirection(i) == node)
				{
					SetConnectionValue(i, 15);
					break;
				}
			}
		}

		public override bool GetPortal(GraphNode other, out Vector3 left, out Vector3 right)
		{
			LayerGridGraph gridGraph = GetGridGraph(base.GraphIndex);
			int[] neighbourOffsets = gridGraph.neighbourOffsets;
			GridNodeBase[] nodes = gridGraph.nodes;
			int num = base.NodeInGridIndex;
			for (int i = 0; i < 8; i++)
			{
				int connectionValue = GetConnectionValue(i);
				if (connectionValue != 15 && other == nodes[num + neighbourOffsets[i] + gridGraph.lastScannedWidth * gridGraph.lastScannedDepth * connectionValue])
				{
					Vector3 vector = (Vector3)(position + other.position) * 0.5f;
					Vector3 vector2 = Vector3.Cross(gridGraph.collision.up, (Vector3)(other.position - position));
					vector2.Normalize();
					vector2 *= gridGraph.nodeSize * 0.5f;
					left = vector - vector2;
					right = vector + vector2;
					return true;
				}
			}
			left = Vector3.zero;
			right = Vector3.zero;
			return false;
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
			LayerGridGraph gridGraph = GetGridGraph(base.GraphIndex);
			int[] neighbourOffsets = gridGraph.neighbourOffsets;
			uint[] neighbourCosts = gridGraph.neighbourCosts;
			GridNodeBase[] nodes = gridGraph.nodes;
			int num = base.NodeInGridIndex;
			int num2 = 255;
			for (int i = 0; i < 8; i++)
			{
				if (i == 4 && (path.traversalProvider == null || path.traversalProvider.filterDiagonalGridConnections))
				{
					num2 = GridNode.FilterDiagonalConnections(num2, gridGraph.neighbours, gridGraph.cutCorners);
				}
				int connectionValue = GetConnectionValue(i);
				if (connectionValue != 15 && ((num2 >> i) & 1) != 0)
				{
					GraphNode graphNode = nodes[num + neighbourOffsets[i] + gridGraph.lastScannedWidth * gridGraph.lastScannedDepth * connectionValue];
					if (!path.CanTraverse(this, graphNode))
					{
						num2 &= ~(1 << i);
					}
					else
					{
						path.OpenCandidateConnection(pathNodeIndex, graphNode.NodeIndex, gScore, neighbourCosts[i], 0u, graphNode.position);
					}
				}
				else
				{
					num2 &= ~(1 << i);
				}
			}
			base.Open(path, pathNodeIndex, gScore);
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
			base.SerializeNode(ctx);
			ctx.SerializeInt3(position);
			ctx.writer.Write(gridFlags);
			ulong num = 0uL;
			for (int i = 0; i < 8; i++)
			{
				num |= (ulong)((long)GetConnectionValue(i) << i * 8);
			}
			ctx.writer.Write(num);
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
			base.DeserializeNode(ctx);
			position = ctx.DeserializeInt3();
			gridFlags = ctx.reader.ReadUInt16();
			if (ctx.meta.version < AstarSerializer.V4_3_12)
			{
				ulong num = ((!(ctx.meta.version < AstarSerializer.V3_9_0)) ? ctx.reader.ReadUInt64() : ((ulong)ctx.reader.ReadUInt32() | 0xF0F0F0F00000000uL));
				gridConnections = 0u;
				for (int i = 0; i < 8; i++)
				{
					ulong num2 = (num >> i * 8) & 0xFF;
					if ((num2 & 0xF) != num2)
					{
						num2 = 15uL;
					}
					SetConnectionValue(i, (int)num2);
				}
				return;
			}
			ulong num3 = ctx.reader.ReadUInt64();
			uint num4 = 0u;
			if (ctx.meta.version < AstarSerializer.V4_3_83)
			{
				num4 = (uint)num3;
			}
			else
			{
				for (int j = 0; j < 8; j++)
				{
					num4 |= (uint)(((int)(num3 >> j * 8) & 0xF) << 4 * j);
				}
			}
			gridConnections = num4;
		}
	}
}
