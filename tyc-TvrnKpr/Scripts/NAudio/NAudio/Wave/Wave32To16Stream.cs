namespace NAudio.Wave
{
	public class Wave32To16Stream : WaveStream
	{
		private WaveStream sourceStream;

		private readonly WaveFormat waveFormat;

		private readonly long length;

		private long position;

		private bool clip;

		private float volume;

		private readonly object lockObject;

		private byte[] sourceBuffer;

		public float Volume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override int BlockAlign => 0;

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

		public override WaveFormat WaveFormat => null;

		public bool Clip
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Wave32To16Stream(WaveStream sourceStream)
		{
		}

		public override int Read(byte[] destBuffer, int offset, int numBytes)
		{
			return 0;
		}

		private void Convert32To16(byte[] destBuffer, int offset, byte[] source, int bytesRead)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
