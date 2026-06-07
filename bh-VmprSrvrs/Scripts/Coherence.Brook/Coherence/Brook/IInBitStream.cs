using System;

namespace Coherence.Brook
{
	public interface IInBitStream
	{
		bool IsEof { get; }

		int Position { get; }

		ushort ReadUint16();

		short ReadInt16();

		uint ReadUint32();

		ulong ReadUint64();

		byte ReadUint8();

		uint ReadBits(int count);

		uint ReadRawBits(int count);

		int ReadSignedBits(int count);

		void ReadBytesUnaligned(Span<byte> buffer, int bitCount);

		int RemainingBits();
	}
}
