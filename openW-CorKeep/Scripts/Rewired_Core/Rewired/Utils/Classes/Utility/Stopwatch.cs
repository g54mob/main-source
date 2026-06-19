using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long zkjsEKqKNyYPTeJAHclYebGahSPGb = 10000000L;

		public static readonly Stopwatch Global;

		private static long IUYFRRbjXzpmSlAGGNWlEqBkHtGk;

		private System.Diagnostics.Stopwatch wcFBYxBbZCurkcUCPrwktcGMoGLpA;

		private long GxGErmGqflBJSQOwRlgDSuRZRIYE;

		public static long frequency => IUYFRRbjXzpmSlAGGNWlEqBkHtGk;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return (double)GxGErmGqflBJSQOwRlgDSuRZRIYE / (double)IUYFRRbjXzpmSlAGGNWlEqBkHtGk;
			}
			set
			{
				GxGErmGqflBJSQOwRlgDSuRZRIYE = (long)(value * (double)IUYFRRbjXzpmSlAGGNWlEqBkHtGk);
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return GxGErmGqflBJSQOwRlgDSuRZRIYE;
			}
			set
			{
				GxGErmGqflBJSQOwRlgDSuRZRIYE = value;
			}
		}

		double StopwatchBase.elapsedSeconds => (double)(wcFBYxBbZCurkcUCPrwktcGMoGLpA.ElapsedTicks + offsetTicks) / (double)IUYFRRbjXzpmSlAGGNWlEqBkHtGk;

		double StopwatchBase.elapsedSecondsRaw => (double)wcFBYxBbZCurkcUCPrwktcGMoGLpA.ElapsedTicks / (double)IUYFRRbjXzpmSlAGGNWlEqBkHtGk;

		long StopwatchBase.elapsedMilliseconds => (long)((double)(wcFBYxBbZCurkcUCPrwktcGMoGLpA.ElapsedTicks + offsetTicks) / (double)IUYFRRbjXzpmSlAGGNWlEqBkHtGk * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => wcFBYxBbZCurkcUCPrwktcGMoGLpA.ElapsedMilliseconds;

		long StopwatchBase.elapsedTicks => wcFBYxBbZCurkcUCPrwktcGMoGLpA.ElapsedTicks + GxGErmGqflBJSQOwRlgDSuRZRIYE;

		long StopwatchBase.elapsedTicksRaw => wcFBYxBbZCurkcUCPrwktcGMoGLpA.ElapsedTicks;

		bool StopwatchBase.isRunning => wcFBYxBbZCurkcUCPrwktcGMoGLpA.IsRunning;

		static Stopwatch()
		{
			IUYFRRbjXzpmSlAGGNWlEqBkHtGk = System.Diagnostics.Stopwatch.Frequency;
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
			if (IUYFRRbjXzpmSlAGGNWlEqBkHtGk == 10000000)
			{
				return ticks;
			}
			return 10000000 / IUYFRRbjXzpmSlAGGNWlEqBkHtGk;
		}

		public Stopwatch()
		{
			wcFBYxBbZCurkcUCPrwktcGMoGLpA = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			wcFBYxBbZCurkcUCPrwktcGMoGLpA.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				wcFBYxBbZCurkcUCPrwktcGMoGLpA.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			wcFBYxBbZCurkcUCPrwktcGMoGLpA.Reset();
		}
	}
}
