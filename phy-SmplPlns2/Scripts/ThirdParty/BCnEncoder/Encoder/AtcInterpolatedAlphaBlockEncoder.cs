using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class AtcInterpolatedAlphaBlockEncoder : BaseBcBlockEncoder<AtcInterpolatedAlphaBlock, RawBlock4X4Rgba32>
	{
		private readonly Bc4ComponentBlockEncoder bc4BlockEncoder;

		private readonly AtcBlockEncoder atcBlockEncoder;

		public AtcInterpolatedAlphaBlockEncoder()
		{
			bc4BlockEncoder = new Bc4ComponentBlockEncoder(ColorComponent.A);
			atcBlockEncoder = new AtcBlockEncoder();
		}

		public override AtcInterpolatedAlphaBlock EncodeBlock(RawBlock4X4Rgba32 block, CompressionQuality quality)
		{
			Bc4ComponentBlock alphas = bc4BlockEncoder.EncodeBlock(block, quality);
			AtcBlock colors = atcBlockEncoder.EncodeBlock(block, quality);
			return new AtcInterpolatedAlphaBlock
			{
				alphas = alphas,
				colors = colors
			};
		}

		public override GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlCompressedRgbaAtcInterpolatedAlpha;
		}

		public override GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgba;
		}

		public override DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatAtcInterpolatedAlphaExt;
		}
	}
}
