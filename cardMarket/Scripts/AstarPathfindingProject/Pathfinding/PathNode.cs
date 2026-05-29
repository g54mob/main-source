using Unity.Mathematics;

namespace Pathfinding
{
	public struct PathNode
	{
		public ushort pathID;

		public ushort heapIndex;

		private uint flags;

		public static readonly PathNode Default = new PathNode
		{
			pathID = 0,
			heapIndex = ushort.MaxValue,
			flags = 0u
		};

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
				return (flags & 0x3C000000) >> 26;
			}
			set
			{
				flags = (flags & 0xC3FFFFFFu) | ((value << 26) & 0x3C000000);
			}
		}

		public uint parentIndex
		{
			get
			{
				return flags & 0x3FFFFFF;
			}
			set
			{
				flags = (flags & 0xFC000000u) | value;
			}
		}

		public bool flag1
		{
			get
			{
				return (flags & 0x40000000) != 0;
			}
			set
			{
				flags = (flags & 0xBFFFFFFFu) | (uint)(value ? 1073741824 : 0);
			}
		}

		public bool flag2
		{
			get
			{
				return (flags & 0x80000000u) != 0;
			}
			set
			{
				flags = (flags & 0x7FFFFFFF) | (uint)(value ? int.MinValue : 0);
			}
		}

		public static uint ReverseFractionAlongEdge(uint v)
		{
			return 15 - v;
		}

		public static uint QuantizeFractionAlongEdge(float v)
		{
			v *= 15f;
			v += 0.5f;
			return math.clamp((uint)v, 0u, 15u);
		}

		public static float UnQuantizeFractionAlongEdge(uint v)
		{
			return (float)v * (1f / 15f);
		}
	}
}
