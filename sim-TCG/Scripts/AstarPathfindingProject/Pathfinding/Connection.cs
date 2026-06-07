using System.Runtime.CompilerServices;

namespace Pathfinding
{
	public struct Connection
	{
		public GraphNode node;

		public uint cost;

		public byte shapeEdgeInfo;

		public const byte NoSharedEdge = 15;

		public const byte IncomingConnection = 16;

		public const byte OutgoingConnection = 32;

		public const byte IdenticalEdge = 64;

		public int shapeEdge => shapeEdgeInfo & 3;

		public int adjacentShapeEdge => (shapeEdgeInfo >> 2) & 3;

		public bool edgesAreIdentical => (shapeEdgeInfo & 0x40) != 0;

		public bool isEdgeShared => (shapeEdgeInfo & 0xF) != 15;

		public bool isOutgoing => (shapeEdgeInfo & 0x20) != 0;

		public bool isIncoming => (shapeEdgeInfo & 0x10) != 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Connection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
			this.node = node;
			this.cost = cost;
			shapeEdgeInfo = PackShapeEdgeInfo(isOutgoing, isIncoming);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte PackShapeEdgeInfo(bool isOutgoing, bool isIncoming)
		{
			return (byte)(0xF | (isIncoming ? 16 : 0) | (isOutgoing ? 32 : 0));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte PackShapeEdgeInfo(byte shapeEdge, byte adjacentShapeEdge, bool areEdgesIdentical, bool isOutgoing, bool isIncoming)
		{
			return (byte)(shapeEdge | (adjacentShapeEdge << 2) | (areEdgesIdentical ? 64 : 0) | (isOutgoing ? 32 : 0) | (isIncoming ? 16 : 0));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Connection(GraphNode node, uint cost, byte shapeEdgeInfo)
		{
			this.node = node;
			this.cost = cost;
			this.shapeEdgeInfo = shapeEdgeInfo;
		}

		public override int GetHashCode()
		{
			return node.GetHashCode() ^ (int)cost;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Connection connection))
			{
				return false;
			}
			if (connection.node == node && connection.cost == cost)
			{
				return connection.shapeEdgeInfo == shapeEdgeInfo;
			}
			return false;
		}
	}
}
