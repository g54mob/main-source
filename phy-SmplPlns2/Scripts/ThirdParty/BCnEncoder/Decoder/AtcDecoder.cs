using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal class AtcDecoder : BaseBcBlockDecoder<AtcBlock, RawBlock4X4Rgba32>
	{
		protected override RawBlock4X4Rgba32 DecodeBlock(AtcBlock block)
		{
			return block.Decode();
		}
	}
}
