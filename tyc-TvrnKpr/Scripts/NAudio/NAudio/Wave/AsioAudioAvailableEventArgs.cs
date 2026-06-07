using System;
using NAudio.Wave.Asio;

namespace NAudio.Wave
{
	public class AsioAudioAvailableEventArgs : EventArgs
	{
		public IntPtr[] InputBuffers { get; private set; }

		public IntPtr[] OutputBuffers { get; private set; }

		public bool WrittenToOutputBuffers { get; set; }

		public int SamplesPerBuffer { get; private set; }

		public AsioSampleType AsioSampleType { get; private set; }

		public AsioAudioAvailableEventArgs(IntPtr[] inputBuffers, IntPtr[] outputBuffers, int samplesPerBuffer, AsioSampleType asioSampleType)
		{
		}

		public int GetAsInterleavedSamples(float[] samples)
		{
			return 0;
		}

		[Obsolete("Better performance if you use the overload that takes an array, and reuse the same one")]
		public float[] GetAsInterleavedSamples()
		{
			return null;
		}
	}
}
