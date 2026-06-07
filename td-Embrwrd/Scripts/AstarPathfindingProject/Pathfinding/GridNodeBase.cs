using System;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public abstract class GridNodeBase : GraphNode
	{
		private const int GridFlagsWalkableErosionOffset = 8;

		private const int GridFlagsWalkableErosionMask = 256;

		private const int GridFlagsWalkableTmpOffset = 9;

		private const int GridFlagsWalkableTmpMask = 512;

		protected const int NodeInGridIndexLayerOffset = 24;

		protected const int NodeInGridIndexMask = 16777215;

		protected int nodeInGridIndex;

		protected ushort gridFlags;

		public Connection[] connections;

		public int NodeInGridIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int XCoordinateInGrid => 0;

		public int ZCoordinateInGrid => 0;

		public bool WalkableErosion
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool TmpWalkable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public abstract bool HasConnectionsToAllEightNeighbours { get; }

		protected GridNodeBase(AstarPath astar)
			: base(null)
		{
		}

		public override float SurfaceArea()
		{
			return 0f;
		}

		public override Vector3 RandomPointOnSurface()
		{
			return default(Vector3);
		}

		public Vector2 NormalizePoint(Vector3 worldPoint)
		{
			return default(Vector2);
		}

		public Vector3 UnNormalizePoint(Vector2 normalizedPointOnSurface)
		{
			return default(Vector3);
		}

		public override int GetGizmoHashCode()
		{
			return 0;
		}

		public abstract GridNodeBase GetNeighbourAlongDirection(int direction);

		public virtual bool HasConnectionInDirection(int direction)
		{
			return false;
		}

		public override bool ContainsConnection(GraphNode node)
		{
			return false;
		}

		public void ClearCustomConnections(bool alsoReverse)
		{
		}

		public override void ClearConnections(bool alsoReverse)
		{
		}

		public override void GetConnections(Action<GraphNode> action)
		{
		}

		public override void UpdateRecursiveG(Path path, PathNode pathNode, PathHandler handler)
		{
		}

		public override void Open(Path path, PathNode pathNode, PathHandler handler)
		{
		}

		public override void AddConnection(GraphNode node, uint cost)
		{
		}

		public override void RemoveConnection(GraphNode node)
		{
		}

		public override void SerializeReferences(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeReferences(GraphSerializationContext ctx)
		{
		}
	}
}
