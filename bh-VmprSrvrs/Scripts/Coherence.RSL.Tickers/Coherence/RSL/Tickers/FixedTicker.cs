using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Coherence.RSL.Tickers
{
	public class FixedTicker : ITickProvider
	{
		private double freq;

		private DateTime nextTime;

		[MaybeNull]
		private readonly Func<DateTime> getTimeNowOverride;

		public FixedTicker(int frequency)
		{
		}

		internal FixedTicker(int frequency, [MaybeNull] Func<DateTime> getTimeNowOverride)
		{
		}

		public bool Elapsed()
		{
			return false;
		}

		public void Reset()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private DateTime GetTimeNow()
		{
			return default(DateTime);
		}
	}
}
