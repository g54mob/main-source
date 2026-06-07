using System;

namespace Coherence.Brook
{
	public interface IInOctetStream : IOctetReader
	{
		ushort ReadUint16();

		uint ReadUint32();

		ulong ReadUint64();

		byte ReadUint8();

		ReadOnlySpan<byte> GetBuffer();
	}
}
