using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Bptc
{
	internal static class Bc7Mode5Encoder
	{
		private const int Subset = 0;

		private static ReadOnlySpan<int> PartitionTable => new int[16];

		public static Bc7Block EncodeBlock(RawBlock4X4Rgba32 block, int startingVariation)
		{
			Bc7BlockType type = Bc7BlockType.Type5;
			Span<Bc7Block> span = stackalloc Bc7Block[4];
			for (int i = 0; i < 4; i++)
			{
				RawBlock4X4Rgba32 rawBlock4X4Rgba = Bc7EncodingHelpers.RotateBlockColors(block, i);
				Bc7Block bc7Block = default(Bc7Block);
				Bc7EncodingHelpers.GetInitialUnscaledEndpoints(rawBlock4X4Rgba, out var ep, out var ep2);
				byte pBit;
				ColorRgba32 ep3 = Bc7EncodingHelpers.ScaleDownEndpoint(ep, type, ignoreAlpha: false, out pBit);
				ColorRgba32 ep4 = Bc7EncodingHelpers.ScaleDownEndpoint(ep2, type, ignoreAlpha: false, out pBit);
				byte pBit2 = 0;
				Bc7EncodingHelpers.OptimizeSubsetEndpointsWithPBit(type, rawBlock4X4Rgba, ref ep3, ref ep4, ref pBit2, ref pBit2, startingVariation, PartitionTable, 0, variatePBits: false, variateAlpha: true);
				ep = Bc7EncodingHelpers.ExpandEndpoint(type, ep3, 0);
				ep2 = Bc7EncodingHelpers.ExpandEndpoint(type, ep4, 0);
				byte[] array = new byte[16];
				byte[] array2 = new byte[16];
				Bc7EncodingHelpers.FillAlphaColorIndices(type, rawBlock4X4Rgba, ep, ep2, array, array2);
				bool flag = false;
				if ((array[0] & 2) > 0)
				{
					ColorRgba32 colorRgba = ep3;
					byte a = ep3.a;
					byte a2 = ep4.a;
					ep3 = ep4;
					ep4 = colorRgba;
					ep3.a = a;
					ep4.a = a2;
					flag = true;
				}
				if ((array2[0] & 2) > 0)
				{
					byte a3 = ep3.a;
					ep3.a = ep4.a;
					ep4.a = a3;
					flag = true;
				}
				if (flag)
				{
					ep = Bc7EncodingHelpers.ExpandEndpoint(type, ep3, 0);
					ep2 = Bc7EncodingHelpers.ExpandEndpoint(type, ep4, 0);
					Bc7EncodingHelpers.FillAlphaColorIndices(type, rawBlock4X4Rgba, ep, ep2, array, array2);
				}
				bc7Block.PackType5(i, new byte[2][]
				{
					new byte[3] { ep3.r, ep3.g, ep3.b },
					new byte[3] { ep4.r, ep4.g, ep4.b }
				}, new byte[2] { ep3.a, ep4.a }, array, array2);
				span[i] = bc7Block;
			}
			int index = 0;
			float num = 0f;
			bool flag2 = true;
			for (int j = 0; j < span.Length; j++)
			{
				RawBlock4X4Rgba32 other = span[j].Decode();
				float num2 = block.CalculateYCbCrAlphaError(other);
				if (num2 < num || flag2)
				{
					flag2 = false;
					num = num2;
					index = j;
				}
			}
			return span[index];
		}
	}
}
