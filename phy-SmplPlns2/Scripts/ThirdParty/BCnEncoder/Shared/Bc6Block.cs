using System;
using BCnEncoder.Encoder.Bptc;

namespace BCnEncoder.Shared
{
	internal struct Bc6Block
	{
		public ulong lowBits;

		public ulong highBits;

		public static readonly int[][] Subsets2PartitionTable = new int[32][]
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

		public static readonly RawBlock4X4RgbFloat ErrorBlock = new RawBlock4X4RgbFloat(new ColorRgbFloat(1f, 0f, 1f));

		public static readonly Bc6BlockType[] Subsets1Types = new Bc6BlockType[4]
		{
			Bc6BlockType.Type3,
			Bc6BlockType.Type7,
			Bc6BlockType.Type11,
			Bc6BlockType.Type15
		};

		public static readonly Bc6BlockType[] Subsets2Types = new Bc6BlockType[10]
		{
			Bc6BlockType.Type0,
			Bc6BlockType.Type1,
			Bc6BlockType.Type2,
			Bc6BlockType.Type6,
			Bc6BlockType.Type10,
			Bc6BlockType.Type14,
			Bc6BlockType.Type18,
			Bc6BlockType.Type22,
			Bc6BlockType.Type26,
			Bc6BlockType.Type30
		};

		public readonly Bc6BlockType Type
		{
			get
			{
				if ((lowBits & 3) < 2)
				{
					return (Bc6BlockType)(lowBits & 3);
				}
				ulong num = lowBits & 0x1F;
				switch (num)
				{
				case 0uL:
				case 1uL:
				case 2uL:
				case 3uL:
				case 4uL:
				case 5uL:
				case 6uL:
				case 7uL:
				case 8uL:
				case 9uL:
				case 10uL:
				case 11uL:
				case 12uL:
				case 13uL:
				case 14uL:
				case 15uL:
				case 16uL:
				case 17uL:
				case 18uL:
				case 19uL:
				case 20uL:
				case 21uL:
				case 22uL:
				{
					ulong num2 = num - 2;
					if (num2 <= 16)
					{
						switch ((uint)num2)
						{
						case 0u:
							return Bc6BlockType.Type2;
						case 1u:
							return Bc6BlockType.Type3;
						case 4u:
							return Bc6BlockType.Type6;
						case 5u:
							return Bc6BlockType.Type7;
						case 8u:
							return Bc6BlockType.Type10;
						case 9u:
							return Bc6BlockType.Type11;
						case 12u:
							return Bc6BlockType.Type14;
						case 13u:
							return Bc6BlockType.Type15;
						case 16u:
							return Bc6BlockType.Type18;
						case 2u:
						case 3u:
						case 6u:
						case 7u:
						case 10u:
						case 11u:
						case 14u:
						case 15u:
							goto end_IL_0027;
						}
					}
					if (num != 22)
					{
						break;
					}
					return Bc6BlockType.Type22;
				}
				case 26uL:
					return Bc6BlockType.Type26;
				case 30uL:
					{
						return Bc6BlockType.Type30;
					}
					end_IL_0027:
					break;
				}
				return Bc6BlockType.Unknown;
			}
		}

		public readonly bool HasSubsets => Type.HasSubsets();

		public readonly int NumEndpoints
		{
			get
			{
				if (!HasSubsets)
				{
					return 2;
				}
				return 4;
			}
		}

		public readonly bool HasTransformedEndpoints => Type.HasTransformedEndpoints();

		public readonly int PartitionSetId
		{
			get
			{
				if (!HasSubsets)
				{
					return -1;
				}
				return ByteHelper.Extract5(highBits, 13);
			}
		}

		public readonly int EndpointBits => Type.EndpointBits();

		public readonly (int, int, int) DeltaBits => Type.DeltaBits();

		public readonly int ColorIndexBitCount
		{
			get
			{
				if (!HasSubsets)
				{
					return 4;
				}
				return 3;
			}
		}

		internal void StoreEp0((int, int, int) endpoint)
		{
			ulong num = (ulong)endpoint.Item1;
			ulong num2 = (ulong)endpoint.Item2;
			ulong num3 = (ulong)endpoint.Item3;
			(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 5, Math.Min(10, EndpointBits), num);
			(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 15, Math.Min(10, EndpointBits), num2);
			(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 25, Math.Min(10, EndpointBits), num3);
			switch (Type)
			{
			case Bc6BlockType.Type2:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 49, 1, num2 >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 59, 1, num3 >> 10);
				break;
			case Bc6BlockType.Type6:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 39, 1, num >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num2 >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 59, 1, num3 >> 10);
				break;
			case Bc6BlockType.Type10:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 39, 1, num >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 49, 1, num2 >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 10);
				break;
			case Bc6BlockType.Type7:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 44, 1, num >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 54, 1, num2 >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 64, 1, num3 >> 10);
				break;
			case Bc6BlockType.Type11:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 44, 1, num >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 54, 1, num2 >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 64, 1, num3 >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 43, 1, num >> 11);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 53, 1, num2 >> 11);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 63, 1, num3 >> 11);
				break;
			case Bc6BlockType.Type15:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 44, 1, num >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 54, 1, num2 >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 64, 1, num3 >> 10);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 43, 1, num >> 11);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 53, 1, num2 >> 11);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 63, 1, num3 >> 11);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 42, 1, num >> 12);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 52, 1, num2 >> 12);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 62, 1, num3 >> 12);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 41, 1, num >> 13);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 51, 1, num2 >> 13);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 61, 1, num3 >> 13);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num >> 14);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num2 >> 14);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 14);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 39, 1, num >> 15);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 49, 1, num2 >> 15);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 59, 1, num3 >> 15);
				break;
			}
		}

		internal readonly (int, int, int) ExtractEp0()
		{
			ulong num = 0uL;
			ulong num2 = 0uL;
			ulong num3 = 0uL;
			num = ByteHelper.ExtractFrom128(lowBits, highBits, 5, Math.Min(10, EndpointBits));
			num2 = ByteHelper.ExtractFrom128(lowBits, highBits, 15, Math.Min(10, EndpointBits));
			num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 25, Math.Min(10, EndpointBits));
			switch (Type)
			{
			case Bc6BlockType.Type2:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 10;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 49, 1) << 10;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 59, 1) << 10;
				break;
			case Bc6BlockType.Type6:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 39, 1) << 10;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1) << 10;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 59, 1) << 10;
				break;
			case Bc6BlockType.Type10:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 39, 1) << 10;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 49, 1) << 10;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 10;
				break;
			case Bc6BlockType.Type7:
				num = ByteHelper.ExtractFrom128(lowBits, highBits, 5, 10);
				num2 = ByteHelper.ExtractFrom128(lowBits, highBits, 15, 10);
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 25, 10);
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 44, 1) << 10;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 54, 1) << 10;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 64, 1) << 10;
				break;
			case Bc6BlockType.Type11:
				num = ByteHelper.ExtractFrom128(lowBits, highBits, 5, 10);
				num2 = ByteHelper.ExtractFrom128(lowBits, highBits, 15, 10);
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 25, 10);
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 44, 1) << 10;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 54, 1) << 10;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 64, 1) << 10;
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 43, 1) << 11;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 53, 1) << 11;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 63, 1) << 11;
				break;
			case Bc6BlockType.Type15:
				num = ByteHelper.ExtractFrom128(lowBits, highBits, 5, 10);
				num2 = ByteHelper.ExtractFrom128(lowBits, highBits, 15, 10);
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 25, 10);
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 44, 1) << 10;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 54, 1) << 10;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 64, 1) << 10;
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 43, 1) << 11;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 53, 1) << 11;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 63, 1) << 11;
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 42, 1) << 12;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 52, 1) << 12;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 62, 1) << 12;
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 41, 1) << 13;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 51, 1) << 13;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 61, 1) << 13;
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 14;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1) << 14;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 14;
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 39, 1) << 15;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 49, 1) << 15;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 59, 1) << 15;
				break;
			}
			return ((int)num, (int)num2, (int)num3);
		}

		internal void StoreEp1((int, int, int) endpoint)
		{
			ulong num = (ulong)endpoint.Item1;
			ulong num2 = (ulong)endpoint.Item2;
			ulong num3 = (ulong)endpoint.Item3;
			if (HasTransformedEndpoints)
			{
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 35, Math.Min(5, DeltaBits.Item1), num);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 45, Math.Min(5, DeltaBits.Item2), num2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 55, Math.Min(5, DeltaBits.Item3), num3);
			}
			switch (Type)
			{
			case Bc6BlockType.Type1:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num2 >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 5);
				break;
			case Bc6BlockType.Type18:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num >> 5);
				break;
			case Bc6BlockType.Type22:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num2 >> 5);
				break;
			case Bc6BlockType.Type26:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 5);
				break;
			case Bc6BlockType.Type30:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 35, 6, num);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 45, 6, num2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 55, 6, num3);
				break;
			case Bc6BlockType.Type3:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 35, 10, num);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 45, 10, num2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 55, 10, num3);
				break;
			case Bc6BlockType.Type7:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 4, num >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 4, num2 >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 4, num3 >> 5);
				break;
			case Bc6BlockType.Type11:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 3, num >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 3, num2 >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 3, num3 >> 5);
				break;
			}
		}

		internal readonly (int, int, int) ExtractEp1()
		{
			ulong num = 0uL;
			ulong num2 = 0uL;
			ulong num3 = 0uL;
			if (HasTransformedEndpoints)
			{
				num = ByteHelper.ExtractFrom128(lowBits, highBits, 35, Math.Min(5, DeltaBits.Item1));
				num2 = ByteHelper.ExtractFrom128(lowBits, highBits, 45, Math.Min(5, DeltaBits.Item2));
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 55, Math.Min(5, DeltaBits.Item3));
			}
			switch (Type)
			{
			case Bc6BlockType.Type1:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 5;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1) << 5;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 5;
				break;
			case Bc6BlockType.Type18:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 5;
				break;
			case Bc6BlockType.Type22:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1) << 5;
				break;
			case Bc6BlockType.Type26:
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 5;
				break;
			case Bc6BlockType.Type30:
				num = ByteHelper.ExtractFrom128(lowBits, highBits, 35, 6);
				num2 = ByteHelper.ExtractFrom128(lowBits, highBits, 45, 6);
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 55, 6);
				break;
			case Bc6BlockType.Type3:
				num = ByteHelper.ExtractFrom128(lowBits, highBits, 35, 10);
				num2 = ByteHelper.ExtractFrom128(lowBits, highBits, 45, 10);
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 55, 10);
				break;
			case Bc6BlockType.Type7:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 4) << 5;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 50, 4) << 5;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 4) << 5;
				break;
			case Bc6BlockType.Type11:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 3) << 5;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 50, 3) << 5;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 3) << 5;
				break;
			}
			return ((int)num, (int)num2, (int)num3);
		}

		internal void StoreEp2((int, int, int) endpoint)
		{
			ulong num = (ulong)endpoint.Item1;
			ulong num2 = (ulong)endpoint.Item2;
			ulong num3 = (ulong)endpoint.Item3;
			(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, 65, Math.Min(5, DeltaBits.Item1), num);
			lowBits = tuple.Item1;
			highBits = tuple.Item2;
			tuple = ByteHelper.StoreTo128(lowBits, highBits, 41, 4, num2);
			lowBits = tuple.Item1;
			highBits = tuple.Item2;
			tuple = ByteHelper.StoreTo128(lowBits, highBits, 61, 4, num3);
			lowBits = tuple.Item1;
			highBits = tuple.Item2;
			Bc6BlockType type = Type;
			switch (type)
			{
			case Bc6BlockType.Type1:
				if (type == Bc6BlockType.Type1)
				{
					(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 70, 1, num >> 5);
					(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 24, 1, num2 >> 4);
					(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 2, 1, num2 >> 5);
					(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 14, 1, num3 >> 4);
					(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 22, 1, num3 >> 5);
				}
				break;
			case Bc6BlockType.Type0:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 2, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 3, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type6:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 75, 1, num2 >> 4);
				break;
			case Bc6BlockType.Type10:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type14:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 24, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 14, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type18:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 70, 1, num >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 24, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 14, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type22:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 24, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 23, 1, num2 >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 14, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type26:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 24, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 14, 1, num3 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 23, 1, num3 >> 5);
				break;
			case Bc6BlockType.Type30:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 65, 6, num);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 24, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 21, 1, num2 >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 14, 1, num3 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 22, 1, num3 >> 5);
				break;
			}
		}

		internal readonly (int, int, int) ExtractEp2()
		{
			ulong num = 0uL;
			ulong num2 = 0uL;
			ulong num3 = 0uL;
			num = ByteHelper.ExtractFrom128(lowBits, highBits, 65, Math.Min(5, DeltaBits.Item1));
			num2 = ByteHelper.ExtractFrom128(lowBits, highBits, 41, 4);
			num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 61, 4);
			Bc6BlockType type = Type;
			switch (type)
			{
			case Bc6BlockType.Type1:
				if (type == Bc6BlockType.Type1)
				{
					num |= ByteHelper.ExtractFrom128(lowBits, highBits, 70, 1) << 5;
					num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 24, 1) << 4;
					num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 2, 1) << 5;
					num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 14, 1) << 4;
					num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 22, 1) << 5;
				}
				break;
			case Bc6BlockType.Type0:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 2, 1) << 4;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 3, 1) << 4;
				break;
			case Bc6BlockType.Type6:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 75, 1) << 4;
				break;
			case Bc6BlockType.Type10:
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 4;
				break;
			case Bc6BlockType.Type14:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 24, 1) << 4;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 14, 1) << 4;
				break;
			case Bc6BlockType.Type18:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 70, 1) << 5;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 24, 1) << 4;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 14, 1) << 4;
				break;
			case Bc6BlockType.Type22:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 24, 1) << 4;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 23, 1) << 5;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 14, 1) << 4;
				break;
			case Bc6BlockType.Type26:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 24, 1) << 4;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 14, 1) << 4;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 23, 1) << 5;
				break;
			case Bc6BlockType.Type30:
				num = ByteHelper.ExtractFrom128(lowBits, highBits, 65, 6);
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 24, 1) << 4;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 21, 1) << 5;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 14, 1) << 4;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 22, 1) << 5;
				break;
			}
			return ((int)num, (int)num2, (int)num3);
		}

		internal void StoreEp3((int, int, int) endpoint)
		{
			ulong num = (ulong)endpoint.Item1;
			ulong num2 = (ulong)endpoint.Item2;
			ulong num3 = (ulong)endpoint.Item3;
			(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 71, Math.Min(5, DeltaBits.Item1), num);
			(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 51, 4, num2);
			switch (Type)
			{
			case Bc6BlockType.Type0:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 1);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 70, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 76, 1, num3 >> 3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 4, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type1:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 76, 1, num >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 3, 2, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 12, 2, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 23, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 32, 1, num3 >> 3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 34, 1, num3 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 33, 1, num3 >> 5);
				break;
			case Bc6BlockType.Type2:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 1);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 70, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 76, 1, num3 >> 3);
				break;
			case Bc6BlockType.Type6:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 69, 1, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 1);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 70, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 76, 1, num3 >> 3);
				break;
			case Bc6BlockType.Type10:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 69, 1, num3 >> 1);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 70, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 76, 1, num3 >> 3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 75, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type14:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 1);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 70, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 76, 1, num3 >> 3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 34, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type18:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 76, 1, num >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 13, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 1);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 23, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 33, 1, num3 >> 3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 34, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type22:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 33, 1, num2 >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 13, 1, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 60, 1, num3 >> 1);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 70, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 76, 1, num3 >> 3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 34, 1, num3 >> 4);
				break;
			case Bc6BlockType.Type26:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 40, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 50, 1, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 13, 1, num3 >> 1);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 70, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 76, 1, num3 >> 3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 34, 1, num3 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 33, 1, num3 >> 5);
				break;
			case Bc6BlockType.Type30:
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 71, 6, num);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 11, 1, num2 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 31, 1, num2 >> 5);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 12, 2, num3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 23, 1, num3 >> 2);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 32, 1, num3 >> 3);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 34, 1, num3 >> 4);
				(lowBits, highBits) = ByteHelper.StoreTo128(lowBits, highBits, 33, 1, num3 >> 5);
				break;
			}
		}

		internal readonly (int, int, int) ExtractEp3()
		{
			ulong num = 0uL;
			ulong num2 = 0uL;
			ulong num3 = 0uL;
			num = ByteHelper.ExtractFrom128(lowBits, highBits, 71, Math.Min(5, DeltaBits.Item1));
			num2 = ByteHelper.ExtractFrom128(lowBits, highBits, 51, 4);
			switch (Type)
			{
			case Bc6BlockType.Type0:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 4;
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 1;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 70, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 76, 1) << 3;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 4, 1) << 4;
				break;
			case Bc6BlockType.Type1:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 76, 1) << 5;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 3, 2) << 4;
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 12, 2);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 23, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 32, 1) << 3;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 34, 1) << 4;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 33, 1) << 5;
				break;
			case Bc6BlockType.Type2:
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 1;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 70, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 76, 1) << 3;
				break;
			case Bc6BlockType.Type6:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 4;
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 69, 1);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 1;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 70, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 76, 1) << 3;
				break;
			case Bc6BlockType.Type10:
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 69, 1) << 1;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 70, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 76, 1) << 3;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 75, 1) << 4;
				break;
			case Bc6BlockType.Type14:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 4;
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 1;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 70, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 76, 1) << 3;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 34, 1) << 4;
				break;
			case Bc6BlockType.Type18:
				num |= ByteHelper.ExtractFrom128(lowBits, highBits, 76, 1) << 5;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 13, 1) << 4;
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 1;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 23, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 33, 1) << 3;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 34, 1) << 4;
				break;
			case Bc6BlockType.Type22:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 4;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 33, 1) << 5;
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 13, 1);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 60, 1) << 1;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 70, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 76, 1) << 3;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 34, 1) << 4;
				break;
			case Bc6BlockType.Type26:
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 40, 1) << 4;
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 50, 1);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 13, 1) << 1;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 70, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 76, 1) << 3;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 34, 1) << 4;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 33, 1) << 5;
				break;
			case Bc6BlockType.Type30:
				num = ByteHelper.ExtractFrom128(lowBits, highBits, 71, 6);
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 11, 1) << 4;
				num2 |= ByteHelper.ExtractFrom128(lowBits, highBits, 31, 1) << 5;
				num3 = ByteHelper.ExtractFrom128(lowBits, highBits, 12, 2);
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 23, 1) << 2;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 32, 1) << 3;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 34, 1) << 4;
				num3 |= ByteHelper.ExtractFrom128(lowBits, highBits, 33, 1) << 5;
				break;
			}
			return ((int)num, (int)num2, (int)num3);
		}

		private readonly (int, int, int)[] ExtractRawEndpoints(bool signedBc6)
		{
			(int, int, int)[] array = new(int, int, int)[HasSubsets ? 4 : 2];
			int endpointBits = EndpointBits;
			var (num, num2, num3) = ExtractEp0();
			if (signedBc6)
			{
				num = IntHelper.SignExtend(num, endpointBits);
				num2 = IntHelper.SignExtend(num2, endpointBits);
				num3 = IntHelper.SignExtend(num3, endpointBits);
			}
			array[0] = (num, num2, num3);
			int num4;
			int num5;
			int num6;
			(num4, num5, num6) = ExtractEp1();
			if (HasTransformedEndpoints)
			{
				num4 = IntHelper.SignExtend(num4, DeltaBits.Item1);
				num5 = IntHelper.SignExtend(num5, DeltaBits.Item2);
				num6 = IntHelper.SignExtend(num6, DeltaBits.Item3);
				num4 = (num4 + num) & ((1 << endpointBits) - 1);
				num5 = (num5 + num2) & ((1 << endpointBits) - 1);
				num6 = (num6 + num3) & ((1 << endpointBits) - 1);
			}
			if (signedBc6)
			{
				num4 = IntHelper.SignExtend(num4, endpointBits);
				num5 = IntHelper.SignExtend(num5, endpointBits);
				num6 = IntHelper.SignExtend(num6, endpointBits);
			}
			array[1] = (num4, num5, num6);
			if (HasSubsets)
			{
				int num7;
				int num8;
				int num9;
				(num7, num8, num9) = ExtractEp2();
				int num10;
				int num11;
				int num12;
				(num10, num11, num12) = ExtractEp3();
				if (HasTransformedEndpoints)
				{
					num7 = IntHelper.SignExtend(num7, DeltaBits.Item1);
					num8 = IntHelper.SignExtend(num8, DeltaBits.Item2);
					num9 = IntHelper.SignExtend(num9, DeltaBits.Item3);
					num7 = (num7 + num) & ((1 << endpointBits) - 1);
					num8 = (num8 + num2) & ((1 << endpointBits) - 1);
					num9 = (num9 + num3) & ((1 << endpointBits) - 1);
					num10 = IntHelper.SignExtend(num10, DeltaBits.Item1);
					num11 = IntHelper.SignExtend(num11, DeltaBits.Item2);
					num12 = IntHelper.SignExtend(num12, DeltaBits.Item3);
					num10 = (num10 + num) & ((1 << endpointBits) - 1);
					num11 = (num11 + num2) & ((1 << endpointBits) - 1);
					num12 = (num12 + num3) & ((1 << endpointBits) - 1);
				}
				if (signedBc6)
				{
					num7 = IntHelper.SignExtend(num7, endpointBits);
					num8 = IntHelper.SignExtend(num8, endpointBits);
					num9 = IntHelper.SignExtend(num9, endpointBits);
					num10 = IntHelper.SignExtend(num10, endpointBits);
					num11 = IntHelper.SignExtend(num11, endpointBits);
					num12 = IntHelper.SignExtend(num12, endpointBits);
				}
				array[2] = (num7, num8, num9);
				array[3] = (num10, num11, num12);
			}
			return array;
		}

		internal static int UnQuantize(int component, int endpointBits, bool signedBc6)
		{
			bool flag = false;
			int num;
			if (!signedBc6)
			{
				num = ((endpointBits >= 15) ? component : ((component != 0) ? ((component != (1 << endpointBits) - 1) ? ((component << 15) + 16384 >> endpointBits - 1) : 65535) : 0));
			}
			else if (endpointBits >= 16)
			{
				num = component;
			}
			else
			{
				if (component < 0)
				{
					flag = true;
					component = -component;
				}
				num = ((component != 0) ? ((component < (1 << endpointBits - 1) - 1) ? ((component << 15) + 16384 >> endpointBits - 1) : 32767) : 0);
				if (flag)
				{
					num = -num;
				}
			}
			return num;
		}

		internal static (int, int, int) UnQuantize((int, int, int) components, int endpointBits, bool signedBc6)
		{
			return (UnQuantize(components.Item1, endpointBits, signedBc6), UnQuantize(components.Item2, endpointBits, signedBc6), UnQuantize(components.Item3, endpointBits, signedBc6));
		}

		internal static Half FinishUnQuantize(int component, bool signedBc6)
		{
			if (!signedBc6)
			{
				component = component * 31 >> 6;
				return Half.ToHalf((ushort)component);
			}
			component = ((component < 0) ? (-(-component * 31 >> 5)) : (component * 31 >> 5));
			int num = 0;
			if (component < 0)
			{
				num = 32768;
				component = -component;
			}
			return Half.ToHalf((ushort)(num | component));
		}

		internal static (Half, Half, Half) FinishUnQuantize((int, int, int) components, bool signedBc6)
		{
			return (FinishUnQuantize(components.Item1, signedBc6), FinishUnQuantize(components.Item2, signedBc6), FinishUnQuantize(components.Item3, signedBc6));
		}

		private static int GetPartitionIndex(int numSubsets, int partitionSetId, int i)
		{
			return numSubsets switch
			{
				1 => 0, 
				2 => Subsets2PartitionTable[partitionSetId][i], 
				_ => throw new ArgumentOutOfRangeException("numSubsets", numSubsets, "Number of subsets can only be 1, 2 or 3"), 
			};
		}

		private static int GetIndexOffset(int numSubsets, int partitionIndex, int bitCount, int index)
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
				int num = Subsets2AnchorIndices[partitionIndex];
				if (index <= num)
				{
					return bitCount * index - 1;
				}
				return bitCount * index - 2;
			}
			default:
				throw new ArgumentOutOfRangeException("numSubsets", numSubsets, "Number of subsets can only be 1, 2 or 3");
			}
		}

		private static int GetIndexBitCount(int numSubsets, int partitionIndex, int bitCount, int index)
		{
			if (index == 0)
			{
				return bitCount - 1;
			}
			if (numSubsets == 2)
			{
				int num = Subsets2AnchorIndices[partitionIndex];
				if (index == num)
				{
					return bitCount - 1;
				}
			}
			return bitCount;
		}

		private readonly int GetIndexBegin()
		{
			if (!HasSubsets)
			{
				return 65;
			}
			return 82;
		}

		internal readonly int GetColorIndex(int numSubsets, int partitionIndex, int bitCount, int index)
		{
			int indexOffset = GetIndexOffset(numSubsets, partitionIndex, bitCount, index);
			int indexBitCount = GetIndexBitCount(numSubsets, partitionIndex, bitCount, index);
			int indexBegin = GetIndexBegin();
			return (int)ByteHelper.ExtractFrom128(lowBits, highBits, indexBegin + indexOffset, indexBitCount);
		}

		internal static (int, int, int) InterpolateColor((int, int, int) endPointStart, (int, int, int) endPointEnd, int colorIndex, int colorBitCount)
		{
			return (BptcEncodingHelpers.InterpolateInt(endPointStart.Item1, endPointEnd.Item1, colorIndex, colorBitCount), BptcEncodingHelpers.InterpolateInt(endPointStart.Item2, endPointEnd.Item2, colorIndex, colorBitCount), BptcEncodingHelpers.InterpolateInt(endPointStart.Item3, endPointEnd.Item3, colorIndex, colorBitCount));
		}

		public readonly RawBlock4X4RgbFloat Decode(bool signed)
		{
			RawBlock4X4RgbFloat result = default(RawBlock4X4RgbFloat);
			Span<ColorRgbFloat> asSpan = result.AsSpan;
			if (Type == Bc6BlockType.Unknown)
			{
				return ErrorBlock;
			}
			(int, int, int)[] array = ExtractRawEndpoints(signed);
			int numSubsets = 1;
			int num = 0;
			if (HasSubsets)
			{
				numSubsets = 2;
				num = PartitionSetId;
			}
			for (int i = 0; i < NumEndpoints; i++)
			{
				array[i] = UnQuantize(array[i], EndpointBits, signed);
			}
			for (int j = 0; j < asSpan.Length; j++)
			{
				int partitionIndex = GetPartitionIndex(numSubsets, num, j);
				(int, int, int) endPointStart = array[2 * partitionIndex];
				(int, int, int) endPointEnd = array[2 * partitionIndex + 1];
				int colorIndex = GetColorIndex(numSubsets, num, ColorIndexBitCount, j);
				var (half, half2, half3) = FinishUnQuantize(InterpolateColor(endPointStart, endPointEnd, colorIndex, ColorIndexBitCount), signed);
				asSpan[j] = new ColorRgbFloat(half, half2, half3);
			}
			return result;
		}

		private void StoreIndices(Span<byte> indices)
		{
			int numSubsets = ((!HasSubsets) ? 1 : 2);
			int partitionSetId = PartitionSetId;
			int colorIndexBitCount = ColorIndexBitCount;
			int indexBegin = GetIndexBegin();
			for (int i = 0; i < indices.Length; i++)
			{
				int partitionIndex = GetPartitionIndex(numSubsets, partitionSetId, i);
				int indexOffset = GetIndexOffset(numSubsets, partitionIndex, colorIndexBitCount, i);
				int indexBitCount = GetIndexBitCount(numSubsets, partitionIndex, colorIndexBitCount, i);
				(ulong, ulong) tuple = ByteHelper.StoreTo128(lowBits, highBits, indexBegin + indexOffset, indexBitCount, indices[i]);
				lowBits = tuple.Item1;
				highBits = tuple.Item2;
			}
		}

		private void StorePartitionSetId(int partitionSetId)
		{
			highBits = ByteHelper.Store5(highBits, 13, (byte)partitionSetId);
		}

		public static Bc6Block PackType0((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 0uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType1((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 1uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType2((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 2uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType6((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 6uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType10((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 10uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType14((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 14uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType18((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 18uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType22((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 22uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType26((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 26uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType30((int, int, int) endpoint0, (int, int, int) endpoint1, (int, int, int) endpoint2, (int, int, int) endpoint3, int partitionSetId, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 30uL;
			result.StorePartitionSetId(partitionSetId);
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreEp2(endpoint2);
			result.StoreEp3(endpoint3);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType3((int, int, int) endpoint0, (int, int, int) endpoint1, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 3uL;
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType7((int, int, int) endpoint0, (int, int, int) endpoint1, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 7uL;
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType11((int, int, int) endpoint0, (int, int, int) endpoint1, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 11uL;
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreIndices(indices);
			return result;
		}

		public static Bc6Block PackType15((int, int, int) endpoint0, (int, int, int) endpoint1, Span<byte> indices)
		{
			Bc6Block result = default(Bc6Block);
			result.lowBits = 15uL;
			result.StoreEp0(endpoint0);
			result.StoreEp1(endpoint1);
			result.StoreIndices(indices);
			return result;
		}
	}
}
