using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Bptc
{
	internal static class Bc7Mode2Encoder
	{
		public static Bc7Block EncodeBlock(RawBlock4X4Rgba32 block, int startingVariation, int bestPartition)
		{
			Bc7Block result = default(Bc7Block);
			ColorRgba32[] array = new ColorRgba32[6];
			ReadOnlySpan<int> partitionTable = Bc7Block.Subsets3PartitionTable[bestPartition];
			byte[] array2 = new byte[16];
			int[] array3 = new int[3]
			{
				0,
				Bc7Block.Subsets3AnchorIndices2[bestPartition],
				Bc7Block.Subsets3AnchorIndices3[bestPartition]
			};
			for (int i = 0; i < 3; i++)
			{
				Bc7EncodingHelpers.GetInitialUnscaledEndpointsForSubset(block, out var ep, out var ep2, partitionTable, i);
				byte pBit;
				ColorRgba32 ep3 = Bc7EncodingHelpers.ScaleDownEndpoint(ep, Bc7BlockType.Type2, ignoreAlpha: true, out pBit);
				ColorRgba32 ep4 = Bc7EncodingHelpers.ScaleDownEndpoint(ep2, Bc7BlockType.Type2, ignoreAlpha: true, out pBit);
				byte pBit2 = 0;
				Bc7EncodingHelpers.OptimizeSubsetEndpointsWithPBit(Bc7BlockType.Type2, block, ref ep3, ref ep4, ref pBit2, ref pBit2, startingVariation, partitionTable, i, variatePBits: false, variateAlpha: false);
				ep = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type2, ep3, 0);
				ep2 = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type2, ep4, 0);
				Bc7EncodingHelpers.FillSubsetIndices(Bc7BlockType.Type2, block, ep, ep2, partitionTable, i, array2);
				if ((array2[array3[i]] & 2) > 0)
				{
					ColorRgba32 colorRgba = ep3;
					ep3 = ep4;
					ep4 = colorRgba;
					ep = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type2, ep3, 0);
					ep2 = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type2, ep4, 0);
					Bc7EncodingHelpers.FillSubsetIndices(Bc7BlockType.Type2, block, ep, ep2, partitionTable, i, array2);
				}
				array[i * 2] = ep3;
				array[i * 2 + 1] = ep4;
			}
			result.PackType2(bestPartition, new byte[6][]
			{
				new byte[3]
				{
					array[0].r,
					array[0].g,
					array[0].b
				},
				new byte[3]
				{
					array[1].r,
					array[1].g,
					array[1].b
				},
				new byte[3]
				{
					array[2].r,
					array[2].g,
					array[2].b
				},
				new byte[3]
				{
					array[3].r,
					array[3].g,
					array[3].b
				},
				new byte[3]
				{
					array[4].r,
					array[4].g,
					array[4].b
				},
				new byte[3]
				{
					array[5].r,
					array[5].g,
					array[5].b
				}
			}, array2);
			return result;
		}
	}
}
