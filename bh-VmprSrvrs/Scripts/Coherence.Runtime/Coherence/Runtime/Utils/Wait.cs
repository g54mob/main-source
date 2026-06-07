using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace Coherence.Runtime.Utils
{
	internal static class Wait
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Awaitable For(TimeSpan timeSpan)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Awaitable For(TimeSpan timeSpan, CancellationToken cancellationToken)
		{
			return null;
		}
	}
}
