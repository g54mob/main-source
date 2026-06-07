using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class AXPlbETJTIapCSefDjAjUXJIqPrI
		{
			public const long zhNgzLjFxDTAjrtkzPxsdEiNekHi = 10000000L;

			private double oaSampOFNhvFjtBvEOiTPiNGjcAU;

			private bool oGbRgRTOOWdhrhpaIvvuiFpWbEOL;

			private double WaDaEKivrairZvwXSubGDdvJxrGsA;

			private double QFCubSXXQjniCRMCnDBIvUfuJHfp;

			public bool YvuySoQxTGaiZhoLPgKlyQRzvKbL => oGbRgRTOOWdhrhpaIvvuiFpWbEOL;

			public double uSoGslZYcaXbDXRuDZEATZfRmkAb
			{
				get
				{
					if (!oGbRgRTOOWdhrhpaIvvuiFpWbEOL)
					{
						return QFCubSXXQjniCRMCnDBIvUfuJHfp;
					}
					return (double)Time.realtimeSinceStartup - WaDaEKivrairZvwXSubGDdvJxrGsA;
				}
			}

			public void GMYURgpRPamjbPthiMwKIpZKbRyf()
			{
				oaSampOFNhvFjtBvEOiTPiNGjcAU = Time.realtimeSinceStartup;
			}

			public void LPIcZUIZRapNoeHUVAidcxSktCCu()
			{
				if (!oGbRgRTOOWdhrhpaIvvuiFpWbEOL)
				{
					oGbRgRTOOWdhrhpaIvvuiFpWbEOL = true;
					WaDaEKivrairZvwXSubGDdvJxrGsA = oaSampOFNhvFjtBvEOiTPiNGjcAU;
				}
			}

			public void EEvNmNmBpggnMsootplVxvKPkaBp()
			{
				if (oGbRgRTOOWdhrhpaIvvuiFpWbEOL)
				{
					oGbRgRTOOWdhrhpaIvvuiFpWbEOL = false;
					QFCubSXXQjniCRMCnDBIvUfuJHfp += oaSampOFNhvFjtBvEOiTPiNGjcAU - WaDaEKivrairZvwXSubGDdvJxrGsA;
				}
			}

			public void vDgsSPRGlECPrmGLkFpzmOVmFfrg()
			{
				WaDaEKivrairZvwXSubGDdvJxrGsA = 0.0;
				QFCubSXXQjniCRMCnDBIvUfuJHfp = 0.0;
				bool num = oGbRgRTOOWdhrhpaIvvuiFpWbEOL;
				oGbRgRTOOWdhrhpaIvvuiFpWbEOL = false;
				if (num)
				{
					LPIcZUIZRapNoeHUVAidcxSktCCu();
				}
			}
		}

		private const long JVHpJeSrrFUXJiNjyfQhqURktjVq = 10000000L;

		private static UnityStopwatch mrORoySYyuoVaVpuIJKGDRhYrBhe;

		private readonly AXPlbETJTIapCSefDjAjUXJIqPrI AOgjBlqaBjddsxhgBbIeXmfeBeeR;

		private readonly bool dVWhnUSGusbyIHpoUnOdapSEWQilb;

		private double UuFsBmvPkHtPrYHnkikJcYqhPzlSA;

		public static UnityStopwatch Global => mrORoySYyuoVaVpuIJKGDRhYrBhe ?? (mrORoySYyuoVaVpuIJKGDRhYrBhe = new UnityStopwatch(true));

		public static long frequency => 10000000L;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return UuFsBmvPkHtPrYHnkikJcYqhPzlSA;
			}
			set
			{
				UuFsBmvPkHtPrYHnkikJcYqhPzlSA = value;
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return (long)(UuFsBmvPkHtPrYHnkikJcYqhPzlSA * 10000000.0);
			}
			set
			{
				UuFsBmvPkHtPrYHnkikJcYqhPzlSA = (double)value / 10000000.0;
			}
		}

		double StopwatchBase.elapsedSeconds => AOgjBlqaBjddsxhgBbIeXmfeBeeR.uSoGslZYcaXbDXRuDZEATZfRmkAb + offsetSeconds;

		double StopwatchBase.elapsedSecondsRaw => AOgjBlqaBjddsxhgBbIeXmfeBeeR.uSoGslZYcaXbDXRuDZEATZfRmkAb;

		long StopwatchBase.elapsedMilliseconds => (long)((AOgjBlqaBjddsxhgBbIeXmfeBeeR.uSoGslZYcaXbDXRuDZEATZfRmkAb + UuFsBmvPkHtPrYHnkikJcYqhPzlSA) * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => (long)(AOgjBlqaBjddsxhgBbIeXmfeBeeR.uSoGslZYcaXbDXRuDZEATZfRmkAb * 1000.0);

		long StopwatchBase.elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		long StopwatchBase.elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		bool StopwatchBase.isRunning => AOgjBlqaBjddsxhgBbIeXmfeBeeR.YvuySoQxTGaiZhoLPgKlyQRzvKbL;

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
			AOgjBlqaBjddsxhgBbIeXmfeBeeR = new AXPlbETJTIapCSefDjAjUXJIqPrI();
			bPUeUDeAOUEWPCnJJnhesnjpKVyVA();
			if (P_0)
			{
				Start();
			}
			dVWhnUSGusbyIHpoUnOdapSEWQilb = P_0;
		}

		~UnityStopwatch()
		{
			YotuBPeqzebLZHTTzNEpxxiUqzCy();
		}

		public override void Stop()
		{
			if (dVWhnUSGusbyIHpoUnOdapSEWQilb)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			AOgjBlqaBjddsxhgBbIeXmfeBeeR.EEvNmNmBpggnMsootplVxvKPkaBp();
		}

		public override void Start()
		{
			if (!dVWhnUSGusbyIHpoUnOdapSEWQilb)
			{
				AOgjBlqaBjddsxhgBbIeXmfeBeeR.LPIcZUIZRapNoeHUVAidcxSktCCu();
			}
		}

		public override void Reset()
		{
			if (dVWhnUSGusbyIHpoUnOdapSEWQilb)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			AOgjBlqaBjddsxhgBbIeXmfeBeeR.vDgsSPRGlECPrmGLkFpzmOVmFfrg();
		}

		private void bPUeUDeAOUEWPCnJJnhesnjpKVyVA()
		{
			YotuBPeqzebLZHTTzNEpxxiUqzCy();
			ReInput.BeforeTimeManagerUpdateEvent += SGqgPuWBEdTEBcCGHqSrBNJqIAzeA;
		}

		private void YotuBPeqzebLZHTTzNEpxxiUqzCy()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= SGqgPuWBEdTEBcCGHqSrBNJqIAzeA;
		}

		private void SGqgPuWBEdTEBcCGHqSrBNJqIAzeA(UpdateLoopType P_0)
		{
			AOgjBlqaBjddsxhgBbIeXmfeBeeR.GMYURgpRPamjbPthiMwKIpZKbRyf();
		}
	}
}
