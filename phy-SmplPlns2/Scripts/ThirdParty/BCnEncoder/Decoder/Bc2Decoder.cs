using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal class Bc2Decoder : BaseBcBlockDecoder<Bc2Block, RawBlock4X4Rgba32>
	{
		protected override RawBlock4X4Rgba32 DecodeBlock(Bc2Block block)
		{
			return block.Decode();
		}
	}
}
