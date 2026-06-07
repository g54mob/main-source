using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long hVrrZXAaYBuPcwIPHbrHgTgGzItl = 10000000L;

		public static readonly Stopwatch Global;

		private static long ALAcwIZXYCNZrltJSDUyVLbIIwmn;

		private System.Diagnostics.Stopwatch mDNrNyZSUrOLkGXQRitQrcLmxjaB;

		private long CjMohlcOsEcitkKdFlpEmPfdSgarA;

		public static long frequency => 0L;

		public override double offsetSeconds
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public override long offsetTicks
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public override double elapsedSeconds => 0.0;

		public override double elapsedSecondsRaw => 0.0;

		public override long elapsedMilliseconds => 0L;

		public override long elapsedMillisecondsRaw => 0L;

		public override long elapsedTicks => 0L;

		public override long elapsedTicksRaw => 0L;

		public override bool isRunning => false;

		static Stopwatch()
		{
		}

		public static Stopwatch StartNew()
		{
			return null;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			return 0L;
		}

		public override void Stop()
		{
		}

		public override void Start()
		{
		}

		public override void Reset()
		{
		}
	}
}
