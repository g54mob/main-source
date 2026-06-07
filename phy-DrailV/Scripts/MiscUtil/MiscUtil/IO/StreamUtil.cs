using System;
using System.IO;

namespace MiscUtil.IO
{
	public static class StreamUtil
	{
		private const int DefaultBufferSize = 8192;

		public static byte[] ReadFully(Stream input)
		{
			return ReadFully(input, 8192);
		}

		public static byte[] ReadFully(Stream input, int bufferSize)
		{
			if (bufferSize < 1)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			return ReadFully(input, new byte[bufferSize]);
		}

		public static byte[] ReadFully(Stream input, IBuffer buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return ReadFully(input, buffer.Bytes);
		}

		public static byte[] ReadFully(Stream input, byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (buffer.Length == 0)
			{
				throw new ArgumentException("Buffer has length of 0");
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Copy(input, memoryStream, buffer);
				if (memoryStream.Length == memoryStream.GetBuffer().Length)
				{
					return memoryStream.GetBuffer();
				}
				return memoryStream.ToArray();
			}
		}

		public static void Copy(Stream input, Stream output)
		{
			Copy(input, output, 8192);
		}

		public static void Copy(Stream input, Stream output, int bufferSize)
		{
			if (bufferSize < 1)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			Copy(input, output, new byte[bufferSize]);
		}

		public static void Copy(Stream input, Stream output, IBuffer buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			Copy(input, output, buffer.Bytes);
		}

		public static void Copy(Stream input, Stream output, byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (buffer.Length == 0)
			{
				throw new ArgumentException("Buffer has length of 0");
			}
			int count;
			while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
			{
				output.Write(buffer, 0, count);
			}
		}

		public static byte[] ReadExactly(Stream input, int bytesToRead)
		{
			return ReadExactly(input, new byte[bytesToRead]);
		}

		public static byte[] ReadExactly(Stream input, IBuffer buffer)
		{
			return ReadExactly(input, buffer.Bytes);
		}

		public static byte[] ReadExactly(Stream input, byte[] buffer)
		{
			return ReadExactly(input, buffer, buffer.Length);
		}

		public static byte[] ReadExactly(Stream input, IBuffer buffer, int bytesToRead)
		{
			return ReadExactly(input, buffer.Bytes, bytesToRead);
		}

		public static byte[] ReadExactly(Stream input, byte[] buffer, int bytesToRead)
		{
			return ReadExactly(input, buffer, 0, bytesToRead);
		}

		public static byte[] ReadExactly(Stream input, IBuffer buffer, int startIndex, int bytesToRead)
		{
			return ReadExactly(input, buffer.Bytes, 0, bytesToRead);
		}

		public static byte[] ReadExactly(Stream input, byte[] buffer, int startIndex, int bytesToRead)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (startIndex < 0 || startIndex >= buffer.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (bytesToRead < 1 || startIndex + bytesToRead > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("bytesToRead");
			}
			int num;
			for (int i = 0; i < bytesToRead; i += num)
			{
				num = input.Read(buffer, startIndex + i, bytesToRead - i);
				if (num == 0)
				{
					throw new EndOfStreamException(string.Format("End of stream reached with {0} byte{1} left to read.", bytesToRead - i, (bytesToRead - i == 1) ? "s" : ""));
				}
			}
			return buffer;
		}
	}
}
