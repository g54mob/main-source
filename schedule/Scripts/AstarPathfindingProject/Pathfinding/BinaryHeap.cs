namespace Pathfinding
{
	public class BinaryHeap
	{
		private struct Tuple
		{
			public PathNode node;

			public uint F;

			public Tuple(uint f, PathNode node)
			{
				this.node = null;
				F = 0u;
			}
		}

		public int numberOfItems;

		public float growthFactor;

		private const int D = 4;

		private const bool SortGScores = true;

		public const ushort NotInHeap = ushort.MaxValue;

		private Tuple[] heap;

		public bool isEmpty => false;

		private static int RoundUpToNextMultipleMod1(int v)
		{
			return 0;
		}

		public BinaryHeap(int capacity)
		{
		}

		public void Clear()
		{
		}

		internal PathNode GetNode(int i)
		{
			return null;
		}

		internal void SetF(int i, uint f)
		{
		}

		private void Expand()
		{
		}

		public void Add(PathNode node)
		{
		}

		private void DecreaseKey(Tuple node, ushort index)
		{
		}

		public PathNode Remove()
		{
			return null;
		}

		private void Validate()
		{
		}

		public void Rebuild()
		{
		}
	}
}
