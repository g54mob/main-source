using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class QqDNbrtvxdexCPUVHPoxOfIczDwQ
		{
			public const long bAVZoeZkTkfSlKmIvOEekjfzwJAjA = 10000000L;

			private double ehAGmOAovSxItHaXKOtHBTWmbJJqA;

			private bool kbjbHmJtohwcrqqEMdwmDsgkyOJXb;

			private double UfFUyxFZPDoZLzfjWkQEhyczQCXD;

			private double GSEvBtjCuQehWGEelFAYfpaAeqaAb;

			public bool SokdkBdobxgxPIavXVdpfoULdMwRA => kbjbHmJtohwcrqqEMdwmDsgkyOJXb;

			public double utQKOHnCkHgWlfMzkTUUjFYJmHrDA
			{
				get
				{
					if (!kbjbHmJtohwcrqqEMdwmDsgkyOJXb)
					{
						return GSEvBtjCuQehWGEelFAYfpaAeqaAb;
					}
					return (double)Time.realtimeSinceStartup - UfFUyxFZPDoZLzfjWkQEhyczQCXD;
				}
			}

			public void EAKYMNNZbJCnhIsXkoXKUyUepMdn()
			{
				ehAGmOAovSxItHaXKOtHBTWmbJJqA = Time.realtimeSinceStartup;
			}

			public void FWKZDrudzNXuyfpmPJtjsxPMqnBs()
			{
				if (!kbjbHmJtohwcrqqEMdwmDsgkyOJXb)
				{
					kbjbHmJtohwcrqqEMdwmDsgkyOJXb = true;
					UfFUyxFZPDoZLzfjWkQEhyczQCXD = ehAGmOAovSxItHaXKOtHBTWmbJJqA;
				}
			}

			public void CXbGXqfOTTmySppIrnuLXrThNFOyA()
			{
				if (kbjbHmJtohwcrqqEMdwmDsgkyOJXb)
				{
					kbjbHmJtohwcrqqEMdwmDsgkyOJXb = false;
					GSEvBtjCuQehWGEelFAYfpaAeqaAb += ehAGmOAovSxItHaXKOtHBTWmbJJqA - UfFUyxFZPDoZLzfjWkQEhyczQCXD;
				}
			}

			public void dCspaeniDvSNjhNziUYtuHFOCgaO()
			{
				UfFUyxFZPDoZLzfjWkQEhyczQCXD = 0.0;
				GSEvBtjCuQehWGEelFAYfpaAeqaAb = 0.0;
				bool num = kbjbHmJtohwcrqqEMdwmDsgkyOJXb;
				kbjbHmJtohwcrqqEMdwmDsgkyOJXb = false;
				if (num)
				{
					FWKZDrudzNXuyfpmPJtjsxPMqnBs();
				}
			}
		}

		private const long RiNLGPoAJcAMZdKFwBCdyKUGIjAJ = 10000000L;

		private static UnityStopwatch yROqTVsCsRzzDIOBImEGXrCgNAqt;

		private readonly QqDNbrtvxdexCPUVHPoxOfIczDwQ YtaUjEADlOQuycHUHgTgcFcIkNtBA;

		private readonly bool jJItviiOBHxCtgIdYLglzBQepbfE;

		private double MTTPRZZEmkAIjVHHezTrIvFHWFsd;

		public static UnityStopwatch Global => yROqTVsCsRzzDIOBImEGXrCgNAqt ?? (yROqTVsCsRzzDIOBImEGXrCgNAqt = new UnityStopwatch(true));

		public static long frequency => 10000000L;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return MTTPRZZEmkAIjVHHezTrIvFHWFsd;
			}
			set
			{
				MTTPRZZEmkAIjVHHezTrIvFHWFsd = value;
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return (long)(MTTPRZZEmkAIjVHHezTrIvFHWFsd * 10000000.0);
			}
			set
			{
				MTTPRZZEmkAIjVHHezTrIvFHWFsd = (double)value / 10000000.0;
			}
		}

		double StopwatchBase.elapsedSeconds => YtaUjEADlOQuycHUHgTgcFcIkNtBA.utQKOHnCkHgWlfMzkTUUjFYJmHrDA + offsetSeconds;

		double StopwatchBase.elapsedSecondsRaw => YtaUjEADlOQuycHUHgTgcFcIkNtBA.utQKOHnCkHgWlfMzkTUUjFYJmHrDA;

		long StopwatchBase.elapsedMilliseconds => (long)((YtaUjEADlOQuycHUHgTgcFcIkNtBA.utQKOHnCkHgWlfMzkTUUjFYJmHrDA + MTTPRZZEmkAIjVHHezTrIvFHWFsd) * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => (long)(YtaUjEADlOQuycHUHgTgcFcIkNtBA.utQKOHnCkHgWlfMzkTUUjFYJmHrDA * 1000.0);

		long StopwatchBase.elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		long StopwatchBase.elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		bool StopwatchBase.isRunning => YtaUjEADlOQuycHUHgTgcFcIkNtBA.SokdkBdobxgxPIavXVdpfoULdMwRA;

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
			YtaUjEADlOQuycHUHgTgcFcIkNtBA = new QqDNbrtvxdexCPUVHPoxOfIczDwQ();
			zkQIcWIwydLDBivHZwdahiOVyEbf();
			if (P_0)
			{
				Start();
			}
			jJItviiOBHxCtgIdYLglzBQepbfE = P_0;
		}

		~UnityStopwatch()
		{
			IJpZauIYRFKvVKrddHoxflzaKcDL();
		}

		public override void Stop()
		{
			if (jJItviiOBHxCtgIdYLglzBQepbfE)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			YtaUjEADlOQuycHUHgTgcFcIkNtBA.CXbGXqfOTTmySppIrnuLXrThNFOyA();
		}

		public override void Start()
		{
			if (!jJItviiOBHxCtgIdYLglzBQepbfE)
			{
				YtaUjEADlOQuycHUHgTgcFcIkNtBA.FWKZDrudzNXuyfpmPJtjsxPMqnBs();
			}
		}

		public override void Reset()
		{
			if (jJItviiOBHxCtgIdYLglzBQepbfE)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			YtaUjEADlOQuycHUHgTgcFcIkNtBA.dCspaeniDvSNjhNziUYtuHFOCgaO();
		}

		private void zkQIcWIwydLDBivHZwdahiOVyEbf()
		{
			IJpZauIYRFKvVKrddHoxflzaKcDL();
			ReInput.BeforeTimeManagerUpdateEvent += AOmFXgmyKABNftwSHFzoVARQziUB;
		}

		private void IJpZauIYRFKvVKrddHoxflzaKcDL()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= AOmFXgmyKABNftwSHFzoVARQziUB;
		}

		private void AOmFXgmyKABNftwSHFzoVARQziUB(UpdateLoopType P_0)
		{
			YtaUjEADlOQuycHUHgTgcFcIkNtBA.EAKYMNNZbJCnhIsXkoXKUyUepMdn();
		}
	}
}
