using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDVibrationMotor
	{
		private int mTjAUVJLhdwgTHePOHaLDrDHbPI;

		private int pwTQfzvmwqyzxhIQxiffubpsaxg;

		private int zCUXnmuVYgzcTtmVhsmWIucANTN;

		private Action HCAUfwpghrvdiBrRQgkVOjJniFj;

		public float Speed
		{
			get
			{
				return QbGjJAgWaKHqAdcHlfbHgRsbFGj(mTjAUVJLhdwgTHePOHaLDrDHbPI);
			}
			set
			{
				mTjAUVJLhdwgTHePOHaLDrDHbPI = jsmtipyfRXDZQDHaISgbTNSwdHH(value);
				while (true)
				{
					int num = -377173211;
					while (true)
					{
						switch (num ^ -377173212)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (HCAUfwpghrvdiBrRQgkVOjJniFj != null)
							{
								goto IL_0033;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_0033:
						HCAUfwpghrvdiBrRQgkVOjJniFj();
						num = -377173212;
					}
				}
			}
		}

		public int SpeedRaw
		{
			get
			{
				return mTjAUVJLhdwgTHePOHaLDrDHbPI;
			}
			set
			{
				mTjAUVJLhdwgTHePOHaLDrDHbPI = value;
				if (HCAUfwpghrvdiBrRQgkVOjJniFj != null)
				{
					HCAUfwpghrvdiBrRQgkVOjJniFj();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = HCAUfwpghrvdiBrRQgkVOjJniFj;
				Action action2 = default(Action);
				while (true)
				{
					int num = 1406109842;
					while (true)
					{
						switch (num ^ 0x53CF8893)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						action2 = action;
						Action value2 = (Action)Delegate.Combine(action2, value);
						action = Interlocked.CompareExchange(ref HCAUfwpghrvdiBrRQgkVOjJniFj, value2, action2);
						num = 1406109843;
					}
				}
			}
			remove
			{
				Action action = HCAUfwpghrvdiBrRQgkVOjJniFj;
				Action value2 = default(Action);
				Action action2 = default(Action);
				while (true)
				{
					int num = -877530123;
					while (true)
					{
						switch (num ^ -877530121)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							action = Interlocked.CompareExchange(ref HCAUfwpghrvdiBrRQgkVOjJniFj, value2, action2);
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						action2 = action;
						value2 = (Action)Delegate.Remove(action2, value);
						num = -877530122;
					}
				}
			}
		}

		public HIDVibrationMotor(int minSpeedRaw, int maxSpeedRaw)
		{
			pwTQfzvmwqyzxhIQxiffubpsaxg = minSpeedRaw;
			zCUXnmuVYgzcTtmVhsmWIucANTN = maxSpeedRaw;
		}

		private float QbGjJAgWaKHqAdcHlfbHgRsbFGj(int P_0)
		{
			return MathTools.Clamp((float)P_0 / (float)zCUXnmuVYgzcTtmVhsmWIucANTN, 0f, 1f);
		}

		private int jsmtipyfRXDZQDHaISgbTNSwdHH(float P_0)
		{
			return MathTools.Clamp((int)(P_0 * (float)zCUXnmuVYgzcTtmVhsmWIucANTN), pwTQfzvmwqyzxhIQxiffubpsaxg, zCUXnmuVYgzcTtmVhsmWIucANTN);
		}
	}
}
