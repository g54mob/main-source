using System;
using System.IO;

namespace NAudio.Wave
{
	public abstract class WaveStream : Stream, IWaveProvider
	{
		public abstract WaveFormat WaveFormat { get; }

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public virtual int BlockAlign => 0;

		public virtual TimeSpan CurrentTime
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public virtual TimeSpan TotalTime => default(TimeSpan);

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long length)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public void Skip(int seconds)
		{
		}

		public virtual bool HasData(int count)
		{
			return false;
		}
	}
}
