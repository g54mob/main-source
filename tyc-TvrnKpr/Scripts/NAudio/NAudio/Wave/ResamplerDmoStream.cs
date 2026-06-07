using NAudio.Dmo;

namespace NAudio.Wave
{
	public class ResamplerDmoStream : WaveStream
	{
		private readonly IWaveProvider inputProvider;

		private readonly WaveStream inputStream;

		private readonly WaveFormat outputFormat;

		private DmoOutputDataBuffer outputBuffer;

		private DmoResampler dmoResampler;

		private MediaBuffer inputMediaBuffer;

		private long position;

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

		public ResamplerDmoStream(IWaveProvider inputProvider, WaveFormat outputFormat)
		{
		}

		private long InputToOutputPosition(long inputPosition)
		{
			return 0L;
		}

		private long OutputToInputPosition(long outputPosition)
		{
			return 0L;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
