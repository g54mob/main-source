using System;

namespace Coherence.Brook
{
	public interface IOutOctetStream : IOctetWriter
	{
		void WriteUint8(byte a);

		void WriteUint16(ushort a);

		void WriteUint32(uint a);

		void WriteUint64(ulong a);

		ArraySegment<byte> Close();
	}
}
