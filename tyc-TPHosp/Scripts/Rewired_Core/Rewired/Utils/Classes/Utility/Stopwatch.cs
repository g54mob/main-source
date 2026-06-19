using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long CoARXDjZJbUaCUNkCBrCvtGDqsH = 10000000L;

		public static readonly Stopwatch Global;

		private static long hCHEwZvZfICHINeFmlzfKeEcTSD;

		private System.Diagnostics.Stopwatch XQucoPWvfKAwRktHPAoAAjPtEEWF;

		private long LBQiNhdeDLlJQGFilVXcKnugPSg;

		public static long frequency => hCHEwZvZfICHINeFmlzfKeEcTSD;

		public override double offsetSeconds
		{
			get
			{
				return (double)LBQiNhdeDLlJQGFilVXcKnugPSg / (double)hCHEwZvZfICHINeFmlzfKeEcTSD;
			}
			set
			{
				LBQiNhdeDLlJQGFilVXcKnugPSg = (long)(value * (double)hCHEwZvZfICHINeFmlzfKeEcTSD);
			}
		}

		public override long offsetTicks
		{
			get
			{
				return LBQiNhdeDLlJQGFilVXcKnugPSg;
			}
			set
			{
				LBQiNhdeDLlJQGFilVXcKnugPSg = value;
			}
		}

		public override double elapsedSeconds => (double)(XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedTicks + offsetTicks) / (double)hCHEwZvZfICHINeFmlzfKeEcTSD;

		public override double elapsedSecondsRaw => (double)XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedTicks / (double)hCHEwZvZfICHINeFmlzfKeEcTSD;

		public override long elapsedMilliseconds => (long)((double)(XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedTicks + offsetTicks) / (double)hCHEwZvZfICHINeFmlzfKeEcTSD * 1000.0);

		public override long elapsedMillisecondsRaw => XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedMilliseconds;

		public override long elapsedTicks => XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedTicks + LBQiNhdeDLlJQGFilVXcKnugPSg;

		public override long elapsedTicksRaw => XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedTicks;

		public override bool isRunning => XQucoPWvfKAwRktHPAoAAjPtEEWF.IsRunning;

		static Stopwatch()
		{
			hCHEwZvZfICHINeFmlzfKeEcTSD = System.Diagnostics.Stopwatch.Frequency;
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
			if (hCHEwZvZfICHINeFmlzfKeEcTSD == 10000000)
			{
				return ticks;
			}
			return 10000000 / hCHEwZvZfICHINeFmlzfKeEcTSD;
		}

		public Stopwatch()
		{
			XQucoPWvfKAwRktHPAoAAjPtEEWF = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			XQucoPWvfKAwRktHPAoAAjPtEEWF.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				XQucoPWvfKAwRktHPAoAAjPtEEWF.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			XQucoPWvfKAwRktHPAoAAjPtEEWF.Reset();
		}
	}
}
