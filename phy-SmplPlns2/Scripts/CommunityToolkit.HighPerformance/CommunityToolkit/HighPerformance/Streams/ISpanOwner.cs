using System;

namespace CommunityToolkit.HighPerformance.Streams
{
	internal interface ISpanOwner
	{
		int Length { get; }

		Span<byte> Span { get; }

		Memory<byte> Memory { get; }
	}
}
