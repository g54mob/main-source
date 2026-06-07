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
	internal class DualSenseDriver : HIDDeviceDriver, IDisposable, IHIDControllerExtension, IDriver_DualSense, IControllerDriver
	{
		private enum clgdJxGApygeEBFweJooXmtFmUPbb
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum kMFZAkfrrzehnHhnQAdiduioIQuBb
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum UlmYTAdpRQvkgbHgaGHJIIkGeqNiA : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum pRIgwHFfpGZgqSqnuHJwsOTcslUH : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum oLbUnCyeNNYvXLfbHYAaQbWGNIOl : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum MtwXhxpbjzECHhKnnIjLQqSRTjvQ
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum PuHLtrOfLtmUhNBvMgxjBDAolrSrA : byte
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

		private enum uBdhbZcFuJpSvtObKHkdEAvClDDi : byte
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

		private enum VqxmchvOJLzAkYTlSkuBgcWnGvbn : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct kUrPcOMIynUGhNDZwbXVDOrGblMt
		{
			private const string fCpyXeXOhDeTAweWOzFygqSWWuGj = "Value must be between 0 and 16.";

			public byte pWRdAJigDslyLjNIYbVMMkTWOPgC;

			public byte MvLzlHXHLZBAOGTRQaiLlzUOCBVGA
			{
				get
				{
					return (byte)(pWRdAJigDslyLjNIYbVMMkTWOPgC & 0xF);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					pWRdAJigDslyLjNIYbVMMkTWOPgC = (byte)((qBLFfwDmmjjaCcyqBozpLgepcGdHA << 4) | (b & 0xF));
				}
			}

			public byte qBLFfwDmmjjaCcyqBozpLgepcGdHA
			{
				get
				{
					return (byte)(pWRdAJigDslyLjNIYbVMMkTWOPgC >> 4);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					pWRdAJigDslyLjNIYbVMMkTWOPgC = (byte)((b << 4) | MvLzlHXHLZBAOGTRQaiLlzUOCBVGA);
				}
			}

			public kUrPcOMIynUGhNDZwbXVDOrGblMt(byte P_0)
			{
				pWRdAJigDslyLjNIYbVMMkTWOPgC = P_0;
			}

			public kUrPcOMIynUGhNDZwbXVDOrGblMt(byte P_0, byte P_1)
			{
				if (P_0 >= 16 || P_1 >= 16)
				{
					throw new ArithmeticException("Value must be between 0 and 16.");
				}
				pWRdAJigDslyLjNIYbVMMkTWOPgC = (byte)((P_1 << 4) | P_0);
			}
		}

		private static class XTTObJBblEPgCJBXVcVQNTmAIzAR
		{
			public enum tBGMPnbdJBscbMAOMwnpaAmvdjYk : byte
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

			public static class TZffRZDMFJwDbqsVTrkvmAdrGLQDb
			{
				public static class dVuetzAmUxapnCeFNhHvrlZLxyDL
				{
					public static bool bMbgCeDWRAlsgukSlQQWKhVFsDuGA(byte[] P_0, int P_1)
					{
						return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
					}

					public static bool zwHhbEBxizIAlQDaXYvMIbabzHDV(byte[] P_0, int P_1, float P_2, float P_3)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						return fOPBmizQEjnUynQRTeqVSCCwLthC(P_0, P_1, (byte)P_2, (byte)P_3);
					}

					public static bool nhNlNpfdfEiEhDqwCMFrEOeMuRmiA(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						return mPoSBNOoaqQGMosbucGfUncHGHUA(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool ZRbePoEcNsGVHXevmhMqxRxRMlRB(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						P_4 = (float)Math.Round(P_4 * 255f);
						return neQxlYnEyEaZhAOllmdjXIpIwFLIA(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool aZGjDKdcSmaiSaZhKspjDguDEmuDb(byte[] P_0, int P_1, float[] P_2)
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
						return ccVuUrNnZIBOPAkIWHqryXUNRXHZ(P_0, P_1, array);
					}

					public static bool xiJyuteaZBVDJZTOBFhrBWYYYZyb(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						P_5 = (float)Math.Round(P_5 * 8f);
						return ENgFHFuNUdQniYGZKQOceLPglgAI(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4, (byte)P_5);
					}

					public static bool ASRWxMWNfjSsnCGxWNvjSAfVckKD(byte[] P_0, int P_1, float[] P_2, float P_3)
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
						return ymqsxfYBYpSiaPRfadczKsBufaIX(P_0, P_1, (byte)P_3, array);
					}
				}

				[Serializable]
				private sealed class fPknyTXmrGnNucfJilPhsUeyrriv
				{
					public static readonly fPknyTXmrGnNucfJilPhsUeyrriv _003C_003E9 = new fPknyTXmrGnNucfJilPhsUeyrriv();

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool KVOpFfFYnuQpBnMuiSWgYkbksBzy(byte P_0)
					{
						return P_0 > 0;
					}

					internal bool MHOLEunsNweHZYRqHKTHBZHaLqyN(byte P_0)
					{
						return P_0 > 0;
					}
				}

				public static bool VJjGVsFTJeqrdHBnuzTIUcAUDsdc(byte[] P_0, int P_1)
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

				public static bool fOPBmizQEjnUynQRTeqVSCCwLthC(byte[] P_0, int P_1, byte P_2, byte P_3)
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool mPoSBNOoaqQGMosbucGfUncHGHUA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool neQxlYnEyEaZhAOllmdjXIpIwFLIA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool ccVuUrNnZIBOPAkIWHqryXUNRXHZ(byte[] P_0, int P_1, byte[] P_2)
				{
					if (P_2.Length != 10)
					{
						return false;
					}
					if (P_2.Any(fPknyTXmrGnNucfJilPhsUeyrriv._003C_003E9.KVOpFfFYnuQpBnMuiSWgYkbksBzy))
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool ENgFHFuNUdQniYGZKQOceLPglgAI(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
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
					return ccVuUrNnZIBOPAkIWHqryXUNRXHZ(P_0, P_1, array);
				}

				public static bool ymqsxfYBYpSiaPRfadczKsBufaIX(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					if (P_3.Length != 10)
					{
						return false;
					}
					if (P_2 > 0 && P_3.Any(fPknyTXmrGnNucfJilPhsUeyrriv._003C_003E9.MHOLEunsNweHZYRqHKTHBZHaLqyN))
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool cFthgydpzpRVGApTKLlzbMKlzhRH(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool eNVhGFJCFipsewoiJVbqJzmaGIpC(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool fzTeEBWsGRqEfKIrLEYJemISDSBgA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool fQdRpCkEAoynKMYAdNRcdeFbnArL(byte[] P_0, int P_1, byte P_2, byte P_3)
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

				public static bool SvpnaKctcpHlJFFclCEDGqJzaIQi(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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

				public static bool qsvfyLHjOPniloSVSGclctqczgCSA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool eSBsJGuVWBVjrFeaUkkmvsRcCowb(byte[] P_0, int P_1, byte P_2, byte P_3)
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}

				public static bool fMPUwzEMtAIinWcBEkkuECIRndpB(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return VJjGVsFTJeqrdHBnuzTIUcAUDsdc(P_0, P_1);
				}
			}
		}

		private const float tsemGoiGnTwYdWptJfFTQNuugqoF = 4f;

		private const int CyZlyMvoGxSvfFEPCQWXSDYugSthA = 15;

		private const int KPGBMQetEpXJKzrVKDVmnoqvhRUS = 2;

		private const int mRZZGzsKnWFRPIOItEtsisXHlFOC = 0;

		private const int ObARokmSaxSwxLudqnodKrRXuHkj = 1912;

		private const int gdpkYxcBnblSxredwzYamWBEHyip = 0;

		private const int VTlEzzHNmzprZDWuHHStZvtEfvfwB = 941;

		private const bool telDkYGVBtedBDwzSPAQKElqlUkV = false;

		private const bool jhffanKCqvwXXWjBxUQBrOndBsk = true;

		private const float JlLXJoxpusxLwPchqfNMDoDCCJdx = 2.5f;

		private const int leJnkqTXdAnszzsTncRzwmgNbSsM = 0;

		private const int xmCyQEoOWzJUpjUBoHYUkTOOOWmV = 0;

		private const int QGsgOYlVHJkHvrEGmcmWWXzWnTxj = 1;

		private const int nFLrTqZdaBuurgqMsjrMqafMIakn = 0;

		private const int bitQdeonCxkERCyVLZJIBiFaAEqe = 0;

		private const int pgCxFpMPMCdogDnPCHepmPEwYjkA = 0;

		private const int IcWXAOwNCmIDvhQunxORfLNZetEU = 1;

		private const int wJkQFYLROoGpKrXboQHhAMfdkDzw = 49;

		private const int QtFiUCuaaCLGeKyAIXejaoVeMFne = 0;

		private const int EFFChoeIMrkrPbcTHiuztFhTzwcKb = 1;

		private const int VcJFZzzlAWxckLPoSgLRIJnIAIgKA = 64;

		private const int uBKRbgJOWPurvavDAoFhnQAZkQnU = 48;

		private const int ckxkjjgsOXcGvyHUvIRysxssPYZE = 78;

		private const int rZyGvfjEakejOwPcgaKBfxcuLZqpA = 5;

		private const int AjCjDoTUCfZKcNDpQPbjDypZxAUi = 41;

		private const byte wzwDOTifYrqKsrPiLEnnwKnJAzUD = 1;

		private const byte DFrVOAmDRzSksndzYTlLNgOxqzWR = 2;

		private const int sWNhlJCHglDaihXCRvngWikmNBVHb = 1;

		private const int HqXVQRSJVgPIQblrYZCmzgiGpydI = 2;

		private const int MsvJxtmdpVdOOhMLUReJhTsviYKk = 3;

		private const int AlOEKvXMxBeKObUDlBbmCEFbgCug = 4;

		private const int kjKQMNmhuJzqlFQthLkKfeuVIJbr = 5;

		private const int tUFIAslParxoIjGXeAOsqtiiFcBhA = 6;

		private const int tjvozQOiprbtHoQRBtIsNGcYVQun = 8;

		private const int hJgcurfsBEmGSHXpCtOHISSTMJrh = 22;

		private const int RLHnjxibKzkpRRufWmugpYdzuDWT = 16;

		private const int KOXrSfwjkYqCJzTSwAsbsztyYSBk = 33;

		private const int zBuimTFhFSyNZlhxcrGNlcPGglBS = 8;

		private const int OdmIhKHnUMIqWwPSpQWKLzficJzP = 9;

		private const int qjJJDhdKVYNvzvPbVDAGrKQfeQSO = 10;

		private const int WIgtMvudrInuQxazYXJDhjopkICe = 28;

		private const int IKcbyBzMVcMRCWUrddOJbQPicZkhA = 53;

		private const int BglgZkprvjibClDxllCyFFLKZKB = 54;

		private const int vmuDAloskfCtTKeBZFwgERpQwwlNA = 43;

		private const int RXJLybxhtoloRrWGysWeISTVHBGd = 42;

		private const int SWYPtdpOfSomIBKhPNtrgJCcJKpO = 48;

		private const bool qsXwyHdXrnBXqDaPcUNZWMvKmwje = true;

		private const int GzzfocIhlInKVwzlafgqxzFxSqiw = 60;

		private const int deGkPuMobbJrFMjHCRlJpoaXpJLL = 60;

		private const int jXOyrGynIxpEfWfafdfXnDBwoSyj = 3000000;

		private const float whwfQTJRzmAaqzgkTFbvWgHnPqbo = 8192f;

		private const float GOwfIbnoFdBTBhmOLxcYdaZAewPqA = 0.0010652969f;

		private const float OiKltqoCZGaIprKvlYpezBoMdIpKA = 0.06103702f;

		private const bool LZPNmAIpRvqbRCqKAimuhuseAlAe = true;

		private const bool fRyaNrdtlgpjGatKtYJCdPsWthdwA = true;

		private const bool ZxrJSNDWgOMpvpFudSgJSzHSVKZx = true;

		private const bool FCEqGtfCnuNPxqgDKUCzqYAUCFZf = true;

		private const float fPHicWCAjSHAhIEmENTKxOtawIMX = 4096f;

		private const float MBgnCtoZJkIYdIzaQglcrcalAKCA = 16384f;

		private const float PAGlSCxtGJEPnxGosdXYeuSAEPTQ = 16777216f;

		private const float INTDykiIVhStDQMCgRbcpocyRwnL = 268435460f;

		private const float qOxMphrEWpOuFVGYFuiYvCPRigiJ = 0.01999998f;

		private const float zibzPojNWfeVufFaiIyTUJUHqztjA = 8192f;

		private const float yGAUNhCGzxzPAfHnMZVNhjQPlVrA = 0.98f;

		private const float xJrhdlzydnUTqrjOPiHbNzeqIFfO = 45f;

		private const float IgFaONXZhPjsaXIBHJkieVlwaDdP = 20f;

		private const DualSenseVibrationMode ziNwoJKYQkJlAXwYXeLrDRcnhAbN = DualSenseVibrationMode.Compatible2;

		private readonly IHIDDevice ZdGAobiSJtgKVSSufZEKkbWOqrot;

		private readonly HIDProperties wZOmWuPOIaODgUnRVvZwyhfFATbk;

		private readonly bool urBDemPOotqBqeojOrfYeWijKhII;

		private readonly int bRicqYdnNbwwHkipklylBEvnJrcNA;

		private readonly int hWEGHBdQlyQBbSeYolKFNefsBnwIA;

		private readonly bool lNGAvXlTjRBdbhRRCiLGCejbpaZqB;

		private readonly byte sFQUUpiRcaUTpVPFtzLehuIfiuRG;

		private readonly int etfeeqhRxzuXClxtntTdTmHsujQtA;

		private readonly int qGeivaAcooafAqvFgiGvXiMEZGyO;

		private readonly int jPWIgRUQhtNlfEChTUtzDBmifELs;

		private readonly int HPZrmGTWnrZtgFiDJjmKWZCFdazP;

		private readonly NativeBuffer WynDIcPUQZuoNwMFNYtngVTThDLT;

		private readonly NativeBuffer HuOJQfTacspCpPwKDklzixhSDESC;

		private xDlFkKEEsqHDzeOiaTIGueyqTccYA OdRhINdCygWtgcGOteXZfFdHmxobc;

		private int ErKRqWFrYXAiZhbQxEvMfCcRoflg;

		private bool JwwdfVjOEMovpkhfbRzzYlOpNtUJA;

		private bool VjMpHRPfTGaObFjrIpMYdbRBFZwK;

		private double sCIFzfCzHxAEbILAFuKwqrPaMqHD;

		private int QpNjTZhmqPgwyuhnZLWPIEQjLOw;

		private MtwXhxpbjzECHhKnnIjLQqSRTjvQ rQVliytBRDhFlMdbZQcUqmSqLSBi;

		private bool HqllTIbiACVQJgfNnOepOlDzZadi;

		private Quaternion zNUiIspBsYKIsgKmuPEojpgGhqIo = Quaternion.identity;

		private DualSenseMicrophoneLightMode ZQnWemFBWpNVIknmDXMbksoBgCwB;

		private pRIgwHFfpGZgqSqnuHJwsOTcslUH fGSVAJhhnkKevqHXxeEtERaIMKtfA;

		private DualSensePlayerLightFlags uQJcLdfcMBHqkOxiTRAyTZjAtRSZ;

		private bool SfoxMJFOPIEHDdKJRNVZGBpvGHjuA;

		private uint YdUSBXGmADBzvsDDenAWrLbOAHbjA;

		private float xovBdFFcqIfbcbSWcLDyghHqsQsCB;

		private double tjdhXOfoAURHJPKsmhoatrVWiMzrA;

		private float KJFRPDKQVBxSXCmhvQOymfaAHFbz;

		private readonly IDualSenseTriggerEffect[] luMBbcCElXnaphgekYLFLihSkgkBb = new IDualSenseTriggerEffect[2];

		private readonly byte[] kNsIxFraGrOzbecPHipaBhFnKqqbA = new byte[10];

		private readonly byte[] jZhNQnsEWMxhKwPQJIvFVtNlZphK = new byte[11];

		private DualSenseTriggerEffectState[] DJMdNaSzhKfNAvKhmDHzfleuPZgkA = new DualSenseTriggerEffectState[2];

		private DualSenseVibrationMode uSftHNJkeriiKFDvvJjWHMPImIgg;

		private byte UezQFExKNUhdAfFXcrPDuPMRyFkJA;

		private bool OVJNuzGSXISHAQHTiBGlYCSfxkGQ;

		private bool VYiKxNceQFCdEaLxnnFHVBAmUGds;

		private bool ckNjXuYrgycAAraRoOmZvqZhqkRR;

		private bool CbLiQpCvrAVuABLQHJsDGUnBjjSYA;

		private bool qMbrIyZAhXpMLlYdsUDuaSSjsRjf;

		private bool TjHfTaqEoFFCGToYuYpuzAXzlclW;

		private bool EjkPHutCzXAoExwUQzzUQKnqTARw;

		private bool ZannFNeashNZcEJvQZneTdpeyYcG;

		private bool CgqGfobKiDKGYdoTPIHSjxZgknIFb;

		private byte wfslEtjuqVKXJHXweSxJJjiowqm;

		private byte DxKYNRDuiUGcCDmfcKveDHZilumR;

		private Quaternion jFRykxwGKTjsZkdnrNHYIfHelnTub = Quaternion.identity;

		private Quaternion sGdFLqxnUgbhKukCZFnldilnADSL = Quaternion.identity;

		private bool yhuuHcCrIZplXsduuEJbHSUkNEBPA;

		private int ffwZpFaWwrqEGZPjlKUgfxhlkDJg;

		private int[] paQonnCmYRXNtoJynDGoZlnknPzR = new int[2];

		private int[] YbncaJsCCXzqLpAuGYVFXdcoWTgW = new int[2];

		private static uint[] bOGZEiztGrbbHPNoPbAkyihEgZrL = new uint[256]
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

		private const uint wGzePZFMKdhhJIPpyxoReVMHgCadb = 3940166985u;

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.VibrationMotorCount; i++)
				{
					if (vibrationMotors[i].WPYNyFAdjBraRLgEqCcHbcfbsIkf > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		public float BatteryLevel => QpNjTZhmqPgwyuhnZLWPIEQjLOw;

		public bool BatteryCharging => rQVliytBRDhFlMdbZQcUqmSqLSBi == MtwXhxpbjzECHhKnnIjLQqSRTjvQ.Charging;

		public DualSenseVibrationMode vibrationMode
		{
			get
			{
				return uSftHNJkeriiKFDvvJjWHMPImIgg;
			}
			set
			{
				uSftHNJkeriiKFDvvJjWHMPImIgg = value;
				gmdQklpwzAYKUmtJdmvUNiAWBKqi();
			}
		}

		public float LeftMotor
		{
			get
			{
				return vibrationMotors[0].EFmUVEpUcrIwRWHZCDJnLnIbiwvAA;
			}
			set
			{
				vibrationMotors[0].EFmUVEpUcrIwRWHZCDJnLnIbiwvAA = value;
			}
		}

		public float RightMotor
		{
			get
			{
				return vibrationMotors[1].EFmUVEpUcrIwRWHZCDJnLnIbiwvAA;
			}
			set
			{
				vibrationMotors[1].EFmUVEpUcrIwRWHZCDJnLnIbiwvAA = value;
			}
		}

		public float LightColorR
		{
			get
			{
				return lights[0].XuilfXHvQLvtozMStdIqbvBZEvHA;
			}
			set
			{
				lights[0].XuilfXHvQLvtozMStdIqbvBZEvHA = value;
			}
		}

		public float LightColorG
		{
			get
			{
				return lights[0].QvbgjVpFXGFLuKKcqiINoDxhmJdy;
			}
			set
			{
				lights[0].QvbgjVpFXGFLuKKcqiINoDxhmJdy = value;
			}
		}

		public float LightColorB
		{
			get
			{
				return lights[0].KZjAKBRCqWvItsiSidTaxzXnlvlP;
			}
			set
			{
				lights[0].KZjAKBRCqWvItsiSidTaxzXnlvlP = value;
			}
		}

		public float LightFlashOnDuration
		{
			get
			{
				return (int)wfslEtjuqVKXJHXweSxJJjiowqm;
			}
			set
			{
				wfslEtjuqVKXJHXweSxJJjiowqm = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				PjORlTFIHIgTRULpmSlDvHbOoYWJ();
				if (wfslEtjuqVKXJHXweSxJJjiowqm == 0 && DxKYNRDuiUGcCDmfcKveDHZilumR == 0)
				{
					VjMpHRPfTGaObFjrIpMYdbRBFZwK = true;
				}
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return (int)DxKYNRDuiUGcCDmfcKveDHZilumR;
			}
			set
			{
				DxKYNRDuiUGcCDmfcKveDHZilumR = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				PjORlTFIHIgTRULpmSlDvHbOoYWJ();
				if (wfslEtjuqVKXJHXweSxJJjiowqm == 0 && DxKYNRDuiUGcCDmfcKveDHZilumR == 0)
				{
					VjMpHRPfTGaObFjrIpMYdbRBFZwK = true;
				}
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				return ZQnWemFBWpNVIknmDXMbksoBgCwB;
			}
			set
			{
				ZQnWemFBWpNVIknmDXMbksoBgCwB = value;
				gmdQklpwzAYKUmtJdmvUNiAWBKqi();
				CbLiQpCvrAVuABLQHJsDGUnBjjSYA = true;
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				return twBhwxNWvZWTjCPoytPIReIdDbZV(fGSVAJhhnkKevqHXxeEtERaIMKtfA);
			}
			set
			{
				fGSVAJhhnkKevqHXxeEtERaIMKtfA = caPGBiKkiIyMyBzyLjPJOvlyogPq(value);
				gmdQklpwzAYKUmtJdmvUNiAWBKqi();
				TjHfTaqEoFFCGToYuYpuzAXzlclW = true;
			}
		}

		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				return uQJcLdfcMBHqkOxiTRAyTZjAtRSZ;
			}
			set
			{
				uQJcLdfcMBHqkOxiTRAyTZjAtRSZ = value;
				gmdQklpwzAYKUmtJdmvUNiAWBKqi();
				qMbrIyZAhXpMLlYdsUDuaSSjsRjf = true;
			}
		}

		public Vector3 AccelerometerValue => KUxImQGffBiXidDYRrJBrGLNWqDJ(accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui);

		public Vector3 AccelerometerValueRaw => new Vector3(accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[0], accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[1], accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[2]);

		public Vector3 GyroscopeValue => QrjKifXGtFxeyUVcmWqYuAhTpTHt(gyroscopes[0].mOMEUBQyWiiPqJDJTDuPNharRHPG);

		public Vector3 GyroscopeValueRaw => new Vector3(gyroscopes[0].QGEPzKgIedvthGPliWOduwXNjWui[0], gyroscopes[0].QGEPzKgIedvthGPliWOduwXNjWui[1], gyroscopes[0].QGEPzKgIedvthGPliWOduwXNjWui[2]);

		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[0], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[1], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[2]);
				return QrjKifXGtFxeyUVcmWqYuAhTpTHt(vector, xovBdFFcqIfbcbSWcLDyghHqsQsCB);
			}
		}

		public Vector3 LastGyroscopeValueRaw => new Vector3(gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[0], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[1], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[2]);

		public Quaternion Orientation => zNUiIspBsYKIsgKmuPEojpgGhqIo;

		public int MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => wZOmWuPOIaODgUnRVvZwyhfFATbk.vendorId;

		ushort IHIDControllerExtension.productId => wZOmWuPOIaODgUnRVvZwyhfFATbk.productId;

		string IHIDControllerExtension.productName => wZOmWuPOIaODgUnRVvZwyhfFATbk.productName;

		string IHIDControllerExtension.manufacturer => wZOmWuPOIaODgUnRVvZwyhfFATbk.manufacturer;

		ushort IHIDControllerExtension.usagePage => wZOmWuPOIaODgUnRVvZwyhfFATbk.usagePage;

		ushort IHIDControllerExtension.usage => wZOmWuPOIaODgUnRVvZwyhfFATbk.usage;

		public void ResetOrientation()
		{
			zNUiIspBsYKIsgKmuPEojpgGhqIo = Quaternion.identity;
			yhuuHcCrIZplXsduuEJbHSUkNEBPA = false;
		}

		public int GetTouchCount()
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].isTouching)
				{
					num++;
				}
			}
			return num;
		}

		public bool IsTouchingAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return false;
			}
			return touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].isTouching;
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].zDrAPvbHymMENazrJhImBDpGdtFiA(touchId);
		}

		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].touchId;
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			if (index < 0 || index >= 2)
			{
				return false;
			}
			IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] vdoCmmimVgkttAEVHxTdgHVkQBPMb = touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb;
			if (!vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].isTouching)
			{
				return false;
			}
			position.x = vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].positionX;
			position.y = vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].positionY;
			return true;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			if (!touchpads[0].zDrAPvbHymMENazrJhImBDpGdtFiA(touchId))
			{
				return false;
			}
			IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] vdoCmmimVgkttAEVHxTdgHVkQBPMb = touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb;
			for (int i = 0; i < vdoCmmimVgkttAEVHxTdgHVkQBPMb.Length; i++)
			{
				if (vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].isTouching)
				{
					position.x = vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].positionX;
					position.y = vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].positionY;
				}
			}
			return true;
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (index < 0 || index >= 2)
			{
				return false;
			}
			IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] vdoCmmimVgkttAEVHxTdgHVkQBPMb = touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb;
			if (!vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].isTouching)
			{
				return false;
			}
			positionX = vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].positionAbsX;
			positionY = vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].positionAbsY;
			return true;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!touchpads[0].zDrAPvbHymMENazrJhImBDpGdtFiA(touchId))
			{
				return false;
			}
			IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] vdoCmmimVgkttAEVHxTdgHVkQBPMb = touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb;
			for (int i = 0; i < vdoCmmimVgkttAEVHxTdgHVkQBPMb.Length; i++)
			{
				if (vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].isTouching)
				{
					positionX = vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].positionAbsX;
					positionY = vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].positionAbsY;
				}
			}
			return true;
		}

		public void StopLightFlash()
		{
			wfslEtjuqVKXJHXweSxJJjiowqm = 0;
			DxKYNRDuiUGcCDmfcKveDHZilumR = 0;
			gmdQklpwzAYKUmtJdmvUNiAWBKqi();
			VjMpHRPfTGaObFjrIpMYdbRBFZwK = true;
			EjkPHutCzXAoExwUQzzUQKnqTARw = true;
		}

		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			for (int i = 0; i < vibrationMotorCount; i++)
			{
				vibrationMotors[i].WPYNyFAdjBraRLgEqCcHbcfbsIkf = 0;
			}
		}

		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			switch (trigger)
			{
			case DualSenseTriggerType.Left:
				luMBbcCElXnaphgekYLFLihSkgkBb[0] = effect;
				gmdQklpwzAYKUmtJdmvUNiAWBKqi();
				VYiKxNceQFCdEaLxnnFHVBAmUGds = true;
				return true;
			case DualSenseTriggerType.Right:
				luMBbcCElXnaphgekYLFLihSkgkBb[1] = effect;
				gmdQklpwzAYKUmtJdmvUNiAWBKqi();
				ckNjXuYrgycAAraRoOmZvqZhqkRR = true;
				return true;
			default:
				return false;
			}
		}

		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			return new DualSenseTriggerEffectStates
			{
				leftTrigger = DJMdNaSzhKfNAvKhmDHzfleuPZgkA[0],
				rightTrigger = DJMdNaSzhKfNAvKhmDHzfleuPZgkA[1]
			};
		}

		public DualSenseDriver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			ZdGAobiSJtgKVSSufZEKkbWOqrot = P_0.hidDevice;
			wZOmWuPOIaODgUnRVvZwyhfFATbk = ZdGAobiSJtgKVSSufZEKkbWOqrot.properties;
			bRicqYdnNbwwHkipklylBEvnJrcNA = P_0.hatZeroValue;
			hWEGHBdQlyQBbSeYolKFNefsBnwIA = P_0.hatSpan;
			urBDemPOotqBqeojOrfYeWijKhII = P_0.connectionType == PWHRTOVLUXMumxboQQmQIFMHEBfDA.Bluetooth;
			if (urBDemPOotqBqeojOrfYeWijKhII)
			{
				ErKRqWFrYXAiZhbQxEvMfCcRoflg = 78;
			}
			else
			{
				ErKRqWFrYXAiZhbQxEvMfCcRoflg = 48;
			}
			WynDIcPUQZuoNwMFNYtngVTThDLT = new NativeBuffer(64);
			HuOJQfTacspCpPwKDklzixhSDESC = new NativeBuffer(ErKRqWFrYXAiZhbQxEvMfCcRoflg);
			OdRhINdCygWtgcGOteXZfFdHmxobc = new xDlFkKEEsqHDzeOiaTIGueyqTccYA(HuOJQfTacspCpPwKDklzixhSDESC.Pointer, HuOJQfTacspCpPwKDklzixhSDESC.Length, ErKRqWFrYXAiZhbQxEvMfCcRoflg);
			lights = new wcZVsiHdENbhsBlZJfyeZHJzcruiA[1]
			{
				new wcZVsiHdENbhsBlZJfyeZHJzcruiA(11, 24, 28)
			};
			lights[0].jbfGSranhZTjcNFJQWUMIeosJyxS += TQxfqoBZgxeSCedyEAdfxZDhlJWGc;
			vibrationMotors = new pmTlTYxlhgTeYOMZqBSNaIrfQJzO[2]
			{
				new pmTlTYxlhgTeYOMZqBSNaIrfQJzO(0, 255),
				new pmTlTYxlhgTeYOMZqBSNaIrfQJzO(0, 255)
			};
			vibrationMotors[0].jbfGSranhZTjcNFJQWUMIeosJyxS += lOJpkPbYtoodKHIDNYCuqegQLeEh;
			vibrationMotors[1].jbfGSranhZTjcNFJQWUMIeosJyxS += lOJpkPbYtoodKHIDNYCuqegQLeEh;
			uSftHNJkeriiKFDvvJjWHMPImIgg = DualSenseVibrationMode.Compatible2;
			OVJNuzGSXISHAQHTiBGlYCSfxkGQ = true;
			VYiKxNceQFCdEaLxnnFHVBAmUGds = true;
			ckNjXuYrgycAAraRoOmZvqZhqkRR = true;
			CbLiQpCvrAVuABLQHJsDGUnBjjSYA = true;
			qMbrIyZAhXpMLlYdsUDuaSSjsRjf = true;
			TjHfTaqEoFFCGToYuYpuzAXzlclW = true;
			EjkPHutCzXAoExwUQzzUQKnqTARw = true;
			ZannFNeashNZcEJvQZneTdpeyYcG = true;
			CgqGfobKiDKGYdoTPIHSjxZgknIFb = true;
			UezQFExKNUhdAfFXcrPDuPMRyFkJA = 2;
			if (urBDemPOotqBqeojOrfYeWijKhII)
			{
				byte[] hidFeatureData = ZdGAobiSJtgKVSSufZEKkbWOqrot.GetHidFeatureData(5, 41, 1000, 3);
				lNGAvXlTjRBdbhRRCiLGCejbpaZqB = hidFeatureData != null && hidFeatureData.Length != 0;
				if (lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
				{
					KnXskmLvonQXiuYYuDcSxklTRCgf(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous);
				}
			}
			else
			{
				lNGAvXlTjRBdbhRRCiLGCejbpaZqB = true;
				lNGAvXlTjRBdbhRRCiLGCejbpaZqB = KnXskmLvonQXiuYYuDcSxklTRCgf(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous);
			}
			if (!lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			sFQUUpiRcaUTpVPFtzLehuIfiuRG = 1;
			etfeeqhRxzuXClxtntTdTmHsujQtA = 0;
			if (urBDemPOotqBqeojOrfYeWijKhII && lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				sFQUUpiRcaUTpVPFtzLehuIfiuRG = 49;
				etfeeqhRxzuXClxtntTdTmHsujQtA = 1;
			}
			qGeivaAcooafAqvFgiGvXiMEZGyO = 8 + etfeeqhRxzuXClxtntTdTmHsujQtA;
			jPWIgRUQhtNlfEChTUtzDBmifELs = 9 + etfeeqhRxzuXClxtntTdTmHsujQtA;
			HPZrmGTWnrZtgFiDJjmKWZCFdazP = 10 + etfeeqhRxzuXClxtntTdTmHsujQtA;
			buttons = new UGvkBdUzfogfxagdjdQqdinGSMwv[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new UGvkBdUzfogfxagdjdQqdinGSMwv(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new vapXGbCthTfrBlIUGtkgzOtCLETf[6]
			{
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new DgGSAFeoadnaMFTBvLhTaezSCUDD[1]
			{
				new DgGSAFeoadnaMFTBvLhTaezSCUDD(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, seeiMBQfqrPHRiAGueuQwOdYDPRt)
			};
			accelerometers = new olIxPUWFAfTtYSNqDeGoXGwRumpd[1]
			{
				new olIxPUWFAfTtYSNqDeGoXGwRumpd(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 48
				}, 3, erEBmeCbXbRPzEwyuAMdkXOLvDNCA)
			};
			gyroscopes = new qVVbimaITgoplhjrKwIaqtLqwxTAc[1]
			{
				new qVVbimaITgoplhjrKwIaqtLqwxTAc(P_0.updateLoopSetting, sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 48
				}, 3, 60, vNZecraOwHroRIIkIlReqOExPAsZA, eRGGfDbEvCUvWHNhtrAJiLNjlgvMA)
			};
			touchpads = new IRcdnSIjiuKLhXFkJwhyNQabopZH[1]
			{
				new IRcdnSIjiuKLhXFkJwhyNQabopZH(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 48
				}, 60, rKCJvNKrEVUPtKqKvbOjKsTsDOkhA)
			};
			tjdhXOfoAURHJPKsmhoatrVWiMzrA = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			XpsptNOSAkuJQtpkRgrzactHjdaEb();
			IPxBlkRXLfFPWhuMRfsCTwsdWDubA(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Asynchronous);
		}

		public unsafe override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < WynDIcPUQZuoNwMFNYtngVTThDLT.Length)
			{
				return false;
			}
			if (urBDemPOotqBqeojOrfYeWijKhII && lNGAvXlTjRBdbhRRCiLGCejbpaZqB && *(byte*)(void*)inputReportPtr == 1)
			{
				return false;
			}
			KJFRPDKQVBxSXCmhvQOymfaAHFbz = (float)(timestamp - tjdhXOfoAURHJPKsmhoatrVWiMzrA);
			tjdhXOfoAURHJPKsmhoatrVWiMzrA = timestamp;
			WynDIcPUQZuoNwMFNYtngVTThDLT.Write(inputReportPtr, inputReportLength, WynDIcPUQZuoNwMFNYtngVTThDLT.Length);
			CZtWNUYAvWJuKUZdOhPfRshdErFs(WynDIcPUQZuoNwMFNYtngVTThDLT);
			RdPFzuLpsssVUfJbWIHhRQPBGScT(WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			YszNVDBZreQueMHaxAPTEUkXgqRz[] array = axes;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			array = hats;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			array = accelerometers;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			array = gyroscopes;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			array = touchpads;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			byte b = WynDIcPUQZuoNwMFNYtngVTThDLT[53 + etfeeqhRxzuXClxtntTdTmHsujQtA];
			oLbUnCyeNNYvXLfbHYAaQbWGNIOl oLbUnCyeNNYvXLfbHYAaQbWGNIOl2 = (oLbUnCyeNNYvXLfbHYAaQbWGNIOl)((b & 0xF0) >> 4);
			if (oLbUnCyeNNYvXLfbHYAaQbWGNIOl2 <= oLbUnCyeNNYvXLfbHYAaQbWGNIOl.Full)
			{
				if (oLbUnCyeNNYvXLfbHYAaQbWGNIOl2 > oLbUnCyeNNYvXLfbHYAaQbWGNIOl.Charging)
				{
					if (oLbUnCyeNNYvXLfbHYAaQbWGNIOl2 != oLbUnCyeNNYvXLfbHYAaQbWGNIOl.Full)
					{
						goto IL_0171;
					}
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 100;
					rQVliytBRDhFlMdbZQcUqmSqLSBi = MtwXhxpbjzECHhKnnIjLQqSRTjvQ.Full;
				}
				else
				{
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = MathTools.Clamp((b & 0xF) * 10 + 5, 0, 100);
					rQVliytBRDhFlMdbZQcUqmSqLSBi = ((oLbUnCyeNNYvXLfbHYAaQbWGNIOl2 != oLbUnCyeNNYvXLfbHYAaQbWGNIOl.Charging) ? MtwXhxpbjzECHhKnnIjLQqSRTjvQ.Discharging : MtwXhxpbjzECHhKnnIjLQqSRTjvQ.Charging);
				}
			}
			else
			{
				if (oLbUnCyeNNYvXLfbHYAaQbWGNIOl2 - 10 > oLbUnCyeNNYvXLfbHYAaQbWGNIOl.Charging)
				{
					if (oLbUnCyeNNYvXLfbHYAaQbWGNIOl2 == oLbUnCyeNNYvXLfbHYAaQbWGNIOl.ChargingError)
					{
					}
					goto IL_0171;
				}
				QpNjTZhmqPgwyuhnZLWPIEQjLOw = 0;
				rQVliytBRDhFlMdbZQcUqmSqLSBi = MtwXhxpbjzECHhKnnIjLQqSRTjvQ.Charging;
			}
			goto IL_017f;
			IL_0171:
			QpNjTZhmqPgwyuhnZLWPIEQjLOw = 0;
			rQVliytBRDhFlMdbZQcUqmSqLSBi = MtwXhxpbjzECHhKnnIjLQqSRTjvQ.Unknown;
			goto IL_017f;
			IL_017f:
			HqllTIbiACVQJgfNnOepOlDzZadi = (WynDIcPUQZuoNwMFNYtngVTThDLT[54 + etfeeqhRxzuXClxtntTdTmHsujQtA] & 1) != 0;
			DJMdNaSzhKfNAvKhmDHzfleuPZgkA[0] = ZpCftxlqOqbdICNMznqlychqBzHt(DualSenseTriggerType.Left, WynDIcPUQZuoNwMFNYtngVTThDLT[43 + etfeeqhRxzuXClxtntTdTmHsujQtA], WynDIcPUQZuoNwMFNYtngVTThDLT[48 + etfeeqhRxzuXClxtntTdTmHsujQtA]);
			DJMdNaSzhKfNAvKhmDHzfleuPZgkA[1] = ZpCftxlqOqbdICNMznqlychqBzHt(DualSenseTriggerType.Right, WynDIcPUQZuoNwMFNYtngVTThDLT[42 + etfeeqhRxzuXClxtntTdTmHsujQtA], WynDIcPUQZuoNwMFNYtngVTThDLT[48 + etfeeqhRxzuXClxtntTdTmHsujQtA]);
			QWsQgHoNItqERAYRrEUeWKzUEOwx();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void IPxBlkRXLfFPWhuMRfsCTwsdWDubA(AdGZaeWqClcGEbNkSQklXlRYcQrJ P_0)
		{
			if (JwwdfVjOEMovpkhfbRzzYlOpNtUJA)
			{
				KnXskmLvonQXiuYYuDcSxklTRCgf(P_0);
				JwwdfVjOEMovpkhfbRzzYlOpNtUJA = false;
			}
		}

		private bool KnXskmLvonQXiuYYuDcSxklTRCgf(AdGZaeWqClcGEbNkSQklXlRYcQrJ P_0)
		{
			TeBejrASFvqxZaiiEktdanDSFjglb();
			bool result = aclPpaLxnqyTLVJMfezZhuMzsQcg(P_0);
			if (VjMpHRPfTGaObFjrIpMYdbRBFZwK)
			{
				result = aclPpaLxnqyTLVJMfezZhuMzsQcg(P_0);
				VjMpHRPfTGaObFjrIpMYdbRBFZwK = false;
			}
			return result;
		}

		private void TeBejrASFvqxZaiiEktdanDSFjglb()
		{
			if (urBDemPOotqBqeojOrfYeWijKhII && lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				HuOJQfTacspCpPwKDklzixhSDESC[0] = 49;
				HuOJQfTacspCpPwKDklzixhSDESC[1] = 2;
				TeBejrASFvqxZaiiEktdanDSFjglb(HuOJQfTacspCpPwKDklzixhSDESC, 2);
				uint num = XDJHtSRTlqhCJtLvfmNRrHqlJbjd(HuOJQfTacspCpPwKDklzixhSDESC, 74);
				HuOJQfTacspCpPwKDklzixhSDESC[74] = (byte)(num & 0xFF);
				HuOJQfTacspCpPwKDklzixhSDESC[75] = (byte)((num & 0xFF00) >> 8);
				HuOJQfTacspCpPwKDklzixhSDESC[76] = (byte)((num & 0xFF0000) >> 16);
				HuOJQfTacspCpPwKDklzixhSDESC[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				HuOJQfTacspCpPwKDklzixhSDESC[0] = 2;
				TeBejrASFvqxZaiiEktdanDSFjglb(HuOJQfTacspCpPwKDklzixhSDESC, 1);
			}
		}

		private void TeBejrASFvqxZaiiEktdanDSFjglb(NativeBuffer P_0, int P_1)
		{
			PuHLtrOfLtmUhNBvMgxjBDAolrSrA puHLtrOfLtmUhNBvMgxjBDAolrSrA = PuHLtrOfLtmUhNBvMgxjBDAolrSrA.None;
			uBdhbZcFuJpSvtObKHkdEAvClDDi uBdhbZcFuJpSvtObKHkdEAvClDDi2 = uBdhbZcFuJpSvtObKHkdEAvClDDi.None;
			puHLtrOfLtmUhNBvMgxjBDAolrSrA |= PuHLtrOfLtmUhNBvMgxjBDAolrSrA.HapticsSelect;
			if (uSftHNJkeriiKFDvvJjWHMPImIgg == DualSenseVibrationMode.Compatible)
			{
				puHLtrOfLtmUhNBvMgxjBDAolrSrA |= PuHLtrOfLtmUhNBvMgxjBDAolrSrA.CompatibleVibrationMode1;
			}
			OVJNuzGSXISHAQHTiBGlYCSfxkGQ = false;
			puHLtrOfLtmUhNBvMgxjBDAolrSrA |= PuHLtrOfLtmUhNBvMgxjBDAolrSrA.LeftTriggerEffect;
			VYiKxNceQFCdEaLxnnFHVBAmUGds = false;
			puHLtrOfLtmUhNBvMgxjBDAolrSrA |= PuHLtrOfLtmUhNBvMgxjBDAolrSrA.RightTriggerEffect;
			ckNjXuYrgycAAraRoOmZvqZhqkRR = false;
			uBdhbZcFuJpSvtObKHkdEAvClDDi2 |= uBdhbZcFuJpSvtObKHkdEAvClDDi.MicrophoneLEDControl;
			CbLiQpCvrAVuABLQHJsDGUnBjjSYA = false;
			uBdhbZcFuJpSvtObKHkdEAvClDDi2 |= uBdhbZcFuJpSvtObKHkdEAvClDDi.PlayerIndicatorLEDControl;
			qMbrIyZAhXpMLlYdsUDuaSSjsRjf = false;
			uBdhbZcFuJpSvtObKHkdEAvClDDi2 |= uBdhbZcFuJpSvtObKHkdEAvClDDi.LightbarControl;
			EjkPHutCzXAoExwUQzzUQKnqTARw = false;
			uBdhbZcFuJpSvtObKHkdEAvClDDi2 |= uBdhbZcFuJpSvtObKHkdEAvClDDi.ChangeOverallMotorEffectPower;
			CgqGfobKiDKGYdoTPIHSjxZgknIFb = false;
			P_0[P_1] = (byte)puHLtrOfLtmUhNBvMgxjBDAolrSrA;
			P_0[1 + P_1] = (byte)uBdhbZcFuJpSvtObKHkdEAvClDDi2;
			P_0[2 + P_1] = (byte)vibrationMotors[1].WPYNyFAdjBraRLgEqCcHbcfbsIkf;
			P_0[3 + P_1] = (byte)vibrationMotors[0].WPYNyFAdjBraRLgEqCcHbcfbsIkf;
			P_0[8 + P_1] = (byte)ZQnWemFBWpNVIknmDXMbksoBgCwB;
			VqxmchvOJLzAkYTlSkuBgcWnGvbn vqxmchvOJLzAkYTlSkuBgcWnGvbn = VqxmchvOJLzAkYTlSkuBgcWnGvbn.None;
			vqxmchvOJLzAkYTlSkuBgcWnGvbn |= VqxmchvOJLzAkYTlSkuBgcWnGvbn.OtherLightBrightnessControl;
			TjHfTaqEoFFCGToYuYpuzAXzlclW = false;
			if (uSftHNJkeriiKFDvvJjWHMPImIgg == DualSenseVibrationMode.Compatible2)
			{
				vqxmchvOJLzAkYTlSkuBgcWnGvbn |= VqxmchvOJLzAkYTlSkuBgcWnGvbn.CompatibleVibrationMode2;
			}
			vqxmchvOJLzAkYTlSkuBgcWnGvbn |= VqxmchvOJLzAkYTlSkuBgcWnGvbn.LightbarSetupControl;
			ZannFNeashNZcEJvQZneTdpeyYcG = false;
			P_0[38 + P_1] = (byte)vqxmchvOJLzAkYTlSkuBgcWnGvbn;
			P_0[41 + P_1] = UezQFExKNUhdAfFXcrPDuPMRyFkJA;
			P_0[42 + P_1] = (byte)fGSVAJhhnkKevqHXxeEtERaIMKtfA;
			P_0[43 + P_1] = (byte)uQJcLdfcMBHqkOxiTRAyTZjAtRSZ;
			if (SfoxMJFOPIEHDdKJRNVZGBpvGHjuA)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[44 + P_1] = lights[0].qliHrwMycrHSwdrYkWwBtKZLSFkj;
			P_0[45 + P_1] = lights[0].lVKGsWgUBkpHMUSOdQPuLcJjaZjiA;
			P_0[46 + P_1] = lights[0].pkPiWyPinEsSkuGqQARVqCeMkJuv;
			TZaWXIGxoQJMzeKtmycSOmzeosos(ref luMBbcCElXnaphgekYLFLihSkgkBb[1], P_0, 10 + P_1);
			TZaWXIGxoQJMzeKtmycSOmzeosos(ref luMBbcCElXnaphgekYLFLihSkgkBb[0], P_0, 21 + P_1);
			P_0[36 + P_1] = 0;
		}

		private void TZaWXIGxoQJMzeKtmycSOmzeosos(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
			if (P_0 == null)
			{
				P_1[P_2] = 0;
				return;
			}
			switch (P_0.triggerEffectType)
			{
			case DualSenseTriggerEffectType.Off:
				XTTObJBblEPgCJBXVcVQNTmAIzAR.TZffRZDMFJwDbqsVTrkvmAdrGLQDb.VJjGVsFTJeqrdHBnuzTIUcAUDsdc(jZhNQnsEWMxhKwPQJIvFVtNlZphK, 0);
				break;
			case DualSenseTriggerEffectType.Feedback:
			{
				DualSenseTriggerEffectFeedback dualSenseTriggerEffectFeedback = (DualSenseTriggerEffectFeedback)(object)P_0;
				XTTObJBblEPgCJBXVcVQNTmAIzAR.TZffRZDMFJwDbqsVTrkvmAdrGLQDb.fOPBmizQEjnUynQRTeqVSCCwLthC(jZhNQnsEWMxhKwPQJIvFVtNlZphK, 0, dualSenseTriggerEffectFeedback.position, dualSenseTriggerEffectFeedback.strength);
				break;
			}
			case DualSenseTriggerEffectType.Weapon:
			{
				DualSenseTriggerEffectWeapon dualSenseTriggerEffectWeapon = (DualSenseTriggerEffectWeapon)(object)P_0;
				XTTObJBblEPgCJBXVcVQNTmAIzAR.TZffRZDMFJwDbqsVTrkvmAdrGLQDb.mPoSBNOoaqQGMosbucGfUncHGHUA(jZhNQnsEWMxhKwPQJIvFVtNlZphK, 0, dualSenseTriggerEffectWeapon.startPosition, dualSenseTriggerEffectWeapon.endPosition, dualSenseTriggerEffectWeapon.strength);
				break;
			}
			case DualSenseTriggerEffectType.Vibration:
			{
				DualSenseTriggerEffectVibration dualSenseTriggerEffectVibration = (DualSenseTriggerEffectVibration)(object)P_0;
				XTTObJBblEPgCJBXVcVQNTmAIzAR.TZffRZDMFJwDbqsVTrkvmAdrGLQDb.neQxlYnEyEaZhAOllmdjXIpIwFLIA(jZhNQnsEWMxhKwPQJIvFVtNlZphK, 0, dualSenseTriggerEffectVibration.position, dualSenseTriggerEffectVibration.amplitude, dualSenseTriggerEffectVibration.frequency);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionFeedback:
				((DualSenseTriggerEffectMultiplePositionFeedback)(object)P_0).strength.CopyTo(kNsIxFraGrOzbecPHipaBhFnKqqbA);
				XTTObJBblEPgCJBXVcVQNTmAIzAR.TZffRZDMFJwDbqsVTrkvmAdrGLQDb.ccVuUrNnZIBOPAkIWHqryXUNRXHZ(jZhNQnsEWMxhKwPQJIvFVtNlZphK, 0, kNsIxFraGrOzbecPHipaBhFnKqqbA);
				break;
			case DualSenseTriggerEffectType.SlopeFeedback:
			{
				DualSenseTriggerEffectSlopeFeedback dualSenseTriggerEffectSlopeFeedback = (DualSenseTriggerEffectSlopeFeedback)(object)P_0;
				XTTObJBblEPgCJBXVcVQNTmAIzAR.TZffRZDMFJwDbqsVTrkvmAdrGLQDb.ENgFHFuNUdQniYGZKQOceLPglgAI(jZhNQnsEWMxhKwPQJIvFVtNlZphK, 0, dualSenseTriggerEffectSlopeFeedback.startPosition, dualSenseTriggerEffectSlopeFeedback.endPosition, dualSenseTriggerEffectSlopeFeedback.startStrength, dualSenseTriggerEffectSlopeFeedback.endStrength);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionVibration:
			{
				DualSenseTriggerEffectMultiplePositionVibration dualSenseTriggerEffectMultiplePositionVibration = (DualSenseTriggerEffectMultiplePositionVibration)(object)P_0;
				dualSenseTriggerEffectMultiplePositionVibration.amplitude.CopyTo(kNsIxFraGrOzbecPHipaBhFnKqqbA);
				XTTObJBblEPgCJBXVcVQNTmAIzAR.TZffRZDMFJwDbqsVTrkvmAdrGLQDb.ymqsxfYBYpSiaPRfadczKsBufaIX(jZhNQnsEWMxhKwPQJIvFVtNlZphK, 0, dualSenseTriggerEffectMultiplePositionVibration.frequency, kNsIxFraGrOzbecPHipaBhFnKqqbA);
				break;
			}
			default:
				Logger.LogWarning("Unknown trigger effect type: 0x" + ((byte)P_0.triggerEffectType).ToString("x2"));
				return;
			}
			P_1.Write(jZhNQnsEWMxhKwPQJIvFVtNlZphK, jZhNQnsEWMxhKwPQJIvFVtNlZphK.Length, P_2);
		}

		private bool aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ P_0)
		{
			sCIFzfCzHxAEbILAFuKwqrPaMqHD = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous:
				return ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteSync(OdRhINdCygWtgcGOteXZfFdHmxobc, 0);
			case AdGZaeWqClcGEbNkSQklXlRYcQrJ.Asynchronous:
				ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteAsync(OdRhINdCygWtgcGOteXZfFdHmxobc, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void RdPFzuLpsssVUfJbWIHhRQPBGScT(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[qGeivaAcooafAqvFgiGvXiMEZGyO];
			buttons[0].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x10) != 0, P_1);
			buttons[1].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x20) != 0, P_1);
			buttons[2].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x40) != 0, P_1);
			buttons[3].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x80) != 0, P_1);
			b = P_0[jPWIgRUQhtNlfEChTUtzDBmifELs];
			buttons[4].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 1) != 0, P_1);
			buttons[5].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 2) != 0, P_1);
			buttons[6].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 4) != 0, P_1);
			buttons[7].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 8) != 0, P_1);
			buttons[8].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x10) != 0, P_1);
			buttons[9].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x20) != 0, P_1);
			buttons[10].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x40) != 0, P_1);
			buttons[11].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x80) != 0, P_1);
			b = P_0[HPZrmGTWnrZtgFiDJjmKWZCFdazP];
			buttons[12].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 1) != 0, P_1);
			buttons[13].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 2) != 0, P_1);
			if (lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				buttons[14].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 4) != 0, P_1);
			}
		}

		private void tNFwFMIVpqJCnYRvDmgzNUNGOLYB(YszNVDBZreQueMHaxAPTEUkXgqRz[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].trsfRiBFSIjLrLMemKcGjgULCoSi(P_1, P_2);
			}
		}

		private void XpsptNOSAkuJQtpkRgrzactHjdaEb()
		{
			if (isVibrating && ReInput.realTime >= sCIFzfCzHxAEbILAFuKwqrPaMqHD)
			{
				gmdQklpwzAYKUmtJdmvUNiAWBKqi();
				OVJNuzGSXISHAQHTiBGlYCSfxkGQ = true;
			}
		}

		private void CZtWNUYAvWJuKUZdOhPfRshdErFs(NativeBuffer P_0)
		{
			if (lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				uint num = WynDIcPUQZuoNwMFNYtngVTThDLT.ReadUInt(28 + etfeeqhRxzuXClxtntTdTmHsujQtA);
				float num3;
				if (num != YdUSBXGmADBzvsDDenAWrLbOAHbjA)
				{
					uint num2 = (uint)((num >= YdUSBXGmADBzvsDDenAWrLbOAHbjA) ? (num - YdUSBXGmADBzvsDDenAWrLbOAHbjA) : ((long)num + 4294967295L - YdUSBXGmADBzvsDDenAWrLbOAHbjA));
					num3 = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					num3 = 0f;
				}
				YdUSBXGmADBzvsDDenAWrLbOAHbjA = num;
				xovBdFFcqIfbcbSWcLDyghHqsQsCB = num3;
			}
		}

		private void QWsQgHoNItqERAYRrEUeWKzUEOwx()
		{
			if (lNGAvXlTjRBdbhRRCiLGCejbpaZqB && !(xovBdFFcqIfbcbSWcLDyghHqsQsCB <= 0f))
			{
				Vector3 vector = QrjKifXGtFxeyUVcmWqYuAhTpTHt(new Vector3(gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[0], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[1], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[2]), xovBdFFcqIfbcbSWcLDyghHqsQsCB);
				dFnDnxElNKgtXEnRVWUipJIPCNBQA(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[0] * -1f, accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[1] * -1f, accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[2] * -1f);
				HZKiaolXvBivPROkYyFrEIrCphrs(vector2, vector);
			}
		}

		private static bool dFnDnxElNKgtXEnRVWUipJIPCNBQA(ref Vector3 P_0)
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

		private void HZKiaolXvBivPROkYyFrEIrCphrs(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && qIpsAUbaZFbDTkpjgqZfuOsIYnKo(P_0, out var kMFZAkfrrzehnHhnQAdiduioIQuBb2))
			{
				Quaternion a = zNUiIspBsYKIsgKmuPEojpgGhqIo * quaternion;
				if (!yhuuHcCrIZplXsduuEJbHSUkNEBPA)
				{
					yhuuHcCrIZplXsduuEJbHSUkNEBPA = true;
					jFRykxwGKTjsZkdnrNHYIfHelnTub = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					sGdFLqxnUgbhKukCZFnldilnADSL = zNUiIspBsYKIsgKmuPEojpgGhqIo;
				}
				jFRykxwGKTjsZkdnrNHYIfHelnTub *= quaternion;
				sGdFLqxnUgbhKukCZFnldilnADSL *= quaternion;
				Quaternion b;
				if ((kMFZAkfrrzehnHhnQAdiduioIQuBb2 & kMFZAkfrrzehnHhnQAdiduioIQuBb.XZ) != kMFZAkfrrzehnHhnQAdiduioIQuBb.None)
				{
					b = PMPEUgxgyCoEmYVVZhImehqvEfad(P_0, a.eulerAngles.y);
				}
				else if ((kMFZAkfrrzehnHhnQAdiduioIQuBb2 & kMFZAkfrrzehnHhnQAdiduioIQuBb.Y) != kMFZAkfrrzehnHhnQAdiduioIQuBb.None)
				{
					b = AaabVIrfEjjkNlrbTOyjoDwtNxxv(P_0);
					Vector3 vector = sGdFLqxnUgbhKukCZFnldilnADSL * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				zNUiIspBsYKIsgKmuPEojpgGhqIo = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				zNUiIspBsYKIsgKmuPEojpgGhqIo *= quaternion;
				if (yhuuHcCrIZplXsduuEJbHSUkNEBPA)
				{
					yhuuHcCrIZplXsduuEJbHSUkNEBPA = false;
				}
			}
		}

		private static Quaternion cXxseHLUaEhifswqgmWtKVFwdTWn(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = OqtoErTcVPvPdrpqqzJEphTTxQGE(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 OqtoErTcVPvPdrpqqzJEphTTxQGE(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion yhNbdZBJgEIBisZARTEFEcepeNVl(Quaternion P_0, clgdJxGApygeEBFweJooXmtFmUPbb P_1)
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

		private float AWKzCjWURPkhuupwummLqjLEgjsw(float P_0, float P_1)
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

		private Vector3 UAqhiPKGQilDpaCJcSNVnNiUHvEKB(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion PMPEUgxgyCoEmYVVZhImehqvEfad(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion AaabVIrfEjjkNlrbTOyjoDwtNxxv(Vector3 P_0, float P_1 = 0f)
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

		private float wRmigcEVcERbvhnvYpyTBlPNJbhE(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool fOZhcxcWmvvaZnuMNRPPCaZNbwoo(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool qIpsAUbaZFbDTkpjgqZfuOsIYnKo(Vector3 P_0, out kMFZAkfrrzehnHhnQAdiduioIQuBb P_1)
		{
			P_0.Normalize();
			P_1 = kMFZAkfrrzehnHhnQAdiduioIQuBb.None;
			bool result = false;
			if (SviVhuZgtvsMQyoeJPIjegrZgEfb(P_0))
			{
				result = true;
				P_1 |= kMFZAkfrrzehnHhnQAdiduioIQuBb.XZ;
			}
			if (ttIigsljASzcBEnoKgMofdIeagUTA(P_0))
			{
				result = true;
				P_1 |= kMFZAkfrrzehnHhnQAdiduioIQuBb.Y;
			}
			return result;
		}

		private bool SviVhuZgtvsMQyoeJPIjegrZgEfb(Vector3 P_0)
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

		private bool ttIigsljASzcBEnoKgMofdIeagUTA(Vector3 P_0)
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

		private Vector3 KUxImQGffBiXidDYRrJBrGLNWqDJ(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 QrjKifXGtFxeyUVcmWqYuAhTpTHt(RingBuffer<qVVbimaITgoplhjrKwIaqtLqwxTAc.RabBRypoXYAJwkbCIuOqggayIjHt> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				qVVbimaITgoplhjrKwIaqtLqwxTAc.RabBRypoXYAJwkbCIuOqggayIjHt rabBRypoXYAJwkbCIuOqggayIjHt = P_0[i];
				result += QrjKifXGtFxeyUVcmWqYuAhTpTHt(rabBRypoXYAJwkbCIuOqggayIjHt.QGEPzKgIedvthGPliWOduwXNjWui, rabBRypoXYAJwkbCIuOqggayIjHt.rUDxkIqFCKfJYnEJOjJtlBdnXVRN);
			}
			return result;
		}

		private Vector3 QrjKifXGtFxeyUVcmWqYuAhTpTHt(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int seeiMBQfqrPHRiAGueuQwOdYDPRt(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void erEBmeCbXbRPzEwyuAMdkXOLvDNCA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void vNZecraOwHroRIIkIlReqOExPAsZA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float eRGGfDbEvCUvWHNhtrAJiLNjlgvMA()
		{
			return xovBdFFcqIfbcbSWcLDyghHqsQsCB;
		}

		private void rKCJvNKrEVUPtKqKvbOjKsTsDOkhA(NativeBuffer P_0, IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] P_1)
		{
			int num = 33 + etfeeqhRxzuXClxtntTdTmHsujQtA;
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
			P_1[0].touchId = rtxRKpGowIXKJGnkCWDEvLcjQEQV(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = rtxRKpGowIXKJGnkCWDEvLcjQEQV(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int rtxRKpGowIXKJGnkCWDEvLcjQEQV(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				paQonnCmYRXNtoJynDGoZlnknPzR[P_0] = -1;
				YbncaJsCCXzqLpAuGYVFXdcoWTgW[P_0] = P_2;
				return -1;
			}
			if (P_2 != YbncaJsCCXzqLpAuGYVFXdcoWTgW[P_0])
			{
				int num = ffwZpFaWwrqEGZPjlKUgfxhlkDJg;
				if (ffwZpFaWwrqEGZPjlKUgfxhlkDJg == int.MaxValue)
				{
					ffwZpFaWwrqEGZPjlKUgfxhlkDJg = 0;
				}
				else
				{
					ffwZpFaWwrqEGZPjlKUgfxhlkDJg++;
				}
				YbncaJsCCXzqLpAuGYVFXdcoWTgW[P_0] = P_2;
				paQonnCmYRXNtoJynDGoZlnknPzR[P_0] = num;
				return num;
			}
			return paQonnCmYRXNtoJynDGoZlnknPzR[P_0];
		}

		private void TQxfqoBZgxeSCedyEAdfxZDhlJWGc()
		{
			EjkPHutCzXAoExwUQzzUQKnqTARw = true;
			gmdQklpwzAYKUmtJdmvUNiAWBKqi();
		}

		private void PjORlTFIHIgTRULpmSlDvHbOoYWJ()
		{
			EjkPHutCzXAoExwUQzzUQKnqTARw = true;
			gmdQklpwzAYKUmtJdmvUNiAWBKqi();
		}

		private void lOJpkPbYtoodKHIDNYCuqegQLeEh()
		{
			OVJNuzGSXISHAQHTiBGlYCSfxkGQ = true;
			gmdQklpwzAYKUmtJdmvUNiAWBKqi();
		}

		private void gmdQklpwzAYKUmtJdmvUNiAWBKqi()
		{
			JwwdfVjOEMovpkhfbRzzYlOpNtUJA = true;
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
				IPxBlkRXLfFPWhuMRfsCTwsdWDubA(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous);
				if (WynDIcPUQZuoNwMFNYtngVTThDLT != null)
				{
					WynDIcPUQZuoNwMFNYtngVTThDLT.Dispose();
				}
				if (HuOJQfTacspCpPwKDklzixhSDESC != null)
				{
					HuOJQfTacspCpPwKDklzixhSDESC.Dispose();
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

		private static uint XDJHtSRTlqhCJtLvfmNRrHqlJbjd(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = bOGZEiztGrbbHPNoPbAkyihEgZrL[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static pRIgwHFfpGZgqSqnuHJwsOTcslUH caPGBiKkiIyMyBzyLjPJOvlyogPq(DualSenseOtherLightBrightness P_0)
		{
			switch (P_0)
			{
			case DualSenseOtherLightBrightness.High:
				return pRIgwHFfpGZgqSqnuHJwsOTcslUH.High;
			case DualSenseOtherLightBrightness.Medium:
				return pRIgwHFfpGZgqSqnuHJwsOTcslUH.Medium;
			case DualSenseOtherLightBrightness.Low:
				return pRIgwHFfpGZgqSqnuHJwsOTcslUH.Low;
			default:
				throw new NotImplementedException();
			}
		}

		private static DualSenseOtherLightBrightness twBhwxNWvZWTjCPoytPIReIdDbZV(pRIgwHFfpGZgqSqnuHJwsOTcslUH P_0)
		{
			switch (P_0)
			{
			case pRIgwHFfpGZgqSqnuHJwsOTcslUH.High:
				return DualSenseOtherLightBrightness.High;
			case pRIgwHFfpGZgqSqnuHJwsOTcslUH.Medium:
				return DualSenseOtherLightBrightness.Medium;
			case pRIgwHFfpGZgqSqnuHJwsOTcslUH.Low:
				return DualSenseOtherLightBrightness.Low;
			default:
				throw new NotImplementedException();
			}
		}

		private static UlmYTAdpRQvkgbHgaGHJIIkGeqNiA YtNpObhmDEWMpLiyNUemGfiHfNCk(DualSenseTriggerType P_0, byte P_1)
		{
			byte b;
			switch (P_0)
			{
			case DualSenseTriggerType.Left:
				b = new kUrPcOMIynUGhNDZwbXVDOrGblMt(P_1).qBLFfwDmmjjaCcyqBozpLgepcGdHA;
				break;
			case DualSenseTriggerType.Right:
				b = new kUrPcOMIynUGhNDZwbXVDOrGblMt(P_1).MvLzlHXHLZBAOGTRQaiLlzUOCBVGA;
				break;
			default:
				return UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Off;
			}
			switch (b)
			{
			case 0:
				return UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Off;
			case 1:
				return UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Feedback;
			case 2:
				return UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Weapon;
			case 3:
				return UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Vibration;
			case 4:
				return UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.SlopeFeedback;
			default:
				return UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Off;
			}
		}

		private static DualSenseTriggerEffectState ZpCftxlqOqbdICNMznqlychqBzHt(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			byte b = new kUrPcOMIynUGhNDZwbXVDOrGblMt(P_1).qBLFfwDmmjjaCcyqBozpLgepcGdHA;
			switch (YtNpObhmDEWMpLiyNUemGfiHfNCk(P_0, P_2))
			{
			case UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Off:
				return DualSenseTriggerEffectState.Off;
			case UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Feedback:
				switch (b)
				{
				case 0:
					return DualSenseTriggerEffectState.FeedbackIdle;
				case 1:
					return DualSenseTriggerEffectState.FeedbackApplyingForce;
				default:
					return DualSenseTriggerEffectState.FeedbackIdle;
				}
			case UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Weapon:
				switch (b)
				{
				case 0:
					return DualSenseTriggerEffectState.WeaponIdle;
				case 1:
					return DualSenseTriggerEffectState.WeaponFiring;
				case 2:
					return DualSenseTriggerEffectState.WeaponFired;
				default:
					return DualSenseTriggerEffectState.WeaponIdle;
				}
			case UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.Vibration:
				switch (b)
				{
				case 0:
					return DualSenseTriggerEffectState.VibrationIdle;
				case 1:
					return DualSenseTriggerEffectState.VibrationVibrating;
				default:
					return DualSenseTriggerEffectState.VibrationIdle;
				}
			case UlmYTAdpRQvkgbHgaGHJIIkGeqNiA.SlopeFeedback:
				switch (b)
				{
				case 0:
					return (DualSenseTriggerEffectState)8;
				case 1:
					return (DualSenseTriggerEffectState)9;
				case 2:
					return (DualSenseTriggerEffectState)10;
				default:
					return (DualSenseTriggerEffectState)8;
				}
			default:
				return DualSenseTriggerEffectState.Off;
			}
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
