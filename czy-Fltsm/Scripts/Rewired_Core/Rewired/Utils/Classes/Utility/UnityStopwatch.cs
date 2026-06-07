using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class WvDYfuVvFngjgydvGbfYHDYVUYoz
		{
			public const long ndNOonhmdwUKPHhkgQPTexfSLMIX = 10000000L;

			private double qGWeqBUgZEpUHRVdPtcaMFSBqKBS;

			private bool kCvnZfJpAjmaXHRoPitPrKqTCVTY;

			private double ScPAsajArLmLnMwBTfkdkjgSPUXk;

			private double GvOfOuHOJEtropUnyLvlakUpxGoE;

			public bool AqqKsIGRBvjhlNrDAOsOhmWiFPws => kCvnZfJpAjmaXHRoPitPrKqTCVTY;

			public double mRKdQSHFEVhCVvxDbLRpCOAoYErfA
			{
				get
				{
					if (!kCvnZfJpAjmaXHRoPitPrKqTCVTY)
					{
						return GvOfOuHOJEtropUnyLvlakUpxGoE;
					}
					return (double)Time.realtimeSinceStartup - ScPAsajArLmLnMwBTfkdkjgSPUXk;
				}
			}

			public void YvWKSSrnDXxXDlYzjMxlTHSJBbhJ()
			{
				qGWeqBUgZEpUHRVdPtcaMFSBqKBS = Time.realtimeSinceStartup;
			}

			public void BxYhFkYPXXZmUOXOQKwYloZxPkFT()
			{
				if (!kCvnZfJpAjmaXHRoPitPrKqTCVTY)
				{
					kCvnZfJpAjmaXHRoPitPrKqTCVTY = true;
					ScPAsajArLmLnMwBTfkdkjgSPUXk = qGWeqBUgZEpUHRVdPtcaMFSBqKBS;
				}
			}

			public void QYxeJtgnbJbcwORqkevmdgZIzISMA()
			{
				if (kCvnZfJpAjmaXHRoPitPrKqTCVTY)
				{
					kCvnZfJpAjmaXHRoPitPrKqTCVTY = false;
					GvOfOuHOJEtropUnyLvlakUpxGoE += qGWeqBUgZEpUHRVdPtcaMFSBqKBS - ScPAsajArLmLnMwBTfkdkjgSPUXk;
				}
			}

			public void tbaAgdPttrcRHJIRjdTMBdLxWdsXA()
			{
				ScPAsajArLmLnMwBTfkdkjgSPUXk = 0.0;
				GvOfOuHOJEtropUnyLvlakUpxGoE = 0.0;
				bool num = kCvnZfJpAjmaXHRoPitPrKqTCVTY;
				kCvnZfJpAjmaXHRoPitPrKqTCVTY = false;
				if (num)
				{
					BxYhFkYPXXZmUOXOQKwYloZxPkFT();
				}
			}
		}

		private const long XnFZyQSnlwEafCVhpYfMltApDtCI = 10000000L;

		private static UnityStopwatch uoAWPYYCUHxhhjJxLxTbClAFeZyP;

		private readonly WvDYfuVvFngjgydvGbfYHDYVUYoz CxeOxDwQLMGkAHRuYuCFCeqtLMhr;

		private readonly bool lOOcxsIpiBjtwBTyLCIKeFDNVgzn;

		private double YyNVhYvLagUePawdryzwNFjeTzoJ;

		public static UnityStopwatch Global => uoAWPYYCUHxhhjJxLxTbClAFeZyP ?? (uoAWPYYCUHxhhjJxLxTbClAFeZyP = new UnityStopwatch(true));

		public static long frequency => 10000000L;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return YyNVhYvLagUePawdryzwNFjeTzoJ;
			}
			set
			{
				YyNVhYvLagUePawdryzwNFjeTzoJ = value;
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return (long)(YyNVhYvLagUePawdryzwNFjeTzoJ * 10000000.0);
			}
			set
			{
				YyNVhYvLagUePawdryzwNFjeTzoJ = (double)value / 10000000.0;
			}
		}

		double StopwatchBase.elapsedSeconds => CxeOxDwQLMGkAHRuYuCFCeqtLMhr.mRKdQSHFEVhCVvxDbLRpCOAoYErfA + offsetSeconds;

		double StopwatchBase.elapsedSecondsRaw => CxeOxDwQLMGkAHRuYuCFCeqtLMhr.mRKdQSHFEVhCVvxDbLRpCOAoYErfA;

		long StopwatchBase.elapsedMilliseconds => (long)((CxeOxDwQLMGkAHRuYuCFCeqtLMhr.mRKdQSHFEVhCVvxDbLRpCOAoYErfA + YyNVhYvLagUePawdryzwNFjeTzoJ) * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => (long)(CxeOxDwQLMGkAHRuYuCFCeqtLMhr.mRKdQSHFEVhCVvxDbLRpCOAoYErfA * 1000.0);

		long StopwatchBase.elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		long StopwatchBase.elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		bool StopwatchBase.isRunning => CxeOxDwQLMGkAHRuYuCFCeqtLMhr.AqqKsIGRBvjhlNrDAOsOhmWiFPws;

		public static UnityStopwatch StartNew()
		{
			UnityStopwatch unityStopwatch = new UnityStopwatch(false);
			unityStopwatch.Start();
			return unityStopwatch;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			return ticks;
		}

		public UnityStopwatch()
			: this(false)
		{
		}

		private UnityStopwatch(bool P_0)
		{
			CxeOxDwQLMGkAHRuYuCFCeqtLMhr = new WvDYfuVvFngjgydvGbfYHDYVUYoz();
			rIQaIneMIvcHpZfHSZfNwtuqKpzN();
			if (P_0)
			{
				Start();
			}
			lOOcxsIpiBjtwBTyLCIKeFDNVgzn = P_0;
		}

		~UnityStopwatch()
		{
			SExRxxgpQZGtHvVVqGAjcvBXTDJC();
		}

		public override void Stop()
		{
			if (lOOcxsIpiBjtwBTyLCIKeFDNVgzn)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			CxeOxDwQLMGkAHRuYuCFCeqtLMhr.QYxeJtgnbJbcwORqkevmdgZIzISMA();
		}

		public override void Start()
		{
			if (!lOOcxsIpiBjtwBTyLCIKeFDNVgzn)
			{
				CxeOxDwQLMGkAHRuYuCFCeqtLMhr.BxYhFkYPXXZmUOXOQKwYloZxPkFT();
			}
		}

		public override void Reset()
		{
			if (lOOcxsIpiBjtwBTyLCIKeFDNVgzn)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			CxeOxDwQLMGkAHRuYuCFCeqtLMhr.tbaAgdPttrcRHJIRjdTMBdLxWdsXA();
		}

		private void rIQaIneMIvcHpZfHSZfNwtuqKpzN()
		{
			SExRxxgpQZGtHvVVqGAjcvBXTDJC();
			ReInput.BeforeTimeManagerUpdateEvent += YmeZpAMaWQDSxUXGQUvCYCWvsqej;
		}

		private void SExRxxgpQZGtHvVVqGAjcvBXTDJC()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= YmeZpAMaWQDSxUXGQUvCYCWvsqej;
		}

		private void YmeZpAMaWQDSxUXGQUvCYCWvsqej(UpdateLoopType P_0)
		{
			CxeOxDwQLMGkAHRuYuCFCeqtLMhr.YvWKSSrnDXxXDlYzjMxlTHSJBbhJ();
		}
	}
}
