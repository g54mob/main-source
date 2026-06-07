using System;
using NAudio.Utils;

namespace NAudio.MediaFoundation
{
	public static class MediaTypes
	{
		public static readonly Guid MFMediaType_Default;

		[FieldDescription("Audio")]
		public static readonly Guid MFMediaType_Audio;

		[FieldDescription("Video")]
		public static readonly Guid MFMediaType_Video;

		[FieldDescription("Protected Media")]
		public static readonly Guid MFMediaType_Protected;

		[FieldDescription("SAMI captions")]
		public static readonly Guid MFMediaType_SAMI;

		[FieldDescription("Script stream")]
		public static readonly Guid MFMediaType_Script;

		[FieldDescription("Still image stream")]
		public static readonly Guid MFMediaType_Image;

		[FieldDescription("HTML stream")]
		public static readonly Guid MFMediaType_HTML;

		[FieldDescription("Binary stream")]
		public static readonly Guid MFMediaType_Binary;

		[FieldDescription("File transfer")]
		public static readonly Guid MFMediaType_FileTransfer;
	}
}
