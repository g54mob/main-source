using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long famLVlHFsrexIvPbfQFDTTrZDNqQ = 10000000L;

		public static readonly Stopwatch Global;

		private static long YLTCXoOryoAvPkUjssOgiLePOtpH;

		private System.Diagnostics.Stopwatch mAXOQAmsVJCpXhrpEGxMTxdZNmg;

		private long AJHGBDjkQsujJFPZxDNSgweqOWfz;

		public static long frequency => YLTCXoOryoAvPkUjssOgiLePOtpH;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return (double)AJHGBDjkQsujJFPZxDNSgweqOWfz / (double)YLTCXoOryoAvPkUjssOgiLePOtpH;
			}
			set
			{
				AJHGBDjkQsujJFPZxDNSgweqOWfz = (long)(value * (double)YLTCXoOryoAvPkUjssOgiLePOtpH);
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return AJHGBDjkQsujJFPZxDNSgweqOWfz;
			}
			set
			{
				AJHGBDjkQsujJFPZxDNSgweqOWfz = value;
			}
		}

		double StopwatchBase.elapsedSeconds => (double)(mAXOQAmsVJCpXhrpEGxMTxdZNmg.ElapsedTicks + offsetTicks) / (double)YLTCXoOryoAvPkUjssOgiLePOtpH;

		double StopwatchBase.elapsedSecondsRaw => (double)mAXOQAmsVJCpXhrpEGxMTxdZNmg.ElapsedTicks / (double)YLTCXoOryoAvPkUjssOgiLePOtpH;

		long StopwatchBase.elapsedMilliseconds => (long)((double)(mAXOQAmsVJCpXhrpEGxMTxdZNmg.ElapsedTicks + offsetTicks) / (double)YLTCXoOryoAvPkUjssOgiLePOtpH * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => mAXOQAmsVJCpXhrpEGxMTxdZNmg.ElapsedMilliseconds;

		long StopwatchBase.elapsedTicks => mAXOQAmsVJCpXhrpEGxMTxdZNmg.ElapsedTicks + AJHGBDjkQsujJFPZxDNSgweqOWfz;

		long StopwatchBase.elapsedTicksRaw => mAXOQAmsVJCpXhrpEGxMTxdZNmg.ElapsedTicks;

		bool StopwatchBase.isRunning => mAXOQAmsVJCpXhrpEGxMTxdZNmg.IsRunning;

		static Stopwatch()
		{
			YLTCXoOryoAvPkUjssOgiLePOtpH = System.Diagnostics.Stopwatch.Frequency;
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
			if (YLTCXoOryoAvPkUjssOgiLePOtpH == 10000000)
			{
				return ticks;
			}
			return 10000000 / YLTCXoOryoAvPkUjssOgiLePOtpH;
		}

		public Stopwatch()
		{
			mAXOQAmsVJCpXhrpEGxMTxdZNmg = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			mAXOQAmsVJCpXhrpEGxMTxdZNmg.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				mAXOQAmsVJCpXhrpEGxMTxdZNmg.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			mAXOQAmsVJCpXhrpEGxMTxdZNmg.Reset();
		}
	}
}
