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
		private int KWulYyfEKaraCKKTPdUZLkmxFqhP;

		private int ZuObaWLOLnjVmmDWqBcdumEYUbLL;

		private int BvNyZBACgrMjUiyooUUCIjTuBciR;

		[CompilerGenerated]
		private Action xBPFWWBHHindayCrQlKoGKQGxZcTb;

		public float Speed
		{
			get
			{
				return uNPXtpAgJHekTelJcTVFycJJapCY(KWulYyfEKaraCKKTPdUZLkmxFqhP);
			}
			set
			{
				KWulYyfEKaraCKKTPdUZLkmxFqhP = TxdjvWYtgUTHHUByHJAlDEbUsyyt(value);
				if (xBPFWWBHHindayCrQlKoGKQGxZcTb != null)
				{
					xBPFWWBHHindayCrQlKoGKQGxZcTb();
				}
			}
		}

		public int SpeedRaw
		{
			get
			{
				return KWulYyfEKaraCKKTPdUZLkmxFqhP;
			}
			set
			{
				KWulYyfEKaraCKKTPdUZLkmxFqhP = value;
				if (xBPFWWBHHindayCrQlKoGKQGxZcTb != null)
				{
					xBPFWWBHHindayCrQlKoGKQGxZcTb();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = xBPFWWBHHindayCrQlKoGKQGxZcTb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref xBPFWWBHHindayCrQlKoGKQGxZcTb, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = xBPFWWBHHindayCrQlKoGKQGxZcTb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref xBPFWWBHHindayCrQlKoGKQGxZcTb, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDVibrationMotor(int P_0, int P_1)
		{
			ZuObaWLOLnjVmmDWqBcdumEYUbLL = P_0;
			BvNyZBACgrMjUiyooUUCIjTuBciR = P_1;
		}

		private float uNPXtpAgJHekTelJcTVFycJJapCY(int P_0)
		{
			return MathTools.Clamp((float)P_0 / (float)BvNyZBACgrMjUiyooUUCIjTuBciR, 0f, 1f);
		}

		private int TxdjvWYtgUTHHUByHJAlDEbUsyyt(float P_0)
		{
			return MathTools.Clamp((int)(P_0 * (float)BvNyZBACgrMjUiyooUUCIjTuBciR), ZuObaWLOLnjVmmDWqBcdumEYUbLL, BvNyZBACgrMjUiyooUUCIjTuBciR);
		}
	}
}
