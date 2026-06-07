using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Bptc
{
	internal static class Bc7Mode6Encoder
	{
		public static Bc7Block EncodeBlock(RawBlock4X4Rgba32 block, int startingVariation)
		{
			bool flag = block.HasTransparentPixels();
			Bc7Block result = default(Bc7Block);
			Bc7EncodingHelpers.GetInitialUnscaledEndpoints(block, out var ep, out var ep2);
			byte pBit;
			ColorRgba32 ep3 = Bc7EncodingHelpers.ScaleDownEndpoint(ep, Bc7BlockType.Type6, ignoreAlpha: false, out pBit);
			byte pBit2;
			ColorRgba32 ep4 = Bc7EncodingHelpers.ScaleDownEndpoint(ep2, Bc7BlockType.Type6, ignoreAlpha: false, out pBit2);
			ReadOnlySpan<int> partitionTable = new int[16];
			if (!flag)
			{
				pBit = 1;
				pBit2 = 1;
			}
			Bc7EncodingHelpers.OptimizeSubsetEndpointsWithPBit(Bc7BlockType.Type6, block, ref ep3, ref ep4, ref pBit, ref pBit2, startingVariation, partitionTable, 0, flag, flag);
			ep = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type6, ep3, pBit);
			ep2 = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type6, ep4, pBit2);
			byte[] array = new byte[16];
			Bc7EncodingHelpers.FillSubsetIndices(Bc7BlockType.Type6, block, ep, ep2, partitionTable, 0, array);
			if ((array[0] & 8) > 0)
			{
				ColorRgba32 colorRgba = ep3;
				byte b = pBit;
				ep3 = ep4;
				pBit = pBit2;
				ep4 = colorRgba;
				pBit2 = b;
				ep = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type6, ep3, pBit);
				ep2 = Bc7EncodingHelpers.ExpandEndpoint(Bc7BlockType.Type6, ep4, pBit2);
				Bc7EncodingHelpers.FillSubsetIndices(Bc7BlockType.Type6, block, ep, ep2, partitionTable, 0, array);
			}
			result.PackType6(new byte[2][]
			{
				new byte[4] { ep3.r, ep3.g, ep3.b, ep3.a },
				new byte[4] { ep4.r, ep4.g, ep4.b, ep4.a }
			}, new byte[2] { pBit, pBit2 }, array);
			return result;
		}
	}
}
