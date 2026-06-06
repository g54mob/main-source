namespace Pathfinding
{
	public struct PathNode
	{
		public ushort pathID;

		public ushort heapIndex;

		private uint flags;

		public static readonly PathNode Default;

		private const uint ParentIndexMask = 67108863u;

		private const int FractionAlongEdgeOffset = 26;

		private const uint FractionAlongEdgeMask = 1006632960u;

		public const int FractionAlongEdgeQuantization = 16;

		private const int Flag1Offset = 30;

		private const uint Flag1Mask = 1073741824u;

		private const int Flag2Offset = 31;

		private const uint Flag2Mask = 2147483648u;

		public uint fractionAlongEdge
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint parentIndex
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

		public static uint ReverseFractionAlongEdge(uint v)
		{
			return 0u;
		}

		public static uint QuantizeFractionAlongEdge(float v)
		{
			return 0u;
		}

		public static float UnQuantizeFractionAlongEdge(uint v)
		{
			return 0f;
		}
	}
}
