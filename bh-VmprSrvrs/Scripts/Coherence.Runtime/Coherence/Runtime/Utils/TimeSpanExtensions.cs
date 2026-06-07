using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Coherence.Runtime.Utils
{
	internal static class TimeSpanExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Awaitable.Awaiter GetAwaiter(this TimeSpan timeSpan)
		{
			return default(Awaitable.Awaiter);
		}
	}
}
