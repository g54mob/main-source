using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long MDHCkXpcDBoerbAhbeXDLAjJDEm = 10000000L;

		public static readonly Stopwatch Global;

		private static long pPOFnobiSkgJguxDXCoaqURacUS;

		private System.Diagnostics.Stopwatch HZnDfeGkEodGvEXfoLZXMHFjjhXu;

		private long DYLxlMvOslRvkhoMGgyxcJoqiav;

		public static long frequency => pPOFnobiSkgJguxDXCoaqURacUS;

		public override double offsetSeconds
		{
			get
			{
				return (double)DYLxlMvOslRvkhoMGgyxcJoqiav / (double)pPOFnobiSkgJguxDXCoaqURacUS;
			}
			set
			{
				DYLxlMvOslRvkhoMGgyxcJoqiav = (long)(value * (double)pPOFnobiSkgJguxDXCoaqURacUS);
			}
		}

		public override long offsetTicks
		{
			get
			{
				return DYLxlMvOslRvkhoMGgyxcJoqiav;
			}
			set
			{
				DYLxlMvOslRvkhoMGgyxcJoqiav = value;
			}
		}

		public override double elapsedSeconds => (double)(HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedTicks + offsetTicks) / (double)pPOFnobiSkgJguxDXCoaqURacUS;

		public override double elapsedSecondsRaw => (double)HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedTicks / (double)pPOFnobiSkgJguxDXCoaqURacUS;

		public override long elapsedMilliseconds => (long)((double)(HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedTicks + offsetTicks) / (double)pPOFnobiSkgJguxDXCoaqURacUS * 1000.0);

		public override long elapsedMillisecondsRaw => HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedMilliseconds;

		public override long elapsedTicks => HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedTicks + DYLxlMvOslRvkhoMGgyxcJoqiav;

		public override long elapsedTicksRaw => HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedTicks;

		public override bool isRunning => HZnDfeGkEodGvEXfoLZXMHFjjhXu.IsRunning;

		static Stopwatch()
		{
			pPOFnobiSkgJguxDXCoaqURacUS = System.Diagnostics.Stopwatch.Frequency;
			Stopwatch stopwatch = default(Stopwatch);
			while (true)
			{
				int num = 159946565;
				while (true)
				{
					switch (num ^ 0x9889744)
					{
					case 2:
						break;
					case 1:
						goto IL_0028;
					default:
						stopwatch.Start();
						Global = stopwatch;
						return;
					}
					break;
					IL_0028:
					stopwatch = new Stopwatch();
					num = 159946564;
				}
			}
		}

		public static Stopwatch StartNew()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			return stopwatch;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			if (pPOFnobiSkgJguxDXCoaqURacUS == 10000000)
			{
				return ticks;
			}
			return 10000000 / pPOFnobiSkgJguxDXCoaqURacUS;
		}

		public Stopwatch()
		{
			HZnDfeGkEodGvEXfoLZXMHFjjhXu = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			HZnDfeGkEodGvEXfoLZXMHFjjhXu.Stop();
		}

		public override void Start()
		{
			if (this == Global)
			{
				return;
			}
			while (true)
			{
				HZnDfeGkEodGvEXfoLZXMHFjjhXu.Start();
				int num = -1497031048;
				while (true)
				{
					switch (num ^ -1497031046)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = -1497031045;
				}
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			HZnDfeGkEodGvEXfoLZXMHFjjhXu.Reset();
		}
	}
}
