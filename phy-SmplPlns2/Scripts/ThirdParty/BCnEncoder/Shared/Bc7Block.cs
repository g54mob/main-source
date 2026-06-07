using System;
using System.IO;
using BCnEncoder.Encoder.Bptc;

namespace BCnEncoder.Shared
{
	internal struct Bc7Block
	{
		public ulong lowBits;

		public ulong highBits;

		public static readonly int[][] Subsets2PartitionTable = new int[64][]
		{
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
				1, 1, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 1, 0, 0, 0, 1, 0, 0,
				0, 1, 0, 0, 0, 1
			},
			new int[16]
			{
				0, 1, 1, 1, 0, 1, 1, 1, 0, 1,
				1, 1, 0, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 1, 0, 0, 1, 1, 0, 0,
				1, 1, 0, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
				0, 1, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 1, 1, 1, 0, 1,
				1, 1, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 1, 0, 0, 1, 1, 0, 1,
				1, 1, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
				1, 1, 0, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 1, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 1, 1, 1, 1, 1,
				1, 1, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 1, 0, 1,
				1, 1, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 1, 0, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 1, 0, 1, 1, 1, 1, 1,
				1, 1, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
				1, 1, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 1, 1, 1, 1, 1,
				1, 1, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 0, 0, 0, 1, 1,
				1, 0, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 1, 1, 1, 0, 0, 0, 1, 0, 0,
				0, 0, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
				0, 0, 1, 1, 1, 0
			},
			new int[16]
			{
				0, 1, 1, 1, 0, 0, 1, 1, 0, 0,
				0, 1, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 0, 1, 0, 0,
				0, 0, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 0, 0, 0, 1, 1,
				0, 0, 1, 1, 1, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
				0, 0, 1, 1, 0, 0
			},
			new int[16]
			{
				0, 1, 1, 1, 0, 0, 1, 1, 0, 0,
				1, 1, 0, 0, 0, 1
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 0, 1, 0, 0,
				0, 1, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 0, 0, 0, 1, 0,
				0, 0, 1, 1, 0, 0
			},
			new int[16]
			{
				0, 1, 1, 0, 0, 1, 1, 0, 0, 1,
				1, 0, 0, 1, 1, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 1, 1, 0, 0, 1,
				1, 0, 1, 1, 0, 0
			},
			new int[16]
			{
				0, 0, 0, 1, 0, 1, 1, 1, 1, 1,
				1, 0, 1, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 1, 1, 1, 1, 1,
				1, 1, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 1, 1, 1, 0, 0, 0, 1, 1, 0,
				0, 0, 1, 1, 1, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 1, 0, 0, 1, 1, 0,
				0, 1, 1, 1, 0, 0
			},
			new int[16]
			{
				0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
				0, 1, 0, 1, 0, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 1, 1, 1, 0, 0,
				0, 0, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 1, 0, 1, 1, 0, 1, 0, 0, 1,
				0, 1, 1, 0, 1, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 1, 1, 1, 1,
				0, 0, 1, 1, 0, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 1, 1, 0, 0, 0, 0,
				1, 1, 1, 1, 0, 0
			},
			new int[16]
			{
				0, 1, 0, 1, 0, 1, 0, 1, 1, 0,
				1, 0, 1, 0, 1, 0
			},
			new int[16]
			{
				0, 1, 1, 0, 1, 0, 0, 1, 0, 1,
				1, 0, 1, 0, 0, 1
			},
			new int[16]
			{
				0, 1, 0, 1, 1, 0, 1, 0, 1, 0,
				1, 0, 0, 1, 0, 1
			},
			new int[16]
			{
				0, 1, 1, 1, 0, 0, 1, 1, 1, 1,
				0, 0, 1, 1, 1, 0
			},
			new int[16]
			{
				0, 0, 0, 1, 0, 0, 1, 1, 1, 1,
				0, 0, 1, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 1, 0, 0, 1,
				0, 0, 1, 1, 0, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 1, 0, 1, 1, 1, 1,
				0, 1, 1, 1, 0, 0
			},
			new int[16]
			{
				0, 1, 1, 0, 1, 0, 0, 1, 1, 0,
				0, 1, 0, 1, 1, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 1, 1, 0, 0, 1, 1,
				0, 0, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 1, 1, 0, 0, 1, 1, 0, 1, 0,
				0, 1, 1, 0, 0, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 1, 1, 0, 0, 1,
				1, 0, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 1, 0, 0, 1, 1, 1, 0, 0, 1,
				0, 0, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 1, 0, 0, 1, 1, 1, 0, 0,
				1, 0, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 1, 0, 0, 1,
				1, 1, 0, 0, 1, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 1, 0, 0, 1, 1,
				1, 0, 0, 1, 0, 0
			},
			new int[16]
			{
				0, 1, 1, 0, 1, 1, 0, 0, 1, 0,
				0, 1, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 1, 1, 0, 1, 1,
				0, 0, 1, 0, 0, 1
			},
			new int[16]
			{
				0, 1, 1, 0, 0, 0, 1, 1, 1, 0,
				0, 1, 1, 1, 0, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 1, 0, 0, 1, 1, 1,
				0, 0, 0, 1, 1, 0
			},
			new int[16]
			{
				0, 1, 1, 0, 1, 1, 0, 0, 1, 1,
				0, 0, 1, 0, 0, 1
			},
			new int[16]
			{
				0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
				1, 1, 1, 0, 0, 1
			},
			new int[16]
			{
				0, 1, 1, 1, 1, 1, 1, 0, 1, 0,
				0, 0, 0, 0, 0, 1
			},
			new int[16]
			{
				0, 0, 0, 1, 1, 0, 0, 0, 1, 1,
				1, 0, 0, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 1, 1, 1, 0, 0,
				1, 1, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 1, 1, 1, 1,
				1, 1, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 1, 0, 0, 0, 1, 0, 1, 1,
				1, 0, 1, 1, 1, 0
			},
			new int[16]
			{
				0, 1, 0, 0, 0, 1, 0, 0, 0, 1,
				1, 1, 0, 1, 1, 1
			}
		};

		public static readonly int[][] Subsets3PartitionTable = new int[64][]
		{
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 1, 1, 0, 2,
				2, 1, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 0, 1, 0, 0, 1, 1, 2, 2,
				1, 1, 2, 2, 2, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 2, 0, 0, 1, 2, 2,
				1, 1, 2, 2, 1, 1
			},
			new int[16]
			{
				0, 2, 2, 2, 0, 0, 2, 2, 0, 0,
				1, 1, 0, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
				2, 2, 1, 1, 2, 2
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
				2, 2, 0, 0, 2, 2
			},
			new int[16]
			{
				0, 0, 2, 2, 0, 0, 2, 2, 1, 1,
				1, 1, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 1, 1, 2, 2,
				1, 1, 2, 2, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
				1, 1, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 1, 1, 1, 1, 1,
				1, 1, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 1, 1, 1, 2, 2,
				2, 2, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 1, 2, 0, 0, 1, 2, 0, 0,
				1, 2, 0, 0, 1, 2
			},
			new int[16]
			{
				0, 1, 1, 2, 0, 1, 1, 2, 0, 1,
				1, 2, 0, 1, 1, 2
			},
			new int[16]
			{
				0, 1, 2, 2, 0, 1, 2, 2, 0, 1,
				2, 2, 0, 1, 2, 2
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 1, 1, 2, 1, 1,
				2, 2, 1, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 1, 1, 2, 0, 0, 1, 2, 2,
				0, 0, 2, 2, 2, 0
			},
			new int[16]
			{
				0, 0, 0, 1, 0, 0, 1, 1, 0, 1,
				1, 2, 1, 1, 2, 2
			},
			new int[16]
			{
				0, 1, 1, 1, 0, 0, 1, 1, 2, 0,
				0, 1, 2, 2, 0, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 1, 2, 2, 1, 1,
				2, 2, 1, 1, 2, 2
			},
			new int[16]
			{
				0, 0, 2, 2, 0, 0, 2, 2, 0, 0,
				2, 2, 1, 1, 1, 1
			},
			new int[16]
			{
				0, 1, 1, 1, 0, 1, 1, 1, 0, 2,
				2, 2, 0, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 0, 1, 0, 0, 0, 1, 2, 2,
				2, 1, 2, 2, 2, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 1, 1, 0, 1,
				2, 2, 0, 1, 2, 2
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 1, 0, 0, 2, 2,
				1, 0, 2, 2, 1, 0
			},
			new int[16]
			{
				0, 1, 2, 2, 0, 1, 2, 2, 0, 0,
				1, 1, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 0, 1, 2, 0, 0, 1, 2, 1, 1,
				2, 2, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 1, 1, 0, 1, 2, 2, 1, 1, 2,
				2, 1, 0, 1, 1, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 1, 1, 0, 1, 2,
				2, 1, 1, 2, 2, 1
			},
			new int[16]
			{
				0, 0, 2, 2, 1, 1, 0, 2, 1, 1,
				0, 2, 0, 0, 2, 2
			},
			new int[16]
			{
				0, 1, 1, 0, 0, 1, 1, 0, 2, 0,
				0, 2, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 1, 2, 2, 0, 1,
				2, 2, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 2, 0, 0, 0, 2, 2,
				1, 1, 2, 2, 2, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 2, 1, 1,
				2, 2, 1, 2, 2, 2
			},
			new int[16]
			{
				0, 2, 2, 2, 0, 0, 2, 2, 0, 0,
				1, 2, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 0, 1, 1, 0, 0, 1, 2, 0, 0,
				2, 2, 0, 2, 2, 2
			},
			new int[16]
			{
				0, 1, 2, 0, 0, 1, 2, 0, 0, 1,
				2, 0, 0, 1, 2, 0
			},
			new int[16]
			{
				0, 0, 0, 0, 1, 1, 1, 1, 2, 2,
				2, 2, 0, 0, 0, 0
			},
			new int[16]
			{
				0, 1, 2, 0, 1, 2, 0, 1, 2, 0,
				1, 2, 0, 1, 2, 0
			},
			new int[16]
			{
				0, 1, 2, 0, 2, 0, 1, 2, 1, 2,
				0, 1, 0, 1, 2, 0
			},
			new int[16]
			{
				0, 0, 1, 1, 2, 2, 0, 0, 1, 1,
				2, 2, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 0, 1, 1, 1, 1, 2, 2, 2, 2,
				0, 0, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 1, 0, 1, 0, 1, 0, 1, 2, 2,
				2, 2, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 2, 1,
				2, 1, 2, 1, 2, 1
			},
			new int[16]
			{
				0, 0, 2, 2, 1, 1, 2, 2, 0, 0,
				2, 2, 1, 1, 2, 2
			},
			new int[16]
			{
				0, 0, 2, 2, 0, 0, 1, 1, 0, 0,
				2, 2, 0, 0, 1, 1
			},
			new int[16]
			{
				0, 2, 2, 0, 1, 2, 2, 1, 0, 2,
				2, 0, 1, 2, 2, 1
			},
			new int[16]
			{
				0, 1, 0, 1, 2, 2, 2, 2, 2, 2,
				2, 2, 0, 1, 0, 1
			},
			new int[16]
			{
				0, 0, 0, 0, 2, 1, 2, 1, 2, 1,
				2, 1, 2, 1, 2, 1
			},
			new int[16]
			{
				0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
				0, 1, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 2, 2, 2, 0, 1, 1, 1, 0, 2,
				2, 2, 0, 1, 1, 1
			},
			new int[16]
			{
				0, 0, 0, 2, 1, 1, 1, 2, 0, 0,
				0, 2, 1, 1, 1, 2
			},
			new int[16]
			{
				0, 0, 0, 0, 2, 1, 1, 2, 2, 1,
				1, 2, 2, 1, 1, 2
			},
			new int[16]
			{
				0, 2, 2, 2, 0, 1, 1, 1, 0, 1,
				1, 1, 0, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 0, 2, 1, 1, 1, 2, 1, 1,
				1, 2, 0, 0, 0, 2
			},
			new int[16]
			{
				0, 1, 1, 0, 0, 1, 1, 0, 0, 1,
				1, 0, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 2, 1,
				1, 2, 2, 1, 1, 2
			},
			new int[16]
			{
				0, 1, 1, 0, 0, 1, 1, 0, 2, 2,
				2, 2, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 0, 2, 2, 0, 0, 1, 1, 0, 0,
				1, 1, 0, 0, 2, 2
			},
			new int[16]
			{
				0, 0, 2, 2, 1, 1, 2, 2, 1, 1,
				2, 2, 0, 0, 2, 2
			},
			new int[16]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 2, 1, 1, 2
			},
			new int[16]
			{
				0, 0, 0, 2, 0, 0, 0, 1, 0, 0,
				0, 2, 0, 0, 0, 1
			},
			new int[16]
			{
				0, 2, 2, 2, 1, 2, 2, 2, 0, 2,
				2, 2, 1, 2, 2, 2
			},
			new int[16]
			{
				0, 1, 0, 1, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 2
			},
			new int[16]
			{
				0, 1, 1, 1, 2, 0, 1, 1, 2, 2,
				0, 1, 2, 2, 2, 0
			}
		};

		public static readonly int[] Subsets2AnchorIndices = new int[64]
		{
			15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
			15, 15, 15, 15, 15, 15, 15, 2, 8, 2,
			2, 8, 8, 15, 2, 8, 2, 2, 8, 8,
			2, 2, 15, 15, 6, 8, 2, 8, 15, 15,
			2, 8, 2, 2, 2, 15, 15, 6, 6, 2,
			6, 8, 15, 15, 2, 2, 15, 15, 15, 15,
			15, 2, 2, 15
		};

		public static readonly int[] Subsets3AnchorIndices2 = new int[64]
		{
			3, 3, 15, 15, 8, 3, 15, 15, 8, 8,
			6, 6, 6, 5, 3, 3, 3, 3, 8, 15,
			3, 3, 6, 10, 5, 8, 8, 6, 8, 5,
			15, 15, 8, 15, 3, 5, 6, 10, 8, 15,
			15, 3, 15, 5, 15, 15, 15, 15, 3, 15,
			5, 5, 5, 8, 5, 10, 5, 10, 8, 13,
			15, 12, 3, 3
		};

		public static readonly int[] Subsets3AnchorIndices3 = new int[64]
		{
			15, 8, 8, 3, 15, 15, 3, 8, 15, 15,
			15, 15, 15, 15, 15, 8, 15, 8, 15, 3,
			15, 8, 15, 8, 3, 15, 6, 10, 15, 15,
			10, 8, 15, 3, 15, 10, 10, 8, 9, 10,
			6, 15, 8, 15, 3, 6, 6, 8, 15, 3,
			15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
			3, 15, 15, 8
		};

		public static readonly RawBlock4X4Rgba32 ErrorBlock = new RawBlock4X4Rgba32(new ColorRgba32(byte.MaxValue, 0, byte.MaxValue));

		public Bc7BlockType Type
		{
			get
			{
				for (int i = 0; i < 8; i++)
				{
					ulong num = (ulong)(1 << i);
					if ((lowBits & num) == num)
					{
						return (Bc7BlockType)i;
					}
				}
				return Bc7BlockType.Type8Reserved;
			}
		}

		public int NumSubsets => Type switch
		{
			Bc7BlockType.Type0 => 3, 
			Bc7BlockType.Type1 => 2, 
			Bc7BlockType.Type2 => 3, 
			Bc7BlockType.Type3 => 2, 
			Bc7BlockType.Type7 => 2, 
			_ => 1, 
		};

		public bool HasSubsets => Type switch
		{
			Bc7BlockType.Type0 => true, 
			Bc7BlockType.Type1 => true, 
			Bc7BlockType.Type2 => true, 
			Bc7BlockType.Type3 => true, 
			Bc7BlockType.Type7 => true, 
			_ => false, 
		};

		public int PartitionSetId => Type switch
		{
			Bc7BlockType.Type0 => ByteHelper.Extract4(lowBits, 1), 
			Bc7BlockType.Type1 => ByteHelper.Extract6(lowBits, 2), 
			Bc7BlockType.Type2 => ByteHelper.Extract6(lowBits, 3), 
			Bc7BlockType.Type3 => ByteHelper.Extract6(lowBits, 4), 
			Bc7BlockType.Type7 => ByteHelper.Extract6(lowBits, 8), 
			_ => -1, 
		};

		public byte RotationBits => Type switch
		{
			Bc7BlockType.Type4 => ByteHelper.Extract2(lowBits, 5), 
			Bc7BlockType.Type5 => ByteHelper.Extract2(lowBits, 6), 
			_ => 0, 
		};

		public int ColorComponentPrecision => Type switch
		{
			Bc7BlockType.Type0 => 5, 
			Bc7BlockType.Type1 => 7, 
			Bc7BlockType.Type2 => 5, 
			Bc7BlockType.Type3 => 8, 
			Bc7BlockType.Type4 => 5, 
			Bc7BlockType.Type5 => 7, 
			Bc7BlockType.Type6 => 8, 
			Bc7BlockType.Type7 => 6, 
			_ => 0, 
		};

		public int AlphaComponentPrecision => Type switch
		{
			Bc7BlockType.Type4 => 6, 
			Bc7BlockType.Type5 => 8, 
			Bc7BlockType.Type6 => 8, 
			Bc7BlockType.Type7 => 6, 
			_ => 0, 
		};

		public bool HasRotationBits => Type switch
		{
			Bc7BlockType.Type4 => true, 
			Bc7BlockType.Type5 => true, 
			_ => false, 
		};

		public bool HasPBits => Type switch
		{
			Bc7BlockType.Type0 => true, 
			Bc7BlockType.Type1 => true, 
			Bc7BlockType.Type3 => true, 
			Bc7BlockType.Type6 => true, 
			Bc7BlockType.Type7 => true, 
			_ => false, 
		};

		public bool HasAlpha => Type switch
		{
			Bc7BlockType.Type4 => true, 
			Bc7BlockType.Type5 => true, 
			Bc7BlockType.Type6 => true, 
			Bc7BlockType.Type7 => true, 
			_ => false, 
		};

		public int Type4IndexMode
		{
			get
			{
				if (Type == Bc7BlockType.Type4)
				{
					return ByteHelper.Extract1(lowBits, 7);
				}
				return 0;
			}
		}

		public int ColorIndexBitCount
		{
			get
			{
				switch (Type)
				{
				case Bc7BlockType.Type0:
					return 3;
				case Bc7BlockType.Type1:
					return 3;
				case Bc7BlockType.Type2:
					return 2;
				case Bc7BlockType.Type3:
					return 2;
				case Bc7BlockType.Type4:
					if (Type4IndexMode == 0)
					{
						return 2;
					}
					if (Type4IndexMode == 1)
					{
						return 3;
					}
					break;
				case Bc7BlockType.Type5:
					return 2;
				case Bc7BlockType.Type6:
					return 4;
				case Bc7BlockType.Type7:
					return 2;
				}
				return 0;
			}
		}

		public int AlphaIndexBitCount
		{
			get
			{
				switch (Type)
				{
				case Bc7BlockType.Type4:
					if (Type4IndexMode == 0)
					{
						return 3;
					}
					if (Type4IndexMode == 1)
					{
						return 2;
					}
					break;
				case Bc7BlockType.Type5:
					return 2;
				case Bc7BlockType.Type6:
					return 4;
				case Bc7BlockType.Type7:
					return 2;
				}
				return 0;
			}
		}

		private void ExtractRawEndpoints(ColorRgba32[] endpoints)
		{
			switch (Type)
			{
			case Bc7BlockType.Type0:
				endpoints[0].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 5, 4);
				endpoints[1].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 9, 4);
				endpoints[2].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 13, 4);
				endpoints[3].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 17, 4);
				endpoints[4].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 21, 4);
				endpoints[5].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 25, 4);
				endpoints[0].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 29, 4);
				endpoints[1].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 33, 4);
				endpoints[2].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 37, 4);
				endpoints[3].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 41, 4);
				endpoints[4].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 45, 4);
				endpoints[5].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 49, 4);
				endpoints[0].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 53, 4);
				endpoints[1].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 57, 4);
				endpoints[2].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 61, 4);
				endpoints[3].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 65, 4);
				endpoints[4].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 69, 4);
				endpoints[5].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 73, 4);
				break;
			case Bc7BlockType.Type1:
				endpoints[0].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 8, 6);
				endpoints[1].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 14, 6);
				endpoints[2].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 20, 6);
				endpoints[3].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 26, 6);
				endpoints[0].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 32, 6);
				endpoints[1].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 38, 6);
				endpoints[2].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 44, 6);
				endpoints[3].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 50, 6);
				endpoints[0].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 56, 6);
				endpoints[1].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 62, 6);
				endpoints[2].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 68, 6);
				endpoints[3].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 74, 6);
				break;
			case Bc7BlockType.Type2:
				endpoints[0].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 9, 5);
				endpoints[1].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 14, 5);
				endpoints[2].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 19, 5);
				endpoints[3].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 24, 5);
				endpoints[4].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 29, 5);
				endpoints[5].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 34, 5);
				endpoints[0].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 39, 5);
				endpoints[1].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 44, 5);
				endpoints[2].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 49, 5);
				endpoints[3].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 54, 5);
				endpoints[4].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 59, 5);
				endpoints[5].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 64, 5);
				endpoints[0].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 69, 5);
				endpoints[1].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 74, 5);
				endpoints[2].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 79, 5);
				endpoints[3].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 84, 5);
				endpoints[4].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 89, 5);
				endpoints[5].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 94, 5);
				break;
			case Bc7BlockType.Type3:
				endpoints[0].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 10, 7);
				endpoints[1].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 17, 7);
				endpoints[2].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 24, 7);
				endpoints[3].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 31, 7);
				endpoints[0].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 38, 7);
				endpoints[1].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 45, 7);
				endpoints[2].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 52, 7);
				endpoints[3].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 59, 7);
				endpoints[0].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 66, 7);
				endpoints[1].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 73, 7);
				endpoints[2].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 80, 7);
				endpoints[3].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 87, 7);
				break;
			case Bc7BlockType.Type4:
				endpoints[0].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 8, 5);
				endpoints[1].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 13, 5);
				endpoints[0].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 18, 5);
				endpoints[1].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 23, 5);
				endpoints[0].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 28, 5);
				endpoints[1].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 33, 5);
				endpoints[0].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 38, 6);
				endpoints[1].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 44, 6);
				break;
			case Bc7BlockType.Type5:
				endpoints[0].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 8, 7);
				endpoints[1].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 15, 7);
				endpoints[0].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 22, 7);
				endpoints[1].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 29, 7);
				endpoints[0].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 36, 7);
				endpoints[1].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 43, 7);
				endpoints[0].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 50, 8);
				endpoints[1].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 58, 8);
				break;
			case Bc7BlockType.Type6:
				endpoints[0].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 7, 7);
				endpoints[1].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 14, 7);
				endpoints[0].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 21, 7);
				endpoints[1].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 28, 7);
				endpoints[0].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 35, 7);
				endpoints[1].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 42, 7);
				endpoints[0].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 49, 7);
				endpoints[1].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 56, 7);
				break;
			case Bc7BlockType.Type7:
				endpoints[0].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 14, 5);
				endpoints[1].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 19, 5);
				endpoints[2].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 24, 5);
				endpoints[3].r = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 29, 5);
				endpoints[0].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 34, 5);
				endpoints[1].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 39, 5);
				endpoints[2].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 44, 5);
				endpoints[3].g = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 49, 5);
				endpoints[0].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 54, 5);
				endpoints[1].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 59, 5);
				endpoints[2].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 64, 5);
				endpoints[3].b = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 69, 5);
				endpoints[0].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 74, 5);
				endpoints[1].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 79, 5);
				endpoints[2].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 84, 5);
				endpoints[3].a = (byte)ByteHelper.ExtractFrom128(lowBits, highBits, 89, 5);
				break;
			default:
				throw new InvalidDataException();
			}
		}

		private byte[] ExtractPBitArray()
		{
			return Type switch
			{
				Bc7BlockType.Type0 => new byte[6]
				{
					ByteHelper.Extract1(highBits, 13),
					ByteHelper.Extract1(highBits, 14),
					ByteHelper.Extract1(highBits, 15),
					ByteHelper.Extract1(highBits, 16),
					ByteHelper.Extract1(highBits, 17),
					ByteHelper.Extract1(highBits, 18)
				}, 
				Bc7BlockType.Type1 => new byte[2]
				{
					ByteHelper.Extract1(highBits, 16),
					ByteHelper.Extract1(highBits, 17)
				}, 
				Bc7BlockType.Type3 => new byte[4]
				{
					ByteHelper.Extract1(highBits, 30),
					ByteHelper.Extract1(highBits, 31),
					ByteHelper.Extract1(highBits, 32),
					ByteHelper.Extract1(highBits, 33)
				}, 
				Bc7BlockType.Type6 => new byte[2]
				{
					ByteHelper.Extract1(lowBits, 63),
					ByteHelper.Extract1(highBits, 0)
				}, 
				Bc7BlockType.Type7 => new byte[4]
				{
					ByteHelper.Extract1(highBits, 30),
					ByteHelper.Extract1(highBits, 31),
					ByteHelper.Extract1(highBits, 32),
					ByteHelper.Extract1(highBits, 33)
				}, 
				_ => Array.Empty<byte>(), 
			};
		}

		private void FinalizeEndpoints(ColorRgba32[] endpoints)
		{
			if (HasPBits)
			{
				for (int i = 0; i < endpoints.Length; i++)
				{
					endpoints[i] <<= 1;
				}
				byte[] array = ExtractPBitArray();
				if (Type == Bc7BlockType.Type1)
				{
					endpoints[0] |= (int)array[0];
					endpoints[1] |= (int)array[0];
					endpoints[2] |= (int)array[1];
					endpoints[3] |= (int)array[1];
				}
				else
				{
					for (int j = 0; j < endpoints.Length; j++)
					{
						endpoints[j] |= (int)array[j];
					}
				}
			}
			int colorComponentPrecision = ColorComponentPrecision;
			int alphaComponentPrecision = AlphaComponentPrecision;
			for (int k = 0; k < endpoints.Length; k++)
			{
				endpoints[k].r = (byte)(endpoints[k].r << 8 - colorComponentPrecision);
				endpoints[k].g = (byte)(endpoints[k].g << 8 - colorComponentPrecision);
				endpoints[k].b = (byte)(endpoints[k].b << 8 - colorComponentPrecision);
				endpoints[k].a = (byte)(endpoints[k].a << 8 - alphaComponentPrecision);
				endpoints[k].r = (byte)(endpoints[k].r | (endpoints[k].r >> colorComponentPrecision));
				endpoints[k].g = (byte)(endpoints[k].g | (endpoints[k].g >> colorComponentPrecision));
				endpoints[k].b = (byte)(endpoints[k].b | (endpoints[k].b >> colorComponentPrecision));
				endpoints[k].a = (byte)(endpoints[k].a | (endpoints[k].a >> alphaComponentPrecision));
			}
			if (!HasAlpha)
			{
				for (int l = 0; l < endpoints.Length; l++)
				{
					endpoints[l].a = byte.MaxValue;
				}
			}
		}

		public ColorRgba32[] ExtractEndpoints()
		{
			ColorRgba32[] array = new ColorRgba32[NumSubsets * 2];
			ExtractRawEndpoints(array);
			FinalizeEndpoints(array);
			return array;
		}

		private int GetPartitionIndex(int numSubsets, int partitionSetId, int i)
		{
			return numSubsets switch
			{
				1 => 0, 
				2 => Subsets2PartitionTable[partitionSetId][i], 
				3 => Subsets3PartitionTable[partitionSetId][i], 
				_ => throw new ArgumentOutOfRangeException("numSubsets", numSubsets, "Number of subsets can only be 1, 2 or 3"), 
			};
		}

		private int GetIndexOffset(Bc7BlockType type, int numSubsets, int partitionIndex, int bitCount, int index)
		{
			if (index == 0)
			{
				return 0;
			}
			switch (numSubsets)
			{
			case 1:
				return bitCount * index - 1;
			case 2:
			{
				int num3 = Subsets2AnchorIndices[partitionIndex];
				if (index <= num3)
				{
					return bitCount * index - 1;
				}
				return bitCount * index - 2;
			}
			case 3:
			{
				int num = Subsets3AnchorIndices2[partitionIndex];
				int num2 = Subsets3AnchorIndices3[partitionIndex];
				if (index <= num && index <= num2)
				{
					return bitCount * index - 1;
				}
				if (index > num && index > num2)
				{
					return bitCount * index - 3;
				}
				return bitCount * index - 2;
			}
			default:
				throw new ArgumentOutOfRangeException("numSubsets", numSubsets, "Number of subsets can only be 1, 2 or 3");
			}
		}

		private int GetIndexBitCount(int numSubsets, int partitionIndex, int bitCount, int index)
		{
			if (index == 0)
			{
				return bitCount - 1;
			}
			switch (numSubsets)
			{
			case 2:
			{
				int num3 = Subsets2AnchorIndices[partitionIndex];
				if (index == num3)
				{
					return bitCount - 1;
				}
				break;
			}
			case 3:
			{
				int num = Subsets3AnchorIndices2[partitionIndex];
				int num2 = Subsets3AnchorIndices3[partitionIndex];
				if (index == num)
				{
					return bitCount - 1;
				}
				if (index == num2)
				{
					return bitCount - 1;
				}
				break;
			}
			}
			return bitCount;
		}

		private int GetIndexBegin(Bc7BlockType type, int bitCount, bool isAlpha)
		{
			switch (type)
			{
			case Bc7BlockType.Type0:
				return 83;
			case Bc7BlockType.Type1:
				return 82;
			case Bc7BlockType.Type2:
				return 99;
			case Bc7BlockType.Type3:
				return 98;
			case Bc7BlockType.Type4:
				if (bitCount == 2)
				{
					return 50;
				}
				return 81;
			case Bc7BlockType.Type5:
				if (isAlpha)
				{
					return 97;
				}
				return 66;
			case Bc7BlockType.Type6:
				return 65;
			case Bc7BlockType.Type7:
				return 98;
			default:
				throw new ArgumentOutOfRangeException("type", type, null);
			}
		}

		private int GetAlphaIndex(Bc7BlockType type, int numSubsets, int partitionIndex, int bitCount, int index)
		{
			if (bitCount == 0)
			{
				return 0;
			}
			int indexOffset = GetIndexOffset(type, numSubsets, partitionIndex, bitCount, index);
			int indexBitCount = GetIndexBitCount(numSubsets, partitionIndex, bitCount, index);
			int indexBegin = GetIndexBegin(type, bitCount, isAlpha: true);
			return (int)ByteHelper.ExtractFrom128(lowBits, highBits, indexBegin + indexOffset, indexBitCount);
		}

		private int GetColorIndex(Bc7BlockType type, int numSubsets, int partitionIndex, int bitCount, int index)
		{
			int indexOffset = GetIndexOffset(type, numSubsets, partitionIndex, bitCount, index);
			int indexBitCount = GetIndexBitCount(numSubsets, partitionIndex, bitCount, index);
			int indexBegin = GetIndexBegin(type, bitCount, isAlpha: false);
			return (int)ByteHelper.ExtractFrom128(lowBits, highBits, indexBegin + indexOffset, indexBitCount);
		}

		private ColorRgba32 InterpolateColor(ColorRgba32 endPointStart, ColorRgba32 endPointEnd, int colorIndex, int alphaIndex, int colorBitCount, int alphaBitCount)
		{
			return new ColorRgba32(BptcEncodingHelpers.InterpolateByte(endPointStart.r, endPointEnd.r, colorIndex, colorBitCount), BptcEncodingHelpers.InterpolateByte(endPointStart.g, endPointEnd.g, colorIndex, colorBitCount), BptcEncodingHelpers.InterpolateByte(endPointStart.b, endPointEnd.b, colorIndex, colorBitCount), BptcEncodingHelpers.InterpolateByte(endPointStart.a, endPointEnd.a, alphaIndex, alphaBitCount));
		}

		private static ColorRgba32 SwapChannels(ColorRgba32 source, int rotation)
		{
			return rotation switch
			{
				0 => source, 
				1 => new ColorRgba32(source.a, source.g, source.b, source.r), 
				2 => new ColorRgba32(source.r, source.a, source.b, source.g), 
				3 => new ColorRgba32(source.r, source.g, source.a, source.b), 
				_ => source, 
			};
		}

		public RawBlock4X4Rgba32 Decode()
		{
			RawBlock4X4Rgba32 result = default(RawBlock4X4Rgba32);
			Bc7BlockType type = Type;
			if (type == Bc7BlockType.Type8Reserved)
			{
				return ErrorBlock;
			}
			int numSubsets = 1;
			int num = 0;
			if (HasSubsets)
			{
				numSubsets = NumSubsets;
				num = PartitionSetId;
			}
			Span<ColorRgba32> asSpan = result.AsSpan;
			bool hasRotationBits = HasRotationBits;
			int rotationBits = RotationBits;
			ColorRgba32[] array = ExtractEndpoints();
			for (int i = 0; i < asSpan.Length; i++)
			{
				int partitionIndex = GetPartitionIndex(numSubsets, num, i);
				ColorRgba32 endPointStart = array[2 * partitionIndex];
				ColorRgba32 endPointEnd = array[2 * partitionIndex + 1];
				int alphaIndexBitCount = AlphaIndexBitCount;
				int colorIndexBitCount = ColorIndexBitCount;
				int alphaIndex = GetAlphaIndex(type, numSubsets, num, alphaIndexBitCount, i);
				int colorIndex = GetColorIndex(type, numSubsets, num, colorIndexBitCount, i);
				ColorRgba32 colorRgba = InterpolateColor(endPointStart, endPointEnd, colorIndex, alphaIndex, colorIndexBitCount, alphaIndexBitCount);
				if (hasRotationBits)
				{
					colorRgba = SwapChannels(colorRgba, rotationBits);
				}
				asSpan[i] = colorRgba;
			}
			return result;
		}

		public void PackType0(int partitionIndex4Bit, byte[][] subsetEndpoints, byte[] pBits, byte[] indices)
		{
			lowBits = 1uL;
			highBits = 0uL;
			lowBits = ByteHelper.Store4(lowBits, 1, (byte)partitionIndex4Bit);
			int num = 5;
			for (int i = 0; i < subsetEndpoints[0].Length; i++)
			{
				for (int j = 0; j < subsetEndpoints.Length; j++)
				{
					(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 4, subsetEndpoints[j][i]);
					lowBits = tuple.Item1;
					highBits = tuple.Item2;
					num += 4;
				}
			}
			for (int k = 0; k < pBits.Length; k++)
			{
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 1, pBits[k]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
				num++;
			}
			int colorIndexBitCount = ColorIndexBitCount;
			int indexBegin = GetIndexBegin(Bc7BlockType.Type0, colorIndexBitCount, isAlpha: false);
			for (int l = 0; l < 16; l++)
			{
				int indexOffset = GetIndexOffset(Bc7BlockType.Type0, NumSubsets, partitionIndex4Bit, colorIndexBitCount, l);
				int indexBitCount = GetIndexBitCount(NumSubsets, partitionIndex4Bit, colorIndexBitCount, l);
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, indices[l]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
			}
		}

		public void PackType1(int partitionIndex6Bit, byte[][] subsetEndpoints, byte[] pBits, byte[] indices)
		{
			lowBits = 2uL;
			highBits = 0uL;
			lowBits = ByteHelper.Store6(lowBits, 2, (byte)partitionIndex6Bit);
			int num = 8;
			for (int i = 0; i < subsetEndpoints[0].Length; i++)
			{
				for (int j = 0; j < subsetEndpoints.Length; j++)
				{
					(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 6, subsetEndpoints[j][i]);
					lowBits = tuple.Item1;
					highBits = tuple.Item2;
					num += 6;
				}
			}
			for (int k = 0; k < pBits.Length; k++)
			{
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 1, pBits[k]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
				num++;
			}
			int colorIndexBitCount = ColorIndexBitCount;
			int indexBegin = GetIndexBegin(Bc7BlockType.Type1, colorIndexBitCount, isAlpha: false);
			for (int l = 0; l < 16; l++)
			{
				int indexOffset = GetIndexOffset(Bc7BlockType.Type1, NumSubsets, partitionIndex6Bit, colorIndexBitCount, l);
				int indexBitCount = GetIndexBitCount(NumSubsets, partitionIndex6Bit, colorIndexBitCount, l);
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, indices[l]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
			}
		}

		public void PackType2(int partitionIndex6Bit, byte[][] subsetEndpoints, byte[] indices)
		{
			lowBits = 4uL;
			highBits = 0uL;
			lowBits = ByteHelper.Store6(lowBits, 3, (byte)partitionIndex6Bit);
			int num = 9;
			for (int i = 0; i < subsetEndpoints[0].Length; i++)
			{
				for (int j = 0; j < subsetEndpoints.Length; j++)
				{
					(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 5, subsetEndpoints[j][i]);
					lowBits = tuple.Item1;
					highBits = tuple.Item2;
					num += 5;
				}
			}
			int colorIndexBitCount = ColorIndexBitCount;
			int indexBegin = GetIndexBegin(Bc7BlockType.Type2, colorIndexBitCount, isAlpha: false);
			for (int k = 0; k < 16; k++)
			{
				int indexOffset = GetIndexOffset(Bc7BlockType.Type2, NumSubsets, partitionIndex6Bit, colorIndexBitCount, k);
				int indexBitCount = GetIndexBitCount(NumSubsets, partitionIndex6Bit, colorIndexBitCount, k);
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, indices[k]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
			}
		}

		public void PackType3(int partitionIndex6Bit, byte[][] subsetEndpoints, byte[] pBits, byte[] indices)
		{
			lowBits = 8uL;
			highBits = 0uL;
			lowBits = ByteHelper.Store6(lowBits, 4, (byte)partitionIndex6Bit);
			int num = 10;
			for (int i = 0; i < subsetEndpoints[0].Length; i++)
			{
				for (int j = 0; j < subsetEndpoints.Length; j++)
				{
					(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 7, subsetEndpoints[j][i]);
					lowBits = tuple.Item1;
					highBits = tuple.Item2;
					num += 7;
				}
			}
			for (int k = 0; k < pBits.Length; k++)
			{
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 1, pBits[k]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
				num++;
			}
			int colorIndexBitCount = ColorIndexBitCount;
			int indexBegin = GetIndexBegin(Bc7BlockType.Type3, colorIndexBitCount, isAlpha: false);
			for (int l = 0; l < 16; l++)
			{
				int indexOffset = GetIndexOffset(Bc7BlockType.Type3, NumSubsets, partitionIndex6Bit, colorIndexBitCount, l);
				int indexBitCount = GetIndexBitCount(NumSubsets, partitionIndex6Bit, colorIndexBitCount, l);
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, indices[l]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
			}
		}

		public void PackType4(int rotation, byte idxMode, byte[][] colorEndPoints, byte[] alphaEndPoints, byte[] indices2Bit, byte[] indices3Bit)
		{
			lowBits = 16uL;
			highBits = 0uL;
			lowBits = ByteHelper.Store2(lowBits, 5, (byte)rotation);
			lowBits = ByteHelper.Store1(lowBits, 7, idxMode);
			int num = 8;
			for (int i = 0; i < colorEndPoints[0].Length; i++)
			{
				for (int j = 0; j < colorEndPoints.Length; j++)
				{
					(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 5, colorEndPoints[j][i]);
					lowBits = tuple.Item1;
					highBits = tuple.Item2;
					num += 5;
				}
			}
			for (int k = 0; k < alphaEndPoints.Length; k++)
			{
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 6, alphaEndPoints[k]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
				num += 6;
			}
			int colorIndexBitCount = ColorIndexBitCount;
			int indexBegin = GetIndexBegin(Bc7BlockType.Type4, colorIndexBitCount, isAlpha: false);
			for (int l = 0; l < 16; l++)
			{
				int indexOffset = GetIndexOffset(Bc7BlockType.Type4, NumSubsets, 0, colorIndexBitCount, l);
				int indexBitCount = GetIndexBitCount(NumSubsets, 0, colorIndexBitCount, l);
				if (idxMode == 0)
				{
					(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, indices2Bit[l]);
				}
				else
				{
					(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, indices3Bit[l]);
				}
			}
			int alphaIndexBitCount = AlphaIndexBitCount;
			int indexBegin2 = GetIndexBegin(Bc7BlockType.Type4, alphaIndexBitCount, isAlpha: true);
			for (int m = 0; m < 16; m++)
			{
				int indexOffset2 = GetIndexOffset(Bc7BlockType.Type4, NumSubsets, 0, alphaIndexBitCount, m);
				int indexBitCount2 = GetIndexBitCount(NumSubsets, 0, alphaIndexBitCount, m);
				if (idxMode == 0)
				{
					(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, indexBegin2 + indexOffset2, indexBitCount2, indices3Bit[m]);
				}
				else
				{
					(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, indexBegin2 + indexOffset2, indexBitCount2, indices2Bit[m]);
				}
			}
		}

		public void PackType5(int rotation, byte[][] colorEndPoints, byte[] alphaEndPoints, byte[] colorIndices, byte[] alphaIndices)
		{
			lowBits = 32uL;
			highBits = 0uL;
			lowBits = ByteHelper.Store2(lowBits, 6, (byte)rotation);
			int num = 8;
			for (int i = 0; i < colorEndPoints[0].Length; i++)
			{
				for (int j = 0; j < colorEndPoints.Length; j++)
				{
					(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 7, colorEndPoints[j][i]);
					lowBits = tuple.Item1;
					highBits = tuple.Item2;
					num += 7;
				}
			}
			for (int k = 0; k < alphaEndPoints.Length; k++)
			{
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 8, alphaEndPoints[k]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
				num += 8;
			}
			int colorIndexBitCount = ColorIndexBitCount;
			int indexBegin = GetIndexBegin(Bc7BlockType.Type5, colorIndexBitCount, isAlpha: false);
			for (int l = 0; l < 16; l++)
			{
				int indexOffset = GetIndexOffset(Bc7BlockType.Type5, NumSubsets, 0, colorIndexBitCount, l);
				int indexBitCount = GetIndexBitCount(NumSubsets, 0, colorIndexBitCount, l);
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, colorIndices[l]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
			}
			int alphaIndexBitCount = AlphaIndexBitCount;
			int indexBegin2 = GetIndexBegin(Bc7BlockType.Type5, alphaIndexBitCount, isAlpha: true);
			for (int m = 0; m < 16; m++)
			{
				int indexOffset2 = GetIndexOffset(Bc7BlockType.Type5, NumSubsets, 0, alphaIndexBitCount, m);
				int indexBitCount2 = GetIndexBitCount(NumSubsets, 0, alphaIndexBitCount, m);
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, indexBegin2 + indexOffset2, indexBitCount2, alphaIndices[m]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
			}
		}

		public void PackType6(byte[][] colorAlphaEndPoints, byte[] pBits, byte[] indices)
		{
			lowBits = 64uL;
			highBits = 0uL;
			int num = 7;
			for (int i = 0; i < colorAlphaEndPoints[0].Length; i++)
			{
				for (int j = 0; j < colorAlphaEndPoints.Length; j++)
				{
					(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 7, colorAlphaEndPoints[j][i]);
					lowBits = tuple.Item1;
					highBits = tuple.Item2;
					num += 7;
				}
			}
			for (int k = 0; k < pBits.Length; k++)
			{
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 1, pBits[k]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
				num++;
			}
			int colorIndexBitCount = ColorIndexBitCount;
			int indexBegin = GetIndexBegin(Bc7BlockType.Type6, colorIndexBitCount, isAlpha: false);
			for (int l = 0; l < 16; l++)
			{
				int indexOffset = GetIndexOffset(Bc7BlockType.Type6, NumSubsets, 0, colorIndexBitCount, l);
				int indexBitCount = GetIndexBitCount(NumSubsets, 0, colorIndexBitCount, l);
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, indices[l]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
			}
		}

		public void PackType7(int partitionIndex6Bit, byte[][] subsetEndpoints, byte[] pBits, byte[] indices)
		{
			lowBits = 128uL;
			highBits = 0uL;
			lowBits = ByteHelper.Store6(lowBits, 8, (byte)partitionIndex6Bit);
			int num = 14;
			for (int i = 0; i < subsetEndpoints[0].Length; i++)
			{
				for (int j = 0; j < subsetEndpoints.Length; j++)
				{
					(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 5, subsetEndpoints[j][i]);
					lowBits = tuple.Item1;
					highBits = tuple.Item2;
					num += 5;
				}
			}
			for (int k = 0; k < pBits.Length; k++)
			{
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, num, 1, pBits[k]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
				num++;
			}
			int colorIndexBitCount = ColorIndexBitCount;
			int indexBegin = GetIndexBegin(Bc7BlockType.Type7, colorIndexBitCount, isAlpha: false);
			for (int l = 0; l < 16; l++)
			{
				int indexOffset = GetIndexOffset(Bc7BlockType.Type7, NumSubsets, partitionIndex6Bit, colorIndexBitCount, l);
				int indexBitCount = GetIndexBitCount(NumSubsets, partitionIndex6Bit, colorIndexBitCount, l);
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, indices[l]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
			}
		}
	}
}
