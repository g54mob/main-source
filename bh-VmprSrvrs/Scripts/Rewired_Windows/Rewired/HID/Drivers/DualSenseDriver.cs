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
		private enum xOkisjKBhqAvZOqSZvUUZFCzJbxN
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum jQJvjijkjnBoqMNNtUyKZVNSofCO
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum FKqjRWpsTKimdoeKBEnbdkHqVKdm : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum iSEHsVJspMEqbNLVTGJIXFuQBOuk : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum bKpvdSaeRPDDUMWDcVTCxHbaiOsI : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum FUyswnbErpCVCudNQomzpEvdCMHAA
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum UvROKpGxTjkBqWtFvRsJqoxCZUcX : byte
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

		private enum xRnMPDqciToDkixHbEYDxwEwWHhF : byte
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

		private enum KwboVhnURBxBjBLHpSjpLnjBhENBA : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct zEnogISncvPfgGztDYyfuoWaItch
		{
			private const string MsWFbRhKeyfCSqfhJkyYgKWiZcuvb = "Value must be between 0 and 16.";

			public byte pJAZkZZvdvVDYgDMkUgsleMWBmng;

			public byte dkjWETFkzWAPXMUxtEsqrLxMFtQA
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public byte PIUgIUaWglrDmEfCbpEHAyGJptLC
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public zEnogISncvPfgGztDYyfuoWaItch(byte P_0)
			{
				pJAZkZZvdvVDYgDMkUgsleMWBmng = 0;
			}

			public zEnogISncvPfgGztDYyfuoWaItch(byte P_0, byte P_1)
			{
				pJAZkZZvdvVDYgDMkUgsleMWBmng = 0;
			}
		}

		private static class MNHduTPlMYKgXIHrcGGemHXmfQqw
		{
			public enum WZodtQPyuYFAtyRBMXuVGCvKAFyp : byte
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

			public static class CfxeiBFKBDsAcYptgIdNFjIGJuudc
			{
				public static class cbiZqbEvOnvraLabmYuZSCuzTWnG
				{
					public static bool mmQKKvdJOreoHhkrSPDKpdAeHbYoA(byte[] P_0, int P_1)
					{
						return false;
					}

					public static bool kkmjxQgUuVsGjwQbGyyQdHaaAhqc(byte[] P_0, int P_1, float P_2, float P_3)
					{
						return false;
					}

					public static bool jxHPIdKWTNXnHRjErwYXDbkclpIA(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						return false;
					}

					public static bool hPHAxFgLtBeIuuZfBVhJijpOAMtm(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						return false;
					}

					public static bool jJbiuiPLKdUrsmTJoOfeLYsRjsRx(byte[] P_0, int P_1, float[] P_2)
					{
						return false;
					}

					public static bool dXkcilhZxupdiWZTVlYTHAGVRzki(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
					{
						return false;
					}

					public static bool tKHXdNrzIxeThDIUvwqzJElYvHHf(byte[] P_0, int P_1, float[] P_2, float P_3)
					{
						return false;
					}
				}

				[Serializable]
				private sealed class GDvzsxOamfVQyoVIzWkSaFoyqMZO
				{
					public static readonly GDvzsxOamfVQyoVIzWkSaFoyqMZO _003C_003E9;

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool TLnEZyzNbkSKebIAZGMpnNCWiQGS(byte P_0)
					{
						return false;
					}

					internal bool SfLaKtIhoVDhQQhpAQkTzGzOHGEoA(byte P_0)
					{
						return false;
					}
				}

				public static bool SIYvhuKzmbXFroDJFiYDAYzgrjMh(byte[] P_0, int P_1)
				{
					return false;
				}

				public static bool cfGKsKEaXeeCehsXFTjeBhyThXvgA(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool kTjkrdorMQsZNdaNbnXMFAzbnJDQ(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool McIgAGKoePPiOGYHgxRAMXrMMgzFB(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool sbfrfVjcrsiXoTcAqZFUDATZdiUw(byte[] P_0, int P_1, byte[] P_2)
				{
					return false;
				}

				public static bool qfZLaFtVFVjlHJzCQdiWYGXClgpI(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					return false;
				}

				public static bool MvYElVXiVHZcAodIeDfcjvDekFFDA(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					return false;
				}

				public static bool yXCujEQaFlOBFJthqeqHrRTtUGcf(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					return false;
				}

				public static bool ALjXPrbBYmCqZWlMEcsOhqMnzRbmA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
				{
					return false;
				}

				public static bool KbKEfsKVooXgxjKGneaQHOFEBhBDA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
				{
					return false;
				}

				public static bool XAIIiNkBUdxUWhPcKetNzhzsTGob(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool VDolNWCHKKQgKALtbNlfyvRxFsAP(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool VIYlEGEnUtFbbiChPPruOvcnlvxKA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}

				public static bool RbQkhMGpnAaNSBRWrqzhIONKvwMCA(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					return false;
				}

				public static bool LKuNEjDQVOCVbbKwwwzHmkAAmRhu(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					return false;
				}
			}
		}

		private const float wqnPuxHFJUdLMARuJKVgceiJWrClB = 4f;

		private const int cTreOWUpOkckWjWgujbcNMGhgxDj = 15;

		private const int UcbZaEmZPRzaMGSyElGhVLfFMpFe = 2;

		private const int xzDgViIDZeiUiPGeyMEBQKGZbgYb = 0;

		private const int ybYTPGSIQjvJOMukAkNSMEDBhhVHA = 1912;

		private const int cJdcvcimevgfTSLVSUhDnCjttiAMA = 0;

		private const int ReaSCEXvalCEltYdbXOzTzumeKVc = 941;

		private const bool NmQicHKLMhTjFjtbpqjDgBkcljQy = false;

		private const bool ITlpScepoqGWkNvFNnYYhdhDQwzH = true;

		private const float fotKQnPSEqXPJTjAMsDMHDQADBwQ = 2.5f;

		private const int dfYiDWWSJXCdjUlkvvokSKMUoTyf = 0;

		private const int wvPFwKESzKySzuEraaZtXCzeXfCr = 0;

		private const int vLWarzIvnxVsfqMaXkjtbmzkQztUA = 1;

		private const int MZUBSpDNHsAEzftJIRkdCpTzSPnYb = 0;

		private const int KRDVIZpVwwDkOaXiYPIcmrIwnxau = 0;

		private const int VKEfJjDwBajAGnQVfHtbbVGGObIuB = 0;

		private const int awNXPxVInYovvpybEnRLLSzzJKkX = 1;

		private const int LiDcuwAzHCNoCVOOitrBEmrDCrtEA = 49;

		private const int zdaCOJWbpczGitoAreWxIRkWpnHX = 0;

		private const int MZVUabwsulBNTLiAslHUEdsZkVZw = 1;

		private const int fCBkhUAFMTFbVAUjiVkCsoBqZBipA = 64;

		private const int puuBvvzDVOTDFQSpNCYTgkZaLqUbA = 48;

		private const int JhtoTxbfazfZTfZlIulbwCtAxAdGA = 78;

		private const int dWWUCnPYxuJCtlWCbNvXxMjbHhqc = 5;

		private const int VXGnYcemLflwEefeLElRSxzUWmIM = 41;

		private const byte CZlJZXStgMMMdCvjSGQHKDINcvPk = 1;

		private const byte gACLweJrOuRAPybzVGTfYLjWpkap = 2;

		private const int gaiYudosMVWlYxuGgHcSCjVVHMJo = 1;

		private const int JrXLDSSOWhHDOjCzvfEmEzRhpTGhA = 2;

		private const int oNAxayIKVsZhlTUcwrXsiwhgTHAo = 3;

		private const int CUAoygFeCNlvYHYrJQcAJgLBBvpe = 4;

		private const int DWBjhvcqDQJEsfvNTukDyCDVnffU = 5;

		private const int WvcLISNSLGzegHKjcXjBPJqEqdlJ = 6;

		private const int xIRJryjIqPHeqiEwTcmDPLElPvJH = 8;

		private const int TBIwSkaeAAsYWNfBJpJcwVNGIrAF = 22;

		private const int xKsbbMvUPYShFTaAXkFYiuJfLNPN = 16;

		private const int uCpeOkXMiqDHYtgzbGLYFOBalhFI = 33;

		private const int XmoKnyHzejCHshGaeeGyXVzcXIOG = 8;

		private const int nrFqFCaGUqanNjJDzLDuqjfKUeCq = 9;

		private const int PrRimzRqJqwRmBGKzlvaYmRBybWc = 10;

		private const int mDpstFSRCNxasMkTimhSgyTxmCrl = 28;

		private const int thBPRCukweyyURxnniwhewIVCfAw = 53;

		private const int uyJeTxcyWbiTEFgUFNerRZgwRQiWA = 54;

		private const int bCpbeeOFgbbCWELjUVvTyZjRftAY = 43;

		private const int gEmUxForqhJRZyMLKcApvxrAWYiC = 42;

		private const int YtUYWywpULiJEcvNVkRaOjjmrBen = 48;

		private const bool XsdNmeymShcXTjDnVyRwMVhMjcJO = true;

		private const int IFeghejPYIXtgleRSkTTNajjZSAy = 60;

		private const int gCHTjScpTyeTtgeNokUmMmNmlYxU = 60;

		private const int oQXqTDAAARdOCewOhUmXOtAfuyIC = 3000000;

		private const float VkkgGVmYyeIOAEAOLIRAnAZGXoCB = 8192f;

		private const float faFBvIcdZDkvCXtxspWkSyydmNgCA = 0.0010652969f;

		private const float eLUeiWcpZHdfxfCAepfytNIWaEHy = 0.06103702f;

		private const bool lXiykMBIsfosvkpHmuWWjBOsDAGk = true;

		private const bool IEMlofhSFbKPVoCYtxpDwKORLSlT = true;

		private const bool XxqZMOZbaaJuImnZPzyCwbEfcki = true;

		private const bool lmvxoKmOvnwCsXGTYJqBDJWWAGbu = true;

		private const float EHzPMDywurfgMmYfSdKghKdTQxVL = 4096f;

		private const float YTrjqKEpZFhJsRSHsDERegFsMLyQ = 16384f;

		private const float PGoacecuLAvueSPKbeEtHiUBAkWZB = 16777216f;

		private const float WaKBvoUfxVQRTINfGlvTHHqUagSaA = 268435460f;

		private const float fwXiMvCQMLcfOCLgyfccnoCOOnLT = 0.01999998f;

		private const float hOXtqOSaPlJxeJXQIDKvuaxKgJwQ = 8192f;

		private const float kPRyWRDRjiEPdTHZkvkbfkzQXFTw = 0.98f;

		private const float NYxlhJVBjIjTRGTDaDkddbdPvuVT = 45f;

		private const float JjwnwSidBYCaQJozaneLhirHjMnRB = 20f;

		private const DualSenseVibrationMode UUcuHRqRctelkXcQtpjNSBVMDGKs = DualSenseVibrationMode.Compatible2;

		private readonly IHIDDevice ZdFSXvUnlWVNoPfuyZsGSFrsusHo;

		private readonly HIDProperties vrozqWboBcmcZvCOEluKoyEfQUog;

		private readonly bool BgtRWTwyVEJnVOijJMsGHDmyDSnV;

		private readonly int yIEdOoJqpKMaPaTGgwtZhiAddGJZB;

		private readonly int oAiGnMDigOYZMeDiaVOgoTTXKJXD;

		private readonly bool pcqUaIWUCdoXyXWfTlpntgfhvDgN;

		private readonly byte ipjebrnGjmNGlyhdVlmajKiKhEzn;

		private readonly int LNkXWJhmiDbknRTmGgSXXNOigUMHA;

		private readonly int YNAXGsogilNaxHFLIERADNAnfMoU;

		private readonly int bmgCsrJoloVBuuCMWLEUCEfhWftB;

		private readonly int YwbOyNetfEotQePjOGmibbsZmtRdA;

		private readonly NativeBuffer kEnFKlptNhVHBxlauKABlEiWaDhFA;

		private readonly NativeBuffer GKzZhLOTPLPjCuCDkkpFSDYNGphbA;

		private kotbTAfQioNEwLHSkuVgCDNCKFGrA pqPkUpAplnRUwVgmTBsEiOPLnCJy;

		private int cWZsfgISwaRbccdeupuQbMlWFuDF;

		private bool oVMfUlKHysDzorzogcDIALwyCxwe;

		private bool cugZTctQMcHOthniPoCqBECADxtOc;

		private double zdBuxwBzNIgmiLLDwetsAMtOPVhSA;

		private int tvLhjeDcEOoGYAxQXvCQZAQuwZpO;

		private FUyswnbErpCVCudNQomzpEvdCMHAA dXLCDeWtvPXrOPpYHbhaREQcCrTy;

		private bool MbzgVeRnsUQApVGMMcsDXUkXzdV;

		private Quaternion xLWhgCOgHuxDqftMGYesHDOOBixW;

		private DualSenseMicrophoneLightMode dBvMKBySsBiqBOnxzAJKPdJioJOH;

		private iSEHsVJspMEqbNLVTGJIXFuQBOuk LahGQgIYcZcMKIYvvaWjBIJDVnBhA;

		private DualSensePlayerLightFlags KwMsNiaTMxDqETgVRunGzBAWWSsM;

		private bool ENFZtZDIOtcfTSHzkOceCiDHKXHq;

		private uint KRWccWvBUmngBhxCiHUyBOURXpLv;

		private float eCQtcTxHpLWWzmbfFfkAHRWrkGvZ;

		private double cLotWuhcJcxcFziVjJggDUzdRGiH;

		private float FFeJTaCKBABDsbkaEEsSmBTsEgNiA;

		private readonly IDualSenseTriggerEffect[] YtGgRvCouJvaBhZlvNkSUObvEiIs;

		private readonly byte[] vWBnneDIuLOSyYiIpyWvKeGwhlAU;

		private readonly byte[] bHQJuCSCUYEXtJexZGBeCpiJkcMr;

		private DualSenseTriggerEffectState[] FkREweaLTofvSpvQkUYlOzrBOHaLA;

		private DualSenseVibrationMode HukYgCrOVKdXYCiHPKzPxdMfcpkK;

		private byte iQSRrnhEYWovIIMFInHREqMdgKQW;

		private bool YplxEczcazrCHYcmncSFCBVJmDSCA;

		private bool VVbYASONXoNOfTLKMTMsSxflwcsy;

		private bool PFDcwQfeofzGfnQOuEBdcntIgOOLA;

		private bool MyNAsVrAvwjhyQcxULtjbIuuqnRr;

		private bool YmsaCUMXCTjoXaRLCZtansUBjcle;

		private bool bYGcYQAlAnLDoUHJObhYyGqIAjPr;

		private bool vfopgAxXSeAJJSyMkbqeFyszMKfC;

		private bool FxxQHIEDmWjzvwJqgLSRgHvtaJdV;

		private bool MsQBuHfqXotpVlCvlekWKuFrhlXab;

		private byte RrULJkRipEclWucumzxXZzdDFyEQ;

		private byte dpPRpnaoNeEVbudVZXdMELpHpdmP;

		private Quaternion JohbdLfbPiEwvXnKHbrtYFFGnkcZ;

		private Quaternion ftKJVZvsdpFcOXKAjheHeWlJGvqt;

		private bool zNjmsEwAjgMsfCNYJgYTYQWokNXL;

		private int izdvOMMEUZfOtBWfwyvMewIaizSpA;

		private int[] GxmHaUBuwKQCooxqCRRlsDrbxafI;

		private int[] lCLIxEaVcaTKfcVKuLhUHvjEoMhK;

		private static uint[] xTdhdaFupWMOdkxznDaBoPQjbkmhb;

		private const uint FtjVLTolsBHnEGKrEGZfadTwgeshA = 3940166985u;

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

		private void WIXlfEWetdaqhMTHBgPrFVypwDvn(XhYmzuUQGnhOTiFQlJuRwfesjZJm P_0)
		{
		}

		private bool wkuVPaXozFUmkRNfQrpIeKJToQUI(XhYmzuUQGnhOTiFQlJuRwfesjZJm P_0)
		{
			return false;
		}

		private void LBbhhycLHCZwNNhxxEoKyVAplbGd()
		{
		}

		private void uwcLduHVUSHCYASfDEbZjpOmypfs(NativeBuffer P_0, int P_1)
		{
		}

		private void CUzeVeXMVFQDfilFuFNZVjCdFBrm(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
		}

		private bool JQiXVrkdCOFmQePjOKjialTwCxrH(XhYmzuUQGnhOTiFQlJuRwfesjZJm P_0)
		{
			return false;
		}

		private void kwoTRCPbWwbrUpdRlnThGfDKCcMJA(NativeBuffer P_0, double P_1)
		{
		}

		private void VCmocJyJyZKApxicMYhlfgmkZjrL(FWfncLHkdkAtpfBEQVIdHvRpLZvXA[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void yMpPAmYQISACnjZYElVLdLMIXobw()
		{
		}

		private void OnMjwRltSirESrEZicYKFRqZNJVFA(NativeBuffer P_0)
		{
		}

		private void FQLxwgoWoXsFASYCtGXEcyDyCinx()
		{
		}

		private static bool QYzixuqpeLECloUCTFYrodnPrSHt(ref Vector3 P_0)
		{
			return false;
		}

		private void wcaXyEtKeYQuXlgcBJdNlxPBIvXx(Vector3 P_0, Vector3 P_1)
		{
		}

		private static Quaternion FontJTpGsoDqNfhbDdORAAtjJTqrB(Quaternion P_0, Vector3 P_1)
		{
			return default(Quaternion);
		}

		private static Vector3 seKyknjwtzAAYwNgZZXaVdDKOwDD(Vector3 P_0, Vector3 P_1)
		{
			return default(Vector3);
		}

		private Quaternion VOmAGxnsCrfVmNtCNmNwUzcnVxdD(Quaternion P_0, xOkisjKBhqAvZOqSZvUUZFCzJbxN P_1)
		{
			return default(Quaternion);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			return default(Quaternion);
		}

		private float GOWxgRiAkCwcTvxfdvBpseGXCZgk(float P_0, float P_1)
		{
			return 0f;
		}

		private Vector3 PcpHgHEsTEvmUKyhtCXJDGijTTbWA(Vector3 P_0, float P_1 = 0f)
		{
			return default(Vector3);
		}

		private Quaternion izWdvHyWATqHudVuNuoFohtnAPTR(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion xVTyjTOvpJvIaDzcYEQBuWxRzFPJ(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private float HZKhvJSFKhUStNJcNuwNmHdHclAP(Vector3 P_0)
		{
			return 0f;
		}

		private bool OHOMCKCtkaCkimeBpdJSPtzSURnx(float P_0)
		{
			return false;
		}

		private bool aeyARwBZzVVAUfMzgZgNBjOScdFab(Vector3 P_0, out jQJvjijkjnBoqMNNtUyKZVNSofCO P_1)
		{
			P_1 = default(jQJvjijkjnBoqMNNtUyKZVNSofCO);
			return false;
		}

		private bool aSIMjydrcOwQePEUkvDrDgbKFqDM(Vector3 P_0)
		{
			return false;
		}

		private bool mpxIukwisdbsxwYcEQJbFjSAockH(Vector3 P_0)
		{
			return false;
		}

		private Vector3 silKJXkMcNpWqWtyMjAqBQWbuviu(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 PSBTRNTfDGNUZxsMohfhusokabf(RingBuffer<xWLdBqQUVoBsyEoHRMNAPSsWHYdgb.fxhQEpWZkJURQyIkTidPochghpyBA> P_0)
		{
			return default(Vector3);
		}

		private Vector3 sFBWgHjyWetzANKAIRcnJblqoUXs(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int GnWvqBjjhclinVzvLUIfbjkDDrNeA(int P_0)
		{
			return 0;
		}

		private void hLGHWBlXKPoUdwFNqnxYzkoiMcHn(byte[] P_0, float[] P_1)
		{
		}

		private void bBMMICslXaZHNDLfWuvfaNmCVZfb(byte[] P_0, float[] P_1)
		{
		}

		private float hpjEMhWjyacTQRGmItEUxFQMBxNx()
		{
			return 0f;
		}

		private void lJulUAHRnTeMbhwrqSbfOBwCChvEA(NativeBuffer P_0, ZgmSdKScSeDYiGUNgbCGiBZRFYxC.TouchData[] P_1)
		{
		}

		private int HyWtIduEdxpWzEZLqQVCaTIJKhCC(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void zeLEExFkIQApPAoMgPvVANpYajqzB()
		{
		}

		private void ZeRfPafsXJIdrGpKGhbppcCVINRE()
		{
		}

		private void cudsczKwlVRuPSWIrBMnXZPeZeSg()
		{
		}

		private void YKmnwwFMglumSSqgSOByvlwyZtzi()
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

		private static uint WsOZRqRgfpWHDNNtBdsXbigUUGVuA(NativeBuffer P_0, int P_1)
		{
			return 0u;
		}

		private static iSEHsVJspMEqbNLVTGJIXFuQBOuk wqueZjpUGWZrgYyozevDIxKxjwYO(DualSenseOtherLightBrightness P_0)
		{
			return default(iSEHsVJspMEqbNLVTGJIXFuQBOuk);
		}

		private static DualSenseOtherLightBrightness HuGqRGvpayVvZzKXDKUxMtNfYWvJ(iSEHsVJspMEqbNLVTGJIXFuQBOuk P_0)
		{
			return default(DualSenseOtherLightBrightness);
		}

		private static FKqjRWpsTKimdoeKBEnbdkHqVKdm AhEDMqWxKrPgqyLmMPjULgkUdBLk(DualSenseTriggerType P_0, byte P_1)
		{
			return default(FKqjRWpsTKimdoeKBEnbdkHqVKdm);
		}

		private static DualSenseTriggerEffectState nEuIEgxFhjJucOrEMCDAccJTxtPd(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			return default(DualSenseTriggerEffectState);
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
		}
	}
}
