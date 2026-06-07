using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long jDfQdnWFzTMFRlLmLupOnPBOxMQI = 10000000L;

		public static readonly Stopwatch Global;

		private static long IpOXDcLvgOpbMyuWCRCfQhOYkwXF;

		private System.Diagnostics.Stopwatch aiBIfKPtbhwFkVziNfrqioXqdtQj;

		private long EqAWARgMPQhGMRkMXoeJGdCrQuRs;

		public static long frequency => IpOXDcLvgOpbMyuWCRCfQhOYkwXF;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return (double)EqAWARgMPQhGMRkMXoeJGdCrQuRs / (double)IpOXDcLvgOpbMyuWCRCfQhOYkwXF;
			}
			set
			{
				EqAWARgMPQhGMRkMXoeJGdCrQuRs = (long)(value * (double)IpOXDcLvgOpbMyuWCRCfQhOYkwXF);
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return EqAWARgMPQhGMRkMXoeJGdCrQuRs;
			}
			set
			{
				EqAWARgMPQhGMRkMXoeJGdCrQuRs = value;
			}
		}

		double StopwatchBase.elapsedSeconds => (double)(aiBIfKPtbhwFkVziNfrqioXqdtQj.ElapsedTicks + offsetTicks) / (double)IpOXDcLvgOpbMyuWCRCfQhOYkwXF;

		double StopwatchBase.elapsedSecondsRaw => (double)aiBIfKPtbhwFkVziNfrqioXqdtQj.ElapsedTicks / (double)IpOXDcLvgOpbMyuWCRCfQhOYkwXF;

		long StopwatchBase.elapsedMilliseconds => (long)((double)(aiBIfKPtbhwFkVziNfrqioXqdtQj.ElapsedTicks + offsetTicks) / (double)IpOXDcLvgOpbMyuWCRCfQhOYkwXF * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => aiBIfKPtbhwFkVziNfrqioXqdtQj.ElapsedMilliseconds;

		long StopwatchBase.elapsedTicks => aiBIfKPtbhwFkVziNfrqioXqdtQj.ElapsedTicks + EqAWARgMPQhGMRkMXoeJGdCrQuRs;

		long StopwatchBase.elapsedTicksRaw => aiBIfKPtbhwFkVziNfrqioXqdtQj.ElapsedTicks;

		bool StopwatchBase.isRunning => aiBIfKPtbhwFkVziNfrqioXqdtQj.IsRunning;

		static Stopwatch()
		{
			IpOXDcLvgOpbMyuWCRCfQhOYkwXF = System.Diagnostics.Stopwatch.Frequency;
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
			if (IpOXDcLvgOpbMyuWCRCfQhOYkwXF == 10000000)
			{
				return ticks;
			}
			return 10000000 / IpOXDcLvgOpbMyuWCRCfQhOYkwXF;
		}

		public Stopwatch()
		{
			aiBIfKPtbhwFkVziNfrqioXqdtQj = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			aiBIfKPtbhwFkVziNfrqioXqdtQj.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				aiBIfKPtbhwFkVziNfrqioXqdtQj.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			aiBIfKPtbhwFkVziNfrqioXqdtQj.Reset();
		}
	}
}
