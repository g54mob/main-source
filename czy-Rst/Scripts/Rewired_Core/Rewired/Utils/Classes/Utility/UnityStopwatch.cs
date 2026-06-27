using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class NiMzfMMKrFTNFAppkEEHyXbciZac
		{
			public const long wbkBwagEkodauglcRnmRiDwbraxZb = 10000000L;

			private double badyLWDcKIAmihGfggFkDpVibkgMA;

			private bool vACdDsOfPvBMwAzugrMThQpoMneCb;

			private double NhicWbaywNdIYpiHwpGbXRfpjdalA;

			private double DJbgznCsNSELHiBODostBJpHSBDqc;

			public bool NNRuWPXdKnVSCnWThRBUMQHVncDK => vACdDsOfPvBMwAzugrMThQpoMneCb;

			public double hQvUdPADZPwrwHoZSyxjrFUBkAQD
			{
				get
				{
					if (!vACdDsOfPvBMwAzugrMThQpoMneCb)
					{
						return DJbgznCsNSELHiBODostBJpHSBDqc;
					}
					return (double)Time.realtimeSinceStartup - NhicWbaywNdIYpiHwpGbXRfpjdalA;
				}
			}

			public void JNddAFaSQJPFkZIxKBzhGsPmmjWuA()
			{
				badyLWDcKIAmihGfggFkDpVibkgMA = Time.realtimeSinceStartup;
			}

			public void IFdFmhVnMBEPzqCMpXgECaSAeOio()
			{
				if (!vACdDsOfPvBMwAzugrMThQpoMneCb)
				{
					vACdDsOfPvBMwAzugrMThQpoMneCb = true;
					NhicWbaywNdIYpiHwpGbXRfpjdalA = badyLWDcKIAmihGfggFkDpVibkgMA;
				}
			}

			public void ReEXAmhXsNOTDisRPCXkNGvxqHvE()
			{
				if (vACdDsOfPvBMwAzugrMThQpoMneCb)
				{
					vACdDsOfPvBMwAzugrMThQpoMneCb = false;
					DJbgznCsNSELHiBODostBJpHSBDqc += badyLWDcKIAmihGfggFkDpVibkgMA - NhicWbaywNdIYpiHwpGbXRfpjdalA;
				}
			}

			public void wTgQkQkBzrBmcdTOsxQQLEUBCBI()
			{
				NhicWbaywNdIYpiHwpGbXRfpjdalA = 0.0;
				DJbgznCsNSELHiBODostBJpHSBDqc = 0.0;
				bool num = vACdDsOfPvBMwAzugrMThQpoMneCb;
				vACdDsOfPvBMwAzugrMThQpoMneCb = false;
				if (num)
				{
					IFdFmhVnMBEPzqCMpXgECaSAeOio();
				}
			}
		}

		private const long MvwEJVRmiaXyIyPpONhMEUPQqxxu = 10000000L;

		private static UnityStopwatch jNhHHtRRtTHMqJdNaspovHGypRfb;

		private readonly NiMzfMMKrFTNFAppkEEHyXbciZac PHRafIzJWKSChzAotEfLebfUkmQkA;

		private readonly bool aPhMfpBKjNQHRnjagQfOHlWuGIWu;

		private double LkyHRNoNjobqgdUbKiXkykwVXpTpA;

		public static UnityStopwatch Global => jNhHHtRRtTHMqJdNaspovHGypRfb ?? (jNhHHtRRtTHMqJdNaspovHGypRfb = new UnityStopwatch(true));

		public static long frequency => 10000000L;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return LkyHRNoNjobqgdUbKiXkykwVXpTpA;
			}
			set
			{
				LkyHRNoNjobqgdUbKiXkykwVXpTpA = value;
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return (long)(LkyHRNoNjobqgdUbKiXkykwVXpTpA * 10000000.0);
			}
			set
			{
				LkyHRNoNjobqgdUbKiXkykwVXpTpA = (double)value / 10000000.0;
			}
		}

		double StopwatchBase.elapsedSeconds => PHRafIzJWKSChzAotEfLebfUkmQkA.hQvUdPADZPwrwHoZSyxjrFUBkAQD + offsetSeconds;

		double StopwatchBase.elapsedSecondsRaw => PHRafIzJWKSChzAotEfLebfUkmQkA.hQvUdPADZPwrwHoZSyxjrFUBkAQD;

		long StopwatchBase.elapsedMilliseconds => (long)((PHRafIzJWKSChzAotEfLebfUkmQkA.hQvUdPADZPwrwHoZSyxjrFUBkAQD + LkyHRNoNjobqgdUbKiXkykwVXpTpA) * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => (long)(PHRafIzJWKSChzAotEfLebfUkmQkA.hQvUdPADZPwrwHoZSyxjrFUBkAQD * 1000.0);

		long StopwatchBase.elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		long StopwatchBase.elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		bool StopwatchBase.isRunning => PHRafIzJWKSChzAotEfLebfUkmQkA.NNRuWPXdKnVSCnWThRBUMQHVncDK;

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
			PHRafIzJWKSChzAotEfLebfUkmQkA = new NiMzfMMKrFTNFAppkEEHyXbciZac();
			iadrMixGLlntAbUFhPMFBSrLzLKS();
			if (P_0)
			{
				Start();
			}
			aPhMfpBKjNQHRnjagQfOHlWuGIWu = P_0;
		}

		~UnityStopwatch()
		{
			TzYeJkCzqVpgALWVRZfUXFwuTlcR();
		}

		public override void Stop()
		{
			if (aPhMfpBKjNQHRnjagQfOHlWuGIWu)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			PHRafIzJWKSChzAotEfLebfUkmQkA.ReEXAmhXsNOTDisRPCXkNGvxqHvE();
		}

		public override void Start()
		{
			if (!aPhMfpBKjNQHRnjagQfOHlWuGIWu)
			{
				PHRafIzJWKSChzAotEfLebfUkmQkA.IFdFmhVnMBEPzqCMpXgECaSAeOio();
			}
		}

		public override void Reset()
		{
			if (aPhMfpBKjNQHRnjagQfOHlWuGIWu)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			PHRafIzJWKSChzAotEfLebfUkmQkA.wTgQkQkBzrBmcdTOsxQQLEUBCBI();
		}

		private void iadrMixGLlntAbUFhPMFBSrLzLKS()
		{
			TzYeJkCzqVpgALWVRZfUXFwuTlcR();
			ReInput.BeforeTimeManagerUpdateEvent += FRVPXRHdLOAlGIaInArGRvTIpMDwA;
		}

		private void TzYeJkCzqVpgALWVRZfUXFwuTlcR()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= FRVPXRHdLOAlGIaInArGRvTIpMDwA;
		}

		private void FRVPXRHdLOAlGIaInArGRvTIpMDwA(UpdateLoopType P_0)
		{
			PHRafIzJWKSChzAotEfLebfUkmQkA.JNddAFaSQJPFkZIxKBzhGsPmmjWuA();
		}
	}
}
