using NAudio.Dsp;

namespace NAudio.Wave
{
	public class SimpleCompressorStream : WaveStream
	{
		private WaveStream sourceStream;

		private readonly SimpleCompressor simpleCompressor;

		private byte[] sourceBuffer;

		private readonly int channels;

		private readonly int bytesPerSample;

		private readonly object lockObject;

		public double MakeUpGain
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Threshold
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Ratio
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Attack
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Release
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public bool Enabled { get; set; }

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

		public override int BlockAlign => 0;

		public SimpleCompressorStream(WaveStream sourceStream)
		{
		}

		public override bool HasData(int count)
		{
			return false;
		}

		private void ReadSamples(byte[] buffer, int start, out double left, out double right)
		{
			left = default(double);
			right = default(double);
		}

		private void WriteSamples(byte[] buffer, int start, double left, double right)
		{
		}

		public override int Read(byte[] array, int offset, int count)
		{
			return 0;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
