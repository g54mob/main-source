using System;

namespace NAudio.Dmo
{
	internal class AudioMediaSubtypes
	{
		public static readonly Guid MEDIASUBTYPE_PCM;

		public static readonly Guid MEDIASUBTYPE_PCMAudioObsolete;

		public static readonly Guid MEDIASUBTYPE_MPEG1Packet;

		public static readonly Guid MEDIASUBTYPE_MPEG1Payload;

		public static readonly Guid MEDIASUBTYPE_MPEG2_AUDIO;

		public static readonly Guid MEDIASUBTYPE_DVD_LPCM_AUDIO;

		public static readonly Guid MEDIASUBTYPE_DRM_Audio;

		public static readonly Guid MEDIASUBTYPE_IEEE_FLOAT;

		public static readonly Guid MEDIASUBTYPE_DOLBY_AC3;

		public static readonly Guid MEDIASUBTYPE_DOLBY_AC3_SPDIF;

		public static readonly Guid MEDIASUBTYPE_RAW_SPORT;

		public static readonly Guid MEDIASUBTYPE_SPDIF_TAG_241h;

		public static readonly Guid WMMEDIASUBTYPE_MP3;

		public static readonly Guid MEDIASUBTYPE_WAVE;

		public static readonly Guid MEDIASUBTYPE_AU;

		public static readonly Guid MEDIASUBTYPE_AIFF;

		public static readonly Guid[] AudioSubTypes;

		public static readonly string[] AudioSubTypeNames;

		public static string GetAudioSubtypeName(Guid subType)
		{
			return null;
		}
	}
}
