using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class AtcExplicitAlphaBlockEncoder : BaseBcBlockEncoder<AtcExplicitAlphaBlock, RawBlock4X4Rgba32>
	{
		private readonly AtcBlockEncoder atcBlockEncoder;

		public AtcExplicitAlphaBlockEncoder()
		{
			atcBlockEncoder = new AtcBlockEncoder();
		}

		public override AtcExplicitAlphaBlock EncodeBlock(RawBlock4X4Rgba32 block, CompressionQuality quality)
		{
			AtcBlock colors = atcBlockEncoder.EncodeBlock(block, quality);
			Bc2AlphaBlock alphas = default(Bc2AlphaBlock);
			for (int i = 0; i < 16; i++)
			{
				alphas.SetAlpha(i, block[i].a);
			}
			return new AtcExplicitAlphaBlock
			{
				alphas = alphas,
				colors = colors
			};
		}

		public override GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlCompressedRgbaAtcExplicitAlpha;
		}

		public override GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgba;
		}

		public override DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatAtcExplicitAlphaExt;
		}
	}
}
