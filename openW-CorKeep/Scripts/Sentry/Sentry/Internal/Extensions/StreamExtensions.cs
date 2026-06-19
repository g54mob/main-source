using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Internal.Extensions
{
	internal static class StreamExtensions
	{
		private static readonly byte[] NewlineBuffer = new byte[1] { 10 };

		public static async Task<byte[]> ReadLineAsync(this Stream stream, CancellationToken cancellationToken = default(CancellationToken))
		{
			using PooledBuffer<byte> buffer = new PooledBuffer<byte>(128);
			using MemoryStream result = new MemoryStream(128);
			int overreach = 0;
			bool found = false;
			while (!found)
			{
				int num = await stream.ReadAsync(buffer.Array, 0, 128, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (num <= 0)
				{
					break;
				}
				for (int i = 0; i < num; i++)
				{
					if (buffer.Array[i] == 10)
					{
						found = true;
						overreach = num - i - 1;
						num = i;
						break;
					}
				}
				result.Write(buffer.Array, 0, num);
			}
			stream.Position -= overreach;
			return result.ToArray();
		}

		public static async Task SkipNewlinesAsync(this Stream stream, CancellationToken cancellationToken = default(CancellationToken))
		{
			using PooledBuffer<byte> buffer = new PooledBuffer<byte>(1);
			while (await stream.ReadAsync(buffer.Array, 0, 1, cancellationToken).ConfigureAwait(continueOnCapturedContext: false) > 0)
			{
				if (buffer.Array[0] != 10)
				{
					stream.Position--;
					break;
				}
			}
		}

		public static async Task<byte[]> ReadByteChunkAsync(this Stream stream, int expectedLength, CancellationToken cancellationToken = default(CancellationToken))
		{
			using PooledBuffer<byte> buffer = new PooledBuffer<byte>(expectedLength);
			int num = await stream.ReadAsync(buffer.Array, 0, expectedLength, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			byte[] array = new byte[num];
			Array.Copy(buffer.Array, array, num);
			return array;
		}

		public static Task WriteNewlineAsync(this Stream stream, CancellationToken cancellationToken = default(CancellationToken))
		{
			return stream.WriteAsync(NewlineBuffer, 0, 1, cancellationToken);
		}

		public static void WriteNewline(this Stream stream)
		{
			stream.Write(NewlineBuffer, 0, 1);
		}

		public static long? TryGetLength(this Stream stream)
		{
			try
			{
				return stream.Length;
			}
			catch
			{
				return null;
			}
		}

		public static bool IsFileStream(this Stream? stream)
		{
			if (!(stream is FileStream))
			{
				return stream?.GetType().Name == "MockFileStream";
			}
			return true;
		}
	}
}
