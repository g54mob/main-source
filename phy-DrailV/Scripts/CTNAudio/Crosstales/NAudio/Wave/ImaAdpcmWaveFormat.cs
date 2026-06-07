using System.Runtime.InteropServices;

namespace Crosstales.NAudio.Wave
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public class ImaAdpcmWaveFormat : WaveFormat
	{
		private ImaAdpcmWaveFormat()
		{
		}

		public ImaAdpcmWaveFormat(int sampleRate, int channels, int bitsPerSample)
		{
			waveFormatTag = WaveFormatEncoding.DviAdpcm;
			base.sampleRate = sampleRate;
			base.channels = (short)channels;
			base.bitsPerSample = (short)bitsPerSample;
			extraSize = 2;
			blockAlign = 0;
			averageBytesPerSecond = 0;
		}
	}
}
