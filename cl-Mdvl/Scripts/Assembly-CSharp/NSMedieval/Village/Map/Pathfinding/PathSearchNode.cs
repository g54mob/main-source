namespace NSMedieval.Village.Map.Pathfinding
{
	public class PathSearchNode
	{
		private MapNode node;

		private PathSearchNode parent;

		private uint h;

		private uint g;

		private int heapIndex = int.MaxValue;

		private bool tagA;

		public MapNode Node
		{
			get
			{
				return node;
			}
			internal set
			{
				node = value;
			}
		}

		public PathSearchNode Parent
		{
			get
			{
				return parent;
			}
			internal set
			{
				parent = value;
			}
		}

		public uint H
		{
			get
			{
				return h;
			}
			set
			{
				h = value;
			}
		}

		public uint G
		{
			get
			{
				return g;
			}
			set
			{
				g = value;
			}
		}

		public bool TagA
		{
			get
			{
				return tagA;
			}
			set
			{
				tagA = value;
			}
		}

		public uint F => g + h;

		public int HeapIndex
		{
			get
			{
				return heapIndex;
			}
			internal set
			{
				heapIndex = value;
			}
		}

		public PathSearchNode(MapNode node, PathSearchNode parent)
		{
			this.node = node;
			this.parent = parent;
		}

		public override int GetHashCode()
		{
			return node.Position.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null || obj.GetType() != GetType())
			{
				return false;
			}
			return Node == ((PathSearchNode)obj).node;
		}
	}
}
