using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long sXWCELFVPKpexniKoLCDGDbdEyxBb = 10000000L;

		public static readonly Stopwatch Global;

		private static long BYHXRDFtPpQadtCfCHysdsrYIBjnA;

		private System.Diagnostics.Stopwatch jUqrsDggbviCoWsphvjFZmkVJMcp;

		private long xzULbfJBDcWLnwRGBLOdqbBIQLUT;

		public static long frequency => BYHXRDFtPpQadtCfCHysdsrYIBjnA;

		public override double offsetSeconds
		{
			get
			{
				return (double)xzULbfJBDcWLnwRGBLOdqbBIQLUT / (double)BYHXRDFtPpQadtCfCHysdsrYIBjnA;
			}
			set
			{
				xzULbfJBDcWLnwRGBLOdqbBIQLUT = (long)(value * (double)BYHXRDFtPpQadtCfCHysdsrYIBjnA);
			}
		}

		public override long offsetTicks
		{
			get
			{
				return xzULbfJBDcWLnwRGBLOdqbBIQLUT;
			}
			set
			{
				xzULbfJBDcWLnwRGBLOdqbBIQLUT = value;
			}
		}

		public override double elapsedSeconds => (double)(jUqrsDggbviCoWsphvjFZmkVJMcp.ElapsedTicks + offsetTicks) / (double)BYHXRDFtPpQadtCfCHysdsrYIBjnA;

		public override double elapsedSecondsRaw => (double)jUqrsDggbviCoWsphvjFZmkVJMcp.ElapsedTicks / (double)BYHXRDFtPpQadtCfCHysdsrYIBjnA;

		public override long elapsedMilliseconds => (long)((double)(jUqrsDggbviCoWsphvjFZmkVJMcp.ElapsedTicks + offsetTicks) / (double)BYHXRDFtPpQadtCfCHysdsrYIBjnA * 1000.0);

		public override long elapsedMillisecondsRaw => jUqrsDggbviCoWsphvjFZmkVJMcp.ElapsedMilliseconds;

		public override long elapsedTicks => jUqrsDggbviCoWsphvjFZmkVJMcp.ElapsedTicks + xzULbfJBDcWLnwRGBLOdqbBIQLUT;

		public override long elapsedTicksRaw => jUqrsDggbviCoWsphvjFZmkVJMcp.ElapsedTicks;

		public override bool isRunning => jUqrsDggbviCoWsphvjFZmkVJMcp.IsRunning;

		static Stopwatch()
		{
			BYHXRDFtPpQadtCfCHysdsrYIBjnA = System.Diagnostics.Stopwatch.Frequency;
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
			if (BYHXRDFtPpQadtCfCHysdsrYIBjnA == 10000000)
			{
				return ticks;
			}
			return 10000000 / BYHXRDFtPpQadtCfCHysdsrYIBjnA;
		}

		public Stopwatch()
		{
			jUqrsDggbviCoWsphvjFZmkVJMcp = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			jUqrsDggbviCoWsphvjFZmkVJMcp.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				jUqrsDggbviCoWsphvjFZmkVJMcp.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			jUqrsDggbviCoWsphvjFZmkVJMcp.Reset();
		}
	}
}
