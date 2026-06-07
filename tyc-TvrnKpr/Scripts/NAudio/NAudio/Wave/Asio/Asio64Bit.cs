using System.Runtime.InteropServices;

namespace NAudio.Wave.Asio
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 8)]
	public struct Asio64Bit
	{
		public uint hi;

		public uint lo;
	}
}
