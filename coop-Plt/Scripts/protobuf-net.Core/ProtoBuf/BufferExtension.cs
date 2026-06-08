using System;
using System.IO;

namespace ProtoBuf
{
	public sealed class BufferExtension : IExtension, IExtensionResettable
	{
		private ArraySegment<byte> _buffer;

		void IExtensionResettable.Reset()
		{
			_buffer = default(ArraySegment<byte>);
		}

		int IExtension.GetLength()
		{
			return _buffer.Count;
		}

		Stream IExtension.BeginAppend()
		{
			return new MemoryStream();
		}

		void IExtension.EndAppend(Stream stream, bool commit)
		{
			using (stream)
			{
				if (!commit || !(stream is MemoryStream memoryStream) || !memoryStream.TryGetBuffer(out var buffer) || buffer.Count == 0)
				{
					return;
				}
				if (_buffer.Count == 0)
				{
					_buffer = buffer;
					return;
				}
				int num = _buffer.Offset + _buffer.Count;
				int num2 = _buffer.Array.Length - num;
				if (num2 >= buffer.Count)
				{
					Buffer.BlockCopy(buffer.Array, buffer.Offset, _buffer.Array, num, buffer.Count);
					_buffer = new ArraySegment<byte>(_buffer.Array, _buffer.Offset, num + buffer.Count);
					return;
				}
				byte[] array = new byte[_buffer.Count + buffer.Count];
				Buffer.BlockCopy(_buffer.Array, _buffer.Offset, array, 0, _buffer.Count);
				Buffer.BlockCopy(buffer.Array, buffer.Offset, array, _buffer.Count, buffer.Count);
				_buffer = new ArraySegment<byte>(array, 0, _buffer.Count + buffer.Count);
			}
		}

		Stream IExtension.BeginQuery()
		{
			if (_buffer.Count != 0)
			{
				return new MemoryStream(_buffer.Array, _buffer.Offset, _buffer.Count, writable: false, publiclyVisible: true);
			}
			return Stream.Null;
		}

		void IExtension.EndQuery(Stream stream)
		{
			using (stream)
			{
			}
		}
	}
}
