using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Bptc
{
	internal static class Bc7Mode1Encoder
	{
		public static Bc7Block EncodeBlock(RawBlock4X4Rgba32 block, int startingVariation, int bestPartition)
		{
			Bc7Block result = default(Bc7Block);
			ColorRgba32[] array = new ColorRgba32[4];
			byte[] array2 = new byte[2];
			ReadOnlySpan<int> partitionTable = Bc7Block.Subsets2PartitionTable[bestPartition];
			byte[] array3 = new byte[16];
			int[] array4 = new int[2]
			{
				0,
				Bc7Block.Subsets2AnchorIndices[bestPartition]
			};
			for (int i = 0; i < 2; i++)
			{
				Bc7EncodingHelpers.GetInitialUnscaledEndpointsForSubset(block, out var ep, out var ep2, partitionTable, i);
				byte pBit;
				ColorRgba32 ep3 = Bc7EncodingHelpers.ScaleDownEndpoint(ep, Bc7BlockType.Type1, ignoreAlpha: true, out pBit);
				ColorRgba32 ep4 = Bc7EncodingHelpers.ScaleDownEndpoint(ep2, Bc7BlockType.Type1, ignoreAlpha: true, out pBit);
				Bc7EncodingHelpers.OptimizeSubsetEndpointsWithPBit(Bc7BlockType.Type1, block, ref ep3, ref ep4, ref pBit, ref pBit, startingVariation, partitionTable, i, variatePBits: true, variateAlpha: false);
				ep = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type1, ep3, pBit);
				ep2 = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type1, ep4, pBit);
				Bc7EncodingHelpers.FillSubsetIndices(Bc7BlockType.Type1, block, ep, ep2, partitionTable, i, array3);
				if ((array3[array4[i]] & 4) > 0)
				{
					ColorRgba32 colorRgba = ep3;
					ep3 = ep4;
					ep4 = colorRgba;
					ep = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type1, ep3, pBit);
					ep2 = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type1, ep4, pBit);
					Bc7EncodingHelpers.FillSubsetIndices(Bc7BlockType.Type1, block, ep, ep2, partitionTable, i, array3);
				}
				array[i * 2] = ep3;
				array[i * 2 + 1] = ep4;
				array2[i] = pBit;
			}
			result.PackType1(bestPartition, new byte[4][]
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
				}
			}, array2, array3);
			return result;
		}
	}
}
