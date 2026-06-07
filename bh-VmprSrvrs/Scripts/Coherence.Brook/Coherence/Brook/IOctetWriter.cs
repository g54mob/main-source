using System;

namespace Coherence.Brook
{
	public interface IOctetWriter
	{
		ReadOnlySpan<byte> Octets { get; }

		uint Position { get; }

		uint Capacity { get; }

		uint RemainingOctetCount { get; }

		void WriteOctet(byte v);

		void WriteOctets(byte[] v);

		void WriteOctets(ReadOnlySpan<byte> v);

		void Seek(uint newPosition);
	}
}
