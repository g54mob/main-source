namespace FFmpegOut
{
	public static class FFmpegPresetExtensions
	{
		public static string GetDisplayName(this FFmpegPreset preset)
		{
			return preset switch
			{
				FFmpegPreset.H264Default => "H.264 Default (MP4)", 
				FFmpegPreset.H264Nvidia => "H.264 NVIDIA (MP4)", 
				FFmpegPreset.H264Lossless420 => "H.264 Lossless 420 (MP4)", 
				FFmpegPreset.H264Lossless444 => "H.264 Lossless 444 (MP4)", 
				FFmpegPreset.HevcDefault => "HEVC Default (MP4)", 
				FFmpegPreset.HevcNvidia => "HEVC NVIDIA (MP4)", 
				FFmpegPreset.ProRes422 => "ProRes 422 (QuickTime)", 
				FFmpegPreset.ProRes4444 => "ProRes 4444 (QuickTime)", 
				FFmpegPreset.VP8Default => "VP8 (WebM)", 
				FFmpegPreset.VP9Default => "VP9 (WebM)", 
				FFmpegPreset.Hap => "HAP (QuickTime)", 
				FFmpegPreset.HapAlpha => "HAP Alpha (QuickTime)", 
				FFmpegPreset.HapQ => "HAP Q (QuickTime)", 
				_ => null, 
			};
		}

		public static string GetSuffix(this FFmpegPreset preset)
		{
			switch (preset)
			{
			case FFmpegPreset.H264Default:
			case FFmpegPreset.H264Nvidia:
			case FFmpegPreset.H264Lossless420:
			case FFmpegPreset.H264Lossless444:
			case FFmpegPreset.HevcDefault:
			case FFmpegPreset.HevcNvidia:
				return ".mp4";
			case FFmpegPreset.ProRes422:
			case FFmpegPreset.ProRes4444:
				return ".mov";
			case FFmpegPreset.VP8Default:
			case FFmpegPreset.VP9Default:
				return ".webm";
			case FFmpegPreset.Hap:
			case FFmpegPreset.HapAlpha:
			case FFmpegPreset.HapQ:
				return ".mov";
			default:
				return null;
			}
		}

		public static string GetOptions(this FFmpegPreset preset)
		{
			return preset switch
			{
				FFmpegPreset.H264Default => "-pix_fmt yuv420p", 
				FFmpegPreset.H264Nvidia => "-c:v h264_nvenc -pix_fmt yuv420p", 
				FFmpegPreset.H264Lossless420 => "-pix_fmt yuv420p -preset ultrafast -crf 0", 
				FFmpegPreset.H264Lossless444 => "-pix_fmt yuv444p -preset ultrafast -crf 0", 
				FFmpegPreset.HevcDefault => "-c:v libx265 -pix_fmt yuv420p", 
				FFmpegPreset.HevcNvidia => "-c:v hevc_nvenc -pix_fmt yuv420p", 
				FFmpegPreset.ProRes422 => "-c:v prores_ks -pix_fmt yuv422p10le", 
				FFmpegPreset.ProRes4444 => "-c:v prores_ks -pix_fmt yuva444p10le", 
				FFmpegPreset.VP8Default => "-c:v libvpx -pix_fmt yuv420p", 
				FFmpegPreset.VP9Default => "-c:v libvpx-vp9", 
				FFmpegPreset.Hap => "-c:v hap", 
				FFmpegPreset.HapAlpha => "-c:v hap -format hap_alpha", 
				FFmpegPreset.HapQ => "-c:v hap -format hap_q", 
				_ => null, 
			};
		}
	}
}
