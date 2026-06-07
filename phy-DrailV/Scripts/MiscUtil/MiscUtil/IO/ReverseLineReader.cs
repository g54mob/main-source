using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiscUtil.IO
{
	public sealed class ReverseLineReader : IEnumerable<string>, IEnumerable
	{
		private const int DefaultBufferSize = 4096;

		private readonly Func<Stream> streamSource;

		private readonly Encoding encoding;

		private readonly int bufferSize;

		private Func<long, byte, bool> characterStartDetector;

		public ReverseLineReader(Func<Stream> streamSource)
			: this(streamSource, Encoding.UTF8)
		{
		}

		public ReverseLineReader(string filename)
			: this(filename, Encoding.UTF8)
		{
		}

		public ReverseLineReader(string filename, Encoding encoding)
			: this(() => File.OpenRead(filename), encoding)
		{
		}

		public ReverseLineReader(Func<Stream> streamSource, Encoding encoding)
			: this(streamSource, encoding, 4096)
		{
		}

		internal ReverseLineReader(Func<Stream> streamSource, Encoding encoding, int bufferSize)
		{
			this.streamSource = streamSource;
			this.encoding = encoding;
			this.bufferSize = bufferSize;
			if (encoding.IsSingleByte)
			{
				characterStartDetector = (long pos, byte data) => true;
				return;
			}
			if (encoding is UnicodeEncoding)
			{
				characterStartDetector = (long pos, byte data) => (pos & 1) == 0;
				return;
			}
			if (encoding is UTF8Encoding)
			{
				characterStartDetector = (long pos, byte data) => (data & 0x80) == 0 || (data & 0x40) != 0;
				return;
			}
			throw new ArgumentException("Only single byte, UTF-8 and Unicode encodings are permitted");
		}

		public IEnumerator<string> GetEnumerator()
		{
			Stream stream = streamSource();
			if (!stream.CanSeek)
			{
				stream.Dispose();
				throw new NotSupportedException("Unable to seek within stream");
			}
			if (!stream.CanRead)
			{
				stream.Dispose();
				throw new NotSupportedException("Unable to read within stream");
			}
			return GetEnumeratorImpl(stream);
		}

		private IEnumerator<string> GetEnumeratorImpl(Stream stream)
		{
			using (stream)
			{
				long position = stream.Length;
				if (encoding is UnicodeEncoding && (position & 1) != 0)
				{
					throw new InvalidDataException("UTF-16 encoding provided, but stream has odd length.");
				}
				byte[] buffer = new byte[bufferSize + 2];
				char[] charBuffer = new char[encoding.GetMaxCharCount(buffer.Length)];
				int leftOverData = 0;
				string previousEnd = null;
				bool firstYield = true;
				bool swallowCarriageReturn = false;
				while (position > 0)
				{
					int bytesToRead = Math.Min((int)((position > int.MaxValue) ? bufferSize : position), bufferSize);
					position = (stream.Position = position - bytesToRead);
					StreamUtil.ReadExactly(stream, buffer, bytesToRead);
					if (leftOverData > 0 && bytesToRead != bufferSize)
					{
						Array.Copy(buffer, bufferSize, buffer, bytesToRead, leftOverData);
					}
					bytesToRead += leftOverData;
					int firstCharPosition = 0;
					while (!characterStartDetector(position + firstCharPosition, buffer[firstCharPosition]))
					{
						firstCharPosition++;
						if (firstCharPosition == 3 || firstCharPosition == bytesToRead)
						{
							throw new InvalidDataException("Invalid UTF-8 data");
						}
					}
					leftOverData = firstCharPosition;
					int charsRead = encoding.GetChars(buffer, firstCharPosition, bytesToRead - firstCharPosition, charBuffer, 0);
					int endExclusive = charsRead;
					for (int i = charsRead - 1; i >= 0; i--)
					{
						char lookingAt = charBuffer[i];
						if (swallowCarriageReturn)
						{
							swallowCarriageReturn = false;
							if (lookingAt == '\r')
							{
								endExclusive--;
								continue;
							}
						}
						if (lookingAt == '\n' || lookingAt == '\r')
						{
							if (lookingAt == '\n')
							{
								swallowCarriageReturn = true;
							}
							int start = i + 1;
							string bufferContents = new string(charBuffer, start, endExclusive - start);
							endExclusive = i;
							string stringToYield = ((previousEnd == null) ? bufferContents : (bufferContents + previousEnd));
							if (!firstYield || stringToYield.Length != 0)
							{
								yield return stringToYield;
							}
							firstYield = false;
							previousEnd = null;
						}
					}
					previousEnd = ((endExclusive == 0) ? null : (new string(charBuffer, 0, endExclusive) + previousEnd));
					if (leftOverData != 0)
					{
						Buffer.BlockCopy(buffer, 0, buffer, bufferSize, leftOverData);
					}
				}
				if (leftOverData != 0)
				{
					throw new InvalidDataException("Invalid UTF-8 data at start of stream");
				}
				if (!firstYield || !string.IsNullOrEmpty(previousEnd))
				{
					yield return previousEnd ?? "";
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
