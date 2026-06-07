using System.Runtime.InteropServices;

namespace NAudio.Wave.Asio
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 84)]
	internal struct AsioTimeCode
	{
		public double speed;

		public Asio64Bit timeCodeSamples;

		public AsioTimeCodeFlags flags;

		public string future;
	}
}
