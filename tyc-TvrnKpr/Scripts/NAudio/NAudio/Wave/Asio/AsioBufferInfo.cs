using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave.Asio
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 24)]
	internal struct AsioBufferInfo
	{
		public bool isInput;

		public int channelNum;

		public IntPtr pBuffer0;

		public IntPtr pBuffer1;

		public IntPtr Buffer(int bufferIndex)
		{
			return (IntPtr)0;
		}
	}
}
