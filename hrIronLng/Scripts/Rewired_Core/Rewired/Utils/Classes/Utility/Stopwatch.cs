using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long yXugMdYeVilWGXSuDPlFfrLjcqz = 10000000L;

		public static readonly Stopwatch Global;

		private static long ZfWfrCKsNvlWLWppXfakAxApXvo;

		private System.Diagnostics.Stopwatch jbYoHftSYRpRTpOpMAwBhkqZnWq;

		private long tYgXSREgwWCVABEQuHDfCqNAjZWh;

		public static long frequency => ZfWfrCKsNvlWLWppXfakAxApXvo;

		public override double offsetSeconds
		{
			get
			{
				return (double)tYgXSREgwWCVABEQuHDfCqNAjZWh / (double)ZfWfrCKsNvlWLWppXfakAxApXvo;
			}
			set
			{
				tYgXSREgwWCVABEQuHDfCqNAjZWh = (long)(value * (double)ZfWfrCKsNvlWLWppXfakAxApXvo);
			}
		}

		public override long offsetTicks
		{
			get
			{
				return tYgXSREgwWCVABEQuHDfCqNAjZWh;
			}
			set
			{
				tYgXSREgwWCVABEQuHDfCqNAjZWh = value;
			}
		}

		public override double elapsedSeconds => (double)(jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedTicks + offsetTicks) / (double)ZfWfrCKsNvlWLWppXfakAxApXvo;

		public override double elapsedSecondsRaw => (double)jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedTicks / (double)ZfWfrCKsNvlWLWppXfakAxApXvo;

		public override long elapsedMilliseconds => (long)((double)(jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedTicks + offsetTicks) / (double)ZfWfrCKsNvlWLWppXfakAxApXvo * 1000.0);

		public override long elapsedMillisecondsRaw => jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedMilliseconds;

		public override long elapsedTicks => jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedTicks + tYgXSREgwWCVABEQuHDfCqNAjZWh;

		public override long elapsedTicksRaw => jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedTicks;

		public override bool isRunning => jbYoHftSYRpRTpOpMAwBhkqZnWq.IsRunning;

		static Stopwatch()
		{
			ZfWfrCKsNvlWLWppXfakAxApXvo = System.Diagnostics.Stopwatch.Frequency;
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
			if (ZfWfrCKsNvlWLWppXfakAxApXvo == 10000000)
			{
				return ticks;
			}
			return 10000000 / ZfWfrCKsNvlWLWppXfakAxApXvo;
		}

		public Stopwatch()
		{
			jbYoHftSYRpRTpOpMAwBhkqZnWq = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			jbYoHftSYRpRTpOpMAwBhkqZnWq.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				jbYoHftSYRpRTpOpMAwBhkqZnWq.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			jbYoHftSYRpRTpOpMAwBhkqZnWq.Reset();
		}
	}
}
