namespace Pathfinding
{
	public struct Connection
	{
		public GraphNode node;

		public uint cost;

		public byte shapeEdge;

		public Connection(GraphNode node, uint cost, byte shapeEdge = 255)
		{
			this.node = null;
			this.cost = 0u;
			this.shapeEdge = 0;
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
