using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal class Bc5Decoder : BaseBcBlockDecoder<Bc5Block, RawBlock4X4Rgba32>
	{
		private readonly ColorComponent component1;

		private readonly ColorComponent component2;

		public Bc5Decoder(ColorComponent component1, ColorComponent component2)
		{
			this.component1 = component1;
			this.component2 = component2;
		}

		protected override RawBlock4X4Rgba32 DecodeBlock(Bc5Block block)
		{
			return block.Decode(component1, component2);
		}
	}
}
