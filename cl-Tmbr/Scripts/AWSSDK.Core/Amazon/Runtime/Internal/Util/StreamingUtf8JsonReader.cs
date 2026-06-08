using System;
using System.Buffers;
using System.IO;
using System.Text.Json;

namespace Amazon.Runtime.Internal.Util
{
	public ref struct StreamingUtf8JsonReader
	{
		private Utf8JsonReader _reader;

		private static JsonReaderOptions _jsonOptions = new JsonReaderOptions
		{
			AllowTrailingCommas = true
		};

		private Stream _stream;

		private byte[] _buffer;

		public Utf8JsonReader Reader => _reader;

		public StreamingUtf8JsonReader(Stream stream)
			: this(stream, AWSConfigs.StreamingUtf8JsonReaderBufferSize ?? 4096)
		{
		}

		public StreamingUtf8JsonReader(Stream stream, int bufferSize)
		{
			if (stream == null)
			{
				throw new ArgumentException("Stream must not be null. Please initialize a stream and pass it into the constructor.");
			}
			_stream = stream;
			_buffer = ArrayPool<byte>.Shared.Rent(bufferSize);
			int length = JsonConstants.Utf8Bom.Length;
			int num = FillBuffer(stream, ref _buffer, 0, _buffer.Length);
			int num2 = 0;
			if (_buffer.AsSpan().StartsWith(JsonConstants.Utf8Bom))
			{
				num2 += length;
				num -= length;
			}
			_reader = new Utf8JsonReader(_buffer.AsSpan(num2, num), num == 0, new JsonReaderState(_jsonOptions));
		}

		public bool Read()
		{
			bool flag = _reader.Read();
			while (!flag)
			{
				if (_reader.IsFinalBlock)
				{
					ArrayPool<byte>.Shared.Return(_buffer);
					break;
				}
				GetMoreBytesFromStream(_stream, ref _buffer, ref _reader);
				flag = _reader.Read();
			}
			return flag;
		}

		private static void GetMoreBytesFromStream(Stream stream, ref byte[] buffer, ref Utf8JsonReader reader)
		{
			int num = 0;
			Span<byte> span = buffer.AsSpan();
			ReadOnlySpan<byte> readOnlySpan = span.Slice((int)reader.BytesConsumed);
			if (reader.BytesConsumed < buffer.Length)
			{
				if (reader.BytesConsumed == 0L)
				{
					byte[] array = ArrayPool<byte>.Shared.Rent(Math.Min(int.MaxValue, buffer.Length * 2));
					Logger.GetLogger(typeof(StreamingUtf8JsonReader)).DebugFormat("Resizing buffer from {0} to {1}", buffer.Length, array.Length);
					span = buffer.AsSpan();
					span.CopyTo(array);
					ArrayPool<byte>.Shared.Return(buffer);
					buffer = array;
					num = FillBuffer(stream, ref buffer, readOnlySpan.Length, buffer.Length - readOnlySpan.Length);
					Span<byte> span2 = buffer.AsSpan(0, num + readOnlySpan.Length);
					reader = new Utf8JsonReader(span2, num == 0, reader.CurrentState);
					return;
				}
				readOnlySpan.CopyTo(buffer);
				num = FillBuffer(stream, ref buffer, readOnlySpan.Length, buffer.Length - readOnlySpan.Length);
			}
			else
			{
				num = FillBuffer(stream, ref buffer, 0, buffer.Length);
			}
			if (num == 0)
			{
				reader = new Utf8JsonReader(buffer.AsSpan(0, num), isFinalBlock: true, reader.CurrentState);
			}
			else
			{
				reader = new Utf8JsonReader(buffer.AsSpan(0, num + readOnlySpan.Length), num + readOnlySpan.Length != buffer.Length || num == 0, reader.CurrentState);
			}
		}

		private static int FillBuffer(Stream stream, ref byte[] buffer, int offset, int bytesToRead)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream must be populated.");
			}
			int num = 0;
			while (bytesToRead > 0)
			{
				int num2 = stream.Read(buffer, offset, bytesToRead);
				if (num2 == 0)
				{
					break;
				}
				offset += num2;
				bytesToRead -= num2;
				num += num2;
			}
			return num;
		}
	}
}
