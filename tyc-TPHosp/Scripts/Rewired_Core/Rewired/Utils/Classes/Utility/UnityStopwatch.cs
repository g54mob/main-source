using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class UUxRqKgDmasRDiKynVkwrSASnTX
		{
			public const long XcTobaCWsGGMgRsBwFcEoCwWGdR = 10000000L;

			private double rzBOWXYwnizVaFMftwFKHJtPIPV;

			private bool sFnYxABJDbPleWSKfAybWTjhabq;

			private double vfFRUIPUoKMeIeOScHBAvptzXYo;

			private double kDgfZtlOVVAnOSUPEBwZpbPgUuN;

			public bool IsRunning => sFnYxABJDbPleWSKfAybWTjhabq;

			public double ElapsedSeconds
			{
				get
				{
					if (!sFnYxABJDbPleWSKfAybWTjhabq)
					{
						return kDgfZtlOVVAnOSUPEBwZpbPgUuN;
					}
					return (double)Time.realtimeSinceStartup - vfFRUIPUoKMeIeOScHBAvptzXYo;
				}
			}

			public void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
				rzBOWXYwnizVaFMftwFKHJtPIPV = Time.realtimeSinceStartup;
			}

			public void PUfBGkQEoKKPRrTrZNGGdNNSToS()
			{
				if (!sFnYxABJDbPleWSKfAybWTjhabq)
				{
					sFnYxABJDbPleWSKfAybWTjhabq = true;
					vfFRUIPUoKMeIeOScHBAvptzXYo = rzBOWXYwnizVaFMftwFKHJtPIPV;
				}
			}

			public void CIEJgfDYMtwMWeSfJfPZCQnbOtY()
			{
				if (sFnYxABJDbPleWSKfAybWTjhabq)
				{
					sFnYxABJDbPleWSKfAybWTjhabq = false;
					kDgfZtlOVVAnOSUPEBwZpbPgUuN += rzBOWXYwnizVaFMftwFKHJtPIPV - vfFRUIPUoKMeIeOScHBAvptzXYo;
				}
			}

			public void QjNHfjHnCmaQyvCGKbwODraSxUWC()
			{
				vfFRUIPUoKMeIeOScHBAvptzXYo = 0.0;
				kDgfZtlOVVAnOSUPEBwZpbPgUuN = 0.0;
				bool flag = sFnYxABJDbPleWSKfAybWTjhabq;
				sFnYxABJDbPleWSKfAybWTjhabq = false;
				if (flag)
				{
					PUfBGkQEoKKPRrTrZNGGdNNSToS();
				}
			}
		}

		private const long CoARXDjZJbUaCUNkCBrCvtGDqsH = 10000000L;

		private static UnityStopwatch DgoqNgnBLopgKFIYmmhIasPETql;

		private readonly UUxRqKgDmasRDiKynVkwrSASnTX XQucoPWvfKAwRktHPAoAAjPtEEWF;

		private readonly bool EKnYbOqVBlVEaMdTeeRLhzHenkU;

		private double dFrAvTIoBNAkLCgSBTwNYZvfUnd;

		public static UnityStopwatch Global => DgoqNgnBLopgKFIYmmhIasPETql ?? (DgoqNgnBLopgKFIYmmhIasPETql = new UnityStopwatch(isGlobal: true));

		public static long frequency => 10000000L;

		public override double offsetSeconds
		{
			get
			{
				return dFrAvTIoBNAkLCgSBTwNYZvfUnd;
			}
			set
			{
				dFrAvTIoBNAkLCgSBTwNYZvfUnd = value;
			}
		}

		public override long offsetTicks
		{
			get
			{
				return (long)(dFrAvTIoBNAkLCgSBTwNYZvfUnd * 10000000.0);
			}
			set
			{
				dFrAvTIoBNAkLCgSBTwNYZvfUnd = (double)value / 10000000.0;
			}
		}

		public override double elapsedSeconds => XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedSeconds + offsetSeconds;

		public override double elapsedSecondsRaw => XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedSeconds;

		public override long elapsedMilliseconds => (long)((XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedSeconds + dFrAvTIoBNAkLCgSBTwNYZvfUnd) * 1000.0);

		public override long elapsedMillisecondsRaw => (long)(XQucoPWvfKAwRktHPAoAAjPtEEWF.ElapsedSeconds * 1000.0);

		public override long elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		public override long elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		public override bool isRunning => XQucoPWvfKAwRktHPAoAAjPtEEWF.IsRunning;

		public static UnityStopwatch StartNew()
		{
			UnityStopwatch unityStopwatch = new UnityStopwatch(isGlobal: false);
			unityStopwatch.Start();
			return unityStopwatch;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			return ticks;
		}

		public UnityStopwatch()
			: this(isGlobal: false)
		{
		}

		private UnityStopwatch(bool isGlobal)
		{
			XQucoPWvfKAwRktHPAoAAjPtEEWF = new UUxRqKgDmasRDiKynVkwrSASnTX();
			yYxVHcwZWcbrAmHUZNrqQPaQMde();
			if (isGlobal)
			{
				Start();
			}
			EKnYbOqVBlVEaMdTeeRLhzHenkU = isGlobal;
		}

		~UnityStopwatch()
		{
			cBSEGfwtrfVKtdLrApXjLbwpJLu();
		}

		public override void Stop()
		{
			if (EKnYbOqVBlVEaMdTeeRLhzHenkU)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			XQucoPWvfKAwRktHPAoAAjPtEEWF.CIEJgfDYMtwMWeSfJfPZCQnbOtY();
		}

		public override void Start()
		{
			if (!EKnYbOqVBlVEaMdTeeRLhzHenkU)
			{
				XQucoPWvfKAwRktHPAoAAjPtEEWF.PUfBGkQEoKKPRrTrZNGGdNNSToS();
			}
		}

		public override void Reset()
		{
			if (EKnYbOqVBlVEaMdTeeRLhzHenkU)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			XQucoPWvfKAwRktHPAoAAjPtEEWF.QjNHfjHnCmaQyvCGKbwODraSxUWC();
		}

		private void yYxVHcwZWcbrAmHUZNrqQPaQMde()
		{
			cBSEGfwtrfVKtdLrApXjLbwpJLu();
			ReInput.BeforeTimeManagerUpdateEvent += yQdUgprBXDEoWjnetusIxRhMmAu;
		}

		private void cBSEGfwtrfVKtdLrApXjLbwpJLu()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= yQdUgprBXDEoWjnetusIxRhMmAu;
		}

		private void yQdUgprBXDEoWjnetusIxRhMmAu(UpdateLoopType P_0)
		{
			XQucoPWvfKAwRktHPAoAAjPtEEWF.QTPiZFmnRsxmyQYmMuIoBQkOtfg();
		}
	}
}
