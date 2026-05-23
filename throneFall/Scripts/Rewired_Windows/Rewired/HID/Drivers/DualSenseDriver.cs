using System;
using System.Diagnostics;
using System.Linq;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualSenseDriver : HIDDeviceDriver, IDriver_DualSense, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum yifYGAMrYZqglHKPuXnEstjdahtE
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum mLKrZVrWxAOnCJNRSSYCuFuIouCQ
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum EKbLOvlGDtpmPfBQywNxEoIeCBjG : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum hrJrpoRvibFHNCNtwywQsPaWAtyd : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum iMiHvpcwHuYPmZYZVpsAIeSylCqj : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum UhDOOsfzCZYaCzNfzMzdMEjZHHOA
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum PUOSoEElBAwGANWBEPETTUCAATet : byte
		{
			None = 0,
			CompatibleVibrationMode1 = 1,
			HapticsSelect = 2,
			RightTriggerEffect = 4,
			LeftTriggerEffect = 8,
			AudioVolume = 0x10,
			ToggleInternalSpeaker = 0x20,
			MicrophoneVolume = 0x40,
			ToggleInternalMicOrExternalSpeaker = 0x80
		}

		private enum idkoIqwlyalgAbwTKqKXOldqTwjf : byte
		{
			None = 0,
			MicrophoneLEDControl = 1,
			PowerSaveControl = 2,
			LightbarControl = 4,
			TurnOffLEDs = 8,
			PlayerIndicatorLEDControl = 0x10,
			Unknown1 = 0x20,
			ChangeOverallMotorEffectPower = 0x40,
			Unknown2 = 0x80
		}

		private enum PraUfWjlDcKUBIYNCDTtaYOBFTBM : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct mTuSQbMesCOHQDztiyjnRexwBKkl
		{
			private const string NkXgVyGFuXRFyohnioWArwvBgnys = "Value must be between 0 and 16.";

			public byte qlRnViZfjWEMehWTLPyeIBtMGuxL;

			public byte gnsdarRKgObLrZsMQYsyUBifBEjz
			{
				get
				{
					return (byte)(qlRnViZfjWEMehWTLPyeIBtMGuxL & 0xF);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					qlRnViZfjWEMehWTLPyeIBtMGuxL = (byte)((SLVcYdcTCKAapVudCLBPlBHJTcBn << 4) | (b & 0xF));
				}
			}

			public byte SLVcYdcTCKAapVudCLBPlBHJTcBn
			{
				get
				{
					return (byte)(qlRnViZfjWEMehWTLPyeIBtMGuxL >> 4);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					qlRnViZfjWEMehWTLPyeIBtMGuxL = (byte)((b << 4) | gnsdarRKgObLrZsMQYsyUBifBEjz);
				}
			}

			public mTuSQbMesCOHQDztiyjnRexwBKkl(byte P_0)
			{
				qlRnViZfjWEMehWTLPyeIBtMGuxL = P_0;
			}

			public mTuSQbMesCOHQDztiyjnRexwBKkl(byte P_0, byte P_1)
			{
				if (P_0 >= 16 || P_1 >= 16)
				{
					throw new ArithmeticException("Value must be between 0 and 16.");
				}
				qlRnViZfjWEMehWTLPyeIBtMGuxL = (byte)((P_1 << 4) | P_0);
			}
		}

		private static class RUUPGqHqjdRhrRWvDsOqLzgyVyai
		{
			public enum HrmRzCHsCxPVufXldnRjjQsMEahc : byte
			{
				Off = 5,
				Feedback = 33,
				Weapon = 37,
				Vibration = 38,
				Bow = 34,
				Galloping = 35,
				Machine = 39,
				Simple_Feedback = 1,
				Simple_Weapon = 2,
				Simple_Vibration = 6,
				Limited_Feedback = 17,
				Limited_Weapon = 18,
				DebugFC = 252,
				DebugFD = 253,
				DebugFE = 254
			}

			public static class LxijGqIBXuTNUoPdTFDZCpdREpcT
			{
				public static class tvtfNGWhYMiHOMAbNifHpSNzSylh
				{
					public static bool lSXCsUAvYEptjtttropCiIfioeEhc(byte[] P_0, int P_1)
					{
						return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
					}

					public static bool pnvbFMutQmIdkdTOxYryUFeiiHlv(byte[] P_0, int P_1, float P_2, float P_3)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						return pmTaWzEQHDEBUGrNuJPmKWDDIKztA(P_0, P_1, (byte)P_2, (byte)P_3);
					}

					public static bool wdgclvfWIebUJCTjbuEMwIEsNkrs(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						return pKscHEdyAdHUpBwXMubEWwUjVOTAA(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool ijMeGeyFdsbgYpyhslGNByISBsnF(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						P_4 = (float)Math.Round(P_4 * 255f);
						return RpFDmjgpiwJjiBDRSYvYkTMMVxzR(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool iRmFKLbXKYbqKfvDhBFiFuHeZbCTC(byte[] P_0, int P_1, float[] P_2)
					{
						if (P_2.Length != 10)
						{
							return false;
						}
						byte[] array = new byte[10];
						for (int i = 0; i < 10; i++)
						{
							array[i] = (byte)Math.Round(P_2[i] * 8f);
						}
						return lxsTtytkhTvhAOsKZbEEgGkDdpWR(P_0, P_1, array);
					}

					public static bool cZxIeIbfAXoTGJDLcPORanKDGbyE(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						P_5 = (float)Math.Round(P_5 * 8f);
						return dEUxQmxfVseNrWYYpJLAvAoSeenj(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4, (byte)P_5);
					}

					public static bool gNUhAehcYEfwTEhGMEPfyFSIekFF(byte[] P_0, int P_1, float[] P_2, float P_3)
					{
						if (P_2.Length != 10)
						{
							return false;
						}
						P_3 = (float)Math.Round(P_3 * 255f);
						byte[] array = new byte[10];
						for (int i = 0; i < 10; i++)
						{
							array[i] = (byte)Math.Round(P_2[i] * 8f);
						}
						return VtHCTwTQFizfejBELgPodCeeUENLA(P_0, P_1, (byte)P_3, array);
					}
				}

				[Serializable]
				private sealed class LMeLWWSGwOtXUnzUSuQIPfVodBNBA
				{
					public static readonly LMeLWWSGwOtXUnzUSuQIPfVodBNBA _003C_003E9 = new LMeLWWSGwOtXUnzUSuQIPfVodBNBA();

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool QkuoWNhrQRJCSyQdiobnEGxILRMj(byte P_0)
					{
						return P_0 > 0;
					}

					internal bool JZQmsYtLmeJqwgJdjWYPbiOKnPCM(byte P_0)
					{
						return P_0 > 0;
					}
				}

				public static bool BbNNJPWoZOEHLlJdesIVhgWuksYg(byte[] P_0, int P_1)
				{
					P_0[P_1] = 5;
					P_0[P_1 + 1] = 0;
					P_0[P_1 + 2] = 0;
					P_0[P_1 + 3] = 0;
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}

				public static bool pmTaWzEQHDEBUGrNuJPmKWDDIKztA(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					if (P_2 > 9)
					{
						return false;
					}
					if (P_3 > 8)
					{
						return false;
					}
					if (P_3 > 0)
					{
						byte b = (byte)((P_3 - 1) & 7);
						uint num = 0u;
						ushort num2 = 0;
						for (int i = P_2; i < 10; i++)
						{
							num |= (uint)(b << 3 * i);
							num2 |= (ushort)(1 << i);
						}
						P_0[P_1] = 33;
						P_0[P_1 + 1] = (byte)(num2 & 0xFF);
						P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num & 0xFF);
						P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
						P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool pKscHEdyAdHUpBwXMubEWwUjVOTAA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					if (P_2 > 7 || P_2 < 2)
					{
						return false;
					}
					if (P_3 > 8)
					{
						return false;
					}
					if (P_3 <= P_2)
					{
						return false;
					}
					if (P_4 > 8)
					{
						return false;
					}
					if (P_4 > 0)
					{
						ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
						P_0[P_1] = 37;
						P_0[P_1 + 1] = (byte)(num & 0xFF);
						P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(P_4 - 1);
						P_0[P_1 + 4] = 0;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool RpFDmjgpiwJjiBDRSYvYkTMMVxzR(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					if (P_2 > 9)
					{
						return false;
					}
					if (P_3 > 8)
					{
						return false;
					}
					if (P_3 > 0 && P_4 > 0)
					{
						byte b = (byte)((P_3 - 1) & 7);
						uint num = 0u;
						ushort num2 = 0;
						for (int i = P_2; i < 10; i++)
						{
							num |= (uint)(b << 3 * i);
							num2 |= (ushort)(1 << i);
						}
						P_0[P_1] = 38;
						P_0[P_1 + 1] = (byte)(num2 & 0xFF);
						P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num & 0xFF);
						P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
						P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = P_4;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool lxsTtytkhTvhAOsKZbEEgGkDdpWR(byte[] P_0, int P_1, byte[] P_2)
				{
					if (P_2.Length != 10)
					{
						return false;
					}
					if (P_2.Any(LMeLWWSGwOtXUnzUSuQIPfVodBNBA._003C_003E9.QkuoWNhrQRJCSyQdiobnEGxILRMj))
					{
						uint num = 0u;
						ushort num2 = 0;
						for (int i = 0; i < 10; i++)
						{
							if (P_2[i] > 0)
							{
								byte b = (byte)((P_2[i] - 1) & 7);
								num |= (uint)(b << 3 * i);
								num2 |= (ushort)(1 << i);
							}
						}
						P_0[P_1] = 33;
						P_0[P_1 + 1] = (byte)(num2 & 0xFF);
						P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num & 0xFF);
						P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
						P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool dEUxQmxfVseNrWYYpJLAvAoSeenj(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					if (P_2 > 8 || P_2 < 0)
					{
						return false;
					}
					if (P_3 > 9)
					{
						return false;
					}
					if (P_3 <= P_2)
					{
						return false;
					}
					if (P_4 > 8)
					{
						return false;
					}
					if (P_4 < 1)
					{
						return false;
					}
					if (P_5 > 8)
					{
						return false;
					}
					if (P_5 < 1)
					{
						return false;
					}
					byte[] array = new byte[10];
					float num = 1f * (float)(P_5 - P_4) / (float)(P_3 - P_2);
					for (int i = P_2; i < 10; i++)
					{
						if (i <= P_3)
						{
							array[i] = (byte)Math.Round((float)(int)P_4 + num * (float)(i - P_2));
						}
						else
						{
							array[i] = P_5;
						}
					}
					return lxsTtytkhTvhAOsKZbEEgGkDdpWR(P_0, P_1, array);
				}

				public static bool VtHCTwTQFizfejBELgPodCeeUENLA(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					if (P_3.Length != 10)
					{
						return false;
					}
					if (P_2 > 0 && P_3.Any(LMeLWWSGwOtXUnzUSuQIPfVodBNBA._003C_003E9.JZQmsYtLmeJqwgJdjWYPbiOKnPCM))
					{
						uint num = 0u;
						ushort num2 = 0;
						for (int i = 0; i < 10; i++)
						{
							if (P_3[i] > 0)
							{
								byte b = (byte)((P_3[i] - 1) & 7);
								num |= (uint)(b << 3 * i);
								num2 |= (ushort)(1 << i);
							}
						}
						P_0[P_1] = 38;
						P_0[P_1 + 1] = (byte)(num2 & 0xFF);
						P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num & 0xFF);
						P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
						P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = P_2;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool bNVSwhEDVSNBvIqvZGOVSHixPQoi(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					if (P_2 > 8)
					{
						return false;
					}
					if (P_3 > 8)
					{
						return false;
					}
					if (P_2 >= P_3)
					{
						return false;
					}
					if (P_4 > 8)
					{
						return false;
					}
					if (P_5 > 8)
					{
						return false;
					}
					if (P_3 > 0 && P_4 > 0 && P_5 > 0)
					{
						ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
						uint num2 = (uint)(((P_4 - 1) & 7) | (((P_5 - 1) & 7) << 3));
						P_0[P_1] = 34;
						P_0[P_1 + 1] = (byte)(num & 0xFF);
						P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num2 & 0xFF);
						P_0[P_1 + 4] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool NYexKKzKjZhfTVOQvOQXFpotQpUB(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
				{
					if (P_2 > 8)
					{
						return false;
					}
					if (P_3 > 9)
					{
						return false;
					}
					if (P_2 >= P_3)
					{
						return false;
					}
					if (P_5 > 7)
					{
						return false;
					}
					if (P_4 > 6)
					{
						return false;
					}
					if (P_4 >= P_5)
					{
						return false;
					}
					if (P_6 > 0)
					{
						ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
						uint num2 = (uint)((P_5 & 7) | ((P_4 & 7) << 3));
						P_0[P_1] = 35;
						P_0[P_1 + 1] = (byte)(num & 0xFF);
						P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num2 & 0xFF);
						P_0[P_1 + 4] = P_6;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool JNLfBXMPyTUnTgmCMcAOwJeIsqZN(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
				{
					if (P_2 > 8)
					{
						return false;
					}
					if (P_3 > 9)
					{
						return false;
					}
					if (P_3 <= P_2)
					{
						return false;
					}
					if (P_4 > 7)
					{
						return false;
					}
					if (P_5 > 7)
					{
						return false;
					}
					if (P_6 > 0)
					{
						ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
						uint num2 = (uint)((P_4 & 7) | ((P_5 & 7) << 3));
						P_0[P_1] = 39;
						P_0[P_1 + 1] = (byte)(num & 0xFF);
						P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num2 & 0xFF);
						P_0[P_1 + 4] = P_6;
						P_0[P_1 + 5] = P_7;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool KXJdmDuyRGgiuqwDjdUtYlOmIYKl(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					P_0[P_1] = 1;
					P_0[P_1 + 1] = P_2;
					P_0[P_1 + 2] = P_3;
					P_0[P_1 + 3] = 0;
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}

				public static bool EJzyfxWzCbhfwBInYNBlNvwrRxEM(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					P_0[P_1] = 2;
					P_0[P_1 + 1] = P_2;
					P_0[P_1 + 2] = P_3;
					P_0[P_1 + 3] = P_4;
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}

				public static bool MENYkjMTOIkeHVenyhBgjMPhnotBA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					if (P_4 > 0 && P_3 > 0)
					{
						P_0[P_1] = 6;
						P_0[P_1 + 1] = P_4;
						P_0[P_1 + 2] = P_3;
						P_0[P_1 + 3] = P_2;
						P_0[P_1 + 4] = 0;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool YnJAPtaYvfxMeOQMEpDdGdyHOpGiB(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					if (P_3 > 10)
					{
						return false;
					}
					if (P_3 > 0)
					{
						P_0[P_1] = 17;
						P_0[P_1 + 1] = P_2;
						P_0[P_1 + 2] = P_3;
						P_0[P_1 + 3] = 0;
						P_0[P_1 + 4] = 0;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}

				public static bool ORhYuSVCBxAMFJuiPiLDZNtAWElhA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					if (P_2 < 16)
					{
						return false;
					}
					if (P_3 < P_2 || P_2 + 100 < P_3)
					{
						return false;
					}
					if (P_4 > 10)
					{
						return false;
					}
					if (P_4 > 0)
					{
						P_0[P_1] = 18;
						P_0[P_1 + 1] = P_2;
						P_0[P_1 + 2] = P_3;
						P_0[P_1 + 3] = P_4;
						P_0[P_1 + 4] = 0;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return BbNNJPWoZOEHLlJdesIVhgWuksYg(P_0, P_1);
				}
			}
		}

		private const float dnayASVYDlHGgMUmeHbaPHFSbkQZ = 4f;

		private const int vruQjzQKBRxBqgesVXEukzVldOVE = 15;

		private const int RfqnLpaaNmgwuNxWxmPjaMoPiFViA = 2;

		private const int sysMRoKcZqgvmCoSNviWdfbDdmkZ = 0;

		private const int ncTUlxOyCKIGkJwwvhpMrEgRReFX = 1912;

		private const int hGmjDFgtwIhovYTBfqBNvuSfudET = 0;

		private const int SRjcyrRYvGpXLsZOKpVdsFCobdWM = 941;

		private const bool WPXfIygSSGDwpBwtChJZHXJgaeYcB = false;

		private const bool NCwFDRigsXZBCIjJcDmGKtYVThxi = true;

		private const float ijyqNEPhUZUPrSgYxCQEcNbISqej = 2.5f;

		private const int iDXOLlSiZoXCTHLqWJkwlzwUvXyd = 0;

		private const int fTUCOfkKdfkrPKxzXUxhBsMujoCzA = 0;

		private const int ceLKDGbZjMavNFJsgoNpTKCqXuhP = 1;

		private const int TcDLmUXyJHHNRkyPmnYjSciOVAbN = 0;

		private const int PMKsqutlkDSnefXivSsiZxrsNaoU = 0;

		private const int OeZEhKmYBFcZoZFBAEZzgvzKpkWS = 0;

		private const int ffOOlGNyfjesZqWtxMhRurWdMNcT = 1;

		private const int EMWsNKPkjbYcEMeTXaNhCEZwuzj = 49;

		private const int kzggeWSbPmNWsnIAcovtkVMdkJt = 0;

		private const int ZYQkrQoHeSUnhYJKRRlAveVLiSRs = 1;

		private const int mOMZRxWNGikajHSdTCTWNXmwWsgJ = 64;

		private const int qBpNUnnVjdCizLbbyqVVDqMmdHAg = 48;

		private const int YxezdSnAmSQGfAbxnzJhdaAILVlU = 78;

		private const int yzNoMbDIYVESiyhSSJbzCnptBYdfA = 5;

		private const int YCRaoHBuRUhpcitgapBFHzUOLbIEA = 41;

		private const byte ZcaChmEwufYHLZSpbsUNfarNfxDl = 1;

		private const byte rkHxQHVClJAflhzfwpNlpGGCfvid = 2;

		private const int nOvlMOucWeUeqcwOBfIQbCoVjBXEA = 1;

		private const int GXMWxjSdICICsiuzSRoeHOszaWACb = 2;

		private const int voFQGBKTJVbaXOScROfmHNIiRIUt = 3;

		private const int HPBSEPBLygsPgQMAaapImiRBQGjJ = 4;

		private const int UeIDZWHgNlvBAhaLuHMJVBsHloxsA = 5;

		private const int PdpjXbJbWnGaKMqMTulPutXUcxrq = 6;

		private const int mnSnMVtoOmCNInEaiGUNwSvdDABP = 8;

		private const int IiNAYJmJKbzOgWHNcBwyXAuGFPYF = 22;

		private const int qarLjvrfZjVxrYNIepQMHFslGWPL = 16;

		private const int pssWHJDcyPGkqsjbGwYAiUcwmtTf = 33;

		private const int QXfynLBtxIBRGajyJSqwgUWqESQg = 8;

		private const int sFMCAdcJGDoPjqAVKxNwTFKKzPWj = 9;

		private const int QSCMNKFwqRhpMGSGOVVapVXTbyxf = 10;

		private const int vDgCYoGtHqwYWTHTNQtIRWqphOpL = 28;

		private const int iXUyxpaLkHbWuSBjGFEfBsdZdqCHA = 53;

		private const int vqIEdSedOAyWgbsOuPSvksNmWTiS = 54;

		private const int oheLqDGiOORFkTbztDWBJSIDqAWl = 43;

		private const int tDriUggeJOIetlYrxMdvEIMKTzgd = 42;

		private const int ZhZnqBiqGgjIyabHcQtgzvUonSkZA = 48;

		private const bool MWcuCNciYGyQjmDdwXhetpUEFvJCA = true;

		private const int HypgZNivWfsOCMgFledPdwIgvHOAc = 60;

		private const int zyMSZjidZPVbZbCTJTuanrgqXstL = 60;

		private const int xSQYliOPSyeVonPuCehDjXEhjUCi = 3000000;

		private const float WLvaGjwyWXQZiHIEiOoDCNdCJQwU = 8192f;

		private const float sEQoBzdtBotywqjpJFacRTFtNAer = 0.0010652969f;

		private const float xdDhWvHoZskgHOsUJyHsTIjIxHBHA = 0.06103702f;

		private const bool yybScvDRiEbcBfBFDDASWnlgDGSz = true;

		private const bool TkBYIKloLQGGxHlACpVZJxfNyFzu = true;

		private const bool OAcChpWspZmCCLMfuSNmzBWEWikw = true;

		private const bool kmuPHzirvCpiSOJRtUARwFzCBqxK = true;

		private const float TiwTuqyMiGTjyjWfjFaeKGWZYBXx = 4096f;

		private const float DleEEvKQBmrEGZORHUsRuBcuWKiMA = 16384f;

		private const float UjxJMPuGFblfGIIGEjkvcTjSylOVA = 16777216f;

		private const float FDsDBICfcdIrEHjlwFZcyBGydCsA = 268435460f;

		private const float kSCAaUkASolumIFqTWQetOpQKuVfb = 0.01999998f;

		private const float gSIFzVMBIESObKQprnfXPIiOImlb = 8192f;

		private const float dNWpqyDovRCSBICPRJKrcYOAxEZSA = 0.98f;

		private const float WwoLKaDnadGQtNLnVSitKOCVdkHd = 45f;

		private const float CUpYCjcpPdcbkbnfXDKHdDGzbLduA = 20f;

		private const DualSenseVibrationMode FQdAaqgJsUnIGUFUWPwJtQeAJUUH = DualSenseVibrationMode.Compatible2;

		private readonly IHIDDevice WZEutGIEvbtGYEEgHaGUIxGiudJPA;

		private readonly HIDProperties sPzZOzlRiNrInmUivXkUTnOxBhch;

		private readonly bool UhwtcawJNpmtlPxrqkJQmbNwHTjI;

		private readonly int vRTkwBaunvejxEvUHXsJZIrtJTVW;

		private readonly int zgzkZxXSgxXGczdTFhrwNnmXINFy;

		private readonly bool aBtTWjEZUKcQQCAnaXXvUSYjgWsQ;

		private readonly byte fcqGDYGdnXjDLBpxgyWgeSNJILlYb;

		private readonly int ErrOqidIukzjRMRiheeLmzruJBUV;

		private readonly int FKPbSZyrsUUNNWUNtzVOmqfdRCkH;

		private readonly int ikldgNJrwRJKnhuSdDfSldprrFdR;

		private readonly int XQquIquNxncqgxqfjeKykQHJKaLMA;

		private readonly NativeBuffer rlmfaEExTWRKjuUcDjiBGURSAIxZ;

		private readonly NativeBuffer NlghswWgZeAxivNHXPjHfynViOjK;

		private dccInhMggZtLYGkWFjXacEyGQoUL omUciQKQrMjIIUQksXOMLVcHLJNhA;

		private int fmWGZFGFETKmWhpuFZIMKvIEAIDH;

		private bool zbFVmWSsoTOICwJnDQrOdieoVjuI;

		private bool dipodLxcYRsXNqAgiHmaIxhPugfqA;

		private double wZASBVXuVjqhSSMZTzVkpiIKvOpU;

		private int owOBPNFXQdnZifDEiQiArylcrWnjA;

		private UhDOOsfzCZYaCzNfzMzdMEjZHHOA sTCfvFQyhalscSrYgJsykbzmCwZS;

		private bool RSuAMkFVhJlBaUNUfOKcoXzaIofv;

		private Quaternion ijVPXpWTXDsgEivMlirccNzYhZxE = Quaternion.identity;

		private DualSenseMicrophoneLightMode sVwsSqqiiahajFYfGkkMeEkanXEg;

		private hrJrpoRvibFHNCNtwywQsPaWAtyd OniEcZCaocNViXHhSAwlizgFRuTSA;

		private DualSensePlayerLightFlags XhJVdHynYUcnkdCDsHHEVQxKqBkAb;

		private bool JIWhkuZoIYnrhNknRePqbZmLMoZL;

		private uint JeTKnvpKgRvzUqKwZucIcvsDqVSb;

		private float xyPuKgrXzkURHjbjicWQwixjAFfFA;

		private double xWhVKPtRyFsZxsRXQhTaiYlzCSkd;

		private float UHlBlHJEXfEUYUialzGIEJuyPbDWA;

		private readonly IDualSenseTriggerEffect[] VuRbvKAEgewffHupSyYKEdQnwdUlA = new IDualSenseTriggerEffect[2];

		private readonly byte[] aTYVFZTxgsCRUPLOQATbddjefcKw = new byte[10];

		private readonly byte[] qPLlkhMCTnFiJQjBibBqrCDXbJGK = new byte[11];

		private DualSenseTriggerEffectState[] YdMfOBBtNPjumdiURxqftIMBqCeEA = new DualSenseTriggerEffectState[2];

		private DualSenseVibrationMode QPlgbrxNrhczsRTMkuBJMEfffrwJ;

		private byte nLVVZOxnIpowyRJPbnfTpUnrqNWr;

		private bool ZpkQmZfPkSOFvVcaIfaHjqsBIQInA;

		private bool YEkNefOeFXZNTAnGxryunDYdHlwv;

		private bool ECWBdbFcWANJopKBHltfEUEJFIbA;

		private bool LSAUwfjbPveUODlhfNfZGTaZgHVA;

		private bool ZibAMvQTPqGsbhDBvOrqYCZNckrAA;

		private bool gjDYDdUSfMCbGVIBdJBMLtHEngHn;

		private bool udhRltlANZkVdXysPHFseATtvLhs;

		private bool EzoekjYqgjebXxCgZunBJkYfOerg;

		private bool HVJhSkseXJMqfLkfOjWQJQidlyFM;

		private byte UqRjTUXpvwgaGdgbHPLPiMHHbIME;

		private byte woQVJOofZDdQVhdLaFPQglAJLaglB;

		private Quaternion AcwIJcpCPXxxRsNYqEPruLqAodkR = Quaternion.identity;

		private Quaternion ikBCjqJvhEozwCGQSCQVKTAZamuib = Quaternion.identity;

		private bool yZgvWxgrzJmrBDQIoIqTdhtwmpBv;

		private int fskMypYnOyjPZFYxJBPKNQtuHmQN;

		private int[] PbhvelTsmrJpSzVkfjQrLCYxaarH = new int[2];

		private int[] yhSwupgoSRENVfAWFprEqMNUxcxE = new int[2];

		private static uint[] ahsGJNsAbzaRPJmvYQQXJyprPvieA = new uint[256]
		{
			3523407757u, 2768625435u, 1007455905u, 1259060791u, 3580832660u, 2724731650u, 996231864u, 1281784366u, 3705235391u, 2883475241u,
			852952723u, 1171273221u, 3686048678u, 2897449776u, 901431946u, 1119744540u, 3484811241u, 3098726271u, 565944005u, 1455205971u,
			3369614320u, 3219065702u, 651582172u, 1372678730u, 3245242331u, 3060352845u, 794826487u, 1483155041u, 3322131394u, 2969862996u,
			671994606u, 1594548856u, 3916222277u, 2657877971u, 123907689u, 1885708031u, 3993045852u, 2567322570u, 1010288u, 1997036262u,
			3887548279u, 2427484129u, 163128923u, 2126386893u, 3772416878u, 2547889144u, 248832578u, 2043925204u, 4108050209u, 2212294583u,
			450215437u, 1842515611u, 4088798008u, 2226203566u, 498629140u, 1790921346u, 4194326291u, 2366072709u, 336475711u, 1661535913u,
			4251816714u, 2322244508u, 325317158u, 1684325040u, 2766056989u, 3554254475u, 1255198513u, 1037565863u, 2746444292u, 3568589458u,
			1304234792u, 985283518u, 2852464175u, 3707901625u, 1141589763u, 856455061u, 2909332022u, 3664761504u, 1130791706u, 878818188u,
			3110715001u, 3463352047u, 1466425173u, 543223747u, 3187964512u, 3372436214u, 1342839628u, 655174618u, 3081909835u, 3233089245u,
			1505515367u, 784033777u, 2967466578u, 3352871620u, 1590793086u, 701932520u, 2679148245u, 3904355907u, 1908338681u, 112844655u,
			2564639436u, 4024072794u, 1993550816u, 30677878u, 2439710439u, 3865851505u, 2137352139u, 140662621u, 2517025534u, 3775001192u,
			2013832146u, 252678980u, 2181537457u, 4110462503u, 1812594589u, 453955339u, 2238339752u, 4067256894u, 1801730948u, 476252946u,
			2363233923u, 4225443349u, 1657960367u, 366298937u, 2343686810u, 4239843852u, 1707062198u, 314082080u, 1069182125u, 1220369467u,
			3518238081u, 2796764439u, 953657524u, 1339070498u, 3604597144u, 2715744526u, 828499103u, 1181144073u, 3748627891u, 2825434405u,
			906764422u, 1091244048u, 3624026538u, 2936369468u, 571309257u, 1426738271u, 3422756325u, 3137613171u, 627095760u, 1382516806u,
			3413039612u, 3161057642u, 752284923u, 1540473965u, 3268974039u, 3051332929u, 733688034u, 1555824756u, 3316994510u, 2998034776u,
			81022053u, 1943239923u, 3940166985u, 2648514015u, 62490748u, 1958656234u, 3988253008u, 2595281350u, 168805463u, 2097738945u,
			3825313147u, 2466682349u, 224526414u, 2053451992u, 3815530850u, 2490061300u, 425942017u, 1852075159u, 4151131437u, 2154433979u,
			504272920u, 1762240654u, 4026595636u, 2265434530u, 397988915u, 1623188645u, 4189500703u, 2393998729u, 282398762u, 1741824188u,
			4275794182u, 2312913296u, 1231433021u, 1046551979u, 2808630289u, 3496967303u, 1309403428u, 957143474u, 2684717064u, 3607279774u,
			1203610895u, 817534361u, 2847130659u, 3736401077u, 1087398166u, 936857984u, 2933784634u, 3654889644u, 1422998873u, 601230799u,
			3135200373u, 3453512931u, 1404893504u, 616286678u, 3182598252u, 3400902906u, 1510651243u, 755860989u, 3020215367u, 3271812305u,
			1567060338u, 710951396u, 3010007134u, 3295551688u, 1913130485u, 84884835u, 2617666777u, 3942734927u, 1969605100u, 40040826u,
			2607524032u, 3966539862u, 2094237127u, 198489425u, 2464015595u, 3856323709u, 2076066270u, 213479752u, 2511347954u, 3803648100u,
			1874795921u, 414723335u, 2175892669u, 4139142187u, 1758648712u, 534112542u, 2262612132u, 4057696306u, 1633981859u, 375629109u,
			2406151311u, 4167943193u, 1711886778u, 286155052u, 2282172566u, 4278190080u
		};

		private const uint SVqnfyoGemIeeJtnlhxtbPqyplmGb = 3940166985u;

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].IqUCAdAupfvNpXYQVecZbYudoQHV > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualSense.BatteryLevel => owOBPNFXQdnZifDEiQiArylcrWnjA;

		bool IDriver_DualSense.BatteryCharging => sTCfvFQyhalscSrYgJsykbzmCwZS == UhDOOsfzCZYaCzNfzMzdMEjZHHOA.Charging;

		DualSenseVibrationMode IDriver_DualSense.vibrationMode
		{
			get
			{
				return QPlgbrxNrhczsRTMkuBJMEfffrwJ;
			}
			set
			{
				QPlgbrxNrhczsRTMkuBJMEfffrwJ = value;
				NNtTdNRbqEdagDtgjepeCWVcGjjk();
			}
		}

		float IDriver_DualSense.LeftMotor
		{
			get
			{
				return vibrationMotors[0].VkXdVAiMyWDgMKEYwLoxttDNIods;
			}
			set
			{
				vibrationMotors[0].VkXdVAiMyWDgMKEYwLoxttDNIods = value;
			}
		}

		float IDriver_DualSense.RightMotor
		{
			get
			{
				return vibrationMotors[1].VkXdVAiMyWDgMKEYwLoxttDNIods;
			}
			set
			{
				vibrationMotors[1].VkXdVAiMyWDgMKEYwLoxttDNIods = value;
			}
		}

		float IDriver_DualSense.LightColorR
		{
			get
			{
				return lights[0].bFcLWhUVQYrhAtojtbBTOwUMnPuo;
			}
			set
			{
				lights[0].bFcLWhUVQYrhAtojtbBTOwUMnPuo = value;
			}
		}

		float IDriver_DualSense.LightColorG
		{
			get
			{
				return lights[0].cPTNHiJyYcdHppnnfDGHBtVeMsBm;
			}
			set
			{
				lights[0].cPTNHiJyYcdHppnnfDGHBtVeMsBm = value;
			}
		}

		float IDriver_DualSense.LightColorB
		{
			get
			{
				return lights[0].UWJkPgTZOsCYAYhmbdbUfaNJAMak;
			}
			set
			{
				lights[0].UWJkPgTZOsCYAYhmbdbUfaNJAMak = value;
			}
		}

		float IDriver_DualSense.LightFlashOnDuration
		{
			get
			{
				return (int)UqRjTUXpvwgaGdgbHPLPiMHHbIME;
			}
			set
			{
				UqRjTUXpvwgaGdgbHPLPiMHHbIME = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				MfEJcJhbmiJBNJfjpFNthIHTpBHfA();
				if (UqRjTUXpvwgaGdgbHPLPiMHHbIME == 0 && woQVJOofZDdQVhdLaFPQglAJLaglB == 0)
				{
					dipodLxcYRsXNqAgiHmaIxhPugfqA = true;
				}
			}
		}

		float IDriver_DualSense.LightFlashOffDuration
		{
			get
			{
				return (int)woQVJOofZDdQVhdLaFPQglAJLaglB;
			}
			set
			{
				woQVJOofZDdQVhdLaFPQglAJLaglB = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				MfEJcJhbmiJBNJfjpFNthIHTpBHfA();
				if (UqRjTUXpvwgaGdgbHPLPiMHHbIME == 0 && woQVJOofZDdQVhdLaFPQglAJLaglB == 0)
				{
					dipodLxcYRsXNqAgiHmaIxhPugfqA = true;
				}
			}
		}

		DualSenseMicrophoneLightMode IDriver_DualSense.microphoneLightMode
		{
			get
			{
				return sVwsSqqiiahajFYfGkkMeEkanXEg;
			}
			set
			{
				sVwsSqqiiahajFYfGkkMeEkanXEg = value;
				NNtTdNRbqEdagDtgjepeCWVcGjjk();
				LSAUwfjbPveUODlhfNfZGTaZgHVA = true;
			}
		}

		DualSenseOtherLightBrightness IDriver_DualSense.otherLightBrightness
		{
			get
			{
				return IJDWjltgqBVwvyNXinuptGclLTzW(OniEcZCaocNViXHhSAwlizgFRuTSA);
			}
			set
			{
				OniEcZCaocNViXHhSAwlizgFRuTSA = fKljvYrGWfamKcZyCBZLuzzvfbOz(value);
				NNtTdNRbqEdagDtgjepeCWVcGjjk();
				gjDYDdUSfMCbGVIBdJBMLtHEngHn = true;
			}
		}

		DualSensePlayerLightFlags IDriver_DualSense.playerLights
		{
			get
			{
				return XhJVdHynYUcnkdCDsHHEVQxKqBkAb;
			}
			set
			{
				XhJVdHynYUcnkdCDsHHEVQxKqBkAb = value;
				NNtTdNRbqEdagDtgjepeCWVcGjjk();
				ZibAMvQTPqGsbhDBvOrqYCZNckrAA = true;
			}
		}

		Vector3 IDriver_DualSense.AccelerometerValue => tgwaligakwMNGSNilHugEkjKnqaoB(accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm);

		Vector3 IDriver_DualSense.AccelerometerValueRaw => new Vector3(accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[0], accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[1], accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[2]);

		Vector3 IDriver_DualSense.GyroscopeValue => YFRCrsFbrgmDyUShpRGhIdJyCpxBA(gyroscopes[0].bRYYalqPvoZZKKsccsFDDVGzVieM);

		Vector3 IDriver_DualSense.GyroscopeValueRaw => new Vector3(gyroscopes[0].ZCKmYdzExBcrTEdbLYeNBVgDsXZH[0], gyroscopes[0].ZCKmYdzExBcrTEdbLYeNBVgDsXZH[1], gyroscopes[0].ZCKmYdzExBcrTEdbLYeNBVgDsXZH[2]);

		Vector3 IDriver_DualSense.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[0], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[1], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[2]);
				return nvAqYuvTOVjswMLEnOMtkJSkoTFW(vector, xyPuKgrXzkURHjbjicWQwixjAFfFA);
			}
		}

		Vector3 IDriver_DualSense.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[0], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[1], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[2]);

		Quaternion IDriver_DualSense.Orientation => ijVPXpWTXDsgEivMlirccNzYhZxE;

		int IDriver_DualSense.MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => sPzZOzlRiNrInmUivXkUTnOxBhch.vendorId;

		ushort IHIDControllerExtension.productId => sPzZOzlRiNrInmUivXkUTnOxBhch.productId;

		string IHIDControllerExtension.productName => sPzZOzlRiNrInmUivXkUTnOxBhch.productName;

		string IHIDControllerExtension.manufacturer => sPzZOzlRiNrInmUivXkUTnOxBhch.manufacturer;

		ushort IHIDControllerExtension.usagePage => sPzZOzlRiNrInmUivXkUTnOxBhch.usagePage;

		ushort IHIDControllerExtension.usage => sPzZOzlRiNrInmUivXkUTnOxBhch.usage;

		public void ResetOrientation()
		{
			ijVPXpWTXDsgEivMlirccNzYhZxE = Quaternion.identity;
			yZgvWxgrzJmrBDQIoIqTdhtwmpBv = false;
		}

		void IDriver_DualSense.ResetOrientation()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
			this.ResetOrientation();
		}

		public int GetTouchCount()
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB[i].isTouching)
				{
					num++;
				}
			}
			return num;
		}

		int IDriver_DualSense.GetTouchCount()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchCount
			return this.GetTouchCount();
		}

		public bool IsTouchingAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return false;
			}
			return touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB[index].isTouching;
		}

		bool IDriver_DualSense.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].KezhOiULMJFiOJiOOejHvhuyqIuIA(touchId);
		}

		bool IDriver_DualSense.IsTouchingAtTouchId(int touchId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtTouchId
			return this.IsTouchingAtTouchId(touchId);
		}

		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB[index].touchId;
		}

		int IDriver_DualSense.GetTouchIdAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchIdAtIndex
			return this.GetTouchIdAtIndex(index);
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			if (index < 0 || index >= 2)
			{
				return false;
			}
			SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] njrKDEoRljbTLZdbSWZHjMXESqOB = touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB;
			if (!njrKDEoRljbTLZdbSWZHjMXESqOB[index].isTouching)
			{
				return false;
			}
			position.x = njrKDEoRljbTLZdbSWZHjMXESqOB[index].positionX;
			position.y = njrKDEoRljbTLZdbSWZHjMXESqOB[index].positionY;
			return true;
		}

		bool IDriver_DualSense.GetTouchPositionByIndex(int index, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByIndex
			return this.GetTouchPositionByIndex(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			if (!touchpads[0].KezhOiULMJFiOJiOOejHvhuyqIuIA(touchId))
			{
				return false;
			}
			SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] njrKDEoRljbTLZdbSWZHjMXESqOB = touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB;
			for (int i = 0; i < njrKDEoRljbTLZdbSWZHjMXESqOB.Length; i++)
			{
				if (njrKDEoRljbTLZdbSWZHjMXESqOB[i].isTouching)
				{
					position.x = njrKDEoRljbTLZdbSWZHjMXESqOB[i].positionX;
					position.y = njrKDEoRljbTLZdbSWZHjMXESqOB[i].positionY;
				}
			}
			return true;
		}

		bool IDriver_DualSense.GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
			return this.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (index < 0 || index >= 2)
			{
				return false;
			}
			SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] njrKDEoRljbTLZdbSWZHjMXESqOB = touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB;
			if (!njrKDEoRljbTLZdbSWZHjMXESqOB[index].isTouching)
			{
				return false;
			}
			positionX = njrKDEoRljbTLZdbSWZHjMXESqOB[index].positionAbsX;
			positionY = njrKDEoRljbTLZdbSWZHjMXESqOB[index].positionAbsY;
			return true;
		}

		bool IDriver_DualSense.GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByIndex
			return this.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!touchpads[0].KezhOiULMJFiOJiOOejHvhuyqIuIA(touchId))
			{
				return false;
			}
			SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] njrKDEoRljbTLZdbSWZHjMXESqOB = touchpads[0].NjrKDEoRljbTLZdbSWZHjMXESqOB;
			for (int i = 0; i < njrKDEoRljbTLZdbSWZHjMXESqOB.Length; i++)
			{
				if (njrKDEoRljbTLZdbSWZHjMXESqOB[i].isTouching)
				{
					positionX = njrKDEoRljbTLZdbSWZHjMXESqOB[i].positionAbsX;
					positionY = njrKDEoRljbTLZdbSWZHjMXESqOB[i].positionAbsY;
				}
			}
			return true;
		}

		bool IDriver_DualSense.GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByTouchId
			return this.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
		}

		public void StopLightFlash()
		{
			UqRjTUXpvwgaGdgbHPLPiMHHbIME = 0;
			woQVJOofZDdQVhdLaFPQglAJLaglB = 0;
			NNtTdNRbqEdagDtgjepeCWVcGjjk();
			dipodLxcYRsXNqAgiHmaIxhPugfqA = true;
			udhRltlANZkVdXysPHFseATtvLhs = true;
		}

		void IDriver_DualSense.StopLightFlash()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopLightFlash
			this.StopLightFlash();
		}

		public void StopVibration()
		{
			int num = base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount;
			for (int i = 0; i < num; i++)
			{
				vibrationMotors[i].IqUCAdAupfvNpXYQVecZbYudoQHV = 0;
			}
		}

		void IDriver_DualSense.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			switch (trigger)
			{
			case DualSenseTriggerType.Left:
				VuRbvKAEgewffHupSyYKEdQnwdUlA[0] = effect;
				NNtTdNRbqEdagDtgjepeCWVcGjjk();
				YEkNefOeFXZNTAnGxryunDYdHlwv = true;
				return true;
			case DualSenseTriggerType.Right:
				VuRbvKAEgewffHupSyYKEdQnwdUlA[1] = effect;
				NNtTdNRbqEdagDtgjepeCWVcGjjk();
				ECWBdbFcWANJopKBHltfEUEJFIbA = true;
				return true;
			default:
				return false;
			}
		}

		bool IDriver_DualSense.SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetTriggerEffect
			return this.SetTriggerEffect(trigger, effect);
		}

		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			return new DualSenseTriggerEffectStates
			{
				leftTrigger = YdMfOBBtNPjumdiURxqftIMBqCeEA[0],
				rightTrigger = YdMfOBBtNPjumdiURxqftIMBqCeEA[1]
			};
		}

		DualSenseTriggerEffectStates IDriver_DualSense.GetTriggerEffectStates()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTriggerEffectStates
			return this.GetTriggerEffectStates();
		}

		public DualSenseDriver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			WZEutGIEvbtGYEEgHaGUIxGiudJPA = P_0.hidDevice;
			sPzZOzlRiNrInmUivXkUTnOxBhch = WZEutGIEvbtGYEEgHaGUIxGiudJPA.properties;
			vRTkwBaunvejxEvUHXsJZIrtJTVW = P_0.hatZeroValue;
			zgzkZxXSgxXGczdTFhrwNnmXINFy = P_0.hatSpan;
			UhwtcawJNpmtlPxrqkJQmbNwHTjI = P_0.connectionType == RXEzGxJeQkuaNxkYCJIkKyWznLNi.Bluetooth;
			if (UhwtcawJNpmtlPxrqkJQmbNwHTjI)
			{
				fmWGZFGFETKmWhpuFZIMKvIEAIDH = 78;
			}
			else
			{
				fmWGZFGFETKmWhpuFZIMKvIEAIDH = 48;
			}
			rlmfaEExTWRKjuUcDjiBGURSAIxZ = new NativeBuffer(64);
			NlghswWgZeAxivNHXPjHfynViOjK = new NativeBuffer(fmWGZFGFETKmWhpuFZIMKvIEAIDH);
			omUciQKQrMjIIUQksXOMLVcHLJNhA = new dccInhMggZtLYGkWFjXacEyGQoUL(NlghswWgZeAxivNHXPjHfynViOjK.Pointer, NlghswWgZeAxivNHXPjHfynViOjK.Length, fmWGZFGFETKmWhpuFZIMKvIEAIDH);
			lights = new iaSQTyJQfafVqZneFJUiRVRBDWdc[1]
			{
				new iaSQTyJQfafVqZneFJUiRVRBDWdc(11, 24, 28)
			};
			lights[0].TnMtrKGOeSsLjFPJAGfRQtnlOdlF += gMKfoGuzIvTahvmMomDZelQyEcwN;
			vibrationMotors = new pMGtGvfvhFCynWDpoUnlyTrPulZp[2]
			{
				new pMGtGvfvhFCynWDpoUnlyTrPulZp(0, 255),
				new pMGtGvfvhFCynWDpoUnlyTrPulZp(0, 255)
			};
			vibrationMotors[0].AvoxNtfnozFNrfrnTlHdoendJzWW += vBqAEEKHaasEnNmUYZnraKoofYGt;
			vibrationMotors[1].AvoxNtfnozFNrfrnTlHdoendJzWW += vBqAEEKHaasEnNmUYZnraKoofYGt;
			QPlgbrxNrhczsRTMkuBJMEfffrwJ = DualSenseVibrationMode.Compatible2;
			ZpkQmZfPkSOFvVcaIfaHjqsBIQInA = true;
			YEkNefOeFXZNTAnGxryunDYdHlwv = true;
			ECWBdbFcWANJopKBHltfEUEJFIbA = true;
			LSAUwfjbPveUODlhfNfZGTaZgHVA = true;
			ZibAMvQTPqGsbhDBvOrqYCZNckrAA = true;
			gjDYDdUSfMCbGVIBdJBMLtHEngHn = true;
			udhRltlANZkVdXysPHFseATtvLhs = true;
			EzoekjYqgjebXxCgZunBJkYfOerg = true;
			HVJhSkseXJMqfLkfOjWQJQidlyFM = true;
			nLVVZOxnIpowyRJPbnfTpUnrqNWr = 2;
			if (UhwtcawJNpmtlPxrqkJQmbNwHTjI)
			{
				byte[] hidFeatureData = WZEutGIEvbtGYEEgHaGUIxGiudJPA.GetHidFeatureData(5, 41, 1000, 3);
				aBtTWjEZUKcQQCAnaXXvUSYjgWsQ = hidFeatureData != null && hidFeatureData.Length != 0;
				if (aBtTWjEZUKcQQCAnaXXvUSYjgWsQ)
				{
					xkzlLTLApkJYCIQxzHQUXqTFtjUG(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous);
				}
			}
			else
			{
				aBtTWjEZUKcQQCAnaXXvUSYjgWsQ = true;
				aBtTWjEZUKcQQCAnaXXvUSYjgWsQ = xkzlLTLApkJYCIQxzHQUXqTFtjUG(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous);
			}
			if (!aBtTWjEZUKcQQCAnaXXvUSYjgWsQ)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			fcqGDYGdnXjDLBpxgyWgeSNJILlYb = 1;
			ErrOqidIukzjRMRiheeLmzruJBUV = 0;
			if (UhwtcawJNpmtlPxrqkJQmbNwHTjI && aBtTWjEZUKcQQCAnaXXvUSYjgWsQ)
			{
				fcqGDYGdnXjDLBpxgyWgeSNJILlYb = 49;
				ErrOqidIukzjRMRiheeLmzruJBUV = 1;
			}
			FKPbSZyrsUUNNWUNtzVOmqfdRCkH = 8 + ErrOqidIukzjRMRiheeLmzruJBUV;
			ikldgNJrwRJKnhuSdDfSldprrFdR = 9 + ErrOqidIukzjRMRiheeLmzruJBUV;
			XQquIquNxncqgxqfjeKykQHJKaLMA = 10 + ErrOqidIukzjRMRiheeLmzruJBUV;
			buttons = new YgmprUEDpDakYucBfpnWbXzouOGJ[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new YgmprUEDpDakYucBfpnWbXzouOGJ(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new nZeIQQWnQohhanyhWEOObGRunlRc[6]
			{
				new nZeIQQWnQohhanyhWEOObGRunlRc(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new nZeIQQWnQohhanyhWEOObGRunlRc(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new nZeIQQWnQohhanyhWEOObGRunlRc(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new nZeIQQWnQohhanyhWEOObGRunlRc(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new nZeIQQWnQohhanyhWEOObGRunlRc(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new nZeIQQWnQohhanyhWEOObGRunlRc(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new XXzPjtyGkCdrTJCzxAmvdoaeCgbHb[1]
			{
				new XXzPjtyGkCdrTJCzxAmvdoaeCgbHb(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, NNBsIsxaxBLpDCAhajqxdUFREqBvA)
			};
			accelerometers = new cMLqHjOwHUDOjQfvBFTMHfOrKnXJ[1]
			{
				new cMLqHjOwHUDOjQfvBFTMHfOrKnXJ(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 48
				}, 3, qpNEaipvYmAZXCvBPXNCaGZwGtXnA)
			};
			gyroscopes = new mtYfxDYuHHPxAtRRwphKvfBUCHvHA[1]
			{
				new mtYfxDYuHHPxAtRRwphKvfBUCHvHA(P_0.updateLoopSetting, fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 48
				}, 3, 60, gVAasjoRbiPInQIDGmOdXJgyjMPT, aSamAcAgoNOgbAsnzmIaKnLGkDJc)
			};
			touchpads = new SRlmwzCpkDCiOPGALkZGROsZKGfx[1]
			{
				new SRlmwzCpkDCiOPGALkZGROsZKGfx(fcqGDYGdnXjDLBpxgyWgeSNJILlYb, new SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + ErrOqidIukzjRMRiheeLmzruJBUV,
					bitSize = 48
				}, 60, wEjYkpFQzgdJHgabJQFxXdJSncdnA)
			};
			xWhVKPtRyFsZxsRXQhTaiYlzCSkd = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			hpgyqPEbUrzFDsaSfvhBUehIlznv();
			PEGYBjSOfENrDHkLefzrwoZdMWfp(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Asynchronous);
		}

		public unsafe override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < rlmfaEExTWRKjuUcDjiBGURSAIxZ.Length)
			{
				return false;
			}
			if (UhwtcawJNpmtlPxrqkJQmbNwHTjI && aBtTWjEZUKcQQCAnaXXvUSYjgWsQ && *(byte*)(void*)inputReportPtr == 1)
			{
				return false;
			}
			UHlBlHJEXfEUYUialzGIEJuyPbDWA = (float)(timestamp - xWhVKPtRyFsZxsRXQhTaiYlzCSkd);
			xWhVKPtRyFsZxsRXQhTaiYlzCSkd = timestamp;
			rlmfaEExTWRKjuUcDjiBGURSAIxZ.Write(inputReportPtr, inputReportLength, rlmfaEExTWRKjuUcDjiBGURSAIxZ.Length);
			ROBEAczxGVgXcGkLNbgYlgDRzITwA(rlmfaEExTWRKjuUcDjiBGURSAIxZ);
			flqfxbHALmmudiVQHflqfuUGdIGb(rlmfaEExTWRKjuUcDjiBGURSAIxZ, timestamp);
			QTwvMqRjxXBwLOoUpuezGnwheUbM[] array = axes;
			QFzWPkiZZoDuPmrmnqstQcFaSktl(array, rlmfaEExTWRKjuUcDjiBGURSAIxZ, timestamp);
			array = hats;
			QFzWPkiZZoDuPmrmnqstQcFaSktl(array, rlmfaEExTWRKjuUcDjiBGURSAIxZ, timestamp);
			array = accelerometers;
			QFzWPkiZZoDuPmrmnqstQcFaSktl(array, rlmfaEExTWRKjuUcDjiBGURSAIxZ, timestamp);
			array = gyroscopes;
			QFzWPkiZZoDuPmrmnqstQcFaSktl(array, rlmfaEExTWRKjuUcDjiBGURSAIxZ, timestamp);
			array = touchpads;
			QFzWPkiZZoDuPmrmnqstQcFaSktl(array, rlmfaEExTWRKjuUcDjiBGURSAIxZ, timestamp);
			byte b = rlmfaEExTWRKjuUcDjiBGURSAIxZ[53 + ErrOqidIukzjRMRiheeLmzruJBUV];
			iMiHvpcwHuYPmZYZVpsAIeSylCqj iMiHvpcwHuYPmZYZVpsAIeSylCqj2 = (iMiHvpcwHuYPmZYZVpsAIeSylCqj)((b & 0xF0) >> 4);
			if (iMiHvpcwHuYPmZYZVpsAIeSylCqj2 <= iMiHvpcwHuYPmZYZVpsAIeSylCqj.Full)
			{
				if (iMiHvpcwHuYPmZYZVpsAIeSylCqj2 > iMiHvpcwHuYPmZYZVpsAIeSylCqj.Charging)
				{
					if (iMiHvpcwHuYPmZYZVpsAIeSylCqj2 != iMiHvpcwHuYPmZYZVpsAIeSylCqj.Full)
					{
						goto IL_0171;
					}
					owOBPNFXQdnZifDEiQiArylcrWnjA = 100;
					sTCfvFQyhalscSrYgJsykbzmCwZS = UhDOOsfzCZYaCzNfzMzdMEjZHHOA.Full;
				}
				else
				{
					owOBPNFXQdnZifDEiQiArylcrWnjA = MathTools.Clamp((b & 0xF) * 10 + 5, 0, 100);
					sTCfvFQyhalscSrYgJsykbzmCwZS = ((iMiHvpcwHuYPmZYZVpsAIeSylCqj2 != iMiHvpcwHuYPmZYZVpsAIeSylCqj.Charging) ? UhDOOsfzCZYaCzNfzMzdMEjZHHOA.Discharging : UhDOOsfzCZYaCzNfzMzdMEjZHHOA.Charging);
				}
			}
			else
			{
				if (iMiHvpcwHuYPmZYZVpsAIeSylCqj2 - 10 > iMiHvpcwHuYPmZYZVpsAIeSylCqj.Charging)
				{
					if (iMiHvpcwHuYPmZYZVpsAIeSylCqj2 == iMiHvpcwHuYPmZYZVpsAIeSylCqj.ChargingError)
					{
					}
					goto IL_0171;
				}
				owOBPNFXQdnZifDEiQiArylcrWnjA = 0;
				sTCfvFQyhalscSrYgJsykbzmCwZS = UhDOOsfzCZYaCzNfzMzdMEjZHHOA.Charging;
			}
			goto IL_017f;
			IL_0171:
			owOBPNFXQdnZifDEiQiArylcrWnjA = 0;
			sTCfvFQyhalscSrYgJsykbzmCwZS = UhDOOsfzCZYaCzNfzMzdMEjZHHOA.Unknown;
			goto IL_017f;
			IL_017f:
			RSuAMkFVhJlBaUNUfOKcoXzaIofv = (rlmfaEExTWRKjuUcDjiBGURSAIxZ[54 + ErrOqidIukzjRMRiheeLmzruJBUV] & 1) != 0;
			YdMfOBBtNPjumdiURxqftIMBqCeEA[0] = gWDdgfzSJGOQULTplMmWBbVDEiJY(DualSenseTriggerType.Left, rlmfaEExTWRKjuUcDjiBGURSAIxZ[43 + ErrOqidIukzjRMRiheeLmzruJBUV], rlmfaEExTWRKjuUcDjiBGURSAIxZ[48 + ErrOqidIukzjRMRiheeLmzruJBUV]);
			YdMfOBBtNPjumdiURxqftIMBqCeEA[1] = gWDdgfzSJGOQULTplMmWBbVDEiJY(DualSenseTriggerType.Right, rlmfaEExTWRKjuUcDjiBGURSAIxZ[42 + ErrOqidIukzjRMRiheeLmzruJBUV], rlmfaEExTWRKjuUcDjiBGURSAIxZ[48 + ErrOqidIukzjRMRiheeLmzruJBUV]);
			ILKQCXkkgcjKkXYSCEfCJRwacntDA();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void PEGYBjSOfENrDHkLefzrwoZdMWfp(ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_0)
		{
			if (zbFVmWSsoTOICwJnDQrOdieoVjuI)
			{
				xkzlLTLApkJYCIQxzHQUXqTFtjUG(P_0);
				zbFVmWSsoTOICwJnDQrOdieoVjuI = false;
			}
		}

		private bool xkzlLTLApkJYCIQxzHQUXqTFtjUG(ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_0)
		{
			CJiBgVgVPjYPdSClYgcqJLenAsObA();
			bool result = IQlheUgQwnGbifCftwvqNhquHMdl(P_0);
			if (dipodLxcYRsXNqAgiHmaIxhPugfqA)
			{
				result = IQlheUgQwnGbifCftwvqNhquHMdl(P_0);
				dipodLxcYRsXNqAgiHmaIxhPugfqA = false;
			}
			return result;
		}

		private void CJiBgVgVPjYPdSClYgcqJLenAsObA()
		{
			if (UhwtcawJNpmtlPxrqkJQmbNwHTjI && aBtTWjEZUKcQQCAnaXXvUSYjgWsQ)
			{
				NlghswWgZeAxivNHXPjHfynViOjK[0] = 49;
				NlghswWgZeAxivNHXPjHfynViOjK[1] = 2;
				hTzWTFHkGvjZgPqbcAZZbGxkfcjhb(NlghswWgZeAxivNHXPjHfynViOjK, 2);
				uint num = XwJHjNJApYuMzSnvidAVKBDEwBPJA(NlghswWgZeAxivNHXPjHfynViOjK, 74);
				NlghswWgZeAxivNHXPjHfynViOjK[74] = (byte)(num & 0xFF);
				NlghswWgZeAxivNHXPjHfynViOjK[75] = (byte)((num & 0xFF00) >> 8);
				NlghswWgZeAxivNHXPjHfynViOjK[76] = (byte)((num & 0xFF0000) >> 16);
				NlghswWgZeAxivNHXPjHfynViOjK[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				NlghswWgZeAxivNHXPjHfynViOjK[0] = 2;
				hTzWTFHkGvjZgPqbcAZZbGxkfcjhb(NlghswWgZeAxivNHXPjHfynViOjK, 1);
			}
		}

		private void hTzWTFHkGvjZgPqbcAZZbGxkfcjhb(NativeBuffer P_0, int P_1)
		{
			PUOSoEElBAwGANWBEPETTUCAATet pUOSoEElBAwGANWBEPETTUCAATet = PUOSoEElBAwGANWBEPETTUCAATet.None;
			idkoIqwlyalgAbwTKqKXOldqTwjf idkoIqwlyalgAbwTKqKXOldqTwjf2 = idkoIqwlyalgAbwTKqKXOldqTwjf.None;
			pUOSoEElBAwGANWBEPETTUCAATet |= PUOSoEElBAwGANWBEPETTUCAATet.HapticsSelect;
			if (QPlgbrxNrhczsRTMkuBJMEfffrwJ == DualSenseVibrationMode.Compatible)
			{
				pUOSoEElBAwGANWBEPETTUCAATet |= PUOSoEElBAwGANWBEPETTUCAATet.CompatibleVibrationMode1;
			}
			ZpkQmZfPkSOFvVcaIfaHjqsBIQInA = false;
			pUOSoEElBAwGANWBEPETTUCAATet |= PUOSoEElBAwGANWBEPETTUCAATet.LeftTriggerEffect;
			YEkNefOeFXZNTAnGxryunDYdHlwv = false;
			pUOSoEElBAwGANWBEPETTUCAATet |= PUOSoEElBAwGANWBEPETTUCAATet.RightTriggerEffect;
			ECWBdbFcWANJopKBHltfEUEJFIbA = false;
			idkoIqwlyalgAbwTKqKXOldqTwjf2 |= idkoIqwlyalgAbwTKqKXOldqTwjf.MicrophoneLEDControl;
			LSAUwfjbPveUODlhfNfZGTaZgHVA = false;
			idkoIqwlyalgAbwTKqKXOldqTwjf2 |= idkoIqwlyalgAbwTKqKXOldqTwjf.PlayerIndicatorLEDControl;
			ZibAMvQTPqGsbhDBvOrqYCZNckrAA = false;
			idkoIqwlyalgAbwTKqKXOldqTwjf2 |= idkoIqwlyalgAbwTKqKXOldqTwjf.LightbarControl;
			udhRltlANZkVdXysPHFseATtvLhs = false;
			idkoIqwlyalgAbwTKqKXOldqTwjf2 |= idkoIqwlyalgAbwTKqKXOldqTwjf.ChangeOverallMotorEffectPower;
			HVJhSkseXJMqfLkfOjWQJQidlyFM = false;
			P_0[P_1] = (byte)pUOSoEElBAwGANWBEPETTUCAATet;
			P_0[1 + P_1] = (byte)idkoIqwlyalgAbwTKqKXOldqTwjf2;
			P_0[2 + P_1] = (byte)vibrationMotors[1].IqUCAdAupfvNpXYQVecZbYudoQHV;
			P_0[3 + P_1] = (byte)vibrationMotors[0].IqUCAdAupfvNpXYQVecZbYudoQHV;
			P_0[8 + P_1] = (byte)sVwsSqqiiahajFYfGkkMeEkanXEg;
			PraUfWjlDcKUBIYNCDTtaYOBFTBM praUfWjlDcKUBIYNCDTtaYOBFTBM = PraUfWjlDcKUBIYNCDTtaYOBFTBM.None;
			praUfWjlDcKUBIYNCDTtaYOBFTBM |= PraUfWjlDcKUBIYNCDTtaYOBFTBM.OtherLightBrightnessControl;
			gjDYDdUSfMCbGVIBdJBMLtHEngHn = false;
			if (QPlgbrxNrhczsRTMkuBJMEfffrwJ == DualSenseVibrationMode.Compatible2)
			{
				praUfWjlDcKUBIYNCDTtaYOBFTBM |= PraUfWjlDcKUBIYNCDTtaYOBFTBM.CompatibleVibrationMode2;
			}
			praUfWjlDcKUBIYNCDTtaYOBFTBM |= PraUfWjlDcKUBIYNCDTtaYOBFTBM.LightbarSetupControl;
			EzoekjYqgjebXxCgZunBJkYfOerg = false;
			P_0[38 + P_1] = (byte)praUfWjlDcKUBIYNCDTtaYOBFTBM;
			P_0[41 + P_1] = nLVVZOxnIpowyRJPbnfTpUnrqNWr;
			P_0[42 + P_1] = (byte)OniEcZCaocNViXHhSAwlizgFRuTSA;
			P_0[43 + P_1] = (byte)XhJVdHynYUcnkdCDsHHEVQxKqBkAb;
			if (JIWhkuZoIYnrhNknRePqbZmLMoZL)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[44 + P_1] = lights[0].iPItKgFTHBtGuRUztlDNfIvkSBLr;
			P_0[45 + P_1] = lights[0].oEsbyWGtXRtvGKQJpHjyopbJnsxS;
			P_0[46 + P_1] = lights[0].SMEmhyfAzxVApXucSoIcGVvjYfNI;
			RtcelFBHFweWXIzTTwzPRgvtkUjoA(ref VuRbvKAEgewffHupSyYKEdQnwdUlA[1], P_0, 10 + P_1);
			RtcelFBHFweWXIzTTwzPRgvtkUjoA(ref VuRbvKAEgewffHupSyYKEdQnwdUlA[0], P_0, 21 + P_1);
			P_0[36 + P_1] = 0;
		}

		private void RtcelFBHFweWXIzTTwzPRgvtkUjoA(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
			if (P_0 == null)
			{
				P_1[P_2] = 0;
				return;
			}
			switch (P_0.triggerEffectType)
			{
			case DualSenseTriggerEffectType.Off:
				RUUPGqHqjdRhrRWvDsOqLzgyVyai.LxijGqIBXuTNUoPdTFDZCpdREpcT.BbNNJPWoZOEHLlJdesIVhgWuksYg(qPLlkhMCTnFiJQjBibBqrCDXbJGK, 0);
				break;
			case DualSenseTriggerEffectType.Feedback:
			{
				DualSenseTriggerEffectFeedback dualSenseTriggerEffectFeedback = (DualSenseTriggerEffectFeedback)(object)P_0;
				RUUPGqHqjdRhrRWvDsOqLzgyVyai.LxijGqIBXuTNUoPdTFDZCpdREpcT.pmTaWzEQHDEBUGrNuJPmKWDDIKztA(qPLlkhMCTnFiJQjBibBqrCDXbJGK, 0, dualSenseTriggerEffectFeedback.position, dualSenseTriggerEffectFeedback.strength);
				break;
			}
			case DualSenseTriggerEffectType.Weapon:
			{
				DualSenseTriggerEffectWeapon dualSenseTriggerEffectWeapon = (DualSenseTriggerEffectWeapon)(object)P_0;
				RUUPGqHqjdRhrRWvDsOqLzgyVyai.LxijGqIBXuTNUoPdTFDZCpdREpcT.pKscHEdyAdHUpBwXMubEWwUjVOTAA(qPLlkhMCTnFiJQjBibBqrCDXbJGK, 0, dualSenseTriggerEffectWeapon.startPosition, dualSenseTriggerEffectWeapon.endPosition, dualSenseTriggerEffectWeapon.strength);
				break;
			}
			case DualSenseTriggerEffectType.Vibration:
			{
				DualSenseTriggerEffectVibration dualSenseTriggerEffectVibration = (DualSenseTriggerEffectVibration)(object)P_0;
				RUUPGqHqjdRhrRWvDsOqLzgyVyai.LxijGqIBXuTNUoPdTFDZCpdREpcT.RpFDmjgpiwJjiBDRSYvYkTMMVxzR(qPLlkhMCTnFiJQjBibBqrCDXbJGK, 0, dualSenseTriggerEffectVibration.position, dualSenseTriggerEffectVibration.amplitude, dualSenseTriggerEffectVibration.frequency);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionFeedback:
				((DualSenseTriggerEffectMultiplePositionFeedback)(object)P_0).strength.CopyTo(aTYVFZTxgsCRUPLOQATbddjefcKw);
				RUUPGqHqjdRhrRWvDsOqLzgyVyai.LxijGqIBXuTNUoPdTFDZCpdREpcT.lxsTtytkhTvhAOsKZbEEgGkDdpWR(qPLlkhMCTnFiJQjBibBqrCDXbJGK, 0, aTYVFZTxgsCRUPLOQATbddjefcKw);
				break;
			case DualSenseTriggerEffectType.SlopeFeedback:
			{
				DualSenseTriggerEffectSlopeFeedback dualSenseTriggerEffectSlopeFeedback = (DualSenseTriggerEffectSlopeFeedback)(object)P_0;
				RUUPGqHqjdRhrRWvDsOqLzgyVyai.LxijGqIBXuTNUoPdTFDZCpdREpcT.dEUxQmxfVseNrWYYpJLAvAoSeenj(qPLlkhMCTnFiJQjBibBqrCDXbJGK, 0, dualSenseTriggerEffectSlopeFeedback.startPosition, dualSenseTriggerEffectSlopeFeedback.endPosition, dualSenseTriggerEffectSlopeFeedback.startStrength, dualSenseTriggerEffectSlopeFeedback.endStrength);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionVibration:
			{
				DualSenseTriggerEffectMultiplePositionVibration dualSenseTriggerEffectMultiplePositionVibration = (DualSenseTriggerEffectMultiplePositionVibration)(object)P_0;
				dualSenseTriggerEffectMultiplePositionVibration.amplitude.CopyTo(aTYVFZTxgsCRUPLOQATbddjefcKw);
				RUUPGqHqjdRhrRWvDsOqLzgyVyai.LxijGqIBXuTNUoPdTFDZCpdREpcT.VtHCTwTQFizfejBELgPodCeeUENLA(qPLlkhMCTnFiJQjBibBqrCDXbJGK, 0, dualSenseTriggerEffectMultiplePositionVibration.frequency, aTYVFZTxgsCRUPLOQATbddjefcKw);
				break;
			}
			default:
				Logger.LogWarning("Unknown trigger effect type: 0x" + ((byte)P_0.triggerEffectType).ToString("x2"));
				return;
			}
			P_1.Write(qPLlkhMCTnFiJQjBibBqrCDXbJGK, qPLlkhMCTnFiJQjBibBqrCDXbJGK.Length, P_2);
		}

		private bool IQlheUgQwnGbifCftwvqNhquHMdl(ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_0)
		{
			wZASBVXuVjqhSSMZTzVkpiIKvOpU = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous:
				return WZEutGIEvbtGYEEgHaGUIxGiudJPA.WriteSync(omUciQKQrMjIIUQksXOMLVcHLJNhA, 0);
			case ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Asynchronous:
				WZEutGIEvbtGYEEgHaGUIxGiudJPA.WriteAsync(omUciQKQrMjIIUQksXOMLVcHLJNhA, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void flqfxbHALmmudiVQHflqfuUGdIGb(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[FKPbSZyrsUUNNWUNtzVOmqfdRCkH];
			buttons[0].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x10) != 0, P_1);
			buttons[1].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x20) != 0, P_1);
			buttons[2].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x40) != 0, P_1);
			buttons[3].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x80) != 0, P_1);
			b = P_0[ikldgNJrwRJKnhuSdDfSldprrFdR];
			buttons[4].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 1) != 0, P_1);
			buttons[5].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 2) != 0, P_1);
			buttons[6].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 4) != 0, P_1);
			buttons[7].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 8) != 0, P_1);
			buttons[8].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x10) != 0, P_1);
			buttons[9].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x20) != 0, P_1);
			buttons[10].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x40) != 0, P_1);
			buttons[11].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 0x80) != 0, P_1);
			b = P_0[XQquIquNxncqgxqfjeKykQHJKaLMA];
			buttons[12].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 1) != 0, P_1);
			buttons[13].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 2) != 0, P_1);
			if (aBtTWjEZUKcQQCAnaXXvUSYjgWsQ)
			{
				buttons[14].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & 4) != 0, P_1);
			}
		}

		private void QFzWPkiZZoDuPmrmnqstQcFaSktl(QTwvMqRjxXBwLOoUpuezGnwheUbM[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].nbdaOhPzrnnznbxNEnDgLWCrHhfx(P_1, P_2);
			}
		}

		private void hpgyqPEbUrzFDsaSfvhBUehIlznv()
		{
			if (isVibrating && ReInput.realTime >= wZASBVXuVjqhSSMZTzVkpiIKvOpU)
			{
				NNtTdNRbqEdagDtgjepeCWVcGjjk();
				ZpkQmZfPkSOFvVcaIfaHjqsBIQInA = true;
			}
		}

		private void ROBEAczxGVgXcGkLNbgYlgDRzITwA(NativeBuffer P_0)
		{
			if (aBtTWjEZUKcQQCAnaXXvUSYjgWsQ)
			{
				uint num = rlmfaEExTWRKjuUcDjiBGURSAIxZ.ReadUInt(28 + ErrOqidIukzjRMRiheeLmzruJBUV);
				float num3;
				if (num != JeTKnvpKgRvzUqKwZucIcvsDqVSb)
				{
					uint num2 = (uint)((num >= JeTKnvpKgRvzUqKwZucIcvsDqVSb) ? (num - JeTKnvpKgRvzUqKwZucIcvsDqVSb) : ((long)num + 4294967295L - JeTKnvpKgRvzUqKwZucIcvsDqVSb));
					num3 = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					num3 = 0f;
				}
				JeTKnvpKgRvzUqKwZucIcvsDqVSb = num;
				xyPuKgrXzkURHjbjicWQwixjAFfFA = num3;
			}
		}

		private void ILKQCXkkgcjKkXYSCEfCJRwacntDA()
		{
			if (aBtTWjEZUKcQQCAnaXXvUSYjgWsQ && !(xyPuKgrXzkURHjbjicWQwixjAFfFA <= 0f))
			{
				Vector3 vector = nvAqYuvTOVjswMLEnOMtkJSkoTFW(new Vector3(gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[0], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[1], gyroscopes[0].YYoVpcWXVNRRChGlABPzCEGREFYAA[2]), xyPuKgrXzkURHjbjicWQwixjAFfFA);
				DgmDPVkmawJVRWlSgIsnEPSfBHNFc(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[0] * -1f, accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[1] * -1f, accelerometers[0].VNYkooeoXLtNVzxyiQWNaRkcrEnm[2] * -1f);
				bLlMOnrJqnyRfguciVNZEPoPSsPt(vector2, vector);
			}
		}

		private static bool DgmDPVkmawJVRWlSgIsnEPSfBHNFc(ref Vector3 P_0)
		{
			if (P_0.magnitude < 0.004f)
			{
				P_0.x = 0f;
				P_0.y = 0f;
				P_0.z = 0f;
				return false;
			}
			return true;
		}

		private void bLlMOnrJqnyRfguciVNZEPoPSsPt(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && rynlxNPkvuNJaVsbJpOJMmfEhoPZ(P_0, out var mLKrZVrWxAOnCJNRSSYCuFuIouCQ2))
			{
				Quaternion a = ijVPXpWTXDsgEivMlirccNzYhZxE * quaternion;
				if (!yZgvWxgrzJmrBDQIoIqTdhtwmpBv)
				{
					yZgvWxgrzJmrBDQIoIqTdhtwmpBv = true;
					AcwIJcpCPXxxRsNYqEPruLqAodkR = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					ikBCjqJvhEozwCGQSCQVKTAZamuib = ijVPXpWTXDsgEivMlirccNzYhZxE;
				}
				AcwIJcpCPXxxRsNYqEPruLqAodkR *= quaternion;
				ikBCjqJvhEozwCGQSCQVKTAZamuib *= quaternion;
				Quaternion b;
				if ((mLKrZVrWxAOnCJNRSSYCuFuIouCQ2 & mLKrZVrWxAOnCJNRSSYCuFuIouCQ.XZ) != mLKrZVrWxAOnCJNRSSYCuFuIouCQ.None)
				{
					b = vyHJxmaYMcpQSkuliAkXRMOjIKHC(P_0, a.eulerAngles.y);
				}
				else if ((mLKrZVrWxAOnCJNRSSYCuFuIouCQ2 & mLKrZVrWxAOnCJNRSSYCuFuIouCQ.Y) != mLKrZVrWxAOnCJNRSSYCuFuIouCQ.None)
				{
					b = ypCOkpEjeyiMOMsfbaKBHGNBicFe(P_0);
					Vector3 vector = ikBCjqJvhEozwCGQSCQVKTAZamuib * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				ijVPXpWTXDsgEivMlirccNzYhZxE = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				ijVPXpWTXDsgEivMlirccNzYhZxE *= quaternion;
				if (yZgvWxgrzJmrBDQIoIqTdhtwmpBv)
				{
					yZgvWxgrzJmrBDQIoIqTdhtwmpBv = false;
				}
			}
		}

		private static Quaternion YdmRpiplmZhzngpheQcRzmUVaGmiA(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = nFHScGnOaYVkqfVXwdceojGKNtNf(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 nFHScGnOaYVkqfVXwdceojGKNtNf(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion YFtwSWlvsGapCQehyjYwnGYjNIdR(Quaternion P_0, yifYGAMrYZqglHKPuXnEstjdahtE P_1)
		{
			Vector4 vector = default(Vector4);
			if (MathTools.Approximately(P_0.w, 0f) && MathTools.Approximately(P_0[(int)P_1], 0f))
			{
				P_0 = Quaternion.identity;
			}
			else
			{
				float num = P_0[(int)P_1];
				float num2 = MathTools.Sqrt(P_0.w * P_0.w + num * num);
				vector[3] = P_0.w / num2;
				vector[(int)P_1] = num / num2;
				P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
			}
			return P_0;
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
			float num2 = 1f / num;
			Quaternion result = default(Quaternion);
			result.x = (0f - quaternion.x) * num2;
			result.y = (0f - quaternion.y) * num2;
			result.z = (0f - quaternion.z) * num2;
			result.w = quaternion.w * num2;
			return result;
		}

		private float XSZZzeacudzshwLvCRThXohFCtgi(float P_0, float P_1)
		{
			P_0 = MathTools.ClampAngle360(P_0);
			P_1 = MathTools.ClampAngle360(P_1);
			if (P_0 == P_1)
			{
				return 0f;
			}
			if (P_0 >= 180f)
			{
				P_0 -= 360f;
			}
			if (P_1 >= 180f)
			{
				P_1 -= 360f;
			}
			return P_0 - P_1;
		}

		private Vector3 YZqFMymuPjmvipPlWHlPfUXtUAxt(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion vyHJxmaYMcpQSkuliAkXRMOjIKHC(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion ypCOkpEjeyiMOMsfbaKBHGNBicFe(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			Quaternion quaternion = Quaternion.Euler(0f, 0f, z) * Quaternion.Euler(x2, 0f, 0f);
			if (P_1 != 0f)
			{
				return quaternion * Quaternion.Euler(0f, P_1, 0f);
			}
			return quaternion;
		}

		private float KQPBBwhCKMbLXxAkqICFvXOPXkKlA(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool DILywrUawPblIilVQIxOryQMISjqA(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool rynlxNPkvuNJaVsbJpOJMmfEhoPZ(Vector3 P_0, out mLKrZVrWxAOnCJNRSSYCuFuIouCQ P_1)
		{
			P_0.Normalize();
			P_1 = mLKrZVrWxAOnCJNRSSYCuFuIouCQ.None;
			bool result = false;
			if (tqLeRVhmcplhMYdQRLpdaXEQxDFi(P_0))
			{
				result = true;
				P_1 |= mLKrZVrWxAOnCJNRSSYCuFuIouCQ.XZ;
			}
			if (pUecgZkGcEiPBjzynglxelpExGag(P_0))
			{
				result = true;
				P_1 |= mLKrZVrWxAOnCJNRSSYCuFuIouCQ.Y;
			}
			return result;
		}

		private bool tqLeRVhmcplhMYdQRLpdaXEQxDFi(Vector3 P_0)
		{
			if (P_0.y > 0f)
			{
				return false;
			}
			if (Vector3.Angle(Vector3.down, P_0) > 45f)
			{
				return false;
			}
			return true;
		}

		private bool pUecgZkGcEiPBjzynglxelpExGag(Vector3 P_0)
		{
			if (P_0.z < 0f)
			{
				return false;
			}
			if (Vector3.Angle(new Vector3(0f, 0f, 1f), P_0) > 20f)
			{
				return false;
			}
			return true;
		}

		private Vector3 tgwaligakwMNGSNilHugEkjKnqaoB(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 YFRCrsFbrgmDyUShpRGhIdJyCpxBA(RingBuffer<mtYfxDYuHHPxAtRRwphKvfBUCHvHA.kHgxaIUQumRSmtlkwfNRJICwIywm> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				mtYfxDYuHHPxAtRRwphKvfBUCHvHA.kHgxaIUQumRSmtlkwfNRJICwIywm kHgxaIUQumRSmtlkwfNRJICwIywm = P_0[i];
				result += nvAqYuvTOVjswMLEnOMtkJSkoTFW(kHgxaIUQumRSmtlkwfNRJICwIywm.CqaRbtXIhghqiCpvcMOWeYBPOEnjA, kHgxaIUQumRSmtlkwfNRJICwIywm.unCFBcqDYBEiWsYKeCdlMEUrtnuJ);
			}
			return result;
		}

		private Vector3 nvAqYuvTOVjswMLEnOMtkJSkoTFW(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int NNBsIsxaxBLpDCAhajqxdUFREqBvA(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void qpNEaipvYmAZXCvBPXNCaGZwGtXnA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void gVAasjoRbiPInQIDGmOdXJgyjMPT(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float aSamAcAgoNOgbAsnzmIaKnLGkDJc()
		{
			return xyPuKgrXzkURHjbjicWQwixjAFfFA;
		}

		private void wEjYkpFQzgdJHgabJQFxXdJSncdnA(NativeBuffer P_0, SRlmwzCpkDCiOPGALkZGROsZKGfx.TouchData[] P_1)
		{
			int num = 33 + ErrOqidIukzjRMRiheeLmzruJBUV;
			int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
			int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
			int positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
			int positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
			byte b = P_0[num];
			bool flag = b < 128;
			byte num2 = P_0[num + 4];
			bool flag2 = num2 < 128;
			int num3 = b & 0x7F;
			int num4 = num2 & 0x7F;
			P_1[0].isTouching = flag;
			P_1[0].touchId = UwdBRruvMUKeeBVJLPwBNekFrHIn(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = UwdBRruvMUKeeBVJLPwBNekFrHIn(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int UwdBRruvMUKeeBVJLPwBNekFrHIn(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				PbhvelTsmrJpSzVkfjQrLCYxaarH[P_0] = -1;
				yhSwupgoSRENVfAWFprEqMNUxcxE[P_0] = P_2;
				return -1;
			}
			if (P_2 != yhSwupgoSRENVfAWFprEqMNUxcxE[P_0])
			{
				int num = fskMypYnOyjPZFYxJBPKNQtuHmQN;
				if (fskMypYnOyjPZFYxJBPKNQtuHmQN == int.MaxValue)
				{
					fskMypYnOyjPZFYxJBPKNQtuHmQN = 0;
				}
				else
				{
					fskMypYnOyjPZFYxJBPKNQtuHmQN++;
				}
				yhSwupgoSRENVfAWFprEqMNUxcxE[P_0] = P_2;
				PbhvelTsmrJpSzVkfjQrLCYxaarH[P_0] = num;
				return num;
			}
			return PbhvelTsmrJpSzVkfjQrLCYxaarH[P_0];
		}

		private void gMKfoGuzIvTahvmMomDZelQyEcwN()
		{
			udhRltlANZkVdXysPHFseATtvLhs = true;
			NNtTdNRbqEdagDtgjepeCWVcGjjk();
		}

		private void MfEJcJhbmiJBNJfjpFNthIHTpBHfA()
		{
			udhRltlANZkVdXysPHFseATtvLhs = true;
			NNtTdNRbqEdagDtgjepeCWVcGjjk();
		}

		private void vBqAEEKHaasEnNmUYZnraKoofYGt()
		{
			ZpkQmZfPkSOFvVcaIfaHjqsBIQInA = true;
			NNtTdNRbqEdagDtgjepeCWVcGjjk();
		}

		private void NNtTdNRbqEdagDtgjepeCWVcGjjk()
		{
			zbFVmWSsoTOICwJnDQrOdieoVjuI = true;
		}

		~DualSenseDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			base.Dispose(disposing);
			if (disposing)
			{
				StopVibration();
				PEGYBjSOfENrDHkLefzrwoZdMWfp(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous);
				if (rlmfaEExTWRKjuUcDjiBGURSAIxZ != null)
				{
					rlmfaEExTWRKjuUcDjiBGURSAIxZ.Dispose();
				}
				if (NlghswWgZeAxivNHXPjHfynViOjK != null)
				{
					NlghswWgZeAxivNHXPjHfynViOjK.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (pid == 3302)
			{
				return vid == 1356;
			}
			return false;
		}

		private static uint XwJHjNJApYuMzSnvidAVKBDEwBPJA(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = ahsGJNsAbzaRPJmvYQQXJyprPvieA[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static hrJrpoRvibFHNCNtwywQsPaWAtyd fKljvYrGWfamKcZyCBZLuzzvfbOz(DualSenseOtherLightBrightness P_0)
		{
			return P_0 switch
			{
				DualSenseOtherLightBrightness.High => hrJrpoRvibFHNCNtwywQsPaWAtyd.High, 
				DualSenseOtherLightBrightness.Medium => hrJrpoRvibFHNCNtwywQsPaWAtyd.Medium, 
				DualSenseOtherLightBrightness.Low => hrJrpoRvibFHNCNtwywQsPaWAtyd.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static DualSenseOtherLightBrightness IJDWjltgqBVwvyNXinuptGclLTzW(hrJrpoRvibFHNCNtwywQsPaWAtyd P_0)
		{
			return P_0 switch
			{
				hrJrpoRvibFHNCNtwywQsPaWAtyd.High => DualSenseOtherLightBrightness.High, 
				hrJrpoRvibFHNCNtwywQsPaWAtyd.Medium => DualSenseOtherLightBrightness.Medium, 
				hrJrpoRvibFHNCNtwywQsPaWAtyd.Low => DualSenseOtherLightBrightness.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static EKbLOvlGDtpmPfBQywNxEoIeCBjG TCVxaDCchSiGUrSBdAtYuULQEqTs(DualSenseTriggerType P_0, byte P_1)
		{
			byte b;
			switch (P_0)
			{
			case DualSenseTriggerType.Left:
				b = new mTuSQbMesCOHQDztiyjnRexwBKkl(P_1).SLVcYdcTCKAapVudCLBPlBHJTcBn;
				break;
			case DualSenseTriggerType.Right:
				b = new mTuSQbMesCOHQDztiyjnRexwBKkl(P_1).gnsdarRKgObLrZsMQYsyUBifBEjz;
				break;
			default:
				return EKbLOvlGDtpmPfBQywNxEoIeCBjG.Off;
			}
			return b switch
			{
				0 => EKbLOvlGDtpmPfBQywNxEoIeCBjG.Off, 
				1 => EKbLOvlGDtpmPfBQywNxEoIeCBjG.Feedback, 
				2 => EKbLOvlGDtpmPfBQywNxEoIeCBjG.Weapon, 
				3 => EKbLOvlGDtpmPfBQywNxEoIeCBjG.Vibration, 
				4 => EKbLOvlGDtpmPfBQywNxEoIeCBjG.SlopeFeedback, 
				_ => EKbLOvlGDtpmPfBQywNxEoIeCBjG.Off, 
			};
		}

		private static DualSenseTriggerEffectState gWDdgfzSJGOQULTplMmWBbVDEiJY(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			byte b = new mTuSQbMesCOHQDztiyjnRexwBKkl(P_1).SLVcYdcTCKAapVudCLBPlBHJTcBn;
			return TCVxaDCchSiGUrSBdAtYuULQEqTs(P_0, P_2) switch
			{
				EKbLOvlGDtpmPfBQywNxEoIeCBjG.Off => DualSenseTriggerEffectState.Off, 
				EKbLOvlGDtpmPfBQywNxEoIeCBjG.Feedback => b switch
				{
					0 => DualSenseTriggerEffectState.FeedbackIdle, 
					1 => DualSenseTriggerEffectState.FeedbackApplyingForce, 
					_ => DualSenseTriggerEffectState.FeedbackIdle, 
				}, 
				EKbLOvlGDtpmPfBQywNxEoIeCBjG.Weapon => b switch
				{
					0 => DualSenseTriggerEffectState.WeaponIdle, 
					1 => DualSenseTriggerEffectState.WeaponFiring, 
					2 => DualSenseTriggerEffectState.WeaponFired, 
					_ => DualSenseTriggerEffectState.WeaponIdle, 
				}, 
				EKbLOvlGDtpmPfBQywNxEoIeCBjG.Vibration => b switch
				{
					0 => DualSenseTriggerEffectState.VibrationIdle, 
					1 => DualSenseTriggerEffectState.VibrationVibrating, 
					_ => DualSenseTriggerEffectState.VibrationIdle, 
				}, 
				EKbLOvlGDtpmPfBQywNxEoIeCBjG.SlopeFeedback => b switch
				{
					0 => (DualSenseTriggerEffectState)8, 
					1 => (DualSenseTriggerEffectState)9, 
					2 => (DualSenseTriggerEffectState)10, 
					_ => (DualSenseTriggerEffectState)8, 
				}, 
				_ => DualSenseTriggerEffectState.Off, 
			};
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
			if (msg != null)
			{
				Logger.Log("DualSenseDriver: " + msg);
			}
		}
	}
}
