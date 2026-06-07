using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDVibrationMotor
	{
		private int OvUBaMeanUalnffDqPXXPnmzSwbn;

		private int ZVeIHgUIsPuaDViIJtElYMOYQsZ;

		private int NbzmtPVYNkWlFatJFfCsgNeqoa;

		private Action twjymmIokCwhTlnPjZXgsCWpVVs;

		public float Speed
		{
			get
			{
				return gBjqnBBMirZxgNOPPTGJYDPNCrKE(OvUBaMeanUalnffDqPXXPnmzSwbn);
			}
			set
			{
				OvUBaMeanUalnffDqPXXPnmzSwbn = HQHRyqZBVkICmfmauZKhpdpCaui(value);
				if (twjymmIokCwhTlnPjZXgsCWpVVs != null)
				{
					twjymmIokCwhTlnPjZXgsCWpVVs();
				}
			}
		}

		public int SpeedRaw
		{
			get
			{
				return OvUBaMeanUalnffDqPXXPnmzSwbn;
			}
			set
			{
				OvUBaMeanUalnffDqPXXPnmzSwbn = value;
				if (twjymmIokCwhTlnPjZXgsCWpVVs != null)
				{
					twjymmIokCwhTlnPjZXgsCWpVVs();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = twjymmIokCwhTlnPjZXgsCWpVVs;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref twjymmIokCwhTlnPjZXgsCWpVVs, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = twjymmIokCwhTlnPjZXgsCWpVVs;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref twjymmIokCwhTlnPjZXgsCWpVVs, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDVibrationMotor(int minSpeedRaw, int maxSpeedRaw)
		{
			ZVeIHgUIsPuaDViIJtElYMOYQsZ = minSpeedRaw;
			NbzmtPVYNkWlFatJFfCsgNeqoa = maxSpeedRaw;
		}

		private float gBjqnBBMirZxgNOPPTGJYDPNCrKE(int P_0)
		{
			return MathTools.Clamp((float)P_0 / (float)NbzmtPVYNkWlFatJFfCsgNeqoa, 0f, 1f);
		}

		private int HQHRyqZBVkICmfmauZKhpdpCaui(float P_0)
		{
			return MathTools.Clamp((int)(P_0 * (float)NbzmtPVYNkWlFatJFfCsgNeqoa), ZVeIHgUIsPuaDViIJtElYMOYQsZ, NbzmtPVYNkWlFatJFfCsgNeqoa);
		}
	}
}
