using System;
using System.Linq;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Bptc
{
	internal static class BptcEncodingHelpers
	{
		private static readonly byte[] ColorInterpolationWeights2 = new byte[4] { 0, 21, 43, 64 };

		private static readonly byte[] ColorInterpolationWeights3 = new byte[8] { 0, 9, 18, 27, 37, 46, 55, 64 };

		private static readonly byte[] ColorInterpolationWeights4 = new byte[16]
		{
			0, 4, 9, 13, 17, 21, 26, 30, 34, 38,
			43, 47, 51, 55, 60, 64
		};

		public static int InterpolateInt(int e0, int e1, int index, int indexPrecision)
		{
			if (indexPrecision == 0)
			{
				return e0;
			}
			byte[] colorInterpolationWeights = ColorInterpolationWeights2;
			byte[] colorInterpolationWeights2 = ColorInterpolationWeights3;
			byte[] colorInterpolationWeights3 = ColorInterpolationWeights4;
			return indexPrecision switch
			{
				2 => (64 - colorInterpolationWeights[index]) * e0 + colorInterpolationWeights[index] * e1 + 32 >> 6, 
				3 => (64 - colorInterpolationWeights2[index]) * e0 + colorInterpolationWeights2[index] * e1 + 32 >> 6, 
				_ => (64 - colorInterpolationWeights3[index]) * e0 + colorInterpolationWeights3[index] * e1 + 32 >> 6, 
			};
		}

		public static byte InterpolateByte(byte e0, byte e1, int index, int indexPrecision)
		{
			if (indexPrecision == 0)
			{
				return e0;
			}
			byte[] colorInterpolationWeights = ColorInterpolationWeights2;
			byte[] colorInterpolationWeights2 = ColorInterpolationWeights3;
			byte[] colorInterpolationWeights3 = ColorInterpolationWeights4;
			return indexPrecision switch
			{
				2 => (byte)((64 - colorInterpolationWeights[index]) * e0 + colorInterpolationWeights[index] * e1 + 32 >> 6), 
				3 => (byte)((64 - colorInterpolationWeights2[index]) * e0 + colorInterpolationWeights2[index] * e1 + 32 >> 6), 
				_ => (byte)((64 - colorInterpolationWeights3[index]) * e0 + colorInterpolationWeights3[index] * e1 + 32 >> 6), 
			};
		}

		public static int[] Rank2SubsetPartitions(ClusterIndices4X4 reducedIndicesBlock, int numDistinctClusters, bool smallIndex = false)
		{
			return Enumerable.Range(0, smallIndex ? 32 : 64).ToArray().OrderBy(CalculatePartitionError)
				.ToArray();
			int CalculatePartitionError(int partitionIndex)
			{
				int num = 0;
				ReadOnlySpan<int> readOnlySpan = Bc7Block.Subsets2PartitionTable[partitionIndex];
				Span<int> span = stackalloc int[numDistinctClusters];
				Span<int> span2 = stackalloc int[numDistinctClusters];
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 16; i++)
				{
					if (readOnlySpan[i] == 0)
					{
						int num4 = reducedIndicesBlock[i];
						span[num4]++;
						if (span[num4] > span[num2])
						{
							num2 = num4;
						}
					}
					else
					{
						int num5 = reducedIndicesBlock[i];
						span2[num5]++;
						if (span2[num5] > span2[num3])
						{
							num3 = num5;
						}
					}
				}
				for (int j = 0; j < 16; j++)
				{
					if (readOnlySpan[j] == 0)
					{
						if (reducedIndicesBlock[j] != num2)
						{
							num++;
						}
					}
					else if (reducedIndicesBlock[j] != num3)
					{
						num++;
					}
				}
				return num;
			}
		}

		public static int[] Rank3SubsetPartitions(ClusterIndices4X4 reducedIndicesBlock, int numDistinctClusters)
		{
			return Enumerable.Range(0, 64).ToArray().OrderBy(CalculatePartitionError)
				.ToArray();
			int CalculatePartitionError(int partitionIndex)
			{
				int num = 0;
				ReadOnlySpan<int> readOnlySpan = Bc7Block.Subsets3PartitionTable[partitionIndex];
				Span<int> span = stackalloc int[numDistinctClusters];
				Span<int> span2 = stackalloc int[numDistinctClusters];
				Span<int> span3 = stackalloc int[numDistinctClusters];
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				for (int i = 0; i < 16; i++)
				{
					if (readOnlySpan[i] == 0)
					{
						int num5 = reducedIndicesBlock[i];
						span[num5]++;
						if (span[num5] > span[num2])
						{
							num2 = num5;
						}
					}
					else if (readOnlySpan[i] == 1)
					{
						int num6 = reducedIndicesBlock[i];
						span2[num6]++;
						if (span2[num6] > span2[num3])
						{
							num3 = num6;
						}
					}
					else
					{
						int num7 = reducedIndicesBlock[i];
						span3[num7]++;
						if (span3[num7] > span3[num4])
						{
							num4 = num7;
						}
					}
				}
				for (int j = 0; j < 16; j++)
				{
					if (readOnlySpan[j] == 0)
					{
						if (reducedIndicesBlock[j] != num2)
						{
							num++;
						}
					}
					else if (readOnlySpan[j] == 1)
					{
						if (reducedIndicesBlock[j] != num3)
						{
							num++;
						}
					}
					else if (reducedIndicesBlock[j] != num4)
					{
						num++;
					}
				}
				return num;
			}
		}
	}
}
