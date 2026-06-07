using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal class Bc4Decoder : BaseBcBlockDecoder<Bc4Block, RawBlock4X4Rgba32>
	{
		private readonly ColorComponent component;

		public Bc4Decoder(ColorComponent component)
		{
			this.component = component;
		}

		protected override RawBlock4X4Rgba32 DecodeBlock(Bc4Block block)
		{
			return block.Decode(component);
		}
	}
}
