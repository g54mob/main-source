using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal class Bc7Decoder : BaseBcBlockDecoder<Bc7Block, RawBlock4X4Rgba32>
	{
		protected override RawBlock4X4Rgba32 DecodeBlock(Bc7Block block)
		{
			return block.Decode();
		}
	}
}
