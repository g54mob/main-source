using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HIDVibrationMotor
	{
		private int KumEtAdvtMqKtdXObkDwPnTGLRRSA;

		private int LfdGaHQatfCQMQldlqwAXWjLJGwk;

		private int scaHBOrefRlajoutfhLAuiXGxvzc;

		[CompilerGenerated]
		private Action eVwZnbUUcKDktmCVjJhgPmPtpBBK;

		public float Speed
		{
			get
			{
				return oWosWECCRjXTQzJcuUONQcNPBCUz(KumEtAdvtMqKtdXObkDwPnTGLRRSA);
			}
			set
			{
				KumEtAdvtMqKtdXObkDwPnTGLRRSA = qlFnrPzWOTGtMJKOzgpfwjOcgKIQ(value);
				if (eVwZnbUUcKDktmCVjJhgPmPtpBBK != null)
				{
					eVwZnbUUcKDktmCVjJhgPmPtpBBK();
				}
			}
		}

		public int SpeedRaw
		{
			get
			{
				return KumEtAdvtMqKtdXObkDwPnTGLRRSA;
			}
			set
			{
				KumEtAdvtMqKtdXObkDwPnTGLRRSA = value;
				if (eVwZnbUUcKDktmCVjJhgPmPtpBBK != null)
				{
					eVwZnbUUcKDktmCVjJhgPmPtpBBK();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = eVwZnbUUcKDktmCVjJhgPmPtpBBK;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref eVwZnbUUcKDktmCVjJhgPmPtpBBK, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = eVwZnbUUcKDktmCVjJhgPmPtpBBK;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref eVwZnbUUcKDktmCVjJhgPmPtpBBK, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDVibrationMotor(int P_0, int P_1)
		{
			LfdGaHQatfCQMQldlqwAXWjLJGwk = P_0;
			scaHBOrefRlajoutfhLAuiXGxvzc = P_1;
		}

		private float oWosWECCRjXTQzJcuUONQcNPBCUz(int P_0)
		{
			return MathTools.Clamp((float)P_0 / (float)scaHBOrefRlajoutfhLAuiXGxvzc, 0f, 1f);
		}

		private int qlFnrPzWOTGtMJKOzgpfwjOcgKIQ(float P_0)
		{
			return MathTools.Clamp((int)(P_0 * (float)scaHBOrefRlajoutfhLAuiXGxvzc), LfdGaHQatfCQMQldlqwAXWjLJGwk, scaHBOrefRlajoutfhLAuiXGxvzc);
		}
	}
}
