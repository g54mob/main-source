using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Bptc
{
	internal static class Bc7Mode7Encoder
	{
		public static Bc7Block EncodeBlock(RawBlock4X4Rgba32 block, int startingVariation, int bestPartition)
		{
			Bc7Block result = default(Bc7Block);
			ColorRgba32[] array = new ColorRgba32[4];
			byte[] array2 = new byte[4];
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
				ColorRgba32 ep3 = Bc7EncodingHelpers.ScaleDownEndpoint(ep, Bc7BlockType.Type7, ignoreAlpha: false, out pBit);
				byte pBit2;
				ColorRgba32 ep4 = Bc7EncodingHelpers.ScaleDownEndpoint(ep2, Bc7BlockType.Type7, ignoreAlpha: false, out pBit2);
				Bc7EncodingHelpers.OptimizeSubsetEndpointsWithPBit(Bc7BlockType.Type7, block, ref ep3, ref ep4, ref pBit, ref pBit2, startingVariation, partitionTable, i, variatePBits: true, variateAlpha: true);
				ep = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type7, ep3, pBit);
				ep2 = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type7, ep4, pBit2);
				Bc7EncodingHelpers.FillSubsetIndices(Bc7BlockType.Type7, block, ep, ep2, partitionTable, i, array3);
				if ((array3[array4[i]] & 2) > 0)
				{
					ColorRgba32 colorRgba = ep3;
					byte b = pBit;
					ep3 = ep4;
					pBit = pBit2;
					ep4 = colorRgba;
					pBit2 = b;
					ep = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type7, ep3, pBit);
					ep2 = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type7, ep4, pBit2);
					Bc7EncodingHelpers.FillSubsetIndices(Bc7BlockType.Type7, block, ep, ep2, partitionTable, i, array3);
				}
				array[i * 2] = ep3;
				array[i * 2 + 1] = ep4;
				array2[i * 2] = pBit;
				array2[i * 2 + 1] = pBit2;
			}
			result.PackType7(bestPartition, new byte[4][]
			{
				new byte[4]
				{
					array[0].r,
					array[0].g,
					array[0].b,
					array[0].a
				},
				new byte[4]
				{
					array[1].r,
					array[1].g,
					array[1].b,
					array[1].a
				},
				new byte[4]
				{
					array[2].r,
					array[2].g,
					array[2].b,
					array[2].a
				},
				new byte[4]
				{
					array[3].r,
					array[3].g,
					array[3].b,
					array[3].a
				}
			}, array2, array3);
			return result;
		}
	}
}
