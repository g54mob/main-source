using System.IO;

namespace NAudio.Wave
{
	public class RawSourceWaveStream : WaveStream
	{
		private readonly Stream sourceStream;

		private readonly WaveFormat waveFormat;

		public override WaveFormat WaveFormat => null;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public RawSourceWaveStream(Stream sourceStream, WaveFormat waveFormat)
		{
		}

		public RawSourceWaveStream(byte[] byteStream, int offset, int count, WaveFormat waveFormat)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
