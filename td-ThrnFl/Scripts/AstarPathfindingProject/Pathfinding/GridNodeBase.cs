using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public abstract class GridNodeBase : GraphNode
	{
		private const int GridFlagsWalkableErosionOffset = 8;

		private const int GridFlagsWalkableErosionMask = 256;

		private const int GridFlagsWalkableTmpOffset = 9;

		private const int GridFlagsWalkableTmpMask = 512;

		public const int NodeInGridIndexLayerOffset = 24;

		protected const int NodeInGridIndexMask = 16777215;

		protected int nodeInGridIndex;

		protected ushort gridFlags;

		internal static readonly int[] offsetToDirection = new int[9] { 7, 0, 4, 3, -1, 1, 6, 2, 5 };

		public int NodeInGridIndex
		{
			get
			{
				return nodeInGridIndex & 0xFFFFFF;
			}
			set
			{
				nodeInGridIndex = (nodeInGridIndex & -16777216) | value;
			}
		}

		public int XCoordinateInGrid => NodeInGridIndex % GridNode.GetGridGraph(base.GraphIndex).width;

		public int ZCoordinateInGrid => NodeInGridIndex / GridNode.GetGridGraph(base.GraphIndex).width;

		public Int2 CoordinatesInGrid
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				int width = GridNode.GetGridGraph(base.GraphIndex).width;
				int num = NodeInGridIndex;
				int num2 = num / width;
				return new Int2(num - num2 * width, num2);
			}
		}

		public bool WalkableErosion
		{
			get
			{
				return (gridFlags & 0x100) != 0;
			}
			set
			{
				gridFlags = (ushort)((gridFlags & -257) | (value ? 256 : 0));
			}
		}

		public bool TmpWalkable
		{
			get
			{
				return (gridFlags & 0x200) != 0;
			}
			set
			{
				gridFlags = (ushort)((gridFlags & -513) | (value ? 512 : 0));
			}
		}

		public abstract bool HasConnectionsToAllEightNeighbours { get; }

		public abstract bool HasConnectionsToAllAxisAlignedNeighbours { get; }

		public abstract bool HasAnyGridConnections { get; }

		public static int OppositeConnectionDirection(int dir)
		{
			if (dir >= 4)
			{
				return (dir - 2) % 4 + 4;
			}
			return (dir + 2) % 4;
		}

		public static int OffsetToConnectionDirection(int dx, int dz)
		{
			dx++;
			dz++;
			if ((uint)dx > 2u || (uint)dz > 2u)
			{
				return -1;
			}
			return offsetToDirection[3 * dz + dx];
		}

		public Vector3 ProjectOnSurface(Vector3 point)
		{
			GridGraph gridGraph = GridNode.GetGridGraph(base.GraphIndex);
			Vector3 vector = (Vector3)position;
			Vector3 vector2 = gridGraph.transform.WorldUpAtGraphPosition(vector);
			return point - vector2 * Vector3.Dot(vector2, point - vector);
		}

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			GridGraph gridGraph = GridNode.GetGridGraph(base.GraphIndex);
			Vector3 vector = (Vector3)position;
			Vector3 dir = gridGraph.transform.InverseTransformVector(p - vector);
			dir.y = 0f;
			dir.x = Mathf.Clamp(dir.x, -0.5f, 0.5f);
			dir.z = Mathf.Clamp(dir.z, -0.5f, 0.5f);
			return vector + gridGraph.transform.TransformVector(dir);
		}

		public override bool ContainsPoint(Vector3 point)
		{
			GridGraph gridGraph = base.Graph as GridGraph;
			return ContainsPointInGraphSpace((Int3)gridGraph.transform.InverseTransform(point));
		}

		public override bool ContainsPointInGraphSpace(Int3 point)
		{
			int num = XCoordinateInGrid * 1000;
			int num2 = ZCoordinateInGrid * 1000;
			if (point.x >= num && point.x <= num + 1000 && point.z >= num2)
			{
				return point.z <= num2 + 1000;
			}
			return false;
		}

		public override float SurfaceArea()
		{
			GridGraph gridGraph = GridNode.GetGridGraph(base.GraphIndex);
			return gridGraph.nodeSize * gridGraph.nodeSize;
		}

		public override Vector3 RandomPointOnSurface()
		{
			GridGraph gridGraph = GridNode.GetGridGraph(base.GraphIndex);
			Vector3 vector = gridGraph.transform.InverseTransform((Vector3)position);
			float2 float5 = AstarMath.ThreadSafeRandomFloat2();
			return gridGraph.transform.Transform(vector + new Vector3(float5.x - 0.5f, 0f, float5.y - 0.5f));
		}

		public Vector2 NormalizePoint(Vector3 worldPoint)
		{
			Vector3 vector = GridNode.GetGridGraph(base.GraphIndex).transform.InverseTransform(worldPoint);
			return new Vector2(vector.x - (float)XCoordinateInGrid, vector.z - (float)ZCoordinateInGrid);
		}

		public Vector3 UnNormalizePoint(Vector2 normalizedPointOnSurface)
		{
			GridGraph gridGraph = GridNode.GetGridGraph(base.GraphIndex);
			return (Vector3)position + gridGraph.transform.TransformVector(new Vector3(normalizedPointOnSurface.x - 0.5f, 0f, normalizedPointOnSurface.y - 0.5f));
		}

		public override int GetGizmoHashCode()
		{
			return base.GetGizmoHashCode() ^ (109 * gridFlags);
		}

		public abstract GridNodeBase GetNeighbourAlongDirection(int direction);

		public virtual bool HasConnectionInDirection(int direction)
		{
			return GetNeighbourAlongDirection(direction) != null;
		}

		public override bool ContainsOutgoingConnection(GraphNode node)
		{
			for (int i = 0; i < 8; i++)
			{
				if (node == GetNeighbourAlongDirection(i))
				{
					return true;
				}
			}
			return false;
		}

		public abstract void ResetConnectionsInternal();

		public override void OpenAtPoint(Path path, uint pathNodeIndex, Int3 pos, uint gScore)
		{
			path.OpenCandidateConnectionsToEndNode(pos, pathNodeIndex, pathNodeIndex, gScore);
			path.OpenCandidateConnection(pathNodeIndex, base.NodeIndex, gScore, 0u, 0u, position);
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
			path.OpenCandidateConnectionsToEndNode(position, pathNodeIndex, pathNodeIndex, gScore);
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
			throw new NotImplementedException("GridNodes do not have support for adding manual connections with your current settings.\nPlease disable ASTAR_GRID_NO_CUSTOM_CONNECTIONS in the Optimizations tab in the A* Inspector");
		}

		public override void RemovePartialConnection(GraphNode node)
		{
		}

		public void ClearCustomConnections(bool alsoReverse)
		{
		}
	}
}
