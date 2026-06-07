using System;
using System.Collections.Generic;
using PortAudioSharp;

namespace PortAudioForUnity
{
	internal abstract class AbstractInputOutputDeviceControl : IDisposable
	{
		private readonly Audio portAudioSharpAudio;

		private static Dictionary<int, AbstractInputOutputDeviceControl> _instances;

		private static int _nextInstanceId;

		private int _instanceId;

		private DeviceInfo InputDeviceInfo { get; set; }

		public int GlobalInputDeviceIndex => 0;

		public int InputChannelCount { get; private set; }

		private DeviceInfo OutputDeviceInfo { get; set; }

		public int GlobalOutputDeviceIndex => 0;

		public int OutputChannelCount { get; private set; }

		public int SampleRate { get; private set; }

		public uint SamplesPerBuffer { get; private set; }

		public int SampleBufferLengthInSeconds { get; private set; }

		protected bool IsAudioStreamStarted { get; private set; }

		protected bool IsDisposed { get; private set; }

		protected AbstractInputOutputDeviceControl(DeviceInfo inputDeviceInfo, int inputChannelCount, DeviceInfo outputDeviceInfo, int outputChannelCount, int sampleRate, uint samplesPerBuffer, int sampleBufferLengthInSeconds)
		{
		}

		public virtual void Dispose()
		{
		}

		protected void StartAudioStream()
		{
		}

		protected void StopAudioStream()
		{
		}

		protected abstract PortAudio.PaStreamCallbackResult AudioStreamCallback(IntPtr input, IntPtr output, uint samplesPerBuffer, ref PortAudio.PaStreamCallbackTimeInfo timeInfo, PortAudio.PaStreamCallbackFlags statusFlags, IntPtr localUserData);

		[MonoPInvokeCallback(typeof(PortAudio.PaStreamCallbackDelegate))]
		public static PortAudio.PaStreamCallbackResult AudioStreamCallbackStatic(IntPtr input, IntPtr output, uint samplesPerBuffer, ref PortAudio.PaStreamCallbackTimeInfo timeInfo, PortAudio.PaStreamCallbackFlags statusFlags, IntPtr userData)
		{
			return default(PortAudio.PaStreamCallbackResult);
		}
	}
}
