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
		private enum wFJJCGbdzCEjjvhGTLYAJxLArleq
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum yHuGERKUfNggUjhXCxHISBMtRbHBb
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum UHTbSvGnXcFeDPIQBmnjzmIBHJcy : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum hyhijesAbyBSHizJHfRSRVfnDthH : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum mGKKchDTelXpmhRDuitSlcMTsdne : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum QWZVxCOclNRGgThZWBLpjOmMWYEr
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum BzqenUzBDPaRSGxXxkRHQmmrKGbuA : byte
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

		private enum wQkbwEDmluqICRHnMlDFzZRvAmyA : byte
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

		private enum DfOhcKGhFtoDRqkJhDOhNigcvEOn : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct owAAVjzCuHbXSlIjBivxHuHDkUfEb
		{
			private const string BmdtMglayWjMmAolXBJQUUBquabw = "Value must be between 0 and 16.";

			public byte ubjolyqvZVRkRTFEslsotRfrNeee;

			public byte qHIjQryhsXGtxhpOzhOingWADkgF
			{
				get
				{
					return (byte)(ubjolyqvZVRkRTFEslsotRfrNeee & 0xF);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					ubjolyqvZVRkRTFEslsotRfrNeee = (byte)((CGdXtnBBWLdMznOlbOoRKhzetxWH << 4) | (b & 0xF));
				}
			}

			public byte CGdXtnBBWLdMznOlbOoRKhzetxWH
			{
				get
				{
					return (byte)(ubjolyqvZVRkRTFEslsotRfrNeee >> 4);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					ubjolyqvZVRkRTFEslsotRfrNeee = (byte)((b << 4) | qHIjQryhsXGtxhpOzhOingWADkgF);
				}
			}

			public owAAVjzCuHbXSlIjBivxHuHDkUfEb(byte P_0)
			{
				ubjolyqvZVRkRTFEslsotRfrNeee = P_0;
			}

			public owAAVjzCuHbXSlIjBivxHuHDkUfEb(byte P_0, byte P_1)
			{
				if (P_0 >= 16 || P_1 >= 16)
				{
					throw new ArithmeticException("Value must be between 0 and 16.");
				}
				ubjolyqvZVRkRTFEslsotRfrNeee = (byte)((P_1 << 4) | P_0);
			}
		}

		private static class LraIesgjLkWCnpxpsrTyoIfLKpxC
		{
			public enum XUFYxjeJuuWMJZeDWyaLAMwtXVxF : byte
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

			public static class VZIvFafjBhNESYRfmsEBxQBcygxU
			{
				public static class hxNcsYvwUVzIOapxklrLUIzYPOwg
				{
					public static bool dHvlnEGNMJgxjFYnUkEWtYPBdUJi(byte[] P_0, int P_1)
					{
						return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
					}

					public static bool jHXGkCJBApaogRQUKVKkbfUJOViJ(byte[] P_0, int P_1, float P_2, float P_3)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						return hjnNXdtNFOCvKByRNSJiphhiJhyh(P_0, P_1, (byte)P_2, (byte)P_3);
					}

					public static bool aRWoitCJCzHoHkehOHBMJXqFndkT(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						return dKCmGOLlAkrFpQlFpAcADUwIBZQl(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool wKmhomZgjlCcKBhfThsLowwnZOgp(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						P_4 = (float)Math.Round(P_4 * 255f);
						return ZenVvpLKgvDcupNVpYmYLlqpfoou(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool ccCqVZedYXjdSNwTapUsNSdqHiCU(byte[] P_0, int P_1, float[] P_2)
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
						return lwCCorOdxIoYBiQeqyaMHIOguYBd(P_0, P_1, array);
					}

					public static bool oTJFtMSVhMxMUjIZBYYFJGTgVnzK(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						P_5 = (float)Math.Round(P_5 * 8f);
						return vlsCwqWLXlbhvswYYlCEQoUlrRcL(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4, (byte)P_5);
					}

					public static bool ygoefmSHSZJcXgnGxmBbHWgnPnQM(byte[] P_0, int P_1, float[] P_2, float P_3)
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
						return NaftMqqOPjEqwRdIogOsfnWFWTOlA(P_0, P_1, (byte)P_3, array);
					}
				}

				[Serializable]
				private sealed class DNACDGHhuXXACgNQjRLOLghHrGWlA
				{
					public static readonly DNACDGHhuXXACgNQjRLOLghHrGWlA _003C_003E9 = new DNACDGHhuXXACgNQjRLOLghHrGWlA();

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool UcGvlVUDtMdWAQdMDdbnFpNhTQLHA(byte P_0)
					{
						return P_0 > 0;
					}

					internal bool NVacjAbWitYfmvMvGqDFAKkjdQVub(byte P_0)
					{
						return P_0 > 0;
					}
				}

				public static bool RsfGbFnHcRBXRLgJLFbJMnkZnbLV(byte[] P_0, int P_1)
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

				public static bool hjnNXdtNFOCvKByRNSJiphhiJhyh(byte[] P_0, int P_1, byte P_2, byte P_3)
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool dKCmGOLlAkrFpQlFpAcADUwIBZQl(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool ZenVvpLKgvDcupNVpYmYLlqpfoou(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool lwCCorOdxIoYBiQeqyaMHIOguYBd(byte[] P_0, int P_1, byte[] P_2)
				{
					if (P_2.Length != 10)
					{
						return false;
					}
					if (P_2.Any(DNACDGHhuXXACgNQjRLOLghHrGWlA._003C_003E9.UcGvlVUDtMdWAQdMDdbnFpNhTQLHA))
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool vlsCwqWLXlbhvswYYlCEQoUlrRcL(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
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
					return lwCCorOdxIoYBiQeqyaMHIOguYBd(P_0, P_1, array);
				}

				public static bool NaftMqqOPjEqwRdIogOsfnWFWTOlA(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					if (P_3.Length != 10)
					{
						return false;
					}
					if (P_2 > 0 && P_3.Any(DNACDGHhuXXACgNQjRLOLghHrGWlA._003C_003E9.NVacjAbWitYfmvMvGqDFAKkjdQVub))
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool lapTxIzZALWpjmxbcFPdzSEWKavC(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool NPUmSGQSCYkFztGWWCDMqSXGlXcP(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool NDnWIXniqUDcNDGWnjJMtDWrsvEKA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool IxhdFLZINZfbwELJOHFrxpsLVPRJ(byte[] P_0, int P_1, byte P_2, byte P_3)
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

				public static bool ANHKchnqYyMmorklfBEpslOESiTn(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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

				public static bool SsvKtbnmSLbrZhylFvEedJxMvMik(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool QkxnIvtjjgkXsqiWbhWjACAjtoJN(byte[] P_0, int P_1, byte P_2, byte P_3)
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}

				public static bool QaPKtCakTkfVJDOqeJKVwkHnZNiDA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return RsfGbFnHcRBXRLgJLFbJMnkZnbLV(P_0, P_1);
				}
			}
		}

		private const float fHWIDOwQBkbHcypgZTycodrrfwZJ = 4f;

		private const int pXENkjzfEMdwkWNawEGiJbPCwsGq = 15;

		private const int RmQgfdNITvdqyzMhOACrLGWuUoKI = 2;

		private const int eWYJMqjLTteDckJCsbkESBNibOxE = 0;

		private const int zwdEihtTEZOVgrMaWJkISOEcvtSy = 1912;

		private const int xNKXARZveZCblalDQcCXeIoKMiZAb = 0;

		private const int CAZnjtuivNWeFOzUzyNjZJqLsrVf = 941;

		private const bool GItqNezpAVPltEPdpbQTcjdPFhDV = false;

		private const bool ZOCMPPLCaEAMQiNBNQECrgogWOaR = true;

		private const float oGQbrUyhIYsVzymOWeNIgFVrhBvfA = 2.5f;

		private const int uJvbDlngPvhMNedkdWSeEAPxHqhNA = 0;

		private const int hamSTvtsngrsDNnjcMohHzePMdPo = 0;

		private const int aVdYEAAupNDuVxIuTaYdqUwZBfybA = 1;

		private const int NUfvvKkDLGlYRQuLRnPhhDIxDNmY = 0;

		private const int RjcgnuHCgMJuiSXaWrfkwtVXWnnr = 0;

		private const int GnhxeSLPBSuYyjdDvQAvXHHjhxLL = 0;

		private const int lSacgAfszoebBfIfeCqXMZaFEEflD = 1;

		private const int GmoJNJjoTiyNyqgMujWTAHsoudoX = 49;

		private const int wGBrlepoxKOjAQnGpjAtEozrrYMe = 0;

		private const int DrqavYPnuDFTjwNAiiCWYSziCJAgA = 1;

		private const int eLsoInptAjDbbxrxgjJGgJYDGBfaA = 64;

		private const int soJKcAQMXyLvdnibNpTZkrGLmJXE = 48;

		private const int ExCHeOOSiJATxyDtQzYnQhuvOMuw = 78;

		private const int ispxStsWcWXroGYMtsPjdNLQBYmE = 5;

		private const int GurgzDXARTresPaeHCAZFSidMmHbA = 41;

		private const byte RvELqmzQeygGDfrrMlbPKgHyOmSr = 1;

		private const byte pJpAeXoAYCjPjBIbDisdKKsdHylW = 2;

		private const int leXCTUbVSxIpcLUCicTIOQMebKCPA = 1;

		private const int YugkunpKQDaPshQblGfsnbGUdFZCb = 2;

		private const int jkdfNZttXGgtXGqcaNywfqyZRPZcA = 3;

		private const int XCbHHnssUhxejeWsFbOuNtvaDqZb = 4;

		private const int YosnIOJJTkZWSMSNDxPTiiEqAhsx = 5;

		private const int ZLHkntmSmihhIeGUqqdLZZfjgMwG = 6;

		private const int saqLZSGWbZxQJhgXTWPRRVIXoWk = 8;

		private const int YfbJTkLShqesYkJtJKsRkIjrCFYb = 22;

		private const int gPBcMbCiBoBOrbiCDioQTeWKJLIpA = 16;

		private const int pvEDWJwHyUEPaIbbrtbGHVYLbbCx = 33;

		private const int EVLlIZypbHSeYYeJmDTqBqSVPJHE = 8;

		private const int qjmPHpXaKGehfGKLdymkktgnIcVN = 9;

		private const int EAgVVKaydGmMMaAYvCLmShKiiWgd = 10;

		private const int hiWHsMtLBxvgExTbyJVKgMdYyUme = 28;

		private const int yWmgylZemEFeayKndFDvqPJynvTL = 53;

		private const int tFyUuGXmIFUPuTkQPcFtJtnXcIliA = 54;

		private const int yHUQQRbcyJEIkdKbKjEHwTyuGjNV = 43;

		private const int pNNatsJZoRqTfLNUCDwxzdwbAttk = 42;

		private const int VllArLhNQnkXybZXfPqiPAejDPedD = 48;

		private const bool EZEFLVBlUPGDnHIzHSuqmUybCaWpA = true;

		private const int DyTpIZGjKuDDEdCHEQyFCVghKAFtb = 60;

		private const int tSoeGnZKRKekBdRFgdnqjAIcTIwAc = 60;

		private const int vacXLmdWOhthoTuXjfZLMqXSwIZC = 3000000;

		private const float OAZRTdLKmQYGmnBEHhdFnMNnFBjm = 8192f;

		private const float yqkZSpSNZbntuQZleFnqwApUzNdN = 0.0010652969f;

		private const float pqtrHrZKXzfpBbIQmyQoPpBjzSQFA = 0.06103702f;

		private const bool gRkRjqqeRjcXqJPaxVKKfXDCRRXA = true;

		private const bool NMjKBIOJJDABjkBShlERWkVkYMiqA = true;

		private const bool IpKuUjjgpYNsQfMnLAVmAqapzmbI = true;

		private const bool mIEcGbHnfLQiEuQTEHJLLcRfNIiw = true;

		private const float XqWHdiPDoNXooTJbEFfoppmsoOAY = 4096f;

		private const float TkWmZrvwRrPDYcMFgNlHoqCBBBlo = 16384f;

		private const float EqHZLZBaFuDiKGiUxDhjeaZihqZdB = 16777216f;

		private const float FHbAOVzjjzJttxIpMWKTZHxzspTg = 268435460f;

		private const float efwNlObkAzjxccfsejHqxnRxfjUhb = 0.01999998f;

		private const float qteGUfpuTJZTGkNQYiWjuWmdBsnj = 8192f;

		private const float pHwbragulSWRDriPsiJxRxufuRSqA = 0.98f;

		private const float EPIIpiuQtiPDjfNFgTPxpJkkedSk = 45f;

		private const float WERkBnTVVeiooPejsDLVEocSUUwfA = 20f;

		private const DualSenseVibrationMode XzZbHyLkmNHsMmtMzSYVSeShUWZM = DualSenseVibrationMode.Compatible2;

		private readonly IHIDDevice STgFaWnmdmPPEgLmmNXWOnwBeuOq;

		private readonly HIDProperties sWRMFjCGHSqTpKHEKSQWcEPIbErX;

		private readonly bool SOKgbuZAHkUhhlLrBLtMHsbLWQeT;

		private readonly int lfrYzLVAlqAoruNYkGRZmeXIeEMW;

		private readonly int vkBhIzywzkGJaNNvesFuqUPeUkMe;

		private readonly bool iUBeNndnANgZIecxRQCrixkHQRfwB;

		private readonly byte xYGrWQMRfUwOXLqpLLRorefxJGgP;

		private readonly int IjDcrqhMujoeZrogYOtFeJNNNIPrA;

		private readonly int VDxgbLNaOFLXuqVbIoBULRUKKPnd;

		private readonly int qdHhRZaCsKNjjVqYQghQWWRSCHgK;

		private readonly int RfKHRsRttskzyDOlWRBejcxyMtMo;

		private readonly NativeBuffer lPIqfOSdBXpFtEkiiWxPnYvfkDir;

		private readonly NativeBuffer JhKdkqzyFndViZwJqJYTGvLuqhiM;

		private fSMyuzvVmAACQsIYyLcgNLStbZVN eLemdSzizHeXShkgXXRUUwAcOQSFA;

		private int fqtHBGhGKUJCcLggsSKxryxrJMfc;

		private bool jhHMCEbaAfZUTMtggPCISIgLMzNc;

		private bool vKPacBYuEABAFiGsJOlgyMNiNzsQA;

		private double sTiESTwOZyJoIiPFwpEoYymzFXmr;

		private int gzkMODcxQoWUkvBORFlUbLTRNLmlA;

		private QWZVxCOclNRGgThZWBLpjOmMWYEr wZmUsRrPlvDdcdqMXVCyDLRVGlKuA;

		private bool JZIPPmmerQGnqevUUNzwRRHVfgeh;

		private Quaternion oClGlWpZeKbBYGYLObTmXLhfiHcD = Quaternion.identity;

		private DualSenseMicrophoneLightMode azWatqLlknXqjvozdjiSLFQDAgNw;

		private hyhijesAbyBSHizJHfRSRVfnDthH GeYUfJnssjHUypinzobhIsYeDrSW;

		private DualSensePlayerLightFlags TrhekBDiWRYcsybFBxCUhVNfDUbp;

		private bool BqlukuOEDdgfCxveezmyOYojPUYA;

		private uint BhzPXhYFKWwKhKOYizoyFpBqvRKj;

		private float zSlfNsYqhdoEZRDfNcZOgJVMTOyOA;

		private double xTBABVEqUMhJlQRSnktyBcpALjTc;

		private float YPFpeDrqJkDZGcCwIWDWguCLdoKWA;

		private readonly IDualSenseTriggerEffect[] ZytMyQvAgfHsrCcprZFCWJmWLyXM = new IDualSenseTriggerEffect[2];

		private readonly byte[] gbklCFcTarUKWtxSnZvjSXJNjLZK = new byte[10];

		private readonly byte[] eDdiAbzgKcDIHyDdZHwgbEbiCuDXA = new byte[11];

		private DualSenseTriggerEffectState[] SNoWRVswXMofoSqCsDnvjhmcJNdp = new DualSenseTriggerEffectState[2];

		private DualSenseVibrationMode KaFedhIZXsTburlXZavLAvDIDefmA;

		private byte fKnDGYMsOyupitIJMziBMIHWWAJU;

		private bool DLIfjRGAgFDMrTlsnbbLlTEaKZXJA;

		private bool USQavlErPWdGLhoSEGnmeGqgAwEte;

		private bool YooHNbSLwZWjBQsUacHdnhohdUXP;

		private bool ZayRhcKrlWjcCnIdAYXbrgtHixEu;

		private bool JjZPQjtRShpvxFHXQcqmnfMytSuD;

		private bool chdTvjttvNLSstBiGSALqfOxrUJb;

		private bool qjVAxbYNHUOZtzsNgKhqFlkGIIsf;

		private bool ORIdOnjNgafiDJMkujMJkfwCLAcJ;

		private bool ZwzxBsRlDUslnpYjtjLAoBCYRhSn;

		private byte YariILqxnsjqiHfcsACLJVmgutTl;

		private byte wfiDASDMXUzHXBDZVVMCKVaulubK;

		private Quaternion CSAyKwALJWTqXGvCThSjRxYdaMzk = Quaternion.identity;

		private Quaternion ilfLcgWGlFFyccyGlNRBMcwkPzbhb = Quaternion.identity;

		private bool gxGjFdVybUSkRdvETIrFKZNRBwGT;

		private int jiMeznnPOnBAHbzlqYOUkoRVLvBZA;

		private int[] JTJaipwTeweYANceYawvaWeWvPqF = new int[2];

		private int[] kHoanjJImMGHNfTUseaIOJuzauqyA = new int[2];

		private static uint[] qkSSKBNJveUSDAtvxsVJRrTSjoju = new uint[256]
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

		private const uint WBGDkkKDyzyfmejdCskzSmWFkcnIb = 3940166985u;

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].OZyBFjtdbmGNdxlWalLBCWEMJQKG > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualSense.BatteryLevel => gzkMODcxQoWUkvBORFlUbLTRNLmlA;

		bool IDriver_DualSense.BatteryCharging => wZmUsRrPlvDdcdqMXVCyDLRVGlKuA == QWZVxCOclNRGgThZWBLpjOmMWYEr.Charging;

		DualSenseVibrationMode IDriver_DualSense.vibrationMode
		{
			get
			{
				return KaFedhIZXsTburlXZavLAvDIDefmA;
			}
			set
			{
				KaFedhIZXsTburlXZavLAvDIDefmA = value;
				XgFSrFwhuNieglOwKbzypnrDEXoGA();
			}
		}

		float IDriver_DualSense.LeftMotor
		{
			get
			{
				return vibrationMotors[0].FdnMOOHJyNvOIoiYNtolKFnibDkk;
			}
			set
			{
				vibrationMotors[0].FdnMOOHJyNvOIoiYNtolKFnibDkk = value;
			}
		}

		float IDriver_DualSense.RightMotor
		{
			get
			{
				return vibrationMotors[1].FdnMOOHJyNvOIoiYNtolKFnibDkk;
			}
			set
			{
				vibrationMotors[1].FdnMOOHJyNvOIoiYNtolKFnibDkk = value;
			}
		}

		float IDriver_DualSense.LightColorR
		{
			get
			{
				return lights[0].vPYcTtJfKLscQqLvSiAHqbypUWfkA;
			}
			set
			{
				lights[0].vPYcTtJfKLscQqLvSiAHqbypUWfkA = value;
			}
		}

		float IDriver_DualSense.LightColorG
		{
			get
			{
				return lights[0].ecnCyygCnjapnBhBOGwNyniPFYSD;
			}
			set
			{
				lights[0].ecnCyygCnjapnBhBOGwNyniPFYSD = value;
			}
		}

		float IDriver_DualSense.LightColorB
		{
			get
			{
				return lights[0].SshhImoBPrhHQgNlYXqOEZnoeDjs;
			}
			set
			{
				lights[0].SshhImoBPrhHQgNlYXqOEZnoeDjs = value;
			}
		}

		float IDriver_DualSense.LightFlashOnDuration
		{
			get
			{
				return (int)YariILqxnsjqiHfcsACLJVmgutTl;
			}
			set
			{
				YariILqxnsjqiHfcsACLJVmgutTl = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				IjaIgLOiMlWgBzDlOWXxvsnaAMUL();
				if (YariILqxnsjqiHfcsACLJVmgutTl == 0 && wfiDASDMXUzHXBDZVVMCKVaulubK == 0)
				{
					vKPacBYuEABAFiGsJOlgyMNiNzsQA = true;
				}
			}
		}

		float IDriver_DualSense.LightFlashOffDuration
		{
			get
			{
				return (int)wfiDASDMXUzHXBDZVVMCKVaulubK;
			}
			set
			{
				wfiDASDMXUzHXBDZVVMCKVaulubK = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				IjaIgLOiMlWgBzDlOWXxvsnaAMUL();
				if (YariILqxnsjqiHfcsACLJVmgutTl == 0 && wfiDASDMXUzHXBDZVVMCKVaulubK == 0)
				{
					vKPacBYuEABAFiGsJOlgyMNiNzsQA = true;
				}
			}
		}

		DualSenseMicrophoneLightMode IDriver_DualSense.microphoneLightMode
		{
			get
			{
				return azWatqLlknXqjvozdjiSLFQDAgNw;
			}
			set
			{
				azWatqLlknXqjvozdjiSLFQDAgNw = value;
				XgFSrFwhuNieglOwKbzypnrDEXoGA();
				ZayRhcKrlWjcCnIdAYXbrgtHixEu = true;
			}
		}

		DualSenseOtherLightBrightness IDriver_DualSense.otherLightBrightness
		{
			get
			{
				return KkhFgtQjuKPplCORVzfjOzCOEEaW(GeYUfJnssjHUypinzobhIsYeDrSW);
			}
			set
			{
				GeYUfJnssjHUypinzobhIsYeDrSW = fHJXwWUcCaIbKbnepRCHaMFIssHz(value);
				XgFSrFwhuNieglOwKbzypnrDEXoGA();
				chdTvjttvNLSstBiGSALqfOxrUJb = true;
			}
		}

		DualSensePlayerLightFlags IDriver_DualSense.playerLights
		{
			get
			{
				return TrhekBDiWRYcsybFBxCUhVNfDUbp;
			}
			set
			{
				TrhekBDiWRYcsybFBxCUhVNfDUbp = value;
				XgFSrFwhuNieglOwKbzypnrDEXoGA();
				JjZPQjtRShpvxFHXQcqmnfMytSuD = true;
			}
		}

		Vector3 IDriver_DualSense.AccelerometerValue => fMQNouTNkbVECvyyWLzkBcJSelvr(accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN);

		Vector3 IDriver_DualSense.AccelerometerValueRaw => new Vector3(accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[0], accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[1], accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[2]);

		Vector3 IDriver_DualSense.GyroscopeValue => CktwRiuvslEGuybpELQpprnXwkmk(gyroscopes[0].jAaKjjHKnrIKIhusFAEDraeMOtzLA);

		Vector3 IDriver_DualSense.GyroscopeValueRaw => new Vector3(gyroscopes[0].NKyhjzEpAZtHNcjqwLDpmKcEdGoA[0], gyroscopes[0].NKyhjzEpAZtHNcjqwLDpmKcEdGoA[1], gyroscopes[0].NKyhjzEpAZtHNcjqwLDpmKcEdGoA[2]);

		Vector3 IDriver_DualSense.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[0], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[1], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[2]);
				return vymdPoCCMGoraIyYAYNbJXwXSlMK(vector, zSlfNsYqhdoEZRDfNcZOgJVMTOyOA);
			}
		}

		Vector3 IDriver_DualSense.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[0], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[1], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[2]);

		Quaternion IDriver_DualSense.Orientation => oClGlWpZeKbBYGYLObTmXLhfiHcD;

		int IDriver_DualSense.MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => sWRMFjCGHSqTpKHEKSQWcEPIbErX.vendorId;

		ushort IHIDControllerExtension.productId => sWRMFjCGHSqTpKHEKSQWcEPIbErX.productId;

		string IHIDControllerExtension.productName => sWRMFjCGHSqTpKHEKSQWcEPIbErX.productName;

		string IHIDControllerExtension.manufacturer => sWRMFjCGHSqTpKHEKSQWcEPIbErX.manufacturer;

		ushort IHIDControllerExtension.usagePage => sWRMFjCGHSqTpKHEKSQWcEPIbErX.usagePage;

		ushort IHIDControllerExtension.usage => sWRMFjCGHSqTpKHEKSQWcEPIbErX.usage;

		public void ResetOrientation()
		{
			oClGlWpZeKbBYGYLObTmXLhfiHcD = Quaternion.identity;
			gxGjFdVybUSkRdvETIrFKZNRBwGT = false;
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
				if (touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj[i].isTouching)
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
			return touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj[index].isTouching;
		}

		bool IDriver_DualSense.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].GsLURatUIUplCESYptaZWyOBgXfU(touchId);
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
			return touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj[index].touchId;
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
			YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] xBRNyXRXsysdNperzXpLQXmtHcpj = touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj;
			if (!xBRNyXRXsysdNperzXpLQXmtHcpj[index].isTouching)
			{
				return false;
			}
			position.x = xBRNyXRXsysdNperzXpLQXmtHcpj[index].positionX;
			position.y = xBRNyXRXsysdNperzXpLQXmtHcpj[index].positionY;
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
			if (!touchpads[0].GsLURatUIUplCESYptaZWyOBgXfU(touchId))
			{
				return false;
			}
			YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] xBRNyXRXsysdNperzXpLQXmtHcpj = touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj;
			for (int i = 0; i < xBRNyXRXsysdNperzXpLQXmtHcpj.Length; i++)
			{
				if (xBRNyXRXsysdNperzXpLQXmtHcpj[i].isTouching)
				{
					position.x = xBRNyXRXsysdNperzXpLQXmtHcpj[i].positionX;
					position.y = xBRNyXRXsysdNperzXpLQXmtHcpj[i].positionY;
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
			YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] xBRNyXRXsysdNperzXpLQXmtHcpj = touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj;
			if (!xBRNyXRXsysdNperzXpLQXmtHcpj[index].isTouching)
			{
				return false;
			}
			positionX = xBRNyXRXsysdNperzXpLQXmtHcpj[index].positionAbsX;
			positionY = xBRNyXRXsysdNperzXpLQXmtHcpj[index].positionAbsY;
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
			if (!touchpads[0].GsLURatUIUplCESYptaZWyOBgXfU(touchId))
			{
				return false;
			}
			YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] xBRNyXRXsysdNperzXpLQXmtHcpj = touchpads[0].XBRNyXRXsysdNperzXpLQXmtHcpj;
			for (int i = 0; i < xBRNyXRXsysdNperzXpLQXmtHcpj.Length; i++)
			{
				if (xBRNyXRXsysdNperzXpLQXmtHcpj[i].isTouching)
				{
					positionX = xBRNyXRXsysdNperzXpLQXmtHcpj[i].positionAbsX;
					positionY = xBRNyXRXsysdNperzXpLQXmtHcpj[i].positionAbsY;
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
			YariILqxnsjqiHfcsACLJVmgutTl = 0;
			wfiDASDMXUzHXBDZVVMCKVaulubK = 0;
			XgFSrFwhuNieglOwKbzypnrDEXoGA();
			vKPacBYuEABAFiGsJOlgyMNiNzsQA = true;
			qjVAxbYNHUOZtzsNgKhqFlkGIIsf = true;
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
				vibrationMotors[i].OZyBFjtdbmGNdxlWalLBCWEMJQKG = 0;
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
				ZytMyQvAgfHsrCcprZFCWJmWLyXM[0] = effect;
				XgFSrFwhuNieglOwKbzypnrDEXoGA();
				USQavlErPWdGLhoSEGnmeGqgAwEte = true;
				return true;
			case DualSenseTriggerType.Right:
				ZytMyQvAgfHsrCcprZFCWJmWLyXM[1] = effect;
				XgFSrFwhuNieglOwKbzypnrDEXoGA();
				YooHNbSLwZWjBQsUacHdnhohdUXP = true;
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
				leftTrigger = SNoWRVswXMofoSqCsDnvjhmcJNdp[0],
				rightTrigger = SNoWRVswXMofoSqCsDnvjhmcJNdp[1]
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
			STgFaWnmdmPPEgLmmNXWOnwBeuOq = P_0.hidDevice;
			sWRMFjCGHSqTpKHEKSQWcEPIbErX = STgFaWnmdmPPEgLmmNXWOnwBeuOq.properties;
			lfrYzLVAlqAoruNYkGRZmeXIeEMW = P_0.hatZeroValue;
			vkBhIzywzkGJaNNvesFuqUPeUkMe = P_0.hatSpan;
			SOKgbuZAHkUhhlLrBLtMHsbLWQeT = P_0.connectionType == RWcHFhaLOdObDBlAnlGahPsMjmIp.Bluetooth;
			if (SOKgbuZAHkUhhlLrBLtMHsbLWQeT)
			{
				fqtHBGhGKUJCcLggsSKxryxrJMfc = 78;
			}
			else
			{
				fqtHBGhGKUJCcLggsSKxryxrJMfc = 48;
			}
			lPIqfOSdBXpFtEkiiWxPnYvfkDir = new NativeBuffer(64);
			JhKdkqzyFndViZwJqJYTGvLuqhiM = new NativeBuffer(fqtHBGhGKUJCcLggsSKxryxrJMfc);
			eLemdSzizHeXShkgXXRUUwAcOQSFA = new fSMyuzvVmAACQsIYyLcgNLStbZVN(JhKdkqzyFndViZwJqJYTGvLuqhiM.Pointer, JhKdkqzyFndViZwJqJYTGvLuqhiM.Length, fqtHBGhGKUJCcLggsSKxryxrJMfc);
			lights = new ynsNWLqHUfktHdifyKAAkOjoGzXj[1]
			{
				new ynsNWLqHUfktHdifyKAAkOjoGzXj(11, 24, 28)
			};
			lights[0].TeuAgAnGMXibjdWBvyDVpORKtNep += emmWrGNIQilbjBLSVIXHDzqRlhxL;
			vibrationMotors = new zjaGFxWobEvzfkfnDIafHMDeSyQp[2]
			{
				new zjaGFxWobEvzfkfnDIafHMDeSyQp(0, 255),
				new zjaGFxWobEvzfkfnDIafHMDeSyQp(0, 255)
			};
			vibrationMotors[0].YeWjEpYFmiaErkTfuJQxcFREviDXA += vKIXQKdsHpHpfvMHdizbVSMTJpLe;
			vibrationMotors[1].YeWjEpYFmiaErkTfuJQxcFREviDXA += vKIXQKdsHpHpfvMHdizbVSMTJpLe;
			KaFedhIZXsTburlXZavLAvDIDefmA = DualSenseVibrationMode.Compatible2;
			DLIfjRGAgFDMrTlsnbbLlTEaKZXJA = true;
			USQavlErPWdGLhoSEGnmeGqgAwEte = true;
			YooHNbSLwZWjBQsUacHdnhohdUXP = true;
			ZayRhcKrlWjcCnIdAYXbrgtHixEu = true;
			JjZPQjtRShpvxFHXQcqmnfMytSuD = true;
			chdTvjttvNLSstBiGSALqfOxrUJb = true;
			qjVAxbYNHUOZtzsNgKhqFlkGIIsf = true;
			ORIdOnjNgafiDJMkujMJkfwCLAcJ = true;
			ZwzxBsRlDUslnpYjtjLAoBCYRhSn = true;
			fKnDGYMsOyupitIJMziBMIHWWAJU = 2;
			if (SOKgbuZAHkUhhlLrBLtMHsbLWQeT)
			{
				byte[] hidFeatureData = STgFaWnmdmPPEgLmmNXWOnwBeuOq.GetHidFeatureData(5, 41, 1000, 3);
				iUBeNndnANgZIecxRQCrixkHQRfwB = hidFeatureData != null && hidFeatureData.Length != 0;
				if (iUBeNndnANgZIecxRQCrixkHQRfwB)
				{
					diXbyFeBnpzEIgEvQYYQkMQiavJL(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous);
				}
			}
			else
			{
				iUBeNndnANgZIecxRQCrixkHQRfwB = true;
				iUBeNndnANgZIecxRQCrixkHQRfwB = diXbyFeBnpzEIgEvQYYQkMQiavJL(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous);
			}
			if (!iUBeNndnANgZIecxRQCrixkHQRfwB)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			xYGrWQMRfUwOXLqpLLRorefxJGgP = 1;
			IjDcrqhMujoeZrogYOtFeJNNNIPrA = 0;
			if (SOKgbuZAHkUhhlLrBLtMHsbLWQeT && iUBeNndnANgZIecxRQCrixkHQRfwB)
			{
				xYGrWQMRfUwOXLqpLLRorefxJGgP = 49;
				IjDcrqhMujoeZrogYOtFeJNNNIPrA = 1;
			}
			VDxgbLNaOFLXuqVbIoBULRUKKPnd = 8 + IjDcrqhMujoeZrogYOtFeJNNNIPrA;
			qdHhRZaCsKNjjVqYQghQWWRSCHgK = 9 + IjDcrqhMujoeZrogYOtFeJNNNIPrA;
			RfKHRsRttskzyDOlWRBejcxyMtMo = 10 + IjDcrqhMujoeZrogYOtFeJNNNIPrA;
			buttons = new WLKCiIfkjEHrYQVDYJcKGKPTVxLS[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new WLKCiIfkjEHrYQVDYJcKGKPTVxLS(xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new dnWPfQfDfnEmaJKgzGFSEYqFnsqm[6]
			{
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new NrHOvbJwrZapXdtjKfrfNYbTfeqF[1]
			{
				new NrHOvbJwrZapXdtjKfrfNYbTfeqF(xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, VKtFFaFGrWMuZGcrARbdbdnechFYd)
			};
			accelerometers = new ghshtHzRELMvoutgmAIqgcgGRfGD[1]
			{
				new ghshtHzRELMvoutgmAIqgcgGRfGD(xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 48
				}, 3, mjvQbcSCCpWAFHrFyaQGhpdXCcKcA)
			};
			gyroscopes = new cAuwuHpmXWfmQkNNNMuQLAbjJQeRA[1]
			{
				new cAuwuHpmXWfmQkNNNMuQLAbjJQeRA(P_0.updateLoopSetting, xYGrWQMRfUwOXLqpLLRorefxJGgP, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 48
				}, 3, 60, sRgxUdFFbxZGfiaJnVXzmXKBDrCI, aTCdYYhmcWBQmsAoUjjIzZTvljCP)
			};
			touchpads = new YbNvcxfeAOXeGxhYaCCOmgMgdTsT[1]
			{
				new YbNvcxfeAOXeGxhYaCCOmgMgdTsT(xYGrWQMRfUwOXLqpLLRorefxJGgP, new YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + IjDcrqhMujoeZrogYOtFeJNNNIPrA,
					bitSize = 48
				}, 60, esRKdfelxrzEPOKpkhUjgAdzTveMA)
			};
			xTBABVEqUMhJlQRSnktyBcpALjTc = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			zHCjpVjFAeFOTiGUYhqRFxZnamoWA();
			NsoKSjhxdFkkLbzPJfilFhnCOFcP(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Asynchronous);
		}

		public unsafe override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < lPIqfOSdBXpFtEkiiWxPnYvfkDir.Length)
			{
				return false;
			}
			if (SOKgbuZAHkUhhlLrBLtMHsbLWQeT && iUBeNndnANgZIecxRQCrixkHQRfwB && *(byte*)(void*)inputReportPtr == 1)
			{
				return false;
			}
			YPFpeDrqJkDZGcCwIWDWguCLdoKWA = (float)(timestamp - xTBABVEqUMhJlQRSnktyBcpALjTc);
			xTBABVEqUMhJlQRSnktyBcpALjTc = timestamp;
			lPIqfOSdBXpFtEkiiWxPnYvfkDir.Write(inputReportPtr, inputReportLength, lPIqfOSdBXpFtEkiiWxPnYvfkDir.Length);
			HetmBuEFQYKMqAvVuqxGHYzqlVMV(lPIqfOSdBXpFtEkiiWxPnYvfkDir);
			dfPiQtoqEOpmiMcJjAevOYOdnuRS(lPIqfOSdBXpFtEkiiWxPnYvfkDir, timestamp);
			QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] array = axes;
			ULNZduVfHbCfHYWiIfRzhanBJagm(array, lPIqfOSdBXpFtEkiiWxPnYvfkDir, timestamp);
			array = hats;
			ULNZduVfHbCfHYWiIfRzhanBJagm(array, lPIqfOSdBXpFtEkiiWxPnYvfkDir, timestamp);
			array = accelerometers;
			ULNZduVfHbCfHYWiIfRzhanBJagm(array, lPIqfOSdBXpFtEkiiWxPnYvfkDir, timestamp);
			array = gyroscopes;
			ULNZduVfHbCfHYWiIfRzhanBJagm(array, lPIqfOSdBXpFtEkiiWxPnYvfkDir, timestamp);
			array = touchpads;
			ULNZduVfHbCfHYWiIfRzhanBJagm(array, lPIqfOSdBXpFtEkiiWxPnYvfkDir, timestamp);
			byte b = lPIqfOSdBXpFtEkiiWxPnYvfkDir[53 + IjDcrqhMujoeZrogYOtFeJNNNIPrA];
			mGKKchDTelXpmhRDuitSlcMTsdne mGKKchDTelXpmhRDuitSlcMTsdne2 = (mGKKchDTelXpmhRDuitSlcMTsdne)((b & 0xF0) >> 4);
			if (mGKKchDTelXpmhRDuitSlcMTsdne2 <= mGKKchDTelXpmhRDuitSlcMTsdne.Full)
			{
				if (mGKKchDTelXpmhRDuitSlcMTsdne2 > mGKKchDTelXpmhRDuitSlcMTsdne.Charging)
				{
					if (mGKKchDTelXpmhRDuitSlcMTsdne2 != mGKKchDTelXpmhRDuitSlcMTsdne.Full)
					{
						goto IL_0171;
					}
					gzkMODcxQoWUkvBORFlUbLTRNLmlA = 100;
					wZmUsRrPlvDdcdqMXVCyDLRVGlKuA = QWZVxCOclNRGgThZWBLpjOmMWYEr.Full;
				}
				else
				{
					gzkMODcxQoWUkvBORFlUbLTRNLmlA = MathTools.Clamp((b & 0xF) * 10 + 5, 0, 100);
					wZmUsRrPlvDdcdqMXVCyDLRVGlKuA = ((mGKKchDTelXpmhRDuitSlcMTsdne2 != mGKKchDTelXpmhRDuitSlcMTsdne.Charging) ? QWZVxCOclNRGgThZWBLpjOmMWYEr.Discharging : QWZVxCOclNRGgThZWBLpjOmMWYEr.Charging);
				}
			}
			else
			{
				if (mGKKchDTelXpmhRDuitSlcMTsdne2 - 10 > mGKKchDTelXpmhRDuitSlcMTsdne.Charging)
				{
					if (mGKKchDTelXpmhRDuitSlcMTsdne2 == mGKKchDTelXpmhRDuitSlcMTsdne.ChargingError)
					{
					}
					goto IL_0171;
				}
				gzkMODcxQoWUkvBORFlUbLTRNLmlA = 0;
				wZmUsRrPlvDdcdqMXVCyDLRVGlKuA = QWZVxCOclNRGgThZWBLpjOmMWYEr.Charging;
			}
			goto IL_017f;
			IL_0171:
			gzkMODcxQoWUkvBORFlUbLTRNLmlA = 0;
			wZmUsRrPlvDdcdqMXVCyDLRVGlKuA = QWZVxCOclNRGgThZWBLpjOmMWYEr.Unknown;
			goto IL_017f;
			IL_017f:
			JZIPPmmerQGnqevUUNzwRRHVfgeh = (lPIqfOSdBXpFtEkiiWxPnYvfkDir[54 + IjDcrqhMujoeZrogYOtFeJNNNIPrA] & 1) != 0;
			SNoWRVswXMofoSqCsDnvjhmcJNdp[0] = oVbrfhWBTPFwWpppAzRKkktedvAI(DualSenseTriggerType.Left, lPIqfOSdBXpFtEkiiWxPnYvfkDir[43 + IjDcrqhMujoeZrogYOtFeJNNNIPrA], lPIqfOSdBXpFtEkiiWxPnYvfkDir[48 + IjDcrqhMujoeZrogYOtFeJNNNIPrA]);
			SNoWRVswXMofoSqCsDnvjhmcJNdp[1] = oVbrfhWBTPFwWpppAzRKkktedvAI(DualSenseTriggerType.Right, lPIqfOSdBXpFtEkiiWxPnYvfkDir[42 + IjDcrqhMujoeZrogYOtFeJNNNIPrA], lPIqfOSdBXpFtEkiiWxPnYvfkDir[48 + IjDcrqhMujoeZrogYOtFeJNNNIPrA]);
			CiifZDbHqtLNilzQvpaIacWBgcetA();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void NsoKSjhxdFkkLbzPJfilFhnCOFcP(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_0)
		{
			if (jhHMCEbaAfZUTMtggPCISIgLMzNc)
			{
				diXbyFeBnpzEIgEvQYYQkMQiavJL(P_0);
				jhHMCEbaAfZUTMtggPCISIgLMzNc = false;
			}
		}

		private bool diXbyFeBnpzEIgEvQYYQkMQiavJL(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_0)
		{
			GFOWALZGXqTaxcjjnfUkenSGfRVF();
			bool result = QBRFuABMMoGTyILtOGtowyGDoCaNA(P_0);
			if (vKPacBYuEABAFiGsJOlgyMNiNzsQA)
			{
				result = QBRFuABMMoGTyILtOGtowyGDoCaNA(P_0);
				vKPacBYuEABAFiGsJOlgyMNiNzsQA = false;
			}
			return result;
		}

		private void GFOWALZGXqTaxcjjnfUkenSGfRVF()
		{
			if (SOKgbuZAHkUhhlLrBLtMHsbLWQeT && iUBeNndnANgZIecxRQCrixkHQRfwB)
			{
				JhKdkqzyFndViZwJqJYTGvLuqhiM[0] = 49;
				JhKdkqzyFndViZwJqJYTGvLuqhiM[1] = 2;
				xALmURoCAuCYqCfxNvIVtvRFKloFb(JhKdkqzyFndViZwJqJYTGvLuqhiM, 2);
				uint num = NVlzgRyrjPoNhgRbNtFVqOfzfUCY(JhKdkqzyFndViZwJqJYTGvLuqhiM, 74);
				JhKdkqzyFndViZwJqJYTGvLuqhiM[74] = (byte)(num & 0xFF);
				JhKdkqzyFndViZwJqJYTGvLuqhiM[75] = (byte)((num & 0xFF00) >> 8);
				JhKdkqzyFndViZwJqJYTGvLuqhiM[76] = (byte)((num & 0xFF0000) >> 16);
				JhKdkqzyFndViZwJqJYTGvLuqhiM[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				JhKdkqzyFndViZwJqJYTGvLuqhiM[0] = 2;
				xALmURoCAuCYqCfxNvIVtvRFKloFb(JhKdkqzyFndViZwJqJYTGvLuqhiM, 1);
			}
		}

		private void xALmURoCAuCYqCfxNvIVtvRFKloFb(NativeBuffer P_0, int P_1)
		{
			BzqenUzBDPaRSGxXxkRHQmmrKGbuA bzqenUzBDPaRSGxXxkRHQmmrKGbuA = BzqenUzBDPaRSGxXxkRHQmmrKGbuA.None;
			wQkbwEDmluqICRHnMlDFzZRvAmyA wQkbwEDmluqICRHnMlDFzZRvAmyA2 = wQkbwEDmluqICRHnMlDFzZRvAmyA.None;
			bzqenUzBDPaRSGxXxkRHQmmrKGbuA |= BzqenUzBDPaRSGxXxkRHQmmrKGbuA.HapticsSelect;
			if (KaFedhIZXsTburlXZavLAvDIDefmA == DualSenseVibrationMode.Compatible)
			{
				bzqenUzBDPaRSGxXxkRHQmmrKGbuA |= BzqenUzBDPaRSGxXxkRHQmmrKGbuA.CompatibleVibrationMode1;
			}
			DLIfjRGAgFDMrTlsnbbLlTEaKZXJA = false;
			bzqenUzBDPaRSGxXxkRHQmmrKGbuA |= BzqenUzBDPaRSGxXxkRHQmmrKGbuA.LeftTriggerEffect;
			USQavlErPWdGLhoSEGnmeGqgAwEte = false;
			bzqenUzBDPaRSGxXxkRHQmmrKGbuA |= BzqenUzBDPaRSGxXxkRHQmmrKGbuA.RightTriggerEffect;
			YooHNbSLwZWjBQsUacHdnhohdUXP = false;
			wQkbwEDmluqICRHnMlDFzZRvAmyA2 |= wQkbwEDmluqICRHnMlDFzZRvAmyA.MicrophoneLEDControl;
			ZayRhcKrlWjcCnIdAYXbrgtHixEu = false;
			wQkbwEDmluqICRHnMlDFzZRvAmyA2 |= wQkbwEDmluqICRHnMlDFzZRvAmyA.PlayerIndicatorLEDControl;
			JjZPQjtRShpvxFHXQcqmnfMytSuD = false;
			wQkbwEDmluqICRHnMlDFzZRvAmyA2 |= wQkbwEDmluqICRHnMlDFzZRvAmyA.LightbarControl;
			qjVAxbYNHUOZtzsNgKhqFlkGIIsf = false;
			wQkbwEDmluqICRHnMlDFzZRvAmyA2 |= wQkbwEDmluqICRHnMlDFzZRvAmyA.ChangeOverallMotorEffectPower;
			ZwzxBsRlDUslnpYjtjLAoBCYRhSn = false;
			P_0[P_1] = (byte)bzqenUzBDPaRSGxXxkRHQmmrKGbuA;
			P_0[1 + P_1] = (byte)wQkbwEDmluqICRHnMlDFzZRvAmyA2;
			P_0[2 + P_1] = (byte)vibrationMotors[1].OZyBFjtdbmGNdxlWalLBCWEMJQKG;
			P_0[3 + P_1] = (byte)vibrationMotors[0].OZyBFjtdbmGNdxlWalLBCWEMJQKG;
			P_0[8 + P_1] = (byte)azWatqLlknXqjvozdjiSLFQDAgNw;
			DfOhcKGhFtoDRqkJhDOhNigcvEOn dfOhcKGhFtoDRqkJhDOhNigcvEOn = DfOhcKGhFtoDRqkJhDOhNigcvEOn.None;
			dfOhcKGhFtoDRqkJhDOhNigcvEOn |= DfOhcKGhFtoDRqkJhDOhNigcvEOn.OtherLightBrightnessControl;
			chdTvjttvNLSstBiGSALqfOxrUJb = false;
			if (KaFedhIZXsTburlXZavLAvDIDefmA == DualSenseVibrationMode.Compatible2)
			{
				dfOhcKGhFtoDRqkJhDOhNigcvEOn |= DfOhcKGhFtoDRqkJhDOhNigcvEOn.CompatibleVibrationMode2;
			}
			dfOhcKGhFtoDRqkJhDOhNigcvEOn |= DfOhcKGhFtoDRqkJhDOhNigcvEOn.LightbarSetupControl;
			ORIdOnjNgafiDJMkujMJkfwCLAcJ = false;
			P_0[38 + P_1] = (byte)dfOhcKGhFtoDRqkJhDOhNigcvEOn;
			P_0[41 + P_1] = fKnDGYMsOyupitIJMziBMIHWWAJU;
			P_0[42 + P_1] = (byte)GeYUfJnssjHUypinzobhIsYeDrSW;
			P_0[43 + P_1] = (byte)TrhekBDiWRYcsybFBxCUhVNfDUbp;
			if (BqlukuOEDdgfCxveezmyOYojPUYA)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[44 + P_1] = lights[0].mBcGJswVLOnTinvvOlCNUxHLUMIN;
			P_0[45 + P_1] = lights[0].kIAhQAlGFQuDKowPUabgZjXgBlcV;
			P_0[46 + P_1] = lights[0].OEydJgYetgIWftEcdQvalqXIIXGw;
			RaUTuFwBPpMBXNJHspcHDoLWlLep(ref ZytMyQvAgfHsrCcprZFCWJmWLyXM[1], P_0, 10 + P_1);
			RaUTuFwBPpMBXNJHspcHDoLWlLep(ref ZytMyQvAgfHsrCcprZFCWJmWLyXM[0], P_0, 21 + P_1);
			P_0[36 + P_1] = 0;
		}

		private void RaUTuFwBPpMBXNJHspcHDoLWlLep(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
			if (P_0 == null)
			{
				P_1[P_2] = 0;
				return;
			}
			switch (P_0.triggerEffectType)
			{
			case DualSenseTriggerEffectType.Off:
				LraIesgjLkWCnpxpsrTyoIfLKpxC.VZIvFafjBhNESYRfmsEBxQBcygxU.RsfGbFnHcRBXRLgJLFbJMnkZnbLV(eDdiAbzgKcDIHyDdZHwgbEbiCuDXA, 0);
				break;
			case DualSenseTriggerEffectType.Feedback:
			{
				DualSenseTriggerEffectFeedback dualSenseTriggerEffectFeedback = (DualSenseTriggerEffectFeedback)(object)P_0;
				LraIesgjLkWCnpxpsrTyoIfLKpxC.VZIvFafjBhNESYRfmsEBxQBcygxU.hjnNXdtNFOCvKByRNSJiphhiJhyh(eDdiAbzgKcDIHyDdZHwgbEbiCuDXA, 0, dualSenseTriggerEffectFeedback.position, dualSenseTriggerEffectFeedback.strength);
				break;
			}
			case DualSenseTriggerEffectType.Weapon:
			{
				DualSenseTriggerEffectWeapon dualSenseTriggerEffectWeapon = (DualSenseTriggerEffectWeapon)(object)P_0;
				LraIesgjLkWCnpxpsrTyoIfLKpxC.VZIvFafjBhNESYRfmsEBxQBcygxU.dKCmGOLlAkrFpQlFpAcADUwIBZQl(eDdiAbzgKcDIHyDdZHwgbEbiCuDXA, 0, dualSenseTriggerEffectWeapon.startPosition, dualSenseTriggerEffectWeapon.endPosition, dualSenseTriggerEffectWeapon.strength);
				break;
			}
			case DualSenseTriggerEffectType.Vibration:
			{
				DualSenseTriggerEffectVibration dualSenseTriggerEffectVibration = (DualSenseTriggerEffectVibration)(object)P_0;
				LraIesgjLkWCnpxpsrTyoIfLKpxC.VZIvFafjBhNESYRfmsEBxQBcygxU.ZenVvpLKgvDcupNVpYmYLlqpfoou(eDdiAbzgKcDIHyDdZHwgbEbiCuDXA, 0, dualSenseTriggerEffectVibration.position, dualSenseTriggerEffectVibration.amplitude, dualSenseTriggerEffectVibration.frequency);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionFeedback:
				((DualSenseTriggerEffectMultiplePositionFeedback)(object)P_0).strength.CopyTo(gbklCFcTarUKWtxSnZvjSXJNjLZK);
				LraIesgjLkWCnpxpsrTyoIfLKpxC.VZIvFafjBhNESYRfmsEBxQBcygxU.lwCCorOdxIoYBiQeqyaMHIOguYBd(eDdiAbzgKcDIHyDdZHwgbEbiCuDXA, 0, gbklCFcTarUKWtxSnZvjSXJNjLZK);
				break;
			case DualSenseTriggerEffectType.SlopeFeedback:
			{
				DualSenseTriggerEffectSlopeFeedback dualSenseTriggerEffectSlopeFeedback = (DualSenseTriggerEffectSlopeFeedback)(object)P_0;
				LraIesgjLkWCnpxpsrTyoIfLKpxC.VZIvFafjBhNESYRfmsEBxQBcygxU.vlsCwqWLXlbhvswYYlCEQoUlrRcL(eDdiAbzgKcDIHyDdZHwgbEbiCuDXA, 0, dualSenseTriggerEffectSlopeFeedback.startPosition, dualSenseTriggerEffectSlopeFeedback.endPosition, dualSenseTriggerEffectSlopeFeedback.startStrength, dualSenseTriggerEffectSlopeFeedback.endStrength);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionVibration:
			{
				DualSenseTriggerEffectMultiplePositionVibration dualSenseTriggerEffectMultiplePositionVibration = (DualSenseTriggerEffectMultiplePositionVibration)(object)P_0;
				dualSenseTriggerEffectMultiplePositionVibration.amplitude.CopyTo(gbklCFcTarUKWtxSnZvjSXJNjLZK);
				LraIesgjLkWCnpxpsrTyoIfLKpxC.VZIvFafjBhNESYRfmsEBxQBcygxU.NaftMqqOPjEqwRdIogOsfnWFWTOlA(eDdiAbzgKcDIHyDdZHwgbEbiCuDXA, 0, dualSenseTriggerEffectMultiplePositionVibration.frequency, gbklCFcTarUKWtxSnZvjSXJNjLZK);
				break;
			}
			default:
				Logger.LogWarning("Unknown trigger effect type: 0x" + ((byte)P_0.triggerEffectType).ToString("x2"));
				return;
			}
			P_1.Write(eDdiAbzgKcDIHyDdZHwgbEbiCuDXA, eDdiAbzgKcDIHyDdZHwgbEbiCuDXA.Length, P_2);
		}

		private bool QBRFuABMMoGTyILtOGtowyGDoCaNA(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_0)
		{
			sTiESTwOZyJoIiPFwpEoYymzFXmr = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous:
				return STgFaWnmdmPPEgLmmNXWOnwBeuOq.WriteSync(eLemdSzizHeXShkgXXRUUwAcOQSFA, 0);
			case UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Asynchronous:
				STgFaWnmdmPPEgLmmNXWOnwBeuOq.WriteAsync(eLemdSzizHeXShkgXXRUUwAcOQSFA, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void dfPiQtoqEOpmiMcJjAevOYOdnuRS(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[VDxgbLNaOFLXuqVbIoBULRUKKPnd];
			buttons[0].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x10) != 0, P_1);
			buttons[1].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x20) != 0, P_1);
			buttons[2].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x40) != 0, P_1);
			buttons[3].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x80) != 0, P_1);
			b = P_0[qdHhRZaCsKNjjVqYQghQWWRSCHgK];
			buttons[4].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 1) != 0, P_1);
			buttons[5].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 2) != 0, P_1);
			buttons[6].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 4) != 0, P_1);
			buttons[7].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 8) != 0, P_1);
			buttons[8].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x10) != 0, P_1);
			buttons[9].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x20) != 0, P_1);
			buttons[10].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x40) != 0, P_1);
			buttons[11].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 0x80) != 0, P_1);
			b = P_0[RfKHRsRttskzyDOlWRBejcxyMtMo];
			buttons[12].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 1) != 0, P_1);
			buttons[13].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 2) != 0, P_1);
			if (iUBeNndnANgZIecxRQCrixkHQRfwB)
			{
				buttons[14].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & 4) != 0, P_1);
			}
		}

		private void ULNZduVfHbCfHYWiIfRzhanBJagm(QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].zlNHwfexPeybhRZVfQjgkewMqYcH(P_1, P_2);
			}
		}

		private void zHCjpVjFAeFOTiGUYhqRFxZnamoWA()
		{
			if (isVibrating && ReInput.realTime >= sTiESTwOZyJoIiPFwpEoYymzFXmr)
			{
				XgFSrFwhuNieglOwKbzypnrDEXoGA();
				DLIfjRGAgFDMrTlsnbbLlTEaKZXJA = true;
			}
		}

		private void HetmBuEFQYKMqAvVuqxGHYzqlVMV(NativeBuffer P_0)
		{
			if (iUBeNndnANgZIecxRQCrixkHQRfwB)
			{
				uint num = lPIqfOSdBXpFtEkiiWxPnYvfkDir.ReadUInt(28 + IjDcrqhMujoeZrogYOtFeJNNNIPrA);
				float num3;
				if (num != BhzPXhYFKWwKhKOYizoyFpBqvRKj)
				{
					uint num2 = (uint)((num >= BhzPXhYFKWwKhKOYizoyFpBqvRKj) ? (num - BhzPXhYFKWwKhKOYizoyFpBqvRKj) : ((long)num + 4294967295L - BhzPXhYFKWwKhKOYizoyFpBqvRKj));
					num3 = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					num3 = 0f;
				}
				BhzPXhYFKWwKhKOYizoyFpBqvRKj = num;
				zSlfNsYqhdoEZRDfNcZOgJVMTOyOA = num3;
			}
		}

		private void CiifZDbHqtLNilzQvpaIacWBgcetA()
		{
			if (iUBeNndnANgZIecxRQCrixkHQRfwB && !(zSlfNsYqhdoEZRDfNcZOgJVMTOyOA <= 0f))
			{
				Vector3 vector = vymdPoCCMGoraIyYAYNbJXwXSlMK(new Vector3(gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[0], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[1], gyroscopes[0].IVCIwqzCZCRIMBSpxbQzdmcskYFN[2]), zSlfNsYqhdoEZRDfNcZOgJVMTOyOA);
				TpQMSRXYsjUAVFOARpbhunacJCSy(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[0] * -1f, accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[1] * -1f, accelerometers[0].JLwYhuHtTQDoTLjyTSPTHSWTgggN[2] * -1f);
				tmNePzHYwkeGrJEwJCGVbjIagvOnc(vector2, vector);
			}
		}

		private static bool TpQMSRXYsjUAVFOARpbhunacJCSy(ref Vector3 P_0)
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

		private void tmNePzHYwkeGrJEwJCGVbjIagvOnc(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && dURacRhgfxRCiYtzcXPBArJzqxMw(P_0, out var yHuGERKUfNggUjhXCxHISBMtRbHBb2))
			{
				Quaternion a = oClGlWpZeKbBYGYLObTmXLhfiHcD * quaternion;
				if (!gxGjFdVybUSkRdvETIrFKZNRBwGT)
				{
					gxGjFdVybUSkRdvETIrFKZNRBwGT = true;
					CSAyKwALJWTqXGvCThSjRxYdaMzk = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					ilfLcgWGlFFyccyGlNRBMcwkPzbhb = oClGlWpZeKbBYGYLObTmXLhfiHcD;
				}
				CSAyKwALJWTqXGvCThSjRxYdaMzk *= quaternion;
				ilfLcgWGlFFyccyGlNRBMcwkPzbhb *= quaternion;
				Quaternion b;
				if ((yHuGERKUfNggUjhXCxHISBMtRbHBb2 & yHuGERKUfNggUjhXCxHISBMtRbHBb.XZ) != yHuGERKUfNggUjhXCxHISBMtRbHBb.None)
				{
					b = lVzIluPyUjqdIOouTZCTwAeEeRGU(P_0, a.eulerAngles.y);
				}
				else if ((yHuGERKUfNggUjhXCxHISBMtRbHBb2 & yHuGERKUfNggUjhXCxHISBMtRbHBb.Y) != yHuGERKUfNggUjhXCxHISBMtRbHBb.None)
				{
					b = wYyJBsxgftCnSiwcUpzNuauoipSQ(P_0);
					Vector3 vector = ilfLcgWGlFFyccyGlNRBMcwkPzbhb * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				oClGlWpZeKbBYGYLObTmXLhfiHcD = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				oClGlWpZeKbBYGYLObTmXLhfiHcD *= quaternion;
				if (gxGjFdVybUSkRdvETIrFKZNRBwGT)
				{
					gxGjFdVybUSkRdvETIrFKZNRBwGT = false;
				}
			}
		}

		private static Quaternion GSKgeeaOgAImzWAbDazHxKssUTbfA(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = vMnFAoCagRWImXRVFsDmVeVfYMMd(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 vMnFAoCagRWImXRVFsDmVeVfYMMd(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion QGDlRKSctZtNAmnQTPBkSaYUTGmd(Quaternion P_0, wFJJCGbdzCEjjvhGTLYAJxLArleq P_1)
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

		private float JbJCecRebkgnzKhatIxjwZZqBfMb(float P_0, float P_1)
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

		private Vector3 SwITPoHpLuSusLprdVuZMtxYpJkq(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion lVzIluPyUjqdIOouTZCTwAeEeRGU(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion wYyJBsxgftCnSiwcUpzNuauoipSQ(Vector3 P_0, float P_1 = 0f)
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

		private float GEjpUghJYJJKRcYyTFTBiegwfVVK(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool BmbIvthfcQhwYhRVbHyIBJuenZymc(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool dURacRhgfxRCiYtzcXPBArJzqxMw(Vector3 P_0, out yHuGERKUfNggUjhXCxHISBMtRbHBb P_1)
		{
			P_0.Normalize();
			P_1 = yHuGERKUfNggUjhXCxHISBMtRbHBb.None;
			bool result = false;
			if (xwvxpZCcmgGwKkxSkKMxZumzKaOR(P_0))
			{
				result = true;
				P_1 |= yHuGERKUfNggUjhXCxHISBMtRbHBb.XZ;
			}
			if (jvGddLDygBOrJDlwEXdfJMZxjajw(P_0))
			{
				result = true;
				P_1 |= yHuGERKUfNggUjhXCxHISBMtRbHBb.Y;
			}
			return result;
		}

		private bool xwvxpZCcmgGwKkxSkKMxZumzKaOR(Vector3 P_0)
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

		private bool jvGddLDygBOrJDlwEXdfJMZxjajw(Vector3 P_0)
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

		private Vector3 fMQNouTNkbVECvyyWLzkBcJSelvr(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 CktwRiuvslEGuybpELQpprnXwkmk(RingBuffer<cAuwuHpmXWfmQkNNNMuQLAbjJQeRA.arYEtUbayhJFeNamRRUDkYiZuhbN> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				cAuwuHpmXWfmQkNNNMuQLAbjJQeRA.arYEtUbayhJFeNamRRUDkYiZuhbN arYEtUbayhJFeNamRRUDkYiZuhbN = P_0[i];
				result += vymdPoCCMGoraIyYAYNbJXwXSlMK(arYEtUbayhJFeNamRRUDkYiZuhbN.IDEGgrKerbltszPxPYPGbtdsLRqgA, arYEtUbayhJFeNamRRUDkYiZuhbN.kGcGjoXESWeZAMcMRhPtzqsCrots);
			}
			return result;
		}

		private Vector3 vymdPoCCMGoraIyYAYNbJXwXSlMK(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int VKtFFaFGrWMuZGcrARbdbdnechFYd(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void mjvQbcSCCpWAFHrFyaQGhpdXCcKcA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void sRgxUdFFbxZGfiaJnVXzmXKBDrCI(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float aTCdYYhmcWBQmsAoUjjIzZTvljCP()
		{
			return zSlfNsYqhdoEZRDfNcZOgJVMTOyOA;
		}

		private void esRKdfelxrzEPOKpkhUjgAdzTveMA(NativeBuffer P_0, YbNvcxfeAOXeGxhYaCCOmgMgdTsT.TouchData[] P_1)
		{
			int num = 33 + IjDcrqhMujoeZrogYOtFeJNNNIPrA;
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
			P_1[0].touchId = AwHKAlPiWVlXkrbRivhJuVMwOhNk(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = AwHKAlPiWVlXkrbRivhJuVMwOhNk(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int AwHKAlPiWVlXkrbRivhJuVMwOhNk(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				JTJaipwTeweYANceYawvaWeWvPqF[P_0] = -1;
				kHoanjJImMGHNfTUseaIOJuzauqyA[P_0] = P_2;
				return -1;
			}
			if (P_2 != kHoanjJImMGHNfTUseaIOJuzauqyA[P_0])
			{
				int num = jiMeznnPOnBAHbzlqYOUkoRVLvBZA;
				if (jiMeznnPOnBAHbzlqYOUkoRVLvBZA == int.MaxValue)
				{
					jiMeznnPOnBAHbzlqYOUkoRVLvBZA = 0;
				}
				else
				{
					jiMeznnPOnBAHbzlqYOUkoRVLvBZA++;
				}
				kHoanjJImMGHNfTUseaIOJuzauqyA[P_0] = P_2;
				JTJaipwTeweYANceYawvaWeWvPqF[P_0] = num;
				return num;
			}
			return JTJaipwTeweYANceYawvaWeWvPqF[P_0];
		}

		private void emmWrGNIQilbjBLSVIXHDzqRlhxL()
		{
			qjVAxbYNHUOZtzsNgKhqFlkGIIsf = true;
			XgFSrFwhuNieglOwKbzypnrDEXoGA();
		}

		private void IjaIgLOiMlWgBzDlOWXxvsnaAMUL()
		{
			qjVAxbYNHUOZtzsNgKhqFlkGIIsf = true;
			XgFSrFwhuNieglOwKbzypnrDEXoGA();
		}

		private void vKIXQKdsHpHpfvMHdizbVSMTJpLe()
		{
			DLIfjRGAgFDMrTlsnbbLlTEaKZXJA = true;
			XgFSrFwhuNieglOwKbzypnrDEXoGA();
		}

		private void XgFSrFwhuNieglOwKbzypnrDEXoGA()
		{
			jhHMCEbaAfZUTMtggPCISIgLMzNc = true;
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
				NsoKSjhxdFkkLbzPJfilFhnCOFcP(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous);
				if (lPIqfOSdBXpFtEkiiWxPnYvfkDir != null)
				{
					lPIqfOSdBXpFtEkiiWxPnYvfkDir.Dispose();
				}
				if (JhKdkqzyFndViZwJqJYTGvLuqhiM != null)
				{
					JhKdkqzyFndViZwJqJYTGvLuqhiM.Dispose();
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

		private static uint NVlzgRyrjPoNhgRbNtFVqOfzfUCY(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = qkSSKBNJveUSDAtvxsVJRrTSjoju[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static hyhijesAbyBSHizJHfRSRVfnDthH fHJXwWUcCaIbKbnepRCHaMFIssHz(DualSenseOtherLightBrightness P_0)
		{
			return P_0 switch
			{
				DualSenseOtherLightBrightness.High => hyhijesAbyBSHizJHfRSRVfnDthH.High, 
				DualSenseOtherLightBrightness.Medium => hyhijesAbyBSHizJHfRSRVfnDthH.Medium, 
				DualSenseOtherLightBrightness.Low => hyhijesAbyBSHizJHfRSRVfnDthH.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static DualSenseOtherLightBrightness KkhFgtQjuKPplCORVzfjOzCOEEaW(hyhijesAbyBSHizJHfRSRVfnDthH P_0)
		{
			return P_0 switch
			{
				hyhijesAbyBSHizJHfRSRVfnDthH.High => DualSenseOtherLightBrightness.High, 
				hyhijesAbyBSHizJHfRSRVfnDthH.Medium => DualSenseOtherLightBrightness.Medium, 
				hyhijesAbyBSHizJHfRSRVfnDthH.Low => DualSenseOtherLightBrightness.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static UHTbSvGnXcFeDPIQBmnjzmIBHJcy ZqxuGRfbODTAYNfZKwFIRchzviUJ(DualSenseTriggerType P_0, byte P_1)
		{
			byte b;
			switch (P_0)
			{
			case DualSenseTriggerType.Left:
				b = new owAAVjzCuHbXSlIjBivxHuHDkUfEb(P_1).CGdXtnBBWLdMznOlbOoRKhzetxWH;
				break;
			case DualSenseTriggerType.Right:
				b = new owAAVjzCuHbXSlIjBivxHuHDkUfEb(P_1).qHIjQryhsXGtxhpOzhOingWADkgF;
				break;
			default:
				return UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Off;
			}
			return b switch
			{
				0 => UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Off, 
				1 => UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Feedback, 
				2 => UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Weapon, 
				3 => UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Vibration, 
				4 => UHTbSvGnXcFeDPIQBmnjzmIBHJcy.SlopeFeedback, 
				_ => UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Off, 
			};
		}

		private static DualSenseTriggerEffectState oVbrfhWBTPFwWpppAzRKkktedvAI(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			byte b = new owAAVjzCuHbXSlIjBivxHuHDkUfEb(P_1).CGdXtnBBWLdMznOlbOoRKhzetxWH;
			return ZqxuGRfbODTAYNfZKwFIRchzviUJ(P_0, P_2) switch
			{
				UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Off => DualSenseTriggerEffectState.Off, 
				UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Feedback => b switch
				{
					0 => DualSenseTriggerEffectState.FeedbackIdle, 
					1 => DualSenseTriggerEffectState.FeedbackApplyingForce, 
					_ => DualSenseTriggerEffectState.FeedbackIdle, 
				}, 
				UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Weapon => b switch
				{
					0 => DualSenseTriggerEffectState.WeaponIdle, 
					1 => DualSenseTriggerEffectState.WeaponFiring, 
					2 => DualSenseTriggerEffectState.WeaponFired, 
					_ => DualSenseTriggerEffectState.WeaponIdle, 
				}, 
				UHTbSvGnXcFeDPIQBmnjzmIBHJcy.Vibration => b switch
				{
					0 => DualSenseTriggerEffectState.VibrationIdle, 
					1 => DualSenseTriggerEffectState.VibrationVibrating, 
					_ => DualSenseTriggerEffectState.VibrationIdle, 
				}, 
				UHTbSvGnXcFeDPIQBmnjzmIBHJcy.SlopeFeedback => b switch
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
