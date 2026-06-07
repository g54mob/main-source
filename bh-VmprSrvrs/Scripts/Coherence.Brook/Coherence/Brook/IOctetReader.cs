using System;

namespace Coherence.Brook
{
	public interface IOctetReader
	{
		uint Position { get; }

		uint Length { get; }

		int RemainingOctetCount { get; }

		byte ReadOctet();

		ReadOnlySpan<byte> ReadOctets(int octetCount);
	}
}
