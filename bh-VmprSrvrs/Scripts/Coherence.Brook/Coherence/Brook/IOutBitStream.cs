using System;

namespace Coherence.Brook
{
	public interface IOutBitStream
	{
		bool IsFull { get; }

		uint Position { get; }

		uint RemainingBitCount { get; }

		uint OverflowBitCount { get; }

		void WriteUint16(ushort value);

		void WriteInt16(short value);

		void WriteUint32(uint value);

		void WriteUint64(ulong value);

		void WriteUint8(byte value);

		void WriteBits(uint value, int count);

		void WriteRawBits(uint value, int count);

		void WriteSignedBits(int value, int count);

		void WriteBytesUnaligned(ReadOnlySpan<byte> bytes, int bitCount);

		void WriteFromStream(IInBitStream inBitStream, int bitCount);

		void Seek(uint newPosition);

		void Flush();
	}
}
