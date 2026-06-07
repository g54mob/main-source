using System.Runtime.InteropServices;

namespace NAudio.Wave.Asio
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 48)]
	internal struct AsioTimeInfo
	{
		public double speed;

		public Asio64Bit systemTime;

		public Asio64Bit samplePosition;

		public double sampleRate;

		public AsioTimeInfoFlags flags;

		public string reserved;
	}
}
