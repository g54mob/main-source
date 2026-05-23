using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualSenseDriver : HIDDeviceDriver, IDriver_DualSense, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum kwWbOigzUXjwsSlLFbphfRWOKNiKA
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum yqlVBrYOMEvZDUDKfkRdVNTtRzZI
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum KWOtPVEcszXdSkbXHOEUvAFRQruq : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum tNwXbQmPQlRJWXrOVdAfZgqrPzrU : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum mxRlHJLqycGWfFGUmxXdKvfJhIxpA : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum WNEfWiAGWElIfccIOJaCVxrIIwQTA
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum VJlyJazegKCnZYGAvcSuwDzrFcxo : byte
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

		private enum mENqiKPfJgBhXesWhgWwEbKHOecgA : byte
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

		private enum JqNbvwYdgcMrCLfOvibMJOjwziOT : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct wKHuSHdYREgINQEeLTSOakCZTmlN
		{
			private const string JXgZUQngZXFPzdfcDMmtSLOeaKhaA = "Value must be between 0 and 16.";

			public byte iRyGjGyzKAuWpwRQalOXrRGtQrcy;

			public byte iwVFcByMXIODaOHRpoKXlwRMKpeR
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public byte YUwESFJqtQnkeIumjpjkEvgaMTCs
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public wKHuSHdYREgINQEeLTSOakCZTmlN(byte P_0)
			{
				iRyGjGyzKAuWpwRQalOXrRGtQrcy = 0;
			}

			public wKHuSHdYREgINQEeLTSOakCZTmlN(byte P_0, byte P_1)
			{
				iRyGjGyzKAuWpwRQalOXrRGtQrcy = 0;
			}
		}

		private static class LHznBYwmYjBNcDWwyZMPTmJZFsjVA
		{
			public enum HmYfBPckFnQRImQCYdNaiWvzOhtsA : byte
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

			public static class PJXWIIpcimJDHlZaiblozFYyTGfO
			{
				public static class dMWtzqdebIdmVRSaceEcAwsOjzcT
				{
					public static bool jRieiCOhTOxmPamIIFJxhAAXTgBF(byte[] P_0, int P_1)
					{
						return false;
					}

					public static bool rwEeFmHCnkfrjkQVOBwHhdLXTuimA(byte[] P_0, int P_1, float P_2, float P_3)
					{
						return false;
					}

					public static bool igHhlJAJxaaIAgNaAfofIBnFLDeKb(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						return false;
					}

					public static bool kbtzyCZZGyItDiQaFUDykLjnUksW(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						return false;
					}

					public static bool kNAOrIypYpiHWaAgHxDaJyegUUTb(byte[] P_0, int P_1, float[] P_2)
					{
						return false;
					}

					public static bool mJYAGujMQPtkPhGGZJhqLHKejbjlA(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
					{
						return false;
					}

					public static bool qVvVtMAXlUnbOTWPhcuIPqhpcZUeA(byte[] P_0, int P_1, float[] P_2, float P_3)
					{
						return false;
					}
				}

				[Serializable]
				private sealed class DxFAXyrlLQDjFueVzDitmNaRLcCU
				{
					public static readonly DxFAXyrlLQDjFueVzDitmNaRLcCU _003C_003E9;

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool ASDvenMkQBTNPbKVZTUArJWpAgTt(byte P_0)
					{
						return false;
					}

					internal bool JfbmAuMbVqGgxhAyMCgoaYzrYiTsA(byte P_0)
					{
						return false;
					}
				}

				public static bool XiueNrxVXQeKMeuCBcQkyUrPQLXaA(byte[] P_0, int P_1)
				{
					return false;
				}

				public static bool nsqICDrynXVFZgeWVxeDjpqmdgsi(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool fTFFoVLldhYolzOGhHlmFhCSbKec(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool HqsbmPFZXeutlUJChQFbHEnhoYgK(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool tMBlTGYKEBBtDPpXwRZbZkRyWGHn(byte[] P_0, int P_1, byte[] P_2)
				{
					return false;
				}

				public static bool fAhWdMQAkaggwkFVSYlxOWFhGLmGb(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					return false;
				}

				public static bool BIsHCOgwbkzpkkBJqfdLdDcNpmId(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					return false;
				}

				public static bool rrkQSDxloIOHkTYuuBwkpMVOukxM(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					return false;
				}

				public static bool FgLdboIQtHazitMHGIohxyEYHzuSA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
				{
					return false;
				}

				public static bool VoqCDhvRTRldIzAZlJidJnTlGNKHA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
				{
					return false;
				}

				public static bool ULufqrFkmAHwvCtUUhaUhlbNJrDDb(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool SXSdsNhpxhvBlOgUplSYqNKEUwZc(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool SCgyDDfJvEkASWUiLhCHjHsUGRwu(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool ATgPEZzMltEmlBVttvqUELBxSrHE(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool KlKuQuogVxSROxnQsdpqsKZzfBud(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}
			}
		}

		private const float zrFUOqqmZrAefNrQRZBRwqkjHrVd = 4f;

		private const int zMZxUDphhPifhFdjuvhTLJOMKEGKA = 15;

		private const int FCJMbVDVguqmvOJXIAfCeFBwluGnA = 2;

		private const int wKBgYAjCeehdrjNTkIUxbYGdeBfQB = 0;

		private const int bHyrjZnChKMHtIfvCEFhAKPwzHEq = 1912;

		private const int dyTXinVDLQjyyFRYEntyCQtYcKVy = 0;

		private const int UPCEeHcmKQOHOdCXlOTYNhjTvSHs = 941;

		private const bool IuICIlvtArimNlqpjfuFoyTLBVYA = false;

		private const bool DEDzXrVHZReXBNvUFMnfnKvieTwK = true;

		private const float svNtkeaQfZOxuRXBWygbDHOjixtv = 2.5f;

		private const int uyitKJtckkpRIGCvzbtBHMMvdAvVA = 0;

		private const int hIpCDZhWblvCrgweqXGEZxuBBPEB = 0;

		private const int mfwAXqClMMmlGKdpZYxUcEjBSTqW = 1;

		private const int FfaeLmeAmTEXCfOQZngKdiZtXzis = 0;

		private const int FRdegIINLPhJxmQpCUORsEUNgBrP = 0;

		private const int KYwchsZHsZvPrYKYharIJGAlwLZN = 0;

		private const int dcbhByuwGlaACfUgGZkyDPvYuKjJ = 1;

		private const int UdjjCvHdcrybtGFTennchIfDyPuNb = 49;

		private const int mYAfcEKxOLlBVcvPjhAMTEizrHYMA = 0;

		private const int RgnumyFeRYXIwPtXernpIfqspdSn = 1;

		private const int kUlTXwrnequDcUwbgeuvwVFTjMrE = 64;

		private const int ifSGXgQnqxFOuIMuVREeViPTDYLdb = 48;

		private const int ChZpTqWZcEMOaXkoOpMOEnnryacg = 78;

		private const int giokaFeqvTvMppEFhFRObhIODvyyA = 5;

		private const int SDmqPhBcpWrdOqfzRheUErmrWTCc = 41;

		private const byte ZEBpCSpTyfZgAMoeUOSqMEFmMaSF = 1;

		private const byte fZkYblqHvLDKkHckHnVCCOfAvYlac = 2;

		private const int xNEQWgLUlgepnnERwGavOzLidkAX = 1;

		private const int WevhFHxkxYKAxpvejEaZpwZKpaZf = 2;

		private const int lteCatvtcNwGEZvfsXoXsbrPteTh = 3;

		private const int NUaRErgiZmFydLjJTcIzXTmgWnyy = 4;

		private const int OynRoMBmpzBBOlIMNaqQiJdmLimb = 5;

		private const int BcUjhPcMjrVkNHWNyDTqLZotTUyX = 6;

		private const int uTxohtIIteTGPyGhVIawGPIIhvWCb = 8;

		private const int GxcrIdVDlhyjdBoIRAxHepHvrmNx = 22;

		private const int yEAvHXQpixvHqROFDgXpqlHKQlKy = 16;

		private const int lKFSUhmJXXUMtnHixJQpXvBTiZMp = 33;

		private const int WLQOqjqnAEnNDtJzygeTNltDExZZ = 8;

		private const int gzxvUBXQpPYeupeQpbDFByhjWGNuA = 9;

		private const int OQpOGmmqDVFpDjBZhfjDmIkwdCmqA = 10;

		private const int ryFmEExteoeuLWXOyFybccPWdEmV = 28;

		private const int ihrrOLRPOHnBtHwTlmLOyOCwNQPe = 53;

		private const int lrhczoHGfKQxvavDFsrIHfoPdchN = 54;

		private const int kXLyLdbTZKKTxQAsIRnowtlkaFFo = 43;

		private const int zCKBkGBDPQJQwpeNGKsAAjxHfyvkb = 42;

		private const int FUuyghBwzcSExkzMNBHXAPlJpQlf = 48;

		private const bool CKZIPhJAjWOMsdnsZPBROohzEKIj = true;

		private const int RKkDfArnrlCHnNOIDRoZqjOGcZZ = 60;

		private const int nDrJKHDKwBnmImCMsKmHWKNPqUsj = 60;

		private const int zQvoUQtKniimhCmvlNYyDCjIQKBdb = 3000000;

		private const float CrCHCDZNxRePlMcTZVEufdWdApfCA = 8192f;

		private const float eAtZWVALuusilfxscIWNuOiUtFhm = 0.0010652969f;

		private const float pqSYZBBcJsmGybPvgrNivIObeKVB = 0.06103702f;

		private const bool iIQrYFoGPMFxEctUabsbpxMRarBs = true;

		private const bool VxuYquYkjMAgwgHrnvgowOxykXkd = true;

		private const bool EDNhdHnKGTQwZAeqTkxBUObxhJzr = true;

		private const bool exZsNRRfUAGrFbTCUNeuLFQjBkmAb = true;

		private const float XAZmbMZONSfohctwIWJLjdtmqNSI = 4096f;

		private const float PTJQRIxeesGBBVCOiGjgyXLXfufe = 16384f;

		private const float QASSVpJXslzLVHiDfCWKgnUbSCZK = 16777216f;

		private const float RzchXfnLIqFYkESkWatsSPcxrAZjb = 268435460f;

		private const float uOdocgnzhqaafIkdqkHRzkCbXmEK = 0.01999998f;

		private const float uJxCLVDbmUvIPRLBQcJESgvtGjpgb = 8192f;

		private const float rQlqqQwrYLMMOXUGwgROnnfzlEKK = 0.98f;

		private const float CGZBJMbyKxHAeFGMiIeKslvqxYOLA = 45f;

		private const float KpIYTDNuXdnPtikCaypiaziQmNee = 20f;

		private const DualSenseVibrationMode TOCVMMXPFQlrZVMHfRzmMkZniFNk = DualSenseVibrationMode.Compatible2;

		private readonly IHIDDevice KfttQitkMjElZJEjiAabSOlRpEYy;

		private readonly HIDProperties iMMyZNQYoLvBafCLYdhfkaOIsuhQ;

		private readonly bool CaRyZANcmpymaMIaLArnNviPakug;

		private readonly int dPoePrPEIjhzcRhDmszikoMSCuCP;

		private readonly int zAWOmJisBtVXdsPIsEHRudNwZeOt;

		private readonly bool wDCEfBvRrEYaLRouZbfYjPhOfKpj;

		private readonly byte thVPcfIUCXHYVweFRuIXvgDroPyC;

		private readonly int GtEsNIInBevTSTbvMCGsHGOFoDPJ;

		private readonly int XTeltfZpDITEQPFKEWJtHJKGkktp;

		private readonly int csWfedatVVYAokuDSKVrGuYGMmmW;

		private readonly int VPNGSCBCOhsatonuEwvDbRoeLiWl;

		private readonly NativeBuffer hBpuofSqdISmXbjHyKkPjyfnbkcB;

		private readonly NativeBuffer LwVTdCrRgoiQpauWiPpofGSakDatA;

		private ndPzSZhFNVeBDFDFsrPPRfBbUpJt avzeqBdYiMMTAZhSXobPaJMoeOic;

		private int zPpQUfrnhVBMHmObuWfdtjtnEnGgA;

		private bool ddyqNmluLZAsJzyoasZxWdDRcEfl;

		private bool tTUhJlMUjZFGMdbbVHGVSOKopLsm;

		private double kfxHhbmCaltTHRoCirJVYDfrnTyF;

		private int cIpVgxgnXhHOpOHZPIDzBOCFhgiF;

		private WNEfWiAGWElIfccIOJaCVxrIIwQTA qKtcbtzmMqlcbBMBXFtXNSOPhZYl;

		private bool BoTiMEuJOJRTbVCNUgwJNiAXgRiN;

		private Quaternion qTuLVXdQkJBuRbxPWrMVAXKnREuY;

		private DualSenseMicrophoneLightMode soLuaADTNyrbsYQczpWbLvDNvSNP;

		private tNwXbQmPQlRJWXrOVdAfZgqrPzrU MpHcwdrMRsNFfEpezyQAGaVqPJGp;

		private DualSensePlayerLightFlags PCynKhNivOpjlPlCXxSrrWElqHbI;

		private bool FzjozUiwrYazeOYcwOsTQRFkfhMj;

		private uint NXgCQRdShRkvqpjPgpQTFPGfoBAob;

		private float hDsErGKbImRqSmboViobTtAAVgey;

		private double vJCoNzGAXPywozkGfFtNNfpOKlbs;

		private float WYSlGnhebzOlLxrGWaEdsjLRCuAG;

		private readonly IDualSenseTriggerEffect[] ZHgxhorDEufYqxgYtsIzYlzOIrVC;

		private readonly byte[] qlrVBtcdFkHnNGUBxiOUATUHFpJf;

		private readonly byte[] gTccfJnUpnYTUZiwRDXZAUsomIFQA;

		private DualSenseTriggerEffectState[] KzlCOvsEoLugdzxXgAEIlgxmmnnx;

		private DualSenseVibrationMode QpUvwRIigheypWhSZmAgdjYWpEvT;

		private byte bwuNamIEbxumfCuUEJwkYiOCqJBf;

		private bool PuViwpQGZCDEgMljbWOgNILeIlDw;

		private bool SBNeUJxwcPNJKBsVEMyZMJhCANbj;

		private bool YFjjEZhEPCLVWgbDeRBGlvlvOcJIA;

		private bool JRdFASdGWXfsHAOmGGnOalicPLKwc;

		private bool JYGiQBzHokigmewUCiHLcpqkTLwFA;

		private bool ayurKXpkOUdOLDCEKAnvYsajfLCQA;

		private bool wzIJJTKIsHUFwYAhyqpTZHeKgkwM;

		private bool CiZBcFAdBhteMTcbykEqysvKOdmOA;

		private bool NGcWXAXhyFmLaYHcjHgvqMHSgHKT;

		private byte ARmClpCwWbxufeqbcYnibZxqDSZeb;

		private byte eqzRaoHaUDSeYwCKDvbhUMrqRbnk;

		private Quaternion OdBPtECHeHntOneJJJzWLgVbhKfW;

		private Quaternion kucbUZGCESbxIJFjhehoyfDmRovD;

		private bool wHXQXXDQeVlcIUfBPUBwQDWPfQMN;

		private int trNoAFhBtkGFYIKkqMfnwwSJPNZs;

		private int[] HIUufFaMTzgHBDwdAZZWdohQqPulA;

		private int[] yXpzgPLOXBoYQakXqENxTnftEMaR;

		private static uint[] iVNPtjFeEhEDOpjmfEaaeJQGlWdx;

		private const uint OlTbdCXCZshwpErgSiHUkNFNbOxCA = 3940166985u;

		private bool isVibrating => false;

		public float BatteryLevel => 0f;

		public bool BatteryCharging => false;

		public DualSenseVibrationMode vibrationMode
		{
			get
			{
				return default(DualSenseVibrationMode);
			}
			set
			{
			}
		}

		public float LeftMotor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightMotor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightColorR
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightColorG
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightColorB
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightFlashOnDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				return default(DualSenseMicrophoneLightMode);
			}
			set
			{
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				return default(DualSenseOtherLightBrightness);
			}
			set
			{
			}
		}

		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				return default(DualSensePlayerLightFlags);
			}
			set
			{
			}
		}

		public Vector3 AccelerometerValue => default(Vector3);

		public Vector3 AccelerometerValueRaw => default(Vector3);

		public Vector3 GyroscopeValue => default(Vector3);

		public Vector3 GyroscopeValueRaw => default(Vector3);

		public Vector3 LastGyroscopeValue => default(Vector3);

		public Vector3 LastGyroscopeValueRaw => default(Vector3);

		public Quaternion Orientation => default(Quaternion);

		public int MaxTouches => 0;

		ushort IHIDControllerExtension.vendorId => 0;

		ushort IHIDControllerExtension.productId => 0;

		string IHIDControllerExtension.productName => null;

		string IHIDControllerExtension.manufacturer => null;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

		public void ResetOrientation()
		{
		}

		public int GetTouchCount()
		{
			return 0;
		}

		public bool IsTouchingAtIndex(int index)
		{
			return false;
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return false;
		}

		public int GetTouchIdAtIndex(int index)
		{
			return 0;
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = default(int);
			positionY = default(int);
			return false;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = default(int);
			positionY = default(int);
			return false;
		}

		public void StopLightFlash()
		{
		}

		public void StopVibration()
		{
		}

		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			return false;
		}

		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			return default(DualSenseTriggerEffectStates);
		}

		public DualSenseDriver(InitArgs P_0)
		{
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			return false;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return null;
		}

		private void ZCjFeNniEMliEGvWDHxAFMsYdnyH(GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_0)
		{
		}

		private bool dWKthrkUImeVBRNcIQznuBDgWENt(GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_0)
		{
			return false;
		}

		private void MVLIJnHJuriYyVlklWMPsfDWvTNw()
		{
		}

		private void bLOZHhkbzlLcrGzeTjQivfIRHyeH(NativeBuffer P_0, int P_1)
		{
		}

		private void JJFbvQcyysGQXsGgcLoWPQdWbcfc(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
		}

		private bool IqKwzaVwzpcKviAwExSRsZPFCsex(GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_0)
		{
			return false;
		}

		private void lVOgfFIevRYcjDxGjYPQJURbOMJzA(NativeBuffer P_0, double P_1)
		{
		}

		private void OBInMWNIksIRKdKjIaICAboByjawA(GLNYbQuaOXeaSToXMWjUhtXAplaf[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void rsDsorvfPpFwCxRlYPumjMNvQuUc()
		{
		}

		private void LNmQUmQxdVTFtbCzqKTtFwpuxtMe(NativeBuffer P_0)
		{
		}

		private void UqvAXxPbDwSftAdDtJPdczDDKGuM()
		{
		}

		private static bool HYPZhWLPtyHMwmZiBGUZejgokWLB(ref Vector3 P_0)
		{
			return false;
		}

		private void pVMKaLMADrNUwjWfPbZanNZaXVSG(Vector3 P_0, Vector3 P_1)
		{
		}

		private static Quaternion YBTrQAGnLBtrqtpuXIauSVrgrxnJ(Quaternion P_0, Vector3 P_1)
		{
			return default(Quaternion);
		}

		private static Vector3 zemTYqQBZELWvqFMRhJXPjlfUySp(Vector3 P_0, Vector3 P_1)
		{
			return default(Vector3);
		}

		private Quaternion EwAgoeCxROigZBncLTiHIRdYIjmW(Quaternion P_0, kwWbOigzUXjwsSlLFbphfRWOKNiKA P_1)
		{
			return default(Quaternion);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			return default(Quaternion);
		}

		private float LoqQFKLJZjefqAdshPvGnkQsfndVA(float P_0, float P_1)
		{
			return 0f;
		}

		private Vector3 AhXdMQRlgjaffyiijgTqFOoKZnixA(Vector3 P_0, float P_1 = 0f)
		{
			return default(Vector3);
		}

		private Quaternion tlcZTWPAritfRlDlBqsooqhSHjSr(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion spbeEKezYkciXIDbIOKiNcfDiDGvb(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private float GooBgOdtFAHhIFJhDcQkgsfmBlTJ(Vector3 P_0)
		{
			return 0f;
		}

		private bool VWesQLpVIJrrNoEOnVgdFhEfxKcd(float P_0)
		{
			return false;
		}

		private bool vDMdvjomOyPufEityuyydKkrXaWd(Vector3 P_0, out yqlVBrYOMEvZDUDKfkRdVNTtRzZI P_1)
		{
			P_1 = default(yqlVBrYOMEvZDUDKfkRdVNTtRzZI);
			return false;
		}

		private bool tLgYgzUsHnAvXHQNmgjYPmhbJWQGA(Vector3 P_0)
		{
			return false;
		}

		private bool bKXwwnHTHKKoYsDdKeSMaLAjPSnAb(Vector3 P_0)
		{
			return false;
		}

		private Vector3 jwNtbATLWwJiFArRQCdDZHIWTbfI(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 SYkfvAoMAgyNvLqqOSqMhNoRUxaK(RingBuffer<wlfdzvjuaZfnTkWOTlZxCBwptsuo.uBFqvefKBuWBtkgvFGvssozHNHtT> P_0)
		{
			return default(Vector3);
		}

		private Vector3 fHtSvOEzxZwYlPHKAyPKVjlDedUf(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int LTiYHMMOAFdlAZecJAWObogiXpYE(int P_0)
		{
			return 0;
		}

		private void oqKcYsKvkvHYNgAelbvSraTEQAvA(byte[] P_0, float[] P_1)
		{
		}

		private void chrhyZLSGaFSkHeMjOeUyzFBopAM(byte[] P_0, float[] P_1)
		{
		}

		private float kJZcakChVFnMfiJdQsKzjzMbjPCjA()
		{
			return 0f;
		}

		private void uBKuCPgkUuFJKnWoglFASHyhVukL(NativeBuffer P_0, WrSlmJxoZFgCLSWPeQjtyKXyDhws.TouchData[] P_1)
		{
		}

		private int EKWDVFBirMGmfFEYoFIcviHyxmLeA(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void oxrCkgLRlrEkqqcXBOlaNtzNMTzS()
		{
		}

		private void MZdnNxAMTktRAMrkQixYhrksykWX()
		{
		}

		private void hAVKImvpDcBSqjOJnLTCfHFTxzNy()
		{
		}

		private void TVCwDtwJRQAtneOnUWORBxaHKxyNA()
		{
		}

		~DualSenseDriver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public static bool Matches(int vid, int pid)
		{
			return false;
		}

		private static uint NgsanvsiMWIUgGLwNdgaAiqaxwYKb(NativeBuffer P_0, int P_1)
		{
			return 0u;
		}

		private static tNwXbQmPQlRJWXrOVdAfZgqrPzrU fsYhHcYCjjbeDIopvwnqGYAKESFs(DualSenseOtherLightBrightness P_0)
		{
			return default(tNwXbQmPQlRJWXrOVdAfZgqrPzrU);
		}

		private static DualSenseOtherLightBrightness IvuxeZKgRNkYidoCVYFCItPSsXei(tNwXbQmPQlRJWXrOVdAfZgqrPzrU P_0)
		{
			return default(DualSenseOtherLightBrightness);
		}

		private static KWOtPVEcszXdSkbXHOEUvAFRQruq LhapvhbYMURWJiLCCBBzBNmvYJQn(DualSenseTriggerType P_0, byte P_1)
		{
			return default(KWOtPVEcszXdSkbXHOEUvAFRQruq);
		}

		private static DualSenseTriggerEffectState qKeFePIOuMbELKEgCXSlloskHHEqA(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			return default(DualSenseTriggerEffectState);
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
		}
	}
}
