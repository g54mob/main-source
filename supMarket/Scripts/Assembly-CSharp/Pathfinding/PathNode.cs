namespace Pathfinding
{
	public class PathNode
	{
		public GraphNode node;

		public PathNode parent;

		public ushort pathID;

		public ushort heapIndex;

		private uint flags;

		private const uint CostMask = 268435455u;

		private const int Flag1Offset = 28;

		private const uint Flag1Mask = 268435456u;

		private const int Flag2Offset = 29;

		private const uint Flag2Mask = 536870912u;

		private uint g;

		private uint h;

		public uint cost
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public bool flag1
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool flag2
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public uint G
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint H
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint F => 0u;

		public void UpdateG(Path path)
		{
		}
	}
}
