using System;

namespace Coherence.Brook
{
	public class OutBitStream : IOutBitStream
	{
		private const int AccumulatorSize = 32;

		private const uint MaxFilter = 4294967295u;

		private readonly IOctetWriter octetWriter;

		private readonly uint octetWriterInitialPosition;

		private int remainingBits;

		[ThreadStatic]
		private static byte[] octetArrayCache;

		public uint Accumulator { get; private set; }

		public bool IsFull { get; private set; }

		public uint Position { get; private set; }

		public uint OverflowBitCount { get; private set; }

		private static byte[] OctetArrayCache => null;

		public uint RemainingBitCount => 0u;

		public OutBitStream(IOctetWriter octetWriter)
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

		public void Flush()
		{
		}

		private uint MaskFromCount(int count)
		{
			return 0u;
		}

		public void Seek(uint newPosition)
		{
		}

		private void WriteRest(uint v, int count, int bitsToKeepFromLeft)
		{
		}

		private void WriteOctets()
		{
		}

		private void WriteLast()
		{
		}

		public void WriteSignedBits(int v, int count)
		{
		}

		public void WriteBits(uint v, int count)
		{
		}

		public void WriteRawBits(uint v, int count)
		{
		}

		private static void ConvertToByteArray(uint value, byte[] bytes)
		{
		}
	}
}
