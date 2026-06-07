using System;
using System.IO;

namespace Coherence.Brook.Octet
{
	public class InOctetStream : IInOctetStream, IOctetReader
	{
		private readonly MemoryStream stream;

		private readonly BinaryReader reader;

		private readonly bool resettable;

		public uint Length => 0u;

		public uint Position => 0u;

		public int RemainingOctetCount => 0;

		private byte[] Buffer => null;

		public InOctetStream(byte[] data)
		{
		}

		protected InOctetStream(int capacity)
		{
		}

		protected void ResetAndWrite(ReadOnlySpan<byte> data)
		{
		}

		public ReadOnlySpan<byte> GetBuffer()
		{
			return default(ReadOnlySpan<byte>);
		}

		public ushort ReadUint16()
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

		public byte ReadOctet()
		{
			return 0;
		}

		public ReadOnlySpan<byte> ReadOctets(int octetCount)
		{
			return default(ReadOnlySpan<byte>);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
