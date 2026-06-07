using System;
using PortAudioSharp;

namespace PortAudioForUnity
{
	internal class OutputDeviceControl : AbstractInputOutputDeviceControl
	{
		private readonly float[] sampleBuffer;

		internal readonly PortAudioUtils.PcmReaderCallback pcmReaderCallback;

		internal OutputDeviceControl(DeviceInfo outputDeviceInfo, int outputChannelCount, int sampleRate, uint samplesPerBuffer, int sampleBufferLengthInSeconds, PortAudioUtils.PcmReaderCallback pcmReaderCallback)
			: base(null, 0, null, 0, 0, 0u, 0)
		{
		}

		public override void Dispose()
		{
		}

		protected override PortAudio.PaStreamCallbackResult AudioStreamCallback(IntPtr input, IntPtr output, uint samplesPerBuffer, ref PortAudio.PaStreamCallbackTimeInfo timeInfo, PortAudio.PaStreamCallbackFlags statusFlags, IntPtr localUserData)
		{
			return default(PortAudio.PaStreamCallbackResult);
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}
	}
}
