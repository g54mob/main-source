using BCnEncoder.Shared;

namespace BCnEncoder.Decoder
{
	internal class Bc6SDecoder : BaseBcBlockDecoder<Bc6Block, RawBlock4X4RgbFloat>
	{
		protected override RawBlock4X4RgbFloat DecodeBlock(Bc6Block block)
		{
			return block.Decode(signed: true);
		}
	}
}
