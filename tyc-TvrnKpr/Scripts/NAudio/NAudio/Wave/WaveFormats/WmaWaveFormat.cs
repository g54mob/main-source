using System.Runtime.InteropServices;

namespace NAudio.Wave.WaveFormats
{
	[StructLayout((LayoutKind)0)]
	internal class WmaWaveFormat : WaveFormat
	{
		private short wValidBitsPerSample;

		private int dwChannelMask;

		private int dwReserved1;

		private int dwReserved2;

		private short wEncodeOptions;

		private short wReserved3;

		public WmaWaveFormat(int sampleRate, int bitsPerSample, int channels)
		{
		}
	}
}
