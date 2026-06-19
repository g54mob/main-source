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
		private enum NCXfVyvaGUEcJyDFxVoYSXKCtPPD
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum HFuggnUJsDeVgGmKHkYSKkWvdbcAA
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum hADcHjMYjcPjtWFHfwrtgUKVZrTe : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum KApSKUcifgvAjfIOpwgOGExlHEEk : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum XBCaeFDqCpLqQePUMGfGKwkVpyQfA : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum hAJbqqQiqLaIOEoMcIlvqpsMEDlJ
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum yFcgLwGlIHIeaxwMDBOLYlatoMOIb : byte
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

		private enum NLACDWZGtlQJwMhYRogTuNLBxSPP : byte
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

		private enum oJMfAmcKMdKqvfVSNZXzURcsbEnP : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct JlYpRfrdIXccKueqbshKpRRPCGiB
		{
			private const string wbhTmUxDxUodOBEihtCGFpXiwqIm = "Value must be between 0 and 16.";

			public byte PxpKcGueaTDoQAqGAEykdoTndVVwA;

			public byte TAWTkBeNbVrSBwWVNabcodUMDHXR
			{
				get
				{
					return (byte)(PxpKcGueaTDoQAqGAEykdoTndVVwA & 0xF);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					PxpKcGueaTDoQAqGAEykdoTndVVwA = (byte)((hcjliVTTVJYlLkGmHjPVDTfwevrp << 4) | (b & 0xF));
				}
			}

			public byte hcjliVTTVJYlLkGmHjPVDTfwevrp
			{
				get
				{
					return (byte)(PxpKcGueaTDoQAqGAEykdoTndVVwA >> 4);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					PxpKcGueaTDoQAqGAEykdoTndVVwA = (byte)((b << 4) | TAWTkBeNbVrSBwWVNabcodUMDHXR);
				}
			}

			public JlYpRfrdIXccKueqbshKpRRPCGiB(byte P_0)
			{
				PxpKcGueaTDoQAqGAEykdoTndVVwA = P_0;
			}

			public JlYpRfrdIXccKueqbshKpRRPCGiB(byte P_0, byte P_1)
			{
				if (P_0 >= 16 || P_1 >= 16)
				{
					throw new ArithmeticException("Value must be between 0 and 16.");
				}
				PxpKcGueaTDoQAqGAEykdoTndVVwA = (byte)((P_1 << 4) | P_0);
			}
		}

		private static class uguqmAogkuGhJgjgEzqspqSVBOGW
		{
			public enum eNBavZydjyxYvGGvydAJVkwpHvUi : byte
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

			public static class cNIPfKtpMhlpqXZsUFXTeWLqGgUx
			{
				public static class IkVGkAlDZJUeArsWUoNZBvOGNXyB
				{
					public static bool CwfZNsOrFBcNHIpwiItEuTFNlhcP(byte[] P_0, int P_1)
					{
						return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
					}

					public static bool AbBiNoBuDzFpUEZUkMXkgGGTQMNE(byte[] P_0, int P_1, float P_2, float P_3)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						return YuxWxNjRCMeneMLQxEVmEkxcQVLEb(P_0, P_1, (byte)P_2, (byte)P_3);
					}

					public static bool JrKWeDOsPvaBtzyqaYdYIqmVpRVh(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						return CdUbeoFJTmtqJmNCVSdCfGyaCBpZb(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool TwsBDEBkYbVioYiidtmNbcWxKIRC(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						P_4 = (float)Math.Round(P_4 * 255f);
						return yIvrVDPtjbZvUgwYTzAKAeytaoNW(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool PCOWvpcxZFcMeOuMWrVaIkvokubx(byte[] P_0, int P_1, float[] P_2)
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
						return ElSaoIEVkIRTyrNXGvhEKJUgqgkW(P_0, P_1, array);
					}

					public static bool DfVrycIosSUpiqKVbRPXIHWuZFED(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						P_5 = (float)Math.Round(P_5 * 8f);
						return OknUQaESlFMNstPcqFOTZKjntHMA(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4, (byte)P_5);
					}

					public static bool ZQsOGISBrPHQzhBcRODlAuNltHxf(byte[] P_0, int P_1, float[] P_2, float P_3)
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
						return snnTmCilIhJHAKlJMbXmeXCLjHvDA(P_0, P_1, (byte)P_3, array);
					}
				}

				[Serializable]
				private sealed class orIifgvwnZMnyEpTXMWGpnxZOOpp
				{
					public static readonly orIifgvwnZMnyEpTXMWGpnxZOOpp _003C_003E9 = new orIifgvwnZMnyEpTXMWGpnxZOOpp();

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool lvYLFrSeJKnKePFsladvcRMjWmxc(byte P_0)
					{
						return P_0 > 0;
					}

					internal bool kRyILaEpxdCqEXDwaYqPVdgdjIoP(byte P_0)
					{
						return P_0 > 0;
					}
				}

				public static bool kqlgpbjdQZiPjCAtjqWTZmAZnKye(byte[] P_0, int P_1)
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

				public static bool YuxWxNjRCMeneMLQxEVmEkxcQVLEb(byte[] P_0, int P_1, byte P_2, byte P_3)
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool CdUbeoFJTmtqJmNCVSdCfGyaCBpZb(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool yIvrVDPtjbZvUgwYTzAKAeytaoNW(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool ElSaoIEVkIRTyrNXGvhEKJUgqgkW(byte[] P_0, int P_1, byte[] P_2)
				{
					if (P_2.Length != 10)
					{
						return false;
					}
					if (P_2.Any(orIifgvwnZMnyEpTXMWGpnxZOOpp._003C_003E9.lvYLFrSeJKnKePFsladvcRMjWmxc))
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool OknUQaESlFMNstPcqFOTZKjntHMA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
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
					return ElSaoIEVkIRTyrNXGvhEKJUgqgkW(P_0, P_1, array);
				}

				public static bool snnTmCilIhJHAKlJMbXmeXCLjHvDA(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					if (P_3.Length != 10)
					{
						return false;
					}
					if (P_2 > 0 && P_3.Any(orIifgvwnZMnyEpTXMWGpnxZOOpp._003C_003E9.kRyILaEpxdCqEXDwaYqPVdgdjIoP))
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool EhpdbZplQNDvHbmuGHIHqmEQSKEW(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool oSUCtwENSSRaBcPQsESWnTVERlNd(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool kJxPiltopSINjCVTJPWOGNCxEjldA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool pkxDLvJpYHWQMLDAqYczwDyFAZkr(byte[] P_0, int P_1, byte P_2, byte P_3)
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

				public static bool zrDaAJetDazZImaeZrVfHpSOmogcA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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

				public static bool rwnaRFAvPLFCpvsczJJciatIOtNlA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool pthWiJvpoefgCzSZFJXlPBWbokkl(byte[] P_0, int P_1, byte P_2, byte P_3)
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}

				public static bool pdJCRcKeUimgxgDbKWXFjlNnvHJPB(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
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
					return kqlgpbjdQZiPjCAtjqWTZmAZnKye(P_0, P_1);
				}
			}
		}

		private const float EhAEbqwuKkZqQbXrhCnwhZhdrfsr = 4f;

		private const int QZClZxxHSMREGThDWZFqWHWKkDrD = 15;

		private const int kwQKgNPOKvCcGqsDgLnzGvWySqng = 2;

		private const int NcEvDCduQlLqYhdHIeiKNCJshjOO = 0;

		private const int KspgGNElLZxcQAyriYbITaGiNlvV = 1912;

		private const int CrOnabFBlTMQPxqOwcVXhPmKGgkmA = 0;

		private const int dxRVfHaOwPhgbDTTRdylMnqHyqsH = 941;

		private const bool rEfxnQrGDBlAXLTcNgZLfrbBxhay = false;

		private const bool yiWmtLFjFOfHirANlZdQmqkoUHNC = true;

		private const float NBEBgnsTzMwDrzTulUSWURbbZOMA = 2.5f;

		private const int DjQbLJhMlbblUyjVDRaMZBtGsSY = 0;

		private const int YncUtFbbeuiHdGGgOhxfkOcVrdspA = 0;

		private const int RtjLemYNiLIFfsshtCJnFdmXqxJvA = 1;

		private const int ajfPVagaCGNpzPnOzGYjsgIbzBTr = 0;

		private const int oeoGPQUWhApPEIMlmacsijXXCrQsA = 0;

		private const int rarqEeHmSUujOcvQZePdScJjFjqkA = 0;

		private const int OmyIIasIkisQlHpusujBKNoGJMUx = 1;

		private const int dWqpazhiYgDpWfPLSRmRBiwmjEBj = 49;

		private const int NRPTCUbiuMfHiPgFZGkxHbbpSlxX = 0;

		private const int cGeJeKZvKFmFOjLEGPfKHlLsHZzc = 1;

		private const int BsqwiDjnHhSrXiwmSIHApfCZfHMq = 64;

		private const int FjHwnmMeYemYLggRbgJRbSIRyetc = 48;

		private const int tqGdCqQTdNegRjpseRNtMTctdUVcb = 78;

		private const int HplHSZkSVSiAURxNNnqtcbHIVwJJ = 5;

		private const int tKteXfbZCVtLGqCrfMTBGHenggyKA = 41;

		private const byte osYyQCrnteGrvmVqwgaHBpDiIshgA = 1;

		private const byte QNrWxJoFEWqLsEcIzxbwDkfxaCMb = 2;

		private const int MjVJvsBbNrLCGVTZECEUPhQcXKzo = 1;

		private const int hjkASRKvRZheCjFqDieaGwGYyTgtA = 2;

		private const int OdnipxrsMUhKjnpxCDjmrrcNAHaaA = 3;

		private const int eFnbxvchxbOYOxfFxVoGQxteeNRN = 4;

		private const int tqoXiyLPYuUnkXLGvzWLrPIaUhVU = 5;

		private const int gLRGeDcCNcbQsfiNGApLCPbtGeRo = 6;

		private const int NUedMxQITzUosCldboEHSZNEdNtp = 8;

		private const int ttzarrXrJwkJUtMEdSJsroChVMeM = 22;

		private const int RNJiRwCGeLfJfnTzjhSelYYsJvaA = 16;

		private const int MnAldywluKsElFyqXeODIMRFptpb = 33;

		private const int fdDBhhcEoFhfiVifQRAwExsZiTsV = 8;

		private const int TzqzjJBRqQEzZFQDLpbctowhuXce = 9;

		private const int fievHoifhMDZqlFHXNTuBhzwemLeA = 10;

		private const int KQChPOpjIhiCckLOGQSCnDYMyrHL = 28;

		private const int ZqoeWNBFhIjTKargDzEtthTcMbgGb = 53;

		private const int EHsRUqBqBXWyIOUZvnEzUXxLlSSy = 54;

		private const int TQCszgddeFdeWqgIaHpBfaZqbDaE = 43;

		private const int ITBHWPPlsDsDVGDKaEhoeuwrUKmc = 42;

		private const int odfMTfNfHlymSMVSdbreJZeJEZWK = 48;

		private const bool beOEjbIZBLtmFDJatrladDstsyrWA = true;

		private const int gQTUijQpFsIsacREykdHnAqEcOmjb = 60;

		private const int YVwFeRKBKOHZdOUIYjakNNSHfWTTA = 60;

		private const int OikjpSvaXpACKQCjTlkDJBsQPimR = 3000000;

		private const float jWZbTPRNNGpfEwUFxiXBoWHtFqMh = 8192f;

		private const float HnsksFOkMxpIGZrwYpyojBlKFNAq = 0.0010652969f;

		private const float QxjthFJrIxfYtZITWdBwIaZfeYfUA = 0.06103702f;

		private const bool RPXbvRenbBORhYCSUPMAswBFoJqR = true;

		private const bool arbazoiKIPvoPUAPRbPJNdLwPKXEb = true;

		private const bool bTSSxVhacQsEscEkhBBqZHmjFpIEA = true;

		private const bool LOsaJcNoDPPswdQgeALfMBjhMaZc = true;

		private const float uyOcBKGHzVwXUSkqmeuahocySKjUA = 4096f;

		private const float edCAxVHhQlVkcBzOOnwZqzWPcDEBb = 16384f;

		private const float vOBLlpXwEcWVgluBZMcbfXDjGwyr = 16777216f;

		private const float sPziYnxgQjkWLmmakRlZUhDfiguD = 268435460f;

		private const float TiiZLypqHbEGGdopAPYkRkBjQlhSA = 0.01999998f;

		private const float BFiwUZxULNmKupHJmfAprauhHuOG = 8192f;

		private const float KxcJTYeXiMPkjncSSEAnbaaxDXhfb = 0.98f;

		private const float fjGoBWqkOosEFejYIArtaUmquSxf = 45f;

		private const float vZNZbBFEAsuZMMmqKpCXfWcCCADy = 20f;

		private const DualSenseVibrationMode sLnhITSbNkJunNNXXZVNsSlPIuR = DualSenseVibrationMode.Compatible2;

		private readonly IHIDDevice rUuEYydrgwLcmidzIbKIRLiNhonYA;

		private readonly HIDProperties ZBZwhBWWWCHcLZPVyLMMpZeAAaGe;

		private readonly bool zZIeZCDUSyGOTdqkvrgAFUvNaMJUA;

		private readonly int OZtLZzXGeoFZXbgXCgZHjYVCLSrR;

		private readonly int WoXZeHujfoArASEOCmjydFYenMbt;

		private readonly bool JkDgpNrYTXfoizlqdSTziXiYaFWN;

		private readonly byte IEWSwgGLgWrzfUzwnWTomOjnSANi;

		private readonly int fUXITQEsrbTTbzWtgBuHCTXPAvol;

		private readonly int udpaArLOtTbmvbkOkBpIIfLYCMOGA;

		private readonly int HeVRlhavrMcHTOyFohgUPmTYGwLF;

		private readonly int aJMFpULuqeeMCgWgyYGyqudmNrhBb;

		private readonly NativeBuffer GpAUFeCZOLAoFLhxUkeBcRbxTDHT;

		private readonly NativeBuffer oaKCMoxSDnoMiCMxKNZLPNlajJYb;

		private MwEMUNdEdQpngdbXMtjwIdOvEFgfA TBaBBwkdmFfksvhzlkAEBrGdcWntb;

		private int KikdnrzvJMRmmGnzAaZEwwczGJbcA;

		private bool AMbDoanTvCussFgoOIESBDYHBESjb;

		private bool KCRnEzMORQannTmbzlyiRpVaLlJx;

		private double RUqgqzDkQkZDihrQSCPqwJcfKXRsA;

		private int ZewyoredRoejUjmFxWiKKMJDfVBab;

		private hAJbqqQiqLaIOEoMcIlvqpsMEDlJ RDuqShdJetISOcfVzQVkiMLVMjzIb;

		private bool oHYjxCaAkOdmErANkECeCONJGzJiA;

		private Quaternion NFlAyLxFQMQEmHJVadsmOCXrDeDJA = Quaternion.identity;

		private DualSenseMicrophoneLightMode JJGHWuBbobRHVeoiRkOJKSZxakEb;

		private KApSKUcifgvAjfIOpwgOGExlHEEk lKSRFzfJfdHlGifcRFmhhNMsehrfb;

		private DualSensePlayerLightFlags gNbhIbkDJHNLQvQYzWNGqQLzKUCM;

		private bool wZsdUWgIDTHXBBwsUHoqwZCkiRdpA;

		private uint wahlCPSVJMNjPLjDAfseCtReinbV;

		private float KVhFlUeMczhjddUcEbSCoCPkKSFTB;

		private double IDDcrzEdnUKQRNuMZHjeOQoMcBGeA;

		private float tYVVEprHGmIikdZxgBCGnfMZLixHA;

		private readonly IDualSenseTriggerEffect[] sgtxYavjzhHJLTJiJcUMiBaKMaoCb = new IDualSenseTriggerEffect[2];

		private readonly byte[] DNoBahEufbrzwduFFCYzzVDFnhghA = new byte[10];

		private readonly byte[] FvfIOTdJocbahdknjvpwFdciqAmf = new byte[11];

		private DualSenseTriggerEffectState[] rAcqrjcCWEVUKXKXYDcdqCkoALUY = new DualSenseTriggerEffectState[2];

		private DualSenseVibrationMode rRPDTUtEyTQGgiQddmLDeZAHoMcA;

		private byte AdfjeyhUPspUETqIiRpTuNVAyKwjA;

		private bool uBWiLlEDxDCfVIkdFMiDiUAcoBibb;

		private bool fmMJXJnSKWTxbxDPmbycBBuUfyAGb;

		private bool duqnaNQFvPtifDyJKpLtqsXvCfeg;

		private bool qGwdSSYiyUSBiecgmjHnwarBPlhR;

		private bool aZHtXVxmWbETHGDAidbemZxsteRI;

		private bool PRvrRPbDoNbiaoiUsyXGbZxpShfR;

		private bool HyFoRJYpYOfaVyDtGRSaKbxYEePk;

		private bool rFGJbDtJpaYvzKFpSiLDdBuOGLTV;

		private bool sidnbCVTQSsAPaQuNjQSrGSMGrhcA;

		private byte dihMRbymygExEMloGJkXCoPwicxc;

		private byte VzcGyaGBAALkbdQIKhRUnVurmrAWb;

		private Quaternion pwSmkGAuASwHpNpBhOJrAQAbgiMz = Quaternion.identity;

		private Quaternion JDxAAKkYqFoHWpvTJXQVQlsawpMsA = Quaternion.identity;

		private bool LHWAdHiJoUrZrCsNjEaFITVKLqhFB;

		private int OfMIBLvmZnxofkfmEeLOvUZTxfgm;

		private int[] wDXYHxipgmfoXQzdkddpzuTEpNCc = new int[2];

		private int[] ZQyDVhFxOYexWYZIGhMSAavdsLLB = new int[2];

		private static uint[] TeMUklZngyujrDvwXKURSgLOooGW = new uint[256]
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

		private const uint rBSjMKXKfbXQIeggalbjlPSZkUAL = 3940166985u;

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].rXanWTxGcklOZyeDGcMFZMCGBbhL > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualSense.BatteryLevel => ZewyoredRoejUjmFxWiKKMJDfVBab;

		bool IDriver_DualSense.BatteryCharging => RDuqShdJetISOcfVzQVkiMLVMjzIb == hAJbqqQiqLaIOEoMcIlvqpsMEDlJ.Charging;

		DualSenseVibrationMode IDriver_DualSense.vibrationMode
		{
			get
			{
				return rRPDTUtEyTQGgiQddmLDeZAHoMcA;
			}
			set
			{
				rRPDTUtEyTQGgiQddmLDeZAHoMcA = value;
				irZshuypDHVKIofmoiReibqPPwNd();
			}
		}

		float IDriver_DualSense.LeftMotor
		{
			get
			{
				return vibrationMotors[0].kebuKyNPnNUAwnkFlyJfDbfeAhBW;
			}
			set
			{
				vibrationMotors[0].kebuKyNPnNUAwnkFlyJfDbfeAhBW = value;
			}
		}

		float IDriver_DualSense.RightMotor
		{
			get
			{
				return vibrationMotors[1].kebuKyNPnNUAwnkFlyJfDbfeAhBW;
			}
			set
			{
				vibrationMotors[1].kebuKyNPnNUAwnkFlyJfDbfeAhBW = value;
			}
		}

		float IDriver_DualSense.LightColorR
		{
			get
			{
				return lights[0].OYKivTjERXZRaQCccSXNqDmvhGKCA;
			}
			set
			{
				lights[0].OYKivTjERXZRaQCccSXNqDmvhGKCA = value;
			}
		}

		float IDriver_DualSense.LightColorG
		{
			get
			{
				return lights[0].TfziCEmzXhXLDQWicRELpXxNVlrg;
			}
			set
			{
				lights[0].TfziCEmzXhXLDQWicRELpXxNVlrg = value;
			}
		}

		float IDriver_DualSense.LightColorB
		{
			get
			{
				return lights[0].xOpRkCySihaekhawqhWWFspcFMSF;
			}
			set
			{
				lights[0].xOpRkCySihaekhawqhWWFspcFMSF = value;
			}
		}

		float IDriver_DualSense.LightFlashOnDuration
		{
			get
			{
				return (int)dihMRbymygExEMloGJkXCoPwicxc;
			}
			set
			{
				dihMRbymygExEMloGJkXCoPwicxc = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				jPeujvCaxhjPloFqocZzySdmOKto();
				if (dihMRbymygExEMloGJkXCoPwicxc == 0 && VzcGyaGBAALkbdQIKhRUnVurmrAWb == 0)
				{
					KCRnEzMORQannTmbzlyiRpVaLlJx = true;
				}
			}
		}

		float IDriver_DualSense.LightFlashOffDuration
		{
			get
			{
				return (int)VzcGyaGBAALkbdQIKhRUnVurmrAWb;
			}
			set
			{
				VzcGyaGBAALkbdQIKhRUnVurmrAWb = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				jPeujvCaxhjPloFqocZzySdmOKto();
				if (dihMRbymygExEMloGJkXCoPwicxc == 0 && VzcGyaGBAALkbdQIKhRUnVurmrAWb == 0)
				{
					KCRnEzMORQannTmbzlyiRpVaLlJx = true;
				}
			}
		}

		DualSenseMicrophoneLightMode IDriver_DualSense.microphoneLightMode
		{
			get
			{
				return JJGHWuBbobRHVeoiRkOJKSZxakEb;
			}
			set
			{
				JJGHWuBbobRHVeoiRkOJKSZxakEb = value;
				irZshuypDHVKIofmoiReibqPPwNd();
				qGwdSSYiyUSBiecgmjHnwarBPlhR = true;
			}
		}

		DualSenseOtherLightBrightness IDriver_DualSense.otherLightBrightness
		{
			get
			{
				return zethEXfQpMGSFFHGFncdsXUWKGXnB(lKSRFzfJfdHlGifcRFmhhNMsehrfb);
			}
			set
			{
				lKSRFzfJfdHlGifcRFmhhNMsehrfb = EhHPWmIYHqrMggRlVBLBByDImuop(value);
				irZshuypDHVKIofmoiReibqPPwNd();
				PRvrRPbDoNbiaoiUsyXGbZxpShfR = true;
			}
		}

		DualSensePlayerLightFlags IDriver_DualSense.playerLights
		{
			get
			{
				return gNbhIbkDJHNLQvQYzWNGqQLzKUCM;
			}
			set
			{
				gNbhIbkDJHNLQvQYzWNGqQLzKUCM = value;
				irZshuypDHVKIofmoiReibqPPwNd();
				aZHtXVxmWbETHGDAidbemZxsteRI = true;
			}
		}

		Vector3 IDriver_DualSense.AccelerometerValue => AbYzOGPkrzqpyaRxotmeUANCyxST(accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq);

		Vector3 IDriver_DualSense.AccelerometerValueRaw => new Vector3(accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[0], accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[1], accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[2]);

		Vector3 IDriver_DualSense.GyroscopeValue => hOxUuWwEehxqUrFscdQdqzdJOwLM(gyroscopes[0].WCqcHNKNqnqvyfzphQRNHzkUYjOs);

		Vector3 IDriver_DualSense.GyroscopeValueRaw => new Vector3(gyroscopes[0].wXaANDSmoAgGvfdyOuMHrJOabbtz[0], gyroscopes[0].wXaANDSmoAgGvfdyOuMHrJOabbtz[1], gyroscopes[0].wXaANDSmoAgGvfdyOuMHrJOabbtz[2]);

		Vector3 IDriver_DualSense.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[0], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[1], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[2]);
				return WqmHrOGxZIMqExfDqhKjIqyXdQxeA(vector, KVhFlUeMczhjddUcEbSCoCPkKSFTB);
			}
		}

		Vector3 IDriver_DualSense.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[0], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[1], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[2]);

		Quaternion IDriver_DualSense.Orientation => NFlAyLxFQMQEmHJVadsmOCXrDeDJA;

		int IDriver_DualSense.MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => ZBZwhBWWWCHcLZPVyLMMpZeAAaGe.vendorId;

		ushort IHIDControllerExtension.productId => ZBZwhBWWWCHcLZPVyLMMpZeAAaGe.productId;

		string IHIDControllerExtension.productName => ZBZwhBWWWCHcLZPVyLMMpZeAAaGe.productName;

		string IHIDControllerExtension.manufacturer => ZBZwhBWWWCHcLZPVyLMMpZeAAaGe.manufacturer;

		ushort IHIDControllerExtension.usagePage => ZBZwhBWWWCHcLZPVyLMMpZeAAaGe.usagePage;

		ushort IHIDControllerExtension.usage => ZBZwhBWWWCHcLZPVyLMMpZeAAaGe.usage;

		public void ResetOrientation()
		{
			NFlAyLxFQMQEmHJVadsmOCXrDeDJA = Quaternion.identity;
			LHWAdHiJoUrZrCsNjEaFITVKLqhFB = false;
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
				if (touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].isTouching)
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
			return touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].isTouching;
		}

		bool IDriver_DualSense.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].tMXqrOzATSzAqZvTXLlZBoUVnLGs(touchId);
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
			return touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].touchId;
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
			hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] iVNpVhZhCmFMvyxmNYTLNjsnDNML = touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML;
			if (!iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].isTouching)
			{
				return false;
			}
			position.x = iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].positionX;
			position.y = iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].positionY;
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
			if (!touchpads[0].tMXqrOzATSzAqZvTXLlZBoUVnLGs(touchId))
			{
				return false;
			}
			hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] iVNpVhZhCmFMvyxmNYTLNjsnDNML = touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML;
			for (int i = 0; i < iVNpVhZhCmFMvyxmNYTLNjsnDNML.Length; i++)
			{
				if (iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].isTouching)
				{
					position.x = iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].positionX;
					position.y = iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].positionY;
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
			hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] iVNpVhZhCmFMvyxmNYTLNjsnDNML = touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML;
			if (!iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].isTouching)
			{
				return false;
			}
			positionX = iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].positionAbsX;
			positionY = iVNpVhZhCmFMvyxmNYTLNjsnDNML[index].positionAbsY;
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
			if (!touchpads[0].tMXqrOzATSzAqZvTXLlZBoUVnLGs(touchId))
			{
				return false;
			}
			hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] iVNpVhZhCmFMvyxmNYTLNjsnDNML = touchpads[0].iVNpVhZhCmFMvyxmNYTLNjsnDNML;
			for (int i = 0; i < iVNpVhZhCmFMvyxmNYTLNjsnDNML.Length; i++)
			{
				if (iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].isTouching)
				{
					positionX = iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].positionAbsX;
					positionY = iVNpVhZhCmFMvyxmNYTLNjsnDNML[i].positionAbsY;
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
			dihMRbymygExEMloGJkXCoPwicxc = 0;
			VzcGyaGBAALkbdQIKhRUnVurmrAWb = 0;
			irZshuypDHVKIofmoiReibqPPwNd();
			KCRnEzMORQannTmbzlyiRpVaLlJx = true;
			HyFoRJYpYOfaVyDtGRSaKbxYEePk = true;
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
				vibrationMotors[i].rXanWTxGcklOZyeDGcMFZMCGBbhL = 0;
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
				sgtxYavjzhHJLTJiJcUMiBaKMaoCb[0] = effect;
				irZshuypDHVKIofmoiReibqPPwNd();
				fmMJXJnSKWTxbxDPmbycBBuUfyAGb = true;
				return true;
			case DualSenseTriggerType.Right:
				sgtxYavjzhHJLTJiJcUMiBaKMaoCb[1] = effect;
				irZshuypDHVKIofmoiReibqPPwNd();
				duqnaNQFvPtifDyJKpLtqsXvCfeg = true;
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
				leftTrigger = rAcqrjcCWEVUKXKXYDcdqCkoALUY[0],
				rightTrigger = rAcqrjcCWEVUKXKXYDcdqCkoALUY[1]
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
			rUuEYydrgwLcmidzIbKIRLiNhonYA = P_0.hidDevice;
			ZBZwhBWWWCHcLZPVyLMMpZeAAaGe = rUuEYydrgwLcmidzIbKIRLiNhonYA.properties;
			OZtLZzXGeoFZXbgXCgZHjYVCLSrR = P_0.hatZeroValue;
			WoXZeHujfoArASEOCmjydFYenMbt = P_0.hatSpan;
			zZIeZCDUSyGOTdqkvrgAFUvNaMJUA = P_0.connectionType == gQgddHFyNfVGfPIXZPBcuigOMkbz.Bluetooth;
			if (zZIeZCDUSyGOTdqkvrgAFUvNaMJUA)
			{
				KikdnrzvJMRmmGnzAaZEwwczGJbcA = 78;
			}
			else
			{
				KikdnrzvJMRmmGnzAaZEwwczGJbcA = 48;
			}
			GpAUFeCZOLAoFLhxUkeBcRbxTDHT = new NativeBuffer(64);
			oaKCMoxSDnoMiCMxKNZLPNlajJYb = new NativeBuffer(KikdnrzvJMRmmGnzAaZEwwczGJbcA);
			TBaBBwkdmFfksvhzlkAEBrGdcWntb = new MwEMUNdEdQpngdbXMtjwIdOvEFgfA(oaKCMoxSDnoMiCMxKNZLPNlajJYb.Pointer, oaKCMoxSDnoMiCMxKNZLPNlajJYb.Length, KikdnrzvJMRmmGnzAaZEwwczGJbcA);
			lights = new TlkpubcBJbLfvkJeODXKdsluGNyG[1]
			{
				new TlkpubcBJbLfvkJeODXKdsluGNyG(11, 24, 28)
			};
			lights[0].ieqOaerHmHMqFmIjZGBVkdVIFYNf += JRynRuPOFeNQNWPRrhXRMfoDovSQ;
			vibrationMotors = new OuyedDeYgCfMJhRepxbdANVcvqtM[2]
			{
				new OuyedDeYgCfMJhRepxbdANVcvqtM(0, 255),
				new OuyedDeYgCfMJhRepxbdANVcvqtM(0, 255)
			};
			vibrationMotors[0].hzMbcPJOtgkpFhGaEaJpzIVCRwkNA += KMQdVqntnbcmXgNRZpGzCqENJAgj;
			vibrationMotors[1].hzMbcPJOtgkpFhGaEaJpzIVCRwkNA += KMQdVqntnbcmXgNRZpGzCqENJAgj;
			rRPDTUtEyTQGgiQddmLDeZAHoMcA = DualSenseVibrationMode.Compatible2;
			uBWiLlEDxDCfVIkdFMiDiUAcoBibb = true;
			fmMJXJnSKWTxbxDPmbycBBuUfyAGb = true;
			duqnaNQFvPtifDyJKpLtqsXvCfeg = true;
			qGwdSSYiyUSBiecgmjHnwarBPlhR = true;
			aZHtXVxmWbETHGDAidbemZxsteRI = true;
			PRvrRPbDoNbiaoiUsyXGbZxpShfR = true;
			HyFoRJYpYOfaVyDtGRSaKbxYEePk = true;
			rFGJbDtJpaYvzKFpSiLDdBuOGLTV = true;
			sidnbCVTQSsAPaQuNjQSrGSMGrhcA = true;
			AdfjeyhUPspUETqIiRpTuNVAyKwjA = 2;
			if (zZIeZCDUSyGOTdqkvrgAFUvNaMJUA)
			{
				byte[] hidFeatureData = rUuEYydrgwLcmidzIbKIRLiNhonYA.GetHidFeatureData(5, 41, 1000, 3);
				JkDgpNrYTXfoizlqdSTziXiYaFWN = hidFeatureData != null && hidFeatureData.Length != 0;
				if (JkDgpNrYTXfoizlqdSTziXiYaFWN)
				{
					YaHItoswabvKirwYaJTAdKVwkmoe(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous);
				}
			}
			else
			{
				JkDgpNrYTXfoizlqdSTziXiYaFWN = true;
				JkDgpNrYTXfoizlqdSTziXiYaFWN = YaHItoswabvKirwYaJTAdKVwkmoe(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous);
			}
			if (!JkDgpNrYTXfoizlqdSTziXiYaFWN)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			IEWSwgGLgWrzfUzwnWTomOjnSANi = 1;
			fUXITQEsrbTTbzWtgBuHCTXPAvol = 0;
			if (zZIeZCDUSyGOTdqkvrgAFUvNaMJUA && JkDgpNrYTXfoizlqdSTziXiYaFWN)
			{
				IEWSwgGLgWrzfUzwnWTomOjnSANi = 49;
				fUXITQEsrbTTbzWtgBuHCTXPAvol = 1;
			}
			udpaArLOtTbmvbkOkBpIIfLYCMOGA = 8 + fUXITQEsrbTTbzWtgBuHCTXPAvol;
			HeVRlhavrMcHTOyFohgUPmTYGwLF = 9 + fUXITQEsrbTTbzWtgBuHCTXPAvol;
			aJMFpULuqeeMCgWgyYGyqudmNrhBb = 10 + fUXITQEsrbTTbzWtgBuHCTXPAvol;
			buttons = new jIFGialkYdAmDDAGsjKrXJoDparB[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new jIFGialkYdAmDDAGsjKrXJoDparB(IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new OLAxjmdqJbHeCArvVCNIDgdBciXE[6]
			{
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new OLAxjmdqJbHeCArvVCNIDgdBciXE(IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new cqHyUHXvbVNypcmuagNrSpCNtoPi[1]
			{
				new cqHyUHXvbVNypcmuagNrSpCNtoPi(IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, wDjGhWKjqITRrhHynWwpimbiEvns)
			};
			accelerometers = new JIxBNLfOAPhdPBxkKRDEqbmYHLnib[1]
			{
				new JIxBNLfOAPhdPBxkKRDEqbmYHLnib(IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 48
				}, 3, XfvwBOKuLjFrvKHQWkLQytzPGexn)
			};
			gyroscopes = new XeuQUxbgIYfXehYWxYnOrZfhgALkA[1]
			{
				new XeuQUxbgIYfXehYWxYnOrZfhgALkA(P_0.updateLoopSetting, IEWSwgGLgWrzfUzwnWTomOjnSANi, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 48
				}, 3, 60, FFoVxNRjifwxRnVORYJjbdQVaZtU, RfUZrmbhgAgjKvInsemKsBXlliji)
			};
			touchpads = new hwDBnDzZlOwqwaLOCXGWdEQuXFFf[1]
			{
				new hwDBnDzZlOwqwaLOCXGWdEQuXFFf(IEWSwgGLgWrzfUzwnWTomOjnSANi, new hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + fUXITQEsrbTTbzWtgBuHCTXPAvol,
					bitSize = 48
				}, 60, BVJaBJKkgtarjWRsQeZpBXbllbRDb)
			};
			IDDcrzEdnUKQRNuMZHjeOQoMcBGeA = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			GFCENzJzPgFfhjHXeDpPlcTtSkBiA();
			eWkaqNCdeBSZfdmOfNnzIUzQpZDVA(pVnphHvTNRURYWZADvNPfpgNNbuB.Asynchronous);
		}

		public unsafe override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < GpAUFeCZOLAoFLhxUkeBcRbxTDHT.Length)
			{
				return false;
			}
			if (zZIeZCDUSyGOTdqkvrgAFUvNaMJUA && JkDgpNrYTXfoizlqdSTziXiYaFWN && *(byte*)(void*)inputReportPtr == 1)
			{
				return false;
			}
			tYVVEprHGmIikdZxgBCGnfMZLixHA = (float)(timestamp - IDDcrzEdnUKQRNuMZHjeOQoMcBGeA);
			IDDcrzEdnUKQRNuMZHjeOQoMcBGeA = timestamp;
			GpAUFeCZOLAoFLhxUkeBcRbxTDHT.Write(inputReportPtr, inputReportLength, GpAUFeCZOLAoFLhxUkeBcRbxTDHT.Length);
			gZbybGYzHIbxCDtASqeSKprmqNpt(GpAUFeCZOLAoFLhxUkeBcRbxTDHT);
			GDZKiLiaNOIZWRLONrofPgIjFcmX(GpAUFeCZOLAoFLhxUkeBcRbxTDHT, timestamp);
			tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] array = axes;
			vvDxLIJLOfxspPCvgeQjujfXRVHm(array, GpAUFeCZOLAoFLhxUkeBcRbxTDHT, timestamp);
			array = hats;
			vvDxLIJLOfxspPCvgeQjujfXRVHm(array, GpAUFeCZOLAoFLhxUkeBcRbxTDHT, timestamp);
			array = accelerometers;
			vvDxLIJLOfxspPCvgeQjujfXRVHm(array, GpAUFeCZOLAoFLhxUkeBcRbxTDHT, timestamp);
			array = gyroscopes;
			vvDxLIJLOfxspPCvgeQjujfXRVHm(array, GpAUFeCZOLAoFLhxUkeBcRbxTDHT, timestamp);
			array = touchpads;
			vvDxLIJLOfxspPCvgeQjujfXRVHm(array, GpAUFeCZOLAoFLhxUkeBcRbxTDHT, timestamp);
			byte b = GpAUFeCZOLAoFLhxUkeBcRbxTDHT[53 + fUXITQEsrbTTbzWtgBuHCTXPAvol];
			XBCaeFDqCpLqQePUMGfGKwkVpyQfA xBCaeFDqCpLqQePUMGfGKwkVpyQfA = (XBCaeFDqCpLqQePUMGfGKwkVpyQfA)((b & 0xF0) >> 4);
			if (xBCaeFDqCpLqQePUMGfGKwkVpyQfA <= XBCaeFDqCpLqQePUMGfGKwkVpyQfA.Full)
			{
				if (xBCaeFDqCpLqQePUMGfGKwkVpyQfA > XBCaeFDqCpLqQePUMGfGKwkVpyQfA.Charging)
				{
					if (xBCaeFDqCpLqQePUMGfGKwkVpyQfA != XBCaeFDqCpLqQePUMGfGKwkVpyQfA.Full)
					{
						goto IL_0171;
					}
					ZewyoredRoejUjmFxWiKKMJDfVBab = 100;
					RDuqShdJetISOcfVzQVkiMLVMjzIb = hAJbqqQiqLaIOEoMcIlvqpsMEDlJ.Full;
				}
				else
				{
					ZewyoredRoejUjmFxWiKKMJDfVBab = MathTools.Clamp((b & 0xF) * 10 + 5, 0, 100);
					RDuqShdJetISOcfVzQVkiMLVMjzIb = ((xBCaeFDqCpLqQePUMGfGKwkVpyQfA != XBCaeFDqCpLqQePUMGfGKwkVpyQfA.Charging) ? hAJbqqQiqLaIOEoMcIlvqpsMEDlJ.Discharging : hAJbqqQiqLaIOEoMcIlvqpsMEDlJ.Charging);
				}
			}
			else
			{
				if (xBCaeFDqCpLqQePUMGfGKwkVpyQfA - 10 > XBCaeFDqCpLqQePUMGfGKwkVpyQfA.Charging)
				{
					if (xBCaeFDqCpLqQePUMGfGKwkVpyQfA == XBCaeFDqCpLqQePUMGfGKwkVpyQfA.ChargingError)
					{
					}
					goto IL_0171;
				}
				ZewyoredRoejUjmFxWiKKMJDfVBab = 0;
				RDuqShdJetISOcfVzQVkiMLVMjzIb = hAJbqqQiqLaIOEoMcIlvqpsMEDlJ.Charging;
			}
			goto IL_017f;
			IL_0171:
			ZewyoredRoejUjmFxWiKKMJDfVBab = 0;
			RDuqShdJetISOcfVzQVkiMLVMjzIb = hAJbqqQiqLaIOEoMcIlvqpsMEDlJ.Unknown;
			goto IL_017f;
			IL_017f:
			oHYjxCaAkOdmErANkECeCONJGzJiA = (GpAUFeCZOLAoFLhxUkeBcRbxTDHT[54 + fUXITQEsrbTTbzWtgBuHCTXPAvol] & 1) != 0;
			rAcqrjcCWEVUKXKXYDcdqCkoALUY[0] = JLnRlTSuAJoVaiwuauDKrzbgnjbI(DualSenseTriggerType.Left, GpAUFeCZOLAoFLhxUkeBcRbxTDHT[43 + fUXITQEsrbTTbzWtgBuHCTXPAvol], GpAUFeCZOLAoFLhxUkeBcRbxTDHT[48 + fUXITQEsrbTTbzWtgBuHCTXPAvol]);
			rAcqrjcCWEVUKXKXYDcdqCkoALUY[1] = JLnRlTSuAJoVaiwuauDKrzbgnjbI(DualSenseTriggerType.Right, GpAUFeCZOLAoFLhxUkeBcRbxTDHT[42 + fUXITQEsrbTTbzWtgBuHCTXPAvol], GpAUFeCZOLAoFLhxUkeBcRbxTDHT[48 + fUXITQEsrbTTbzWtgBuHCTXPAvol]);
			vfwibxJAfpmaWupDFEjKlxKHSgXW();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void eWkaqNCdeBSZfdmOfNnzIUzQpZDVA(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			if (AMbDoanTvCussFgoOIESBDYHBESjb)
			{
				YaHItoswabvKirwYaJTAdKVwkmoe(P_0);
				AMbDoanTvCussFgoOIESBDYHBESjb = false;
			}
		}

		private bool YaHItoswabvKirwYaJTAdKVwkmoe(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			zRQqozJnYoccJbhqPeXirJKChPsi();
			bool result = tVgUmVgVwecMJOmaZigtpKNHWVUA(P_0);
			if (KCRnEzMORQannTmbzlyiRpVaLlJx)
			{
				result = tVgUmVgVwecMJOmaZigtpKNHWVUA(P_0);
				KCRnEzMORQannTmbzlyiRpVaLlJx = false;
			}
			return result;
		}

		private void zRQqozJnYoccJbhqPeXirJKChPsi()
		{
			if (zZIeZCDUSyGOTdqkvrgAFUvNaMJUA && JkDgpNrYTXfoizlqdSTziXiYaFWN)
			{
				oaKCMoxSDnoMiCMxKNZLPNlajJYb[0] = 49;
				oaKCMoxSDnoMiCMxKNZLPNlajJYb[1] = 2;
				MNRastGmXwEfMZumfMTDWsNVQnBrA(oaKCMoxSDnoMiCMxKNZLPNlajJYb, 2);
				uint num = sHblGholuLLcRpyaxoKNhXvnuIfw(oaKCMoxSDnoMiCMxKNZLPNlajJYb, 74);
				oaKCMoxSDnoMiCMxKNZLPNlajJYb[74] = (byte)(num & 0xFF);
				oaKCMoxSDnoMiCMxKNZLPNlajJYb[75] = (byte)((num & 0xFF00) >> 8);
				oaKCMoxSDnoMiCMxKNZLPNlajJYb[76] = (byte)((num & 0xFF0000) >> 16);
				oaKCMoxSDnoMiCMxKNZLPNlajJYb[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				oaKCMoxSDnoMiCMxKNZLPNlajJYb[0] = 2;
				MNRastGmXwEfMZumfMTDWsNVQnBrA(oaKCMoxSDnoMiCMxKNZLPNlajJYb, 1);
			}
		}

		private void MNRastGmXwEfMZumfMTDWsNVQnBrA(NativeBuffer P_0, int P_1)
		{
			yFcgLwGlIHIeaxwMDBOLYlatoMOIb yFcgLwGlIHIeaxwMDBOLYlatoMOIb2 = yFcgLwGlIHIeaxwMDBOLYlatoMOIb.None;
			NLACDWZGtlQJwMhYRogTuNLBxSPP nLACDWZGtlQJwMhYRogTuNLBxSPP = NLACDWZGtlQJwMhYRogTuNLBxSPP.None;
			yFcgLwGlIHIeaxwMDBOLYlatoMOIb2 |= yFcgLwGlIHIeaxwMDBOLYlatoMOIb.HapticsSelect;
			if (rRPDTUtEyTQGgiQddmLDeZAHoMcA == DualSenseVibrationMode.Compatible)
			{
				yFcgLwGlIHIeaxwMDBOLYlatoMOIb2 |= yFcgLwGlIHIeaxwMDBOLYlatoMOIb.CompatibleVibrationMode1;
			}
			uBWiLlEDxDCfVIkdFMiDiUAcoBibb = false;
			yFcgLwGlIHIeaxwMDBOLYlatoMOIb2 |= yFcgLwGlIHIeaxwMDBOLYlatoMOIb.LeftTriggerEffect;
			fmMJXJnSKWTxbxDPmbycBBuUfyAGb = false;
			yFcgLwGlIHIeaxwMDBOLYlatoMOIb2 |= yFcgLwGlIHIeaxwMDBOLYlatoMOIb.RightTriggerEffect;
			duqnaNQFvPtifDyJKpLtqsXvCfeg = false;
			nLACDWZGtlQJwMhYRogTuNLBxSPP |= NLACDWZGtlQJwMhYRogTuNLBxSPP.MicrophoneLEDControl;
			qGwdSSYiyUSBiecgmjHnwarBPlhR = false;
			nLACDWZGtlQJwMhYRogTuNLBxSPP |= NLACDWZGtlQJwMhYRogTuNLBxSPP.PlayerIndicatorLEDControl;
			aZHtXVxmWbETHGDAidbemZxsteRI = false;
			nLACDWZGtlQJwMhYRogTuNLBxSPP |= NLACDWZGtlQJwMhYRogTuNLBxSPP.LightbarControl;
			HyFoRJYpYOfaVyDtGRSaKbxYEePk = false;
			nLACDWZGtlQJwMhYRogTuNLBxSPP |= NLACDWZGtlQJwMhYRogTuNLBxSPP.ChangeOverallMotorEffectPower;
			sidnbCVTQSsAPaQuNjQSrGSMGrhcA = false;
			P_0[P_1] = (byte)yFcgLwGlIHIeaxwMDBOLYlatoMOIb2;
			P_0[1 + P_1] = (byte)nLACDWZGtlQJwMhYRogTuNLBxSPP;
			P_0[2 + P_1] = (byte)vibrationMotors[1].rXanWTxGcklOZyeDGcMFZMCGBbhL;
			P_0[3 + P_1] = (byte)vibrationMotors[0].rXanWTxGcklOZyeDGcMFZMCGBbhL;
			P_0[8 + P_1] = (byte)JJGHWuBbobRHVeoiRkOJKSZxakEb;
			oJMfAmcKMdKqvfVSNZXzURcsbEnP oJMfAmcKMdKqvfVSNZXzURcsbEnP2 = oJMfAmcKMdKqvfVSNZXzURcsbEnP.None;
			oJMfAmcKMdKqvfVSNZXzURcsbEnP2 |= oJMfAmcKMdKqvfVSNZXzURcsbEnP.OtherLightBrightnessControl;
			PRvrRPbDoNbiaoiUsyXGbZxpShfR = false;
			if (rRPDTUtEyTQGgiQddmLDeZAHoMcA == DualSenseVibrationMode.Compatible2)
			{
				oJMfAmcKMdKqvfVSNZXzURcsbEnP2 |= oJMfAmcKMdKqvfVSNZXzURcsbEnP.CompatibleVibrationMode2;
			}
			oJMfAmcKMdKqvfVSNZXzURcsbEnP2 |= oJMfAmcKMdKqvfVSNZXzURcsbEnP.LightbarSetupControl;
			rFGJbDtJpaYvzKFpSiLDdBuOGLTV = false;
			P_0[38 + P_1] = (byte)oJMfAmcKMdKqvfVSNZXzURcsbEnP2;
			P_0[41 + P_1] = AdfjeyhUPspUETqIiRpTuNVAyKwjA;
			P_0[42 + P_1] = (byte)lKSRFzfJfdHlGifcRFmhhNMsehrfb;
			P_0[43 + P_1] = (byte)gNbhIbkDJHNLQvQYzWNGqQLzKUCM;
			if (wZsdUWgIDTHXBBwsUHoqwZCkiRdpA)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[44 + P_1] = lights[0].LLchhSHiYWLgKJawqrLLaTDNyKxcA;
			P_0[45 + P_1] = lights[0].HqCVfkrMQUVRcbdOevdmSmRmtWNj;
			P_0[46 + P_1] = lights[0].jSiVbYCgDkpLtoziFaBcgRJEJmvE;
			soMtUvmVIddkjAiYKRvDAxLSqZJk(ref sgtxYavjzhHJLTJiJcUMiBaKMaoCb[1], P_0, 10 + P_1);
			soMtUvmVIddkjAiYKRvDAxLSqZJk(ref sgtxYavjzhHJLTJiJcUMiBaKMaoCb[0], P_0, 21 + P_1);
			P_0[36 + P_1] = 0;
		}

		private void soMtUvmVIddkjAiYKRvDAxLSqZJk(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
			if (P_0 == null)
			{
				P_1[P_2] = 0;
				return;
			}
			switch (P_0.triggerEffectType)
			{
			case DualSenseTriggerEffectType.Off:
				uguqmAogkuGhJgjgEzqspqSVBOGW.cNIPfKtpMhlpqXZsUFXTeWLqGgUx.kqlgpbjdQZiPjCAtjqWTZmAZnKye(FvfIOTdJocbahdknjvpwFdciqAmf, 0);
				break;
			case DualSenseTriggerEffectType.Feedback:
			{
				DualSenseTriggerEffectFeedback dualSenseTriggerEffectFeedback = (DualSenseTriggerEffectFeedback)(object)P_0;
				uguqmAogkuGhJgjgEzqspqSVBOGW.cNIPfKtpMhlpqXZsUFXTeWLqGgUx.YuxWxNjRCMeneMLQxEVmEkxcQVLEb(FvfIOTdJocbahdknjvpwFdciqAmf, 0, dualSenseTriggerEffectFeedback.position, dualSenseTriggerEffectFeedback.strength);
				break;
			}
			case DualSenseTriggerEffectType.Weapon:
			{
				DualSenseTriggerEffectWeapon dualSenseTriggerEffectWeapon = (DualSenseTriggerEffectWeapon)(object)P_0;
				uguqmAogkuGhJgjgEzqspqSVBOGW.cNIPfKtpMhlpqXZsUFXTeWLqGgUx.CdUbeoFJTmtqJmNCVSdCfGyaCBpZb(FvfIOTdJocbahdknjvpwFdciqAmf, 0, dualSenseTriggerEffectWeapon.startPosition, dualSenseTriggerEffectWeapon.endPosition, dualSenseTriggerEffectWeapon.strength);
				break;
			}
			case DualSenseTriggerEffectType.Vibration:
			{
				DualSenseTriggerEffectVibration dualSenseTriggerEffectVibration = (DualSenseTriggerEffectVibration)(object)P_0;
				uguqmAogkuGhJgjgEzqspqSVBOGW.cNIPfKtpMhlpqXZsUFXTeWLqGgUx.yIvrVDPtjbZvUgwYTzAKAeytaoNW(FvfIOTdJocbahdknjvpwFdciqAmf, 0, dualSenseTriggerEffectVibration.position, dualSenseTriggerEffectVibration.amplitude, dualSenseTriggerEffectVibration.frequency);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionFeedback:
				((DualSenseTriggerEffectMultiplePositionFeedback)(object)P_0).strength.CopyTo(DNoBahEufbrzwduFFCYzzVDFnhghA);
				uguqmAogkuGhJgjgEzqspqSVBOGW.cNIPfKtpMhlpqXZsUFXTeWLqGgUx.ElSaoIEVkIRTyrNXGvhEKJUgqgkW(FvfIOTdJocbahdknjvpwFdciqAmf, 0, DNoBahEufbrzwduFFCYzzVDFnhghA);
				break;
			case DualSenseTriggerEffectType.SlopeFeedback:
			{
				DualSenseTriggerEffectSlopeFeedback dualSenseTriggerEffectSlopeFeedback = (DualSenseTriggerEffectSlopeFeedback)(object)P_0;
				uguqmAogkuGhJgjgEzqspqSVBOGW.cNIPfKtpMhlpqXZsUFXTeWLqGgUx.OknUQaESlFMNstPcqFOTZKjntHMA(FvfIOTdJocbahdknjvpwFdciqAmf, 0, dualSenseTriggerEffectSlopeFeedback.startPosition, dualSenseTriggerEffectSlopeFeedback.endPosition, dualSenseTriggerEffectSlopeFeedback.startStrength, dualSenseTriggerEffectSlopeFeedback.endStrength);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionVibration:
			{
				DualSenseTriggerEffectMultiplePositionVibration dualSenseTriggerEffectMultiplePositionVibration = (DualSenseTriggerEffectMultiplePositionVibration)(object)P_0;
				dualSenseTriggerEffectMultiplePositionVibration.amplitude.CopyTo(DNoBahEufbrzwduFFCYzzVDFnhghA);
				uguqmAogkuGhJgjgEzqspqSVBOGW.cNIPfKtpMhlpqXZsUFXTeWLqGgUx.snnTmCilIhJHAKlJMbXmeXCLjHvDA(FvfIOTdJocbahdknjvpwFdciqAmf, 0, dualSenseTriggerEffectMultiplePositionVibration.frequency, DNoBahEufbrzwduFFCYzzVDFnhghA);
				break;
			}
			default:
				Logger.LogWarning("Unknown trigger effect type: 0x" + ((byte)P_0.triggerEffectType).ToString("x2"));
				return;
			}
			P_1.Write(FvfIOTdJocbahdknjvpwFdciqAmf, FvfIOTdJocbahdknjvpwFdciqAmf.Length, P_2);
		}

		private bool tVgUmVgVwecMJOmaZigtpKNHWVUA(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			RUqgqzDkQkZDihrQSCPqwJcfKXRsA = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous:
				return rUuEYydrgwLcmidzIbKIRLiNhonYA.WriteSync(TBaBBwkdmFfksvhzlkAEBrGdcWntb, 0);
			case pVnphHvTNRURYWZADvNPfpgNNbuB.Asynchronous:
				rUuEYydrgwLcmidzIbKIRLiNhonYA.WriteAsync(TBaBBwkdmFfksvhzlkAEBrGdcWntb, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void GDZKiLiaNOIZWRLONrofPgIjFcmX(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[udpaArLOtTbmvbkOkBpIIfLYCMOGA];
			buttons[0].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x10) != 0, P_1);
			buttons[1].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x20) != 0, P_1);
			buttons[2].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x40) != 0, P_1);
			buttons[3].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x80) != 0, P_1);
			b = P_0[HeVRlhavrMcHTOyFohgUPmTYGwLF];
			buttons[4].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 1) != 0, P_1);
			buttons[5].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 2) != 0, P_1);
			buttons[6].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 4) != 0, P_1);
			buttons[7].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 8) != 0, P_1);
			buttons[8].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x10) != 0, P_1);
			buttons[9].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x20) != 0, P_1);
			buttons[10].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x40) != 0, P_1);
			buttons[11].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 0x80) != 0, P_1);
			b = P_0[aJMFpULuqeeMCgWgyYGyqudmNrhBb];
			buttons[12].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 1) != 0, P_1);
			buttons[13].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 2) != 0, P_1);
			if (JkDgpNrYTXfoizlqdSTziXiYaFWN)
			{
				buttons[14].fihwdEXCUmtjghmZzTkajeNnBqkZ((b & 4) != 0, P_1);
			}
		}

		private void vvDxLIJLOfxspPCvgeQjujfXRVHm(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].SnJrVNcoeoNiXCCQLiNahDsWooVr(P_1, P_2);
			}
		}

		private void GFCENzJzPgFfhjHXeDpPlcTtSkBiA()
		{
			if (isVibrating && ReInput.realTime >= RUqgqzDkQkZDihrQSCPqwJcfKXRsA)
			{
				irZshuypDHVKIofmoiReibqPPwNd();
				uBWiLlEDxDCfVIkdFMiDiUAcoBibb = true;
			}
		}

		private void gZbybGYzHIbxCDtASqeSKprmqNpt(NativeBuffer P_0)
		{
			if (JkDgpNrYTXfoizlqdSTziXiYaFWN)
			{
				uint num = GpAUFeCZOLAoFLhxUkeBcRbxTDHT.ReadUInt(28 + fUXITQEsrbTTbzWtgBuHCTXPAvol);
				float kVhFlUeMczhjddUcEbSCoCPkKSFTB;
				if (num != wahlCPSVJMNjPLjDAfseCtReinbV)
				{
					uint num2 = (uint)((num >= wahlCPSVJMNjPLjDAfseCtReinbV) ? (num - wahlCPSVJMNjPLjDAfseCtReinbV) : ((long)num + 4294967295L - wahlCPSVJMNjPLjDAfseCtReinbV));
					kVhFlUeMczhjddUcEbSCoCPkKSFTB = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					kVhFlUeMczhjddUcEbSCoCPkKSFTB = 0f;
				}
				wahlCPSVJMNjPLjDAfseCtReinbV = num;
				KVhFlUeMczhjddUcEbSCoCPkKSFTB = kVhFlUeMczhjddUcEbSCoCPkKSFTB;
			}
		}

		private void vfwibxJAfpmaWupDFEjKlxKHSgXW()
		{
			if (JkDgpNrYTXfoizlqdSTziXiYaFWN && !(KVhFlUeMczhjddUcEbSCoCPkKSFTB <= 0f))
			{
				Vector3 vector = WqmHrOGxZIMqExfDqhKjIqyXdQxeA(new Vector3(gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[0], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[1], gyroscopes[0].fiIBUWbzGCfvemOsFmTtDwkcsSkyB[2]), KVhFlUeMczhjddUcEbSCoCPkKSFTB);
				uoMxsbLfzdEjtbURpbihgtcJcIppB(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[0] * -1f, accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[1] * -1f, accelerometers[0].idaOHKBnMGIFbSErnXWBOkCLqsFq[2] * -1f);
				YsPgrVQVnuutPVWvrjLRskWwWtnX(vector2, vector);
			}
		}

		private static bool uoMxsbLfzdEjtbURpbihgtcJcIppB(ref Vector3 P_0)
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

		private void YsPgrVQVnuutPVWvrjLRskWwWtnX(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && CtNJErctshrzIgJySfYTugNxMltO(P_0, out var hFuggnUJsDeVgGmKHkYSKkWvdbcAA))
			{
				Quaternion a = NFlAyLxFQMQEmHJVadsmOCXrDeDJA * quaternion;
				if (!LHWAdHiJoUrZrCsNjEaFITVKLqhFB)
				{
					LHWAdHiJoUrZrCsNjEaFITVKLqhFB = true;
					pwSmkGAuASwHpNpBhOJrAQAbgiMz = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					JDxAAKkYqFoHWpvTJXQVQlsawpMsA = NFlAyLxFQMQEmHJVadsmOCXrDeDJA;
				}
				pwSmkGAuASwHpNpBhOJrAQAbgiMz *= quaternion;
				JDxAAKkYqFoHWpvTJXQVQlsawpMsA *= quaternion;
				Quaternion b;
				if ((hFuggnUJsDeVgGmKHkYSKkWvdbcAA & HFuggnUJsDeVgGmKHkYSKkWvdbcAA.XZ) != HFuggnUJsDeVgGmKHkYSKkWvdbcAA.None)
				{
					b = QMjadOTVBpBfeDIpfSvZrFyMRVri(P_0, a.eulerAngles.y);
				}
				else if ((hFuggnUJsDeVgGmKHkYSKkWvdbcAA & HFuggnUJsDeVgGmKHkYSKkWvdbcAA.Y) != HFuggnUJsDeVgGmKHkYSKkWvdbcAA.None)
				{
					b = TiehsOniwjYhqtrPyugTvDwcxFzj(P_0);
					Vector3 vector = JDxAAKkYqFoHWpvTJXQVQlsawpMsA * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				NFlAyLxFQMQEmHJVadsmOCXrDeDJA = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				NFlAyLxFQMQEmHJVadsmOCXrDeDJA *= quaternion;
				if (LHWAdHiJoUrZrCsNjEaFITVKLqhFB)
				{
					LHWAdHiJoUrZrCsNjEaFITVKLqhFB = false;
				}
			}
		}

		private static Quaternion rUYeGEEJjYbBZHjovaiFGPswPBWJA(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = OVbbUyOapRKhYERGnbxwCacjIWbs(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 OVbbUyOapRKhYERGnbxwCacjIWbs(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion lBZDNqMYdBGOitHatQokRDoIDcHK(Quaternion P_0, NCXfVyvaGUEcJyDFxVoYSXKCtPPD P_1)
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

		private float iBjdiYRataoHNNqaLsZrhcFyEZMW(float P_0, float P_1)
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

		private Vector3 frCQpEBjYoSLWQteRLdPRRpUuBNN(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion QMjadOTVBpBfeDIpfSvZrFyMRVri(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion TiehsOniwjYhqtrPyugTvDwcxFzj(Vector3 P_0, float P_1 = 0f)
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

		private float dkxyuUpnXZobtpqvxSQXvOkgTjqP(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool qSdBTTJdvWjJyhYGfFnOdIexnZXOc(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool CtNJErctshrzIgJySfYTugNxMltO(Vector3 P_0, out HFuggnUJsDeVgGmKHkYSKkWvdbcAA P_1)
		{
			P_0.Normalize();
			P_1 = HFuggnUJsDeVgGmKHkYSKkWvdbcAA.None;
			bool result = false;
			if (IbtVtXAneiNByrNPEPUnOyLxoIbd(P_0))
			{
				result = true;
				P_1 |= HFuggnUJsDeVgGmKHkYSKkWvdbcAA.XZ;
			}
			if (IUPhjJxtZCobKKbckInWDZbEwMr(P_0))
			{
				result = true;
				P_1 |= HFuggnUJsDeVgGmKHkYSKkWvdbcAA.Y;
			}
			return result;
		}

		private bool IbtVtXAneiNByrNPEPUnOyLxoIbd(Vector3 P_0)
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

		private bool IUPhjJxtZCobKKbckInWDZbEwMr(Vector3 P_0)
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

		private Vector3 AbYzOGPkrzqpyaRxotmeUANCyxST(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 hOxUuWwEehxqUrFscdQdqzdJOwLM(RingBuffer<XeuQUxbgIYfXehYWxYnOrZfhgALkA.NMUfRuddrxzsOdYlzmZPObqZgnUAb> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				XeuQUxbgIYfXehYWxYnOrZfhgALkA.NMUfRuddrxzsOdYlzmZPObqZgnUAb nMUfRuddrxzsOdYlzmZPObqZgnUAb = P_0[i];
				result += WqmHrOGxZIMqExfDqhKjIqyXdQxeA(nMUfRuddrxzsOdYlzmZPObqZgnUAb.rbEgINakgzYISAmqheGGqOdwGNTDA, nMUfRuddrxzsOdYlzmZPObqZgnUAb.HskqKKXFdIkNuFNXjQqjwcHGwfED);
			}
			return result;
		}

		private Vector3 WqmHrOGxZIMqExfDqhKjIqyXdQxeA(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int wDjGhWKjqITRrhHynWwpimbiEvns(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void XfvwBOKuLjFrvKHQWkLQytzPGexn(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void FFoVxNRjifwxRnVORYJjbdQVaZtU(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float RfUZrmbhgAgjKvInsemKsBXlliji()
		{
			return KVhFlUeMczhjddUcEbSCoCPkKSFTB;
		}

		private void BVJaBJKkgtarjWRsQeZpBXbllbRDb(NativeBuffer P_0, hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] P_1)
		{
			int num = 33 + fUXITQEsrbTTbzWtgBuHCTXPAvol;
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
			P_1[0].touchId = plJeoZTLZFSBEkjICueLzxGcYzqf(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = plJeoZTLZFSBEkjICueLzxGcYzqf(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int plJeoZTLZFSBEkjICueLzxGcYzqf(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				wDXYHxipgmfoXQzdkddpzuTEpNCc[P_0] = -1;
				ZQyDVhFxOYexWYZIGhMSAavdsLLB[P_0] = P_2;
				return -1;
			}
			if (P_2 != ZQyDVhFxOYexWYZIGhMSAavdsLLB[P_0])
			{
				int ofMIBLvmZnxofkfmEeLOvUZTxfgm = OfMIBLvmZnxofkfmEeLOvUZTxfgm;
				if (OfMIBLvmZnxofkfmEeLOvUZTxfgm == int.MaxValue)
				{
					OfMIBLvmZnxofkfmEeLOvUZTxfgm = 0;
				}
				else
				{
					OfMIBLvmZnxofkfmEeLOvUZTxfgm++;
				}
				ZQyDVhFxOYexWYZIGhMSAavdsLLB[P_0] = P_2;
				wDXYHxipgmfoXQzdkddpzuTEpNCc[P_0] = ofMIBLvmZnxofkfmEeLOvUZTxfgm;
				return ofMIBLvmZnxofkfmEeLOvUZTxfgm;
			}
			return wDXYHxipgmfoXQzdkddpzuTEpNCc[P_0];
		}

		private void JRynRuPOFeNQNWPRrhXRMfoDovSQ()
		{
			HyFoRJYpYOfaVyDtGRSaKbxYEePk = true;
			irZshuypDHVKIofmoiReibqPPwNd();
		}

		private void jPeujvCaxhjPloFqocZzySdmOKto()
		{
			HyFoRJYpYOfaVyDtGRSaKbxYEePk = true;
			irZshuypDHVKIofmoiReibqPPwNd();
		}

		private void KMQdVqntnbcmXgNRZpGzCqENJAgj()
		{
			uBWiLlEDxDCfVIkdFMiDiUAcoBibb = true;
			irZshuypDHVKIofmoiReibqPPwNd();
		}

		private void irZshuypDHVKIofmoiReibqPPwNd()
		{
			AMbDoanTvCussFgoOIESBDYHBESjb = true;
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
				eWkaqNCdeBSZfdmOfNnzIUzQpZDVA(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous);
				if (GpAUFeCZOLAoFLhxUkeBcRbxTDHT != null)
				{
					GpAUFeCZOLAoFLhxUkeBcRbxTDHT.Dispose();
				}
				if (oaKCMoxSDnoMiCMxKNZLPNlajJYb != null)
				{
					oaKCMoxSDnoMiCMxKNZLPNlajJYb.Dispose();
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

		private static uint sHblGholuLLcRpyaxoKNhXvnuIfw(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = TeMUklZngyujrDvwXKURSgLOooGW[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static KApSKUcifgvAjfIOpwgOGExlHEEk EhHPWmIYHqrMggRlVBLBByDImuop(DualSenseOtherLightBrightness P_0)
		{
			return P_0 switch
			{
				DualSenseOtherLightBrightness.High => KApSKUcifgvAjfIOpwgOGExlHEEk.High, 
				DualSenseOtherLightBrightness.Medium => KApSKUcifgvAjfIOpwgOGExlHEEk.Medium, 
				DualSenseOtherLightBrightness.Low => KApSKUcifgvAjfIOpwgOGExlHEEk.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static DualSenseOtherLightBrightness zethEXfQpMGSFFHGFncdsXUWKGXnB(KApSKUcifgvAjfIOpwgOGExlHEEk P_0)
		{
			return P_0 switch
			{
				KApSKUcifgvAjfIOpwgOGExlHEEk.High => DualSenseOtherLightBrightness.High, 
				KApSKUcifgvAjfIOpwgOGExlHEEk.Medium => DualSenseOtherLightBrightness.Medium, 
				KApSKUcifgvAjfIOpwgOGExlHEEk.Low => DualSenseOtherLightBrightness.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static hADcHjMYjcPjtWFHfwrtgUKVZrTe cstKfxtacNBqwEVIwkxEMQhvBjlw(DualSenseTriggerType P_0, byte P_1)
		{
			byte b;
			switch (P_0)
			{
			case DualSenseTriggerType.Left:
				b = new JlYpRfrdIXccKueqbshKpRRPCGiB(P_1).hcjliVTTVJYlLkGmHjPVDTfwevrp;
				break;
			case DualSenseTriggerType.Right:
				b = new JlYpRfrdIXccKueqbshKpRRPCGiB(P_1).TAWTkBeNbVrSBwWVNabcodUMDHXR;
				break;
			default:
				return hADcHjMYjcPjtWFHfwrtgUKVZrTe.Off;
			}
			return b switch
			{
				0 => hADcHjMYjcPjtWFHfwrtgUKVZrTe.Off, 
				1 => hADcHjMYjcPjtWFHfwrtgUKVZrTe.Feedback, 
				2 => hADcHjMYjcPjtWFHfwrtgUKVZrTe.Weapon, 
				3 => hADcHjMYjcPjtWFHfwrtgUKVZrTe.Vibration, 
				4 => hADcHjMYjcPjtWFHfwrtgUKVZrTe.SlopeFeedback, 
				_ => hADcHjMYjcPjtWFHfwrtgUKVZrTe.Off, 
			};
		}

		private static DualSenseTriggerEffectState JLnRlTSuAJoVaiwuauDKrzbgnjbI(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			byte b = new JlYpRfrdIXccKueqbshKpRRPCGiB(P_1).hcjliVTTVJYlLkGmHjPVDTfwevrp;
			return cstKfxtacNBqwEVIwkxEMQhvBjlw(P_0, P_2) switch
			{
				hADcHjMYjcPjtWFHfwrtgUKVZrTe.Off => DualSenseTriggerEffectState.Off, 
				hADcHjMYjcPjtWFHfwrtgUKVZrTe.Feedback => b switch
				{
					0 => DualSenseTriggerEffectState.FeedbackIdle, 
					1 => DualSenseTriggerEffectState.FeedbackApplyingForce, 
					_ => DualSenseTriggerEffectState.FeedbackIdle, 
				}, 
				hADcHjMYjcPjtWFHfwrtgUKVZrTe.Weapon => b switch
				{
					0 => DualSenseTriggerEffectState.WeaponIdle, 
					1 => DualSenseTriggerEffectState.WeaponFiring, 
					2 => DualSenseTriggerEffectState.WeaponFired, 
					_ => DualSenseTriggerEffectState.WeaponIdle, 
				}, 
				hADcHjMYjcPjtWFHfwrtgUKVZrTe.Vibration => b switch
				{
					0 => DualSenseTriggerEffectState.VibrationIdle, 
					1 => DualSenseTriggerEffectState.VibrationVibrating, 
					_ => DualSenseTriggerEffectState.VibrationIdle, 
				}, 
				hADcHjMYjcPjtWFHfwrtgUKVZrTe.SlopeFeedback => b switch
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
