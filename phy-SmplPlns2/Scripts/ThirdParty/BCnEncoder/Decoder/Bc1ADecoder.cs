using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal class Bc1ADecoder : BaseBcBlockDecoder<Bc1Block, RawBlock4X4Rgba32>
	{
		protected override RawBlock4X4Rgba32 DecodeBlock(Bc1Block block)
		{
			return block.Decode(useAlpha: true);
		}
	}
}
