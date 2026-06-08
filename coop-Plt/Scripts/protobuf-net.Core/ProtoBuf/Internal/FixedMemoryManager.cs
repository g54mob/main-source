using System;
using System.Buffers;

namespace ProtoBuf.Internal
{
	internal sealed class FixedMemoryManager : MemoryManager<byte>
	{
		private unsafe byte* _pointer;

		private int _length;

		internal unsafe Memory<byte> Init(byte* pointer, int length)
		{
			_pointer = pointer;
			_length = length;
			return Memory;
		}

		public unsafe override Span<byte> GetSpan()
		{
			return new Span<byte>(_pointer, _length);
		}

		public override MemoryHandle Pin(int elementIndex = 0)
		{
			throw new NotSupportedException();
		}

		public override void Unpin()
		{
			throw new NotSupportedException();
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
