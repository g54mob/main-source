using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal class AtcExplicitAlphaDecoder : BaseBcBlockDecoder<AtcExplicitAlphaBlock, RawBlock4X4Rgba32>
	{
		protected override RawBlock4X4Rgba32 DecodeBlock(AtcExplicitAlphaBlock block)
		{
			return block.Decode();
		}
	}
}
