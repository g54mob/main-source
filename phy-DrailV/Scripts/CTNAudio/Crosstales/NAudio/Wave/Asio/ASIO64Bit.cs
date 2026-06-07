using System.Runtime.InteropServices;

namespace Crosstales.NAudio.Wave.Asio
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct ASIO64Bit
	{
		public uint hi;

		public uint lo;
	}
}
