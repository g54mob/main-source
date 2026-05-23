using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDVibrationMotor
	{
		private int mHbreZDiSbeUzIhrluBUklxESXs;

		private int tfBBWtpQBcHsNuFwWOYqFnRdvjO;

		private int pfEvfwuMyaPNzuxQKDnZtTCZZcd;

		private Action VLIacpadFzqLReAPgFHzRrPMtwzS;

		public float Speed
		{
			get
			{
				return AzKbfSaxXIEOooIfWSUEFeCcoWZ(mHbreZDiSbeUzIhrluBUklxESXs);
			}
			set
			{
				mHbreZDiSbeUzIhrluBUklxESXs = nhghHzwCyXezshUOxNDksoavSNbB(value);
				while (true)
				{
					int num = -403821097;
					while (true)
					{
						switch (num ^ -403821100)
						{
						case 0:
							break;
						default:
							return;
						case 3:
						{
							int num2;
							if (VLIacpadFzqLReAPgFHzRrPMtwzS == null)
							{
								num = -403821099;
								num2 = num;
							}
							else
							{
								num = -403821098;
								num2 = num;
							}
							continue;
						}
						case 2:
							VLIacpadFzqLReAPgFHzRrPMtwzS();
							num = -403821099;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		public int SpeedRaw
		{
			get
			{
				return mHbreZDiSbeUzIhrluBUklxESXs;
			}
			set
			{
				mHbreZDiSbeUzIhrluBUklxESXs = value;
				if (VLIacpadFzqLReAPgFHzRrPMtwzS == null)
				{
					return;
				}
				while (true)
				{
					int num = 1816184348;
					while (true)
					{
						switch (num ^ 0x6C40C61E)
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
						VLIacpadFzqLReAPgFHzRrPMtwzS();
						num = 1816184351;
					}
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = VLIacpadFzqLReAPgFHzRrPMtwzS;
				Action value2 = default(Action);
				Action action2 = default(Action);
				while (true)
				{
					int num = -815386385;
					while (true)
					{
						switch (num ^ -815386386)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
							action = Interlocked.CompareExchange(ref VLIacpadFzqLReAPgFHzRrPMtwzS, value2, action2);
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						action2 = action;
						value2 = (Action)Delegate.Combine(action2, value);
						num = -815386386;
					}
				}
			}
			remove
			{
				Action action = VLIacpadFzqLReAPgFHzRrPMtwzS;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref VLIacpadFzqLReAPgFHzRrPMtwzS, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDVibrationMotor(int minSpeedRaw, int maxSpeedRaw)
		{
			tfBBWtpQBcHsNuFwWOYqFnRdvjO = minSpeedRaw;
			pfEvfwuMyaPNzuxQKDnZtTCZZcd = maxSpeedRaw;
		}

		private float AzKbfSaxXIEOooIfWSUEFeCcoWZ(int P_0)
		{
			return MathTools.Clamp((float)P_0 / (float)pfEvfwuMyaPNzuxQKDnZtTCZZcd, 0f, 1f);
		}

		private int nhghHzwCyXezshUOxNDksoavSNbB(float P_0)
		{
			return MathTools.Clamp((int)(P_0 * (float)pfEvfwuMyaPNzuxQKDnZtTCZZcd), tfBBWtpQBcHsNuFwWOYqFnRdvjO, pfEvfwuMyaPNzuxQKDnZtTCZZcd);
		}
	}
}
