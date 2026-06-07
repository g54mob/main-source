using BCnEncoder.Shared;

namespace BCnEncoder.Decoder.Options
{
	public class DecoderOutputOptions
	{
		public bool RedAsLuminance { get; set; } = true;

		public ColorComponent Bc4Component { get; set; }

		public ColorComponent Bc5Component1 { get; set; }

		public ColorComponent Bc5Component2 { get; set; } = ColorComponent.G;
	}
}
