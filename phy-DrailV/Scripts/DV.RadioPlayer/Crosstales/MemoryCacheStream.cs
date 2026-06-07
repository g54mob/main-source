using System;
using System.IO;
using UnityEngine;

namespace Crosstales
{
	public class MemoryCacheStream : Stream
	{
		private byte[] cache;

		private long writePosition;

		private long readPosition;

		private long length;

		private int size;

		private readonly int maxSize;

		public override bool CanRead => true;

		public override bool CanSeek => true;

		public override bool CanWrite => true;

		public override long Position
		{
			get
			{
				return readPosition;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", "Non-negative number required.");
				}
				readPosition = value;
			}
		}

		public override long Length => length;

		public MemoryCacheStream(int cacheSize = 65536, int maxCacheSize = 65536)
		{
			length = (writePosition = (readPosition = 0L));
			size = cacheSize;
			maxSize = maxCacheSize;
			createCache();
		}

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			switch (origin)
			{
			case SeekOrigin.Begin:
				Position = (int)offset;
				break;
			case SeekOrigin.Current:
			{
				long num2 = Position + offset;
				if (num2 < 0)
				{
					throw new IOException("An attempt was made to move the position before the beginning of the stream.");
				}
				Position = num2;
				break;
			}
			case SeekOrigin.End:
			{
				long num = length + offset;
				if (num < 0)
				{
					throw new IOException("An attempt was made to move the position before the beginning of the stream.");
				}
				Position = num;
				break;
			}
			default:
				throw new ArgumentException("Invalid seek origin.");
			}
			return Position;
		}

		public override void SetLength(long value)
		{
			int num = (int)value;
			if (size != num)
			{
				size = num;
				long num2 = (Position = 0L);
				length = num2;
				createCache();
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", "Buffer cannot be null.");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Non-negative number required.");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Non-negative number required.");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
			}
			if (readPosition < length)
			{
				return read(buffer, offset, count);
			}
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", "Buffer cannot be null.");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Non-negative number required.");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Non-negative number required.");
			}
			if (count > size)
			{
				throw new ArgumentOutOfRangeException("count", "Value is larger than the cache size.");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
			}
			if (count != 0)
			{
				write(buffer, offset, count);
			}
		}

		private int read(byte[] buff, int offset, int count)
		{
			int num = (int)(readPosition % size);
			if (num + count > size)
			{
				int num2 = size - num;
				int num3 = count - num2;
				Array.Copy(cache, num, buff, offset, num2);
				Array.Copy(cache, 0, buff, offset + num2, num3);
			}
			else
			{
				Array.Copy(cache, num, buff, offset, count);
			}
			readPosition += count;
			return count;
		}

		private void write(byte[] buff, int offset, int count)
		{
			int num = (int)(writePosition % size);
			if (num + count > size)
			{
				int num2 = size - num;
				int num3 = count - num2;
				Array.Copy(buff, offset, cache, num, num2);
				Array.Copy(buff, offset + num2, cache, 0, num3);
			}
			else
			{
				Array.Copy(buff, offset, cache, num, count);
			}
			writePosition += count;
			length = writePosition;
		}

		private void createCache()
		{
			if (size > maxSize)
			{
				cache = new byte[maxSize];
				Debug.LogWarning("'size' is larger than 'maxSize'! Using 'maxSize' as cache!");
			}
			else
			{
				cache = new byte[size];
			}
		}
	}
}
