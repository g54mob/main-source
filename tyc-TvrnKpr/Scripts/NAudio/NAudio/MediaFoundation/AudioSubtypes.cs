using System;
using NAudio.Utils;

namespace NAudio.MediaFoundation
{
	public static class AudioSubtypes
	{
		[FieldDescription("AAC")]
		public static readonly Guid MFAudioFormat_AAC;

		[FieldDescription("ADTS")]
		public static readonly Guid MFAudioFormat_ADTS;

		[FieldDescription("Dolby AC3 SPDIF")]
		public static readonly Guid MFAudioFormat_Dolby_AC3_SPDIF;

		[FieldDescription("DRM")]
		public static readonly Guid MFAudioFormat_DRM;

		[FieldDescription("DTS")]
		public static readonly Guid MFAudioFormat_DTS;

		[FieldDescription("IEEE floating-point")]
		public static readonly Guid MFAudioFormat_Float;

		[FieldDescription("MP3")]
		public static readonly Guid MFAudioFormat_MP3;

		[FieldDescription("MPEG")]
		public static readonly Guid MFAudioFormat_MPEG;

		[FieldDescription("WMA 9 Voice codec")]
		public static readonly Guid MFAudioFormat_MSP1;

		[FieldDescription("PCM")]
		public static readonly Guid MFAudioFormat_PCM;

		[FieldDescription("WMA SPDIF")]
		public static readonly Guid MFAudioFormat_WMASPDIF;

		[FieldDescription("WMAudio Lossless")]
		public static readonly Guid MFAudioFormat_WMAudio_Lossless;

		[FieldDescription("Windows Media Audio")]
		public static readonly Guid MFAudioFormat_WMAudioV8;

		[FieldDescription("Windows Media Audio Professional")]
		public static readonly Guid MFAudioFormat_WMAudioV9;

		[FieldDescription("Dolby AC3")]
		public static readonly Guid MFAudioFormat_Dolby_AC3;

		[FieldDescription("MPEG-4 and AAC Audio Types")]
		public static readonly Guid MEDIASUBTYPE_RAW_AAC1;

		[FieldDescription("Dolby Audio Types")]
		public static readonly Guid MEDIASUBTYPE_DVM;

		[FieldDescription("Dolby Audio Types")]
		public static readonly Guid MEDIASUBTYPE_DOLBY_DDPLUS;

		[FieldDescription("μ-law")]
		public static readonly Guid KSDATAFORMAT_SUBTYPE_MULAW;

		[FieldDescription("ADPCM")]
		public static readonly Guid KSDATAFORMAT_SUBTYPE_ADPCM;

		[FieldDescription("Dolby Digital Plus for HDMI")]
		public static readonly Guid KSDATAFORMAT_SUBTYPE_IEC61937_DOLBY_DIGITAL_PLUS;

		[FieldDescription("MSAudio1")]
		public static readonly Guid MEDIASUBTYPE_MSAUDIO1;

		[FieldDescription("IMA ADPCM")]
		public static readonly Guid ImaAdpcm;

		[FieldDescription("WMSP2")]
		public static readonly Guid WMMEDIASUBTYPE_WMSP2;
	}
}
