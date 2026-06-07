using NAudio.Wave.SampleProviders;

namespace NAudio.Wave
{
	public class AudioFileReader : WaveStream, ISampleProvider
	{
		private WaveStream readerStream;

		private readonly SampleChannel sampleChannel;

		private readonly int destBytesPerSample;

		private readonly int sourceBytesPerSample;

		private readonly long length;

		private readonly object lockObject;

		public string FileName { get; }

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

		public AudioFileReader(string fileName)
		{
		}

		private void CreateReaderStream(string fileName)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}

		private long SourceToDest(long sourceBytes)
		{
			return 0L;
		}

		private long DestToSource(long destBytes)
		{
			return 0L;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
