using System;

namespace Coherence.Brook
{
	public class DebugOutBitStream : IOutBitStream
	{
		private readonly IOutBitStream bitStream;

		public uint RemainingBitCount => 0u;

		public uint Position => 0u;

		public bool IsFull => false;

		public uint OverflowBitCount => 0u;

		public DebugOutBitStream(IOutBitStream bitStream)
		{
		}

		public void WriteUint16(ushort v)
		{
		}

		public void WriteInt16(short v)
		{
		}

		public void WriteUint32(uint v)
		{
		}

		public void WriteUint64(ulong v)
		{
		}

		public void WriteUint8(byte v)
		{
		}

		public void WriteBytesUnaligned(ReadOnlySpan<byte> bytes, int bitCount)
		{
		}

		public void WriteFromStream(IInBitStream inBitStream, int bitCount)
		{
		}

		public void Seek(uint newPosition)
		{
		}

		public void WriteSignedBits(int v, int count)
		{
		}

		public void WriteBits(uint v, int count)
		{
		}

		private void WriteType(DebugSerializeType type, int bitCount)
		{
		}

		private void InternalWriteBits(uint v, int count)
		{
		}

		public void WriteRawBits(uint v, int count)
		{
		}

		public void Flush()
		{
		}
	}
}
