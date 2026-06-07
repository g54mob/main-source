using System;

namespace NAudio.Wave
{
	public class WaveOffsetStream : WaveStream
	{
		private WaveStream sourceStream;

		private long audioStartPosition;

		private long sourceOffsetBytes;

		private long sourceLengthBytes;

		private long length;

		private readonly int bytesPerSample;

		private long position;

		private TimeSpan startTime;

		private TimeSpan sourceOffset;

		private TimeSpan sourceLength;

		private readonly object lockObject;

		public TimeSpan StartTime
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public TimeSpan SourceOffset
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public TimeSpan SourceLength
		{
			get
			{
				return default(TimeSpan);
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

		public WaveOffsetStream(WaveStream sourceStream, TimeSpan startTime, TimeSpan sourceOffset, TimeSpan sourceLength)
		{
		}

		public WaveOffsetStream(WaveStream sourceStream)
		{
		}

		public override int Read(byte[] destBuffer, int offset, int numBytes)
		{
			return 0;
		}

		public override bool HasData(int count)
		{
			return false;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
