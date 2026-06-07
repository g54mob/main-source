using System;

namespace NAudio.Dmo
{
	internal static class MediaTypes
	{
		public static readonly Guid MEDIATYPE_AnalogAudio;

		public static readonly Guid MEDIATYPE_AnalogVideo;

		public static readonly Guid MEDIATYPE_Audio;

		public static readonly Guid MEDIATYPE_AUXLine21Data;

		public static readonly Guid MEDIATYPE_File;

		public static readonly Guid MEDIATYPE_Interleaved;

		public static readonly Guid MEDIATYPE_Midi;

		public static readonly Guid MEDIATYPE_ScriptCommand;

		public static readonly Guid MEDIATYPE_Stream;

		public static readonly Guid MEDIATYPE_Text;

		public static readonly Guid MEDIATYPE_Timecode;

		public static readonly Guid MEDIATYPE_Video;

		public static readonly Guid[] MajorTypes;

		public static readonly string[] MajorTypeNames;

		public static string GetMediaTypeName(Guid majorType)
		{
			return null;
		}
	}
}
