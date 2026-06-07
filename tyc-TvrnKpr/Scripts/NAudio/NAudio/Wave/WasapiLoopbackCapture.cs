using NAudio.CoreAudioApi;

namespace NAudio.Wave
{
	public class WasapiLoopbackCapture : WasapiCapture
	{
		public override WaveFormat WaveFormat
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public WasapiLoopbackCapture()
		{
		}

		public WasapiLoopbackCapture(MMDevice captureDevice)
		{
		}

		public static MMDevice GetDefaultLoopbackCaptureDevice()
		{
			return null;
		}

		protected override AudioClientStreamFlags GetAudioClientStreamFlags()
		{
			return default(AudioClientStreamFlags);
		}
	}
}
