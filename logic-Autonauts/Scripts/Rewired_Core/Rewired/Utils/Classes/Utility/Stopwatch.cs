using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long hYTshpHoTFEhrWGvsfFUkVqSQEpB = 10000000L;

		public static readonly Stopwatch Global;

		private static long IWUAgfJBToCzlJBWGhnllkenNbpB;

		private System.Diagnostics.Stopwatch mVvWXxiAtwPieoNAdspYRflscLk;

		private long mXZgMVFTZfgSlUQhXJNwkNItanY;

		public static long frequency
		{
			get
			{
				return IWUAgfJBToCzlJBWGhnllkenNbpB;
			}
		}

		public override double offsetSeconds
		{
			get
			{
				return (double)mXZgMVFTZfgSlUQhXJNwkNItanY / (double)IWUAgfJBToCzlJBWGhnllkenNbpB;
			}
			set
			{
				mXZgMVFTZfgSlUQhXJNwkNItanY = (long)(value * (double)IWUAgfJBToCzlJBWGhnllkenNbpB);
			}
		}

		public override long offsetTicks
		{
			get
			{
				return mXZgMVFTZfgSlUQhXJNwkNItanY;
			}
			set
			{
				mXZgMVFTZfgSlUQhXJNwkNItanY = value;
			}
		}

		public override double elapsedSeconds
		{
			get
			{
				return (double)(mVvWXxiAtwPieoNAdspYRflscLk.ElapsedTicks + offsetTicks) / (double)IWUAgfJBToCzlJBWGhnllkenNbpB;
			}
		}

		public override double elapsedSecondsRaw
		{
			get
			{
				return (double)mVvWXxiAtwPieoNAdspYRflscLk.ElapsedTicks / (double)IWUAgfJBToCzlJBWGhnllkenNbpB;
			}
		}

		public override long elapsedMilliseconds
		{
			get
			{
				return (long)((double)(mVvWXxiAtwPieoNAdspYRflscLk.ElapsedTicks + offsetTicks) / (double)IWUAgfJBToCzlJBWGhnllkenNbpB * 1000.0);
			}
		}

		public override long elapsedMillisecondsRaw
		{
			get
			{
				return mVvWXxiAtwPieoNAdspYRflscLk.ElapsedMilliseconds;
			}
		}

		public override long elapsedTicks
		{
			get
			{
				return mVvWXxiAtwPieoNAdspYRflscLk.ElapsedTicks + mXZgMVFTZfgSlUQhXJNwkNItanY;
			}
		}

		public override long elapsedTicksRaw
		{
			get
			{
				return mVvWXxiAtwPieoNAdspYRflscLk.ElapsedTicks;
			}
		}

		public override bool isRunning
		{
			get
			{
				return mVvWXxiAtwPieoNAdspYRflscLk.IsRunning;
			}
		}

		static Stopwatch()
		{
			IWUAgfJBToCzlJBWGhnllkenNbpB = System.Diagnostics.Stopwatch.Frequency;
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
			if (IWUAgfJBToCzlJBWGhnllkenNbpB == 10000000)
			{
				return ticks;
			}
			return 10000000 / IWUAgfJBToCzlJBWGhnllkenNbpB;
		}

		public Stopwatch()
		{
			mVvWXxiAtwPieoNAdspYRflscLk = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			mVvWXxiAtwPieoNAdspYRflscLk.Stop();
		}

		public override void Start()
		{
			if (this == Global)
			{
				while (true)
				{
					switch (-770232083 ^ -770232084)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			mVvWXxiAtwPieoNAdspYRflscLk.Start();
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			while (true)
			{
				mVvWXxiAtwPieoNAdspYRflscLk.Reset();
				int num = 201383974;
				while (true)
				{
					switch (num ^ 0xC00E026)
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
					num = 201383975;
				}
			}
		}
	}
}
