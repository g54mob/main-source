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
		private enum aXmfcIHhwQfJXiVHfzgIYCtTmxEaA
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum muHlxBSVgLCeiPQIBlLAEqkonOxL
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum QaebztGWAywShtzJxAVpToeSNXEFA : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum nkGuBosNiweifSHWfdDSHIZajFBlA : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum wXzRppHKQhtbEVkGCRUYoqASvuTS : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum OKeBqEcSaBXlOTzQyrjbckSVtCenA
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum VGBWvWxMBXxyuBOtPveTjWoeSpBe : byte
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

		private enum qQbPQaNrbloIipqKTxFTsOnMHYWP : byte
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

		private enum JfzRkAEGjrvbdMcCPyYjKIExIKcg : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct mmxXybtvxXhnoHWgvnZxdxlQOHJJ
		{
			private const string VZArPwvAjYGcUuuirvjYLlhnOcRy = "Value must be between 0 and 16.";

			public byte mDUhDcuIyFCxWbpKQdFozqtsbRAzA;

			public byte yxziKfkTfPDwXBTVRRFoqjuRfJWBA
			{
				get
				{
					return (byte)(mDUhDcuIyFCxWbpKQdFozqtsbRAzA & 0xF);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					mDUhDcuIyFCxWbpKQdFozqtsbRAzA = (byte)((MYWjstJKLLyDPPhyNqoTHiXhxrmk << 4) | (b & 0xF));
				}
			}

			public byte MYWjstJKLLyDPPhyNqoTHiXhxrmk
			{
				get
				{
					return (byte)(mDUhDcuIyFCxWbpKQdFozqtsbRAzA >> 4);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					mDUhDcuIyFCxWbpKQdFozqtsbRAzA = (byte)((b << 4) | yxziKfkTfPDwXBTVRRFoqjuRfJWBA);
				}
			}

			public mmxXybtvxXhnoHWgvnZxdxlQOHJJ(byte P_0)
			{
				mDUhDcuIyFCxWbpKQdFozqtsbRAzA = P_0;
			}

			public mmxXybtvxXhnoHWgvnZxdxlQOHJJ(byte P_0, byte P_1)
			{
				if (P_0 >= 16 || P_1 >= 16)
				{
					throw new ArithmeticException("Value must be between 0 and 16.");
				}
				mDUhDcuIyFCxWbpKQdFozqtsbRAzA = (byte)((P_1 << 4) | P_0);
			}
		}

		private static class RhPspkytqiogDRteCpNuhCqAlSBu
		{
			public enum BMqDnxCwfyawzGhQckMLLJMhuTZzb : byte
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

			public static class VnjComnkQbvwqwbkEgeHcTljhyVhA
			{
				public static class dPyyZGbwRPTvmYyqQFpRBLZBJfKl
				{
					public static bool pbOSAdANYBAZIzgQgWYRijtIrnlB(byte[] P_0, int P_1)
					{
						return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
					}

					public static bool hXwkrKLyVtTCAtrNsCdmBoiKjKKxA(byte[] P_0, int P_1, float P_2, float P_3)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						return fYxuzGhUMNagQhKrNiuVuPjODAvA(P_0, P_1, (byte)P_2, (byte)P_3);
					}

					public static bool eunhLpYrTlphfGiaanbUYNQGufQw(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						return htWjAQNJuQhZSsURoOISYGLBDirA(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool yAJvYgNimfkUapYmpcGTfMOadSGz(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						P_4 = (float)Math.Round(P_4 * 255f);
						return BCUIqfFzrdUvMHUMFCRIIREywrQH(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool iyvcfXwVJTJNwlCQSiiiYLpfukid(byte[] P_0, int P_1, float[] P_2)
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
						return vnpsfoUbiEpUwSZROBEMILwhGadW(P_0, P_1, array);
					}

					public static bool uUkFoIFUeSCDqABGdvgBPMtbtHRCc(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						P_5 = (float)Math.Round(P_5 * 8f);
						return fXPvXyGSWxsJVQLJuesEDBuwfzKX(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4, (byte)P_5);
					}

					public static bool cgBwHkEeZNYUfOcXFEzndOOqnrcab(byte[] P_0, int P_1, float[] P_2, float P_3)
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
						return VYEruPsGCdKEYxFnSwSiskOGDQyC(P_0, P_1, (byte)P_3, array);
					}
				}

				[Serializable]
				private sealed class VTveBGpsvNwowtbVVCnGlMJGZUgp
				{
					public static readonly VTveBGpsvNwowtbVVCnGlMJGZUgp _003C_003E9 = new VTveBGpsvNwowtbVVCnGlMJGZUgp();

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool MEbxMHEOcGKeimrRbLPdwUheLOnv(byte P_0)
					{
						return P_0 > 0;
					}

					internal bool DFXQMUWtdfDpAeBmmCnNBPAmtIvs(byte P_0)
					{
						return P_0 > 0;
					}
				}

				public static bool LwWchXCvtVMzzbpGelPVNVIkOtffB(byte[] P_0, int P_1)
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

				public static bool fYxuzGhUMNagQhKrNiuVuPjODAvA(byte[] P_0, int P_1, byte P_2, byte P_3)
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool htWjAQNJuQhZSsURoOISYGLBDirA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool BCUIqfFzrdUvMHUMFCRIIREywrQH(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool vnpsfoUbiEpUwSZROBEMILwhGadW(byte[] P_0, int P_1, byte[] P_2)
				{
					if (P_2.Length != 10)
					{
						return false;
					}
					if (P_2.Any(VTveBGpsvNwowtbVVCnGlMJGZUgp._003C_003E9.MEbxMHEOcGKeimrRbLPdwUheLOnv))
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool fXPvXyGSWxsJVQLJuesEDBuwfzKX(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
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
					return vnpsfoUbiEpUwSZROBEMILwhGadW(P_0, P_1, array);
				}

				public static bool VYEruPsGCdKEYxFnSwSiskOGDQyC(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					if (P_3.Length != 10)
					{
						return false;
					}
					if (P_2 > 0 && P_3.Any(VTveBGpsvNwowtbVVCnGlMJGZUgp._003C_003E9.DFXQMUWtdfDpAeBmmCnNBPAmtIvs))
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool reEMsvvpCXZkFEAqCebXcvoFiCDjA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool TThDHAHQLWKODMRNudtEBfldJDYwb(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool TDObhBzcpSaWhkXNXUfOQOqyVhkt(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool KnYIYHVQIZwXYkjMywztsqCWETdr(byte[] P_0, int P_1, byte P_2, byte P_3)
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

				public static bool YxuDblpKLoGrCDOmZcIbbFmNgudl(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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

				public static bool YsWMBthCFPZfjVHilBqqacDZjzGW(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool QUohfvpeyZnGEENBxaftDwaUmvOA(byte[] P_0, int P_1, byte P_2, byte P_3)
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}

				public static bool CyaAOCoFAqzidurlEeSVpopgJeGk(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return LwWchXCvtVMzzbpGelPVNVIkOtffB(P_0, P_1);
				}
			}
		}

		private const float hShotGmkKsdHQOWdpUSmzGXafvjH = 4f;

		private const int zJfUujnpPWWOGqktGUoaIljBnqqN = 15;

		private const int XrjeVdVFOnDLKNWLaEibIQyhAKmwA = 2;

		private const int kIrKmkntQpwUWEqJSGVWTJnfjhLDA = 0;

		private const int vHCRixjhRNhnIXyxiWgKBpyzzyqE = 1912;

		private const int rVxatHVvpJWBZEhMutmLNBELasdaA = 0;

		private const int UCwmMzcRcJbknszPFqYnEYQIkajk = 941;

		private const bool IUKihcrVwXBkBciLZwBRhiTYhpvj = false;

		private const bool NrzvrFZehOucoWdQvSqIwIIxmOOw = true;

		private const float aWjYCOiiXGIhLUePomdMQPjwvDRo = 2.5f;

		private const int yyWwqnhKCvbwvNJrXDqwZBdaWkVm = 0;

		private const int bzBmdvvqqmGfKxymUOzyMExYrnMB = 0;

		private const int itIxSQAhuROrvJzzdqWjtwUWjNWH = 1;

		private const int FsMCYUsQUCqyxuaUrrdrqhwePRCp = 0;

		private const int VSXGSiKWvQEoIhNfgHoszIhYhoBk = 0;

		private const int CNQDKKLIGIAyETDMNEsxHIfigbpWA = 0;

		private const int vOXTLEaTmkVFpapmaYqBSpMDCWPI = 1;

		private const int WPHaoJhlQoiIQbUPeYiJBFUgtpSOB = 49;

		private const int yUqBIwGjaMhqoFwViDThlPPdatirB = 0;

		private const int TQRXYYDvnXMfBCHPCNqSDeFlAVigA = 1;

		private const int cVkhxWlNtdXPuNwCmnQYbqOxBTEA = 64;

		private const int sRwcxWbIQmPxFKRyzSBRQzeGtwdNA = 48;

		private const int KinTLGGJdNddTAEmqfmhBfMkRUQr = 78;

		private const int skKGOrkxDYmnMaUHZdWdkVdRVVEY = 5;

		private const int YrYUPFHHSRGOAfJddgaZZlOisxfH = 41;

		private const byte ThvPaejpEuyavBoAyPYTDfwpkxmC = 1;

		private const byte zVStPZkYHUSjVtxqhbWdHJEaJiHR = 2;

		private const int pCumEYVIVxJiSwXBErhCFoixClkJ = 1;

		private const int AEHDJprbDBxHMiimJbDmyioJZTrW = 2;

		private const int lwMaBXpbUECDxQFlKxAolgWWIPdN = 3;

		private const int HhOLwFafhztPSOFDrENCOvXfFRYZ = 4;

		private const int SkDzEGRURyyiAuOBrbVTrmPnjWac = 5;

		private const int PLwhHrkrRoKPcCcZABMDCEDwtyYaA = 6;

		private const int mGTOHNCVBlIhalRfdfTHQBjZBWok = 8;

		private const int ATMmcTNjRezIYGnCliaiavqmLMtxA = 22;

		private const int oscxhxIHQcKgLIkHhbAAbWaDhTmaA = 16;

		private const int lNzzuRkRjOmnAgQcRxVISWkGQhwu = 33;

		private const int CJoQIDmIeXymugpnOYlaMAEKtPzy = 8;

		private const int czBuuxBKXALRZivUDeYmxuUejczS = 9;

		private const int KERQoKmKzEqAoGsJXwuaJAHjkoAU = 10;

		private const int dYnOwcraWvpTsDrYWotSlMaHQaSS = 28;

		private const int qiNVQbLGzSISSUCyBrSvfCvlpFlL = 53;

		private const int dgHLMYNZBFfuOtjRthopODFSGkNJ = 54;

		private const int eulTlVzhhTygEDXsqNqJtUSxKvfV = 43;

		private const int fSiSAcTcrVltFhJNsPthkKCkIIVDA = 42;

		private const int XxYODLLoTltYShTGhANoLPYKDkTF = 48;

		private const bool SJneNFLBtDxURiwAjGZmTGziajse = true;

		private const int THcrbJYHIglUcaUfsGdLEKSVEklJ = 60;

		private const int nGLvEpLbQSItnniGWDqoTluKMpEj = 60;

		private const int peTrugnQJdxDYfwfBoBHFbOZmihp = 3000000;

		private const float GdqGufXFLQRkEVWTnKBRuEpqPZVt = 8192f;

		private const float kkFholEsKrNRUkkaATeufpVBRCNl = 0.0010652969f;

		private const float jpGerkDEvwTbDuZfKqmmarbyWeQc = 0.06103702f;

		private const bool iLwoytuTvLEQvxVSQtxEmwbGlJlp = true;

		private const bool BxSeaCQcKBjkNpfTRGsBhlvnFQGW = true;

		private const bool ARhhVpvcuMIbcLywpjawZuKqqnJU = true;

		private const bool uyxznvVOmJtGaSgYeBlTeMboNUAqA = true;

		private const float FodMoiNhKTKYGtsviPHugAHxMmiE = 4096f;

		private const float JhUqxLdSzRriUGAORVRffeHCXJMB = 16384f;

		private const float YXmmwNDEAqCEuAlPTCJxrvhkIgpT = 16777216f;

		private const float ByOZzJtXcjinFBbueQsTAVZqiqfN = 268435460f;

		private const float mZOnOhPTjLHCPnrClNochpsIpkR = 0.01999998f;

		private const float aJLglxJfIFKbuqCBwOQddvOsbFDFA = 8192f;

		private const float lbPKIoamoGxszOjMSrlhcnOwBLkk = 0.98f;

		private const float UttEpoaaqcqfBCBAdCznDqWCpwFqC = 45f;

		private const float KaakahLMCqEPCtuyQhRJdBELEtYG = 20f;

		private const DualSenseVibrationMode BcqYmkJLtBWIqMmFLqcZZSoeMIfP = DualSenseVibrationMode.Compatible2;

		private readonly IHIDDevice YEJFbMnbsafroSXjQljEDgEEEkiN;

		private readonly HIDProperties aLqTzlSBACtQZmkBgFyYGlzBMWZDb;

		private readonly bool CptMRkVInoHWTJunrJbSYDSQKsIE;

		private readonly int dCWDUNHluseURDMXMkwJdtjhNUuOb;

		private readonly int fAiQMpiIpuGoEhbSYjWaZrqxmEwTA;

		private bool qowewrrsLLvdyKqytalbmpOPRbJj;

		private byte zEbfSXMcACyhfjintbBmudBkARGF;

		private int UCuIlwWqhvUNdCIzgTMRAJhYGijI;

		private int FvCsTHLhhPElxFKUqTKGDQjBrMJeA;

		private int qVwIKTuUrUlvBzeJmyQSJyfRArYk;

		private int BFzanuPuhmZEOlHyeptgqcFzbkwL;

		private readonly NativeBuffer nVhAMeEChZzHZylRABgJsFBkNHIh;

		private readonly NativeBuffer TzbyJsfwOxWdCnkIYBkVTwvjAxEBA;

		private dQrAZjxmvMRuuUvHYPSsKegoCJrCA sDoKIydaBLxydYthPtUMpoppIgKA;

		private int xfTmgDfGPQpfitMlILkQgYSekHqs;

		private bool pnGpfSvjzMkvogfaWuxIFooKkEFY;

		private bool tWyFdVSIPYyLbcGpvBLiHnbfddGJA;

		private double yENhiJkEKkSZkISQUcnyJcYgCHQw;

		private int uHlTXwbDedcQBNBhqZUWQhCNRMp;

		private OKeBqEcSaBXlOTzQyrjbckSVtCenA qHNPjPrEutaTWOMLjdkoiSbQspsuA;

		private bool VezieoupsAMoAYzByUhcICjYdfOKA;

		private Quaternion qWMrvbdlGIoVyiQTaMJqGcfujyWGA = Quaternion.identity;

		private DualSenseMicrophoneLightMode cplXAeHnvdeYJJkiBtTWQuuWhwzr;

		private nkGuBosNiweifSHWfdDSHIZajFBlA MehAoFdHdlfuSVJgHIVvRycnores;

		private DualSensePlayerLightFlags DMCREDLRuXWdWWGQfedSkUbeSKZh;

		private bool ZbZOZowjBZBOVTqkAbPifHkfkJaBb;

		private uint NACewxMTXWyWPkJLOnTyQclhrruS;

		private float zgIuyqMyqbsZxxgqvhNEKboFWhIG;

		private double hkcRzNQSpMnRDkcEHIQuFAQTqDRNA;

		private float CyTNVArOuxzmgiluTvSddiImgwRA;

		private readonly IDualSenseTriggerEffect[] PGjVUjIztwITiNaRVnSZdKHfitBA = new IDualSenseTriggerEffect[2];

		private readonly byte[] ezNbDDkIvrmVuTaTDjIdDVzObYxd = new byte[10];

		private readonly byte[] gEEhFrEhPiiypkQarJWceLTGdwbkb = new byte[11];

		private DualSenseTriggerEffectState[] CoDqJPuAWSGLYgePMfXxHkAzJRNY = new DualSenseTriggerEffectState[2];

		private DualSenseVibrationMode YcyYQfQEUwOBERuSpSVVufnPAyFcA;

		private byte vyShQYSHPeJjEFKheAuFFvGJKGdg;

		private bool XvxEaDUdhVDgZBQhLLRREdkngBtEA;

		private bool KOlAQjdOWSeBdWrZoJryNaOLeyZG;

		private bool SsHaqtgCbBHwtzsXKkWvDyIwFIhZ;

		private bool HhHbmsBYuQjVwENwiNszLaHKVhsSA;

		private bool JBugyllOGbxRBjQMgxCqwHNbYfCq;

		private bool yxMLkpxJgHqjuLRWgNmKzaRkdjeBA;

		private bool wosEjnIVAAJiFLXfSRikCVHDREMW;

		private bool IVtEUjcdfcGZlyzrMnLZqpWDxHIsA;

		private bool RGACsgXMCAlRRDEiPajIehmRoveOA;

		private byte GhCGZNqsguBXAdnbMsqDGUCjpkdbb;

		private byte qaFdCULFKUnPvhrIvauOFnMpxeJK;

		private Quaternion EQnAjcQMWEkGhmKDbZszSQcmWuFn = Quaternion.identity;

		private Quaternion mSYNilEuVXWYsKHPUdNVvOxuzFsA = Quaternion.identity;

		private bool uhnmRbTDiUULbRETzPxTPEjSiugJ;

		private int tefKAldvFlwpxRacOjaSdVhOBflr;

		private int[] JtiXLfkVpktmqrsdeUUdnPEXjlKjA = new int[2];

		private int[] kuHSGfNKfIFtfzCPUZQUKJKqNeKP = new int[2];

		private static uint[] uXvvMTBXaausjyqaPpMVAjlRyINf = new uint[256]
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

		private const uint MKzDToPhrtTTYNLkmUzlzFuQuUNG = 3940166985u;

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].SzNjajnXuqTkLVKNUlPZHTgLWZsS > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualSense.BatteryLevel => uHlTXwbDedcQBNBhqZUWQhCNRMp;

		bool IDriver_DualSense.BatteryCharging => qHNPjPrEutaTWOMLjdkoiSbQspsuA == OKeBqEcSaBXlOTzQyrjbckSVtCenA.Charging;

		DualSenseVibrationMode IDriver_DualSense.vibrationMode
		{
			get
			{
				return YcyYQfQEUwOBERuSpSVVufnPAyFcA;
			}
			set
			{
				YcyYQfQEUwOBERuSpSVVufnPAyFcA = value;
				NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
			}
		}

		float IDriver_DualSense.LeftMotor
		{
			get
			{
				return vibrationMotors[0].PvKIhOBqjFDTufSBvzXfLPDhKvGfb;
			}
			set
			{
				vibrationMotors[0].PvKIhOBqjFDTufSBvzXfLPDhKvGfb = value;
			}
		}

		float IDriver_DualSense.RightMotor
		{
			get
			{
				return vibrationMotors[1].PvKIhOBqjFDTufSBvzXfLPDhKvGfb;
			}
			set
			{
				vibrationMotors[1].PvKIhOBqjFDTufSBvzXfLPDhKvGfb = value;
			}
		}

		float IDriver_DualSense.LightColorR
		{
			get
			{
				return lights[0].bmxoAjzsPVSTcbpsoalZqgIkhIBt;
			}
			set
			{
				lights[0].bmxoAjzsPVSTcbpsoalZqgIkhIBt = value;
			}
		}

		float IDriver_DualSense.LightColorG
		{
			get
			{
				return lights[0].uGGffweBZbyGJjlgwJeLbWHGERux;
			}
			set
			{
				lights[0].uGGffweBZbyGJjlgwJeLbWHGERux = value;
			}
		}

		float IDriver_DualSense.LightColorB
		{
			get
			{
				return lights[0].QiEWCumzGtErsUfsoqUSBOXdNDVn;
			}
			set
			{
				lights[0].QiEWCumzGtErsUfsoqUSBOXdNDVn = value;
			}
		}

		float IDriver_DualSense.LightFlashOnDuration
		{
			get
			{
				return (int)GhCGZNqsguBXAdnbMsqDGUCjpkdbb;
			}
			set
			{
				GhCGZNqsguBXAdnbMsqDGUCjpkdbb = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				UWPNnBQoxzgylTewwUcvmsZzkUko();
				if (GhCGZNqsguBXAdnbMsqDGUCjpkdbb == 0 && qaFdCULFKUnPvhrIvauOFnMpxeJK == 0)
				{
					tWyFdVSIPYyLbcGpvBLiHnbfddGJA = true;
				}
			}
		}

		float IDriver_DualSense.LightFlashOffDuration
		{
			get
			{
				return (int)qaFdCULFKUnPvhrIvauOFnMpxeJK;
			}
			set
			{
				qaFdCULFKUnPvhrIvauOFnMpxeJK = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				UWPNnBQoxzgylTewwUcvmsZzkUko();
				if (GhCGZNqsguBXAdnbMsqDGUCjpkdbb == 0 && qaFdCULFKUnPvhrIvauOFnMpxeJK == 0)
				{
					tWyFdVSIPYyLbcGpvBLiHnbfddGJA = true;
				}
			}
		}

		DualSenseMicrophoneLightMode IDriver_DualSense.microphoneLightMode
		{
			get
			{
				return cplXAeHnvdeYJJkiBtTWQuuWhwzr;
			}
			set
			{
				cplXAeHnvdeYJJkiBtTWQuuWhwzr = value;
				NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
				HhHbmsBYuQjVwENwiNszLaHKVhsSA = true;
			}
		}

		DualSenseOtherLightBrightness IDriver_DualSense.otherLightBrightness
		{
			get
			{
				return CVKJOzGpfKZvBkSthLrzTamBSwYC(MehAoFdHdlfuSVJgHIVvRycnores);
			}
			set
			{
				MehAoFdHdlfuSVJgHIVvRycnores = fvgCXIIsPaCNuHlxBjqFDxpBPohp(value);
				NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
				yxMLkpxJgHqjuLRWgNmKzaRkdjeBA = true;
			}
		}

		DualSensePlayerLightFlags IDriver_DualSense.playerLights
		{
			get
			{
				return DMCREDLRuXWdWWGQfedSkUbeSKZh;
			}
			set
			{
				DMCREDLRuXWdWWGQfedSkUbeSKZh = value;
				NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
				JBugyllOGbxRBjQMgxCqwHNbYfCq = true;
			}
		}

		Vector3 IDriver_DualSense.AccelerometerValue => jlDDqELvbHaiXJxaxToTGhRjnFhb(accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq);

		Vector3 IDriver_DualSense.AccelerometerValueRaw => new Vector3(accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[0], accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[1], accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[2]);

		Vector3 IDriver_DualSense.GyroscopeValue => YwSGVkmJwrkeUKFuymlzmVZCKaSM(gyroscopes[0].ryJMmdZbgbmdaGLxdebJrFWVdjZP);

		Vector3 IDriver_DualSense.GyroscopeValueRaw => new Vector3(gyroscopes[0].TOPmGrQoeSxFlEKkKDvFEfkvXbyBA[0], gyroscopes[0].TOPmGrQoeSxFlEKkKDvFEfkvXbyBA[1], gyroscopes[0].TOPmGrQoeSxFlEKkKDvFEfkvXbyBA[2]);

		Vector3 IDriver_DualSense.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[0], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[1], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[2]);
				return nKHuFqSDDEKFSKYTiKzrKrESWCwu(vector, zgIuyqMyqbsZxxgqvhNEKboFWhIG);
			}
		}

		Vector3 IDriver_DualSense.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[0], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[1], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[2]);

		Quaternion IDriver_DualSense.Orientation => qWMrvbdlGIoVyiQTaMJqGcfujyWGA;

		int IDriver_DualSense.MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => aLqTzlSBACtQZmkBgFyYGlzBMWZDb.vendorId;

		ushort IHIDControllerExtension.productId => aLqTzlSBACtQZmkBgFyYGlzBMWZDb.productId;

		string IHIDControllerExtension.productName => aLqTzlSBACtQZmkBgFyYGlzBMWZDb.productName;

		string IHIDControllerExtension.manufacturer => aLqTzlSBACtQZmkBgFyYGlzBMWZDb.manufacturer;

		ushort IHIDControllerExtension.usagePage => aLqTzlSBACtQZmkBgFyYGlzBMWZDb.usagePage;

		ushort IHIDControllerExtension.usage => aLqTzlSBACtQZmkBgFyYGlzBMWZDb.usage;

		public void ResetOrientation()
		{
			qWMrvbdlGIoVyiQTaMJqGcfujyWGA = Quaternion.identity;
			uhnmRbTDiUULbRETzPxTPEjSiugJ = false;
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
				if (touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].isTouching)
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
			return touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].isTouching;
		}

		bool IDriver_DualSense.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].YpmgwwjwNILOgscVHbQZZLkGyLXu(touchId);
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
			return touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].touchId;
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
			ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] rFuDyXZFSuwShPfcFbhPdVCqtPBKA = touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA;
			if (!rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].isTouching)
			{
				return false;
			}
			position.x = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].positionX;
			position.y = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].positionY;
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
			if (!touchpads[0].YpmgwwjwNILOgscVHbQZZLkGyLXu(touchId))
			{
				return false;
			}
			ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] rFuDyXZFSuwShPfcFbhPdVCqtPBKA = touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA;
			for (int i = 0; i < rFuDyXZFSuwShPfcFbhPdVCqtPBKA.Length; i++)
			{
				if (rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].isTouching)
				{
					position.x = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].positionX;
					position.y = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].positionY;
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
			ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] rFuDyXZFSuwShPfcFbhPdVCqtPBKA = touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA;
			if (!rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].isTouching)
			{
				return false;
			}
			positionX = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].positionAbsX;
			positionY = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].positionAbsY;
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
			if (!touchpads[0].YpmgwwjwNILOgscVHbQZZLkGyLXu(touchId))
			{
				return false;
			}
			ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] rFuDyXZFSuwShPfcFbhPdVCqtPBKA = touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA;
			for (int i = 0; i < rFuDyXZFSuwShPfcFbhPdVCqtPBKA.Length; i++)
			{
				if (rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].isTouching)
				{
					positionX = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].positionAbsX;
					positionY = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].positionAbsY;
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
			GhCGZNqsguBXAdnbMsqDGUCjpkdbb = 0;
			qaFdCULFKUnPvhrIvauOFnMpxeJK = 0;
			NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
			tWyFdVSIPYyLbcGpvBLiHnbfddGJA = true;
			wosEjnIVAAJiFLXfSRikCVHDREMW = true;
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
				vibrationMotors[i].SzNjajnXuqTkLVKNUlPZHTgLWZsS = 0;
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
				PGjVUjIztwITiNaRVnSZdKHfitBA[0] = effect;
				NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
				KOlAQjdOWSeBdWrZoJryNaOLeyZG = true;
				return true;
			case DualSenseTriggerType.Right:
				PGjVUjIztwITiNaRVnSZdKHfitBA[1] = effect;
				NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
				SsHaqtgCbBHwtzsXKkWvDyIwFIhZ = true;
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
				leftTrigger = CoDqJPuAWSGLYgePMfXxHkAzJRNY[0],
				rightTrigger = CoDqJPuAWSGLYgePMfXxHkAzJRNY[1]
			};
		}

		DualSenseTriggerEffectStates IDriver_DualSense.GetTriggerEffectStates()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTriggerEffectStates
			return this.GetTriggerEffectStates();
		}

		public DualSenseDriver(InitArgs P_0)
			: base(P_0)
		{
			YEJFbMnbsafroSXjQljEDgEEEkiN = P_0.hidDevice;
			aLqTzlSBACtQZmkBgFyYGlzBMWZDb = YEJFbMnbsafroSXjQljEDgEEEkiN.properties;
			dCWDUNHluseURDMXMkwJdtjhNUuOb = P_0.hatZeroValue;
			fAiQMpiIpuGoEhbSYjWaZrqxmEwTA = P_0.hatSpan;
			CptMRkVInoHWTJunrJbSYDSQKsIE = P_0.connectionType == THNsKdmFHrPljnxJReWkqtKXyhyf.Bluetooth;
			if (CptMRkVInoHWTJunrJbSYDSQKsIE)
			{
				xfTmgDfGPQpfitMlILkQgYSekHqs = 78;
			}
			else
			{
				xfTmgDfGPQpfitMlILkQgYSekHqs = 48;
			}
			nVhAMeEChZzHZylRABgJsFBkNHIh = new NativeBuffer(64);
			TzbyJsfwOxWdCnkIYBkVTwvjAxEBA = new NativeBuffer(xfTmgDfGPQpfitMlILkQgYSekHqs);
			sDoKIydaBLxydYthPtUMpoppIgKA = new dQrAZjxmvMRuuUvHYPSsKegoCJrCA(TzbyJsfwOxWdCnkIYBkVTwvjAxEBA.Pointer, TzbyJsfwOxWdCnkIYBkVTwvjAxEBA.Length, xfTmgDfGPQpfitMlILkQgYSekHqs);
			lights = new eOTDyXEaLnqMzCVeUQsYyxDdlUnRA[1]
			{
				new eOTDyXEaLnqMzCVeUQsYyxDdlUnRA(11, 24, 28)
			};
			lights[0].VjNtNSvDDNOJXHSCDSpNyyrXKTOM += iTPSHSDwTyBHJfPTxkPBWwGCtkTG;
			vibrationMotors = new rTJgTxMejKLMRUmSvWOxEnqbcNsC[2]
			{
				new rTJgTxMejKLMRUmSvWOxEnqbcNsC(0, 255),
				new rTJgTxMejKLMRUmSvWOxEnqbcNsC(0, 255)
			};
			vibrationMotors[0].WzdlTpQpSqeyLlyDKcyfIzFLadvf += tMfgqKxlppofXXpBFJAzYpcIXUxl;
			vibrationMotors[1].WzdlTpQpSqeyLlyDKcyfIzFLadvf += tMfgqKxlppofXXpBFJAzYpcIXUxl;
			YcyYQfQEUwOBERuSpSVVufnPAyFcA = DualSenseVibrationMode.Compatible2;
			XvxEaDUdhVDgZBQhLLRREdkngBtEA = true;
			KOlAQjdOWSeBdWrZoJryNaOLeyZG = true;
			SsHaqtgCbBHwtzsXKkWvDyIwFIhZ = true;
			HhHbmsBYuQjVwENwiNszLaHKVhsSA = true;
			JBugyllOGbxRBjQMgxCqwHNbYfCq = true;
			yxMLkpxJgHqjuLRWgNmKzaRkdjeBA = true;
			wosEjnIVAAJiFLXfSRikCVHDREMW = true;
			IVtEUjcdfcGZlyzrMnLZqpWDxHIsA = true;
			RGACsgXMCAlRRDEiPajIehmRoveOA = true;
			vyShQYSHPeJjEFKheAuFFvGJKGdg = 2;
		}

		protected override void OnInitialize()
		{
			if (CptMRkVInoHWTJunrJbSYDSQKsIE)
			{
				byte[] hidFeatureData = YEJFbMnbsafroSXjQljEDgEEEkiN.GetHidFeatureData(5, 41, 1000, 3);
				qowewrrsLLvdyKqytalbmpOPRbJj = hidFeatureData != null && hidFeatureData.Length != 0;
				if (qowewrrsLLvdyKqytalbmpOPRbJj)
				{
					jaqbTVaskrCsaOCesqqEkrmleezTA(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
				}
			}
			else
			{
				qowewrrsLLvdyKqytalbmpOPRbJj = true;
				qowewrrsLLvdyKqytalbmpOPRbJj = jaqbTVaskrCsaOCesqqEkrmleezTA(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
			}
			if (!qowewrrsLLvdyKqytalbmpOPRbJj)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			zEbfSXMcACyhfjintbBmudBkARGF = 1;
			UCuIlwWqhvUNdCIzgTMRAJhYGijI = 0;
			if (CptMRkVInoHWTJunrJbSYDSQKsIE && qowewrrsLLvdyKqytalbmpOPRbJj)
			{
				zEbfSXMcACyhfjintbBmudBkARGF = 49;
				UCuIlwWqhvUNdCIzgTMRAJhYGijI = 1;
			}
			FvCsTHLhhPElxFKUqTKGDQjBrMJeA = 8 + UCuIlwWqhvUNdCIzgTMRAJhYGijI;
			qVwIKTuUrUlvBzeJmyQSJyfRArYk = 9 + UCuIlwWqhvUNdCIzgTMRAJhYGijI;
			BFzanuPuhmZEOlHyeptgqcFzbkwL = 10 + UCuIlwWqhvUNdCIzgTMRAJhYGijI;
			buttons = new UAfXLOdFwSwHeolOgcMEHHfYJfpJA[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new UAfXLOdFwSwHeolOgcMEHHfYJfpJA(zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new bpjwwWbNobTCGrXbZKxCDfQGumWO[6]
			{
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new ZGyGvtDVdXQGfZtomiLpAayOMjWu[1]
			{
				new ZGyGvtDVdXQGfZtomiLpAayOMjWu(zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, TWQoteGVgCAPjUDqrXbxwoDjvxeg)
			};
			accelerometers = new ofElGznmYTkSLSeuUEeYlIATDRkU[1]
			{
				new ofElGznmYTkSLSeuUEeYlIATDRkU(zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 48
				}, 3, ovESkgGRXvguxpGwWuqEwZnCicuc)
			};
			gyroscopes = new wiBPGDvFUUBIavEWhuSIVMNwIKCkA[1]
			{
				new wiBPGDvFUUBIavEWhuSIVMNwIKCkA(base.initArgs.updateLoopSetting, zEbfSXMcACyhfjintbBmudBkARGF, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 48
				}, 3, 60, aGJJSjTzwtBhNKUYDqbbhbsEPJix, wJjGMObtjKzhONMzsVHUeutyRvmz)
			};
			touchpads = new ECuuExxPnMTpiDfXAPmQzhehTPKT[1]
			{
				new ECuuExxPnMTpiDfXAPmQzhehTPKT(zEbfSXMcACyhfjintbBmudBkARGF, new ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + UCuIlwWqhvUNdCIzgTMRAJhYGijI,
					bitSize = 48
				}, 60, osaAChmckraQvoJeQqyxLhJklpMG)
			};
			hkcRzNQSpMnRDkcEHIQuFAQTqDRNA = ReInput.realTime;
			InitializationFinished(initialized: true);
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			zvbCrVhNtqsAjeeLuSvRcmxiwoMj();
			NSDlDxnkHZAEhDAwpUFbQcPDBvAi(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous);
		}

		public unsafe override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < nVhAMeEChZzHZylRABgJsFBkNHIh.Length)
			{
				return false;
			}
			if (CptMRkVInoHWTJunrJbSYDSQKsIE && qowewrrsLLvdyKqytalbmpOPRbJj && *(byte*)(void*)inputReportPtr == 1)
			{
				return false;
			}
			CyTNVArOuxzmgiluTvSddiImgwRA = (float)(timestamp - hkcRzNQSpMnRDkcEHIQuFAQTqDRNA);
			hkcRzNQSpMnRDkcEHIQuFAQTqDRNA = timestamp;
			nVhAMeEChZzHZylRABgJsFBkNHIh.Write(inputReportPtr, inputReportLength, nVhAMeEChZzHZylRABgJsFBkNHIh.Length);
			XOVmyGIZcAqEHeWYrTQwAPzCDaGb(nVhAMeEChZzHZylRABgJsFBkNHIh);
			tIcANnfuJMmJOsoULqUvCZiedgrIb(nVhAMeEChZzHZylRABgJsFBkNHIh, timestamp);
			OYzieseEeYXDrIqXsZAdwVmBBsCg[] array = axes;
			GQqDewNoObWarwqdcHPhstPWpTMO(array, nVhAMeEChZzHZylRABgJsFBkNHIh, timestamp);
			array = hats;
			GQqDewNoObWarwqdcHPhstPWpTMO(array, nVhAMeEChZzHZylRABgJsFBkNHIh, timestamp);
			array = accelerometers;
			GQqDewNoObWarwqdcHPhstPWpTMO(array, nVhAMeEChZzHZylRABgJsFBkNHIh, timestamp);
			array = gyroscopes;
			GQqDewNoObWarwqdcHPhstPWpTMO(array, nVhAMeEChZzHZylRABgJsFBkNHIh, timestamp);
			array = touchpads;
			GQqDewNoObWarwqdcHPhstPWpTMO(array, nVhAMeEChZzHZylRABgJsFBkNHIh, timestamp);
			byte b = nVhAMeEChZzHZylRABgJsFBkNHIh[53 + UCuIlwWqhvUNdCIzgTMRAJhYGijI];
			wXzRppHKQhtbEVkGCRUYoqASvuTS wXzRppHKQhtbEVkGCRUYoqASvuTS2 = (wXzRppHKQhtbEVkGCRUYoqASvuTS)((b & 0xF0) >> 4);
			if (wXzRppHKQhtbEVkGCRUYoqASvuTS2 <= wXzRppHKQhtbEVkGCRUYoqASvuTS.Full)
			{
				if (wXzRppHKQhtbEVkGCRUYoqASvuTS2 > wXzRppHKQhtbEVkGCRUYoqASvuTS.Charging)
				{
					if (wXzRppHKQhtbEVkGCRUYoqASvuTS2 != wXzRppHKQhtbEVkGCRUYoqASvuTS.Full)
					{
						goto IL_0171;
					}
					uHlTXwbDedcQBNBhqZUWQhCNRMp = 100;
					qHNPjPrEutaTWOMLjdkoiSbQspsuA = OKeBqEcSaBXlOTzQyrjbckSVtCenA.Full;
				}
				else
				{
					uHlTXwbDedcQBNBhqZUWQhCNRMp = MathTools.Clamp((b & 0xF) * 10 + 5, 0, 100);
					qHNPjPrEutaTWOMLjdkoiSbQspsuA = ((wXzRppHKQhtbEVkGCRUYoqASvuTS2 != wXzRppHKQhtbEVkGCRUYoqASvuTS.Charging) ? OKeBqEcSaBXlOTzQyrjbckSVtCenA.Discharging : OKeBqEcSaBXlOTzQyrjbckSVtCenA.Charging);
				}
			}
			else
			{
				if (wXzRppHKQhtbEVkGCRUYoqASvuTS2 - 10 > wXzRppHKQhtbEVkGCRUYoqASvuTS.Charging)
				{
					if (wXzRppHKQhtbEVkGCRUYoqASvuTS2 == wXzRppHKQhtbEVkGCRUYoqASvuTS.ChargingError)
					{
					}
					goto IL_0171;
				}
				uHlTXwbDedcQBNBhqZUWQhCNRMp = 0;
				qHNPjPrEutaTWOMLjdkoiSbQspsuA = OKeBqEcSaBXlOTzQyrjbckSVtCenA.Charging;
			}
			goto IL_017f;
			IL_0171:
			uHlTXwbDedcQBNBhqZUWQhCNRMp = 0;
			qHNPjPrEutaTWOMLjdkoiSbQspsuA = OKeBqEcSaBXlOTzQyrjbckSVtCenA.Unknown;
			goto IL_017f;
			IL_017f:
			VezieoupsAMoAYzByUhcICjYdfOKA = (nVhAMeEChZzHZylRABgJsFBkNHIh[54 + UCuIlwWqhvUNdCIzgTMRAJhYGijI] & 1) != 0;
			CoDqJPuAWSGLYgePMfXxHkAzJRNY[0] = yNOIKhEzCXqhcRLwcFBGdwLdmhmP(DualSenseTriggerType.Left, nVhAMeEChZzHZylRABgJsFBkNHIh[43 + UCuIlwWqhvUNdCIzgTMRAJhYGijI], nVhAMeEChZzHZylRABgJsFBkNHIh[48 + UCuIlwWqhvUNdCIzgTMRAJhYGijI]);
			CoDqJPuAWSGLYgePMfXxHkAzJRNY[1] = yNOIKhEzCXqhcRLwcFBGdwLdmhmP(DualSenseTriggerType.Right, nVhAMeEChZzHZylRABgJsFBkNHIh[42 + UCuIlwWqhvUNdCIzgTMRAJhYGijI], nVhAMeEChZzHZylRABgJsFBkNHIh[48 + UCuIlwWqhvUNdCIzgTMRAJhYGijI]);
			AuXobVZgvnhzOVKLXKSGtXkYVaOW();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void NSDlDxnkHZAEhDAwpUFbQcPDBvAi(IpOusHhkFVHLPKjRNBUJTzZIWToMA P_0)
		{
			if (pnGpfSvjzMkvogfaWuxIFooKkEFY)
			{
				jaqbTVaskrCsaOCesqqEkrmleezTA(P_0);
				pnGpfSvjzMkvogfaWuxIFooKkEFY = false;
			}
		}

		private bool jaqbTVaskrCsaOCesqqEkrmleezTA(IpOusHhkFVHLPKjRNBUJTzZIWToMA P_0)
		{
			GsrFjHLpYstbRQKaPLRsjeqPGblcA();
			bool result = CGiyZWXeFkFhUlXoujXepyaUqCCp(P_0);
			if (tWyFdVSIPYyLbcGpvBLiHnbfddGJA)
			{
				result = CGiyZWXeFkFhUlXoujXepyaUqCCp(P_0);
				tWyFdVSIPYyLbcGpvBLiHnbfddGJA = false;
			}
			return result;
		}

		private void GsrFjHLpYstbRQKaPLRsjeqPGblcA()
		{
			if (CptMRkVInoHWTJunrJbSYDSQKsIE && qowewrrsLLvdyKqytalbmpOPRbJj)
			{
				TzbyJsfwOxWdCnkIYBkVTwvjAxEBA[0] = 49;
				TzbyJsfwOxWdCnkIYBkVTwvjAxEBA[1] = 2;
				jYwpvRmDqemBONhohuHDuGxCFnKU(TzbyJsfwOxWdCnkIYBkVTwvjAxEBA, 2);
				uint num = LFKBNDetiJVdZEdexKrJxxVorMyt(TzbyJsfwOxWdCnkIYBkVTwvjAxEBA, 74);
				TzbyJsfwOxWdCnkIYBkVTwvjAxEBA[74] = (byte)(num & 0xFF);
				TzbyJsfwOxWdCnkIYBkVTwvjAxEBA[75] = (byte)((num & 0xFF00) >> 8);
				TzbyJsfwOxWdCnkIYBkVTwvjAxEBA[76] = (byte)((num & 0xFF0000) >> 16);
				TzbyJsfwOxWdCnkIYBkVTwvjAxEBA[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				TzbyJsfwOxWdCnkIYBkVTwvjAxEBA[0] = 2;
				jYwpvRmDqemBONhohuHDuGxCFnKU(TzbyJsfwOxWdCnkIYBkVTwvjAxEBA, 1);
			}
		}

		private void jYwpvRmDqemBONhohuHDuGxCFnKU(NativeBuffer P_0, int P_1)
		{
			VGBWvWxMBXxyuBOtPveTjWoeSpBe vGBWvWxMBXxyuBOtPveTjWoeSpBe = VGBWvWxMBXxyuBOtPveTjWoeSpBe.None;
			qQbPQaNrbloIipqKTxFTsOnMHYWP qQbPQaNrbloIipqKTxFTsOnMHYWP2 = qQbPQaNrbloIipqKTxFTsOnMHYWP.None;
			vGBWvWxMBXxyuBOtPveTjWoeSpBe |= VGBWvWxMBXxyuBOtPveTjWoeSpBe.HapticsSelect;
			if (YcyYQfQEUwOBERuSpSVVufnPAyFcA == DualSenseVibrationMode.Compatible)
			{
				vGBWvWxMBXxyuBOtPveTjWoeSpBe |= VGBWvWxMBXxyuBOtPveTjWoeSpBe.CompatibleVibrationMode1;
			}
			XvxEaDUdhVDgZBQhLLRREdkngBtEA = false;
			vGBWvWxMBXxyuBOtPveTjWoeSpBe |= VGBWvWxMBXxyuBOtPveTjWoeSpBe.LeftTriggerEffect;
			KOlAQjdOWSeBdWrZoJryNaOLeyZG = false;
			vGBWvWxMBXxyuBOtPveTjWoeSpBe |= VGBWvWxMBXxyuBOtPveTjWoeSpBe.RightTriggerEffect;
			SsHaqtgCbBHwtzsXKkWvDyIwFIhZ = false;
			qQbPQaNrbloIipqKTxFTsOnMHYWP2 |= qQbPQaNrbloIipqKTxFTsOnMHYWP.MicrophoneLEDControl;
			HhHbmsBYuQjVwENwiNszLaHKVhsSA = false;
			qQbPQaNrbloIipqKTxFTsOnMHYWP2 |= qQbPQaNrbloIipqKTxFTsOnMHYWP.PlayerIndicatorLEDControl;
			JBugyllOGbxRBjQMgxCqwHNbYfCq = false;
			qQbPQaNrbloIipqKTxFTsOnMHYWP2 |= qQbPQaNrbloIipqKTxFTsOnMHYWP.LightbarControl;
			wosEjnIVAAJiFLXfSRikCVHDREMW = false;
			qQbPQaNrbloIipqKTxFTsOnMHYWP2 |= qQbPQaNrbloIipqKTxFTsOnMHYWP.ChangeOverallMotorEffectPower;
			RGACsgXMCAlRRDEiPajIehmRoveOA = false;
			P_0[P_1] = (byte)vGBWvWxMBXxyuBOtPveTjWoeSpBe;
			P_0[1 + P_1] = (byte)qQbPQaNrbloIipqKTxFTsOnMHYWP2;
			P_0[2 + P_1] = (byte)vibrationMotors[1].SzNjajnXuqTkLVKNUlPZHTgLWZsS;
			P_0[3 + P_1] = (byte)vibrationMotors[0].SzNjajnXuqTkLVKNUlPZHTgLWZsS;
			P_0[8 + P_1] = (byte)cplXAeHnvdeYJJkiBtTWQuuWhwzr;
			JfzRkAEGjrvbdMcCPyYjKIExIKcg jfzRkAEGjrvbdMcCPyYjKIExIKcg = JfzRkAEGjrvbdMcCPyYjKIExIKcg.None;
			jfzRkAEGjrvbdMcCPyYjKIExIKcg |= JfzRkAEGjrvbdMcCPyYjKIExIKcg.OtherLightBrightnessControl;
			yxMLkpxJgHqjuLRWgNmKzaRkdjeBA = false;
			if (YcyYQfQEUwOBERuSpSVVufnPAyFcA == DualSenseVibrationMode.Compatible2)
			{
				jfzRkAEGjrvbdMcCPyYjKIExIKcg |= JfzRkAEGjrvbdMcCPyYjKIExIKcg.CompatibleVibrationMode2;
			}
			jfzRkAEGjrvbdMcCPyYjKIExIKcg |= JfzRkAEGjrvbdMcCPyYjKIExIKcg.LightbarSetupControl;
			IVtEUjcdfcGZlyzrMnLZqpWDxHIsA = false;
			P_0[38 + P_1] = (byte)jfzRkAEGjrvbdMcCPyYjKIExIKcg;
			P_0[41 + P_1] = vyShQYSHPeJjEFKheAuFFvGJKGdg;
			P_0[42 + P_1] = (byte)MehAoFdHdlfuSVJgHIVvRycnores;
			P_0[43 + P_1] = (byte)DMCREDLRuXWdWWGQfedSkUbeSKZh;
			if (ZbZOZowjBZBOVTqkAbPifHkfkJaBb)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[44 + P_1] = lights[0].icHctacIJMzVGXgZeecHBnvYQQyD;
			P_0[45 + P_1] = lights[0].sxriMIpQSAKUwYKSoWWkEypbExKV;
			P_0[46 + P_1] = lights[0].GhRUEqUmyuxeFVpnBfPmcoxXDHeUA;
			PztRBqoWhrnxclYeEQHNUlaVVNWC(ref PGjVUjIztwITiNaRVnSZdKHfitBA[1], P_0, 10 + P_1);
			PztRBqoWhrnxclYeEQHNUlaVVNWC(ref PGjVUjIztwITiNaRVnSZdKHfitBA[0], P_0, 21 + P_1);
			P_0[36 + P_1] = 0;
		}

		private void PztRBqoWhrnxclYeEQHNUlaVVNWC(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
			if (P_0 == null)
			{
				P_1[P_2] = 0;
				return;
			}
			switch (P_0.triggerEffectType)
			{
			case DualSenseTriggerEffectType.Off:
				RhPspkytqiogDRteCpNuhCqAlSBu.VnjComnkQbvwqwbkEgeHcTljhyVhA.LwWchXCvtVMzzbpGelPVNVIkOtffB(gEEhFrEhPiiypkQarJWceLTGdwbkb, 0);
				break;
			case DualSenseTriggerEffectType.Feedback:
			{
				DualSenseTriggerEffectFeedback dualSenseTriggerEffectFeedback = (DualSenseTriggerEffectFeedback)(object)P_0;
				RhPspkytqiogDRteCpNuhCqAlSBu.VnjComnkQbvwqwbkEgeHcTljhyVhA.fYxuzGhUMNagQhKrNiuVuPjODAvA(gEEhFrEhPiiypkQarJWceLTGdwbkb, 0, dualSenseTriggerEffectFeedback.position, dualSenseTriggerEffectFeedback.strength);
				break;
			}
			case DualSenseTriggerEffectType.Weapon:
			{
				DualSenseTriggerEffectWeapon dualSenseTriggerEffectWeapon = (DualSenseTriggerEffectWeapon)(object)P_0;
				RhPspkytqiogDRteCpNuhCqAlSBu.VnjComnkQbvwqwbkEgeHcTljhyVhA.htWjAQNJuQhZSsURoOISYGLBDirA(gEEhFrEhPiiypkQarJWceLTGdwbkb, 0, dualSenseTriggerEffectWeapon.startPosition, dualSenseTriggerEffectWeapon.endPosition, dualSenseTriggerEffectWeapon.strength);
				break;
			}
			case DualSenseTriggerEffectType.Vibration:
			{
				DualSenseTriggerEffectVibration dualSenseTriggerEffectVibration = (DualSenseTriggerEffectVibration)(object)P_0;
				RhPspkytqiogDRteCpNuhCqAlSBu.VnjComnkQbvwqwbkEgeHcTljhyVhA.BCUIqfFzrdUvMHUMFCRIIREywrQH(gEEhFrEhPiiypkQarJWceLTGdwbkb, 0, dualSenseTriggerEffectVibration.position, dualSenseTriggerEffectVibration.amplitude, dualSenseTriggerEffectVibration.frequency);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionFeedback:
				((DualSenseTriggerEffectMultiplePositionFeedback)(object)P_0).strength.CopyTo(ezNbDDkIvrmVuTaTDjIdDVzObYxd);
				RhPspkytqiogDRteCpNuhCqAlSBu.VnjComnkQbvwqwbkEgeHcTljhyVhA.vnpsfoUbiEpUwSZROBEMILwhGadW(gEEhFrEhPiiypkQarJWceLTGdwbkb, 0, ezNbDDkIvrmVuTaTDjIdDVzObYxd);
				break;
			case DualSenseTriggerEffectType.SlopeFeedback:
			{
				DualSenseTriggerEffectSlopeFeedback dualSenseTriggerEffectSlopeFeedback = (DualSenseTriggerEffectSlopeFeedback)(object)P_0;
				RhPspkytqiogDRteCpNuhCqAlSBu.VnjComnkQbvwqwbkEgeHcTljhyVhA.fXPvXyGSWxsJVQLJuesEDBuwfzKX(gEEhFrEhPiiypkQarJWceLTGdwbkb, 0, dualSenseTriggerEffectSlopeFeedback.startPosition, dualSenseTriggerEffectSlopeFeedback.endPosition, dualSenseTriggerEffectSlopeFeedback.startStrength, dualSenseTriggerEffectSlopeFeedback.endStrength);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionVibration:
			{
				DualSenseTriggerEffectMultiplePositionVibration dualSenseTriggerEffectMultiplePositionVibration = (DualSenseTriggerEffectMultiplePositionVibration)(object)P_0;
				dualSenseTriggerEffectMultiplePositionVibration.amplitude.CopyTo(ezNbDDkIvrmVuTaTDjIdDVzObYxd);
				RhPspkytqiogDRteCpNuhCqAlSBu.VnjComnkQbvwqwbkEgeHcTljhyVhA.VYEruPsGCdKEYxFnSwSiskOGDQyC(gEEhFrEhPiiypkQarJWceLTGdwbkb, 0, dualSenseTriggerEffectMultiplePositionVibration.frequency, ezNbDDkIvrmVuTaTDjIdDVzObYxd);
				break;
			}
			default:
				Logger.LogWarning("Unknown trigger effect type: 0x" + ((byte)P_0.triggerEffectType).ToString("x2"));
				return;
			}
			P_1.Write(gEEhFrEhPiiypkQarJWceLTGdwbkb, gEEhFrEhPiiypkQarJWceLTGdwbkb.Length, P_2);
		}

		private bool CGiyZWXeFkFhUlXoujXepyaUqCCp(IpOusHhkFVHLPKjRNBUJTzZIWToMA P_0)
		{
			yENhiJkEKkSZkISQUcnyJcYgCHQw = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous:
				return YEJFbMnbsafroSXjQljEDgEEEkiN.WriteSync(sDoKIydaBLxydYthPtUMpoppIgKA, 0);
			case IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous:
				YEJFbMnbsafroSXjQljEDgEEEkiN.WriteAsync(sDoKIydaBLxydYthPtUMpoppIgKA, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void tIcANnfuJMmJOsoULqUvCZiedgrIb(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[FvCsTHLhhPElxFKUqTKGDQjBrMJeA];
			buttons[0].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x10) != 0, P_1);
			buttons[1].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x20) != 0, P_1);
			buttons[2].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x40) != 0, P_1);
			buttons[3].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x80) != 0, P_1);
			b = P_0[qVwIKTuUrUlvBzeJmyQSJyfRArYk];
			buttons[4].AtQsHqTAryodwUVQnJukddZkgqvd((b & 1) != 0, P_1);
			buttons[5].AtQsHqTAryodwUVQnJukddZkgqvd((b & 2) != 0, P_1);
			buttons[6].AtQsHqTAryodwUVQnJukddZkgqvd((b & 4) != 0, P_1);
			buttons[7].AtQsHqTAryodwUVQnJukddZkgqvd((b & 8) != 0, P_1);
			buttons[8].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x10) != 0, P_1);
			buttons[9].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x20) != 0, P_1);
			buttons[10].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x40) != 0, P_1);
			buttons[11].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x80) != 0, P_1);
			b = P_0[BFzanuPuhmZEOlHyeptgqcFzbkwL];
			buttons[12].AtQsHqTAryodwUVQnJukddZkgqvd((b & 1) != 0, P_1);
			buttons[13].AtQsHqTAryodwUVQnJukddZkgqvd((b & 2) != 0, P_1);
			if (qowewrrsLLvdyKqytalbmpOPRbJj)
			{
				buttons[14].AtQsHqTAryodwUVQnJukddZkgqvd((b & 4) != 0, P_1);
			}
		}

		private void GQqDewNoObWarwqdcHPhstPWpTMO(OYzieseEeYXDrIqXsZAdwVmBBsCg[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].bNihcfetwkjYPbAQTEqgnRQFuUSJ(P_1, P_2);
			}
		}

		private void zvbCrVhNtqsAjeeLuSvRcmxiwoMj()
		{
			if (isVibrating && ReInput.realTime >= yENhiJkEKkSZkISQUcnyJcYgCHQw)
			{
				NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
				XvxEaDUdhVDgZBQhLLRREdkngBtEA = true;
			}
		}

		private void XOVmyGIZcAqEHeWYrTQwAPzCDaGb(NativeBuffer P_0)
		{
			if (qowewrrsLLvdyKqytalbmpOPRbJj)
			{
				uint num = nVhAMeEChZzHZylRABgJsFBkNHIh.ReadUInt(28 + UCuIlwWqhvUNdCIzgTMRAJhYGijI);
				float num3;
				if (num != NACewxMTXWyWPkJLOnTyQclhrruS)
				{
					uint num2 = (uint)((num >= NACewxMTXWyWPkJLOnTyQclhrruS) ? (num - NACewxMTXWyWPkJLOnTyQclhrruS) : ((long)num + 4294967295L - NACewxMTXWyWPkJLOnTyQclhrruS));
					num3 = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					num3 = 0f;
				}
				NACewxMTXWyWPkJLOnTyQclhrruS = num;
				zgIuyqMyqbsZxxgqvhNEKboFWhIG = num3;
			}
		}

		private void AuXobVZgvnhzOVKLXKSGtXkYVaOW()
		{
			if (qowewrrsLLvdyKqytalbmpOPRbJj && !(zgIuyqMyqbsZxxgqvhNEKboFWhIG <= 0f))
			{
				Vector3 vector = nKHuFqSDDEKFSKYTiKzrKrESWCwu(new Vector3(gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[0], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[1], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[2]), zgIuyqMyqbsZxxgqvhNEKboFWhIG);
				BjjrNWXjcrknqfDhdXHvzKlrYmqE(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[0] * -1f, accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[1] * -1f, accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[2] * -1f);
				fveuYhMklsqRRkJppsxBgDgflfgj(vector2, vector);
			}
		}

		private static bool BjjrNWXjcrknqfDhdXHvzKlrYmqE(ref Vector3 P_0)
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

		private void fveuYhMklsqRRkJppsxBgDgflfgj(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && vGkTqXkQefwcCVVqIvqVovzgxBgH(P_0, out var muHlxBSVgLCeiPQIBlLAEqkonOxL2))
			{
				Quaternion a = qWMrvbdlGIoVyiQTaMJqGcfujyWGA * quaternion;
				if (!uhnmRbTDiUULbRETzPxTPEjSiugJ)
				{
					uhnmRbTDiUULbRETzPxTPEjSiugJ = true;
					EQnAjcQMWEkGhmKDbZszSQcmWuFn = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					mSYNilEuVXWYsKHPUdNVvOxuzFsA = qWMrvbdlGIoVyiQTaMJqGcfujyWGA;
				}
				EQnAjcQMWEkGhmKDbZszSQcmWuFn *= quaternion;
				mSYNilEuVXWYsKHPUdNVvOxuzFsA *= quaternion;
				Quaternion b;
				if ((muHlxBSVgLCeiPQIBlLAEqkonOxL2 & muHlxBSVgLCeiPQIBlLAEqkonOxL.XZ) != muHlxBSVgLCeiPQIBlLAEqkonOxL.None)
				{
					b = nLQUzyHjDtkIceVbfrnRpASHdLehA(P_0, a.eulerAngles.y);
				}
				else if ((muHlxBSVgLCeiPQIBlLAEqkonOxL2 & muHlxBSVgLCeiPQIBlLAEqkonOxL.Y) != muHlxBSVgLCeiPQIBlLAEqkonOxL.None)
				{
					b = gdHfeabbkjvXgMinoIVBHrIdXtcAA(P_0);
					Vector3 vector = mSYNilEuVXWYsKHPUdNVvOxuzFsA * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				qWMrvbdlGIoVyiQTaMJqGcfujyWGA = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				qWMrvbdlGIoVyiQTaMJqGcfujyWGA *= quaternion;
				if (uhnmRbTDiUULbRETzPxTPEjSiugJ)
				{
					uhnmRbTDiUULbRETzPxTPEjSiugJ = false;
				}
			}
		}

		private static Quaternion GphXkeOSvEUIPiryjVlXBQXnVGNg(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = brSLySQdrRnoElIAhNMqEkMsCEgGA(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 brSLySQdrRnoElIAhNMqEkMsCEgGA(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion WYuFCOUcvVtPqWmivnneBoKJwPWM(Quaternion P_0, aXmfcIHhwQfJXiVHfzgIYCtTmxEaA P_1)
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

		private float JNQmlkDejsfEJIygBladivjtGTTlA(float P_0, float P_1)
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

		private Vector3 SJhmRiLdWmKhYzGcDBAXRsNREXEN(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion nLQUzyHjDtkIceVbfrnRpASHdLehA(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion gdHfeabbkjvXgMinoIVBHrIdXtcAA(Vector3 P_0, float P_1 = 0f)
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

		private float GWhcVjZYJensSlmvlJvpQibtxkc(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool VTIIcbtdrASWkfKOFCIYIwOuPbYk(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool vGkTqXkQefwcCVVqIvqVovzgxBgH(Vector3 P_0, out muHlxBSVgLCeiPQIBlLAEqkonOxL P_1)
		{
			P_0.Normalize();
			P_1 = muHlxBSVgLCeiPQIBlLAEqkonOxL.None;
			bool result = false;
			if (rlOtGHSlvejEaQKZCYefMnMitikM(P_0))
			{
				result = true;
				P_1 |= muHlxBSVgLCeiPQIBlLAEqkonOxL.XZ;
			}
			if (jHfyQVRXnFJLdpxjkePjObhgHeJgA(P_0))
			{
				result = true;
				P_1 |= muHlxBSVgLCeiPQIBlLAEqkonOxL.Y;
			}
			return result;
		}

		private bool rlOtGHSlvejEaQKZCYefMnMitikM(Vector3 P_0)
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

		private bool jHfyQVRXnFJLdpxjkePjObhgHeJgA(Vector3 P_0)
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

		private Vector3 jlDDqELvbHaiXJxaxToTGhRjnFhb(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 YwSGVkmJwrkeUKFuymlzmVZCKaSM(RingBuffer<wiBPGDvFUUBIavEWhuSIVMNwIKCkA.omfOYSthvfxFOzvrfcgXtYNKrtBD> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				wiBPGDvFUUBIavEWhuSIVMNwIKCkA.omfOYSthvfxFOzvrfcgXtYNKrtBD omfOYSthvfxFOzvrfcgXtYNKrtBD = P_0[i];
				result += nKHuFqSDDEKFSKYTiKzrKrESWCwu(omfOYSthvfxFOzvrfcgXtYNKrtBD.OZrLUbmVszNAYtdqpGvGeqRxwPIu, omfOYSthvfxFOzvrfcgXtYNKrtBD.eGTwdyVsRArxyevZfnHlkMWJcZXd);
			}
			return result;
		}

		private Vector3 nKHuFqSDDEKFSKYTiKzrKrESWCwu(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int TWQoteGVgCAPjUDqrXbxwoDjvxeg(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void ovESkgGRXvguxpGwWuqEwZnCicuc(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void aGJJSjTzwtBhNKUYDqbbhbsEPJix(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float wJjGMObtjKzhONMzsVHUeutyRvmz()
		{
			return zgIuyqMyqbsZxxgqvhNEKboFWhIG;
		}

		private void osaAChmckraQvoJeQqyxLhJklpMG(NativeBuffer P_0, ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] P_1)
		{
			int num = 33 + UCuIlwWqhvUNdCIzgTMRAJhYGijI;
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
			P_1[0].touchId = KoeKvhVNZXSHEHIEMwJJhjyfIKrp(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = KoeKvhVNZXSHEHIEMwJJhjyfIKrp(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int KoeKvhVNZXSHEHIEMwJJhjyfIKrp(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				JtiXLfkVpktmqrsdeUUdnPEXjlKjA[P_0] = -1;
				kuHSGfNKfIFtfzCPUZQUKJKqNeKP[P_0] = P_2;
				return -1;
			}
			if (P_2 != kuHSGfNKfIFtfzCPUZQUKJKqNeKP[P_0])
			{
				int num = tefKAldvFlwpxRacOjaSdVhOBflr;
				if (tefKAldvFlwpxRacOjaSdVhOBflr == int.MaxValue)
				{
					tefKAldvFlwpxRacOjaSdVhOBflr = 0;
				}
				else
				{
					tefKAldvFlwpxRacOjaSdVhOBflr++;
				}
				kuHSGfNKfIFtfzCPUZQUKJKqNeKP[P_0] = P_2;
				JtiXLfkVpktmqrsdeUUdnPEXjlKjA[P_0] = num;
				return num;
			}
			return JtiXLfkVpktmqrsdeUUdnPEXjlKjA[P_0];
		}

		private void iTPSHSDwTyBHJfPTxkPBWwGCtkTG()
		{
			wosEjnIVAAJiFLXfSRikCVHDREMW = true;
			NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
		}

		private void UWPNnBQoxzgylTewwUcvmsZzkUko()
		{
			wosEjnIVAAJiFLXfSRikCVHDREMW = true;
			NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
		}

		private void tMfgqKxlppofXXpBFJAzYpcIXUxl()
		{
			XvxEaDUdhVDgZBQhLLRREdkngBtEA = true;
			NgsVjDsdxXBUSCHpstTkhkVAYBWSA();
		}

		private void NgsVjDsdxXBUSCHpstTkhkVAYBWSA()
		{
			pnGpfSvjzMkvogfaWuxIFooKkEFY = true;
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
				NSDlDxnkHZAEhDAwpUFbQcPDBvAi(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
				if (nVhAMeEChZzHZylRABgJsFBkNHIh != null)
				{
					nVhAMeEChZzHZylRABgJsFBkNHIh.Dispose();
				}
				if (TzbyJsfwOxWdCnkIYBkVTwvjAxEBA != null)
				{
					TzbyJsfwOxWdCnkIYBkVTwvjAxEBA.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			for (int i = 0; i < Consts.pidVids_sony_dualSense.Count; i++)
			{
				if (Consts.pidVids_sony_dualSense[i].vendorId == vid && Consts.pidVids_sony_dualSense[i].productId == pid)
				{
					return true;
				}
			}
			return false;
		}

		private static uint LFKBNDetiJVdZEdexKrJxxVorMyt(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = uXvvMTBXaausjyqaPpMVAjlRyINf[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static nkGuBosNiweifSHWfdDSHIZajFBlA fvgCXIIsPaCNuHlxBjqFDxpBPohp(DualSenseOtherLightBrightness P_0)
		{
			return P_0 switch
			{
				DualSenseOtherLightBrightness.High => nkGuBosNiweifSHWfdDSHIZajFBlA.High, 
				DualSenseOtherLightBrightness.Medium => nkGuBosNiweifSHWfdDSHIZajFBlA.Medium, 
				DualSenseOtherLightBrightness.Low => nkGuBosNiweifSHWfdDSHIZajFBlA.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static DualSenseOtherLightBrightness CVKJOzGpfKZvBkSthLrzTamBSwYC(nkGuBosNiweifSHWfdDSHIZajFBlA P_0)
		{
			return P_0 switch
			{
				nkGuBosNiweifSHWfdDSHIZajFBlA.High => DualSenseOtherLightBrightness.High, 
				nkGuBosNiweifSHWfdDSHIZajFBlA.Medium => DualSenseOtherLightBrightness.Medium, 
				nkGuBosNiweifSHWfdDSHIZajFBlA.Low => DualSenseOtherLightBrightness.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static QaebztGWAywShtzJxAVpToeSNXEFA TuOoBRxCqTCpcixCerCMOSPoFvaSA(DualSenseTriggerType P_0, byte P_1)
		{
			byte b;
			switch (P_0)
			{
			case DualSenseTriggerType.Left:
				b = new mmxXybtvxXhnoHWgvnZxdxlQOHJJ(P_1).MYWjstJKLLyDPPhyNqoTHiXhxrmk;
				break;
			case DualSenseTriggerType.Right:
				b = new mmxXybtvxXhnoHWgvnZxdxlQOHJJ(P_1).yxziKfkTfPDwXBTVRRFoqjuRfJWBA;
				break;
			default:
				return QaebztGWAywShtzJxAVpToeSNXEFA.Off;
			}
			return b switch
			{
				0 => QaebztGWAywShtzJxAVpToeSNXEFA.Off, 
				1 => QaebztGWAywShtzJxAVpToeSNXEFA.Feedback, 
				2 => QaebztGWAywShtzJxAVpToeSNXEFA.Weapon, 
				3 => QaebztGWAywShtzJxAVpToeSNXEFA.Vibration, 
				4 => QaebztGWAywShtzJxAVpToeSNXEFA.SlopeFeedback, 
				_ => QaebztGWAywShtzJxAVpToeSNXEFA.Off, 
			};
		}

		private static DualSenseTriggerEffectState yNOIKhEzCXqhcRLwcFBGdwLdmhmP(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			byte b = new mmxXybtvxXhnoHWgvnZxdxlQOHJJ(P_1).MYWjstJKLLyDPPhyNqoTHiXhxrmk;
			return TuOoBRxCqTCpcixCerCMOSPoFvaSA(P_0, P_2) switch
			{
				QaebztGWAywShtzJxAVpToeSNXEFA.Off => DualSenseTriggerEffectState.Off, 
				QaebztGWAywShtzJxAVpToeSNXEFA.Feedback => b switch
				{
					0 => DualSenseTriggerEffectState.FeedbackIdle, 
					1 => DualSenseTriggerEffectState.FeedbackApplyingForce, 
					_ => DualSenseTriggerEffectState.FeedbackIdle, 
				}, 
				QaebztGWAywShtzJxAVpToeSNXEFA.Weapon => b switch
				{
					0 => DualSenseTriggerEffectState.WeaponIdle, 
					1 => DualSenseTriggerEffectState.WeaponFiring, 
					2 => DualSenseTriggerEffectState.WeaponFired, 
					_ => DualSenseTriggerEffectState.WeaponIdle, 
				}, 
				QaebztGWAywShtzJxAVpToeSNXEFA.Vibration => b switch
				{
					0 => DualSenseTriggerEffectState.VibrationIdle, 
					1 => DualSenseTriggerEffectState.VibrationVibrating, 
					_ => DualSenseTriggerEffectState.VibrationIdle, 
				}, 
				QaebztGWAywShtzJxAVpToeSNXEFA.SlopeFeedback => b switch
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
