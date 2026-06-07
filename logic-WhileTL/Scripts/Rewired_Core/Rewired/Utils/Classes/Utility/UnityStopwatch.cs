using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class wDxpuCUqWBbEmCASVvvWFxekDddd
		{
			public const long nyTYbeywcrReHbgzOkSBYKVeAddq = 10000000L;

			private double VCTRHRwasBTNRnqoVFlJhhOfyGxvA;

			private bool QWrXDKvVVUfbZepgRxFscxCRguIx;

			private double NVJLtSvqwpWmxGuvMYWPFSaDWVYC;

			private double WtcCHpTVaeLRfcdFqloQZorQadtd;

			public bool UKDjqhpfJCieoZaEUDBKohpkaYzD => QWrXDKvVVUfbZepgRxFscxCRguIx;

			public double oRNKVIrpbBWsbkIMQFMzkMPOErleA
			{
				get
				{
					if (!QWrXDKvVVUfbZepgRxFscxCRguIx)
					{
						return WtcCHpTVaeLRfcdFqloQZorQadtd;
					}
					return (double)Time.realtimeSinceStartup - NVJLtSvqwpWmxGuvMYWPFSaDWVYC;
				}
			}

			public void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
				VCTRHRwasBTNRnqoVFlJhhOfyGxvA = Time.realtimeSinceStartup;
			}

			public void rIjUCmsjifmvcBNTbhJRFVmmqsqk()
			{
				if (!QWrXDKvVVUfbZepgRxFscxCRguIx)
				{
					QWrXDKvVVUfbZepgRxFscxCRguIx = true;
					NVJLtSvqwpWmxGuvMYWPFSaDWVYC = VCTRHRwasBTNRnqoVFlJhhOfyGxvA;
				}
			}

			public void cfGxOdtHWEPUlSbBpwyOclSNIGkO()
			{
				if (QWrXDKvVVUfbZepgRxFscxCRguIx)
				{
					QWrXDKvVVUfbZepgRxFscxCRguIx = false;
					WtcCHpTVaeLRfcdFqloQZorQadtd += VCTRHRwasBTNRnqoVFlJhhOfyGxvA - NVJLtSvqwpWmxGuvMYWPFSaDWVYC;
				}
			}

			public void ooNidbhWzBcZZJydutNALDEuSswc()
			{
				NVJLtSvqwpWmxGuvMYWPFSaDWVYC = 0.0;
				WtcCHpTVaeLRfcdFqloQZorQadtd = 0.0;
				bool qWrXDKvVVUfbZepgRxFscxCRguIx = QWrXDKvVVUfbZepgRxFscxCRguIx;
				QWrXDKvVVUfbZepgRxFscxCRguIx = false;
				if (qWrXDKvVVUfbZepgRxFscxCRguIx)
				{
					rIjUCmsjifmvcBNTbhJRFVmmqsqk();
				}
			}
		}

		private const long sXWCELFVPKpexniKoLCDGDbdEyxBb = 10000000L;

		private static UnityStopwatch zciGzgTBHLGPdtghAyvZQeDoolVE;

		private readonly wDxpuCUqWBbEmCASVvvWFxekDddd jUqrsDggbviCoWsphvjFZmkVJMcp;

		private readonly bool kChbDEIAVYKfDGmtUWMUKXkGusyJA;

		private double ZGbVHFwZZenqwiYixPWKifIZlOTP;

		public static UnityStopwatch Global => zciGzgTBHLGPdtghAyvZQeDoolVE ?? (zciGzgTBHLGPdtghAyvZQeDoolVE = new UnityStopwatch(true));

		public static long frequency => 10000000L;

		public override double offsetSeconds
		{
			get
			{
				return ZGbVHFwZZenqwiYixPWKifIZlOTP;
			}
			set
			{
				ZGbVHFwZZenqwiYixPWKifIZlOTP = value;
			}
		}

		public override long offsetTicks
		{
			get
			{
				return (long)(ZGbVHFwZZenqwiYixPWKifIZlOTP * 10000000.0);
			}
			set
			{
				ZGbVHFwZZenqwiYixPWKifIZlOTP = (double)value / 10000000.0;
			}
		}

		public override double elapsedSeconds => jUqrsDggbviCoWsphvjFZmkVJMcp.oRNKVIrpbBWsbkIMQFMzkMPOErleA + offsetSeconds;

		public override double elapsedSecondsRaw => jUqrsDggbviCoWsphvjFZmkVJMcp.oRNKVIrpbBWsbkIMQFMzkMPOErleA;

		public override long elapsedMilliseconds => (long)((jUqrsDggbviCoWsphvjFZmkVJMcp.oRNKVIrpbBWsbkIMQFMzkMPOErleA + ZGbVHFwZZenqwiYixPWKifIZlOTP) * 1000.0);

		public override long elapsedMillisecondsRaw => (long)(jUqrsDggbviCoWsphvjFZmkVJMcp.oRNKVIrpbBWsbkIMQFMzkMPOErleA * 1000.0);

		public override long elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		public override long elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		public override bool isRunning => jUqrsDggbviCoWsphvjFZmkVJMcp.UKDjqhpfJCieoZaEUDBKohpkaYzD;

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
			jUqrsDggbviCoWsphvjFZmkVJMcp = new wDxpuCUqWBbEmCASVvvWFxekDddd();
			AijFMcCAJBxLrUohxGYteiccqQYQA();
			if (P_0)
			{
				Start();
			}
			kChbDEIAVYKfDGmtUWMUKXkGusyJA = P_0;
		}

		~UnityStopwatch()
		{
			OlMxVtMUtQprQDLLaVsmnqBBeNYEA();
		}

		public override void Stop()
		{
			if (kChbDEIAVYKfDGmtUWMUKXkGusyJA)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			jUqrsDggbviCoWsphvjFZmkVJMcp.cfGxOdtHWEPUlSbBpwyOclSNIGkO();
		}

		public override void Start()
		{
			if (!kChbDEIAVYKfDGmtUWMUKXkGusyJA)
			{
				jUqrsDggbviCoWsphvjFZmkVJMcp.rIjUCmsjifmvcBNTbhJRFVmmqsqk();
			}
		}

		public override void Reset()
		{
			if (kChbDEIAVYKfDGmtUWMUKXkGusyJA)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			jUqrsDggbviCoWsphvjFZmkVJMcp.ooNidbhWzBcZZJydutNALDEuSswc();
		}

		private void AijFMcCAJBxLrUohxGYteiccqQYQA()
		{
			OlMxVtMUtQprQDLLaVsmnqBBeNYEA();
			ReInput.BeforeTimeManagerUpdateEvent += IghfPvNUXsucbZILFgzLRWwwGmUeA;
		}

		private void OlMxVtMUtQprQDLLaVsmnqBBeNYEA()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= IghfPvNUXsucbZILFgzLRWwwGmUeA;
		}

		private void IghfPvNUXsucbZILFgzLRWwwGmUeA(UpdateLoopType P_0)
		{
			jUqrsDggbviCoWsphvjFZmkVJMcp.sOLNzBCCbZmFXkMugfndpShqgrUP();
		}
	}
}
