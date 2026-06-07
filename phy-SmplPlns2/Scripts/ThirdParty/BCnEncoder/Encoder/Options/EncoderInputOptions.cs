using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Options
{
	public class EncoderInputOptions
	{
		public bool LuminanceAsRed { get; set; }

		public ColorComponent Bc4Component { get; set; }

		public ColorComponent Bc5Component1 { get; set; }

		public ColorComponent Bc5Component2 { get; set; } = ColorComponent.G;
	}
}
