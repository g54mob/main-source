using System.Runtime.InteropServices;

namespace Crosstales.NAudio.Wave.WaveFormats
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal class WmaWaveFormat : WaveFormat
	{
		private int dwReserved1;

		private int dwReserved2;

		private short wEncodeOptions;

		private short wReserved3;

		public WmaWaveFormat(int sampleRate, int bitsPerSample, int channels)
			: base(sampleRate, bitsPerSample, channels)
		{
			waveFormatTag = WaveFormatEncoding.WindowsMediaAudio;
		}
	}
}
