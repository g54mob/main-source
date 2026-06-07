using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class AtcBlockEncoder : BaseBcBlockEncoder<AtcBlock, RawBlock4X4Rgba32>
	{
		private readonly Bc1BlockEncoder bc1BlockEncoder;

		public AtcBlockEncoder()
		{
			bc1BlockEncoder = new Bc1BlockEncoder();
		}

		public unsafe override AtcBlock EncodeBlock(RawBlock4X4Rgba32 block, CompressionQuality quality)
		{
			AtcBlock result = default(AtcBlock);
			Bc1Block bc1Block = bc1BlockEncoder.EncodeBlock(block, quality);
			result.color0 = new ColorRgb555(bc1Block.color0.R, bc1Block.color0.G, bc1Block.color0.B);
			result.color1 = bc1Block.color1;
			byte* ptr = stackalloc byte[4] { 0, 3, 1, 2 };
			for (int i = 0; i < 16; i++)
			{
				result[i] = ptr[bc1Block[i]];
			}
			return result;
		}

		public override GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlCompressedRgbAtc;
		}

		public override GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgb;
		}

		public override DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatAtcExt;
		}
	}
}
