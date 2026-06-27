using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long cTAIiULwfolIMbiqxRZhLdZqliag = 10000000L;

		public static readonly Stopwatch Global;

		private static long ZIzTDFUiwlCOHggmoibIsTEielpg;

		private System.Diagnostics.Stopwatch jZaaMlKEeANBdTRybeWREyROQleW;

		private long TqbgWqDpEhVxVTVChcRkmeYVeajYA;

		public static long frequency => ZIzTDFUiwlCOHggmoibIsTEielpg;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return (double)TqbgWqDpEhVxVTVChcRkmeYVeajYA / (double)ZIzTDFUiwlCOHggmoibIsTEielpg;
			}
			set
			{
				TqbgWqDpEhVxVTVChcRkmeYVeajYA = (long)(value * (double)ZIzTDFUiwlCOHggmoibIsTEielpg);
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return TqbgWqDpEhVxVTVChcRkmeYVeajYA;
			}
			set
			{
				TqbgWqDpEhVxVTVChcRkmeYVeajYA = value;
			}
		}

		double StopwatchBase.elapsedSeconds => (double)(jZaaMlKEeANBdTRybeWREyROQleW.ElapsedTicks + offsetTicks) / (double)ZIzTDFUiwlCOHggmoibIsTEielpg;

		double StopwatchBase.elapsedSecondsRaw => (double)jZaaMlKEeANBdTRybeWREyROQleW.ElapsedTicks / (double)ZIzTDFUiwlCOHggmoibIsTEielpg;

		long StopwatchBase.elapsedMilliseconds => (long)((double)(jZaaMlKEeANBdTRybeWREyROQleW.ElapsedTicks + offsetTicks) / (double)ZIzTDFUiwlCOHggmoibIsTEielpg * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => jZaaMlKEeANBdTRybeWREyROQleW.ElapsedMilliseconds;

		long StopwatchBase.elapsedTicks => jZaaMlKEeANBdTRybeWREyROQleW.ElapsedTicks + TqbgWqDpEhVxVTVChcRkmeYVeajYA;

		long StopwatchBase.elapsedTicksRaw => jZaaMlKEeANBdTRybeWREyROQleW.ElapsedTicks;

		bool StopwatchBase.isRunning => jZaaMlKEeANBdTRybeWREyROQleW.IsRunning;

		static Stopwatch()
		{
			ZIzTDFUiwlCOHggmoibIsTEielpg = System.Diagnostics.Stopwatch.Frequency;
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
			if (ZIzTDFUiwlCOHggmoibIsTEielpg == 10000000)
			{
				return ticks;
			}
			return 10000000 / ZIzTDFUiwlCOHggmoibIsTEielpg;
		}

		public Stopwatch()
		{
			jZaaMlKEeANBdTRybeWREyROQleW = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			jZaaMlKEeANBdTRybeWREyROQleW.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				jZaaMlKEeANBdTRybeWREyROQleW.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			jZaaMlKEeANBdTRybeWREyROQleW.Reset();
		}
	}
}
