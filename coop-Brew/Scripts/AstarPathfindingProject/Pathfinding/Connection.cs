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

		public int shapeEdge => 0;

		public int adjacentShapeEdge => 0;

		public bool edgesAreIdentical => false;

		public bool isEdgeShared => false;

		public bool isOutgoing => false;

		public bool isIncoming => false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Connection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
			this.node = null;
			this.cost = 0u;
			shapeEdgeInfo = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte PackShapeEdgeInfo(bool isOutgoing, bool isIncoming)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte PackShapeEdgeInfo(byte shapeEdge, byte adjacentShapeEdge, bool areEdgesIdentical, bool isOutgoing, bool isIncoming)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Connection(GraphNode node, uint cost, byte shapeEdgeInfo)
		{
			this.node = null;
			this.cost = 0u;
			this.shapeEdgeInfo = 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}
	}
}
