using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long pnrtCJKYhumRhNOaGOctcnURvBRW = 10000000L;

		public static readonly Stopwatch Global;

		private static long MbEFPYIHjjAqwmCwHjXAoPNDhSCWA;

		private System.Diagnostics.Stopwatch wDPoIeTmpGtVQxckWHpFznYlQJBp;

		private long AsOYpnmTgjNnobIJAsQiFNnsGMAe;

		public static long frequency => MbEFPYIHjjAqwmCwHjXAoPNDhSCWA;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return (double)AsOYpnmTgjNnobIJAsQiFNnsGMAe / (double)MbEFPYIHjjAqwmCwHjXAoPNDhSCWA;
			}
			set
			{
				AsOYpnmTgjNnobIJAsQiFNnsGMAe = (long)(value * (double)MbEFPYIHjjAqwmCwHjXAoPNDhSCWA);
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return AsOYpnmTgjNnobIJAsQiFNnsGMAe;
			}
			set
			{
				AsOYpnmTgjNnobIJAsQiFNnsGMAe = value;
			}
		}

		double StopwatchBase.elapsedSeconds => (double)(wDPoIeTmpGtVQxckWHpFznYlQJBp.ElapsedTicks + offsetTicks) / (double)MbEFPYIHjjAqwmCwHjXAoPNDhSCWA;

		double StopwatchBase.elapsedSecondsRaw => (double)wDPoIeTmpGtVQxckWHpFznYlQJBp.ElapsedTicks / (double)MbEFPYIHjjAqwmCwHjXAoPNDhSCWA;

		long StopwatchBase.elapsedMilliseconds => (long)((double)(wDPoIeTmpGtVQxckWHpFznYlQJBp.ElapsedTicks + offsetTicks) / (double)MbEFPYIHjjAqwmCwHjXAoPNDhSCWA * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => wDPoIeTmpGtVQxckWHpFznYlQJBp.ElapsedMilliseconds;

		long StopwatchBase.elapsedTicks => wDPoIeTmpGtVQxckWHpFznYlQJBp.ElapsedTicks + AsOYpnmTgjNnobIJAsQiFNnsGMAe;

		long StopwatchBase.elapsedTicksRaw => wDPoIeTmpGtVQxckWHpFznYlQJBp.ElapsedTicks;

		bool StopwatchBase.isRunning => wDPoIeTmpGtVQxckWHpFznYlQJBp.IsRunning;

		static Stopwatch()
		{
			MbEFPYIHjjAqwmCwHjXAoPNDhSCWA = System.Diagnostics.Stopwatch.Frequency;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Global = stopwatch;
		}

		public static Stopwatch StartNew()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			return stopwatch;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			if (MbEFPYIHjjAqwmCwHjXAoPNDhSCWA == 10000000)
			{
				return ticks;
			}
			return 10000000 / MbEFPYIHjjAqwmCwHjXAoPNDhSCWA;
		}

		public Stopwatch()
		{
			wDPoIeTmpGtVQxckWHpFznYlQJBp = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			wDPoIeTmpGtVQxckWHpFznYlQJBp.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				wDPoIeTmpGtVQxckWHpFznYlQJBp.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			wDPoIeTmpGtVQxckWHpFznYlQJBp.Reset();
		}
	}
}
