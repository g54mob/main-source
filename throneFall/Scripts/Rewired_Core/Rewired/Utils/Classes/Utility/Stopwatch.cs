using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long ApJXfdYKqkSYcoajgWWGsgptfHGS = 10000000L;

		public static readonly Stopwatch Global;

		private static long ldycoiLSkrCzlehrjFlxXVwtAAJFb;

		private System.Diagnostics.Stopwatch VRhNtGLYmSWgRQVdevRyfxrDnJGy;

		private long pwchJJaHUvOojMOTkKZBFRwYSnBI;

		public static long frequency => ldycoiLSkrCzlehrjFlxXVwtAAJFb;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return (double)pwchJJaHUvOojMOTkKZBFRwYSnBI / (double)ldycoiLSkrCzlehrjFlxXVwtAAJFb;
			}
			set
			{
				pwchJJaHUvOojMOTkKZBFRwYSnBI = (long)(value * (double)ldycoiLSkrCzlehrjFlxXVwtAAJFb);
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return pwchJJaHUvOojMOTkKZBFRwYSnBI;
			}
			set
			{
				pwchJJaHUvOojMOTkKZBFRwYSnBI = value;
			}
		}

		double StopwatchBase.elapsedSeconds => (double)(VRhNtGLYmSWgRQVdevRyfxrDnJGy.ElapsedTicks + offsetTicks) / (double)ldycoiLSkrCzlehrjFlxXVwtAAJFb;

		double StopwatchBase.elapsedSecondsRaw => (double)VRhNtGLYmSWgRQVdevRyfxrDnJGy.ElapsedTicks / (double)ldycoiLSkrCzlehrjFlxXVwtAAJFb;

		long StopwatchBase.elapsedMilliseconds => (long)((double)(VRhNtGLYmSWgRQVdevRyfxrDnJGy.ElapsedTicks + offsetTicks) / (double)ldycoiLSkrCzlehrjFlxXVwtAAJFb * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => VRhNtGLYmSWgRQVdevRyfxrDnJGy.ElapsedMilliseconds;

		long StopwatchBase.elapsedTicks => VRhNtGLYmSWgRQVdevRyfxrDnJGy.ElapsedTicks + pwchJJaHUvOojMOTkKZBFRwYSnBI;

		long StopwatchBase.elapsedTicksRaw => VRhNtGLYmSWgRQVdevRyfxrDnJGy.ElapsedTicks;

		bool StopwatchBase.isRunning => VRhNtGLYmSWgRQVdevRyfxrDnJGy.IsRunning;

		static Stopwatch()
		{
			ldycoiLSkrCzlehrjFlxXVwtAAJFb = System.Diagnostics.Stopwatch.Frequency;
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
			if (ldycoiLSkrCzlehrjFlxXVwtAAJFb == 10000000)
			{
				return ticks;
			}
			return 10000000 / ldycoiLSkrCzlehrjFlxXVwtAAJFb;
		}

		public Stopwatch()
		{
			VRhNtGLYmSWgRQVdevRyfxrDnJGy = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			VRhNtGLYmSWgRQVdevRyfxrDnJGy.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				VRhNtGLYmSWgRQVdevRyfxrDnJGy.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			VRhNtGLYmSWgRQVdevRyfxrDnJGy.Reset();
		}
	}
}
