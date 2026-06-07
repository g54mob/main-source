using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long FOKdVQnIrQFUFFdcHHmxEMOoGijy = 10000000L;

		public static readonly Stopwatch Global;

		private static long oBPYbAxXljBUFSbZtUaWxPEFDlxG;

		private System.Diagnostics.Stopwatch YreggMjCHbVzMOrXOzZrDERYDKyEb;

		private long KCGqVynrzswVTLgDgkFVncaHFXUC;

		public static long frequency => oBPYbAxXljBUFSbZtUaWxPEFDlxG;

		public override double offsetSeconds
		{
			get
			{
				return (double)KCGqVynrzswVTLgDgkFVncaHFXUC / (double)oBPYbAxXljBUFSbZtUaWxPEFDlxG;
			}
			set
			{
				KCGqVynrzswVTLgDgkFVncaHFXUC = (long)(value * (double)oBPYbAxXljBUFSbZtUaWxPEFDlxG);
			}
		}

		public override long offsetTicks
		{
			get
			{
				return KCGqVynrzswVTLgDgkFVncaHFXUC;
			}
			set
			{
				KCGqVynrzswVTLgDgkFVncaHFXUC = value;
			}
		}

		public override double elapsedSeconds => (double)(YreggMjCHbVzMOrXOzZrDERYDKyEb.ElapsedTicks + offsetTicks) / (double)oBPYbAxXljBUFSbZtUaWxPEFDlxG;

		public override double elapsedSecondsRaw => (double)YreggMjCHbVzMOrXOzZrDERYDKyEb.ElapsedTicks / (double)oBPYbAxXljBUFSbZtUaWxPEFDlxG;

		public override long elapsedMilliseconds => (long)((double)(YreggMjCHbVzMOrXOzZrDERYDKyEb.ElapsedTicks + offsetTicks) / (double)oBPYbAxXljBUFSbZtUaWxPEFDlxG * 1000.0);

		public override long elapsedMillisecondsRaw => YreggMjCHbVzMOrXOzZrDERYDKyEb.ElapsedMilliseconds;

		public override long elapsedTicks => YreggMjCHbVzMOrXOzZrDERYDKyEb.ElapsedTicks + KCGqVynrzswVTLgDgkFVncaHFXUC;

		public override long elapsedTicksRaw => YreggMjCHbVzMOrXOzZrDERYDKyEb.ElapsedTicks;

		public override bool isRunning => YreggMjCHbVzMOrXOzZrDERYDKyEb.IsRunning;

		static Stopwatch()
		{
			oBPYbAxXljBUFSbZtUaWxPEFDlxG = System.Diagnostics.Stopwatch.Frequency;
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
			if (oBPYbAxXljBUFSbZtUaWxPEFDlxG == 10000000)
			{
				return ticks;
			}
			return 10000000 / oBPYbAxXljBUFSbZtUaWxPEFDlxG;
		}

		public Stopwatch()
		{
			YreggMjCHbVzMOrXOzZrDERYDKyEb = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			YreggMjCHbVzMOrXOzZrDERYDKyEb.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				YreggMjCHbVzMOrXOzZrDERYDKyEb.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			YreggMjCHbVzMOrXOzZrDERYDKyEb.Reset();
		}
	}
}
