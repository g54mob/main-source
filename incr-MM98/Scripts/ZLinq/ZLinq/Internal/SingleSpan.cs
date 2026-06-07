using System;
using System.Runtime.InteropServices;

namespace ZLinq.Internal
{
	internal static class SingleSpan
	{
		internal static Span<T> Create<T>(ref T reference)
		{
			return MemoryMarshal.CreateSpan(ref reference, 1);
		}
	}
}
