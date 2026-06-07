using System;
using Coherence.Log;

namespace Coherence.Brook
{
	public class InBitStream : IInBitStream
	{
		private readonly IOctetReader octetReader;

		private int remainingBits;

		private uint data;

		private int position;

		private readonly int bitSize;

		private static readonly Logger Logger;

		public int Position => 0;

		public bool IsEof => false;

		public InBitStream(IOctetReader octetReader, int bitSize)
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

		private uint MaskFromCount(int count)
		{
			return 0u;
		}

		private uint ReadOnce(int bitsToRead)
		{
			return 0u;
		}

		private void Fill()
		{
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
