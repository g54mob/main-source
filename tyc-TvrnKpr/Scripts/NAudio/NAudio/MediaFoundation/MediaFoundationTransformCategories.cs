using System;
using NAudio.Utils;

namespace NAudio.MediaFoundation
{
	public static class MediaFoundationTransformCategories
	{
		[FieldDescription("Video Decoder")]
		public static readonly Guid VideoDecoder;

		[FieldDescription("Video Encoder")]
		public static readonly Guid VideoEncoder;

		[FieldDescription("Video Effect")]
		public static readonly Guid VideoEffect;

		[FieldDescription("Multiplexer")]
		public static readonly Guid Multiplexer;

		[FieldDescription("Demultiplexer")]
		public static readonly Guid Demultiplexer;

		[FieldDescription("Audio Decoder")]
		public static readonly Guid AudioDecoder;

		[FieldDescription("Audio Encoder")]
		public static readonly Guid AudioEncoder;

		[FieldDescription("Audio Effect")]
		public static readonly Guid AudioEffect;

		[FieldDescription("Video Processor")]
		public static readonly Guid VideoProcessor;

		[FieldDescription("Other")]
		public static readonly Guid Other;
	}
}
