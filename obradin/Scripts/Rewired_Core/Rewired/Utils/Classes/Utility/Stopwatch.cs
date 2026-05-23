using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long UMXZmanKNXhCKiGeEeJAIeqGoFwg = 10000000L;

		public static readonly Stopwatch Global;

		private static long dIKVlkpFLcCUYapTqirxMLexKqwg;

		private System.Diagnostics.Stopwatch XJdPlaQAlkHyVCjLHboQazhehtx;

		private long ZpPqTYdaRfxhQirgpgJeDRQraeT;

		public static long frequency
		{
			get
			{
				return dIKVlkpFLcCUYapTqirxMLexKqwg;
			}
		}

		public override double offsetSeconds
		{
			get
			{
				return (double)ZpPqTYdaRfxhQirgpgJeDRQraeT / (double)dIKVlkpFLcCUYapTqirxMLexKqwg;
			}
			set
			{
				ZpPqTYdaRfxhQirgpgJeDRQraeT = (long)(value * (double)dIKVlkpFLcCUYapTqirxMLexKqwg);
			}
		}

		public override long offsetTicks
		{
			get
			{
				return ZpPqTYdaRfxhQirgpgJeDRQraeT;
			}
			set
			{
				ZpPqTYdaRfxhQirgpgJeDRQraeT = value;
			}
		}

		public override double elapsedSeconds
		{
			get
			{
				return (double)(XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedTicks + offsetTicks) / (double)dIKVlkpFLcCUYapTqirxMLexKqwg;
			}
		}

		public override double elapsedSecondsRaw
		{
			get
			{
				return (double)XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedTicks / (double)dIKVlkpFLcCUYapTqirxMLexKqwg;
			}
		}

		public override long elapsedMilliseconds
		{
			get
			{
				return (long)((double)(XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedTicks + offsetTicks) / (double)dIKVlkpFLcCUYapTqirxMLexKqwg * 1000.0);
			}
		}

		public override long elapsedMillisecondsRaw
		{
			get
			{
				return XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedMilliseconds;
			}
		}

		public override long elapsedTicks
		{
			get
			{
				return XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedTicks + ZpPqTYdaRfxhQirgpgJeDRQraeT;
			}
		}

		public override long elapsedTicksRaw
		{
			get
			{
				return XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedTicks;
			}
		}

		public override bool isRunning
		{
			get
			{
				return XJdPlaQAlkHyVCjLHboQazhehtx.IsRunning;
			}
		}

		static Stopwatch()
		{
			dIKVlkpFLcCUYapTqirxMLexKqwg = System.Diagnostics.Stopwatch.Frequency;
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
			if (dIKVlkpFLcCUYapTqirxMLexKqwg == 10000000)
			{
				return ticks;
			}
			return 10000000 / dIKVlkpFLcCUYapTqirxMLexKqwg;
		}

		public Stopwatch()
		{
			XJdPlaQAlkHyVCjLHboQazhehtx = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			while (true)
			{
				XJdPlaQAlkHyVCjLHboQazhehtx.Stop();
				int num = -1564288707;
				while (true)
				{
					switch (num ^ -1564288707)
					{
					case 2:
						goto IL_0013;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0013:
					num = -1564288708;
				}
			}
		}

		public override void Start()
		{
			if (this == Global)
			{
				while (true)
				{
					switch (-1400396294 ^ -1400396296)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			XJdPlaQAlkHyVCjLHboQazhehtx.Start();
		}

		public override void Reset()
		{
			if (this == Global)
			{
				goto IL_0008;
			}
			goto IL_003c;
			IL_0008:
			int num = -1234806650;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1234806651)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				throw new Exception("The Global Stopwatch cannot be reset.");
			case 1:
				goto IL_003c;
			case 2:
				return;
			}
			goto IL_0008;
			IL_003c:
			XJdPlaQAlkHyVCjLHboQazhehtx.Reset();
			num = -1234806649;
			goto IL_000d;
		}
	}
}
