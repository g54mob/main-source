using System;
using NAudio.Utils;

namespace NAudio.MediaFoundation
{
	public static class MediaFoundationAttributes
	{
		public static readonly Guid MF_TRANSFORM_ASYNC;

		public static readonly Guid MF_TRANSFORM_ASYNC_UNLOCK;

		[FieldDescription("Transform Flags")]
		public static readonly Guid MF_TRANSFORM_FLAGS_Attribute;

		[FieldDescription("Transform Category")]
		public static readonly Guid MF_TRANSFORM_CATEGORY_Attribute;

		[FieldDescription("Class identifier")]
		public static readonly Guid MFT_TRANSFORM_CLSID_Attribute;

		[FieldDescription("Input Types")]
		public static readonly Guid MFT_INPUT_TYPES_Attributes;

		[FieldDescription("Output Types")]
		public static readonly Guid MFT_OUTPUT_TYPES_Attributes;

		public static readonly Guid MFT_ENUM_HARDWARE_URL_Attribute;

		[FieldDescription("Name")]
		public static readonly Guid MFT_FRIENDLY_NAME_Attribute;

		public static readonly Guid MFT_CONNECTED_STREAM_ATTRIBUTE;

		public static readonly Guid MFT_CONNECTED_TO_HW_STREAM;

		[FieldDescription("Preferred Output Format")]
		public static readonly Guid MFT_PREFERRED_OUTPUTTYPE_Attribute;

		public static readonly Guid MFT_PROCESS_LOCAL_Attribute;

		public static readonly Guid MFT_PREFERRED_ENCODER_PROFILE;

		public static readonly Guid MFT_HW_TIMESTAMP_WITH_QPC_Attribute;

		public static readonly Guid MFT_FIELDOFUSE_UNLOCK_Attribute;

		public static readonly Guid MFT_CODEC_MERIT_Attribute;

		public static readonly Guid MFT_ENUM_TRANSCODE_ONLY_ATTRIBUTE;

		[FieldDescription("PMP Host Context")]
		public static readonly Guid MF_PD_PMPHOST_CONTEXT;

		[FieldDescription("App Context")]
		public static readonly Guid MF_PD_APP_CONTEXT;

		[FieldDescription("Duration")]
		public static readonly Guid MF_PD_DURATION;

		[FieldDescription("Total File Size")]
		public static readonly Guid MF_PD_TOTAL_FILE_SIZE;

		[FieldDescription("Audio encoding bitrate")]
		public static readonly Guid MF_PD_AUDIO_ENCODING_BITRATE;

		[FieldDescription("Video Encoding Bitrate")]
		public static readonly Guid MF_PD_VIDEO_ENCODING_BITRATE;

		[FieldDescription("MIME Type")]
		public static readonly Guid MF_PD_MIME_TYPE;

		[FieldDescription("Last Modified Time")]
		public static readonly Guid MF_PD_LAST_MODIFIED_TIME;

		[FieldDescription("Element ID")]
		public static readonly Guid MF_PD_PLAYBACK_ELEMENT_ID;

		[FieldDescription("Preferred Language")]
		public static readonly Guid MF_PD_PREFERRED_LANGUAGE;

		[FieldDescription("Playback boundary time")]
		public static readonly Guid MF_PD_PLAYBACK_BOUNDARY_TIME;

		[FieldDescription("Audio is variable bitrate")]
		public static readonly Guid MF_PD_AUDIO_ISVARIABLEBITRATE;

		[FieldDescription("Major Media Type")]
		public static readonly Guid MF_MT_MAJOR_TYPE;

		[FieldDescription("Media Subtype")]
		public static readonly Guid MF_MT_SUBTYPE;

		[FieldDescription("Audio block alignment")]
		public static readonly Guid MF_MT_AUDIO_BLOCK_ALIGNMENT;

		[FieldDescription("Audio average bytes per second")]
		public static readonly Guid MF_MT_AUDIO_AVG_BYTES_PER_SECOND;

		[FieldDescription("Audio number of channels")]
		public static readonly Guid MF_MT_AUDIO_NUM_CHANNELS;

		[FieldDescription("Audio samples per second")]
		public static readonly Guid MF_MT_AUDIO_SAMPLES_PER_SECOND;

		[FieldDescription("Audio bits per sample")]
		public static readonly Guid MF_MT_AUDIO_BITS_PER_SAMPLE;

		[FieldDescription("Enable Hardware Transforms")]
		public static readonly Guid MF_READWRITE_ENABLE_HARDWARE_TRANSFORMS;

		[FieldDescription("User data")]
		public static readonly Guid MF_MT_USER_DATA;

		[FieldDescription("All samples independent")]
		public static readonly Guid MF_MT_ALL_SAMPLES_INDEPENDENT;

		[FieldDescription("Fixed size samples")]
		public static readonly Guid MF_MT_FIXED_SIZE_SAMPLES;

		[FieldDescription("DirectShow Format Guid")]
		public static readonly Guid MF_MT_AM_FORMAT_TYPE;

		[FieldDescription("Preferred legacy format structure")]
		public static readonly Guid MF_MT_AUDIO_PREFER_WAVEFORMATEX;

		[FieldDescription("Is Compressed")]
		public static readonly Guid MF_MT_COMPRESSED;

		[FieldDescription("Average bitrate")]
		public static readonly Guid MF_MT_AVG_BITRATE;

		[FieldDescription("AAC payload type")]
		public static readonly Guid MF_MT_AAC_PAYLOAD_TYPE;

		[FieldDescription("AAC Audio Profile Level Indication")]
		public static readonly Guid MF_MT_AAC_AUDIO_PROFILE_LEVEL_INDICATION;
	}
}
