using System.Runtime.InteropServices;

namespace NAudio.Wave.Asio
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 52)]
	public struct AsioChannelInfo
	{
		public int channel;

		public bool isInput;

		public bool isActive;

		public int channelGroup;

		public AsioSampleType type;

		public string name;
	}
}
