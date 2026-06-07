using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0)]
	public class Mp3WaveFormat : WaveFormat
	{
		public Mp3WaveFormatId id;

		public Mp3WaveFormatFlags flags;

		public ushort blockSize;

		public ushort framesPerBlock;

		public ushort codecDelay;

		private const short Mp3WaveFormatExtraBytes = 12;

		public Mp3WaveFormat(int sampleRate, int channels, int blockSize, int bitRate)
		{
		}
	}
}
