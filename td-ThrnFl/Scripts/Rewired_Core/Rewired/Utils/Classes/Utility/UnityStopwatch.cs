using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class zhpuSQVIEzrcxXTwqNXnJExpDUhS
		{
			public const long ESrpRHryuiaFWyQxOHrmgJSseCPBA = 10000000L;

			private double VskIPrERWSPHGyFmhwEVGqdtmUEn;

			private bool HtDokFVDBnvpOoHtvPJuxyDvMZKt;

			private double xLjlDYryTVbhslYRpRcKiKZiRPGJ;

			private double dUeUYCXDAQoErIRvCdiEmAZBjBpf;

			public bool vEMfTyKqWpWqsgEGmYUrrYhYXtzl => HtDokFVDBnvpOoHtvPJuxyDvMZKt;

			public double PFafhwAFZReVIbYIeRbQlYzCKMuCc
			{
				get
				{
					if (!HtDokFVDBnvpOoHtvPJuxyDvMZKt)
					{
						return dUeUYCXDAQoErIRvCdiEmAZBjBpf;
					}
					return (double)Time.realtimeSinceStartup - xLjlDYryTVbhslYRpRcKiKZiRPGJ;
				}
			}

			public void fZaQtcxjYJfcAFCoVlaIkTltoFkfb()
			{
				VskIPrERWSPHGyFmhwEVGqdtmUEn = Time.realtimeSinceStartup;
			}

			public void uXiFeAKTYJffHdMBuEWrHlkLxsWY()
			{
				if (!HtDokFVDBnvpOoHtvPJuxyDvMZKt)
				{
					HtDokFVDBnvpOoHtvPJuxyDvMZKt = true;
					xLjlDYryTVbhslYRpRcKiKZiRPGJ = VskIPrERWSPHGyFmhwEVGqdtmUEn;
				}
			}

			public void zvNgyDcOsXDlhnunUSVDqUciMxHk()
			{
				if (HtDokFVDBnvpOoHtvPJuxyDvMZKt)
				{
					HtDokFVDBnvpOoHtvPJuxyDvMZKt = false;
					dUeUYCXDAQoErIRvCdiEmAZBjBpf += VskIPrERWSPHGyFmhwEVGqdtmUEn - xLjlDYryTVbhslYRpRcKiKZiRPGJ;
				}
			}

			public void KPYsTZRtgxOEOvnIPQpxxrqJInhv()
			{
				xLjlDYryTVbhslYRpRcKiKZiRPGJ = 0.0;
				dUeUYCXDAQoErIRvCdiEmAZBjBpf = 0.0;
				bool htDokFVDBnvpOoHtvPJuxyDvMZKt = HtDokFVDBnvpOoHtvPJuxyDvMZKt;
				HtDokFVDBnvpOoHtvPJuxyDvMZKt = false;
				if (htDokFVDBnvpOoHtvPJuxyDvMZKt)
				{
					uXiFeAKTYJffHdMBuEWrHlkLxsWY();
				}
			}
		}

		private const long qjbwWkCcxoHfaxCmTeltzGtJRqFG = 10000000L;

		private static UnityStopwatch JCcZasORXZSacSrifNvCWxrpkTrv;

		private readonly zhpuSQVIEzrcxXTwqNXnJExpDUhS pYYlGxmKSGcdDmwjmccofARPpQevA;

		private readonly bool IEkWIMKezXcXpggxnetleGwndosv;

		private double pyxoWcbblmFLIVxwDMbRZRASBerH;

		public static UnityStopwatch Global => JCcZasORXZSacSrifNvCWxrpkTrv ?? (JCcZasORXZSacSrifNvCWxrpkTrv = new UnityStopwatch(true));

		public static long frequency => 10000000L;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return pyxoWcbblmFLIVxwDMbRZRASBerH;
			}
			set
			{
				pyxoWcbblmFLIVxwDMbRZRASBerH = value;
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return (long)(pyxoWcbblmFLIVxwDMbRZRASBerH * 10000000.0);
			}
			set
			{
				pyxoWcbblmFLIVxwDMbRZRASBerH = (double)value / 10000000.0;
			}
		}

		double StopwatchBase.elapsedSeconds => pYYlGxmKSGcdDmwjmccofARPpQevA.PFafhwAFZReVIbYIeRbQlYzCKMuCc + offsetSeconds;

		double StopwatchBase.elapsedSecondsRaw => pYYlGxmKSGcdDmwjmccofARPpQevA.PFafhwAFZReVIbYIeRbQlYzCKMuCc;

		long StopwatchBase.elapsedMilliseconds => (long)((pYYlGxmKSGcdDmwjmccofARPpQevA.PFafhwAFZReVIbYIeRbQlYzCKMuCc + pyxoWcbblmFLIVxwDMbRZRASBerH) * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => (long)(pYYlGxmKSGcdDmwjmccofARPpQevA.PFafhwAFZReVIbYIeRbQlYzCKMuCc * 1000.0);

		long StopwatchBase.elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		long StopwatchBase.elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		bool StopwatchBase.isRunning => pYYlGxmKSGcdDmwjmccofARPpQevA.vEMfTyKqWpWqsgEGmYUrrYhYXtzl;

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
			pYYlGxmKSGcdDmwjmccofARPpQevA = new zhpuSQVIEzrcxXTwqNXnJExpDUhS();
			IjwdtZawVvqAooRYsKHoyFJMdpkEA();
			if (P_0)
			{
				Start();
			}
			IEkWIMKezXcXpggxnetleGwndosv = P_0;
		}

		~UnityStopwatch()
		{
			hfZeoXsgEFXgcWhUEkKfcJAzDhMj();
		}

		public override void Stop()
		{
			if (IEkWIMKezXcXpggxnetleGwndosv)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			pYYlGxmKSGcdDmwjmccofARPpQevA.zvNgyDcOsXDlhnunUSVDqUciMxHk();
		}

		public override void Start()
		{
			if (!IEkWIMKezXcXpggxnetleGwndosv)
			{
				pYYlGxmKSGcdDmwjmccofARPpQevA.uXiFeAKTYJffHdMBuEWrHlkLxsWY();
			}
		}

		public override void Reset()
		{
			if (IEkWIMKezXcXpggxnetleGwndosv)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			pYYlGxmKSGcdDmwjmccofARPpQevA.KPYsTZRtgxOEOvnIPQpxxrqJInhv();
		}

		private void IjwdtZawVvqAooRYsKHoyFJMdpkEA()
		{
			hfZeoXsgEFXgcWhUEkKfcJAzDhMj();
			ReInput.BeforeTimeManagerUpdateEvent += fAUEquUZHCkGypfJknwxEKdVLshx;
		}

		private void hfZeoXsgEFXgcWhUEkKfcJAzDhMj()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= fAUEquUZHCkGypfJknwxEKdVLshx;
		}

		private void fAUEquUZHCkGypfJknwxEKdVLshx(UpdateLoopType P_0)
		{
			pYYlGxmKSGcdDmwjmccofARPpQevA.fZaQtcxjYJfcAFCoVlaIkTltoFkfb();
		}
	}
}
