using System;

namespace UTJ.FrameCapturer
{
	[Serializable]
	public class MovieEncoderConfigs
	{
		public MovieEncoder.Type format;

		public fcAPI.fcPngConfig pngEncoderSettings;

		public fcAPI.fcExrConfig exrEncoderSettings;

		public fcAPI.fcGifConfig gifEncoderSettings;

		public fcAPI.fcWebMConfig webmEncoderSettings;

		public fcAPI.fcMP4Config mp4EncoderSettings;

		public bool supportVideo => false;

		public bool supportAudio => false;

		public bool captureVideo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool captureAudio
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MovieEncoderConfigs(MovieEncoder.Type t)
		{
		}

		public void Setup(int w, int h, int ch = 4, int targetFrameRate = 60)
		{
		}
	}
}
