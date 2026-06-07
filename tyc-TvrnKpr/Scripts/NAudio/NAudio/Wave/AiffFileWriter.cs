using System.IO;

namespace NAudio.Wave
{
	public class AiffFileWriter : Stream
	{
		private Stream outStream;

		private BinaryWriter writer;

		private long dataSizePos;

		private long commSampleCountPos;

		private int dataChunkSize;

		private WaveFormat format;

		private string filename;

		private byte[] value24;

		public string Filename => null;

		public override long Length => 0L;

		public WaveFormat WaveFormat => null;

		public override bool CanRead => false;

		public override bool CanWrite => false;

		public override bool CanSeek => false;

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

		public static void CreateAiffFile(string filename, WaveStream sourceProvider)
		{
		}

		public AiffFileWriter(Stream outStream, WaveFormat format)
		{
		}

		public AiffFileWriter(string filename, WaveFormat format)
		{
		}

		private void WriteSsndChunkHeader()
		{
		}

		private byte[] SwapEndian(short n)
		{
			return null;
		}

		private byte[] SwapEndian(int n)
		{
			return null;
		}

		private void CreateCommChunk()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] data, int offset, int count)
		{
		}

		public void WriteSample(float sample)
		{
		}

		public void WriteSamples(float[] samples, int offset, int count)
		{
		}

		public void WriteSamples(short[] samples, int offset, int count)
		{
		}

		public override void Flush()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		protected virtual void UpdateHeader(BinaryWriter writer)
		{
		}

		private void UpdateCommChunk(BinaryWriter writer)
		{
		}

		private void UpdateSsndChunk(BinaryWriter writer)
		{
		}

		~AiffFileWriter()
		{
		}
	}
}
