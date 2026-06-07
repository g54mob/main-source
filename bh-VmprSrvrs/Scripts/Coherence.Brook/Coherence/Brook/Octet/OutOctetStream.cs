using System;
using System.IO;

namespace Coherence.Brook.Octet
{
	public class OutOctetStream : IOutOctetStream, IOctetWriter
	{
		private BinaryWriter writer;

		private MemoryStream stream;

		public ReadOnlySpan<byte> Octets => default(ReadOnlySpan<byte>);

		public uint Capacity => 0u;

		public uint Position => 0u;

		public uint RemainingOctetCount => 0u;

		public OutOctetStream(int capacity)
		{
		}

		public OutOctetStream(byte[] buffer)
		{
		}

		private void Init(byte[] buffer)
		{
		}

		protected void ResizeAndReset(int capacity)
		{
		}

		protected void Reset()
		{
		}

		public void WriteUint16(ushort data)
		{
		}

		public void WriteUint32(uint data)
		{
		}

		public void WriteUint64(ulong data)
		{
		}

		public void WriteUint8(byte data)
		{
		}

		public void WriteOctet(byte v)
		{
		}

		public void WriteOctets(byte[] data)
		{
		}

		public void WriteOctets(ReadOnlySpan<byte> data)
		{
		}

		public void Seek(uint newPosition)
		{
		}

		public ArraySegment<byte> Close()
		{
			return default(ArraySegment<byte>);
		}
	}
}
