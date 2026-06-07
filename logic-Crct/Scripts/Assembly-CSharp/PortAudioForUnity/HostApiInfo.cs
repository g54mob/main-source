using PortAudioSharp;

namespace PortAudioForUnity
{
	public class HostApiInfo
	{
		public HostApi HostApi { get; private set; }

		public string Name { get; private set; }

		public int DeviceCount { get; private set; }

		public int DefaultInputDeviceGlobalIndex { get; private set; }

		public int DefaultOutputDeviceGlobalIndex { get; private set; }

		internal HostApiInfo(PortAudio.PaHostApiInfo paHostApiInfo)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
