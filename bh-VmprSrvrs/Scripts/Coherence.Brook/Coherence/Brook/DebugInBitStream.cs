using System;

namespace Coherence.Brook
{
	public class DebugInBitStream : IInBitStream
	{
		private readonly IInBitStream bitStream;

		public int Position => 0;

		public bool IsEof => false;

		public DebugInBitStream(IInBitStream bitStream)
		{
		}

		private void CheckType(DebugSerializeType expectedType, int expectedBitCount)
		{
		}

		public void ReadBytesUnaligned(Span<byte> buffer, int bitCount)
		{
		}

		public ushort ReadUint16()
		{
			return 0;
		}

		public int ReadSignedBits(int count)
		{
			return 0;
		}

		public int RemainingBits()
		{
			return 0;
		}

		public short ReadInt16()
		{
			return 0;
		}

		public uint ReadUint32()
		{
			return 0u;
		}

		public ulong ReadUint64()
		{
			return 0uL;
		}

		public byte ReadUint8()
		{
			return 0;
		}

		public uint ReadBits(int count)
		{
			return 0u;
		}

		public uint ReadRawBits(int count)
		{
			return 0u;
		}
	}
}
