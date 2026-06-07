using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDVibrationMotor
	{
		private int SNnscCoqckixoPuRBSmdJqlNqzvP;

		private int ZlwaHJHYuDfrBCpiTBBFcrDKknOcA;

		private int ezfWxZyBbvSYmocvHYEFKMIRFBZk;

		[CompilerGenerated]
		private Action wOhUpxXdDessoyKTVojNhlBmBpjc;

		public float Speed
		{
			get
			{
				return gdjhBShDKTHyTWvtEubQoqlInaoEb(SNnscCoqckixoPuRBSmdJqlNqzvP);
			}
			set
			{
				SNnscCoqckixoPuRBSmdJqlNqzvP = cfYuHScXDpvRKPTPRPspUknTgsib(value);
				if (wOhUpxXdDessoyKTVojNhlBmBpjc != null)
				{
					wOhUpxXdDessoyKTVojNhlBmBpjc();
				}
			}
		}

		public int SpeedRaw
		{
			get
			{
				return SNnscCoqckixoPuRBSmdJqlNqzvP;
			}
			set
			{
				SNnscCoqckixoPuRBSmdJqlNqzvP = value;
				if (wOhUpxXdDessoyKTVojNhlBmBpjc != null)
				{
					wOhUpxXdDessoyKTVojNhlBmBpjc();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = wOhUpxXdDessoyKTVojNhlBmBpjc;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref wOhUpxXdDessoyKTVojNhlBmBpjc, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = wOhUpxXdDessoyKTVojNhlBmBpjc;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref wOhUpxXdDessoyKTVojNhlBmBpjc, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDVibrationMotor(int P_0, int P_1)
		{
			ZlwaHJHYuDfrBCpiTBBFcrDKknOcA = P_0;
			ezfWxZyBbvSYmocvHYEFKMIRFBZk = P_1;
		}

		private float gdjhBShDKTHyTWvtEubQoqlInaoEb(int P_0)
		{
			return MathTools.Clamp((float)P_0 / (float)ezfWxZyBbvSYmocvHYEFKMIRFBZk, 0f, 1f);
		}

		private int cfYuHScXDpvRKPTPRPspUknTgsib(float P_0)
		{
			return MathTools.Clamp((int)(P_0 * (float)ezfWxZyBbvSYmocvHYEFKMIRFBZk), ZlwaHJHYuDfrBCpiTBBFcrDKknOcA, ezfWxZyBbvSYmocvHYEFKMIRFBZk);
		}
	}
}
