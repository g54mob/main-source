using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0)]
	public class ImaAdpcmWaveFormat : WaveFormat
	{
		private short samplesPerBlock;

		private ImaAdpcmWaveFormat()
		{
		}

		public ImaAdpcmWaveFormat(int sampleRate, int channels, int bitsPerSample)
		{
		}
	}
}
