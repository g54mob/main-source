using System;

namespace DV.Radio
{
	public static class __EnumMethods
	{
		public static AudioCodec GetCodec(this AudioFormat format)
		{
			switch (format)
			{
			case AudioFormat.Unknown:
				return AudioCodec.None;
			case AudioFormat.MP3:
				return AudioCodec.MP3_NAudio;
			case AudioFormat.OGG:
				return AudioCodec.OGG_NVorbis;
			default:
				throw new NotImplementedException($"Unhandled audio format {format}");
			}
		}
	}
}
