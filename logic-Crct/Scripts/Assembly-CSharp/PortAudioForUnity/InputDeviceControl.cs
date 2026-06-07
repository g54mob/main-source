using System;
using PortAudioSharp;

namespace PortAudioForUnity
{
	internal class InputDeviceControl : AbstractInputOutputDeviceControl
	{
		private readonly bool playRecordedSamples;

		private readonly float[] allChannelsRecordedSamples;

		private int writeAllChannelsSampleBufferIndex;

		public float OutputAmplificationFactor { get; set; }

		public bool Loop { get; private set; }

		public bool IsRecording => false;

		internal InputDeviceControl(DeviceInfo inputDeviceInfo, DeviceInfo outputDeviceInfo, float outputAmplificationFactor, int sampleRate, uint samplesPerBuffer, int sampleBufferLengthInSeconds, bool loop)
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

		private void ResetRecordedSamples()
		{
		}

		public void Stop()
		{
		}

		public void GetRecordedSamples(int channelIndex, float[] bufferToBeFilled)
		{
		}

		public void GetAllRecordedSamples(float[] bufferToBeFilled)
		{
		}

		public int GetSingleChannelRecordingPosition()
		{
			return 0;
		}
	}
}
