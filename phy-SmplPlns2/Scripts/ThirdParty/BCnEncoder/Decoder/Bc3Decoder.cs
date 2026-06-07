using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal class Bc3Decoder : BaseBcBlockDecoder<Bc3Block, RawBlock4X4Rgba32>
	{
		protected override RawBlock4X4Rgba32 DecodeBlock(Bc3Block block)
		{
			return block.Decode();
		}
	}
}
