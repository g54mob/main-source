using System;

namespace Coherence.Brook
{
	public static class InOctetStreamExtensions
	{
		public static ReadOnlySpan<byte> GetOffsetBuffer(this IInOctetStream stream)
		{
			return default(ReadOnlySpan<byte>);
		}
	}
}
