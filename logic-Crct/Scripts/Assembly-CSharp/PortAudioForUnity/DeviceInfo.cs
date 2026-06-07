using PortAudioSharp;

namespace PortAudioForUnity
{
	public class DeviceInfo
	{
		public HostApi HostApi { get; private set; }

		public int HostApiDeviceIndex { get; private set; }

		public int GlobalDeviceIndex { get; private set; }

		public string Name { get; private set; }

		public int MaxInputChannels { get; private set; }

		public int MaxOutputChannels { get; private set; }

		public double DefaultLowInputLatency { get; private set; }

		public double DefaultLowOutputLatency { get; private set; }

		public double DefaultHighInputLatency { get; private set; }

		public double DefaultHighOutputLatency { get; private set; }

		public double DefaultSampleRate { get; private set; }

		public override string ToString()
		{
			return null;
		}

		internal DeviceInfo(PortAudio.PaHostApiInfo paHostApiInfo, PortAudio.PaDeviceInfo paDeviceInfo, int hostApiDeviceIndex, int globalDeviceIndex)
		{
		}
	}
}
