using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDVibrationMotor
	{
		private int XXxjzOfBMxHhCgyuZqXALffAvYj;

		private int WWJBCuBqPyXgkUdtuPUsacNzfeVj;

		private int MkOawlMGosygIIGXoGPJIMUHvCwc;

		private Action ecKvzyNgFvgosguICrPvIgXKmra;

		public float Speed
		{
			get
			{
				return tcSmSHYpLCfbBMDgskYSwZCieRC(XXxjzOfBMxHhCgyuZqXALffAvYj);
			}
			set
			{
				XXxjzOfBMxHhCgyuZqXALffAvYj = GwwLAkUbeTcKXkcFHuZwNZmtGEkG(value);
				while (true)
				{
					int num = -1073404480;
					while (true)
					{
						switch (num ^ -1073404479)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							if (ecKvzyNgFvgosguICrPvIgXKmra != null)
							{
								goto IL_0033;
							}
							return;
						case 2:
							return;
						}
						break;
						IL_0033:
						ecKvzyNgFvgosguICrPvIgXKmra();
						num = -1073404477;
					}
				}
			}
		}

		public int SpeedRaw
		{
			get
			{
				return XXxjzOfBMxHhCgyuZqXALffAvYj;
			}
			set
			{
				XXxjzOfBMxHhCgyuZqXALffAvYj = value;
				if (ecKvzyNgFvgosguICrPvIgXKmra == null)
				{
					return;
				}
				while (true)
				{
					int num = -707628027;
					while (true)
					{
						switch (num ^ -707628025)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_002d;
						case 1:
							return;
						}
						break;
						IL_002d:
						ecKvzyNgFvgosguICrPvIgXKmra();
						num = -707628026;
					}
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = ecKvzyNgFvgosguICrPvIgXKmra;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref ecKvzyNgFvgosguICrPvIgXKmra, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = ecKvzyNgFvgosguICrPvIgXKmra;
				Action action2 = default(Action);
				while (true)
				{
					int num = 171546012;
					while (true)
					{
						switch (num ^ 0xA39959D)
						{
						case 0:
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
						Action value2 = (Action)Delegate.Remove(action2, value);
						action = Interlocked.CompareExchange(ref ecKvzyNgFvgosguICrPvIgXKmra, value2, action2);
						num = 171546015;
					}
				}
			}
		}

		public HIDVibrationMotor(int minSpeedRaw, int maxSpeedRaw)
		{
			WWJBCuBqPyXgkUdtuPUsacNzfeVj = minSpeedRaw;
			MkOawlMGosygIIGXoGPJIMUHvCwc = maxSpeedRaw;
		}

		private float tcSmSHYpLCfbBMDgskYSwZCieRC(int P_0)
		{
			return MathTools.Clamp((float)P_0 / (float)MkOawlMGosygIIGXoGPJIMUHvCwc, 0f, 1f);
		}

		private int GwwLAkUbeTcKXkcFHuZwNZmtGEkG(float P_0)
		{
			return MathTools.Clamp((int)(P_0 * (float)MkOawlMGosygIIGXoGPJIMUHvCwc), WWJBCuBqPyXgkUdtuPUsacNzfeVj, MkOawlMGosygIIGXoGPJIMUHvCwc);
		}
	}
}
