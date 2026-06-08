using System;
using System.Buffers;

namespace ProtoBuf
{
	internal static class BufferPool
	{
		private static readonly ArrayPool<byte> _pool = ArrayPool<byte>.Shared;

		internal const int BUFFER_LENGTH = 1024;

		private const int MaxByteArraySize = 2147483591;

		internal static byte[] GetBuffer()
		{
			return GetBuffer(1024);
		}

		internal static byte[] GetBuffer(int minSize)
		{
			byte[] cachedBuffer = GetCachedBuffer(minSize);
			return cachedBuffer ?? new byte[minSize];
		}

		internal static byte[] GetCachedBuffer(int minSize)
		{
			return _pool.Rent(minSize);
		}

		internal static void ResizeAndFlushLeft(ref byte[] buffer, int toFitAtLeastBytes, int copyFromIndex, int copyBytes)
		{
			int num = buffer.Length * 2;
			if (num < 0)
			{
				num = 2147483591;
			}
			if (num < toFitAtLeastBytes)
			{
				num = toFitAtLeastBytes;
			}
			if (copyBytes == 0)
			{
				ReleaseBufferToPool(ref buffer);
			}
			byte[] array = GetCachedBuffer(num) ?? new byte[num];
			if (copyBytes > 0)
			{
				Buffer.BlockCopy(buffer, copyFromIndex, array, 0, copyBytes);
				ReleaseBufferToPool(ref buffer);
			}
			buffer = array;
		}

		internal static void ReleaseBufferToPool(ref byte[] buffer)
		{
			byte[] array = buffer;
			buffer = null;
			if (array != null)
			{
				_pool.Return(array);
			}
		}
	}
}
