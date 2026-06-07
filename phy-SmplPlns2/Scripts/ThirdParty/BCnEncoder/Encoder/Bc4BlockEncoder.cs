using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class Bc4BlockEncoder : BaseBcBlockEncoder<Bc4Block, RawBlock4X4Rgba32>
	{
		private readonly Bc4ComponentBlockEncoder bc4Encoder;

		public Bc4BlockEncoder(ColorComponent component)
		{
			bc4Encoder = new Bc4ComponentBlockEncoder(component);
		}

		public override Bc4Block EncodeBlock(RawBlock4X4Rgba32 block, CompressionQuality quality)
		{
			return new Bc4Block
			{
				componentBlock = bc4Encoder.EncodeBlock(block, quality)
			};
		}

		public override GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlCompressedRedRgtc1Ext;
		}

		public override GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRed;
		}

		public override DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatBc4Unorm;
		}
	}
}
