using System;

namespace ZLinq.Internal
{
	internal static class SingleSpan
	{
		internal static Span<T> Create<T>(ref T reference) where T : notnull
		{
			return default(Span<T>);
		}
	}
}
