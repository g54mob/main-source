using BCnEncoder.Shared;

namespace BCnEncoder.Encoder.Options
{
	public class EncoderOutputOptions
	{
		public bool GenerateMipMaps { get; set; } = true;

		public int MaxMipMapLevel { get; set; } = -1;

		public CompressionFormat Format { get; set; } = CompressionFormat.Bc1;

		public CompressionQuality Quality { get; set; } = CompressionQuality.Balanced;

		public OutputFileFormat FileFormat { get; set; }

		public bool DdsBc1WriteAlphaFlag { get; set; }

		public bool DdsPreferDxt10Header { get; set; }
	}
}
