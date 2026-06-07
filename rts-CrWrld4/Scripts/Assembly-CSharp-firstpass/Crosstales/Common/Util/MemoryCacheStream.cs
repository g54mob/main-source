using System.IO;

namespace Crosstales.Common.Util
{
	public class MemoryCacheStream : Stream
	{
		private byte[] cache;

		private long writePosition;

		private long readPosition;

		private long length;

		private int size;

		private readonly int maxSize;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

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

		public override long Length => 0L;

		public MemoryCacheStream(int cacheSize = 65536, int maxCacheSize = 67108864)
		{
		}

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		private int read(byte[] buff, int offset, int count)
		{
			return 0;
		}

		private void write(byte[] buff, int offset, int count)
		{
		}

		private void createCache()
		{
		}
	}
}
