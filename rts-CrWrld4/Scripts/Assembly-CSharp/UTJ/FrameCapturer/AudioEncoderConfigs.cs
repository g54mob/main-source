using System;

namespace UTJ.FrameCapturer
{
	[Serializable]
	public class AudioEncoderConfigs
	{
		public AudioEncoder.Type format;

		public fcAPI.fcWaveConfig waveEncoderSettings;

		public fcAPI.fcOggConfig oggEncoderSettings;

		public fcAPI.fcFlacConfig flacEncoderSettings;

		public void Setup()
		{
		}
	}
}
