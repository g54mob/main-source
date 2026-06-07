using System.Runtime.CompilerServices;
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

		public const int NodeInGridIndexLayerOffset = 24;

		protected const int NodeInGridIndexMask = 16777215;

		protected int nodeInGridIndex;

		protected ushort gridFlags;

		public Connection[] connections;

		internal static readonly int[] offsetToDirection;

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

		public Vector2Int CoordinatesInGrid
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(Vector2Int);
			}
		}

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

		public abstract bool HasConnectionsToAllAxisAlignedNeighbours { get; }

		public abstract bool HasAnyGridConnections { get; }

		public static int OppositeConnectionDirection(int dir)
		{
			return 0;
		}

		public static int OffsetToConnectionDirection(int dx, int dz)
		{
			return 0;
		}

		public Vector3 ProjectOnSurface(Vector3 point)
		{
			return default(Vector3);
		}

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			return default(Vector3);
		}

		public override bool ContainsPoint(Vector3 point)
		{
			return false;
		}

		public override bool ContainsPointInGraphSpace(Int3 point)
		{
			return false;
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

		public override bool ContainsOutgoingConnection(GraphNode node)
		{
			return false;
		}

		public abstract void ResetConnectionsInternal();

		public override void OpenAtPoint(Path path, uint pathNodeIndex, Int3 pos, uint gScore)
		{
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
		}

		public void ClearCustomConnections(bool alsoReverse)
		{
		}

		public override void ClearConnections(bool alsoReverse)
		{
		}

		public override void GetConnections<T>(GetConnectionsWithData<T> action, ref T data, int connectionFilter)
		{
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
		}

		public override void RemovePartialConnection(GraphNode node)
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
